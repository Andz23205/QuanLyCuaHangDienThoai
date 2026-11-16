
using System;
using System.Windows.Forms;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    public partial class Form9 : Form
    {
        // Thông tin nhân viên
        public static string MaNVDangNhap = "";
        public static string TenNVDangNhap = "";

        // Thông tin khách hàng
        public static string MaKHDangNhap = "";
        public static string TenKHDangNhap = "";

        // Vai trò tài khoản
        public static string VaiTroDangNhap = "";

        private readonly NhanVienBUS nhanVienBus = new NhanVienBUS();
        private readonly KhachHangBUS khachHangBus = new KhachHangBUS();

        public Form9()
        {
            InitializeComponent();

            txtMatKhau.UseSystemPasswordChar = true;

            button1.Click += btnDangNhap_Click;
            button2.Click += (s, e) => Application.Exit();
            button3.Click += btnDangKy_Click;

            AcceptButton = button1;
            CancelButton = button2;
        }

        // Đăng ký tài khoản khách hàng
        private void btnDangKy_Click(object? sender, EventArgs e)
        {
            using (Form11 form = new Form11())
            {
                form.ShowDialog(this);
            }
        }

        // Xóa phiên đăng nhập
        private void XoaThongTinDangNhap()
        {
            MaNVDangNhap = "";
            TenNVDangNhap = "";

            MaKHDangNhap = "";
            TenKHDangNhap = "";

            VaiTroDangNhap = "";
        }

        // Quay lại màn hình đăng nhập khi form chính đóng
        private void XuLyDongForm(object? sender, FormClosedEventArgs e)
        {
            XoaThongTinDangNhap();

            txtMaNhanVien.Clear();
            txtMatKhau.Clear();

            txtMaNhanVien.Focus();

            this.Show();
        }

        // Mở Form10 cho nhân viên và quản lý
        private void MoFormNhanVien()
        {
            this.Hide();

            Form10 form = new Form10();
            form.FormClosed += XuLyDongForm;
            form.Show();
        }

        // Mở Form12 cho khách hàng
        private void MoFormKhachHang()
        {
            this.Hide();

            Form12 form = new Form12();
            form.FormClosed += XuLyDongForm;
            form.Show();
        }

        // Xử lý đăng nhập
        private void btnDangNhap_Click(object? sender, EventArgs e)
        {
            string tk = txtMaNhanVien.Text.Trim();
            string mk = txtMatKhau.Text;

            if (string.IsNullOrWhiteSpace(tk) ||
                string.IsNullOrWhiteSpace(mk))
            {
                MessageBox.Show(
                    "Vui lòng nhập đầy đủ tài khoản và mật khẩu!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            XoaThongTinDangNhap();

            // ==================================
            // 1. KIỂM TRA TÀI KHOẢN NHÂN VIÊN
            // ==================================

            if (nhanVienBus.DangNhap(
                tk,
                mk,
                out NhanVien? nv,
                out string errorNhanVien))
            {
                MaNVDangNhap = nv!.MaNV;
                TenNVDangNhap = nv.HoTen;
                VaiTroDangNhap = nv.VaiTro;

                MoFormNhanVien();
                return;
            }

            // ==================================
            // 2. KIỂM TRA TÀI KHOẢN KHÁCH HÀNG
            // ==================================

            if (khachHangBus.DangNhap(
                tk,
                mk,
                out KhachHang? kh,
                out string errorKhachHang))
            {
                MaKHDangNhap = kh!.MaKH;
                TenKHDangNhap = kh.HoTen;
                VaiTroDangNhap = "Khách hàng";

                MoFormKhachHang();
                return;
            }

            // ==================================
            // 3. ĐĂNG NHẬP THẤT BẠI
            // ==================================

            MessageBox.Show(
                "Tên đăng nhập hoặc mật khẩu không chính xác!",
                "Lỗi đăng nhập",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            txtMatKhau.Focus();
            txtMatKhau.SelectAll();
        }
    }
}
