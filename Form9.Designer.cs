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
            button1 = new Button();
            button2 = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label1.Location = new Point(296, 41);
            label1.Name = "label1";
            label1.Size = new Size(335, 38);
            label1.TabIndex = 0;
            label1.Text = "CỬA HÀNG ĐIỆN THOẠI ";
        
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtMatKhau);
            groupBox1.Controls.Add(txtMaNhanVien);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(24, 107);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(889, 181);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin đăng nhập ";
            // 
            // txtMatKhau
            // 
            txtMatKhau.Location = new Point(155, 124);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(709, 27);
            txtMatKhau.TabIndex = 3;
            // 
            // txtMaNhanVien
            // 
            txtMaNhanVien.Location = new Point(155, 44);
            txtMaNhanVien.Name = "txtMaNhanVien";
            txtMaNhanVien.Size = new Size(709, 27);
            txtMaNhanVien.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(35, 124);
            label3.Name = "label3";
            label3.Size = new Size(70, 20);
            label3.TabIndex = 1;
            label3.Text = "Mật khẩu";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(35, 44);
            label2.Name = "label2";
            label2.Size = new Size(101, 20);
            label2.TabIndex = 0;
            label2.Text = "Mã nhân viên ";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ScrollBar;
            button1.Location = new Point(179, 331);
            button1.Name = "button1";
            button1.Size = new Size(149, 45);
            button1.TabIndex = 2;
            button1.Text = "&Đăng nhập";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ScrollBar;
            button2.Location = new Point(414, 331);
            button2.Name = "button2";
            button2.Size = new Size(119, 45);
            button2.TabIndex = 3;
            button2.Text = "Th&oát";
            button2.UseVisualStyleBackColor = false;
            // 
            // Form9
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(940, 441);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Name = "Form9";
            Text = "Đăng nhập hệ thống ";
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
        private Button button1;
        private Button button2;
    }
}