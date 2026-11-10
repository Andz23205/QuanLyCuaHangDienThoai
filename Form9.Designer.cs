namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    partial class Form9
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            groupBox1 = new GroupBox();
            txtMatKhau = new TextBox();
            txtMaNhanVien = new TextBox();
            label3 = new Label();
            label2 = new Label();
            btnDangNhap = new Button();
            btnThoat = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label1.Location = new Point(481, 66);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(524, 60);
            label1.TabIndex = 0;
            label1.Text = "CỬA HÀNG ĐIỆN THOẠI ";
            label1.Click += label1_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtMatKhau);
            groupBox1.Controls.Add(txtMaNhanVien);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(39, 171);
            groupBox1.Margin = new Padding(5);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(5);
            groupBox1.Size = new Size(1445, 290);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin đăng nhập ";
            // 
            // txtMatKhau
            // 
            txtMatKhau.Location = new Point(252, 198);
            txtMatKhau.Margin = new Padding(5);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(1150, 39);
            txtMatKhau.TabIndex = 3;
            // 
            // txtMaNhanVien
            // 
            txtMaNhanVien.Location = new Point(252, 70);
            txtMaNhanVien.Margin = new Padding(5);
            txtMaNhanVien.Name = "txtMaNhanVien";
            txtMaNhanVien.Size = new Size(1150, 39);
            txtMaNhanVien.TabIndex = 2;
            txtMaNhanVien.TextChanged += textBox1_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(57, 198);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(115, 32);
            label3.TabIndex = 1;
            label3.Text = "Mật khẩu";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(57, 70);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(168, 32);
            label2.TabIndex = 0;
            label2.Text = "Mã nhân viên ";
            // 
            // btnDangNhap
            // 
            btnDangNhap.BackColor = SystemColors.ScrollBar;
            btnDangNhap.Location = new Point(291, 530);
            btnDangNhap.Margin = new Padding(5);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(242, 72);
            btnDangNhap.TabIndex = 2;
            btnDangNhap.Text = "&Đăng nhập";
            btnDangNhap.UseVisualStyleBackColor = false;
            btnDangNhap.Click += btnDangNhap_Click;
            // 
            // btnThoat
            // 
            btnThoat.BackColor = SystemColors.ScrollBar;
            btnThoat.Location = new Point(673, 530);
            btnThoat.Margin = new Padding(5);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(193, 72);
            btnThoat.TabIndex = 3;
            btnThoat.Text = "Th&oát";
            btnThoat.UseVisualStyleBackColor = false;
            // 
            // Form9
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1528, 706);
            Controls.Add(btnThoat);
            Controls.Add(btnDangNhap);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Margin = new Padding(5);
            Name = "Form9";
            Text = "Đăng nhập hệ thống ";
            Load += Form9_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private TextBox txtMatKhau;
        private TextBox txtMaNhanVien;
        private Label label3;
        private Label label2;
        private Button btnDangNhap;
        private Button btnThoat;
    }
}