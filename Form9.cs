using System;
using System.Windows.Forms;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    public partial class Form9 : Form
    {
        public static string MaNVDangNhap = "";
        public static string TenNVDangNhap = "";
        public static string VaiTroDangNhap = "";

        private readonly NhanVienBUS nhanVienBus = new NhanVienBUS();

        public Form9()
        {
            InitializeComponent();

            txtMatKhau.UseSystemPasswordChar = true;

            button1.Click += btnDangNhap_Click;
            button2.Click += (s, e) => Application.Exit();

            AcceptButton = button1;
            CancelButton = button2;
        }

        private void btnDangNhap_Click(object? sender, EventArgs e)
        {
            string tk = txtMaNhanVien.Text.Trim();
            string mk = txtMatKhau.Text.Trim();

            if (string.IsNullOrWhiteSpace(tk) || string.IsNullOrWhiteSpace(mk))
            {
                MessageBox.Show(
                    "Vui lòng nhập đầy đủ mã nhân viên và mật khẩu!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Kiểm tra đăng nhập qua BUS
            if (nhanVienBus.DangNhap(tk, mk, out NhanVien? nv, out string error))
            {
                MaNVDangNhap = nv!.MaNV;
                TenNVDangNhap = nv.HoTen;
                VaiTroDangNhap = nv.VaiTro;

               

                // Ẩn Form đăng nhập
                this.Hide();

                // Mở Form10
                Form10 main = new Form10();

                // Khi Form10 đóng thì quay lại Form9
                main.FormClosed += (s, args) =>
                {
                    txtMatKhau.Clear();
                    txtMaNhanVien.Focus();

                    // Xóa thông tin phiên đăng nhập
                    MaNVDangNhap = "";
                    TenNVDangNhap = "";
                    VaiTroDangNhap = "";

                    this.Show();
                };

                main.Show();
            }
            else
            {
                MessageBox.Show(
                    error,
                    "Lỗi đăng nhập",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                txtMatKhau.Focus();
                txtMatKhau.SelectAll();
            }
        }
    }
}
