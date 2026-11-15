using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    public partial class Form2 : Form
    {
        private readonly NhanVienBUS nhanVienBus = new NhanVienBUS();
        private DataTable dtNV = new DataTable();
        private DataView dvNV = new DataView();

        public Form2()
        {
            InitializeComponent();

            Load += Form2_Load;
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamLai.Click += btnLamLai_Click;
            btnThoat.Click += (s, e) => Close();
            btnTim.Click += btnTim_Click;
            dgvNhanVien.CellClick += dgvNhanVien_CellClick;
        }


        private void Form2_Load(object? sender, EventArgs e)
        {
            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            dtpNgaySinh.MaxDate = DateTime.Today;

            txtMatKhau.UseSystemPasswordChar = true;

            cboChucVu.DropDownStyle = ComboBoxStyle.DropDownList;
            cboChucVu.Items.Clear();
            cboChucVu.Items.AddRange(new object[]
            {
        "Quản lý", "Nhân viên", "Bán hàng", "Thu ngân", "Kho"
            });

            // Cấu hình bảng nhân viên
            dgvNhanVien.ReadOnly = true;
            dgvNhanVien.AllowUserToAddRows = false;
            dgvNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNhanVien.MultiSelect = false;
            dgvNhanVien.RowHeadersVisible = false;
            dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Cấu hình trạng thái
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.AddRange(new object[]
            {
        "Đang làm việc",
        "Đã nghỉ việc"
            });
            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrangThai.Enabled =
    Form9.VaiTroDangNhap == "Quản lý" ||
    Form9.VaiTroDangNhap == "Quan ly" ||
    Form9.VaiTroDangNhap == "Admin";
            cboTrangThai.SelectedIndex = 0;

           
            bool laQuanLy =
    Form9.VaiTroDangNhap == "Quản lý" ||
    Form9.VaiTroDangNhap == "Quan ly" ||
    Form9.VaiTroDangNhap == "Admin";

            btnXoa.Visible = laQuanLy;
            btnXoa.Enabled = laQuanLy;
            LoadData();
            LamLai();
        }


        private void LoadData()
        {
            try
            {
                // Lấy danh sách nhân viên từ BUS
                dtNV = nhanVienBus.LayDanhSach();
                dvNV = new DataView(dtNV);
                dgvNhanVien.DataSource = dvNV;

                var tieuDe = new Dictionary<string, string>
                {
                    ["MaNV"] = "Mã NV",
                    ["TenNV"] = "Họ tên",
                    ["GioiTinh"] = "Giới tính",
                    ["NgaySinh"] = "Ngày sinh",
                    ["SDT"] = "Số ĐT",
                    ["DiaChi"] = "Địa chỉ",
                    ["ChucVu"] = "Chức vụ",
                    ["TrangThai"] = "Trạng thái"
                };

                foreach (var kv in tieuDe)
                {
                    if (dgvNhanVien.Columns.Contains(kv.Key))
                        dgvNhanVien.Columns[kv.Key]!.HeaderText = kv.Value;
                }

                // Định dạng ngày sinh
                if (dgvNhanVien.Columns.Contains("NgaySinh"))
                    dgvNhanVien.Columns["NgaySinh"]!.DefaultCellStyle.Format = "dd/MM/yyyy";

                // Ẩn các cột không cần hiển thị
                if (dgvNhanVien.Columns.Contains("MatKhau"))
                    dgvNhanVien.Columns["MatKhau"]!.Visible = false;

                if (dgvNhanVien.Columns.Contains("TenDangNhap"))
                    dgvNhanVien.Columns["TenDangNhap"]!.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách nhân viên: " + ex.Message);
            }
        }


        private void dgvNhanVien_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvNhanVien.Rows[e.RowIndex].DataBoundItem is not DataRowView r) return;

            txtMaNV.Text = r["MaNV"].ToString();
            txtMaNV.ReadOnly = true;
            txtTenNV.Text = r["TenNV"].ToString();

            if (r["NgaySinh"] != DBNull.Value && r["NgaySinh"] is DateTime ns)
            {
                dtpNgaySinh.Value =
                    ns <= dtpNgaySinh.MaxDate && ns >= dtpNgaySinh.MinDate
                    ? ns
                    : dtpNgaySinh.MaxDate;
            }
            else
            {
                dtpNgaySinh.Value = DateTime.Today;
            }

            string gt = r["GioiTinh"] == DBNull.Value
                ? "Nam"
                : r["GioiTinh"].ToString() ?? "Nam";

            radNu.Checked = gt.Equals("Nữ", StringComparison.OrdinalIgnoreCase);
            radNam.Checked = !radNu.Checked;

            txtSDT.Text = r["SDT"]?.ToString() ?? "";
            txtDiaChi.Text = r["DiaChi"]?.ToString() ?? "";

            string chucVu = r["ChucVu"]?.ToString() ?? "";
            cboChucVu.SelectedIndex = cboChucVu.FindStringExact(chucVu);

            txtMatKhau.Text = r["MatKhau"]?.ToString() ?? "";

            // Hiển thị trạng thái nhân viên
            string trangThai = r["TrangThai"] == DBNull.Value
                ? "Đang làm việc"
                : r["TrangThai"].ToString() ?? "Đang làm việc";

            cboTrangThai.Text = trangThai;
        }



        private NhanVien TaoDoiTuongNhanVien()
        {
            return new NhanVien(
                txtMaNV.Text.Trim(),
                txtTenNV.Text.Trim(),
                radNu.Checked ? "Nữ" : "Nam",
                dtpNgaySinh.Value.Date,
                txtSDT.Text.Trim(),
                txtDiaChi.Text.Trim(),
                txtMaNV.Text.Trim().ToLower(),
                txtMatKhau.Text.Trim(),
                cboChucVu.Text
            )
            {
                TrangThai = cboTrangThai.Text
            };
        }


        private void btnThem_Click(object? sender, EventArgs e)
        {
            NhanVien nv = TaoDoiTuongNhanVien();

            // Thuc hien qua tang BUS
            if (nhanVienBus.Them(nv, out string error))
            {
                MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (!txtMaNV.ReadOnly)
            {
                MessageBox.Show("Hãy chọn một nhân viên trong danh sách để sửa.");
                return;
            }

            bool laQuanLy =
                Form9.VaiTroDangNhap == "Quản lý" ||
                Form9.VaiTroDangNhap == "Quan ly" ||
                Form9.VaiTroDangNhap == "Admin";

            NhanVien nv = TaoDoiTuongNhanVien();

            // Nếu không phải quản lý, giữ nguyên trạng thái cũ
            if (!laQuanLy)
            {
                DataRowView? dongChon =
                    dgvNhanVien.CurrentRow?.DataBoundItem as DataRowView;

                if (dongChon != null)
                    nv.TrangThai = dongChon["TrangThai"]?.ToString()
                                   ?? "Đang làm việc";
            }

            if (nhanVienBus.Sua(nv, out string error))
            {
                MessageBox.Show(
                    "Cập nhật nhân viên thành công!",
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
                    "Lỗi sửa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!Form9.VaiTroDangNhap.Equals("Quản lý",
                    StringComparison.OrdinalIgnoreCase) &&
                !Form9.VaiTroDangNhap.Equals("Quan ly",
                    StringComparison.OrdinalIgnoreCase) &&
                !Form9.VaiTroDangNhap.Equals("Admin",
                    StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Chỉ quản lý mới có quyền xóa nhân viên!");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa!");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa nhân viên này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result != DialogResult.Yes)
                return;

            if (nhanVienBus.Xoa(txtMaNV.Text.Trim(), out string error))
            {
                MessageBox.Show("Xóa nhân viên thành công!");
                LoadData();
                LamLai();
            }
            else
            {
                MessageBox.Show(
                    error,
                    "Không thể xóa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }


        private void btnLamLai_Click(object? sender, EventArgs e)
        {
            txtTim.Clear();
            if (dvNV != null) dvNV.RowFilter = "";
            LamLai();
        }

        private void LamLai()
        {
            txtMaNV.ReadOnly = false;
            txtMaNV.Clear();
            txtTenNV.Clear();
            dtpNgaySinh.Value = DateTime.Today;
            radNam.Checked = true;
            radNu.Checked = false;
            txtSDT.Clear();
            txtDiaChi.Clear();
            cboChucVu.SelectedIndex = -1;
            txtMatKhau.Clear();
            dgvNhanVien.ClearSelection();
            txtMaNV.Focus();
        }

        private void btnTim_Click(object? sender, EventArgs e)
        {
            string tk = txtTim.Text.Trim().Replace("'", "''");
            if (dvNV == null) return;
            dvNV.RowFilter = tk.Length == 0 ? "" : $"TenNV LIKE '%{tk}%' OR MaNV LIKE '%{tk}%' OR SDT LIKE '%{tk}%'";
            if (dvNV.Count == 0)
                MessageBox.Show("Không tìm thấy nhân viên nào phù hợp.");
        }
    }
}