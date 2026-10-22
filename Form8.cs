
using System;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    public partial class Form8 : Form
    {
        private DataTable bangChiTiet;
        private Dictionary<string, string> tenHang = new Dictionary<string, string>();
        private Dictionary<string, decimal> donGia = new Dictionary<string, decimal>();

        public Form8()
        {
            InitializeComponent();

            KhoiTaoDuLieu();
            TaoBangChiTiet();
            GanSuKien();
        }

        // 1. Khởi tạo dữ liệu hàng mẫu
        private void KhoiTaoDuLieu()
        {
            tenHang.Add("DT001", "iPhone 15 Pro Max");
            donGia.Add("DT001", 25000000);

            tenHang.Add("DT002", "Samsung Galaxy S24");
            donGia.Add("DT002", 18000000);

            tenHang.Add("DT003", "Xiaomi Redmi Note 13");
            donGia.Add("DT003", 4000000);

            cboMaHang.Items.Clear();
            cboMaHang.Items.AddRange(new object[]
            {
                "DT001", "DT002", "DT003"
            });

            cboNCC.Items.Clear();
            cboNCC.Items.AddRange(new object[]
            {
                "NCC001", "NCC002", "NCC003"
            });

            cboMaHDN.DropDownStyle = ComboBoxStyle.DropDown;
            cboNCC.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMaHang.DropDownStyle = ComboBoxStyle.DropDownList;

            txtMaNV.Text = "NV001";
            txtTenNV.Text = "Nguyễn Văn An";
            txtMaNCC.ReadOnly = true;
            txtTenNV.ReadOnly = true;
            txtTenHang.ReadOnly = true;
            txtDonGiaNhap.ReadOnly = true;
            txtThanhTien.ReadOnly = true;

            txtSDT.ReadOnly = true;
            txtDiaChi.ReadOnly = true;

            dtpNgayNhap.Value = DateTime.Today;
        }

        // 2. Tạo bảng chi tiết hóa đơn
        private void TaoBangChiTiet()
        {
            bangChiTiet = new DataTable();

            bangChiTiet.Columns.Add("Mã hàng");
            bangChiTiet.Columns.Add("Tên hàng");
            bangChiTiet.Columns.Add("Đơn giá nhập", typeof(decimal));
            bangChiTiet.Columns.Add("Số lượng", typeof(int));
            bangChiTiet.Columns.Add("Thành tiền", typeof(decimal));

            dgvChiTiet.DataSource = bangChiTiet;
            dgvChiTiet.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTiet.AllowUserToAddRows = false;
            dgvChiTiet.ReadOnly = true;
            dgvChiTiet.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            CapNhatTongTien();
        }

        // 3. Gắn sự kiện cho các nút và điều khiển
        private void GanSuKien()
        {
            cboMaHang.SelectedIndexChanged += cboMaHang_SelectedIndexChanged;
            cboNCC.SelectedIndexChanged += cboNCC_SelectedIndexChanged;
            txtSoLuong.TextChanged += txtSoLuong_TextChanged;

            button1.Click += button1_Click;
            btnThemHD.Click += btnThemHD_Click;
            btnLuu.Click += btnLuu_Click;
            btnHuy.Click += btnHuy_Click;
            btnTim.Click += btnTim_Click;
            btnThoat.Click += btnThoat_Click;
            btnIn.Click += btnIn_Click;
        }

        // 4. Chọn mã hàng thì hiện tên và đơn giá
        private void cboMaHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ma = cboMaHang.Text;

            if (tenHang.ContainsKey(ma))
            {
                txtTenHang.Text = tenHang[ma];
                txtDonGiaNhap.Text = donGia[ma].ToString("N0");
                TinhThanhTien();
            }
        }

        // 5. Chọn nhà cung cấp
        private void cboNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboNCC.Text)
            {
                case "NCC001":
                    txtMaNCC.Text = "NCC001";
                    txtSDT.Text = "0901111111";
                    txtDiaChi.Text = "Hà Nội";
                    break;

                case "NCC002":
                    txtMaNCC.Text = "NCC002";
                    txtSDT.Text = "0902222222";
                    txtDiaChi.Text = "Hồ Chí Minh";
                    break;

                case "NCC003":
                    txtMaNCC.Text = "NCC003";
                    txtSDT.Text = "0903333333";
                    txtDiaChi.Text = "Đà Nẵng";
                    break;
            }
        }

        // 6. Tính thành tiền
        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            TinhThanhTien();
        }

        private void TinhThanhTien()
        {
            int soLuong;
            decimal gia;

            if (int.TryParse(txtSoLuong.Text, out soLuong) &&
                decimal.TryParse(
                    txtDonGiaNhap.Text.Replace(",", ""),
                    out gia) &&
                soLuong > 0)
            {
                txtThanhTien.Text = (gia * soLuong).ToString("N0");
            }
            else
            {
                txtThanhTien.Clear();
            }
        }

        // 7. Thêm mặt hàng vào hóa đơn
        private void button1_Click(object sender, EventArgs e)
        {
            string ma = cboMaHang.Text;
            int soLuong;
            decimal gia;

            if (!tenHang.ContainsKey(ma))
            {
                MessageBox.Show("Bạn hãy chọn mã hàng!");
                return;
            }

            if (!int.TryParse(txtSoLuong.Text, out soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên lớn hơn 0!");
                txtSoLuong.Focus();
                return;
            }

            gia = donGia[ma];

            // Nếu mặt hàng đã tồn tại thì cộng số lượng
            foreach (DataRow row in bangChiTiet.Rows)
            {
                if (row["Mã hàng"].ToString() == ma)
                {
                    int slCu = Convert.ToInt32(row["Số lượng"]);
                    int slMoi = slCu + soLuong;

                    row["Số lượng"] = slMoi;
                    row["Thành tiền"] = gia * slMoi;

                    CapNhatTongTien();
                    LamMoiNhapHang();
                    return;
                }
            }

            bangChiTiet.Rows.Add(
                ma,
                tenHang[ma],
                gia,
                soLuong,
                gia * soLuong
            );

            CapNhatTongTien();
            LamMoiNhapHang();
        }

        // 8. Cập nhật tổng tiền
        private void CapNhatTongTien()
        {
            decimal tong = 0;

            foreach (DataRow row in bangChiTiet.Rows)
            {
                tong += Convert.ToDecimal(row["Thành tiền"]);
            }

            lblTongTien.Text = "Tổng tiền: " + tong.ToString("N0") + " VNĐ";
        }

        // 9. Xóa thông tin nhập mặt hàng
        private void LamMoiNhapHang()
        {
            cboMaHang.SelectedIndex = -1;
            txtTenHang.Clear();
            txtSoLuong.Clear();
            txtDonGiaNhap.Clear();
            txtThanhTien.Clear();
            cboMaHang.Focus();
        }

        // 10. Thêm hóa đơn mới
        private void btnThemHD_Click(object sender, EventArgs e)
        {
            bangChiTiet.Clear();

            cboMaHDN.Text = "HDN" + DateTime.Now.ToString("yyyyMMddHHmmss");
            cboNCC.SelectedIndex = -1;

            txtMaNCC.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();

            dtpNgayNhap.Value = DateTime.Today;

            LamMoiNhapHang();
            CapNhatTongTien();

            MessageBox.Show("Đã tạo hóa đơn nhập mới!");
        }

        // 11. Lưu hóa đơn (tạm thời chưa lưu vào database)
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cboMaHDN.Text))
            {
                MessageBox.Show("Bạn hãy nhập mã hóa đơn!");
                return;
            }

            if (string.IsNullOrWhiteSpace(cboNCC.Text))
            {
                MessageBox.Show("Bạn hãy chọn nhà cung cấp!");
                return;
            }

            if (bangChiTiet.Rows.Count == 0)
            {
                MessageBox.Show("Hóa đơn chưa có mặt hàng!");
                return;
            }

            MessageBox.Show(
                "Kiểm tra hóa đơn thành công!\n" +
                "Mã hóa đơn: " + cboMaHDN.Text +
                "\nNgày nhập: " + dtpNgayNhap.Value.ToShortDateString() +
                "\n" + lblTongTien.Text +
                "\n\nLưu ý: Dữ liệu chưa được lưu vào SQL Server."
            );
        }

        // 12. Hủy hóa đơn
        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show(
                "Bạn có chắc muốn hủy hóa đơn hiện tại?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (kq == DialogResult.Yes)
            {
                bangChiTiet.Clear();
                cboMaHDN.Text = "";
                cboNCC.SelectedIndex = -1;
                txtMaNCC.Clear();
                txtSDT.Clear();
                txtDiaChi.Clear();

                LamMoiNhapHang();
                CapNhatTongTien();
            }
        }

        // 13. Tìm hóa đơn mẫu
        private void btnTim_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Chức năng tìm hóa đơn cần dữ liệu đã lưu.\n" +
                "Hiện tại nhóm chưa kết nối SQL Server."
            );
        }

        // 14. In hóa đơn mẫu
        private void btnIn_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Chức năng xuất Excel sẽ được bổ sung sau."
            );
        }

        // 15. Thoát form
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

