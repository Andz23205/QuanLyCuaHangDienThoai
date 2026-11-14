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

            // Goi qua tang Business Logic Layer (BUS)
            if (nhanVienBus.DangNhap(tk, mk, out NhanVien? nv, out string error))
            {
                MaNVDangNhap = nv!.MaNV;
                TenNVDangNhap = nv.HoTen;
                VaiTroDangNhap = nv.VaiTro;

                MessageBox.Show($"Đăng nhập thành công!\nXin chào {TenNVDangNhap} ({VaiTroDangNhap})", 
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
                Form10 main = new Form10();
                main.FormClosed += (s, args) => {
                    txtMatKhau.Clear();
                    this.Show();
                };
                main.Show();
            }
            else
            {
                MessageBox.Show(error, "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhau.Focus();
                txtMatKhau.SelectAll();
            }
        }
    }
}