using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();

            Load += Form10_Load;

            // Wire up menu items by index to avoid encoding issues
            if (mnuDanhMuc.DropDownItems.Count >= 5)
            {
                mnuDanhMuc.DropDownItems[0].Click += (s, e) => MoForm(new Form1());
                mnuDanhMuc.DropDownItems[1].Click += (s, e) => MoForm(new Form5());
                mnuDanhMuc.DropDownItems[2].Click += (s, e) => MoForm(new Form2());
                mnuDanhMuc.DropDownItems[3].Click += (s, e) => MoForm(new Form3());
                mnuDanhMuc.DropDownItems[4].Click += (s, e) => MoForm(new Form4());
            }

            // Menu Hoa Don drop downs
            ToolStripMenuItem mnuHDB = new ToolStripMenuItem("Hóa đơn bán hàng", null, (s, e) => MoForm(new Form7()));
            ToolStripMenuItem mnuHDN = new ToolStripMenuItem("Hóa đơn nhập hàng", null, (s, e) => MoForm(new Form8()));
            mnuHoaDon.DropDownItems.Add(mnuHDB);
            mnuHoaDon.DropDownItems.Add(mnuHDN);

            // Menu Tim kiem & Bao cao
            mnuTimKiem.Click += (s, e) => MoForm(new Form6());
            mnuBaocao.Click += (s, e) => MoForm(new FormBaoCao());

            // Thoat
            mnuThoat.Click += (s, e) => {
                if (MessageBox.Show("Bạn có muốn đăng xuất khỏi hệ thống?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Close();
                }
            };
        }

        private void Form10_Load(object? sender, EventArgs e)
        {
            this.Text = "HỆ THỐNG QUẢN LÝ CỬA HÀNG ĐIỆN THOẠI - NHÓM 4";
            this.WindowState = FormWindowState.Maximized;

            string tenNV = string.IsNullOrEmpty(Form9.TenNVDangNhap) ? "Admin" : Form9.TenNVDangNhap;
            string vaiTro = string.IsNullOrEmpty(Form9.VaiTroDangNhap) ? "Quản lý" : Form9.VaiTroDangNhap;

            tslNhanVien.Text = $"Người dùng: {tenNV} | Quyền: {vaiTro}      ";
            tslNgay.Text = $"Hôm nay: {DateTime.Now:dd/MM/yyyy HH:mm}";

            // Role check: If not Quan ly, disable Nhan vien management
            if (!vaiTro.Equals("Quản lý", StringComparison.OrdinalIgnoreCase) && !vaiTro.Equals("Admin", StringComparison.OrdinalIgnoreCase))
            {
                if (mnuDanhMuc.DropDownItems.Count >= 3)
                    mnuDanhMuc.DropDownItems[2].Enabled = false;
            }
        }

        private void MoForm(Form f)
        {
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ShowDialog();
        }
    }
}