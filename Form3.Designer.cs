namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    partial class Form3
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
            groupBox1 = new GroupBox();
            txtEmail = new TextBox();
            txtTenKH = new TextBox();
            txtDiaChi = new TextBox();
            txtSDT = new TextBox();
            txtMaKH = new TextBox();
            label3 = new Label();
            label5 = new Label();
            label4 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            label9 = new Label();
            label10 = new Label();
            label8 = new Label();
            label7 = new Label();
            groupBox3 = new GroupBox();
            btnThoat = new Button();
            btnLamLai = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            groupBox4 = new GroupBox();
            dgvKhachHang = new DataGridView();
            colMaKH = new DataGridViewTextBoxColumn();
            colTenKH = new DataGridViewTextBoxColumn();
            colSDT = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            colDiaChi = new DataGridViewTextBoxColumn();
            groupBox5 = new GroupBox();
            txtTim = new TextBox();
            label6 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKhachHang).BeginInit();
            groupBox5.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtEmail);
            groupBox1.Controls.Add(txtTenKH);
            groupBox1.Controls.Add(txtDiaChi);
            groupBox1.Controls.Add(txtSDT);
            groupBox1.Controls.Add(txtMaKH);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(20, 19);
            groupBox1.Margin = new Padding(5, 5, 5, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(5, 5, 5, 5);
            groupBox1.Size = new Size(1331, 413);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin khách hàng ";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(791, 154);
            txtEmail.Margin = new Padding(5, 5, 5, 5);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(412, 39);
            txtEmail.TabIndex = 1;
            // 
            // txtTenKH
            // 
            txtTenKH.Location = new Point(791, 82);
            txtTenKH.Margin = new Padding(5, 5, 5, 5);
            txtTenKH.Name = "txtTenKH";
            txtTenKH.Size = new Size(412, 39);
            txtTenKH.TabIndex = 1;
            // 
            // txtDiaChi
            // 
            txtDiaChi.Location = new Point(205, 251);
            txtDiaChi.Margin = new Padding(5, 5, 5, 5);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(998, 39);
            txtDiaChi.TabIndex = 1;
            // 
            // txtSDT
            // 
            txtSDT.Location = new Point(205, 160);
            txtSDT.Margin = new Padding(5, 5, 5, 5);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(348, 39);
            txtSDT.TabIndex = 1;
            // 
            // txtMaKH
            // 
            txtMaKH.Location = new Point(205, 72);
            txtMaKH.Margin = new Padding(5, 5, 5, 5);
            txtMaKH.Name = "txtMaKH";
            txtMaKH.Size = new Size(348, 39);
            txtMaKH.TabIndex = 1;
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
            label5.Size = new Size(90, 32);
            label5.TabIndex = 0;
            label5.Text = "Tên KH";
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
            label1.Size = new Size(93, 32);
            label1.TabIndex = 0;
            label1.Text = "Mã KH ";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label7);
            groupBox2.Location = new Point(1388, 19);
            groupBox2.Margin = new Padding(5, 5, 5, 5);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(5, 5, 5, 5);
            groupBox2.Size = new Size(551, 413);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Lưu ý";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(37, 104);
            label9.Margin = new Padding(5, 0, 5, 0);
            label9.Name = "label9";
            label9.Size = new Size(483, 128);
            label9.TabIndex = 0;
            label9.Text = "nhập SĐT trên frmHoaDonBan thì hiện tên, \r\nmã địa chỉ\r\n\r\n\r\n";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(37, 344);
            label10.Margin = new Padding(5, 0, 5, 0);
            label10.Name = "label10";
            label10.Size = new Size(435, 32);
            label10.TabIndex = 0;
            label10.Text = "Form này dùng để xem, sửa, xóa khách.";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(37, 232);
            label8.Margin = new Padding(5, 0, 5, 0);
            label8.Name = "label8";
            label8.Size = new Size(506, 64);
            label8.TabIndex = 0;
            label8.Text = "Khách chưa có trong CSDL (lần đầu đến mua) \r\nsẽ được thêm tự động khi lập hóa đơn.";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(37, 72);
            label7.Margin = new Padding(5, 0, 5, 0);
            label7.Name = "label7";
            label7.Size = new Size(464, 32);
            label7.TabIndex = 0;
            label7.Text = "Số ĐT là cách tra cứu chính khi bán hàng: ";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnThoat);
            groupBox3.Controls.Add(btnLamLai);
            groupBox3.Controls.Add(btnXoa);
            groupBox3.Controls.Add(btnSua);
            groupBox3.Controls.Add(btnThem);
            groupBox3.Location = new Point(20, 442);
            groupBox3.Margin = new Padding(5, 5, 5, 5);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(5, 5, 5, 5);
            groupBox3.Size = new Size(1331, 162);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Chức năng ";
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
            btnThem.Location = new Point(49, 66);
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
            groupBox4.Location = new Point(20, 637);
            groupBox4.Margin = new Padding(5, 5, 5, 5);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(5, 5, 5, 5);
            groupBox4.Size = new Size(1818, 384);
            groupBox4.TabIndex = 3;
            groupBox4.TabStop = false;
            groupBox4.Text = "Danh sách khách hàng";
            // 
            // dgvKhachHang
            // 
            dgvKhachHang.AllowUserToAddRows = false;
            dgvKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKhachHang.BackgroundColor = Color.White;
            dgvKhachHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKhachHang.Columns.AddRange(new DataGridViewColumn[] { colMaKH, colTenKH, colSDT, colEmail, colDiaChi });
            dgvKhachHang.Location = new Point(10, 42);
            dgvKhachHang.Margin = new Padding(5, 5, 5, 5);
            dgvKhachHang.Name = "dgvKhachHang";
            dgvKhachHang.ReadOnly = true;
            dgvKhachHang.RowHeadersWidth = 51;
            dgvKhachHang.Size = new Size(1901, 333);
            dgvKhachHang.TabIndex = 0;
            // 
            // colMaKH
            // 
            colMaKH.HeaderText = "Mã KH";
            colMaKH.MinimumWidth = 6;
            colMaKH.Name = "colMaKH";
            colMaKH.ReadOnly = true;
            // 
            // colTenKH
            // 
            colTenKH.HeaderText = "Tên KH";
            colTenKH.MinimumWidth = 6;
            colTenKH.Name = "colTenKH";
            colTenKH.ReadOnly = true;
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
            // groupBox5
            // 
            groupBox5.Controls.Add(txtTim);
            groupBox5.Controls.Add(label6);
            groupBox5.Location = new Point(1388, 442);
            groupBox5.Margin = new Padding(5, 5, 5, 5);
            groupBox5.Name = "groupBox5";
            groupBox5.Padding = new Padding(5, 5, 5, 5);
            groupBox5.Size = new Size(551, 162);
            groupBox5.TabIndex = 4;
            groupBox5.TabStop = false;
            groupBox5.Text = "Tìm nhanh";
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
            label6.Size = new Size(105, 32);
            label6.TabIndex = 0;
            label6.Text = "Từ khóa:";
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1974, 1129);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Margin = new Padding(5, 5, 5, 5);
            Name = "Form3";
            Text = "Quản lí khách hàng ";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvKhachHang).EndInit();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
        private TextBox txtEmail;
        private TextBox txtTenKH;
        private TextBox txtSDT;
        private TextBox txtMaKH;
        private Label label3;
        private Label label5;
        private Label label4;
        private Label label2;
        private Label label1;
        private TextBox txtDiaChi;
        private Button btnSua;
        private Button btnThem;
        private Label label9;
        private Label label8;
        private Label label7;
        private Button btnLamLai;
        private Button btnXoa;
        private Button button5;
        private TextBox txtTim;
        private Label label6;
        private Button btnThoat;
        private Label label10;
        private DataGridView dgvKhachHang;
        private DataGridViewTextBoxColumn colMaKH;
        private DataGridViewTextBoxColumn colTenKH;
        private DataGridViewTextBoxColumn colSDT;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewTextBoxColumn colDiaChi;
    }
}