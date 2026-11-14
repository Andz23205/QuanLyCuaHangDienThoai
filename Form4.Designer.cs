namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    partial class Form4
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
            btnThoat = new Button();
            groupBox5 = new GroupBox();
            button1 = new Button();
            txtTim = new TextBox();
            label6 = new Label();
            label8 = new Label();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            groupBox4 = new GroupBox();
            dgvKhachHang = new DataGridView();
            colMaNCC = new DataGridViewTextBoxColumn();
            colTenNCC = new DataGridViewTextBoxColumn();
            colSDT = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            colDiaChi = new DataGridViewTextBoxColumn();
            colNguoiLH = new DataGridViewTextBoxColumn();
            btnLamLai = new Button();
            label7 = new Label();
            groupBox2 = new GroupBox();
            txtEmail = new TextBox();
            txtTenNCC = new TextBox();
            txtDiaChi = new TextBox();
            txtSDT = new TextBox();
            txtMaNCC = new TextBox();
            label3 = new Label();
            label5 = new Label();
            label4 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox3 = new GroupBox();
            groupBox1 = new GroupBox();
            txtNguoiLH = new TextBox();
            label11 = new Label();
            groupBox5.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKhachHang).BeginInit();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnThoat
            // 
            btnThoat.BackColor = SystemColors.ControlLight;
            btnThoat.Location = new Point(614, 43);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(112, 41);
            btnThoat.TabIndex = 0;
            btnThoat.Text = "Th&oát";
            btnThoat.UseVisualStyleBackColor = false;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(button1);
            groupBox5.Controls.Add(txtTim);
            groupBox5.Controls.Add(label6);
            groupBox5.Location = new Point(777, 266);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(339, 101);
            groupBox5.TabIndex = 9;
            groupBox5.TabStop = false;
            groupBox5.Text = "Tìm nhanh";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ControlLight;
            button1.Location = new Point(239, 44);
            button1.Name = "button1";
            button1.Size = new Size(94, 38);
            button1.TabIndex = 2;
            button1.Text = "&Tìm";
            button1.UseVisualStyleBackColor = false;
            // 
            // txtTim
            // 
            txtTim.Location = new Point(62, 50);
            txtTim.Name = "txtTim";
            txtTim.Size = new Size(153, 27);
            txtTim.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 53);
            label6.Name = "label6";
            label6.Size = new Size(39, 20);
            label6.TabIndex = 0;
            label6.Text = "SĐT:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(18, 125);
            label8.Name = "label8";
            label8.Size = new Size(304, 60);
            label8.TabIndex = 0;
            label8.Text = "Không cho xóa nhà cung cấp đã có hóa đơn \r\nnhập, hãy bắt lỗi khóa ngoại và báo bằng \r\nMessageBox.";
            // 
            // btnXoa
            // 
            btnXoa.BackColor = SystemColors.ControlLight;
            btnXoa.Location = new Point(298, 43);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(110, 41);
            btnXoa.TabIndex = 0;
            btnXoa.Text = "&Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            // 
            // btnSua
            // 
            btnSua.BackColor = SystemColors.ControlLight;
            btnSua.Location = new Point(160, 43);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(102, 41);
            btnSua.TabIndex = 0;
            btnSua.Text = "&Sửa";
            btnSua.UseVisualStyleBackColor = false;
            // 
            // btnThem
            // 
            btnThem.BackColor = SystemColors.ControlLight;
            btnThem.Location = new Point(19, 41);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(104, 41);
            btnThem.TabIndex = 0;
            btnThem.Text = "&Thêm";
            btnThem.UseVisualStyleBackColor = false;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(dgvKhachHang);
            groupBox4.Location = new Point(6, 386);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(1119, 240);
            groupBox4.TabIndex = 8;
            groupBox4.TabStop = false;
            groupBox4.Text = "Danh sách khách hàng";
            // 
            // dgvKhachHang
            // 
            dgvKhachHang.AllowUserToAddRows = false;
            dgvKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKhachHang.BackgroundColor = Color.White;
            dgvKhachHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKhachHang.Columns.AddRange(new DataGridViewColumn[] { colMaNCC, colTenNCC, colSDT, colEmail, colDiaChi, colNguoiLH });
            dgvKhachHang.Location = new Point(6, 26);
            dgvKhachHang.Name = "dgvKhachHang";
            dgvKhachHang.ReadOnly = true;
            dgvKhachHang.RowHeadersWidth = 51;
            dgvKhachHang.Size = new Size(1107, 208);
            dgvKhachHang.TabIndex = 0;
            // 
            // colMaNCC
            // 
            colMaNCC.HeaderText = "Mã NCC";
            colMaNCC.MinimumWidth = 6;
            colMaNCC.Name = "colMaNCC";
            colMaNCC.ReadOnly = true;
            // 
            // colTenNCC
            // 
            colTenNCC.HeaderText = "Tên NCC";
            colTenNCC.MinimumWidth = 6;
            colTenNCC.Name = "colTenNCC";
            colTenNCC.ReadOnly = true;
            // 
            // colSDT
            // 
            colSDT.HeaderText = "Số ĐT";
            colSDT.MinimumWidth = 6;
            colSDT.Name = "colSDT";
            colSDT.ReadOnly = true;
            // 
            // colEmail
            // 
            colEmail.HeaderText = "Email";
            colEmail.MinimumWidth = 6;
            colEmail.Name = "colEmail";
            colEmail.ReadOnly = true;
            // 
            // colDiaChi
            // 
            colDiaChi.HeaderText = "Địa chỉ";
            colDiaChi.MinimumWidth = 6;
            colDiaChi.Name = "colDiaChi";
            colDiaChi.ReadOnly = true;
            // 
            // colNguoiLH
            // 
            colNguoiLH.HeaderText = "Người liên hệ";
            colNguoiLH.MinimumWidth = 6;
            colNguoiLH.Name = "colNguoiLH";
            colNguoiLH.ReadOnly = true;
            // 
            // btnLamLai
            // 
            btnLamLai.BackColor = SystemColors.ControlLight;
            btnLamLai.Location = new Point(453, 44);
            btnLamLai.Name = "btnLamLai";
            btnLamLai.Size = new Size(109, 38);
            btnLamLai.TabIndex = 0;
            btnLamLai.Text = "&Làm lại";
            btnLamLai.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(18, 48);
            label7.Name = "label7";
            label7.Size = new Size(324, 40);
            label7.TabIndex = 0;
            label7.Text = "Nhà cung cấp được chọn bằng ComboBox trên \r\nfrmHoaDonNhap.\r\n";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label7);
            groupBox2.Location = new Point(777, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(339, 258);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Lưu ý";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(487, 96);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(255, 27);
            txtEmail.TabIndex = 1;
            // 
            // txtTenNCC
            // 
            txtTenNCC.Location = new Point(487, 51);
            txtTenNCC.Name = "txtTenNCC";
            txtTenNCC.Size = new Size(255, 27);
            txtTenNCC.TabIndex = 1;
            // 
            // txtDiaChi
            // 
            txtDiaChi.Location = new Point(135, 158);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(616, 27);
            txtDiaChi.TabIndex = 1;
            // 
            // txtSDT
            // 
            txtSDT.Location = new Point(135, 100);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(216, 27);
            txtSDT.TabIndex = 1;
            // 
            // txtMaNCC
            // 
            txtMaNCC.Location = new Point(135, 48);
            txtMaNCC.Name = "txtMaNCC";
            txtMaNCC.Size = new Size(216, 27);
            txtMaNCC.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 164);
            label3.Name = "label3";
            label3.Size = new Size(55, 20);
            label3.TabIndex = 0;
            label3.Text = "Địa chỉ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(383, 51);
            label5.Name = "label5";
            label5.Size = new Size(65, 20);
            label5.TabIndex = 0;
            label5.Text = "Tên NCC";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(383, 103);
            label4.Name = "label4";
            label4.Size = new Size(46, 20);
            label4.TabIndex = 0;
            label4.Text = "Email";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 107);
            label2.Name = "label2";
            label2.Size = new Size(49, 20);
            label2.TabIndex = 0;
            label2.Text = "Số ĐT";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 51);
            label1.Name = "label1";
            label1.Size = new Size(63, 20);
            label1.TabIndex = 0;
            label1.Text = "Mã NCC";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnThoat);
            groupBox3.Controls.Add(btnLamLai);
            groupBox3.Controls.Add(btnXoa);
            groupBox3.Controls.Add(btnSua);
            groupBox3.Controls.Add(btnThem);
            groupBox3.Location = new Point(4, 266);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(765, 101);
            groupBox3.TabIndex = 7;
            groupBox3.TabStop = false;
            groupBox3.Text = "Chức năng ";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtNguoiLH);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(txtEmail);
            groupBox1.Controls.Add(txtTenNCC);
            groupBox1.Controls.Add(txtDiaChi);
            groupBox1.Controls.Add(txtSDT);
            groupBox1.Controls.Add(txtMaNCC);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(6, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(765, 258);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin nhà cung cấp";
            // 
            // txtNguoiLH
            // 
            txtNguoiLH.Location = new Point(135, 208);
            txtNguoiLH.Name = "txtNguoiLH";
            txtNguoiLH.Size = new Size(216, 27);
            txtNguoiLH.TabIndex = 3;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(30, 215);
            label11.Name = "label11";
            label11.Size = new Size(103, 20);
            label11.TabIndex = 2;
            label11.Text = "Người liên hệ ";
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1124, 657);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox2);
            Controls.Add(groupBox3);
            Controls.Add(groupBox1);
            Name = "Form4";
            Text = "Quản lí nhà cung cấp";
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvKhachHang).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnThoat;
        private GroupBox groupBox5;
        private TextBox txtTim;
        private Label label6;
        private Label label8;
        private Button btnXoa;
        private Button btnSua;
        private Button btnThem;
        private GroupBox groupBox4;
        private DataGridView dgvKhachHang;
        private Button btnLamLai;
        private Label label7;
        private GroupBox groupBox2;
        private TextBox txtEmail;
        private TextBox txtTenNCC;
        private TextBox txtDiaChi;
        private TextBox txtSDT;
        private TextBox txtMaNCC;
        private Label label3;
        private Label label5;
        private Label label4;
        private Label label2;
        private Label label1;
        private GroupBox groupBox3;
        private GroupBox groupBox1;
        private TextBox txtNguoiLH;
        private Label label11;
        private Button button1;
        private DataGridViewTextBoxColumn colMaNCC;
        private DataGridViewTextBoxColumn colTenNCC;
        private DataGridViewTextBoxColumn colSDT;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewTextBoxColumn colDiaChi;
        private DataGridViewTextBoxColumn colNguoiLH;
    }
}