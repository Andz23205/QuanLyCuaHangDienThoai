
using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();

            Load += Form5_Load;

            // TAB 1: HANG SAN XUAT
            btnThem.Click += (s, e) =>
                ThemDanhMuc("tblHangSX", "MaHangSX", "TenHangSX",
                    txtMaHang, txtTenHang, LoadHangSX);

            btnSua.Click += (s, e) =>
                SuaDanhMuc("tblHangSX", "MaHangSX", "TenHangSX",
                    txtMaHang, txtTenHang, LoadHangSX);

            btnXoa.Click += (s, e) =>
                XoaDanhMuc("tblHangSX", "MaHangSX",
                    txtMaHang, LoadHangSX);

            btnLamLai.Click += (s, e) =>
                LamLai(txtMaHang, txtTenHang);

            btnThoat.Click += (s, e) => Close();

            dgvHangSX.CellClick += (s, e) =>
                ChonDong(e, dgvHangSX, txtMaHang, txtTenHang, "MaHangSX", "TenHangSX");


            // TAB 2: LOAI HANG
            // button5 = Them, button4 = Sua, button3 = Xoa
            // button2 = Lam lai, button1 = Thoat

            button5.Click += (s, e) =>
                ThemDanhMuc("tblLoai", "MaLoai", "TenLoai",
                    textBox3, textBox1, LoadLoai);

            button4.Click += (s, e) =>
                SuaDanhMuc("tblLoai", "MaLoai", "TenLoai",
                    textBox3, textBox1, LoadLoai);

            button3.Click += (s, e) =>
                XoaDanhMuc("tblLoai", "MaLoai",
                    textBox3, LoadLoai);

            button2.Click += (s, e) =>
                LamLai(textBox3, textBox1);

            button1.Click += (s, e) => Close();

            dataGridView1.CellClick += (s, e) =>
                ChonDong(e, dataGridView1, textBox3, textBox1, "MaLoai", "TenLoai");


            // TAB 3: MAU SAC
            // button10 = Them, button9 = Sua, button8 = Xoa
            // button7 = Lam lai, button6 = Thoat

            button10.Click += (s, e) =>
                ThemDanhMuc("tblMau", "MaMau", "TenMau",
                    textBox6, textBox4, LoadMau);

            button9.Click += (s, e) =>
                SuaDanhMuc("tblMau", "MaMau", "TenMau",
                    textBox6, textBox4, LoadMau);

            button8.Click += (s, e) =>
                XoaDanhMuc("tblMau", "MaMau",
                    textBox6, LoadMau);

            button7.Click += (s, e) =>
                LamLai(textBox6, textBox4);

            button6.Click += (s, e) => Close();

            dataGridView2.CellClick += (s, e) =>
                ChonDong(e, dataGridView2, textBox6, textBox4, "MaMau", "TenMau");


            // TAB 4: DUNG LUONG
            // button15 = Them, button14 = Sua, button13 = Xoa
            // button12 = Lam lai, button11 = Thoat

            button15.Click += (s, e) =>
                ThemDanhMuc("tblDungLuong", "MaDungLuong", "TenDungLuong",
                    textBox9, textBox7, LoadDungLuong);

            button14.Click += (s, e) =>
                SuaDanhMuc("tblDungLuong", "MaDungLuong", "TenDungLuong",
                    textBox9, textBox7, LoadDungLuong);

            button13.Click += (s, e) =>
                XoaDanhMuc("tblDungLuong", "MaDungLuong",
                    textBox9, LoadDungLuong);

            button12.Click += (s, e) =>
                LamLai(textBox9, textBox7);

            button11.Click += (s, e) => Close();

            dataGridView3.CellClick += (s, e) =>
                ChonDong(e, dataGridView3, textBox9, textBox7,
                    "MaDungLuong", "TenDungLuong");
        }


        // KHOI TAO FORM
        private void Form5_Load(object? sender, EventArgs e)
        {
            SetupDgv(dgvHangSX);
            SetupDgv(dataGridView1);
            SetupDgv(dataGridView2);
            SetupDgv(dataGridView3);

            // Database hien tai khong co cot GhiChu.
            // An cac o ghi chu de tranh nhap lieu nhung khong duoc luu.

            txtGhiChu.Visible = false;
            label2.Visible = false;

            textBox2.Visible = false;
            label5.Visible = false;

            textBox5.Visible = false;
            label8.Visible = false;

            textBox8.Visible = false;
            label11.Visible = false;

            // Dat lai ten nhan cho tung tab
            label1.Text = "Mã hãng SX";
            label3.Text = "Tên hãng SX";

            label6.Text = "Mã loại";
            label4.Text = "Tên loại";

            label9.Text = "Mã màu";
            label7.Text = "Tên màu";

            label12.Text = "Mã dung lượng";
            label10.Text = "Tên dung lượng";

            LoadHangSX();
            LoadLoai();
            LoadMau();
            LoadDungLuong();
        }


        // CAU HINH DATAGRIDVIEW
        private void SetupDgv(DataGridView dgv)
        {
            dgv.Columns.Clear();
            dgv.AutoGenerateColumns = true;

            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowHeadersVisible = false;
        }


        // TAI DU LIEU
        private void LoadHangSX()
        {
            dgvHangSX.DataSource = KetNoiCSDL.DocBang(
                "SELECT MaHangSX, TenHangSX FROM tblHangSX ORDER BY MaHangSX");

            if (dgvHangSX.Columns.Contains("MaHangSX"))
                dgvHangSX.Columns["MaHangSX"].HeaderText = "Mã hãng SX";

            if (dgvHangSX.Columns.Contains("TenHangSX"))
                dgvHangSX.Columns["TenHangSX"].HeaderText = "Tên hãng SX";
        }


        private void LoadLoai()
        {
            dataGridView1.DataSource = KetNoiCSDL.DocBang(
                "SELECT MaLoai, TenLoai FROM tblLoai ORDER BY MaLoai");

            if (dataGridView1.Columns.Contains("MaLoai"))
                dataGridView1.Columns["MaLoai"].HeaderText = "Mã loại";

            if (dataGridView1.Columns.Contains("TenLoai"))
                dataGridView1.Columns["TenLoai"].HeaderText = "Tên loại";
        }


        private void LoadMau()
        {
            dataGridView2.DataSource = KetNoiCSDL.DocBang(
                "SELECT MaMau, TenMau FROM tblMau ORDER BY MaMau");

            if (dataGridView2.Columns.Contains("MaMau"))
                dataGridView2.Columns["MaMau"].HeaderText = "Mã màu";

            if (dataGridView2.Columns.Contains("TenMau"))
                dataGridView2.Columns["TenMau"].HeaderText = "Tên màu";
        }


        private void LoadDungLuong()
        {
            dataGridView3.DataSource = KetNoiCSDL.DocBang(
                "SELECT MaDungLuong, TenDungLuong FROM tblDungLuong ORDER BY MaDungLuong");

            if (dataGridView3.Columns.Contains("MaDungLuong"))
                dataGridView3.Columns["MaDungLuong"].HeaderText = "Mã dung lượng";

            if (dataGridView3.Columns.Contains("TenDungLuong"))
                dataGridView3.Columns["TenDungLuong"].HeaderText = "Tên dung lượng";
        }


        // CHON MOT DONG TREN DATAGRIDVIEW
        private void ChonDong(
            DataGridViewCellEventArgs e,
            DataGridView dgv,
            TextBox txtMa,
            TextBox txtTen,
            string cotMa,
            string cotTen)
        {
            if (e.RowIndex < 0)
                return;

            if (dgv.Rows[e.RowIndex].DataBoundItem is DataRowView r)
            {
                txtMa.Text = r[cotMa]?.ToString() ?? "";
                txtTen.Text = r[cotTen]?.ToString() ?? "";

                txtMa.ReadOnly = true;
            }
        }


        // THEM DANH MUC
        private void ThemDanhMuc(
            string bang,
            string cotMa,
            string cotTen,
            TextBox txtMa,
            TextBox txtTen,
            Action reload)
        {
            string ma = txtMa.Text.Trim();
            string ten = txtTen.Text.Trim();

            if (txtMa.ReadOnly)
            {
                MessageBox.Show(
                    "Bạn đang chọn một danh mục có sẵn. Hãy bấm Làm lại trước khi thêm mới!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(ma) ||
                string.IsNullOrWhiteSpace(ten))
            {
                MessageBox.Show(
                    "Vui lòng nhập đầy đủ mã và tên danh mục!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                object? count = KetNoiCSDL.ThucThiGiaTri(
                    $"SELECT COUNT(*) FROM {bang} WHERE {cotMa} = @Ma",
                    new[] { new SqlParameter("@Ma", ma) });

                if (Convert.ToInt32(count) > 0)
                {
                    MessageBox.Show(
                        "Mã danh mục đã tồn tại!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                int ketQua = KetNoiCSDL.ThucThi(
                    $"INSERT INTO {bang} ({cotMa}, {cotTen}) VALUES (@Ma, @Ten)",
                    new[]
                    {
                        new SqlParameter("@Ma", ma),
                        new SqlParameter("@Ten", ten)
                    });

                if (ketQua > 0)
                {
                    MessageBox.Show(
                        "Thêm danh mục thành công!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    reload();
                    LamLai(txtMa, txtTen);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi thêm danh mục: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // SUA DANH MUC
        private void SuaDanhMuc(
            string bang,
            string cotMa,
            string cotTen,
            TextBox txtMa,
            TextBox txtTen,
            Action reload)
        {
            string ma = txtMa.Text.Trim();
            string ten = txtTen.Text.Trim();

            if (!txtMa.ReadOnly || string.IsNullOrWhiteSpace(ma))
            {
                MessageBox.Show(
                    "Vui lòng chọn danh mục cần sửa trong danh sách!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(ten))
            {
                MessageBox.Show(
                    "Tên danh mục không được để trống!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int ketQua = KetNoiCSDL.ThucThi(
                    $"UPDATE {bang} SET {cotTen} = @Ten WHERE {cotMa} = @Ma",
                    new[]
                    {
                        new SqlParameter("@Ma", ma),
                        new SqlParameter("@Ten", ten)
                    });

                if (ketQua > 0)
                {
                    MessageBox.Show(
                        "Cập nhật danh mục thành công!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    reload();
                    LamLai(txtMa, txtTen);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy danh mục cần sửa!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi sửa danh mục: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // XOA DANH MUC
        private void XoaDanhMuc(
            string bang,
            string cotMa,
            TextBox txtMa,
            Action reload)
        {
            string ma = txtMa.Text.Trim();

            if (!txtMa.ReadOnly || string.IsNullOrWhiteSpace(ma))
            {
                MessageBox.Show(
                    "Vui lòng chọn danh mục cần xóa trong danh sách!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DialogResult xacNhan = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa danh mục {ma} không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (xacNhan != DialogResult.Yes)
                return;

            try
            {
                int ketQua = KetNoiCSDL.ThucThi(
                    $"DELETE FROM {bang} WHERE {cotMa} = @Ma",
                    new[] { new SqlParameter("@Ma", ma) });

                if (ketQua > 0)
                {
                    MessageBox.Show(
                        "Xóa danh mục thành công!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    reload();
                    LamLai(txtMa, null);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy danh mục cần xóa!");
                }
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                MessageBox.Show(
                    "Không thể xóa danh mục này vì đang được sử dụng trong danh sách sản phẩm.\n\n" +
                    "Hãy cập nhật sản phẩm liên quan trước khi xóa.",
                    "Không thể xóa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi xóa danh mục: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // LAM LAI CAC O NHAP
        private void LamLai(TextBox txtMa, TextBox? txtTen)
        {
            txtMa.Clear();
            txtMa.ReadOnly = false;

            if (txtTen != null)
                txtTen.Clear();

            txtMa.Focus();
        }
    }
}
