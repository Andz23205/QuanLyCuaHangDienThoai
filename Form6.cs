using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    public partial class Form6 : Form
    {
        private readonly CultureInfo vn = new("vi-VN");
        private readonly HangHoaBUS hangHoaBus = new HangHoaBUS();
        private DataTable dtKetQua = new DataTable();

        public Form6()
        {
            InitializeComponent();

            button1.Text = "Tìm kiếm";
            button2.Text = "Làm lại";
            button3.Text = "Xuất Excel";
            button4.Text = "Thoát";

            Load += Form6_Load;
            button1.Click += btnTimKiem_Click;
            button2.Click += btnLamLai_Click;
            button3.Click += btnXuatExcel_Click;
            button4.Click += (s, e) => Close();
        }

        private void Form6_Load(object? sender, EventArgs e)
        {
            NapCombo(cboHang, "SELECT MaHangSX, TenHangSX FROM tblHangSX ORDER BY TenHangSX", "TenHangSX", "MaHangSX");
            NapCombo(cboLoai, "SELECT MaLoai, TenLoai FROM tblLoai ORDER BY TenLoai", "TenLoai", "MaLoai");
            NapCombo(cboMau, "SELECT MaMau, TenMau FROM tblMau ORDER BY TenMau", "TenMau", "MaMau");

            dgvKetQua.AutoGenerateColumns = false;
            ColMaHang.DataPropertyName = "MaHang";
            colTenHang.DataPropertyName = "TenHang";
            colHang.DataPropertyName = "Hang";
            colLoai.DataPropertyName = "Loai";
            colMau.DataPropertyName = "Mau";
            colDungLuong.DataPropertyName = "DungLuong";
            colGiaBan.DataPropertyName = "DonGiaBan";
            colSL.DataPropertyName = "SoLuongTon";

            dgvKetQua.ReadOnly = true;
            dgvKetQua.AllowUserToAddRows = false;
            dgvKetQua.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKetQua.MultiSelect = false;
            dgvKetQua.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            colGiaBan.DefaultCellStyle.Format = "N0";
            colGiaBan.DefaultCellStyle.FormatProvider = vn;

            ThucHienTimKiem();
        }

        private void NapCombo(ComboBox cbo, string sql, string display, string value)
        {
            try
            {
                DataTable dt = DatabaseAccess.DocBang(sql);
                DataRow dr = dt.NewRow();
                dr[display] = "-- Tất cả --";
                dr[value] = "";
                dt.Rows.InsertAt(dr, 0);

                cbo.DataSource = dt;
                cbo.DisplayMember = display;
                cbo.ValueMember = value;
                cbo.SelectedIndex = 0;
            }
            catch { }
        }

        private void btnTimKiem_Click(object? sender, EventArgs e)
        {
            ThucHienTimKiem();
        }

        private void ThucHienTimKiem()
        {
            try
            {
                string? ten = string.IsNullOrWhiteSpace(txtTenHang.Text) ? null : txtTenHang.Text.Trim();
                string? hang = cboHang.SelectedIndex > 0 ? cboHang.SelectedValue?.ToString() : null;
                string? loai = cboLoai.SelectedIndex > 0 ? cboLoai.SelectedValue?.ToString() : null;
                string? mau = cboMau.SelectedIndex > 0 ? cboMau.SelectedValue?.ToString() : null;

                decimal? giaTu = null;
                if (decimal.TryParse(txtGiaTu.Text.Replace(".", "").Replace(",", "").Trim(), out decimal gt) && gt > 0)
                    giaTu = gt;

                decimal? giaDen = null;
                if (decimal.TryParse(txtGiaDen.Text.Replace(".", "").Replace(",", "").Trim(), out decimal gd) && gd > 0)
                    giaDen = gd;

                // Goi qua tang BUS (va thuc thi Stored Procedure sp_TimKiemHang)
                dtKetQua = hangHoaBus.TimKiem(ten, hang, loai, mau, giaTu, giaDen);
                dgvKetQua.DataSource = dtKetQua;

                label6.Text = $"Tìm thấy {dtKetQua.Rows.Count} sản phẩm";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        private void btnLamLai_Click(object? sender, EventArgs e)
        {
            txtTenHang.Clear();
            txtGiaTu.Clear();
            txtGiaDen.Clear();
            if (cboHang.Items.Count > 0) cboHang.SelectedIndex = 0;
            if (cboLoai.Items.Count > 0) cboLoai.SelectedIndex = 0;
            if (cboMau.Items.Count > 0) cboMau.SelectedIndex = 0;
            ThucHienTimKiem();
        }

        private void btnXuatExcel_Click(object? sender, EventArgs e)
        {
            if (dtKetQua.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất Excel!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Excel Files (*.xlsx)|*.xlsx",
                FileName = $"BaoCao_SanPham_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx",
                Title = "Lưu file Excel kết quả tìm kiếm"
            };

            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                using var wb = new XLWorkbook();
                var ws = wb.Worksheets.Add("DanhSachSanPham");

                // Tiêu đề
                ws.Cell(1, 1).Value = "BÁO CÁO DANH SÁCH SẢN PHẨM";
                var titleRange = ws.Range("A1:I1");
                titleRange.Merge();
                titleRange.Style.Font.FontSize = 16;
                titleRange.Style.Font.Bold = true;
                titleRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                ws.Cell(2, 1).Value = $"Thời gian xuất: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
                ws.Cell(2, 1).Style.Font.Italic = true;

                // Header
                string[] headers = { "STT", "Mã hàng", "Tên hàng", "Hãng", "Loại", "Màu", "Dung lượng", "Giá bán (VNĐ)", "Tồn kho" };
                for (int i = 0; i < headers.Length; i++)
                {
                    var cell = ws.Cell(4, i + 1);
                    cell.Value = headers[i];
                    cell.Style.Font.Bold = true;
                    cell.Style.Fill.BackgroundColor = XLColor.LightSteelBlue;
                    cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                }

                // Dữ liệu
                int rowIdx = 5;
                for (int i = 0; i < dtKetQua.Rows.Count; i++)
                {
                    DataRow r = dtKetQua.Rows[i];
                    ws.Cell(rowIdx, 1).Value = i + 1;
                    ws.Cell(rowIdx, 2).Value = r["MaHang"]?.ToString();
                    ws.Cell(rowIdx, 3).Value = r["TenHang"]?.ToString();
                    ws.Cell(rowIdx, 4).Value = r["Hang"]?.ToString();
                    ws.Cell(rowIdx, 5).Value = r["Loai"]?.ToString();
                    ws.Cell(rowIdx, 6).Value = r["Mau"]?.ToString();
                    ws.Cell(rowIdx, 7).Value = r["DungLuong"]?.ToString();
                    ws.Cell(rowIdx, 8).Value = Convert.ToDecimal(r["DonGiaBan"]);
                    ws.Cell(rowIdx, 8).Style.NumberFormat.Format = "#,##0";
                    ws.Cell(rowIdx, 9).Value = Convert.ToInt32(r["SoLuongTon"]);
                    // Viền
                    ws.Range(rowIdx, 1, rowIdx, 9).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    rowIdx++;
                }

                ws.Columns().AdjustToContents();
                wb.SaveAs(sfd.FileName);

                MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = sfd.FileName,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}