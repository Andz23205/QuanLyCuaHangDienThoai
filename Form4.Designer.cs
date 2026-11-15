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
            btnThoat.Location = new Point(998, 69);
            btnThoat.Margin = new Padding(5, 5, 5, 5);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(182, 66);
            btnThoat.TabIndex = 0;
            btnThoat.Text = "Th&oát";
            btnThoat.UseVisualStyleBackColor = false;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(button1);
            groupBox5.Controls.Add(txtTim);
            groupBox5.Controls.Add(label6);
            groupBox5.Location = new Point(1345, 442);
            groupBox5.Margin = new Padding(5, 5, 5, 5);
            groupBox5.Name = "groupBox5";
            groupBox5.Padding = new Padding(5, 5, 5, 5);
            groupBox5.Size = new Size(551, 162);
            groupBox5.TabIndex = 9;
            groupBox5.TabStop = false;
            groupBox5.Text = "Tìm nhanh";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ControlLight;
            button1.Location = new Point(388, 70);
            button1.Margin = new Padding(5, 5, 5, 5);
            button1.Name = "button1";
            button1.Size = new Size(153, 61);
            button1.TabIndex = 2;
            button1.Text = "&Tìm";
            button1.UseVisualStyleBackColor = false;
            // 
            // txtTim
            // 
            txtTim.Location = new Point(101, 80);
            txtTim.Margin = new Padding(5, 5, 5, 5);
            txtTim.Name = "txtTim";
            txtTim.Size = new Size(246, 39);
            txtTim.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(10, 85);
            label6.Margin = new Padding(5, 0, 5, 0);
            label6.Name = "label6";
            label6.Size = new Size(62, 32);
            label6.TabIndex = 0;
            label6.Text = "SĐT:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(29, 200);
            label8.Margin = new Padding(5, 0, 5, 0);
            label8.Name = "label8";
            label8.Size = new Size(493, 96);
            label8.TabIndex = 0;
            label8.Text = "Không cho xóa nhà cung cấp đã có hóa đơn \r\nnhập, hãy bắt lỗi khóa ngoại và báo bằng \r\nMessageBox.";
            // 
            // btnXoa
            // 
            btnXoa.BackColor = SystemColors.ControlLight;
            btnXoa.Location = new Point(484, 69);
            btnXoa.Margin = new Padding(5, 5, 5, 5);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(179, 66);
            btnXoa.TabIndex = 0;
            btnXoa.Text = "&Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            // 
            // btnSua
            // 
            btnSua.BackColor = SystemColors.ControlLight;
            btnSua.Location = new Point(260, 69);
            btnSua.Margin = new Padding(5, 5, 5, 5);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(166, 66);
            btnSua.TabIndex = 0;
            btnSua.Text = "&Sửa";
            btnSua.UseVisualStyleBackColor = false;
            // 
            // btnThem
            // 
            btnThem.BackColor = SystemColors.ControlLight;
            btnThem.Location = new Point(31, 66);
            btnThem.Margin = new Padding(5, 5, 5, 5);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(169, 66);
            btnThem.TabIndex = 0;
            btnThem.Text = "&Thêm";
            btnThem.UseVisualStyleBackColor = false;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(dgvKhachHang);
            groupBox4.Location = new Point(10, 618);
            groupBox4.Margin = new Padding(5, 5, 5, 5);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(5, 5, 5, 5);
            groupBox4.Size = new Size(1818, 384);
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
            dgvKhachHang.Location = new Point(10, 42);
            dgvKhachHang.Margin = new Padding(5, 5, 5, 5);
            dgvKhachHang.Name = "dgvKhachHang";
            dgvKhachHang.ReadOnly = true;
            dgvKhachHang.RowHeadersWidth = 51;
            dgvKhachHang.Size = new Size(1799, 333);
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
            btnLamLai.Location = new Point(736, 70);
            btnLamLai.Margin = new Padding(5, 5, 5, 5);
            btnLamLai.Name = "btnLamLai";
            btnLamLai.Size = new Size(177, 61);
            btnLamLai.TabIndex = 0;
            btnLamLai.Text = "&Làm lại";
            btnLamLai.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(29, 77);
            label7.Margin = new Padding(5, 0, 5, 0);
            label7.Name = "label7";
            label7.Size = new Size(524, 64);
            label7.TabIndex = 0;
            label7.Text = "Nhà cung cấp được chọn bằng ComboBox trên \r\nfrmHoaDonNhap.\r\n";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label7);
            groupBox2.Location = new Point(1345, 19);
            groupBox2.Margin = new Padding(5, 5, 5, 5);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(5, 5, 5, 5);
            groupBox2.Size = new Size(551, 413);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Lưu ý";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(791, 154);
            txtEmail.Margin = new Padding(5, 5, 5, 5);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(412, 39);
            txtEmail.TabIndex = 1;
            // 
            // txtTenNCC
            // 
            txtTenNCC.Location = new Point(791, 82);
            txtTenNCC.Margin = new Padding(5, 5, 5, 5);
            txtTenNCC.Name = "txtTenNCC";
            txtTenNCC.Size = new Size(412, 39);
            txtTenNCC.TabIndex = 1;
            // 
            // txtDiaChi
            // 
            txtDiaChi.Location = new Point(219, 253);
            txtDiaChi.Margin = new Padding(5, 5, 5, 5);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(998, 39);
            txtDiaChi.TabIndex = 1;
            // 
            // txtSDT
            // 
            txtSDT.Location = new Point(219, 160);
            txtSDT.Margin = new Padding(5, 5, 5, 5);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(348, 39);
            txtSDT.TabIndex = 1;
            // 
            // txtMaNCC
            // 
            txtMaNCC.Location = new Point(219, 77);
            txtMaNCC.Margin = new Padding(5, 5, 5, 5);
            txtMaNCC.Name = "txtMaNCC";
            txtMaNCC.Size = new Size(348, 39);
            txtMaNCC.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(49, 262);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(87, 32);
            label3.TabIndex = 0;
            label3.Text = "Địa chỉ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(622, 82);
            label5.Margin = new Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new Size(106, 32);
            label5.TabIndex = 0;
            label5.Text = "Tên NCC";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(622, 165);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(71, 32);
            label4.TabIndex = 0;
            label4.Text = "Email";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(49, 171);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(78, 32);
            label2.TabIndex = 0;
            label2.Text = "Số ĐT";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(49, 82);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(102, 32);
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
            groupBox3.Location = new Point(6, 426);
            groupBox3.Margin = new Padding(5, 5, 5, 5);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(5, 5, 5, 5);
            groupBox3.Size = new Size(1303, 162);
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
            groupBox1.Location = new Point(10, 19);
            groupBox1.Margin = new Padding(5, 5, 5, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(5, 5, 5, 5);
            groupBox1.Size = new Size(1299, 413);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin nhà cung cấp";
            // 
            // txtNguoiLH
            // 
            txtNguoiLH.Location = new Point(219, 333);
            txtNguoiLH.Margin = new Padding(5, 5, 5, 5);
            txtNguoiLH.Name = "txtNguoiLH";
            txtNguoiLH.Size = new Size(348, 39);
            txtNguoiLH.TabIndex = 3;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(49, 344);
            label11.Margin = new Padding(5, 0, 5, 0);
            label11.Name = "label11";
            label11.Size = new Size(167, 32);
            label11.TabIndex = 2;
            label11.Text = "Người liên hệ ";
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1924, 1129);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox2);
            Controls.Add(groupBox3);
            Controls.Add(groupBox1);
            Margin = new Padding(5, 5, 5, 5);
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