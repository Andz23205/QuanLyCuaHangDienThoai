
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    partial class Form11
    {
        private System.ComponentModel.IContainer components = null;

        private Panel panelHeader;
        private Panel panelContent;
        private GroupBox groupBox1;

        private Label label1;
        private Label labelSubtitle;

        private Label labelHoTen;
        private Label labelSDT;
        private Label labelEmail;
        private Label labelTaiKhoan;
        private Label labelMatKhau;
        private Label labelXacNhan;
        private Label labelRole;

        private TextBox txtHoTen;
        private TextBox txtSoDienThoai;
        private TextBox txtEmail;
        private TextBox txtTaiKhoan;
        private TextBox txtMatKhau;
        private TextBox txtXacNhanMatKhau;

        private ComboBox cboRole;

        private Button btnDangKy;
        private Button btnQuayLai;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelHeader = new Panel();
            panelContent = new Panel();
            groupBox1 = new GroupBox();

            label1 = new Label();
            labelSubtitle = new Label();

            labelHoTen = new Label();
            labelSDT = new Label();
            labelEmail = new Label();
            labelTaiKhoan = new Label();
            labelMatKhau = new Label();
            labelXacNhan = new Label();
            labelRole = new Label();

            txtHoTen = new TextBox();
            txtSoDienThoai = new TextBox();
            txtEmail = new TextBox();
            txtTaiKhoan = new TextBox();
            txtMatKhau = new TextBox();
            txtXacNhanMatKhau = new TextBox();

            cboRole = new ComboBox();

            btnDangKy = new Button();
            btnQuayLai = new Button();

            panelHeader.SuspendLayout();
            panelContent.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();

            // ==============================
            // FORM 11
            // ==============================

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;

            BackColor = Color.FromArgb(241, 246, 252);

            ClientSize = new Size(1000, 780);
            MinimumSize = new Size(900, 720);

            StartPosition = FormStartPosition.CenterScreen;

            Name = "Form11";
            Text = "PHONE STORE - Đăng ký tài khoản";

            Font = new Font("Segoe UI", 10F);

            // ==============================
            // HEADER
            // ==============================

            panelHeader.BackColor =
                Color.FromArgb(11, 46, 77);

            panelHeader.Dock = DockStyle.Top;
            panelHeader.Height = 85;

            label1.AutoSize = false;

            label1.Text =
                "HỆ THỐNG QUẢN LÝ CỬA HÀNG | PHONE STORE";

            label1.Font =
                new Font("Segoe UI", 17F, FontStyle.Bold);

            label1.ForeColor = Color.White;
            label1.Dock = DockStyle.Fill;

            label1.TextAlign =
                ContentAlignment.MiddleCenter;

            panelHeader.Controls.Add(label1);

            // ==============================
            // CONTENT
            // ==============================

            panelContent.Dock = DockStyle.Fill;

            panelContent.BackColor =
                Color.FromArgb(241, 246, 252);

            panelContent.Resize += panelContent_Resize;

            // ==============================
            // GROUP BOX
            // ==============================

            groupBox1.BackColor = Color.White;

            groupBox1.ForeColor =
                Color.FromArgb(11, 46, 77);

            groupBox1.Font =
                new Font("Segoe UI", 11F, FontStyle.Bold);

            groupBox1.Text = "ĐĂNG KÝ TÀI KHOẢN MỚI";

            groupBox1.Size = new Size(760, 625);

            groupBox1.TabStop = false;
            groupBox1.Padding = new Padding(20);

            // ==============================
            // SUBTITLE
            // ==============================

            labelSubtitle.AutoSize = false;

            labelSubtitle.Location = new Point(45, 65);
            labelSubtitle.Size = new Size(660, 30);

            labelSubtitle.Text =
                "Vui lòng điền đầy đủ thông tin để tạo tài khoản mới";

            labelSubtitle.Font =
                new Font("Segoe UI", 10F);

            labelSubtitle.ForeColor =
                Color.FromArgb(110, 125, 145);

            // ==============================
            // LABEL STYLE
            // ==============================

            Font labelFont =
                new Font("Segoe UI", 10F, FontStyle.Bold);

            Color labelColor =
                Color.FromArgb(45, 65, 85);

            // ==============================
            // HỌ VÀ TÊN
            // ==============================

            labelHoTen.Text = "HỌ VÀ TÊN";
            labelHoTen.Location = new Point(48, 120);
            labelHoTen.AutoSize = true;
            labelHoTen.Font = labelFont;
            labelHoTen.ForeColor = labelColor;

            txtHoTen.Location = new Point(50, 150);
            txtHoTen.Size = new Size(310, 35);
            txtHoTen.Font = new Font("Segoe UI", 11F);
            txtHoTen.BorderStyle = BorderStyle.FixedSingle;
            txtHoTen.BackColor = Color.FromArgb(248, 250, 253);

            // ==============================
            // SỐ ĐIỆN THOẠI
            // ==============================

            labelSDT.Text = "SỐ ĐIỆN THOẠI";
            labelSDT.Location = new Point(395, 120);
            labelSDT.AutoSize = true;
            labelSDT.Font = labelFont;
            labelSDT.ForeColor = labelColor;

            txtSoDienThoai.Location = new Point(397, 150);
            txtSoDienThoai.Size = new Size(310, 35);
            txtSoDienThoai.Font = new Font("Segoe UI", 11F);
            txtSoDienThoai.BorderStyle = BorderStyle.FixedSingle;
            txtSoDienThoai.BackColor = Color.FromArgb(248, 250, 253);

            // ==============================
            // EMAIL
            // ==============================

            labelEmail.Text = "EMAIL";
            labelEmail.Location = new Point(48, 215);
            labelEmail.AutoSize = true;
            labelEmail.Font = labelFont;
            labelEmail.ForeColor = labelColor;

            txtEmail.Location = new Point(50, 245);
            txtEmail.Size = new Size(310, 35);
            txtEmail.Font = new Font("Segoe UI", 11F);
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.BackColor = Color.FromArgb(248, 250, 253);

            // ==============================
            // TÊN TÀI KHOẢN
            // ==============================

            labelTaiKhoan.Text = "TÊN TÀI KHOẢN";
            labelTaiKhoan.Location = new Point(395, 215);
            labelTaiKhoan.AutoSize = true;
            labelTaiKhoan.Font = labelFont;
            labelTaiKhoan.ForeColor = labelColor;

            txtTaiKhoan.Location = new Point(397, 245);
            txtTaiKhoan.Size = new Size(310, 35);
            txtTaiKhoan.Font = new Font("Segoe UI", 11F);
            txtTaiKhoan.BorderStyle = BorderStyle.FixedSingle;
            txtTaiKhoan.BackColor = Color.FromArgb(248, 250, 253);

            // ==============================
            // MẬT KHẨU
            // ==============================

            labelMatKhau.Text = "MẬT KHẨU";
            labelMatKhau.Location = new Point(48, 310);
            labelMatKhau.AutoSize = true;
            labelMatKhau.Font = labelFont;
            labelMatKhau.ForeColor = labelColor;

            txtMatKhau.Location = new Point(50, 340);
            txtMatKhau.Size = new Size(310, 35);
            txtMatKhau.Font = new Font("Segoe UI", 11F);
            txtMatKhau.BorderStyle = BorderStyle.FixedSingle;
            txtMatKhau.BackColor = Color.FromArgb(248, 250, 253);

            // ==============================
            // XÁC NHẬN MẬT KHẨU
            // ==============================

            labelXacNhan.Text = "XÁC NHẬN MẬT KHẨU";
            labelXacNhan.Location = new Point(395, 310);
            labelXacNhan.AutoSize = true;
            labelXacNhan.Font = labelFont;
            labelXacNhan.ForeColor = labelColor;

            txtXacNhanMatKhau.Location = new Point(397, 340);
            txtXacNhanMatKhau.Size = new Size(310, 35);
            txtXacNhanMatKhau.Font = new Font("Segoe UI", 11F);
            txtXacNhanMatKhau.BorderStyle = BorderStyle.FixedSingle;
            txtXacNhanMatKhau.BackColor = Color.FromArgb(248, 250, 253);

            // ==============================
            // CHỌN ROLE
            // ==============================

            labelRole.Text = "CHỌN ROLE ĐĂNG KÝ";
            labelRole.Location = new Point(48, 405);
            labelRole.AutoSize = true;
            labelRole.Font = labelFont;
            labelRole.ForeColor = labelColor;

            cboRole.Location = new Point(50, 435);
            cboRole.Size = new Size(657, 35);
            cboRole.Font = new Font("Segoe UI", 11F);

            cboRole.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cboRole.BackColor = Color.FromArgb(248, 250, 253);

            cboRole.Items.AddRange(new object[]
            {
                "Quản lý",
                "Nhân viên",
                "Khách hàng"
            });

            cboRole.SelectedIndex = 2;

            // ==============================
            // BUTTON ĐĂNG KÝ
            // ==============================

            btnDangKy.Location = new Point(50, 520);
            btnDangKy.Size = new Size(310, 48);

            btnDangKy.Text = "ĐĂNG KÝ";
            btnDangKy.Font =
                new Font("Segoe UI", 11F, FontStyle.Bold);

            btnDangKy.ForeColor = Color.White;

            btnDangKy.BackColor =
                Color.FromArgb(8, 120, 209);

            btnDangKy.FlatStyle = FlatStyle.Flat;
            btnDangKy.FlatAppearance.BorderSize = 0;

            btnDangKy.Cursor = Cursors.Hand;
            btnDangKy.UseVisualStyleBackColor = false;

            // ==============================
            // BUTTON QUAY LẠI
            // ==============================

            btnQuayLai.Location = new Point(397, 520);
            btnQuayLai.Size = new Size(310, 48);

            btnQuayLai.Text = "QUAY LẠI";
            btnQuayLai.Font =
                new Font("Segoe UI", 11F, FontStyle.Bold);

            btnQuayLai.ForeColor =
                Color.FromArgb(60, 75, 90);

            btnQuayLai.BackColor =
                Color.FromArgb(231, 237, 245);

            btnQuayLai.FlatStyle = FlatStyle.Flat;
            btnQuayLai.FlatAppearance.BorderSize = 0;

            btnQuayLai.Cursor = Cursors.Hand;
            btnQuayLai.UseVisualStyleBackColor = false;

            // ==============================
            // ADD CONTROLS
            // ==============================

            groupBox1.Controls.Add(labelSubtitle);

            groupBox1.Controls.Add(labelHoTen);
            groupBox1.Controls.Add(txtHoTen);

            groupBox1.Controls.Add(labelSDT);
            groupBox1.Controls.Add(txtSoDienThoai);

            groupBox1.Controls.Add(labelEmail);
            groupBox1.Controls.Add(txtEmail);

            groupBox1.Controls.Add(labelTaiKhoan);
            groupBox1.Controls.Add(txtTaiKhoan);

            groupBox1.Controls.Add(labelMatKhau);
            groupBox1.Controls.Add(txtMatKhau);

            groupBox1.Controls.Add(labelXacNhan);
            groupBox1.Controls.Add(txtXacNhanMatKhau);

            groupBox1.Controls.Add(labelRole);
            groupBox1.Controls.Add(cboRole);

            groupBox1.Controls.Add(btnDangKy);
            groupBox1.Controls.Add(btnQuayLai);

            panelContent.Controls.Add(groupBox1);

            // ==============================
            // FORM CONTROLS
            // ==============================

            Controls.Add(panelContent);
            Controls.Add(panelHeader);

            panelHeader.ResumeLayout(false);
            panelContent.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();

            ResumeLayout(false);
        }

        // ==============================
        // CĂN GIỮA GROUPBOX
        // ==============================

        private void panelContent_Resize(object sender, EventArgs e)
        {
            groupBox1.Location = new Point(
                (panelContent.ClientSize.Width - groupBox1.Width) / 2,
                (panelContent.ClientSize.Height - groupBox1.Height) / 2
            );
        }
    }
}
