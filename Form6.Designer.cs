
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    partial class Form6
    {
        private System.ComponentModel.IContainer components = null;

        private readonly Color mauNen = Color.FromArgb(244, 247, 252);
        private readonly Color mauChu = Color.FromArgb(35, 48, 68);
        private readonly Color mauXanh = Color.FromArgb(41, 98, 170);
        private readonly Color mauXanhDam = Color.FromArgb(30, 75, 135);
        private readonly Color mauDo = Color.FromArgb(220, 75, 75);
        private readonly Color mauXam = Color.FromArgb(105, 119, 139);
        private readonly Color mauVien = Color.FromArgb(220, 227, 237);

        private GroupBox groupBox1;
        private ComboBox cboLoai;
        private ComboBox cboHang;
        private ComboBox cboMau;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
        private TextBox txtGiaDen;
        private TextBox txtGiaTu;
        private TextBox txtTenHang;
        private Label label2;
        private Label label5;
        private Label label4;
        private Label label7;
        private Label label3;
        private Label label1;

        private GroupBox groupBox2;
        private DataGridView dgvKetQua;
        private DataGridViewTextBoxColumn ColMaHang;
        private DataGridViewTextBoxColumn colTenHang;
        private DataGridViewTextBoxColumn colHang;
        private DataGridViewTextBoxColumn colLoai;
        private DataGridViewTextBoxColumn colMau;
        private DataGridViewTextBoxColumn colDungLuong;
        private DataGridViewTextBoxColumn colGiaBan;
        private DataGridViewTextBoxColumn colSL;
        private Label label6;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();

            cboLoai = new ComboBox();
            cboHang = new ComboBox();
            cboMau = new ComboBox();

            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();

            txtGiaDen = new TextBox();
            txtGiaTu = new TextBox();
            txtTenHang = new TextBox();

            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label7 = new Label();
            label6 = new Label();

            dgvKetQua = new DataGridView();

            ColMaHang = new DataGridViewTextBoxColumn();
            colTenHang = new DataGridViewTextBoxColumn();
            colHang = new DataGridViewTextBoxColumn();
            colLoai = new DataGridViewTextBoxColumn();
            colMau = new DataGridViewTextBoxColumn();
            colDungLuong = new DataGridViewTextBoxColumn();
            colGiaBan = new DataGridViewTextBoxColumn();
            colSL = new DataGridViewTextBoxColumn();

            ((System.ComponentModel.ISupportInitialize)dgvKetQua).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();

            // FORM
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = mauNen;
            Font = new Font("Segoe UI", 10F);
            ClientSize = new Size(1400, 850);
            MinimumSize = new Size(1000, 700);
            Name = "Form6";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TÌM KIẾM ĐIỆN THOẠI";
            WindowState = FormWindowState.Maximized;

            // GROUPBOX 1 - TIÊU CHÍ TÌM KIẾM
            groupBox1.Text = "TIÊU CHÍ TÌM KIẾM";
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            groupBox1.ForeColor = mauChu;
            groupBox1.BackColor = Color.White;
            groupBox1.Padding = new Padding(15);
            groupBox1.Location = new Point(18, 15);
            groupBox1.Size = new Size(1300, 270);
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // LABEL
            SetupLabel(label1, "Tên hàng");
            SetupLabel(label3, "Hãng sản xuất");
            SetupLabel(label5, "Loại hàng");
            SetupLabel(label2, "Màu sắc");
            SetupLabel(label7, "Giá từ");
            SetupLabel(label4, "Giá đến");

            // TEXTBOX
            SetupTextBox(txtTenHang);
            SetupTextBox(txtGiaTu);
            SetupTextBox(txtGiaDen);

            // COMBOBOX
            SetupComboBox(cboHang);
            SetupComboBox(cboLoai);
            SetupComboBox(cboMau);

            // BUTTON
            button1.Text = "⌕  Tìm kiếm";
            button2.Text = "↻  Làm mới";
            button3.Text = "✕  Xóa lọc";
            button4.Text = "←  Thoát";

            StyleButton(button1, mauXanh, Color.White);
            StyleButton(button2, Color.FromArgb(36, 155, 110), Color.White);
            StyleButton(button3, mauXam, Color.White);
            StyleButton(button4, Color.FromArgb(70, 82, 100), Color.White);

            // ADD CONTROLS GROUPBOX 1
            groupBox1.Controls.AddRange(new Control[]
            {
                label1, txtTenHang,
                label3, cboHang,
                label5, cboLoai,
                label2, cboMau,
                label7, txtGiaTu,
                label4, txtGiaDen,
                button1, button2, button3, button4
            });

            // GROUPBOX 2 - KẾT QUẢ
            groupBox2.Text = "KẾT QUẢ TÌM KIẾM";
            groupBox2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            groupBox2.ForeColor = mauChu;
            groupBox2.BackColor = Color.White;
            groupBox2.Padding = new Padding(12);
            groupBox2.Location = new Point(18, 300);
            groupBox2.Size = new Size(1300, 500);
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom |
                               AnchorStyles.Left | AnchorStyles.Right;

            // LABEL SỐ LƯỢNG
            label6.Text = "Tìm thấy:";
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label6.ForeColor = mauXanh;
            label6.AutoSize = true;
            label6.Location = new Point(18, 35);

            // DATAGRIDVIEW
            dgvKetQua.BackgroundColor = Color.White;
            dgvKetQua.BorderStyle = BorderStyle.None;
            dgvKetQua.GridColor = mauVien;

            dgvKetQua.EnableHeadersVisualStyles = false;

            dgvKetQua.ColumnHeadersDefaultCellStyle.BackColor = mauXanhDam;
            dgvKetQua.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvKetQua.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10F, FontStyle.Bold);

            dgvKetQua.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvKetQua.ColumnHeadersHeight = 45;
            dgvKetQua.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgvKetQua.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvKetQua.DefaultCellStyle.ForeColor = mauChu;
            dgvKetQua.DefaultCellStyle.BackColor = Color.White;

            dgvKetQua.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(218, 232, 250);

            dgvKetQua.DefaultCellStyle.SelectionForeColor = mauChu;

            dgvKetQua.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(244, 248, 253);

            dgvKetQua.RowTemplate.Height = 38;

            dgvKetQua.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvKetQua.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvKetQua.MultiSelect = false;
            dgvKetQua.ReadOnly = true;
            dgvKetQua.AllowUserToAddRows = false;
            dgvKetQua.AllowUserToDeleteRows = false;
            dgvKetQua.RowHeadersVisible = false;

            // CÁC CỘT DỮ LIỆU
            ColMaHang.HeaderText = "Mã hàng";
            ColMaHang.Name = "ColMaHang";
            ColMaHang.MinimumWidth = 90;
            ColMaHang.FillWeight = 85;

            colTenHang.HeaderText = "Tên hàng";
            colTenHang.Name = "colTenHang";
            colTenHang.MinimumWidth = 130;
            colTenHang.FillWeight = 150;

            colHang.HeaderText = "Hãng sản xuất";
            colHang.Name = "colHang";
            colHang.MinimumWidth = 110;
            colHang.FillWeight = 110;

            colLoai.HeaderText = "Loại hàng";
            colLoai.Name = "colLoai";
            colLoai.MinimumWidth = 90;
            colLoai.FillWeight = 95;

            colMau.HeaderText = "Màu sắc";
            colMau.Name = "colMau";
            colMau.MinimumWidth = 85;
            colMau.FillWeight = 90;

            colDungLuong.HeaderText = "Dung lượng";
            colDungLuong.Name = "colDungLuong";
            colDungLuong.MinimumWidth = 100;
            colDungLuong.FillWeight = 95;

            colGiaBan.HeaderText = "Giá bán";
            colGiaBan.Name = "colGiaBan";
            colGiaBan.MinimumWidth = 110;
            colGiaBan.FillWeight = 110;

            colSL.HeaderText = "Số lượng";
            colSL.Name = "colSL";
            colSL.MinimumWidth = 80;
            colSL.FillWeight = 80;

            dgvKetQua.Columns.AddRange(new DataGridViewColumn[]
            {
                ColMaHang,
                colTenHang,
                colHang,
                colLoai,
                colMau,
                colDungLuong,
                colGiaBan,
                colSL
            });

            dgvKetQua.AutoGenerateColumns = false;

            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(dgvKetQua);

            // ADD TO FORM
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);

            // BỐ TRÍ RESPONSIVE
            Resize += (sender, e) => LayoutForm6();

            groupBox1.Resize += (sender, e) => LayoutForm6();
            groupBox2.Resize += (sender, e) => LayoutForm6();

            LayoutForm6();

            ((System.ComponentModel.ISupportInitialize)dgvKetQua).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        private void LayoutForm6()
        {
            if (groupBox1 == null || groupBox2 == null || dgvKetQua == null)
                return;

            int margin = 18;
            int formWidth = ClientSize.Width;
            int formHeight = ClientSize.Height;

            int groupWidth = Math.Max(500, formWidth - margin * 2);

            // KHUNG TIÊU CHÍ
            groupBox1.SetBounds(margin, 15, groupWidth, 270);

            int innerWidth = groupBox1.ClientSize.Width - 40;
            int gap = 25;
            int colWidth = Math.Max(130, (innerWidth - gap * 2) / 3);

            int x1 = 20;
            int x2 = x1 + colWidth + gap;
            int x3 = x2 + colWidth + gap;

            int labelY1 = 35;
            int inputY1 = 61;
            int labelY2 = 112;
            int inputY2 = 138;

            // HÀNG 1
            label1.Location = new Point(x1, labelY1);
            txtTenHang.SetBounds(x1, inputY1, colWidth, 34);

            label3.Location = new Point(x2, labelY1);
            cboHang.SetBounds(x2, inputY1, colWidth, 34);

            label5.Location = new Point(x3, labelY1);
            cboLoai.SetBounds(x3, inputY1, colWidth, 34);

            // HÀNG 2
            label2.Location = new Point(x1, labelY2);
            cboMau.SetBounds(x1, inputY2, colWidth, 34);

            label7.Location = new Point(x2, labelY2);
            txtGiaTu.SetBounds(x2, inputY2, colWidth, 34);

            label4.Location = new Point(x3, labelY2);
            txtGiaDen.SetBounds(x3, inputY2, colWidth, 34);

            // NHÓM NÚT
            int buttonY = 198;
            int buttonWidth = 155;
            int buttonHeight = 48;
            int buttonGap = 15;
            int buttonX = 20;

            button1.SetBounds(buttonX, buttonY, buttonWidth, buttonHeight);
            buttonX += buttonWidth + buttonGap;

            button2.SetBounds(buttonX, buttonY, buttonWidth, buttonHeight);
            buttonX += buttonWidth + buttonGap;

            button3.SetBounds(buttonX, buttonY, buttonWidth, buttonHeight);
            buttonX += buttonWidth + buttonGap;

            button4.SetBounds(buttonX, buttonY, buttonWidth, buttonHeight);

            // KHUNG KẾT QUẢ
            int resultTop = 300;
            int resultHeight = Math.Max(200, formHeight - resultTop - margin);

            groupBox2.SetBounds(
                margin,
                resultTop,
                groupWidth,
                resultHeight
            );

            // DÒNG THỐNG KÊ
            label6.Location = new Point(18, 34);

            // BẢNG DỮ LIỆU
            int gridTop = 65;
            int gridLeft = 15;
            int gridWidth = Math.Max(300, groupBox2.ClientSize.Width - 30);
            int gridHeight = Math.Max(100, groupBox2.ClientSize.Height - gridTop - 15);

            dgvKetQua.SetBounds(
                gridLeft,
                gridTop,
                gridWidth,
                gridHeight
            );
        }

        private void SetupLabel(Label lbl, string text)
        {
            lbl.Text = text;
            lbl.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbl.ForeColor = mauChu;
            lbl.AutoSize = true;
        }

        private void SetupTextBox(TextBox txt)
        {
            txt.Font = new Font("Segoe UI", 10F);
            txt.ForeColor = mauChu;
            txt.BackColor = Color.FromArgb(250, 252, 255);
            txt.BorderStyle = BorderStyle.FixedSingle;
        }

        private void SetupComboBox(ComboBox cbo)
        {
            cbo.Font = new Font("Segoe UI", 10F);
            cbo.ForeColor = mauChu;
            cbo.BackColor = Color.White;
            cbo.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void StyleButton(Button btn, Color backColor, Color foreColor)
        {
            btn.BackColor = backColor;
            btn.ForeColor = foreColor;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
            btn.UseVisualStyleBackColor = false;
        }
    }
}
