
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    partial class Form2
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

            // ==============================
            // KHAI BÁO CONTROL
            // ==============================

            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            groupBox4 = new GroupBox();

            txtMaNV = new TextBox();
            txtTenNV = new TextBox();
            txtDiaChi = new TextBox();
            txtMatKhau = new TextBox();
            txtSDT = new TextBox();
            txtTim = new TextBox();

            cboChucVu = new ComboBox();
            cboTrangThai = new ComboBox();

            dtpNgaySinh = new DateTimePicker();

            radNam = new RadioButton();
            radNu = new RadioButton();

            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamLai = new Button();
            btnThoat = new Button();
            btnTim = new Button();

            dgvNhanVien = new DataGridView();

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
            label11 = new Label();

            // ==============================
            // BẢNG MÀU CHUNG
            // ==============================

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

            Name = "Form2";
            Text = "PHONE STORE - Quản lý nhân viên";

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

            root.RowStyles.Add(
                new RowStyle(SizeType.Percent, 100F));

            // ==============================
            // 1. KHU VỰC THÔNG TIN
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
                new ColumnStyle(SizeType.Percent, 72F));

            top.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 28F));

            // ==============================
            // GROUPBOX THÔNG TIN NHÂN VIÊN
            // ==============================

            groupBox1.Text = "THÔNG TIN NHÂN VIÊN";
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Margin = new Padding(0, 0, 10, 0);

            StyleGroup(groupBox1, navy, boldFont);

            TableLayoutPanel fields = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 4,
                RowCount = 5,
                Padding = new Padding(12, 10, 12, 10),
                BackColor = Color.White
            };

            fields.ColumnStyles.Add(
                new ColumnStyle(SizeType.Absolute, 105F));

            fields.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 50F));

            fields.ColumnStyles.Add(
                new ColumnStyle(SizeType.Absolute, 105F));

            fields.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 50F));

            for (int i = 0; i < 5; i++)
            {
                fields.RowStyles.Add(
                    new RowStyle(SizeType.Percent, 20F));
            }

            // ==============================
            // LABEL
            // ==============================

            SetLabel(label1, "Mã nhân viên");
            SetLabel(label2, "Ngày sinh");
            SetLabel(label3, "Địa chỉ");
            SetLabel(label4, "Số điện thoại");
            SetLabel(label5, "Mật khẩu");
            SetLabel(label6, "Họ tên");
            SetLabel(label7, "Giới tính");
            SetLabel(label8, "Chức vụ");
            SetLabel(label11, "Trạng thái");

            // ==============================
            // TEXTBOX
            // ==============================

            StyleText(txtMaNV);
            StyleText(txtTenNV);
            StyleText(txtDiaChi);
            StyleText(txtMatKhau);
            StyleText(txtSDT);

            // ==============================
            // COMBOBOX
            // ==============================

            StyleCombo(cboChucVu);
            StyleCombo(cboTrangThai);

            // ==============================
            // DATE TIME PICKER
            // ==============================

            dtpNgaySinh.Dock = DockStyle.Fill;
            dtpNgaySinh.Font = normalFont;
            dtpNgaySinh.Format = DateTimePickerFormat.Short;
            dtpNgaySinh.Margin = new Padding(5, 5, 8, 5);

            // ==============================
            // GIỚI TÍNH
            // ==============================

            FlowLayoutPanel genderPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                BackColor = Color.White,
                Padding = new Padding(5, 5, 0, 0)
            };

            radNam.Text = "Nam";
            radNu.Text = "Nữ";

            radNam.AutoSize = true;
            radNu.AutoSize = true;

            radNam.Font = normalFont;
            radNu.Font = normalFont;

            radNam.ForeColor = textColor;
            radNu.ForeColor = textColor;

            radNam.Margin = new Padding(3, 3, 20, 3);
            radNu.Margin = new Padding(3);

            genderPanel.Controls.Add(radNam);
            genderPanel.Controls.Add(radNu);

            // ==============================
            // ĐƯA THÔNG TIN VÀO BẢNG
            // ==============================

            AddField(fields, label1, txtMaNV, 0, 0);
            AddField(fields, label6, txtTenNV, 2, 0);

            AddField(fields, label2, dtpNgaySinh, 0, 1);
            AddField(fields, label7, genderPanel, 2, 1);

            AddField(fields, label4, txtSDT, 0, 2);
            AddField(fields, label8, cboChucVu, 2, 2);

            fields.Controls.Add(label3, 0, 3);
            fields.Controls.Add(txtDiaChi, 1, 3);
            fields.SetColumnSpan(txtDiaChi, 3);

            AddField(fields, label5, txtMatKhau, 0, 4);
            AddField(fields, label11, cboTrangThai, 2, 4);

            groupBox1.Controls.Add(fields);

            // ==============================
            // 2. GROUPBOX LƯU Ý
            // ==============================

            groupBox2.Text = "LƯU Ý";
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Margin = new Padding(0);

            StyleGroup(groupBox2, navy, boldFont);

            Panel notePanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(15)
            };

            label9.AutoSize = false;
            label9.Dock = DockStyle.Top;
            label9.Height = 100;

            label9.Text =
                "TÀI KHOẢN ĐĂNG NHẬP\n\n" +
                "Tên đăng nhập: Mã nhân viên\n\n" +
                "Mật khẩu: Mật khẩu nhân viên";

            label9.Font = normalFont;
            label9.ForeColor = textColor;
            label9.TextAlign = ContentAlignment.TopLeft;

            notePanel.Controls.Add(label9);
            groupBox2.Controls.Add(notePanel);

            top.Controls.Add(groupBox1, 0, 0);
            top.Controls.Add(groupBox2, 1, 0);

            // ==============================
            // 3. CHỨC NĂNG
            // ==============================

            groupBox3.Text = "CHỨC NĂNG";
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Margin = new Padding(0, 8, 0, 5);

            StyleGroup(groupBox3, navy, boldFont);

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
            StyleButton(btnLamLai, muted);
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
                b.Size = new Size(130, 42);
                b.Margin = new Padding(8, 5, 12, 5);

                actions.Controls.Add(b);
            }

            groupBox3.Controls.Add(actions);

            // ==============================
            // 4. TÌM KIẾM NHÂN VIÊN
            // ==============================

            groupBox4.Text = "TÌM KIẾM NHÂN VIÊN";
            groupBox4.Dock = DockStyle.Fill;
            groupBox4.Margin = new Padding(0, 5, 0, 0);

            StyleGroup(groupBox4, navy, boldFont);

            TableLayoutPanel searchLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 3,
                RowCount = 1,
                Padding = new Padding(12, 8, 12, 8),
                BackColor = Color.White
            };

            searchLayout.ColumnStyles.Add(
                new ColumnStyle(SizeType.Absolute, 170F));

            searchLayout.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 100F));

            searchLayout.ColumnStyles.Add(
                new ColumnStyle(SizeType.Absolute, 125F));

            label10.Text = "Tên hoặc mã nhân viên";
            label10.Dock = DockStyle.Fill;
            label10.TextAlign = ContentAlignment.MiddleLeft;
            label10.Font = normalFont;
            label10.ForeColor = textColor;

            StyleText(txtTim);
            txtTim.Dock = DockStyle.Fill;

            btnTim.Text = "TÌM KIẾM";
            btnTim.Dock = DockStyle.Fill;

            StyleButton(btnTim, blue);

            searchLayout.Controls.Add(label10, 0, 0);
            searchLayout.Controls.Add(txtTim, 1, 0);
            searchLayout.Controls.Add(btnTim, 2, 0);

            groupBox4.Controls.Add(searchLayout);

            // ==============================
            // 5. DANH SÁCH NHÂN VIÊN
            // ==============================

            dgvNhanVien.Dock = DockStyle.Fill;

            dgvNhanVien.BackgroundColor = Color.White;
            dgvNhanVien.BorderStyle = BorderStyle.None;

            dgvNhanVien.EnableHeadersVisualStyles = false;

            dgvNhanVien.ColumnHeadersDefaultCellStyle.BackColor = navy;
            dgvNhanVien.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgvNhanVien.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 9.5F, FontStyle.Bold);

            dgvNhanVien.DefaultCellStyle.Font = normalFont;
            dgvNhanVien.DefaultCellStyle.ForeColor = textColor;

            dgvNhanVien.DefaultCellStyle.BackColor = Color.White;

            dgvNhanVien.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(220, 235, 252);

            dgvNhanVien.DefaultCellStyle.SelectionForeColor = navy;

            dgvNhanVien.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(245, 248, 252);

            dgvNhanVien.ColumnHeadersHeight = 42;
            dgvNhanVien.RowTemplate.Height = 36;

            dgvNhanVien.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvNhanVien.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvNhanVien.MultiSelect = false;
            dgvNhanVien.ReadOnly = true;

            dgvNhanVien.AllowUserToAddRows = false;
            dgvNhanVien.RowHeadersVisible = false;

            dgvNhanVien.GridColor = border;

            dgvNhanVien.Margin = new Padding(0, 5, 0, 0);

            // ==============================
            // GHÉP TOÀN BỘ GIAO DIỆN
            // ==============================

            root.Controls.Add(top, 0, 0);
            root.Controls.Add(groupBox3, 0, 1);
            root.Controls.Add(groupBox4, 0, 2);
            root.Controls.Add(dgvNhanVien, 0, 3);

            Controls.Add(root);

            ResumeLayout(false);
        }

        // ==================================
        // HÀM HỖ TRỢ GIAO DIỆN
        // ==================================

        private void StyleGroup(
            GroupBox group,
            Color titleColor,
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

            label.Font =
                new Font("Segoe UI", 9F, FontStyle.Bold);

            label.ForeColor =
                Color.FromArgb(35, 51, 72);

            label.Margin = new Padding(3);
        }

        private void StyleText(TextBox txt)
        {
            txt.Font = new Font("Segoe UI", 10F);

            txt.BackColor =
                Color.FromArgb(248, 250, 253);

            txt.ForeColor =
                Color.FromArgb(35, 51, 72);

            txt.BorderStyle = BorderStyle.FixedSingle;

            txt.Dock = DockStyle.Fill;

            txt.Margin = new Padding(5, 5, 8, 5);
        }

        private void StyleCombo(ComboBox cbo)
        {
            cbo.Font = new Font("Segoe UI", 9.5F);

            cbo.BackColor =
                Color.FromArgb(248, 250, 253);

            cbo.ForeColor =
                Color.FromArgb(35, 51, 72);

            cbo.Dock = DockStyle.Fill;

            cbo.Margin = new Padding(5, 5, 8, 5);
        }

        private void StyleButton(Button btn, Color color)
        {
            btn.BackColor = color;
            btn.ForeColor = Color.White;

            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;

            btn.Font =
                new Font("Segoe UI", 9F, FontStyle.Bold);

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
        // KHAI BÁO CONTROL
        // ==================================

        private TextBox txtTim;
        private Label label10;

        private Button btnThoat;
        private Button btnLamLai;
        private Button btnXoa;
        private Button btnSua;
        private Button btnThem;
        private Button btnTim;

        private TextBox txtTenNV;
        private TextBox txtMatKhau;
        private TextBox txtMaNV;
        private TextBox txtDiaChi;
        private TextBox txtSDT;

        private Label label8;
        private Label label7;
        private Label label4;
        private Label label5;
        private Label label3;
        private Label label2;
        private Label label6;
        private Label label1;
        private Label label9;
        private Label label11;

        private GroupBox groupBox4;
        private GroupBox groupBox3;
        private GroupBox groupBox2;
        private GroupBox groupBox1;

        private RadioButton radNu;
        private RadioButton radNam;

        private DateTimePicker dtpNgaySinh;
        private ComboBox cboChucVu;
        private ComboBox cboTrangThai;

        private DataGridView dgvNhanVien;

        // Giữ lại các khai báo cũ để tương thích
        private ListBox listBox4;
        private ListBox listBox1;
    }
}
