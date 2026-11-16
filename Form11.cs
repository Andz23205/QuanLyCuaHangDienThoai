
using System;
using System.Windows.Forms;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    public partial class Form11 : Form
    {
        private readonly KhachHangBUS khachHangBUS = new KhachHangBUS();

        public Form11()
        {
            InitializeComponent();

            txtMatKhau.UseSystemPasswordChar = true;
            txtXacNhanMatKhau.UseSystemPasswordChar = true;

            btnDangKy.Click += btnDangKy_Click;
            btnQuayLai.Click += (s, e) => this.Close();
        }

        private void btnDangKy_Click(object? sender, EventArgs e)
        {
            // Kiểm tra dữ liệu nhập
            if (string.IsNullOrWhiteSpace(txtHoTen.Text) ||
                string.IsNullOrWhiteSpace(txtSoDienThoai.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtTaiKhoan.Text) ||
                string.IsNullOrWhiteSpace(txtMatKhau.Text) ||
                string.IsNullOrWhiteSpace(txtXacNhanMatKhau.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập đầy đủ thông tin!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Chỉ cho phép đăng ký khách hàng
            if (cboRole.Text.Trim() != "Khách hàng")
            {
                MessageBox.Show(
                    "Chỉ được phép đăng ký tài khoản Khách hàng!\n" +
                    "Tài khoản Quản lý và Nhân viên do hệ thống quản lý cấp.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Kiểm tra mật khẩu xác nhận
            if (txtMatKhau.Text != txtXacNhanMatKhau.Text)
            {
                MessageBox.Show(
                    "Mật khẩu xác nhận không khớp!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtXacNhanMatKhau.Focus();
                return;
            }

            // Tạo đối tượng khách hàng
            KhachHang kh = new KhachHang(
                "",
                txtHoTen.Text.Trim(),
                txtSoDienThoai.Text.Trim(),
                "",
                txtEmail.Text.Trim())
            {
                TaiKhoan = txtTaiKhoan.Text.Trim(),
                MatKhau = txtMatKhau.Text
            };

            // Gọi BUS đăng ký
            if (khachHangBUS.DangKy(kh, out string error))
            {
                MessageBox.Show(
                    "Đăng ký tài khoản thành công!\n\n" +
                    "Mã khách hàng: " + kh.MaKH +
                    "\nTên tài khoản: " + kh.TaiKhoan,
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(
                    error,
                    "Đăng ký thất bại",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
    }
}
