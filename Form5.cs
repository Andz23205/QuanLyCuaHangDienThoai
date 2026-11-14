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

            // Tab 1: HangSX
            btnThem.Click += (s, e) => ThemDanhMuc("tblHangSX", "MaHangSX", "TenHangSX", txtMaHang.Text, txtTenHang.Text, LoadHangSX);
            btnSua.Click += (s, e) => SuaDanhMuc("tblHangSX", "MaHangSX", "TenHangSX", txtMaHang.Text, txtTenHang.Text, LoadHangSX);
            btnXoa.Click += (s, e) => XoaDanhMuc("tblHangSX", "MaHangSX", txtMaHang.Text, LoadHangSX);
            btnLamLai.Click += (s, e) => { txtMaHang.Clear(); txtTenHang.Clear(); txtGhiChu.Clear(); txtMaHang.ReadOnly = false; };
            btnThoat.Click += (s, e) => Close();
            dgvHangSX.CellClick += (s, e) => {
                if (e.RowIndex >= 0 && dgvHangSX.Rows[e.RowIndex].DataBoundItem is DataRowView r) {
                    txtMaHang.Text = r["MaHangSX"].ToString();
                    txtTenHang.Text = r["TenHangSX"].ToString();
                    txtMaHang.ReadOnly = true;
                }
            };

            // Tab 2: Loai
            button1.Click += (s, e) => ThemDanhMuc("tblLoai", "MaLoai", "TenLoai", textBox1.Text, textBox2.Text, LoadLoai);
            button2.Click += (s, e) => SuaDanhMuc("tblLoai", "MaLoai", "TenLoai", textBox1.Text, textBox2.Text, LoadLoai);
            button3.Click += (s, e) => XoaDanhMuc("tblLoai", "MaLoai", textBox1.Text, LoadLoai);
            button4.Click += (s, e) => { textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox1.ReadOnly = false; };
            button5.Click += (s, e) => Close();
            dataGridView1.CellClick += (s, e) => {
                if (e.RowIndex >= 0 && dataGridView1.Rows[e.RowIndex].DataBoundItem is DataRowView r) {
                    textBox1.Text = r["MaLoai"].ToString();
                    textBox2.Text = r["TenLoai"].ToString();
                    textBox1.ReadOnly = true;
                }
            };

            // Tab 3: MauSac
            button6.Click += (s, e) => ThemDanhMuc("tblMau", "MaMau", "TenMau", textBox4.Text, textBox5.Text, LoadMau);
            button7.Click += (s, e) => SuaDanhMuc("tblMau", "MaMau", "TenMau", textBox4.Text, textBox5.Text, LoadMau);
            button8.Click += (s, e) => XoaDanhMuc("tblMau", "MaMau", textBox4.Text, LoadMau);
            button9.Click += (s, e) => { textBox4.Clear(); textBox5.Clear(); textBox6.Clear(); textBox4.ReadOnly = false; };
            button10.Click += (s, e) => Close();
            dataGridView2.CellClick += (s, e) => {
                if (e.RowIndex >= 0 && dataGridView2.Rows[e.RowIndex].DataBoundItem is DataRowView r) {
                    textBox4.Text = r["MaMau"].ToString();
                    textBox5.Text = r["TenMau"].ToString();
                    textBox4.ReadOnly = true;
                }
            };

            // Tab 4: DungLuong
            button11.Click += (s, e) => ThemDanhMuc("tblDungLuong", "MaDungLuong", "TenDungLuong", textBox7.Text, textBox8.Text, LoadDungLuong);
            button12.Click += (s, e) => SuaDanhMuc("tblDungLuong", "MaDungLuong", "TenDungLuong", textBox7.Text, textBox8.Text, LoadDungLuong);
            button13.Click += (s, e) => XoaDanhMuc("tblDungLuong", "MaDungLuong", textBox7.Text, LoadDungLuong);
            button14.Click += (s, e) => { textBox7.Clear(); textBox8.Clear(); textBox9.Clear(); textBox7.ReadOnly = false; };
            button15.Click += (s, e) => Close();
            dataGridView3.CellClick += (s, e) => {
                if (e.RowIndex >= 0 && dataGridView3.Rows[e.RowIndex].DataBoundItem is DataRowView r) {
                    textBox7.Text = r["MaDungLuong"].ToString();
                    textBox8.Text = r["TenDungLuong"].ToString();
                    textBox7.ReadOnly = true;
                }
            };
        }

        private void Form5_Load(object? sender, EventArgs e)
        {
            SetupDgv(dgvHangSX);
            SetupDgv(dataGridView1);
            SetupDgv(dataGridView2);
            SetupDgv(dataGridView3);

            LoadHangSX();
            LoadLoai();
            LoadMau();
            LoadDungLuong();
        }

        private void SetupDgv(DataGridView dgv)
        {
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadHangSX()
        {
            dgvHangSX.DataSource = KetNoiCSDL.DocBang("SELECT MaHangSX, TenHangSX FROM tblHangSX ORDER BY MaHangSX");
            if (dgvHangSX.Columns.Count >= 2)
            {
                dgvHangSX.Columns[0].HeaderText = "Mã hãng SX";
                dgvHangSX.Columns[1].HeaderText = "Tên hãng SX";
            }
        }

        private void LoadLoai()
        {
            dataGridView1.DataSource = KetNoiCSDL.DocBang("SELECT MaLoai, TenLoai FROM tblLoai ORDER BY MaLoai");
            if (dataGridView1.Columns.Count >= 2)
            {
                dataGridView1.Columns[0].HeaderText = "Mã loại";
                dataGridView1.Columns[1].HeaderText = "Tên loại";
            }
        }

        private void LoadMau()
        {
            dataGridView2.DataSource = KetNoiCSDL.DocBang("SELECT MaMau, TenMau FROM tblMau ORDER BY MaMau");
            if (dataGridView2.Columns.Count >= 2)
            {
                dataGridView2.Columns[0].HeaderText = "Mã màu";
                dataGridView2.Columns[1].HeaderText = "Tên màu";
            }
        }

        private void LoadDungLuong()
        {
            dataGridView3.DataSource = KetNoiCSDL.DocBang("SELECT MaDungLuong, TenDungLuong FROM tblDungLuong ORDER BY MaDungLuong");
            if (dataGridView3.Columns.Count >= 2)
            {
                dataGridView3.Columns[0].HeaderText = "Mã dung lượng";
                dataGridView3.Columns[1].HeaderText = "Tên dung lượng";
            }
        }

        private void ThemDanhMuc(string bang, string cotMa, string cotTen, string ma, string ten, Action reload)
        {
            ma = ma.Trim();
            ten = ten.Trim();
            if (string.IsNullOrWhiteSpace(ma) || string.IsNullOrWhiteSpace(ten))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ mã và tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                object? count = KetNoiCSDL.ThucThiGiaTri($"SELECT COUNT(*) FROM {bang} WHERE {cotMa}=@Ma", new[] { new SqlParameter("@Ma", ma) });
                if (Convert.ToInt32(count) > 0)
                {
                    MessageBox.Show("Mã đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                KetNoiCSDL.ThucThi($"INSERT INTO {bang} ({cotMa}, {cotTen}) VALUES (@Ma, @Ten)",
                    new[] { new SqlParameter("@Ma", ma), new SqlParameter("@Ten", ten) });

                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reload();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm: " + ex.Message);
            }
        }

        private void SuaDanhMuc(string bang, string cotMa, string cotTen, string ma, string ten, Action reload)
        {
            ma = ma.Trim();
            ten = ten.Trim();
            if (string.IsNullOrWhiteSpace(ma) || string.IsNullOrWhiteSpace(ten))
            {
                MessageBox.Show("Vui lòng chọn dòng cần sửa và nhập tên mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                KetNoiCSDL.ThucThi($"UPDATE {bang} SET {cotTen}=@Ten WHERE {cotMa}=@Ma",
                    new[] { new SqlParameter("@Ma", ma), new SqlParameter("@Ten", ten) });

                MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reload();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa: " + ex.Message);
            }
        }

        private void XoaDanhMuc(string bang, string cotMa, string ma, Action reload)
        {
            ma = ma.Trim();
            if (string.IsNullOrWhiteSpace(ma))
            {
                MessageBox.Show("Vui lòng chọn mục cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa mục {ma}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                KetNoiCSDL.ThucThi($"DELETE FROM {bang} WHERE {cotMa}=@Ma", new[] { new SqlParameter("@Ma", ma) });
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reload();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xóa (dữ liệu này đang được dùng trong danh sách hàng): " + ex.Message);
            }
        }
    }
}