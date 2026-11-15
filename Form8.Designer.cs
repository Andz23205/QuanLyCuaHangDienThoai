
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    partial class Form8
    {
        private System.ComponentModel.IContainer components = null;

        // ==========================================
        // MÀU SẮC - ĐỒNG BỘ FORM7
        // ==========================================

        private readonly Color mauNen = Color.FromArgb(244, 247, 251);
        private readonly Color mauChu = Color.FromArgb(35, 51, 72);
        private readonly Color mauXanh = Color.FromArgb(36, 120, 212);
        private readonly Color mauXanhDam = Color.FromArgb(20, 43, 74);
        private readonly Color mauXanhLa = Color.FromArgb(36, 155, 110);
        private readonly Color mauDo = Color.FromArgb(220, 75, 75);
        private readonly Color mauXam = Color.FromArgb(105, 119, 139);
        private readonly Color mauVien = Color.FromArgb(220, 227, 237);

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            // ==========================================
            // KHỞI TẠO CONTROL
            // ==========================================

            label1 = new Label();

            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            groupBox4 = new GroupBox();

            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();

            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();

            cboMaHDN = new ComboBox();
            txtMaNV = new TextBox();
            cboNCC = new ComboBox();
            txtSDT = new TextBox();
            dtpNgayNhap = new DateTimePicker();
            txtTenNV = new TextBox();
            txtMaNCC = new TextBox();
            txtDiaChi = new TextBox();

            cboMaHang = new ComboBox();
            txtTenHang = new TextBox();
            txtDonGiaNhap = new TextBox();
            txtSoLuong = new TextBox();
            txtThanhTien = new TextBox();

            btnTim = new Button();
            button1 = new Button();

            dgvChiTiet = new DataGridView();
            lblTongTien = new Label();

            btnThemHD = new Button();
            btnLuu = new Button();
            btnHuy = new Button();
            btnIn = new Button();
            btnThoat = new Button();

            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).BeginInit();

            SuspendLayout();

            // ==========================================
            // FORM
            // ==========================================

            AutoScaleMode = AutoScaleMode.Font;
            BackColor = mauNen;
            Font = new Font("Segoe UI", 10F);
            Name = "Form8";
            Text = "HÓA ĐƠN NHẬP HÀNG";
            StartPosition = FormStartPosition.CenterScreen;
            Dock = DockStyle.Fill;
            AutoScroll = false;

            // ==========================================
            // BỐ CỤC TỔNG
            // ==========================================

            TableLayoutPanel tblMain = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 5,
                BackColor = mauNen,
                Padding = new Padding(8),
                Margin = Padding.Empty
            };

            tblMain.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 100F));

            tblMain.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 80F));

            tblMain.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 320F));

            tblMain.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 280F));

            tblMain.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100F));

            tblMain.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 110F));

            // ==========================================
            // TIÊU ĐỀ
            // ==========================================

            label1.Text = "HÓA ĐƠN NHẬP HÀNG";
            label1.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            label1.ForeColor = mauXanhDam;
            label1.Dock = DockStyle.Fill;
            label1.TextAlign = ContentAlignment.MiddleLeft;
            label1.Margin = new Padding(5, 0, 0, 4);
            label1.Click += label1_Click;

            tblMain.Controls.Add(label1, 0, 0);

            // ==========================================
            // GROUPBOX 1 - THÔNG TIN CHUNG
            // ==========================================

            SetupGroupBox(groupBox1, "THÔNG TIN CHUNG");

            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Margin = new Padding(0, 0, 0, 7);
            groupBox1.Padding = new Padding(8, 12, 8, 5);

            TableLayoutPanel tblThongTin = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 3,
                RowCount = 3,
                BackColor = Color.White,
                Margin = Padding.Empty,
                Padding = Padding.Empty
            };

            for (int i = 0; i < 3; i++)
            {
                tblThongTin.ColumnStyles.Add(
                    new ColumnStyle(SizeType.Percent, 33.33F));

                tblThongTin.RowStyles.Add(
                    new RowStyle(SizeType.Percent, 33.33F));
            }

            // Hàng 1
            tblThongTin.Controls.Add(
                CreateFieldWithSearch(
                    label2, "Mã hóa đơn nhập", cboMaHDN, btnTim),
                0, 0);

            tblThongTin.Controls.Add(
                CreateField(label6, "Ngày nhập", dtpNgayNhap),
                1, 0);

            tblThongTin.Controls.Add(
                CreateField(label3, "Mã nhân viên", txtMaNV),
                2, 0);

            // Hàng 2
            tblThongTin.Controls.Add(
                CreateField(label7, "Tên nhân viên", txtTenNV),
                0, 1);

            tblThongTin.Controls.Add(
                CreateField(label4, "Nhà cung cấp", cboNCC),
                1, 1);

            tblThongTin.Controls.Add(
                CreateField(label5, "SĐT nhà cung cấp", txtSDT),
                2, 1);

            // Hàng 3
            tblThongTin.Controls.Add(
                CreateField(label8, "Mã nhà cung cấp", txtMaNCC),
                0, 2);

            Panel pnlDiaChi = CreateField(
                label9, "Địa chỉ", txtDiaChi);

            tblThongTin.Controls.Add(pnlDiaChi, 1, 2);
            tblThongTin.SetColumnSpan(pnlDiaChi, 2);

            groupBox1.Controls.Add(tblThongTin);

            tblMain.Controls.Add(groupBox1, 0, 1);

            // ==========================================
            // GROUPBOX 2 - CHỌN MẶT HÀNG
            // ==========================================

            SetupGroupBox(groupBox2, "CHỌN MẶT HÀNG");

            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Margin = new Padding(0, 0, 0, 7);
            groupBox2.Padding = new Padding(8, 12, 8, 5);

            TableLayoutPanel tblMatHang = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 4,
                RowCount = 2,
                BackColor = Color.White,
                Margin = Padding.Empty,
                Padding = Padding.Empty
            };

            tblMatHang.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 24F));

            tblMatHang.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 24F));

            tblMatHang.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 24F));

            tblMatHang.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 28F));

            tblMatHang.RowStyles.Add(
                new RowStyle(SizeType.Percent, 50F));

            tblMatHang.RowStyles.Add(
                new RowStyle(SizeType.Percent, 50F));

            // Hàng 1
            tblMatHang.Controls.Add(
                CreateField(label10, "Mã hàng", cboMaHang),
                0, 0);

            tblMatHang.Controls.Add(
                CreateField(label12, "Tên hàng", txtTenHang),
                1, 0);

            tblMatHang.Controls.Add(
                CreateField(label14, "Đơn giá nhập", txtDonGiaNhap),
                2, 0);

            // Hàng 2
            tblMatHang.Controls.Add(
                CreateField(label11, "Số lượng", txtSoLuong),
                0, 1);

            Panel pnlThanhTien = CreateField(
                label13, "Thành tiền", txtThanhTien);

            tblMatHang.Controls.Add(pnlThanhTien, 1, 1);
            tblMatHang.SetColumnSpan(pnlThanhTien, 2);

            // Nút thêm mặt hàng
            button1.Text = "＋  Thêm hàng";
            StyleButton(button1, mauXanhLa, Color.White);
            button1.Dock = DockStyle.None;
            button1.Anchor = AnchorStyles.None;
            button1.Size = new Size(160, 42);
            button1.Margin = new Padding(5);

            tblMatHang.Controls.Add(button1, 3, 0);
            tblMatHang.SetRowSpan(button1, 2);

            groupBox2.Controls.Add(tblMatHang);

            tblMain.Controls.Add(groupBox2, 0, 2);

            // ==========================================
            // GROUPBOX 3 - CHI TIẾT HÓA ĐƠN
            // ==========================================

            SetupGroupBox(groupBox3, "CHI TIẾT HÓA ĐƠN NHẬP");

            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Margin = new Padding(0, 0, 0, 7);
            groupBox3.Padding = new Padding(8, 12, 8, 5);

            TableLayoutPanel tblChiTiet = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2,
                BackColor = Color.White,
                Margin = Padding.Empty,
                Padding = Padding.Empty
            };

            tblChiTiet.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 100F));

            tblChiTiet.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100F));

            tblChiTiet.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 38F));

            // DataGridView
            dgvChiTiet.Dock = DockStyle.Fill;
            dgvChiTiet.BackgroundColor = Color.White;
            dgvChiTiet.BorderStyle = BorderStyle.None;
            dgvChiTiet.GridColor = mauVien;

            dgvChiTiet.EnableHeadersVisualStyles = false;

            dgvChiTiet.ColumnHeadersDefaultCellStyle.BackColor =
                mauXanhDam;

            dgvChiTiet.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvChiTiet.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10F, FontStyle.Bold);

            dgvChiTiet.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvChiTiet.DefaultCellStyle.Font =
                new Font("Segoe UI", 9.5F);

            dgvChiTiet.DefaultCellStyle.ForeColor = mauChu;
            dgvChiTiet.DefaultCellStyle.BackColor = Color.White;

            dgvChiTiet.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(218, 232, 250);

            dgvChiTiet.DefaultCellStyle.SelectionForeColor = mauChu;

            dgvChiTiet.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(244, 248, 253);

            dgvChiTiet.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvChiTiet.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvChiTiet.MultiSelect = false;
            dgvChiTiet.ReadOnly = true;
            dgvChiTiet.AllowUserToAddRows = false;
            dgvChiTiet.AllowUserToDeleteRows = false;
            dgvChiTiet.RowHeadersVisible = false;
            dgvChiTiet.RowTemplate.Height = 32;
            dgvChiTiet.ColumnHeadersHeight = 38;

            dgvChiTiet.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Tổng tiền
            lblTongTien.Text = "Tổng tiền: 0 VNĐ";
            lblTongTien.Font =
                new Font("Segoe UI", 12F, FontStyle.Bold);

            lblTongTien.ForeColor = mauDo;
            lblTongTien.Dock = DockStyle.Fill;
            lblTongTien.TextAlign = ContentAlignment.MiddleRight;
            lblTongTien.Margin = new Padding(0, 0, 8, 0);

            tblChiTiet.Controls.Add(dgvChiTiet, 0, 0);
            tblChiTiet.Controls.Add(lblTongTien, 0, 1);

            groupBox3.Controls.Add(tblChiTiet);

            tblMain.Controls.Add(groupBox3, 0, 3);

            // ==========================================
            // GROUPBOX 4 - CHỨC NĂNG
            // ==========================================

            SetupGroupBox(groupBox4, "CHỨC NĂNG");

            groupBox4.Dock = DockStyle.Fill;
            groupBox4.Margin = Padding.Empty;
            groupBox4.Padding = new Padding(8, 10, 8, 5);

            FlowLayoutPanel flpChucNang = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                AutoScroll = true,
                BackColor = Color.White,
                Padding = new Padding(2, 5, 2, 2),
                Margin = Padding.Empty
            };

            // Thêm hóa đơn
            btnThemHD.Text = "＋  Thêm mới";
            StyleButton(btnThemHD, mauXanh, Color.White);
            btnThemHD.Size = new Size(125, 38);

            // Lưu
            btnLuu.Text = "✓  Lưu hóa đơn";
            StyleButton(btnLuu, mauXanhLa, Color.White);
            btnLuu.Size = new Size(135, 38);

            // Hủy
            btnHuy.Text = "✕  Hủy bỏ";
            StyleButton(btnHuy, mauDo, Color.White);
            btnHuy.Size = new Size(125, 38);

            // In hóa đơn
            btnIn.Text = "▤  In hóa đơn";
            StyleButton(btnIn, mauXam, Color.White);
            btnIn.Size = new Size(140, 38);

            // Thoát
            btnThoat.Text = "←  Thoát";
            StyleButton(
                btnThoat,
                Color.FromArgb(70, 82, 100),
                Color.White);

            btnThoat.Size = new Size(115, 38);

            flpChucNang.Controls.AddRange(new Control[]
            {
                btnThemHD,
                btnLuu,
                btnHuy,
                btnIn,
                btnThoat
            });

            groupBox4.Controls.Add(flpChucNang);

            tblMain.Controls.Add(groupBox4, 0, 4);

            // ==========================================
            // HOÀN TẤT
            // ==========================================

            Controls.Add(tblMain);

            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).EndInit();

            ResumeLayout(false);
        }

        // ==========================================
        // HÀM TẠO FIELD THÔNG THƯỜNG
        // ==========================================

        private Panel CreateField(
            Label lbl,
            string title,
            Control input)
        {
            Panel pnl = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(4, 2, 8, 2),
                Margin = new Padding(2)
            };

            TableLayoutPanel tbl = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2,
                BackColor = Color.White,
                Margin = Padding.Empty,
                Padding = Padding.Empty
            };

            tbl.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 100F));

            tbl.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 30F));

            tbl.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100F));

            lbl.Text = title;
            lbl.Dock = DockStyle.Fill;
            lbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbl.ForeColor = mauChu;
            lbl.TextAlign = ContentAlignment.MiddleLeft;
            lbl.Margin = Padding.Empty;

            StyleInput(input);

            input.Dock = DockStyle.Fill;
            input.Margin = new Padding(0, 8, 0, 1);

            tbl.Controls.Add(lbl, 0, 0);
            tbl.Controls.Add(input, 0, 1);

            pnl.Controls.Add(tbl);

            return pnl;
        }

        // ==========================================
        // FIELD MÃ HÓA ĐƠN CÓ NÚT TÌM
        // ==========================================

        private Panel CreateFieldWithSearch(
            Label lbl,
            string title,
            ComboBox cbo,
            Button btn)
        {
            Panel pnl = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(4, 2, 8, 2),
                Margin = new Padding(2)
            };

            TableLayoutPanel tbl = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2,
                BackColor = Color.White,
                Margin = Padding.Empty,
                Padding = Padding.Empty
            };

            tbl.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 100F));

            tbl.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 30F));

            tbl.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100F));

            lbl.Text = title;
            lbl.Dock = DockStyle.Fill;
            lbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbl.ForeColor = mauChu;
            lbl.TextAlign = ContentAlignment.MiddleLeft;
            lbl.Margin = Padding.Empty;

            TableLayoutPanel tblInput = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1,
                Margin = new Padding(0, 8, 0, 1),
                Padding = Padding.Empty
            };

            tblInput.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 100F));

            tblInput.ColumnStyles.Add(
                new ColumnStyle(SizeType.Absolute, 65F));

            tblInput.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100F));

            StyleInput(cbo);

            cbo.Dock = DockStyle.Fill;
            cbo.Margin = new Padding(0, 0, 4, 0);

            btn.Text = "⌕ Tìm";
            StyleButton(btn, mauXanh, Color.White);
            btn.Dock = DockStyle.Fill;
            btn.Margin = Padding.Empty;
            btn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            tblInput.Controls.Add(cbo, 0, 0);
            tblInput.Controls.Add(btn, 1, 0);

            tbl.Controls.Add(lbl, 0, 0);
            tbl.Controls.Add(tblInput, 0, 1);

            pnl.Controls.Add(tbl);

            return pnl;
        }

        // ==========================================
        // ĐỊNH DẠNG INPUT
        // ==========================================

        private void StyleInput(Control input)
        {
            input.Font = new Font("Segoe UI", 9.5F);
            input.ForeColor = mauChu;

            if (input is TextBox txt)
            {
                txt.BorderStyle = BorderStyle.FixedSingle;
                txt.BackColor = Color.FromArgb(250, 252, 255);
            }
            else if (input is ComboBox cbo)
            {
                cbo.DropDownStyle = ComboBoxStyle.DropDownList;
                cbo.FlatStyle = FlatStyle.Flat;
                cbo.BackColor = Color.White;
            }
            else if (input is DateTimePicker dtp)
            {
                dtp.Format = DateTimePickerFormat.Custom;
                dtp.CustomFormat = "dd/MM/yyyy";
            }
        }

        // ==========================================
        // ĐỊNH DẠNG GROUPBOX
        // ==========================================

        private void SetupGroupBox(GroupBox gb, string title)
        {
            gb.Text = title;
            gb.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            gb.ForeColor = mauXanhDam;
            gb.BackColor = Color.White;
        }

        // ==========================================
        // ĐỊNH DẠNG BUTTON
        // ==========================================

        private void StyleButton(
            Button btn,
            Color backColor,
            Color foreColor)
        {
            btn.BackColor = backColor;
            btn.ForeColor = foreColor;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
            btn.UseVisualStyleBackColor = false;
        }

        // ==========================================
        // KHAI BÁO CONTROL
        // ==========================================

        private Label label1;

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;

        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;

        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;

        private ComboBox cboMaHDN;
        private TextBox txtMaNV;
        private ComboBox cboNCC;
        private TextBox txtSDT;
        private DateTimePicker dtpNgayNhap;
        private TextBox txtTenNV;
        private TextBox txtMaNCC;
        private TextBox txtDiaChi;

        private ComboBox cboMaHang;
        private TextBox txtTenHang;
        private TextBox txtDonGiaNhap;
        private TextBox txtSoLuong;
        private TextBox txtThanhTien;

        private Button btnTim;
        private Button button1;

        private DataGridView dgvChiTiet;
        private Label lblTongTien;

        private Button btnThemHD;
        private Button btnLuu;
        private Button btnHuy;
        private Button btnIn;
        private Button btnThoat;
    }
}
