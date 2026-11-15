
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            // Controls
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            groupBox4 = new GroupBox();

            txtMaHang = new TextBox();
            txtTenHang = new TextBox();
            txtGiaNhap = new TextBox();
            txtGiaBan = new TextBox();
            txtSoLuong = new TextBox();
            txtTim = new TextBox();

            cboHang = new ComboBox();
            cboLoai = new ComboBox();
            cboMau = new ComboBox();
            cboDungLuong = new ComboBox();

            picAnh = new PictureBox();
            lblTenAnh = new Label();

            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamLai = new Button();
            btnThoat = new Button();
            btnChonAnh = new Button();
            btnTim = new Button();

            dgvHang = new DataGridView();

            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();

            // Colors
            Color navy = Color.FromArgb(20, 43, 74);
            Color blue = Color.FromArgb(36, 120, 212);
            Color background = Color.FromArgb(244, 247, 251);
            Color textColor = Color.FromArgb(35, 51, 72);
            Color muted = Color.FromArgb(112, 128, 150);
            Color border = Color.FromArgb(220, 228, 238);

            Font normalFont = new Font("Segoe UI", 9.5F);
            Font boldFont = new Font("Segoe UI", 10F, FontStyle.Bold);

            SuspendLayout();

            // ==============================
            // FORM
            // ==============================

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;

            BackColor = background;
            Font = normalFont;

            ClientSize = new Size(1100, 760);
            MinimumSize = new Size(850, 600);

            Name = "Form1";
            Text = "PHONE STORE - Quản lý điện thoại";

            // ==============================
            // BỐ CỤC TỔNG
            // ==============================

            TableLayoutPanel root = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 4,
                Padding = new Padding(16),
                BackColor = background,
                Margin = Padding.Empty
            };

            root.RowStyles.Add(
         new RowStyle(SizeType.Absolute, 310F)); // Thông tin điện thoại

            root.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 105F)); // Chức năng

            root.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 105F)); // Tìm kiếm

            root.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100F)); // Danh sách

            // ==============================
            // 1. THÔNG TIN SẢN PHẨM
            // ==============================

            TableLayoutPanel top = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1,
                BackColor = background,
                Margin = Padding.Empty
            };

            top.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 68F));

            top.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 32F));

            groupBox1.Text = "THÔNG TIN ĐIỆN THOẠI";
            StyleGroup(groupBox1, navy, border, boldFont);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Margin = new Padding(0, 0, 10, 0);

            TableLayoutPanel fields = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 4,
                RowCount = 5,
                Padding = new Padding(12, 10, 12, 10),
                BackColor = Color.White
            };

            fields.ColumnStyles.Add(
                new ColumnStyle(SizeType.Absolute, 100F));

            fields.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 50F));

            fields.ColumnStyles.Add(
                new ColumnStyle(SizeType.Absolute, 100F));

            fields.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 50F));

            for (int i = 0; i < 5; i++)
            {
                fields.RowStyles.Add(
                    new RowStyle(SizeType.Percent, 20F));
            }

            // Labels
            SetLabel(label1, "Mã hàng");
            SetLabel(label6, "Tên hàng");
            SetLabel(label2, "Hãng SX");
            SetLabel(label7, "Loại");
            SetLabel(label4, "Màu sắc");
            SetLabel(label8, "Dung lượng");
            SetLabel(label3, "Giá nhập");
            SetLabel(label9, "Giá bán");
            SetLabel(label5, "Số lượng tồn");

            // Inputs
            StyleText(txtMaHang);
            StyleText(txtTenHang);
            StyleText(txtGiaNhap);
            StyleText(txtGiaBan);
            StyleText(txtSoLuong);

            StyleCombo(cboHang);
            StyleCombo(cboLoai);
            StyleCombo(cboMau);
            StyleCombo(cboDungLuong);

            AddField(fields, label1, txtMaHang, 0, 0);
            AddField(fields, label6, txtTenHang, 2, 0);

            AddField(fields, label2, cboHang, 0, 1);
            AddField(fields, label7, cboLoai, 2, 1);

            AddField(fields, label4, cboMau, 0, 2);
            AddField(fields, label8, cboDungLuong, 2, 2);

            AddField(fields, label3, txtGiaNhap, 0, 3);
            AddField(fields, label9, txtGiaBan, 2, 3);

            fields.Controls.Add(label5, 0, 4);
            fields.Controls.Add(txtSoLuong, 1, 4);

            groupBox1.Controls.Add(fields);

            // ==============================
            // 2. ẢNH SẢN PHẨM
            // ==============================

            groupBox2.Text = "ẢNH ĐẠI DIỆN";
            StyleGroup(groupBox2, navy, border, boldFont);

            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Margin = new Padding(0);

            TableLayoutPanel imageLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 3,
                Padding = new Padding(12),
                BackColor = Color.White
            };

            imageLayout.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100F));

            imageLayout.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 42F));

            imageLayout.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 25F));

            picAnh.Dock = DockStyle.Fill;
            picAnh.BackColor = background;
            picAnh.SizeMode = PictureBoxSizeMode.Zoom;
            picAnh.Margin = new Padding(0, 0, 0, 8);

            btnChonAnh.Text = "CHỌN ẢNH";
            btnChonAnh.Dock = DockStyle.Fill;
            StyleButton(btnChonAnh, blue);

            lblTenAnh.Text = "Chưa chọn ảnh";
            lblTenAnh.Dock = DockStyle.Fill;
            lblTenAnh.TextAlign = ContentAlignment.MiddleCenter;
            lblTenAnh.ForeColor = muted;
            lblTenAnh.AutoEllipsis = true;
            lblTenAnh.Font = normalFont;

            imageLayout.Controls.Add(picAnh, 0, 0);
            imageLayout.Controls.Add(btnChonAnh, 0, 1);
            imageLayout.Controls.Add(lblTenAnh, 0, 2);

            groupBox2.Controls.Add(imageLayout);

            top.Controls.Add(groupBox1, 0, 0);
            top.Controls.Add(groupBox2, 1, 0);

            // ==============================
            // 3. NÚT CHỨC NĂNG
            // ==============================

            groupBox3.Text = "CHỨC NĂNG";
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Margin = new Padding(0, 6, 0, 5);
            StyleGroup(groupBox3, navy, border, boldFont);

            FlowLayoutPanel actions = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                Padding = new Padding(10, 5, 10, 2),
                BackColor = Color.White
            };

            StyleButton(btnThem, blue);
            StyleButton(btnSua, blue);
            StyleButton(btnXoa, Color.FromArgb(210, 70, 70));
            StyleButton(btnLamLai, Color.FromArgb(112, 128, 150));
            StyleButton(btnThoat, navy);

            btnThem.Text = "+ THÊM";
            btnSua.Text = "SỬA";
            btnXoa.Text = "XÓA";
            btnLamLai.Text = "LÀM LẠI";
            btnThoat.Text = "THOÁT";

            foreach (Button b in new[]
            {
                btnThem, btnSua, btnXoa, btnLamLai, btnThoat
            })
            {
                b.Size = new Size(130, 45);
                b.Margin = new Padding(8, 5, 12, 5);
                actions.Controls.Add(b);
            }

            groupBox3.Controls.Add(actions);

            // ==============================
            // 4. TÌM KIẾM
            // ==============================

            groupBox4.Text = "TÌM KIẾM MẶT HÀNG";
            groupBox4.Dock = DockStyle.Fill;
            groupBox4.Margin = new Padding(0, 6, 0, 0);
            StyleGroup(groupBox4, navy, border, boldFont);

            TableLayoutPanel searchLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 3,
                RowCount = 1,
                Padding = new Padding(10, 4, 10, 4),
                BackColor = Color.White
            };

            searchLayout.ColumnStyles.Add(
                new ColumnStyle(SizeType.Absolute, 170F));

            searchLayout.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 100F));

            searchLayout.ColumnStyles.Add(
                new ColumnStyle(SizeType.Absolute, 115F));

            label10.Text = "Tên hoặc mã hàng";
            label10.Dock = DockStyle.Fill;
            label10.TextAlign = ContentAlignment.MiddleLeft;
            label10.Font = normalFont;
            label10.ForeColor = textColor;

            StyleText(txtTim);
            txtTim.Dock = DockStyle.Fill;
            txtTim.Margin = new Padding(5, 3, 10, 3);

            btnTim.Text = "TÌM KIẾM";
            btnTim.Dock = DockStyle.Fill;
            StyleButton(btnTim, blue);

            searchLayout.Controls.Add(label10, 0, 0);
            searchLayout.Controls.Add(txtTim, 1, 0);
            searchLayout.Controls.Add(btnTim, 2, 0);

            groupBox4.Controls.Add(searchLayout);

            // ==============================
            // 5. BẢNG DANH SÁCH
            // ==============================

            dgvHang.Dock = DockStyle.Fill;
            dgvHang.BackgroundColor = Color.White;
            dgvHang.BorderStyle = BorderStyle.None;

            dgvHang.EnableHeadersVisualStyles = false;

            dgvHang.ColumnHeadersDefaultCellStyle.BackColor = navy;
            dgvHang.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvHang.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 9.5F, FontStyle.Bold);

            dgvHang.DefaultCellStyle.Font = normalFont;
            dgvHang.DefaultCellStyle.ForeColor = textColor;
            dgvHang.DefaultCellStyle.BackColor = Color.White;
            dgvHang.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(220, 235, 252);

            dgvHang.DefaultCellStyle.SelectionForeColor = navy;

            dgvHang.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(245, 248, 252);

            dgvHang.ColumnHeadersHeight = 42;
            dgvHang.RowTemplate.Height = 36;

            dgvHang.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvHang.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvHang.MultiSelect = false;
            dgvHang.ReadOnly = true;
            dgvHang.AllowUserToAddRows = false;
            dgvHang.RowHeadersVisible = false;

            dgvHang.GridColor = border;
            dgvHang.Margin = new Padding(0, 5, 0, 0);

            // ==============================
            // GHÉP GIAO DIỆN
            // ==============================

            root.Controls.Add(top, 0, 0);
            root.Controls.Add(groupBox3, 0, 1);
            root.Controls.Add(groupBox4, 0, 2);
            root.Controls.Add(dgvHang, 0, 3);

            Controls.Add(root);

            ResumeLayout(false);
        }

        // ==================================
        // CÁC HÀM HỖ TRỢ THIẾT KẾ
        // ==================================

        private void StyleGroup(
            GroupBox group,
            Color titleColor,
            Color lineColor,
            Font font)
        {
            group.BackColor = Color.White;
            group.ForeColor = titleColor;
            group.Font = font;
            group.Padding = new Padding(10);
        }

        private void SetLabel(Label label, string text)
        {
            label.Text = text;
            label.Dock = DockStyle.Fill;
            label.TextAlign = ContentAlignment.MiddleLeft;
            label.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label.ForeColor = Color.FromArgb(35, 51, 72);
            label.Margin = new Padding(3);
        }

        private void StyleText(TextBox txt)
        {
            txt.Font = new Font("Segoe UI", 10F);
            txt.BackColor = Color.FromArgb(248, 250, 253);
            txt.ForeColor = Color.FromArgb(35, 51, 72);
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.Dock = DockStyle.Fill;
            txt.Margin = new Padding(5, 5, 8, 5);
        }

        private void StyleCombo(ComboBox cbo)
        {
            cbo.Font = new Font("Segoe UI", 9.5F);
            cbo.BackColor = Color.FromArgb(248, 250, 253);
            cbo.ForeColor = Color.FromArgb(35, 51, 72);
            cbo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo.Dock = DockStyle.Fill;
            cbo.Margin = new Padding(5, 5, 8, 5);
        }

        private void StyleButton(Button btn, Color color)
        {
            btn.BackColor = color;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
            btn.UseVisualStyleBackColor = false;
        }

        private void AddField(
            TableLayoutPanel table,
            Control label,
            Control input,
            int column,
            int row)
        {
            table.Controls.Add(label, column, row);
            table.Controls.Add(input, column + 1, row);
        }

        // ==================================
        // KHAI BÁO CONTROLS
        // ==================================

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;

        private TextBox txtGiaNhap;
        private TextBox txtMaHang;
        private TextBox txtGiaBan;
        private TextBox txtTenHang;
        private TextBox txtSoLuong;
        private TextBox txtTim;

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;

        private PictureBox picAnh;
        private Button btnChonAnh;
        private Button btnThoat;
        private Button btnLamLai;
        private Button btnXoa;
        private Button btnSua;
        private Button btnThem;
        private Button btnTim;

        private ComboBox cboMau;
        private ComboBox cboHang;
        private ComboBox cboLoai;
        private ComboBox cboDungLuong;

        private Label lblTenAnh;
        private DataGridView dgvHang;
    }
}
