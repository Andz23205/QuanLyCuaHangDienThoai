using System.Data;
using System.Text.RegularExpressions;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    // FORM 2: Quản lý nhân viên (frmNhanVien) - bản KHÔNG dùng SQL
    public partial class Form2 : Form
    {
        private readonly DataView dvNV = new(DuLieuTam.NhanVien);

        public Form2()
        {
            InitializeComponent();

            // Gắn sự kiện bằng code (KHÔNG nhấp đúp vào nút trong Designer)
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
            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            dtpNgaySinh.MaxDate = DateTime.Today;

            txtMatKhau.UseSystemPasswordChar = true;

            cboChucVu.DropDownStyle = ComboBoxStyle.DropDownList;
            cboChucVu.Items.Clear();
            cboChucVu.Items.AddRange(DuLieuTam.DanhSachChucVu);

            dgvNhanVien.ReadOnly = true;
            dgvNhanVien.AllowUserToAddRows = false;
            dgvNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNhanVien.MultiSelect = false;
            dgvNhanVien.RowHeadersVisible = false;
            dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dvNV.Sort = "MaNV";
            dgvNhanVien.DataSource = dvNV;

            var tieuDe = new Dictionary<string, string>
            {
                ["MaNV"] = "Mã NV",
                ["TenNV"] = "Họ tên",
                ["NgaySinh"] = "Ngày sinh",
                ["GioiTinh"] = "Giới tính",
                ["SDT"] = "Số ĐT",
                ["DiaChi"] = "Địa chỉ",
                ["ChucVu"] = "Chức vụ"
            };
            foreach (var kv in tieuDe) dgvNhanVien.Columns[kv.Key]!.HeaderText = kv.Value;
            dgvNhanVien.Columns["NgaySinh"]!.DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvNhanVien.Columns["Passw"]!.Visible = false;   // không hiện mật khẩu trên lưới

            LamLai();
        }

        // ---------- Đổ dữ liệu khi bấm vào dòng ----------
        private void dgvNhanVien_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvNhanVien.Rows[e.RowIndex].DataBoundItem is not DataRowView r) return;

            txtMaNV.Text = r["MaNV"].ToString();
            txtMaNV.ReadOnly = true;                          // khóa chính, không cho sửa
            txtTenNV.Text = r["TenNV"].ToString();

            if (r["NgaySinh"] is DateTime ns)
                dtpNgaySinh.Value = ns < dtpNgaySinh.MinDate ? dtpNgaySinh.MinDate
                                  : ns > dtpNgaySinh.MaxDate ? dtpNgaySinh.MaxDate : ns;

            bool nu = r["GioiTinh"].ToString() == "Nữ";
            radNu.Checked = nu;
            radNam.Checked = !nu;

            txtSDT.Text = r["SDT"].ToString();
            txtDiaChi.Text = r["DiaChi"].ToString();
            cboChucVu.SelectedItem = r["ChucVu"].ToString();

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

        // ---------- Thêm / Sửa / Xóa / Làm lại / Tìm ----------
        private void btnThem_Click(object? sender, EventArgs e)
        {
            if (!KiemTra(batBuocMatKhau: true)) return;
            string ma = txtMaNV.Text.Trim();
            if (DuLieuTam.NhanVien.Rows.Find(ma) != null)
            {
                Loi("Mã nhân viên đã tồn tại, hãy nhập mã khác.", txtMaNV);
                return;
            }
            DuLieuTam.NhanVien.Rows.Add(ma, txtTenNV.Text.Trim(), dtpNgaySinh.Value.Date,
                radNam.Checked ? "Nam" : "Nữ", txtSDT.Text.Trim(), txtDiaChi.Text.Trim(),
                cboChucVu.SelectedItem!.ToString(), txtMatKhau.Text);
            MessageBox.Show("Thêm thành công.");
            LamLai();
        }

        private void btnSua_Click(object? sender, EventArgs e)
        {
            if (!txtMaNV.ReadOnly)
            {
                MessageBox.Show("Hãy bấm chọn một dòng trong danh sách để sửa.");
                return;
            }
            if (!KiemTra(batBuocMatKhau: false)) return;

            var row = DuLieuTam.NhanVien.Rows.Find(txtMaNV.Text.Trim());
            if (row == null) { MessageBox.Show("Không tìm thấy nhân viên cần sửa."); return; }

            row["TenNV"] = txtTenNV.Text.Trim();
            row["NgaySinh"] = dtpNgaySinh.Value.Date;
            row["GioiTinh"] = radNam.Checked ? "Nam" : "Nữ";
            row["SDT"] = txtSDT.Text.Trim();
            row["DiaChi"] = txtDiaChi.Text.Trim();
            row["ChucVu"] = cboChucVu.SelectedItem!.ToString();
            if (txtMatKhau.Text.Length > 0) row["Passw"] = txtMatKhau.Text;   // để trống = giữ mật khẩu cũ

            MessageBox.Show("Sửa thành công.");
            LamLai();
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

            var row = DuLieuTam.NhanVien.Rows.Find(txtMaNV.Text.Trim());
            if (row == null) { MessageBox.Show("Không tìm thấy nhân viên cần xóa."); return; }

            DuLieuTam.NhanVien.Rows.Remove(row);
            MessageBox.Show("Đã xóa.");
            LamLai();
        }

        private void btnLamLai_Click(object? sender, EventArgs e)
        {
            txtTim.Clear();
            dvNV.RowFilter = "";
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
            string tk = txtTim.Text.Trim();
            dvNV.RowFilter = tk.Length == 0 ? "" : $"TenNV LIKE '%{DuLieuTam.ThoatLike(tk)}%'";
            if (dvNV.Count == 0)
                MessageBox.Show("Không tìm thấy nhân viên nào.");
        }
    }
}