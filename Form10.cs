using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Data;

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

        private Panel pnlRightSidebar;
        private Label lblTieuDe;
        private Label lblTaiKhoan;
        private Form formDangHienThi;

        private TableLayoutPanel tblBoCuc;
        private ToolTip toolTip;

        private ThongKeDAL thongKeDAL = new ThongKeDAL();

        private string tenNguoiDung = "";
        private string vaiTro = "";

        public Form10()
        {
            InitializeComponent();

            this.Text = "CỬA HÀNG BÁN ĐIỆN THOẠI - NHÓM 4";
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
                Height = 110,
                BackColor = Color.White,
                Padding = new Padding(24, 0, 24, 0)
            };

            // Khu vực nội dung
            pnlNoiDung = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = mauNen,
                Padding = Padding.Empty,
                AutoScroll = false
            };

            TaoSidebar();
            TaoHeader();

            // ================= BỐ CỤC TỔNG =================


            // Tạo bố cục 3 cột: Menu - Nội dung - Right Sidebar
            tblBoCuc = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                Margin = Padding.Empty,
                Padding = Padding.Empty,
                ColumnCount = 3,
                RowCount = 2,
                BackColor = mauNen
            };

            // Cột 1: Menu trái 500px
            tblBoCuc.ColumnStyles.Add(
                new ColumnStyle(SizeType.Absolute, 500F));

            // Cột 2: Nội dung tự giãn
            tblBoCuc.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 100F));

            // Cột 3: Right Sidebar 400px
            tblBoCuc.ColumnStyles.Add(
                new ColumnStyle(SizeType.Absolute, 400F));

            // Hàng 1: Header 110px
            tblBoCuc.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 110F));

            // Hàng 2: Phần nội dung còn lại
            tblBoCuc.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100F));

            // Thiết lập các Panel
            pnlSidebar.Dock = DockStyle.Fill;
            pnlHeader.Dock = DockStyle.Fill;
            pnlNoiDung.Dock = DockStyle.Fill;
            pnlNoiDung.Padding = Padding.Empty;

            // Tạo Right Sidebar
            pnlRightSidebar = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(12),
                AutoScroll = true
            };

            TaoRightSidebar();

            // Thêm Menu trái, chiếm cả 2 hàng
            tblBoCuc.Controls.Add(pnlSidebar, 0, 0);
            tblBoCuc.SetRowSpan(pnlSidebar, 2);

            // Header chiếm 2 cột bên phải
            tblBoCuc.Controls.Add(pnlHeader, 1, 0);
            tblBoCuc.SetColumnSpan(pnlHeader, 2);

            // Nội dung Form con
            tblBoCuc.Controls.Add(pnlNoiDung, 1, 1);

            // Right Sidebar
            tblBoCuc.Controls.Add(pnlRightSidebar, 2, 1);

            // Đưa bố cục vào Form10
            this.Controls.Clear();
            this.Controls.Add(tblBoCuc);

        }



        private void TaoRightSidebar()
        {
            // Bố cục tổng: Tiêu đề - Hai khu vực ảnh - Thông tin cửa hàng
            TableLayoutPanel tblRight = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 3,
                BackColor = Color.White,
                Margin = Padding.Empty,
                Padding = new Padding(8)
            };

            tblRight.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 100F));

            tblRight.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 42F));

            tblRight.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100F));

            tblRight.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 115F));

            // Tiêu đề
            Label lblTieuDeRight = new Label
            {
                Text = "THÔNG TIN NỔI BẬT",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(23, 43, 77),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Khu vực chia đôi cho khuyến mãi và điện thoại
            TableLayoutPanel tblAnh = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2,
                BackColor = Color.White,
                Margin = Padding.Empty
            };

            tblAnh.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 100F));

            tblAnh.RowStyles.Add(
                new RowStyle(SizeType.Percent, 50F));

            tblAnh.RowStyles.Add(
                new RowStyle(SizeType.Percent, 50F));

            // Khu vực khuyến mãi
            Panel pnlKhuyenMai = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(3),
                Margin = Padding.Empty
            };

            Label lblKhuyenMai = new Label
            {
                Text = "KHUYẾN MÃI HOT",
                Dock = DockStyle.Top,
                Height = 30,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(23, 43, 77),
                TextAlign = ContentAlignment.MiddleLeft
            };

            PictureBox picBanner = TaoPictureBoxChuan(
                "banner_khuyenmai.jpg", 340, 200);

            picBanner.Dock = DockStyle.Fill;
            picBanner.Margin = Padding.Empty;

            pnlKhuyenMai.Controls.Add(picBanner);
            pnlKhuyenMai.Controls.Add(lblKhuyenMai);

            // Khu vực điện thoại nổi bật
            Panel pnlDienThoai = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(3),
                Margin = Padding.Empty
            };

            Label lblDienThoai = new Label
            {
                Text = "ĐIỆN THOẠI NỔI BẬT",
                Dock = DockStyle.Top,
                Height = 30,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(23, 43, 77),
                TextAlign = ContentAlignment.MiddleLeft
            };

            Label lblTenDienThoai = new Label
            {
                Text = "iPhone 18",
                Dock = DockStyle.Bottom,
                Height = 28,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(23, 43, 77),
                TextAlign = ContentAlignment.MiddleCenter
            };

            PictureBox picDienThoai = TaoPictureBoxChuan(
                "iphone18.jpg", 340, 200);

            picDienThoai.Dock = DockStyle.Fill;
            picDienThoai.Margin = Padding.Empty;

            pnlDienThoai.Controls.Add(picDienThoai);
            pnlDienThoai.Controls.Add(lblTenDienThoai);
            pnlDienThoai.Controls.Add(lblDienThoai);

            tblAnh.Controls.Add(pnlKhuyenMai, 0, 0);
            tblAnh.Controls.Add(pnlDienThoai, 0, 1);

            // Thông tin cửa hàng: luôn nằm ở hàng cuối
            Panel pnlThongTin = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(245, 248, 252),
                Padding = new Padding(8),
                Margin = new Padding(0, 5, 0, 0)
            };

            Label lblTieuDeThongTin = new Label
            {
                Text = "THÔNG TIN CỬA HÀNG",
                Dock = DockStyle.Top,
                Height = 30,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(23, 43, 77),
                TextAlign = ContentAlignment.MiddleLeft
            };

            Label lblLienHe = new Label
            {
                Text = "Hotline: 1900 xxxx\n" +
                       "Hỗ trợ khách hàng 24/7\n" +
                       "Chính sách bảo hành và đổi trả uy tín",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(80, 90, 105),
                TextAlign = ContentAlignment.MiddleLeft
            };

            pnlThongTin.Controls.Add(lblLienHe);
            pnlThongTin.Controls.Add(lblTieuDeThongTin);

            // Ghép ba phần vào Right Sidebar
            tblRight.Controls.Add(lblTieuDeRight, 0, 0);
            tblRight.Controls.Add(tblAnh, 0, 1);
            tblRight.Controls.Add(pnlThongTin, 0, 2);

            pnlRightSidebar.Controls.Clear();
            pnlRightSidebar.Controls.Add(tblRight);
        }


        // Hàm hỗ trợ tạo PictureBox với kích thước tùy chỉnh để lấp đầy cột
        private PictureBox TaoPictureBoxChuan(string tenAnh, int chieuRong, int chieuCao)
        {
            string duongDan = Path.Combine(Application.StartupPath, "Images", tenAnh);

            if (!File.Exists(duongDan))
            {
                string dir = AppDomain.CurrentDomain.BaseDirectory;
                for (int i = 0; i < 4; i++)
                {
                    dir = Directory.GetParent(dir)?.FullName ?? dir;
                }
                string thuMucGoc = Path.Combine(dir, "Images", tenAnh);
                if (File.Exists(thuMucGoc))
                {
                    duongDan = thuMucGoc;
                }
            }

            PictureBox pic = new PictureBox
            {
                Width = chieuRong,
                Height = chieuCao,
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.White,
                Margin = new Padding(0, 5, 0, 10)
            };

            if (File.Exists(duongDan))
            {
                using (Image img = Image.FromFile(duongDan))
                {
                    pic.Image = new Bitmap(img);
                }
            }

            return pic;
        }

        private Panel TaoTheRightSidebar(string tieuDe, string noiDung)
        {
            Panel pnl = new Panel
            {
                Width = 400,
                Height = 190,
                BackColor = Color.FromArgb(242, 246, 252),
                Margin = new Padding(0, 5, 0, 12),
                Padding = new Padding(10)
            };

            Label lblTieuDe = new Label
            {
                Text = tieuDe,
                Dock = DockStyle.Top,
                Height = 35,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(23, 43, 77),
                TextAlign = ContentAlignment.MiddleLeft
            };

            Label lblNoiDung = new Label
            {
                Text = noiDung,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(80, 90, 105),
                TextAlign = ContentAlignment.MiddleCenter
            };

            pnl.Controls.Add(lblNoiDung);
            pnl.Controls.Add(lblTieuDe);

            return pnl;
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
                AutoSize = true, // Tự động co giãn theo nội dung để không bị cắt chữ
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
                Width = 440,
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
                Width = 440,
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

            // Bố cục tổng thể của Dashboard
            TableLayoutPanel tblDashboard = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 3,
                BackColor = mauNen,
                Padding = new Padding(20),
                Margin = Padding.Empty
            };

            tblDashboard.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 100F));

            // Hàng chào mừng
            tblDashboard.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 65F));

            // Hàng 4 thẻ thống kê
            tblDashboard.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 125F));

            // Biểu đồ chiếm phần còn lại, nhưng có giới hạn tối thiểu
            tblDashboard.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100F));

            // =========================
            // 1. KHU VỰC CHÀO MỪNG
            // =========================

            Panel pnlChao = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = mauNen,
                Margin = new Padding(0, 0, 0, 8)
            };

            Label lblChao = new Label
            {
                Text = "Xin chào, " + tenNguoiDung + "!",
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                ForeColor = mauNavy,
                AutoSize = true,
                Location = new Point(0, 0)
            };

            Label lblMoTa = new Label
            {
                Text = "Tổng quan hoạt động cửa hàng điện thoại",
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = mauPhu,
                AutoSize = true,
                Location = new Point(2, 39)
            };

            pnlChao.Controls.Add(lblChao);
            pnlChao.Controls.Add(lblMoTa);

            // =========================
            // 2. KHU VỰC THỐNG KÊ
            // =========================

            TableLayoutPanel tblThe = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 4,
                RowCount = 1,
                BackColor = mauNen,
                Margin = new Padding(0, 0, 0, 12),
                Padding = Padding.Empty
            };

            for (int i = 0; i < 4; i++)
            {
                tblThe.ColumnStyles.Add(
                    new ColumnStyle(SizeType.Percent, 25F));
            }

            tblThe.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100F));


            // Lấy dữ liệu từ SQL Server
            int tongSanPham = 0;
            int tongKhachHang = 0;
            int hoaDonHomNay = 0;
            decimal doanhThuHomNay = 0;

            try
            {
                tongSanPham = thongKeDAL.DemTongSanPham();
                tongKhachHang = thongKeDAL.DemTongKhachHang();
                hoaDonHomNay = thongKeDAL.DemHoaDonHomNay();
                doanhThuHomNay = thongKeDAL.TinhDoanhThuHomNay();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải dữ liệu thống kê:\n" + ex.Message,
                    "Lỗi dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

            // 4 ô thống kê nằm trên cùng một hàng ngang
            tblThe.Controls.Add(
                TaoTheThongKe("▣", "Tổng sản phẩm",
                tongSanPham.ToString("N0")), 0, 0);

            tblThe.Controls.Add(
                TaoTheThongKe("♙", "Khách hàng",
                tongKhachHang.ToString("N0")), 1, 0);

            tblThe.Controls.Add(
                TaoTheThongKe("▤", "Hóa đơn hôm nay",
                hoaDonHomNay.ToString("N0")), 2, 0);

            tblThe.Controls.Add(
                TaoTheThongKe("₫", "Doanh thu hôm nay",
                doanhThuHomNay.ToString("N0") + " đ"), 3, 0);


            // =========================
            // 3. KHU VỰC BIỂU ĐỒ
            // =========================

            Panel pnlBieuDo = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(16),
                Margin = Padding.Empty
            };

            // Chia biểu đồ thành 3 hàng riêng biệt
            TableLayoutPanel tblBieuDo = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 3,
                BackColor = Color.White,
                Margin = Padding.Empty,
                Padding = Padding.Empty
            };

            tblBieuDo.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));

            tblBieuDo.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));

            tblBieuDo.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            // Tiêu đề biểu đồ
            Label lblTieuDeBieuDo = new Label
            {
                Text = "DOANH THU 7 NGÀY GẦN NHẤT",
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                ForeColor = mauNavy,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                AutoEllipsis = false
            };

            // Mô tả
            Label lblMoTaBieuDo = new Label
            {
                Text = "Thống kê doanh thu bán hàng theo ngày",
                Font = new Font("Segoe UI", 9F),
                ForeColor = mauPhu,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            };

            // Lấy dữ liệu
            DataTable dtDoanhThu = new DataTable();

            try
            {
                dtDoanhThu = thongKeDAL.LayDoanhThu7Ngay();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải biểu đồ doanh thu:\n" + ex.Message,
                    "Lỗi dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

            // Khu vực vẽ biểu đồ
            Panel pnlVungBieuDo = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Margin = Padding.Empty,
                Padding = new Padding(0, 5, 0, 5),
                MinimumSize = new Size(0, 180)
            };

            // Vẽ lại khi Panel thay đổi kích thước
            pnlVungBieuDo.Paint += (s, e) =>
            {
                VeBieuDoDoanhThu(
                    e.Graphics,
                    pnlVungBieuDo.ClientSize,
                    dtDoanhThu);
            };

            pnlVungBieuDo.Resize += (s, e) =>
            {
                pnlVungBieuDo.Invalidate();
            };

            tblBieuDo.Controls.Add(lblTieuDeBieuDo, 0, 0);
            tblBieuDo.Controls.Add(lblMoTaBieuDo, 0, 1);
            tblBieuDo.Controls.Add(pnlVungBieuDo, 0, 2);

            pnlBieuDo.Controls.Add(tblBieuDo);

            // Ghép các khu vực
            tblDashboard.Controls.Add(pnlChao, 0, 0);
            tblDashboard.Controls.Add(tblThe, 0, 1);
            tblDashboard.Controls.Add(pnlBieuDo, 0, 2);

            pnlNoiDung.Controls.Add(tblDashboard);
        }





        private Panel TaoTheThongKe(string icon, string tieuDe, string giaTri)
        {
            Panel pnl = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Margin = new Padding(0, 0, 10, 0),
                Padding = new Padding(12)
            };

            TableLayoutPanel tbl = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 2,
                BackColor = Color.White,
                Margin = Padding.Empty,
                Padding = Padding.Empty
            };

            tbl.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 100F));

            tbl.ColumnStyles.Add(
                new ColumnStyle(SizeType.Absolute, 30F));

            tbl.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 38F));

            tbl.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100F));

            Label lblTen = new Label
            {
                Text = tieuDe,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = mauPhu,
                TextAlign = ContentAlignment.MiddleLeft,
                AutoEllipsis = true
            };

            Label lblIcon = new Label
            {
                Text = icon,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 15F, FontStyle.Bold),
                ForeColor = mauBlue,
                TextAlign = ContentAlignment.MiddleCenter
            };

            Label lblGiaTri = new Label
            {
                Text = giaTri,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = mauNavy,
                TextAlign = ContentAlignment.MiddleLeft,
                AutoEllipsis = true
            };

            tbl.Controls.Add(lblTen, 0, 0);
            tbl.Controls.Add(lblIcon, 1, 0);
            tbl.Controls.Add(lblGiaTri, 0, 1);
            tbl.SetColumnSpan(lblGiaTri, 2);

            pnl.Controls.Add(tbl);

            return pnl;
        }






        private decimal ChonBuocTruc(decimal doanhThuMax)
        {
            decimal giaTriMucTieu = doanhThuMax / 5m;
            decimal bac = 1m;

            while (giaTriMucTieu / bac >= 10m)
                bac *= 10m;

            while (giaTriMucTieu / bac < 1m)
                bac /= 10m;

            decimal heSo = giaTriMucTieu / bac;

            if (heSo <= 1m)
                return bac;
            if (heSo <= 2m)
                return 2m * bac;
            if (heSo <= 5m)
                return 5m * bac;

            return 10m * bac;
        }

        private string DinhDangTien(decimal soTien)
        {
            if (soTien >= 1_000_000_000m)
                return (soTien / 1_000_000_000m).ToString("0.##") + " tỷ";

            if (soTien >= 1_000_000m)
                return (soTien / 1_000_000m).ToString("0.##") + " tr";

            return soTien.ToString("N0");
        }

        private void VeBieuDoDoanhThu(
            Graphics g,
            Size kichThuoc,
            DataTable dt)
        {
            g.Clear(Color.White);

            if (kichThuoc.Width < 200 || kichThuoc.Height < 120)
                return;

            if (dt == null || dt.Rows.Count == 0)
            {
                using (Font f = new Font("Segoe UI", 11F))
                using (Brush b = new SolidBrush(mauPhu))
                {
                    g.DrawString("Chưa có dữ liệu doanh thu", f, b, 30, 30);
                }
                return;
            }

            if (!dt.Columns.Contains("DoanhThu") ||
                !dt.Columns.Contains("Ngay"))
                return;

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint =
                System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            float leTrai = 95;
            float lePhai = 25;
            float leTren = 42;
            float leDuoi = 48;

            float xTrai = leTrai;
            float xPhai = kichThuoc.Width - lePhai;
            float yTren = leTren;
            float yDuoi = kichThuoc.Height - leDuoi;

            float chieuRong = xPhai - xTrai;
            float chieuCao = yDuoi - yTren;

            if (chieuRong <= 0 || chieuCao <= 0)
                return;

            decimal doanhThuMax = 0;

            foreach (DataRow row in dt.Rows)
            {
                if (row["DoanhThu"] == DBNull.Value)
                    continue;

                decimal doanhThu = Convert.ToDecimal(row["DoanhThu"]);

                if (doanhThu > doanhThuMax)
                    doanhThuMax = doanhThu;
            }

            if (doanhThuMax <= 0)
                doanhThuMax = 1m;

            // Tự động chọn bước trục, tránh vẽ hàng nghìn đường lưới
            decimal buocTruc = ChonBuocTruc(doanhThuMax);

            decimal giaTriTrucMax =
                Math.Ceiling(doanhThuMax / buocTruc) * buocTruc;

            if (giaTriTrucMax <= 0)
                giaTriTrucMax = buocTruc;

            using (Font fontTruc = new Font("Segoe UI", 9F))
            using (Font fontTien = new Font("Segoe UI", 9F, FontStyle.Bold))
            using (Font fontNgay = new Font("Segoe UI", 9F))
            using (Brush brushChu = new SolidBrush(mauChu))
            using (Brush brushPhu = new SolidBrush(mauPhu))
            using (Brush brushCot = new SolidBrush(mauBlue))
            using (Pen penLuoi = new Pen(Color.FromArgb(225, 231, 239), 1))
            using (Pen penTruc = new Pen(Color.FromArgb(190, 200, 215), 1))
            using (StringFormat canGiua = new StringFormat())
            using (StringFormat canPhai = new StringFormat())
            {
                canGiua.Alignment = StringAlignment.Center;
                canGiua.LineAlignment = StringAlignment.Center;

                canPhai.Alignment = StringAlignment.Far;
                canPhai.LineAlignment = StringAlignment.Center;

                // Vẽ trục tung và đường lưới
                int soKhoang = (int)(giaTriTrucMax / buocTruc);

                for (int i = 0; i <= soKhoang; i++)
                {
                    decimal giaTri = i * buocTruc;

                    float y = yDuoi -
                        (float)(giaTri / giaTriTrucMax) * chieuCao;

                    g.DrawLine(penLuoi, xTrai, y, xPhai, y);

                    g.DrawString(
                        DinhDangTien(giaTri),
                        fontTruc,
                        brushPhu,
                        new RectangleF(0, y - 11, leTrai - 12, 22),
                        canPhai
                    );
                }

                g.DrawLine(penTruc, xTrai, yTren, xTrai, yDuoi);
                g.DrawLine(penTruc, xTrai, yDuoi, xPhai, yDuoi);

                // Vẽ cột doanh thu
                int soNgay = dt.Rows.Count;
                float khoangCot = chieuRong / soNgay;

                float rongCot = Math.Min(48F, khoangCot * 0.55F);

                for (int i = 0; i < soNgay; i++)
                {
                    DataRow row = dt.Rows[i];

                    if (row["DoanhThu"] == DBNull.Value ||
                        row["Ngay"] == DBNull.Value)
                        continue;

                    decimal doanhThu = Convert.ToDecimal(row["DoanhThu"]);
                    DateTime ngay = Convert.ToDateTime(row["Ngay"]);

                    float caoCot =
                        (float)(doanhThu / giaTriTrucMax) * chieuCao;

                    float x = xTrai + i * khoangCot
                        + (khoangCot - rongCot) / 2;

                    float y = yDuoi - caoCot;

                    if (doanhThu > 0)
                    {
                        g.FillRectangle(
                            brushCot,
                            x,
                            y,
                            rongCot,
                            caoCot
                        );
                    }

                    // Hiển thị doanh thu rút gọn
                    string tien = DinhDangTien(doanhThu);

                    g.DrawString(
                        tien,
                        fontTien,
                        brushChu,
                        new RectangleF(
                            xTrai + i * khoangCot,
                            Math.Max(0, y - 27),
                            khoangCot,
                            23
                        ),
                        canGiua
                    );

                    // Hiển thị ngày
                    g.DrawString(
                        ngay.ToString("dd/MM"),
                        fontNgay,
                        brushPhu,
                        new RectangleF(
                            xTrai + i * khoangCot,
                            yDuoi + 8,
                            khoangCot,
                            25
                        ),
                        canGiua
                    );
                }
            }
        }




        // Mở Form chức năng trong vùng nội dung
        private void MoForm(Form f, string tieuDe)
        {
            // Đóng Form cũ nếu đang hiển thị
            DongFormDangHienThi();

            // Cập nhật tiêu đề trên Header
            lblTieuDe.Text = tieuDe;

            // Tạm dừng bố cục để tránh nhấp nháy
            pnlNoiDung.SuspendLayout();

            // Xóa các control cũ trong vùng nội dung
            pnlNoiDung.Controls.Clear();

            // Cấu hình Form con
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            f.StartPosition = FormStartPosition.Manual;

            // Xóa khoảng cách ngoài
            f.Margin = Padding.Empty;

            // Yêu cầu Form con lấp đầy vùng nội dung
            f.Dock = DockStyle.Fill;

            // Thêm Form con vào vùng nội dung
            pnlNoiDung.Controls.Add(f);

            // Đảm bảo Form con chiếm toàn bộ vùng hiển thị
            f.Dock = DockStyle.Fill;

            // Hiển thị Form con
            f.Show();
            f.BringToFront();

            // Lưu Form đang hiển thị
            formDangHienThi = f;

            // Hoàn tất bố cục
            pnlNoiDung.ResumeLayout(true);
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