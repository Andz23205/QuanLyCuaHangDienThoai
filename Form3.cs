using System;
using System.Data;
using System.Windows.Forms;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    public partial class Form3 : Form
    {
        private readonly KhachHangBUS khachHangBus = new KhachHangBUS();
        private DataTable dtKH = new DataTable();
        private DataView dvKH = new DataView();

        public Form3()
        {
            InitializeComponent();

            Load += Form3_Load;
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamLai.Click += btnLamLai_Click;
            btnThoat.Click += (s, e) => Close();
            txtTim.TextChanged += (s, e) => TimKiem();
            dgvKhachHang.CellClick += dgvKhachHang_CellClick;
        }

        private void Form3_Load(object? sender, EventArgs e)
        {
            dgvKhachHang.AutoGenerateColumns = false;
            colMaKH.DataPropertyName = "MaKH";
            colTenKH.DataPropertyName = "TenKH";
            colSDT.DataPropertyName = "SDT";
            colDiaChi.DataPropertyName = "DiaChi";
            if (colEmail != null) colEmail.DataPropertyName = "Email";

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
                dtKH = khachHangBus.LayDanhSach();
                dvKH = new DataView(dtKH);
                dgvKhachHang.DataSource = dvKH;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách khách hàng: " + ex.Message);
            }
        }

        private void dgvKhachHang_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvKhachHang.Rows[e.RowIndex].DataBoundItem is not DataRowView r) return;

            txtMaKH.Text = r["MaKH"].ToString();
            txtMaKH.ReadOnly = true;
            txtTenKH.Text = r["TenKH"].ToString();
            txtSDT.Text = r["SDT"]?.ToString() ?? "";
            txtDiaChi.Text = r["DiaChi"]?.ToString() ?? "";
            txtEmail.Text = r["Email"]?.ToString() ?? "";
        }


        private KhachHang TaoDoiTuongKhachHang()
        {
            return new KhachHang(
                txtMaKH.Text.Trim(),
                txtTenKH.Text.Trim(),
                txtSDT.Text.Trim(),
                txtDiaChi.Text.Trim(),
                txtEmail.Text.Trim()
            );
        }


        private void btnThem_Click(object? sender, EventArgs e)
        {
            KhachHang kh = TaoDoiTuongKhachHang();

            // Thuc hien qua tang BUS
            if (khachHangBus.Them(kh, out string error))
            {
                MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (!txtMaKH.ReadOnly)
            {
                MessageBox.Show("Hãy chọn một khách hàng trong danh sách để sửa.");
                return;
            }

            KhachHang kh = TaoDoiTuongKhachHang();

            // Thuc hien qua tang BUS
            if (khachHangBus.Sua(kh, out string error))
            {
                MessageBox.Show("Cập nhật khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (!txtMaKH.ReadOnly || string.IsNullOrWhiteSpace(txtMaKH.Text))
            {
                MessageBox.Show(
                    "Hãy chọn một khách hàng trong danh sách cần xóa!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            string ma = txtMaKH.Text.Trim();

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa khách hàng {ma} không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
                return;

            if (khachHangBus.Xoa(ma, out string error))
            {
                MessageBox.Show(
                    "Xóa khách hàng thành công!",
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
                    "Không thể xóa khách hàng",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }


        private void btnLamLai_Click(object? sender, EventArgs e)
        {
            txtTim.Clear();
            if (dvKH != null) dvKH.RowFilter = "";
            LamLai();
        }

        private void LamLai()
        {
            txtMaKH.ReadOnly = false;
            txtMaKH.Clear();
            txtTenKH.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            txtEmail.Clear();
            dgvKhachHang.ClearSelection();
            txtMaKH.Focus();
        }


        private void TimKiem()
        {
            if (dvKH == null) return;

            string tk = txtTim.Text.Trim().Replace("'", "''");

            if (tk.Length == 0)
            {
                dvKH.RowFilter = "";
                return;
            }

            dvKH.RowFilter =
                $"MaKH LIKE '%{tk}%' OR " +
                $"TenKH LIKE '%{tk}%' OR " +
                $"SDT LIKE '%{tk}%' OR " +
                $"Email LIKE '%{tk}%' OR " +
                $"DiaChi LIKE '%{tk}%'";
        }

    }
}