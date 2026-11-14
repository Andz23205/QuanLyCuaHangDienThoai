using System;
using System.Data;
using System.Windows.Forms;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    public partial class Form4 : Form
    {
        private readonly NhaCungCapBUS nhaCungCapBus = new NhaCungCapBUS();
        private DataTable dtNCC = new DataTable();
        private DataView dvNCC = new DataView();

        public Form4()
        {
            InitializeComponent();

            Load += Form4_Load;
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamLai.Click += btnLamLai_Click;
            btnThoat.Click += (s, e) => Close();
            txtTim.TextChanged += (s, e) => TimKiem();
            dgvKhachHang.CellClick += dgvKhachHang_CellClick;
        }

        private void Form4_Load(object? sender, EventArgs e)
        {
            dgvKhachHang.AutoGenerateColumns = false;
            colMaNCC.DataPropertyName = "MaNCC";
            colTenNCC.DataPropertyName = "TenNCC";
            colSDT.DataPropertyName = "SDT";
            colDiaChi.DataPropertyName = "DiaChi";
            if (colEmail != null) colEmail.DataPropertyName = "Email";
            if (colNguoiLH != null) colNguoiLH.DataPropertyName = "NguoiLH";

            dgvKhachHang.ReadOnly = true;
            dgvKhachHang.AllowUserToAddRows = false;
            dgvKhachHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKhachHang.MultiSelect = false;
            dgvKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            LoadData();
            LamLai();
        }

        private void LoadData()
        {
            try
            {
                // Goi qua tang BUS
                dtNCC = nhaCungCapBus.LayDanhSach();
                dvNCC = new DataView(dtNCC);
                dgvKhachHang.DataSource = dvNCC;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách nhà cung cấp: " + ex.Message);
            }
        }

        private void dgvKhachHang_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvKhachHang.Rows[e.RowIndex].DataBoundItem is not DataRowView r) return;

            txtMaNCC.Text = r["MaNCC"].ToString();
            txtMaNCC.ReadOnly = true;
            txtTenNCC.Text = r["TenNCC"].ToString();
            txtSDT.Text = r["SDT"]?.ToString() ?? "";
            txtDiaChi.Text = r["DiaChi"]?.ToString() ?? "";
            txtEmail.Text = r["Email"]?.ToString() ?? "";
            txtNguoiLH.Text = r["NguoiLH"]?.ToString() ?? "";
        }

        private NhaCungCap TaoDoiTuongNhaCungCap()
        {
            return new NhaCungCap(
                txtMaNCC.Text.Trim(),
                txtTenNCC.Text.Trim(),
                txtSDT.Text.Trim(),
                txtDiaChi.Text.Trim()
            );
        }

        private void btnThem_Click(object? sender, EventArgs e)
        {
            NhaCungCap ncc = TaoDoiTuongNhaCungCap();

            // Thuc hien qua tang BUS
            if (nhaCungCapBus.Them(ncc, out string error))
            {
                MessageBox.Show("Thêm nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (!txtMaNCC.ReadOnly)
            {
                MessageBox.Show("Hãy chọn một nhà cung cấp trong danh sách để sửa.");
                return;
            }

            NhaCungCap ncc = TaoDoiTuongNhaCungCap();

            // Thuc hien qua tang BUS
            if (nhaCungCapBus.Sua(ncc, out string error))
            {
                MessageBox.Show("Cập nhật nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (!txtMaNCC.ReadOnly)
            {
                MessageBox.Show("Hãy chọn một nhà cung cấp trong danh sách để xóa.");
                return;
            }

            string ma = txtMaNCC.Text.Trim();
            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa nhà cung cấp {ma}?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            // Thuc hien qua tang BUS
            if (nhaCungCapBus.Xoa(ma, out string error))
            {
                MessageBox.Show("Đã xóa nhà cung cấp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (dvNCC != null) dvNCC.RowFilter = "";
            LamLai();
        }

        private void LamLai()
        {
            txtMaNCC.ReadOnly = false;
            txtMaNCC.Clear();
            txtTenNCC.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            txtEmail.Clear();
            txtNguoiLH.Clear();
            dgvKhachHang.ClearSelection();
            txtMaNCC.Focus();
        }

        private void TimKiem()
        {
            string tk = txtTim.Text.Trim().Replace("'", "''");
            if (dvNCC == null) return;
            dvNCC.RowFilter = tk.Length == 0 ? "" : $"TenNCC LIKE '%{tk}%' OR MaNCC LIKE '%{tk}%' OR SDT LIKE '%{tk}%'";
        }
    }
}