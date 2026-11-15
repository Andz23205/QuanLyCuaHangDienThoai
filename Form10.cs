using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Forms;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    public partial class Form10 : Form
    {
        // Màu sắc chủ đạo
        private readonly Color mauNavy = Color.FromArgb(20, 43, 74);
        private readonly Color mauBlue = Color.FromArgb(36, 120, 212);
        private readonly Color mauNen = Color.FromArgb(244, 247, 251);
        private readonly Color mauChu = Color.FromArgb(35, 51, 72);
        private readonly Color mauPhu = Color.FromArgb(112, 128, 150);

        private Panel pnlSidebar;
        private Panel pnlHeader;
        private Panel pnlNoiDung;
        private Label lblTieuDe;
        private Label lblTaiKhoan;
        private Form formDangHienThi;
        private ToolTip toolTip;

        private string tenNguoiDung = "";
        private string vaiTro = "";

        public Form10()
        {
            InitializeComponent();

            this.Text = "PHONE STORE - MANAGEMENT SYSTEM";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = new Size(1100, 700);
            this.BackColor = mauNen;
            this.Font = new Font("Segoe UI", 10F);

            tenNguoiDung = string.IsNullOrWhiteSpace(Form9.TenNVDangNhap)
                ? "Người dùng"
                : Form9.TenNVDangNhap.Trim();

            vaiTro = string.IsNullOrWhiteSpace(Form9.VaiTroDangNhap)
                ? "Chưa xác định"
                : Form9.VaiTroDangNhap.Trim();

            toolTip = new ToolTip();

            TaoGiaoDien();
            Load += Form10_Load;
        }

        private bool LaQuanLy()
        {
            return vaiTro.Equals("Quản lý", StringComparison.OrdinalIgnoreCase)
                || vaiTro.Equals("Quan ly", StringComparison.OrdinalIgnoreCase)
                || vaiTro.Equals("Admin", StringComparison.OrdinalIgnoreCase);
        }

        private void TaoGiaoDien()
        {
            // Sidebar
            pnlSidebar = new Panel
            {
                Dock = DockStyle.Left,
                Width = 500,
                BackColor = mauNavy
            };

            // Header
            pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 76,
                BackColor = Color.White,
                Padding = new Padding(24, 0, 24, 0)
            };

            // Khu vực nội dung
            pnlNoiDung = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = mauNen,
                Padding = new Padding(24),
                AutoScroll = true
            };

            TaoSidebar();
            TaoHeader();

            Controls.Add(pnlNoiDung);
            Controls.Add(pnlHeader);
            Controls.Add(pnlSidebar);

            // Đảm bảo thứ tự Dock chính xác
            pnlSidebar.Dock = DockStyle.Left;
            pnlHeader.Dock = DockStyle.Top;
            pnlNoiDung.Dock = DockStyle.Fill;

            pnlSidebar.BringToFront();
            pnlHeader.BringToFront();
            pnlNoiDung.BringToFront();
        }

        private void TaoSidebar()
        {
            Panel pnlLogo = new Panel
            {
                Dock = DockStyle.Top,
                Height = 105,
                BackColor = mauNavy,
                Padding = new Padding(20, 18, 10, 10)
            };

            Label lblLogo = new Label
            {
                Text = "▣  PHONE STORE",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 17F, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(18, 22)
            };

            Label lblPhu = new Label
            {
                Text = "MANAGEMENT SYSTEM",
                ForeColor = Color.FromArgb(175, 195, 220),
                Font = new Font("Segoe UI", 8.5F),
                AutoSize = true,
                Location = new Point(21, 56)
            };

            pnlLogo.Controls.Add(lblLogo);
            pnlLogo.Controls.Add(lblPhu);

            FlowLayoutPanel flpMenu = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = true,
                BackColor = mauNavy,
                Padding = new Padding(12, 12, 12, 12)
            };

            Label lblNhomTongQuan = TaoNhomMenu("TỔNG QUAN");
            flpMenu.Controls.Add(lblNhomTongQuan);

            flpMenu.Controls.Add(TaoNutMenu("⌂", "Tổng quan", () =>
            {
                HienThiDashboard();
            }));

            Label lblNhomQuanLy = TaoNhomMenu("QUẢN LÝ CỬA HÀNG");
            flpMenu.Controls.Add(lblNhomQuanLy);

            flpMenu.Controls.Add(TaoNutMenu("▣", "Điện thoại", () =>
            {
                MoForm(new Form1(), "Điện thoại");
            }));

            flpMenu.Controls.Add(TaoNutMenu("▤", "Danh mục", () =>
            {
                MoForm(new Form5(), "Danh mục");
            }));

            // Chỉ quản lý mới được vào Form2
            if (LaQuanLy())
            {
                flpMenu.Controls.Add(TaoNutMenu("♙", "Nhân viên", () =>
                {
                    MoForm(new Form2(), "Quản lý nhân viên");
                }));
            }

            flpMenu.Controls.Add(TaoNutMenu("♧", "Khách hàng", () =>
            {
                MoForm(new Form3(), "Quản lý khách hàng");
            }));

            flpMenu.Controls.Add(TaoNutMenu("▱", "Nhà cung cấp", () =>
            {
                MoForm(new Form4(), "Nhà cung cấp");
            }));

            flpMenu.Controls.Add(TaoNutMenu("⌕", "Tìm kiếm", () =>
            {
                MoForm(new Form6(), "Tìm kiếm điện thoại");
            }));

            Label lblNhomHoaDon = TaoNhomMenu("GIAO DỊCH");
            flpMenu.Controls.Add(lblNhomHoaDon);

            flpMenu.Controls.Add(TaoNutMenu("▤", "Hóa đơn bán", () =>
            {
                MoForm(new Form7(), "Hóa đơn bán hàng");
            }));

            flpMenu.Controls.Add(TaoNutMenu("▧", "Hóa đơn nhập", () =>
            {
                MoForm(new Form8(), "Hóa đơn nhập hàng");
            }));

            Label lblNhomBaoCao = TaoNhomMenu("THỐNG KÊ");
            flpMenu.Controls.Add(lblNhomBaoCao);

            flpMenu.Controls.Add(TaoNutMenu("▥", "Báo cáo", () =>
            {
                MoForm(new FormBaoCao(), "Báo cáo thống kê");
            }));

            Panel pnlDangXuat = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 65,
                BackColor = mauNavy,
                Padding = new Padding(12, 8, 12, 8)
            };

            Button btnDangXuat = TaoNutMenu("⇥", "Đăng xuất", () =>
            {
                if (MessageBox.Show(
                    "Bạn có muốn đăng xuất khỏi hệ thống?",
                    "Xác nhận đăng xuất",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Close();
                }
            });

            btnDangXuat.Dock = DockStyle.Fill;
            pnlDangXuat.Controls.Add(btnDangXuat);

            pnlSidebar.Controls.Add(flpMenu);
            pnlSidebar.Controls.Add(pnlDangXuat);
            pnlSidebar.Controls.Add(pnlLogo);
        }

        private void TaoHeader()
        {
            lblTieuDe = new Label
            {
                Text = "Tổng quan",
                AutoSize = true,
                Font = new Font("Segoe UI", 17F, FontStyle.Bold),
                ForeColor = mauChu,
                Location = new Point(24, 21)
            };

            lblTaiKhoan = new Label
            {
                Text = tenNguoiDung + "  |  " + vaiTro,
                AutoSize = true,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = mauNavy,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };

            pnlHeader.Controls.Add(lblTieuDe);
            pnlHeader.Controls.Add(lblTaiKhoan);

            pnlHeader.Resize += (s, e) =>
            {
                lblTaiKhoan.Location = new Point(
                    pnlHeader.ClientSize.Width - lblTaiKhoan.Width - 28, 28);
            };
        }

        private Label TaoNhomMenu(string text)
        {
            return new Label
            {
                Text = text,
                Width = 500,
                Height = 34,
                TextAlign = ContentAlignment.MiddleLeft,
                ForeColor = Color.FromArgb(151, 174, 202),
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                Margin = new Padding(4, 13, 4, 3),
                Padding = new Padding(8, 0, 0, 0)
            };
        }

        private Button TaoNutMenu(string icon, string text, Action hanhDong)
        {
            Button btn = new Button
            {
                Text = "  " + icon + "     " + text,
                Width = 500,
                Height = 45,
                FlatStyle = FlatStyle.Flat,
                BackColor = mauNavy,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10F),
                TextAlign = ContentAlignment.MiddleLeft,
                Cursor = Cursors.Hand,
                Margin = new Padding(3, 3, 3, 3),
                Padding = new Padding(8, 0, 0, 0)
            };

            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(39, 72, 111);
            btn.Click += (s, e) => hanhDong();

            return btn;
        }

        private void Form10_Load(object? sender, EventArgs e)
        {
            HienThiDashboard();
        }

        // Trang tổng quan
        private void HienThiDashboard()
        {
            DongFormDangHienThi();

            lblTieuDe.Text = "Tổng quan";

            pnlNoiDung.Controls.Clear();

            FlowLayoutPanel flp = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = true,
                BackColor = mauNen,
                Padding = new Padding(4)
            };

            Label lblChao = new Label
            {
                Text = "Xin chào, " + tenNguoiDung + "!",
                Font = new Font("Segoe UI", 19F, FontStyle.Bold),
                ForeColor = mauNavy,
                AutoSize = true,
                Margin = new Padding(0, 0, 0, 5)
            };

            Label lblMoTa = new Label
            {
                Text = "Tổng quan hoạt động cửa hàng điện thoại",
                Font = new Font("Segoe UI", 10F),
                ForeColor = mauPhu,
                AutoSize = true,
                Margin = new Padding(0, 0, 0, 22)
            };

            flp.Controls.Add(lblChao);
            flp.Controls.Add(lblMoTa);

            FlowLayoutPanel flpThe = new FlowLayoutPanel
            {
                Width = 1100,
                Height = 145,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true,
                BackColor = mauNen,
                Margin = new Padding(0, 0, 0, 20)
            };

            flpThe.Controls.Add(TaoTheThongKe("▣", "Tổng sản phẩm", "—"));
            flpThe.Controls.Add(TaoTheThongKe("♙", "Khách hàng", "—"));
            flpThe.Controls.Add(TaoTheThongKe("▤", "Hóa đơn hôm nay", "—"));
            flpThe.Controls.Add(TaoTheThongKe("₫", "Doanh thu hôm nay", "—"));

            flp.Controls.Add(flpThe);

            Panel pnlBieuDo = new Panel
            {
                Width = 1100,
                Height = 300,
                BackColor = Color.White,
                Padding = new Padding(22),
                Margin = new Padding(0, 0, 0, 20)
            };

            Label lblBieuDo = new Label
            {
                Text = "BIỂU ĐỒ DOANH THU",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = mauNavy,
                AutoSize = true,
                Location = new Point(22, 18)
            };

            Label lblChoDuLieu = new Label
            {
                Text = "Biểu đồ sẽ hiển thị sau khi kết nối dữ liệu doanh thu từ SQL Server.",
                Font = new Font("Segoe UI", 10F),
                ForeColor = mauPhu,
                AutoSize = true,
                Location = new Point(22, 65)
            };

            pnlBieuDo.Controls.Add(lblBieuDo);
            pnlBieuDo.Controls.Add(lblChoDuLieu);

            flp.Controls.Add(pnlBieuDo);

            Panel pnlHuongDan = new Panel
            {
                Width = 1100,
                Height = 100,
                BackColor = Color.White,
                Padding = new Padding(22),
                Margin = new Padding(0, 0, 0, 20)
            };

            Label lblHuongDan = new Label
            {
                Text = "HƯỚNG DẪN SỬ DỤNG",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = mauNavy,
                AutoSize = true,
                Location = new Point(22, 15)
            };

            Label lblNoiDungHuongDan = new Label
            {
                Text = "Chọn chức năng ở menu bên trái để quản lý sản phẩm, khách hàng, hóa đơn và các hoạt động của cửa hàng.",
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = mauPhu,
                AutoSize = true,
                Location = new Point(22, 48)
            };

            pnlHuongDan.Controls.Add(lblHuongDan);
            pnlHuongDan.Controls.Add(lblNoiDungHuongDan);

            flp.Controls.Add(pnlHuongDan);

            pnlNoiDung.Controls.Add(flp);
        }

        private Panel TaoTheThongKe(string icon, string tieuDe, string giaTri)
        {
            Panel pnl = new Panel
            {
                Width = 255,
                Height = 125,
                BackColor = Color.White,
                Margin = new Padding(0, 0, 16, 10),
                Padding = new Padding(16)
            };

            Label lblIcon = new Label
            {
                Text = icon,
                Font = new Font("Segoe UI", 19F, FontStyle.Bold),
                ForeColor = mauBlue,
                AutoSize = true,
                Location = new Point(16, 12)
            };

            Label lblTen = new Label
            {
                Text = tieuDe,
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = mauPhu,
                AutoSize = true,
                Location = new Point(16, 55)
            };

            Label lblGiaTri = new Label
            {
                Text = giaTri,
                Font = new Font("Segoe UI", 21F, FontStyle.Bold),
                ForeColor = mauNavy,
                AutoSize = true,
                Location = new Point(16, 77)
            };

            pnl.Controls.Add(lblIcon);
            pnl.Controls.Add(lblTen);
            pnl.Controls.Add(lblGiaTri);

            return pnl;
        }

        // Mở Form chức năng trong vùng nội dung
        private void MoForm(Form f, string tieuDe)
        {
            DongFormDangHienThi();

            pnlNoiDung.Controls.Clear();

            lblTieuDe.Text = tieuDe;

            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;

            pnlNoiDung.Controls.Add(f);
            formDangHienThi = f;

            f.Show();
            f.BringToFront();
        }

        private void DongFormDangHienThi()
        {
            if (formDangHienThi != null)
            {
                formDangHienThi.Close();
                formDangHienThi.Dispose();
                formDangHienThi = null;
            }
        }
    }
}