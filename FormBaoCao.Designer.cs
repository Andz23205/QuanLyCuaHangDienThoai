namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    partial class FormBaoCao
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            tabControl1        = new System.Windows.Forms.TabControl();
            tabDoanhThu        = new System.Windows.Forms.TabPage();
            dgvDoanhThu        = new System.Windows.Forms.DataGridView();
            lblTongDoanhThu    = new System.Windows.Forms.Label();
            tabTonKho          = new System.Windows.Forms.TabPage();
            dgvTonKho          = new System.Windows.Forms.DataGridView();
            lblTongTonKho      = new System.Windows.Forms.Label();
            tabTopBanChay      = new System.Windows.Forms.TabPage();
            dgvTopBanChay      = new System.Windows.Forms.DataGridView();
            panelBottom        = new System.Windows.Forms.Panel();
            btnXuatExcel       = new System.Windows.Forms.Button();
            btnLamMoi          = new System.Windows.Forms.Button();
            btnDong            = new System.Windows.Forms.Button();
            lblTitle           = new System.Windows.Forms.Label();

            // tabControl1
            tabControl1.Controls.Add(tabDoanhThu);
            tabControl1.Controls.Add(tabTonKho);
            tabControl1.Controls.Add(tabTopBanChay);
            tabControl1.Dock      = System.Windows.Forms.DockStyle.Fill;
            tabControl1.Font      = new System.Drawing.Font("Segoe UI", 10f);
            tabControl1.ItemSize  = new System.Drawing.Size(160, 32);

            // tabDoanhThu
            tabDoanhThu.Text = "📊 Doanh thu theo tháng";
            tabDoanhThu.Controls.Add(dgvDoanhThu);
            tabDoanhThu.Controls.Add(lblTongDoanhThu);
            tabDoanhThu.Padding = new System.Windows.Forms.Padding(5);

            dgvDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvDoanhThu.Font = new System.Drawing.Font("Segoe UI", 9.5f);

            lblTongDoanhThu.Dock      = System.Windows.Forms.DockStyle.Bottom;
            lblTongDoanhThu.Height    = 30;
            lblTongDoanhThu.Font      = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            lblTongDoanhThu.ForeColor = System.Drawing.Color.DarkGreen;
            lblTongDoanhThu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lblTongDoanhThu.Padding   = new System.Windows.Forms.Padding(5, 0, 0, 0);
            lblTongDoanhThu.Text      = "Đang tải...";

            // tabTonKho
            tabTonKho.Text = "📦 Tồn kho";
            tabTonKho.Controls.Add(dgvTonKho);
            tabTonKho.Controls.Add(lblTongTonKho);
            tabTonKho.Padding = new System.Windows.Forms.Padding(5);

            dgvTonKho.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvTonKho.Font = new System.Drawing.Font("Segoe UI", 9.5f);

            lblTongTonKho.Dock      = System.Windows.Forms.DockStyle.Bottom;
            lblTongTonKho.Height    = 30;
            lblTongTonKho.Font      = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            lblTongTonKho.ForeColor = System.Drawing.Color.DarkBlue;
            lblTongTonKho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lblTongTonKho.Padding   = new System.Windows.Forms.Padding(5, 0, 0, 0);
            lblTongTonKho.Text      = "Đang tải...";

            // tabTopBanChay
            tabTopBanChay.Text = "🏆 Top bán chạy";
            tabTopBanChay.Controls.Add(dgvTopBanChay);
            tabTopBanChay.Padding = new System.Windows.Forms.Padding(5);

            dgvTopBanChay.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvTopBanChay.Font = new System.Drawing.Font("Segoe UI", 9.5f);

            // panelBottom (buttons)
            panelBottom.Dock      = System.Windows.Forms.DockStyle.Bottom;
            panelBottom.Height    = 55;
            panelBottom.Padding   = new System.Windows.Forms.Padding(10, 8, 10, 8);
            panelBottom.BackColor = System.Drawing.Color.WhiteSmoke;
            panelBottom.Controls.Add(btnDong);
            panelBottom.Controls.Add(btnLamMoi);
            panelBottom.Controls.Add(btnXuatExcel);

            btnXuatExcel.Text      = "📄 Xuất Excel";
            btnXuatExcel.Size      = new System.Drawing.Size(140, 36);
            btnXuatExcel.Location  = new System.Drawing.Point(10, 9);
            btnXuatExcel.BackColor = System.Drawing.Color.ForestGreen;
            btnXuatExcel.ForeColor = System.Drawing.Color.White;
            btnXuatExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnXuatExcel.Font      = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            btnXuatExcel.Click    += btnXuatExcel_Click;

            btnLamMoi.Text      = "🔄 Làm mới";
            btnLamMoi.Size      = new System.Drawing.Size(120, 36);
            btnLamMoi.Location  = new System.Drawing.Point(160, 9);
            btnLamMoi.BackColor = System.Drawing.Color.SteelBlue;
            btnLamMoi.ForeColor = System.Drawing.Color.White;
            btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnLamMoi.Font      = new System.Drawing.Font("Segoe UI", 10f);
            btnLamMoi.Click    += btnLamMoi_Click;

            btnDong.Text      = "✖ Đóng";
            btnDong.Size      = new System.Drawing.Size(100, 36);
            btnDong.Location  = new System.Drawing.Point(290, 9);
            btnDong.BackColor = System.Drawing.Color.Crimson;
            btnDong.ForeColor = System.Drawing.Color.White;
            btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnDong.Font      = new System.Drawing.Font("Segoe UI", 10f);
            btnDong.Click    += btnDong_Click;

            // lblTitle
            lblTitle.Text      = "BÁO CÁO THỐNG KÊ CỬA HÀNG ĐIỆN THOẠI";
            lblTitle.Dock      = System.Windows.Forms.DockStyle.Top;
            lblTitle.Height    = 50;
            lblTitle.Font      = new System.Drawing.Font("Segoe UI", 15f, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.DarkBlue;
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblTitle.BackColor = System.Drawing.Color.AliceBlue;

            // Form
            this.Controls.Add(tabControl1);
            this.Controls.Add(panelBottom);
            this.Controls.Add(lblTitle);
            this.BackColor = System.Drawing.Color.White;
        }

        private System.Windows.Forms.TabControl     tabControl1;
        private System.Windows.Forms.TabPage        tabDoanhThu;
        private System.Windows.Forms.TabPage        tabTonKho;
        private System.Windows.Forms.TabPage        tabTopBanChay;
        private System.Windows.Forms.DataGridView   dgvDoanhThu;
        private System.Windows.Forms.DataGridView   dgvTonKho;
        private System.Windows.Forms.DataGridView   dgvTopBanChay;
        private System.Windows.Forms.Label          lblTongDoanhThu;
        private System.Windows.Forms.Label          lblTongTonKho;
        private System.Windows.Forms.Panel          panelBottom;
        private System.Windows.Forms.Button         btnXuatExcel;
        private System.Windows.Forms.Button         btnLamMoi;
        private System.Windows.Forms.Button         btnDong;
        private System.Windows.Forms.Label          lblTitle;
    }
}
