using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    public partial class Form1 : Form
    {
        private readonly CultureInfo vn = new("vi-VN");
        private readonly HangHoaBUS hangHoaBus = new HangHoaBUS();
        private DataTable dtHang = new DataTable();
        private DataView dvHang = new DataView();
        private string tenAnh = "";
        private string ThuMucAnh => Path.Combine(Application.StartupPath, "Images");

        public Form1()
        {
            InitializeComponent();

            Load += Form1_Load;
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamLai.Click += btnLamLai_Click;
            btnThoat.Click += (s, e) => Close();
            btnChonAnh.Click += btnChonAnh_Click;
            btnTim.Click += btnTim_Click;
            dgvHang.CellClick += dgvHang_CellClick;
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            NapCombo(cboHang, "SELECT MaHangSX, TenHangSX FROM tblHangSX ORDER BY TenHangSX", "TenHangSX", "MaHangSX");
            NapCombo(cboLoai, "SELECT MaLoai, TenLoai FROM tblLoai ORDER BY TenLoai", "TenLoai", "MaLoai");
            NapCombo(cboMau, "SELECT MaMau, TenMau FROM tblMau ORDER BY TenMau", "TenMau", "MaMau");
            NapCombo(cboDungLuong, "SELECT MaDungLuong, TenDungLuong FROM tblDungLuong ORDER BY TenDungLuong", "TenDungLuong", "MaDungLuong");

            dgvHang.ReadOnly = true;
            dgvHang.AllowUserToAddRows = false;
            dgvHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHang.MultiSelect = false;
            dgvHang.RowHeadersVisible = false;
            dgvHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            LoadData();
            LamLai();
        }

        private void NapCombo(ComboBox cbo, string sql, string display, string value)
        {
            try
            {
                DataTable dt = DatabaseAccess.DocBang(sql);
                cbo.DataSource = dt;
                cbo.DisplayMember = display;
                cbo.ValueMember = value;
                cbo.SelectedIndex = -1;
            }
            catch { }
        }

        private void LoadData()
        {
            try
            {
                // Goi qua tang BUS (va thuc thi Stored Procedure sp_LayDanhSachHang)
                dtHang = hangHoaBus.LayDanhSach();
                dvHang = new DataView(dtHang);
                dgvHang.DataSource = dvHang;

                var tieuDe = new Dictionary<string, string>
                {
                    ["MaHang"] = "Mã hàng",
                    ["TenHang"] = "Tên hàng",
                    ["Hang"] = "Hãng",
                    ["Loai"] = "Loại",
                    ["Mau"] = "Màu",
                    ["DungLuong"] = "Dung lượng",
                    ["GiaNhap"] = "Giá nhập",
                    ["GiaBan"] = "Giá bán",
                    ["SoLuong"] = "Số lượng tồn"
                };

                foreach (var kv in tieuDe)
                {
                    if (dgvHang.Columns.Contains(kv.Key))
                        dgvHang.Columns[kv.Key]!.HeaderText = kv.Value;
                }

                foreach (var col in new[] { "MaHangSX", "MaLoai", "MaMau", "MaDungLuong" })
                {
                    if (dgvHang.Columns.Contains(col))
                        dgvHang.Columns[col]!.Visible = false;
                }

                foreach (var cot in new[] { "GiaNhap", "GiaBan" })
                {
                    if (dgvHang.Columns.Contains(cot))
                    {
                        dgvHang.Columns[cot]!.DefaultCellStyle.Format = "N0";
                        dgvHang.Columns[cot]!.DefaultCellStyle.FormatProvider = vn;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void dgvHang_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvHang.Rows[e.RowIndex].DataBoundItem is not DataRowView r) return;

            txtMaHang.Text = r["MaHang"].ToString();
            txtMaHang.ReadOnly = true;
            txtTenHang.Text = r["TenHang"].ToString();

            if (r["MaHangSX"] != DBNull.Value) cboHang.SelectedValue = r["MaHangSX"].ToString();
            else cboHang.SelectedIndex = -1;

            if (r["MaLoai"] != DBNull.Value) cboLoai.SelectedValue = r["MaLoai"].ToString();
            else cboLoai.SelectedIndex = -1;

            if (r["MaMau"] != DBNull.Value) cboMau.SelectedValue = r["MaMau"].ToString();
            else cboMau.SelectedIndex = -1;

            if (r["MaDungLuong"] != DBNull.Value) cboDungLuong.SelectedValue = r["MaDungLuong"].ToString();
            else cboDungLuong.SelectedIndex = -1;

            if (decimal.TryParse(r["GiaNhap"].ToString(), out decimal gn))
                txtGiaNhap.Text = gn.ToString("N0", vn);
            if (decimal.TryParse(r["GiaBan"].ToString(), out decimal gb))
                txtGiaBan.Text = gb.ToString("N0", vn);

            txtSoLuong.Text = r["SoLuong"].ToString();

            tenAnh = "";
            lblTenAnh.Text = "";
            HienAnh("");
        }

        private void btnChonAnh_Click(object? sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog
            {
                Title = "Chọn ảnh điện thoại",
                Filter = "Ảnh|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
            };
            if (ofd.ShowDialog() != DialogResult.OK) return;

            try
            {
                Directory.CreateDirectory(ThuMucAnh);
                string ten = Path.GetFileName(ofd.FileName);
                string dich = Path.Combine(ThuMucAnh, ten);
                if (!File.Exists(dich)) File.Copy(ofd.FileName, dich, true);
                tenAnh = ten;
                lblTenAnh.Text = ten;
                HienAnh(ten);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải ảnh: " + ex.Message);
            }
        }

        private void HienAnh(string ten)
        {
            picAnh.Image?.Dispose();
            picAnh.Image = null;
            if (string.IsNullOrEmpty(ten)) return;

            string duongDan = Path.Combine(ThuMucAnh, ten);
            if (!File.Exists(duongDan)) return;

            using var bmp = new Bitmap(duongDan);
            picAnh.Image = new Bitmap(bmp);
            picAnh.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private bool DocTien(string s, out decimal tien)
        {
            string clean = s.Replace(".", "").Replace(",", "").Trim();
            return decimal.TryParse(clean, NumberStyles.Number, CultureInfo.InvariantCulture, out tien) && tien >= 0;
        }

        private static void Loi(string thongBao, Control ctrl)
        {
            MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            ctrl.Focus();
        }

        private bool TaoDoiTuongHang(out HangHoa? hang)
        {
            hang = null;
            if (string.IsNullOrWhiteSpace(txtMaHang.Text)) { Loi("Chưa nhập mã hàng.", txtMaHang); return false; }
            if (string.IsNullOrWhiteSpace(txtTenHang.Text)) { Loi("Chưa nhập tên hàng.", txtTenHang); return false; }
            if (cboHang.SelectedIndex < 0) { Loi("Chưa chọn hãng sản xuất.", cboHang); return false; }
            if (cboLoai.SelectedIndex < 0) { Loi("Chưa chọn loại hàng.", cboLoai); return false; }
            if (cboMau.SelectedIndex < 0) { Loi("Chưa chọn màu sắc.", cboMau); return false; }
            if (!DocTien(txtGiaNhap.Text, out decimal gn)) { Loi("Giá nhập phải là số không âm.", txtGiaNhap); return false; }
            if (!DocTien(txtGiaBan.Text, out decimal gb)) { Loi("Giá bán phải là số không âm.", txtGiaBan); return false; }
            if (!int.TryParse(txtSoLuong.Text.Trim(), out int sl) || sl < 0)
            { Loi("Số lượng tồn phải là số nguyên không âm.", txtSoLuong); return false; }

            hang = new HangHoa(
                txtMaHang.Text.Trim(),
                txtTenHang.Text.Trim(),
                cboHang.SelectedValue?.ToString(),
                cboLoai.SelectedValue?.ToString(),
                cboMau.SelectedValue?.ToString(),
                cboDungLuong.SelectedValue?.ToString(),
                gn, gb, sl
            );
            return true;
        }

        private void btnThem_Click(object? sender, EventArgs e)
        {
            if (!TaoDoiTuongHang(out HangHoa? hang) || hang == null) return;

            // Thuc hien qua tang BUS
            if (hangHoaBus.Them(hang, out string error))
            {
                MessageBox.Show("Thêm mặt hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                LamLai();
            }
            else
            {
                MessageBox.Show(error, "Lỗi thêm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSua_Click(object? sender, EventArgs e)
        {
            if (!txtMaHang.ReadOnly)
            {
                MessageBox.Show("Hãy chọn một dòng trong danh sách để sửa.");
                return;
            }
            if (!TaoDoiTuongHang(out HangHoa? hang) || hang == null) return;

            // Thuc hien qua tang BUS
            if (hangHoaBus.Sua(hang, out string error))
            {
                MessageBox.Show("Cập nhật mặt hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                LamLai();
            }
            else
            {
                MessageBox.Show(error, "Lỗi sửa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object? sender, EventArgs e)
        {
            if (!txtMaHang.ReadOnly)
            {
                MessageBox.Show("Hãy chọn một dòng trong danh sách để xóa.");
                return;
            }

            string ma = txtMaHang.Text.Trim();
            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa mặt hàng {ma}?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            // Thuc hien qua tang BUS
            if (hangHoaBus.Xoa(ma, out string error))
            {
                MessageBox.Show("Đã xóa mặt hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                LamLai();
            }
            else
            {
                MessageBox.Show(error, "Lỗi xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLamLai_Click(object? sender, EventArgs e)
        {
            txtTim.Clear();
            if (dvHang != null) dvHang.RowFilter = "";
            LamLai();
        }

        private void LamLai()
        {
            txtMaHang.ReadOnly = false;
            txtMaHang.Clear();
            txtTenHang.Clear();
            txtGiaNhap.Clear();
            txtGiaBan.Clear();
            txtSoLuong.Clear();
            cboHang.SelectedIndex = -1;
            cboLoai.SelectedIndex = -1;
            cboMau.SelectedIndex = -1;
            cboDungLuong.SelectedIndex = -1;
            tenAnh = "";
            lblTenAnh.Text = "";
            HienAnh("");
            dgvHang.ClearSelection();
            txtMaHang.Focus();
        }

        private void btnTim_Click(object? sender, EventArgs e)
        {
            string tk = txtTim.Text.Trim().Replace("'", "''");
            if (dvHang == null) return;
            dvHang.RowFilter = tk.Length == 0 ? "" : $"TenHang LIKE '%{tk}%' OR MaHang LIKE '%{tk}%'";
            if (dvHang.Count == 0)
                MessageBox.Show("Không tìm thấy mặt hàng nào phù hợp.");
        }
    }
}