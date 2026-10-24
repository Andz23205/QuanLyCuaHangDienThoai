using System.Data;
using System.Globalization;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    // FORM 1: Quản lý điện thoại (frmHang) - bản KHÔNG dùng SQL
    public partial class Form1 : Form
    {
        private readonly CultureInfo vn = new("vi-VN");
        private readonly DataView dvHang = new(DuLieuTam.Hang);
        private string tenAnh = "";   // chỉ lưu tên file, ví dụ iphone15.jpg
        private string ThuMucAnh => Path.Combine(Application.StartupPath, "Images");

        public Form1()
        {
            InitializeComponent();

            // Gắn sự kiện bằng code (KHÔNG nhấp đúp vào nút trong Designer, kẻo bị chạy 2 lần)
            Load += Form1_Load;
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamLai.Click += btnLamLai_Click;
            btnThoat.Click += (s, e) => Close();
            btnChonAnh.Click += btnChonAnh_Click;
            btnTim.Click += btnTim_Click;
            dgvHang.CellClick += dgvHang_CellClick;
        }

        // ---------- Khởi tạo ----------
        private void Form1_Load(object? sender, EventArgs e)
        {
            NapCombo(cboHang, DuLieuTam.DanhSachHang);
            NapCombo(cboLoai, DuLieuTam.DanhSachLoai);
            NapCombo(cboMau, DuLieuTam.DanhSachMau);
            NapCombo(cboDungLuong, DuLieuTam.DanhSachDungLuong);

            dgvHang.ReadOnly = true;
            dgvHang.AllowUserToAddRows = false;
            dgvHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHang.MultiSelect = false;
            dgvHang.RowHeadersVisible = false;
            dgvHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dvHang.Sort = "MaHang";
            dgvHang.DataSource = dvHang;

            var tieuDe = new Dictionary<string, string>
            {
                ["MaHang"] = "Mã hàng",
                ["TenHang"] = "Tên hàng",
                ["Hang"] = "Hãng",
                ["Loai"] = "Loại",
                ["Mau"] = "Màu",
                ["DungLuong"] = "Dung lượng",
                ["GiaNhap"] = "Giá nhập",
                ["GiaBan"] = "Giá bán",
                ["SoLuong"] = "SL"
            };
            foreach (var kv in tieuDe) dgvHang.Columns[kv.Key]!.HeaderText = kv.Value;
            dgvHang.Columns["Anh"]!.Visible = false;
            foreach (var cot in new[] { "GiaNhap", "GiaBan" })
            {
                dgvHang.Columns[cot]!.DefaultCellStyle.Format = "N0";
                dgvHang.Columns[cot]!.DefaultCellStyle.FormatProvider = vn;
            }
            LamLai();
        }

        private static void NapCombo(ComboBox cbo, string[] ds)
        {
            cbo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo.Items.Clear();
            cbo.Items.AddRange(ds);
            cbo.SelectedIndex = -1;
        }

        // ---------- Đổ dữ liệu khi bấm vào dòng ----------
        private void dgvHang_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvHang.Rows[e.RowIndex].DataBoundItem is not DataRowView r) return;

            txtMaHang.Text = r["MaHang"].ToString();
            txtMaHang.ReadOnly = true;                        // khóa chính, không cho sửa
            txtTenHang.Text = r["TenHang"].ToString();
            Chon(cboHang, r["Hang"]);
            Chon(cboLoai, r["Loai"]);
            Chon(cboMau, r["Mau"]);
            Chon(cboDungLuong, r["DungLuong"]);
            txtGiaNhap.Text = Convert.ToDecimal(r["GiaNhap"]).ToString("N0", vn);
            txtGiaBan.Text = Convert.ToDecimal(r["GiaBan"]).ToString("N0", vn);
            txtSoLuong.Text = r["SoLuong"].ToString();

            tenAnh = r["Anh"] as string ?? "";
            lblTenAnh.Text = tenAnh;
            HienAnh(tenAnh);
        }

        private static void Chon(ComboBox cbo, object giaTri)
        {
            if (giaTri is string s) cbo.SelectedItem = s;
            else cbo.SelectedIndex = -1;
        }

        // ---------- Ảnh ----------
        private void btnChonAnh_Click(object? sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog
            {
                Title = "Chọn ảnh điện thoại",
                Filter = "Ảnh|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
            };
            if (ofd.ShowDialog() != DialogResult.OK) return;

            try
            {
                Directory.CreateDirectory(ThuMucAnh);
                string ten = Path.GetFileName(ofd.FileName);
                string dich = Path.Combine(ThuMucAnh, ten);
                if (!string.Equals(Path.GetFullPath(ofd.FileName), Path.GetFullPath(dich),
                        StringComparison.OrdinalIgnoreCase))
                    File.Copy(ofd.FileName, dich, true);

                tenAnh = ten;
                lblTenAnh.Text = ten;
                HienAnh(ten);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không chọn được ảnh:\n" + ex.Message);
            }
        }

        private void HienAnh(string ten)
        {
            picAnh.Image?.Dispose();
            picAnh.Image = null;
            picAnh.SizeMode = PictureBoxSizeMode.Zoom;
            if (string.IsNullOrEmpty(ten)) return;

            string p = Path.Combine(ThuMucAnh, ten);
            if (!File.Exists(p)) return;

            // Đọc qua stream rồi copy để không bị khóa file ảnh
            using var fs = new FileStream(p, FileMode.Open, FileAccess.Read);
            using var img = Image.FromStream(fs);
            picAnh.Image = new Bitmap(img);
        }

        // ---------- Kiểm tra dữ liệu ----------
        private static bool DocTien(string s, out decimal kq)
            => decimal.TryParse(s.Replace(".", "").Replace(",", "").Trim(), NumberStyles.None,
                                CultureInfo.InvariantCulture, out kq);

        private static void Loi(string noiDung, Control c)
        {
            MessageBox.Show(noiDung, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            c.Focus();
        }

        private static object OrNull(string? s) => string.IsNullOrEmpty(s) ? DBNull.Value : s;

        private bool KiemTra(out decimal giaNhap, out decimal giaBan, out int soLuong)
        {
            giaNhap = giaBan = 0; soLuong = 0;
            if (string.IsNullOrWhiteSpace(txtMaHang.Text)) { Loi("Chưa nhập mã hàng.", txtMaHang); return false; }
            if (string.IsNullOrWhiteSpace(txtTenHang.Text)) { Loi("Chưa nhập tên hàng.", txtTenHang); return false; }
            if (cboHang.SelectedIndex < 0) { Loi("Chưa chọn hãng sản xuất.", cboHang); return false; }
            if (cboLoai.SelectedIndex < 0) { Loi("Chưa chọn loại hàng.", cboLoai); return false; }
            if (cboMau.SelectedIndex < 0) { Loi("Chưa chọn màu sắc.", cboMau); return false; }
            if (!DocTien(txtGiaNhap.Text, out giaNhap)) { Loi("Giá nhập phải là số không âm.", txtGiaNhap); return false; }
            if (!DocTien(txtGiaBan.Text, out giaBan)) { Loi("Giá bán phải là số không âm.", txtGiaBan); return false; }
            if (!int.TryParse(txtSoLuong.Text.Trim(), out soLuong) || soLuong < 0)
            { Loi("Số lượng tồn phải là số nguyên không âm.", txtSoLuong); return false; }
            return true;
        }

        // ---------- Thêm / Sửa / Xóa / Làm lại / Tìm ----------
        private void btnThem_Click(object? sender, EventArgs e)
        {
            if (!KiemTra(out var gn, out var gb, out var sl)) return;
            string ma = txtMaHang.Text.Trim();
            if (DuLieuTam.Hang.Rows.Find(ma) != null)
            {
                Loi("Mã hàng đã tồn tại, hãy nhập mã khác.", txtMaHang);
                return;
            }
            DuLieuTam.Hang.Rows.Add(ma, txtTenHang.Text.Trim(), cboHang.Text, cboLoai.Text, cboMau.Text,
                OrNull(cboDungLuong.SelectedIndex < 0 ? null : cboDungLuong.Text), gn, gb, sl, OrNull(tenAnh));
            MessageBox.Show("Thêm thành công.");
            LamLai();
        }

        private void btnSua_Click(object? sender, EventArgs e)
        {
            if (!txtMaHang.ReadOnly)
            {
                MessageBox.Show("Hãy bấm chọn một dòng trong danh sách để sửa.");
                return;
            }
            if (!KiemTra(out var gn, out var gb, out var sl)) return;

            var row = DuLieuTam.Hang.Rows.Find(txtMaHang.Text.Trim());
            if (row == null) { MessageBox.Show("Không tìm thấy mã hàng cần sửa."); return; }

            row["TenHang"] = txtTenHang.Text.Trim();
            row["Hang"] = cboHang.Text;
            row["Loai"] = cboLoai.Text;
            row["Mau"] = cboMau.Text;
            row["DungLuong"] = OrNull(cboDungLuong.SelectedIndex < 0 ? null : cboDungLuong.Text);
            row["GiaNhap"] = gn;
            row["GiaBan"] = gb;
            row["SoLuong"] = sl;
            row["Anh"] = OrNull(tenAnh);
            MessageBox.Show("Sửa thành công.");
            LamLai();
        }

        private void btnXoa_Click(object? sender, EventArgs e)
        {
            if (!txtMaHang.ReadOnly)
            {
                MessageBox.Show("Hãy bấm chọn một dòng trong danh sách để xóa.");
                return;
            }
            if (MessageBox.Show($"Xóa mặt hàng {txtMaHang.Text}?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            var row = DuLieuTam.Hang.Rows.Find(txtMaHang.Text.Trim());
            if (row == null) { MessageBox.Show("Không tìm thấy mã hàng cần xóa."); return; }

            DuLieuTam.Hang.Rows.Remove(row);
            MessageBox.Show("Đã xóa.");
            LamLai();
        }

        private void btnLamLai_Click(object? sender, EventArgs e)
        {
            txtTim.Clear();
            dvHang.RowFilter = "";
            LamLai();
        }

        private void LamLai()
        {
            txtMaHang.ReadOnly = false;
            txtMaHang.Clear();
            txtTenHang.Clear();
            txtGiaNhap.Clear();
            txtGiaBan.Clear();
            txtSoLuong.Clear();
            cboHang.SelectedIndex = -1;
            cboLoai.SelectedIndex = -1;
            cboMau.SelectedIndex = -1;
            cboDungLuong.SelectedIndex = -1;
            tenAnh = "";
            lblTenAnh.Text = "";
            HienAnh("");
            dgvHang.ClearSelection();
            txtMaHang.Focus();
        }

        private void btnTim_Click(object? sender, EventArgs e)
        {
            string tk = txtTim.Text.Trim();
            dvHang.RowFilter = tk.Length == 0 ? "" : $"TenHang LIKE '%{DuLieuTam.ThoatLike(tk)}%'";
            if (dvHang.Count == 0)
                MessageBox.Show("Không tìm thấy mặt hàng nào.");
        }
    }
}