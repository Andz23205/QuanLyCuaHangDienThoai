
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
        private readonly CultureInfo vn = new CultureInfo("vi-VN");

        private readonly HangHoaBUS hangHoaBus = new HangHoaBUS();

        private DataTable dtHang = new DataTable();
        private DataView dvHang = new DataView();

        private string tenAnh = "";

        // Thư mục Images nằm trong thư mục chạy chương trình
        private string ThuMucAnh =>
            Path.Combine(Application.StartupPath, "Images");

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

        // =====================================================
        // 1. KHỞI TẠO FORM
        // =====================================================

        private void Form1_Load(object? sender, EventArgs e)
        {
            NapCombo(
                cboHang,
                "SELECT MaHangSX, TenHangSX FROM tblHangSX ORDER BY TenHangSX",
                "TenHangSX",
                "MaHangSX"
            );

            NapCombo(
                cboLoai,
                "SELECT MaLoai, TenLoai FROM tblLoai ORDER BY TenLoai",
                "TenLoai",
                "MaLoai"
            );

            NapCombo(
                cboMau,
                "SELECT MaMau, TenMau FROM tblMau ORDER BY TenMau",
                "TenMau",
                "MaMau"
            );

            NapCombo(
                cboDungLuong,
                "SELECT MaDungLuong, TenDungLuong FROM tblDungLuong ORDER BY TenDungLuong",
                "TenDungLuong",
                "MaDungLuong"
            );

            dgvHang.ReadOnly = true;
            dgvHang.AllowUserToAddRows = false;
            dgvHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHang.MultiSelect = false;
            dgvHang.RowHeadersVisible = false;
            dgvHang.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            LoadData();
            LamLai();
        }

        // =====================================================
        // 2. NẠP COMBOBOX
        // =====================================================

        private void NapCombo(
            ComboBox cbo,
            string sql,
            string display,
            string value)
        {
            try
            {
                DataTable dt = DatabaseAccess.DocBang(sql);

                cbo.DataSource = dt;
                cbo.DisplayMember = display;
                cbo.ValueMember = value;
                cbo.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải danh mục: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =====================================================
        // 3. TẢI DANH SÁCH HÀNG HÓA
        // =====================================================

        private void LoadData()
        {
            try
            {
                // Lấy dữ liệu từ Stored Procedure
                dtHang = hangHoaBus.LayDanhSach();

                if (dtHang == null)
                {
                    throw new Exception(
                        "Không nhận được dữ liệu từ HangHoaBUS."
                    );
                }

                // Kiểm tra các cột bắt buộc
                string[] cotBatBuoc =
                {
                    "MaHang",
                    "TenHang",
                    "MaHangSX",
                    "MaLoai",
                    "MaMau",
                    "MaDungLuong",
                    "Hang",
                    "Loai",
                    "Mau",
                    "DungLuong",
                    "DonGiaNhap",
                    "DonGiaBan",
                    "SoLuongTon",
                    "TenAnh"
                };

                foreach (string cot in cotBatBuoc)
                {
                    if (!dtHang.Columns.Contains(cot))
                    {
                        throw new Exception(
                            "Dữ liệu trả về không có cột: " + cot +
                            ". Hãy kiểm tra Stored Procedure sp_LayDanhSachHang."
                        );
                    }
                }

                dvHang = new DataView(dtHang);
                dgvHang.DataSource = dvHang;

                // Đặt tên hiển thị cho các cột
                var tieuDe = new Dictionary<string, string>
                {
                    ["MaHang"] = "Mã hàng",
                    ["TenHang"] = "Tên điện thoại",
                    ["Hang"] = "Hãng sản xuất",
                    ["Loai"] = "Loại",
                    ["Mau"] = "Màu",
                    ["DungLuong"] = "Dung lượng",
                    ["DonGiaNhap"] = "Giá nhập",
                    ["DonGiaBan"] = "Giá bán",
                    ["SoLuongTon"] = "Số lượng tồn"
                };

                foreach (var kv in tieuDe)
                {
                    if (dgvHang.Columns.Contains(kv.Key))
                    {
                        dgvHang.Columns[kv.Key]!.HeaderText = kv.Value;
                    }
                }

                // Ẩn các cột mã danh mục và ảnh
                string[] cotAn =
                {
                    "MaHangSX",
                    "MaLoai",
                    "MaMau",
                    "MaDungLuong",
                    "TenAnh",
                    "MoTa"
                };

                foreach (string cot in cotAn)
                {
                    if (dgvHang.Columns.Contains(cot))
                    {
                        dgvHang.Columns[cot]!.Visible = false;
                    }
                }

                // Định dạng tiền
                foreach (string cot in new[]
                {
                    "DonGiaNhap",
                    "DonGiaBan"
                })
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
                MessageBox.Show(
                    "Lỗi tải dữ liệu hàng hóa:\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =====================================================
        // 4. CHỌN MỘT SẢN PHẨM TRÊN DATAGRIDVIEW
        // =====================================================

        private void dgvHang_CellClick(
            object? sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvHang.Rows[e.RowIndex].DataBoundItem
                is not DataRowView r)
                return;

            txtMaHang.Text = r["MaHang"]?.ToString() ?? "";

            txtMaHang.ReadOnly = true;

            txtTenHang.Text = r["TenHang"]?.ToString() ?? "";

            // Hãng sản xuất
            if (r["MaHangSX"] != DBNull.Value)
                cboHang.SelectedValue = r["MaHangSX"].ToString();
            else
                cboHang.SelectedIndex = -1;

            // Loại điện thoại
            if (r["MaLoai"] != DBNull.Value)
                cboLoai.SelectedValue = r["MaLoai"].ToString();
            else
                cboLoai.SelectedIndex = -1;

            // Màu sắc
            if (r["MaMau"] != DBNull.Value)
                cboMau.SelectedValue = r["MaMau"].ToString();
            else
                cboMau.SelectedIndex = -1;

            // Dung lượng
            if (r["MaDungLuong"] != DBNull.Value)
                cboDungLuong.SelectedValue = r["MaDungLuong"].ToString();
            else
                cboDungLuong.SelectedIndex = -1;

            // Giá nhập
            if (r["DonGiaNhap"] != DBNull.Value)
            {
                decimal gn = Convert.ToDecimal(r["DonGiaNhap"]);

                txtGiaNhap.Text = gn.ToString("N0", vn);
            }
            else
            {
                txtGiaNhap.Clear();
            }

            // Giá bán
            if (r["DonGiaBan"] != DBNull.Value)
            {
                decimal gb = Convert.ToDecimal(r["DonGiaBan"]);

                txtGiaBan.Text = gb.ToString("N0", vn);
            }
            else
            {
                txtGiaBan.Clear();
            }

            // Số lượng tồn
            txtSoLuong.Text = r["SoLuongTon"] == DBNull.Value
                ? "0"
                : r["SoLuongTon"].ToString();

            // Tên ảnh
            tenAnh = r["TenAnh"] == DBNull.Value
                ? ""
                : r["TenAnh"].ToString() ?? "";

            lblTenAnh.Text = tenAnh;

            HienAnh(tenAnh);
        }

        // =====================================================
        // 5. CHỌN ẢNH ĐIỆN THOẠI
        // =====================================================

        private void btnChonAnh_Click(object? sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog
            {
                Title = "Chọn ảnh điện thoại",
                Filter = "Ảnh điện thoại|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
            };

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                Directory.CreateDirectory(ThuMucAnh);

                string ten = Path.GetFileName(ofd.FileName);

                string dich = Path.Combine(ThuMucAnh, ten);

                if (!string.Equals(
                    Path.GetFullPath(ofd.FileName),
                    Path.GetFullPath(dich),
                    StringComparison.OrdinalIgnoreCase))
                {
                    File.Copy(ofd.FileName, dich, true);
                }

                tenAnh = ten;

                lblTenAnh.Text = ten;

                HienAnh(ten);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải ảnh: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // =====================================================
        // 6. HIỂN THỊ ẢNH
        // =====================================================

        private void HienAnh(string ten)
        {
            picAnh.Image?.Dispose();
            picAnh.Image = null;

            if (string.IsNullOrWhiteSpace(ten))
                return;

            string tenFile = Path.GetFileName(ten.Trim());

            string duongDan = Path.Combine(ThuMucAnh, tenFile);

            if (!File.Exists(duongDan))
                return;

            try
            {
                using Bitmap bmp = new Bitmap(duongDan);

                picAnh.Image = new Bitmap(bmp);

                picAnh.SizeMode = PictureBoxSizeMode.Zoom;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể hiển thị ảnh:\n" +
                    duongDan +
                    "\n\n" + ex.Message,
                    "Lỗi ảnh",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        // =====================================================
        // 7. ĐỌC GIÁ TIỀN
        // =====================================================

        private bool DocTien(string s, out decimal tien)
        {
            return decimal.TryParse(
                s.Trim(),
                NumberStyles.Number,
                vn,
                out tien
            ) && tien >= 0;
        }

        // =====================================================
        // 8. HIỂN THỊ THÔNG BÁO LỖI
        // =====================================================

        private static void Loi(string thongBao, Control ctrl)
        {
            MessageBox.Show(
                thongBao,
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );

            ctrl.Focus();
        }

        // =====================================================
        // 9. TẠO ĐỐI TƯỢNG HÀNG HÓA
        // =====================================================

        private bool TaoDoiTuongHang(out HangHoa? hang)
        {
            hang = null;

            if (string.IsNullOrWhiteSpace(txtMaHang.Text))
            {
                Loi("Chưa nhập mã hàng.", txtMaHang);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTenHang.Text))
            {
                Loi("Chưa nhập tên hàng.", txtTenHang);
                return false;
            }

            if (cboHang.SelectedIndex < 0)
            {
                Loi("Chưa chọn hãng sản xuất.", cboHang);
                return false;
            }

            if (cboLoai.SelectedIndex < 0)
            {
                Loi("Chưa chọn loại hàng.", cboLoai);
                return false;
            }

            if (cboMau.SelectedIndex < 0)
            {
                Loi("Chưa chọn màu sắc.", cboMau);
                return false;
            }

            if (!DocTien(txtGiaNhap.Text, out decimal gn))
            {
                Loi("Giá nhập phải là số không âm.", txtGiaNhap);
                return false;
            }

            if (!DocTien(txtGiaBan.Text, out decimal gb))
            {
                Loi("Giá bán phải là số không âm.", txtGiaBan);
                return false;
            }

            if (!int.TryParse(txtSoLuong.Text.Trim(), out int sl) || sl < 0)
            {
                Loi(
                    "Số lượng tồn phải là số nguyên không âm.",
                    txtSoLuong
                );

                return false;
            }

            hang = new HangHoa(
                txtMaHang.Text.Trim(),
                txtTenHang.Text.Trim(),
                cboHang.SelectedValue?.ToString(),
                cboLoai.SelectedValue?.ToString(),
                cboMau.SelectedValue?.ToString(),
                cboDungLuong.SelectedValue?.ToString(),
                gn,
                gb,
                sl
            );

            hang.TenAnh = tenAnh;

            return true;
        }

        // =====================================================
        // 10. THÊM HÀNG HÓA
        // =====================================================

        private void btnThem_Click(object? sender, EventArgs e)
        {
            if (!TaoDoiTuongHang(out HangHoa? hang) || hang == null)
                return;

            if (hangHoaBus.Them(hang, out string error))
            {
                MessageBox.Show(
                    "Thêm mặt hàng thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                LoadData();
                LamLai();
            }
            else
            {
                MessageBox.Show(
                    error,
                    "Lỗi thêm",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        // =====================================================
        // 11. SỬA HÀNG HÓA
        // =====================================================


        private void btnSua_Click(object? sender, EventArgs e)
        {
            // Kiểm tra đã chọn sản phẩm cần sửa chưa
            if (!txtMaHang.ReadOnly)
            {
                MessageBox.Show(
                    "Hãy chọn một dòng trong danh sách để sửa."
                );
                return;
            }

            // Lấy thông tin sản phẩm từ các ô nhập
            if (!TaoDoiTuongHang(out HangHoa? hang) || hang == null)
                return;

            // Đảm bảo tên ảnh mới được lưu vào đối tượng
            hang.TenAnh = tenAnh;

            // Cập nhật sản phẩm xuống SQL Server
            if (hangHoaBus.Sua(hang, out string error))
            {
                MessageBox.Show(
                    "Cập nhật sản phẩm thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                LoadData();
                LamLai();
            }
            else
            {
                MessageBox.Show(
                    string.IsNullOrWhiteSpace(error)
                        ? "Cập nhật sản phẩm thất bại!"
                        : error,
                    "Lỗi cập nhật",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        // =====================================================
        // 12. XÓA HÀNG HÓA
        // =====================================================

        private void btnXoa_Click(object? sender, EventArgs e)
        {
            if (!txtMaHang.ReadOnly)
            {
                MessageBox.Show(
                    "Hãy chọn một dòng trong danh sách để xóa."
                );

                return;
            }

            string ma = txtMaHang.Text.Trim();

            if (MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa mặt hàng {ma}?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            ) != DialogResult.Yes)
            {
                return;
            }

            if (hangHoaBus.Xoa(ma, out string error))
            {
                MessageBox.Show(
                    "Đã xóa mặt hàng!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                LoadData();
                LamLai();
            }
            else
            {
                MessageBox.Show(
                    error,
                    "Lỗi xóa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        // =====================================================
        // 13. LÀM LẠI FORM
        // =====================================================

        private void btnLamLai_Click(object? sender, EventArgs e)
        {
            txtTim.Clear();

            if (dvHang != null)
                dvHang.RowFilter = "";

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

        // =====================================================
        // 14. TÌM KIẾM HÀNG HÓA
        // =====================================================

        private void btnTim_Click(object? sender, EventArgs e)
        {
            string tk = txtTim.Text.Trim().Replace("'", "''");

            if (dvHang == null)
                return;

            if (tk.Length == 0)
            {
                dvHang.RowFilter = "";
                return;
            }

            dvHang.RowFilter =
                $"TenHang LIKE '%{tk}%' OR MaHang LIKE '%{tk}%'";

            if (dvHang.Count == 0)
            {
                MessageBox.Show(
                    "Không tìm thấy mặt hàng nào phù hợp.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }
    }
}
