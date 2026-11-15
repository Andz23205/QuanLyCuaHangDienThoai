
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    partial class Form9
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private Panel panelHeader;
        private Panel panelContent;
        private Label label4;

        private void InitializeComponent()
        {
            panelHeader = new Panel();
            label1 = new Label();

            panelContent = new Panel();
            groupBox1 = new GroupBox();

            label4 = new Label();
            label2 = new Label();
            label3 = new Label();

            txtMaNhanVien = new TextBox();
            txtMatKhau = new TextBox();

            button1 = new Button();
            button2 = new Button();

            panelHeader.SuspendLayout();
            panelContent.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();

            // ==============================
            // FORM 9
            // ==============================

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;

            BackColor = Color.FromArgb(241, 246, 252);

            ClientSize = new Size(1000, 680);

            MinimumSize = new Size(850, 620);

            StartPosition = FormStartPosition.CenterScreen;

            Name = "Form9";
            Text = "PHONE STORE - Đăng nhập";

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
            // LOGIN CARD
            // ==============================

            groupBox1.BackColor = Color.White;

            groupBox1.ForeColor =
                Color.FromArgb(11, 46, 77);

            groupBox1.Font =
                new Font("Segoe UI", 11F, FontStyle.Bold);

            groupBox1.Text = "ĐĂNG NHẬP HỆ THỐNG";

            groupBox1.Size = new Size(580, 420);

            groupBox1.TabStop = false;

            groupBox1.Padding = new Padding(20);

            // ==============================
            // SUBTITLE
            // ==============================

            label4.AutoSize = false;

            label4.Location = new Point(35, 65);

            label4.Size = new Size(500, 35);

            label4.Text =
                "Vui lòng nhập thông tin tài khoản của bạn";

            label4.Font =
                new Font("Segoe UI", 10F);

            label4.ForeColor =
                Color.FromArgb(110, 125, 145);

            // ==============================
            // LABEL MÃ NHÂN VIÊN
            // ==============================

            label2.AutoSize = true;

            label2.Location = new Point(38, 125);

            label2.Text = "MÃ NHÂN VIÊN";

            label2.Font =
                new Font("Segoe UI", 10F, FontStyle.Bold);

            label2.ForeColor =
                Color.FromArgb(45, 65, 85);

            // ==============================
            // TEXTBOX MÃ NHÂN VIÊN
            // ==============================

            txtMaNhanVien.Location =
                new Point(40, 155);

            txtMaNhanVien.Size =
                new Size(490, 35);

            txtMaNhanVien.Font =
                new Font("Segoe UI", 12F);

            txtMaNhanVien.BorderStyle =
                BorderStyle.FixedSingle;

            txtMaNhanVien.BackColor =
                Color.FromArgb(248, 250, 253);

            txtMaNhanVien.Name = "txtMaNhanVien";

            // ==============================
            // LABEL MẬT KHẨU
            // ==============================

            label3.AutoSize = true;

            label3.Location = new Point(38, 220);

            label3.Text = "MẬT KHẨU";

            label3.Font =
                new Font("Segoe UI", 10F, FontStyle.Bold);

            label3.ForeColor =
                Color.FromArgb(45, 65, 85);

            // ==============================
            // TEXTBOX MẬT KHẨU
            // ==============================

            txtMatKhau.Location =
                new Point(40, 250);

            txtMatKhau.Size =
                new Size(490, 35);

            txtMatKhau.Font =
                new Font("Segoe UI", 12F);

            txtMatKhau.BorderStyle =
                BorderStyle.FixedSingle;

            txtMatKhau.BackColor =
                Color.FromArgb(248, 250, 253);

            txtMatKhau.Name = "txtMatKhau";

            // ==============================
            // BUTTON ĐĂNG NHẬP
            // ==============================

            button1.Location =
                new Point(40, 330);

            button1.Size =
                new Size(295, 48);

            button1.Text = "ĐĂNG NHẬP";

            button1.Name = "button1";

            button1.Font =
                new Font("Segoe UI", 11F, FontStyle.Bold);

            button1.ForeColor = Color.White;

            button1.BackColor =
                Color.FromArgb(8, 120, 209);

            button1.FlatStyle = FlatStyle.Flat;

            button1.FlatAppearance.BorderSize = 0;

            button1.Cursor = Cursors.Hand;

            button1.UseVisualStyleBackColor = false;

            // ==============================
            // BUTTON THOÁT
            // ==============================

            button2.Location =
                new Point(355, 330);

            button2.Size =
                new Size(175, 48);

            button2.Text = "THOÁT";

            button2.Name = "button2";

            button2.Font =
                new Font("Segoe UI", 10F, FontStyle.Bold);

            button2.ForeColor =
                Color.FromArgb(60, 75, 90);

            button2.BackColor =
                Color.FromArgb(231, 237, 245);

            button2.FlatStyle = FlatStyle.Flat;

            button2.FlatAppearance.BorderSize = 0;

            button2.Cursor = Cursors.Hand;

            button2.UseVisualStyleBackColor = false;

            // ==============================
            // ADD CONTROLS
            // ==============================

            groupBox1.Controls.Add(label4);

            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtMaNhanVien);

            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtMatKhau);

            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(button2);

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

        // Tự động căn giữa khung đăng nhập
        private void panelContent_Resize(object sender, EventArgs e)
        {
            groupBox1.Location = new Point(
                (panelContent.ClientSize.Width - groupBox1.Width) / 2,
                (panelContent.ClientSize.Height - groupBox1.Height) / 2
            );
        }

        private Label label1;
        private GroupBox groupBox1;

        private TextBox txtMatKhau;
        private TextBox txtMaNhanVien;

        private Label label2;
        private Label label3;

        private Button button1;
        private Button button2;
    }
}
