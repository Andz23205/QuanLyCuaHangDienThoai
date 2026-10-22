
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    public partial class Form7 : Form
    {
        Dictionary<string, string> tenHang = new Dictionary<string, string>();
        Dictionary<string, decimal> donGia = new Dictionary<string, decimal>();

        DataTable bangChiTiet = new DataTable();

        public Form7()
        {
            InitializeComponent();

            // Du lieu hang mau
            tenHang.Add("DT001", "iPhone 15 Pro Max");
            tenHang.Add("DT002", "Galaxy S24 Ultra");
            tenHang.Add("DT003", "Redmi Note 13");
            tenHang.Add("PK001", "Op lung iPhone 15");

            donGia.Add("DT001", 30990000);
            donGia.Add("DT002", 24500000);
            donGia.Add("DT003", 5290000);
            donGia.Add("PK001", 150000);

            // Khoi tao bang chi tiet hoa don
            bangChiTiet.Columns.Add("MaHang", typeof(string));
            bangChiTiet.Columns.Add("TenHang", typeof(string));
            bangChiTiet.Columns.Add("DonGia", typeof(decimal));
            bangChiTiet.Columns.Add("SoLuong", typeof(int));
            bangChiTiet.Columns.Add("GiamGia", typeof(decimal));
            bangChiTiet.Columns.Add("ThanhTien", typeof(decimal));

            dgvChiTiet.DataSource = bangChiTiet;
            dgvChiTiet.AllowUserToAddRows = false;
            dgvChiTiet.ReadOnly = true;
            dgvChiTiet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChiTiet.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            // Cau hinh hien thi
            txtTenHang.ReadOnly = true;
            txtDonGia.ReadOnly = true;
            txtThanhTien.ReadOnly = true;
            txtTenNV.ReadOnly = true;
            txtTenKH.ReadOnly = true;
            txtMaKH.ReadOnly = true;
            txtDiaChi.ReadOnly = true;

            // Nap danh sach ma hang
            cboMaHang.Items.Clear();
            cboMaHang.Items.AddRange(new object[]
            {
                "DT001", "DT002", "DT003", "PK001"
            });

            // Nap ma hoa don mau
            cboMaHD.Items.Clear();
            cboMaHD.Items.AddRange(new object[]
            {
                "HDB_171020260001",
                "HDB_171020260002"
            });

            // Gan su kien
            cboMaHang.SelectedIndexChanged += cboMaHang_SelectedIndexChanged;
            txtSoLuong.TextChanged += txtSoLuong_TextChanged;
            txtGiamGia.TextChanged += txtGiamGia_TextChanged;

            btnThemHang.Click += btnThemHang_Click;
            btnThemHD.Click += btnThemHD_Click;
            btnHuy.Click += btnHuy_Click;
            btnLuu.Click += btnLuu_Click;
            btnTim.Click += btnTim_Click;
            btnThoat.Click += btnThoat_Click;
            dgvChiTiet.CellClick += dgvChiTiet_CellClick;

            dtpNgayLap.Value = DateTime.Today;

            lblTongTien.Text = "Tổng tiền: 0 VNĐ";
        }

        // Chon ma hang
        private void cboMaHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ma = cboMaHang.Text;

            if (tenHang.ContainsKey(ma))
            {
                txtTenHang.Text = tenHang[ma];
                txtDonGia.Text = donGia[ma].ToString("N0");

                TinhThanhTien();
            }
        }

        // Tu dong tinh tien khi thay doi so luong
        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            TinhThanhTien();
        }

        // Tu dong tinh tien khi thay doi giam gia
        private void txtGiamGia_TextChanged(object sender, EventArgs e)
        {
            TinhThanhTien();
        }

        // Tinh thanh tien
        private void TinhThanhTien()
        {
            decimal gia, giamGia;
            int soLuong;

            if (decimal.TryParse(txtDonGia.Text, out gia) &&
                int.TryParse(txtSoLuong.Text, out soLuong) &&
                decimal.TryParse(txtGiamGia.Text, out giamGia))
            {
                if (soLuong > 0 && giamGia >= 0 && giamGia <= 100)
                {
                    decimal tien = gia * soLuong * (100 - giamGia) / 100;
                    txtThanhTien.Text = tien.ToString("N0");
                    return;
                }
            }

            txtThanhTien.Clear();
        }

        // Them mat hang vao hoa don
        private void btnThemHang_Click(object sender, EventArgs e)
        {
            string ma = cboMaHang.Text;
            int soLuong;
            decimal giamGia;

            if (!tenHang.ContainsKey(ma))
            {
                MessageBox.Show("Vui lòng chọn mã hàng!");
                return;
            }

            if (!int.TryParse(txtSoLuong.Text, out soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0!");
                return;
            }

            if (!decimal.TryParse(txtGiamGia.Text, out giamGia) ||
                giamGia < 0 || giamGia > 100)
            {
                MessageBox.Show("Giảm giá phải từ 0 đến 100!");
                return;
            }

            decimal gia = donGia[ma];
            decimal thanhTien = gia * soLuong * (100 - giamGia) / 100;

            bangChiTiet.Rows.Add(
                ma,
                tenHang[ma],
                gia,
                soLuong,
                giamGia,
                thanhTien
            );

            TinhTongTien();

            cboMaHang.SelectedIndex = -1;
            txtTenHang.Clear();
            txtDonGia.Clear();
            txtSoLuong.Clear();
            txtGiamGia.Clear();
            txtThanhTien.Clear();
        }

        // Tinh tong tien hoa don
        private void TinhTongTien()
        {
            decimal tong = 0;

            foreach (DataRow row in bangChiTiet.Rows)
            {
                tong += Convert.ToDecimal(row["ThanhTien"]);
            }

            lblTongTien.Text = "Tổng tiền: " + tong.ToString("N0") + " VNĐ";
        }

        // Them hoa don moi
        private void btnThemHD_Click(object sender, EventArgs e)
        {
            bangChiTiet.Rows.Clear();

            txtMaNV.Clear();
            txtTenNV.Clear();
            txtSDT.Clear();
            txtTenKH.Clear();
            txtMaKH.Clear();
            txtDiaChi.Clear();

            cboMaHang.SelectedIndex = -1;
            txtTenHang.Clear();
            txtDonGia.Clear();
            txtSoLuong.Clear();
            txtGiamGia.Clear();
            txtThanhTien.Clear();

            cboMaHD.Text = "HDB_" + DateTime.Now.ToString("ddMMyyyyHHmmss");
            dtpNgayLap.Value = DateTime.Today;

            TinhTongTien();

            MessageBox.Show("Đã tạo hóa đơn mới. Đây là dữ liệu mẫu, chưa lưu vào CSDL.");
        }

        // Huy hoa don hien tai
        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show(
                "Bạn có chắc muốn hủy hóa đơn hiện tại?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (kq == DialogResult.Yes)
            {
                bangChiTiet.Rows.Clear();
                TinhTongTien();

                MessageBox.Show("Đã xóa các mặt hàng trên giao diện.");
            }
        }

        // Luu tam hoa don
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (bangChiTiet.Rows.Count == 0)
            {
                MessageBox.Show("Hóa đơn chưa có mặt hàng!");
                return;
            }

            MessageBox.Show(
                "Thông tin hóa đơn hiện đang ở bộ nhớ chương trình.\n" +
                "Nhóm chưa có CSDL SQL Server nên chưa thể lưu lâu dài.");
        }

        // Tim hoa don mau
        private void btnTim_Click(object sender, EventArgs e)
        {
            string maHD = cboMaHD.Text.Trim();

            if (maHD == "HDB_171020260001")
            {
                txtMaNV.Text = "NV001";
                txtTenNV.Text = "Nguyễn Văn An";
                txtSDT.Text = "0901234567";
                txtTenKH.Text = "Phạm Quốc Huy";
                txtMaKH.Text = "KH001";
                txtDiaChi.Text = "25 Trần Đại Nghĩa, Hà Nội";

                MessageBox.Show("Đã tìm thấy thông tin hóa đơn mẫu.");
            }
            else
            {
                MessageBox.Show(
                    "Chưa tìm thấy hóa đơn mẫu này.\n" +
                    "Chức năng tra cứu CSDL sẽ bổ sung sau.");
            }
        }

        // Click dong de xoa mat hang
        private void dgvChiTiet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DialogResult kq = MessageBox.Show(
                "Bạn có muốn xóa mặt hàng này khỏi hóa đơn?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (kq == DialogResult.Yes)
            {
                bangChiTiet.Rows.RemoveAt(e.RowIndex);
                TinhTongTien();
            }
        }

        // In hoa don tam
        private void btnIn_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Chức năng xuất hóa đơn Excel sẽ được bổ sung sau khi hoàn thành phần dữ liệu.");
        }

        // Thoat chuong trinh
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label13_Click(object sender, EventArgs e)
        {
        }
    }
}
