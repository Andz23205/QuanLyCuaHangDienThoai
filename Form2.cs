using System.Data;
using System.Text.RegularExpressions;
using Microsoft.Data.SqlClient;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    // FORM 2: Quản lý nhân viên (frmNhanVien) - dùng SQL Server, bảng tblNhanVien
    // Ô "Chức vụ" lưu vào cột VaiTro, ô "Mật khẩu" lưu vào cột MatKhau.
    public partial class Form2 : Form
    {
        private static readonly string[] DanhSachChucVu = { "Quản lý", "Nhân viên" };

        public Form2()
        {
            InitializeComponent();

            // Gắn sự kiện bằng code (KHÔNG nhấp đúp vào nút trong Designer, kẻo nút chạy 2 lần)
            Load += Form2_Load;
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamLai.Click += btnLamLai_Click;
            btnThoat.Click += (s, e) => Close();
            btnTim.Click += btnTim_Click;
            dgvNhanVien.CellClick += dgvNhanVien_CellClick;
        }

        // ---------- Khởi tạo ----------
        private void Form2_Load(object? sender, EventArgs e)
        {
            txtMaNV.MaxLength = 20;       // khớp độ dài cột trong SQL
            txtTenNV.MaxLength = 100;
            txtSDT.MaxLength = 15;
            txtDiaChi.MaxLength = 200;
            txtMatKhau.MaxLength = 255;

            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            dtpNgaySinh.MaxDate = DateTime.Today;

            txtMatKhau.UseSystemPasswordChar = true;

            cboChucVu.DropDownStyle = ComboBoxStyle.DropDownList;
            cboChucVu.Items.Clear();
            cboChucVu.Items.AddRange(DanhSachChucVu);

            dgvNhanVien.ReadOnly = true;
            dgvNhanVien.AllowUserToAddRows = false;
            dgvNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNhanVien.MultiSelect = false;
            dgvNhanVien.RowHeadersVisible = false;
            dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            try { NapLuoi(); }
            catch (Exception ex)
            {
                MessageBox.Show("Không kết nối được CSDL. Hãy kiểm tra SQL Server và KetNoiCSDL.cs.\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LamLai();
        }

        private static string ThoatLike(string s) =>
            s.Replace("[", "[[]").Replace("%", "[%]").Replace("_", "[_]");

        private void NapLuoi(string tuKhoa = "")
        {
            // Không lấy cột MatKhau lên lưới để tránh lộ mật khẩu
            dgvNhanVien.DataSource = KetNoiCSDL.LayBang(@"
                SELECT MaNV, TenNV, GioiTinh, NgaySinh, SDT, DiaChi, VaiTro
                FROM tblNhanVien
                WHERE TenNV LIKE @tk
                ORDER BY MaNV",
                KetNoiCSDL.Tham("@tk", "%" + ThoatLike(tuKhoa.Trim()) + "%"));

            var tieuDe = new Dictionary<string, string>
            {
                ["MaNV"] = "Mã NV",
                ["TenNV"] = "Họ tên",
                ["GioiTinh"] = "Giới tính",
                ["NgaySinh"] = "Ngày sinh",
                ["SDT"] = "Số ĐT",
                ["DiaChi"] = "Địa chỉ",
                ["VaiTro"] = "Chức vụ"
            };
            foreach (var kv in tieuDe) dgvNhanVien.Columns[kv.Key]!.HeaderText = kv.Value;
            dgvNhanVien.Columns["NgaySinh"]!.DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvNhanVien.ClearSelection();
        }

        // ---------- Đổ dữ liệu khi bấm vào dòng ----------
        private void dgvNhanVien_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvNhanVien.Rows[e.RowIndex].DataBoundItem is not DataRowView r) return;

            txtMaNV.Text = r["MaNV"].ToString();
            txtMaNV.ReadOnly = true;                          // khóa chính, không cho sửa
            txtTenNV.Text = r["TenNV"].ToString();

            if (r["NgaySinh"] is DateTime ns)                 // NgaySinh có thể NULL
                dtpNgaySinh.Value = ns < dtpNgaySinh.MinDate ? dtpNgaySinh.MinDate
                                  : ns > dtpNgaySinh.MaxDate ? dtpNgaySinh.MaxDate : ns;

            bool nu = r["GioiTinh"].ToString() == "Nữ";
            radNu.Checked = nu;
            radNam.Checked = !nu;

            txtSDT.Text = r["SDT"].ToString();
            txtDiaChi.Text = r["DiaChi"].ToString();
            cboChucVu.SelectedItem = r["VaiTro"].ToString();

            // Để trống: nếu bấm Sửa mà không nhập thì giữ nguyên mật khẩu cũ
            txtMatKhau.Clear();
        }

        // ---------- Kiểm tra dữ liệu ----------
        private static void Loi(string noiDung, Control c)
        {
            MessageBox.Show(noiDung, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            c.Focus();
        }

        private bool KiemTra(bool batBuocMatKhau)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text)) { Loi("Chưa nhập mã nhân viên.", txtMaNV); return false; }
            if (string.IsNullOrWhiteSpace(txtTenNV.Text)) { Loi("Chưa nhập họ tên.", txtTenNV); return false; }
            if (!radNam.Checked && !radNu.Checked) { Loi("Chưa chọn giới tính.", radNam); return false; }
            if (!Regex.IsMatch(txtSDT.Text.Trim(), @"^0\d{9}$"))
            { Loi("Số điện thoại phải gồm 10 chữ số và bắt đầu bằng 0.", txtSDT); return false; }
            if (cboChucVu.SelectedIndex < 0) { Loi("Chưa chọn chức vụ.", cboChucVu); return false; }
            if (string.IsNullOrWhiteSpace(txtDiaChi.Text)) { Loi("Chưa nhập địa chỉ.", txtDiaChi); return false; }
            if (batBuocMatKhau && string.IsNullOrEmpty(txtMatKhau.Text))
            { Loi("Chưa nhập mật khẩu.", txtMatKhau); return false; }
            return true;
        }

        private SqlParameter[] ThamSo() => new[]
        {
            KetNoiCSDL.Tham("@ma", txtMaNV.Text.Trim()),
            KetNoiCSDL.Tham("@ten", txtTenNV.Text.Trim()),
            KetNoiCSDL.Tham("@ns", dtpNgaySinh.Value.Date),
            KetNoiCSDL.Tham("@gt", radNam.Checked ? "Nam" : "Nữ"),
            KetNoiCSDL.Tham("@sdt", txtSDT.Text.Trim()),
            KetNoiCSDL.Tham("@dc", txtDiaChi.Text.Trim()),
            KetNoiCSDL.Tham("@vt", cboChucVu.SelectedItem!.ToString()),
            KetNoiCSDL.Tham("@mk", txtMatKhau.Text)
        };

        // ---------- Thêm / Sửa / Xóa / Làm lại / Tìm ----------
        private void btnThem_Click(object? sender, EventArgs e)
        {
            if (!KiemTra(batBuocMatKhau: true)) return;
            try
            {
                int dem = Convert.ToInt32(KetNoiCSDL.LayGiaTri(
                    "SELECT COUNT(*) FROM tblNhanVien WHERE MaNV = @ma",
                    KetNoiCSDL.Tham("@ma", txtMaNV.Text.Trim())));
                if (dem > 0)
                {
                    Loi("Mã nhân viên đã tồn tại, hãy nhập mã khác.", txtMaNV);
                    return;
                }
                // Cột TenDangNhap để NULL (đăng nhập bằng mã nhân viên + mật khẩu)
                KetNoiCSDL.ThucThi(@"
                    INSERT INTO tblNhanVien (MaNV, TenNV, GioiTinh, NgaySinh, SDT, DiaChi, VaiTro, MatKhau)
                    VALUES (@ma, @ten, @gt, @ns, @sdt, @dc, @vt, @mk)", ThamSo());
                MessageBox.Show("Thêm thành công.");
                NapLuoi();
                LamLai();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm:\n" + ex.Message);
            }
        }

        private void btnSua_Click(object? sender, EventArgs e)
        {
            if (!txtMaNV.ReadOnly)
            {
                MessageBox.Show("Hãy bấm chọn một dòng trong danh sách để sửa.");
                return;
            }
            if (!KiemTra(batBuocMatKhau: false)) return;
            try
            {
                // Để trống mật khẩu thì giữ nguyên mật khẩu cũ
                string sql = @"
                    UPDATE tblNhanVien
                    SET TenNV = @ten, GioiTinh = @gt, NgaySinh = @ns, SDT = @sdt, DiaChi = @dc, VaiTro = @vt"
                    + (txtMatKhau.Text.Length > 0 ? ", MatKhau = @mk" : "")
                    + " WHERE MaNV = @ma";
                int n = KetNoiCSDL.ThucThi(sql, ThamSo());
                MessageBox.Show(n > 0 ? "Sửa thành công." : "Không tìm thấy nhân viên cần sửa.");
                NapLuoi();
                LamLai();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa:\n" + ex.Message);
            }
        }

        private void btnXoa_Click(object? sender, EventArgs e)
        {
            if (!txtMaNV.ReadOnly)
            {
                MessageBox.Show("Hãy bấm chọn một dòng trong danh sách để xóa.");
                return;
            }
            if (MessageBox.Show($"Xóa nhân viên {txtMaNV.Text} - {txtTenNV.Text}?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            try
            {
                int n = KetNoiCSDL.ThucThi("DELETE FROM tblNhanVien WHERE MaNV = @ma",
                    KetNoiCSDL.Tham("@ma", txtMaNV.Text.Trim()));
                MessageBox.Show(n > 0 ? "Đã xóa." : "Không tìm thấy nhân viên cần xóa.");
                NapLuoi();
                LamLai();
            }
            catch (SqlException ex) when (ex.Number == 547)   // vi phạm khóa ngoại
            {
                MessageBox.Show("Không xóa được: nhân viên này đã lập hóa đơn bán hoặc hóa đơn nhập.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa:\n" + ex.Message);
            }
        }

        private void btnLamLai_Click(object? sender, EventArgs e)
        {
            txtTim.Clear();
            try { NapLuoi(); }
            catch (Exception ex) { MessageBox.Show("Lỗi khi tải danh sách:\n" + ex.Message); }
            LamLai();
        }

        private void LamLai()
        {
            txtMaNV.ReadOnly = false;
            txtMaNV.Clear();
            txtTenNV.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            txtMatKhau.Clear();
            dtpNgaySinh.Value = DateTime.Today.AddYears(-20);
            radNam.Checked = true;
            cboChucVu.SelectedIndex = -1;
            dgvNhanVien.ClearSelection();
            txtMaNV.Focus();
        }

        private void btnTim_Click(object? sender, EventArgs e)
        {
            try
            {
                NapLuoi(txtTim.Text);
                if (dgvNhanVien.Rows.Count == 0)
                    MessageBox.Show("Không tìm thấy nhân viên nào.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm:\n" + ex.Message);
            }
        }
    }
}