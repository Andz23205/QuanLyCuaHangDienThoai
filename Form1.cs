using System.Data;
using System.Globalization;
using Microsoft.Data.SqlClient;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    // FORM 1: Quản lý điện thoại (frmHang) - dùng SQL Server, bảng tblHang
    public partial class Form1 : Form
    {
        private readonly CultureInfo vn = new("vi-VN");
        private string tenAnh = "";   // chỉ lưu TÊN file ảnh vào cột Anh, ảnh nằm trong thư mục Images
        private string ThuMucAnh => Path.Combine(Application.StartupPath, "Images");

        public Form1()
        {
            InitializeComponent();

            // Gắn sự kiện bằng code (KHÔNG nhấp đúp vào nút trong Designer, kẻo nút chạy 2 lần)
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
            txtMaHang.MaxLength = 20;     // khớp độ dài cột trong SQL
            txtTenHang.MaxLength = 100;

            dgvHang.ReadOnly = true;
            dgvHang.AllowUserToAddRows = false;
            dgvHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHang.MultiSelect = false;
            dgvHang.RowHeadersVisible = false;
            dgvHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            try
            {
                NapCombo(cboHang, "tblHangSX", "MaHangSX", "TenHangSX");
                NapCombo(cboLoai, "tblLoai", "MaLoai", "TenLoai");
                NapCombo(cboMau, "tblMau", "MaMau", "TenMau");
                NapCombo(cboDungLuong, "tblDungLuong", "MaDungLuong", "TenDungLuong");
                NapLuoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không kết nối được CSDL. Hãy kiểm tra SQL Server và KetNoiCSDL.cs.\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LamLai();
        }

        // Đổ danh sách từ bảng danh mục: hiện tên, lưu mã
        private static void NapCombo(ComboBox cbo, string bang, string cotMa, string cotTen)
        {
            cbo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo.DataSource = KetNoiCSDL.LayBang($"SELECT {cotMa}, {cotTen} FROM {bang} ORDER BY {cotMa}");
            cbo.ValueMember = cotMa;
            cbo.DisplayMember = cotTen;
            cbo.SelectedIndex = -1;
        }

        private static string ThoatLike(string s) =>
            s.Replace("[", "[[]").Replace("%", "[%]").Replace("_", "[_]");

        private void NapLuoi(string tuKhoa = "")
        {
            dgvHang.DataSource = KetNoiCSDL.LayBang(@"
                SELECT h.MaHang, h.TenHang, s.TenHangSX, l.TenLoai, m.TenMau, d.TenDungLuong,
                       h.DonGiaNhap, h.DonGiaBan, h.SoLuongTon,
                       h.MaHangSX, h.MaLoai, h.MaMau, h.MaDungLuong, h.Anh
                FROM tblHang h
                LEFT JOIN tblHangSX   s ON h.MaHangSX   = s.MaHangSX
                LEFT JOIN tblLoai     l ON h.MaLoai     = l.MaLoai
                LEFT JOIN tblMau      m ON h.MaMau      = m.MaMau
                LEFT JOIN tblDungLuong d ON h.MaDungLuong = d.MaDungLuong
                WHERE h.TenHang LIKE @tk
                ORDER BY h.MaHang",
                KetNoiCSDL.Tham("@tk", "%" + ThoatLike(tuKhoa.Trim()) + "%"));

            var tieuDe = new Dictionary<string, string>
            {
                ["MaHang"] = "Mã hàng",
                ["TenHang"] = "Tên hàng",
                ["TenHangSX"] = "Hãng",
                ["TenLoai"] = "Loại",
                ["TenMau"] = "Màu",
                ["TenDungLuong"] = "Dung lượng",
                ["DonGiaNhap"] = "Giá nhập",
                ["DonGiaBan"] = "Giá bán",
                ["SoLuongTon"] = "SL tồn"
            };
            foreach (var kv in tieuDe) dgvHang.Columns[kv.Key]!.HeaderText = kv.Value;

            // Cột chỉ dùng để đổ lên ô nhập, không hiện trên lưới
            foreach (var cot in new[] { "MaHangSX", "MaLoai", "MaMau", "MaDungLuong", "Anh" })
                dgvHang.Columns[cot]!.Visible = false;

            foreach (var cot in new[] { "DonGiaNhap", "DonGiaBan" })
            {
                dgvHang.Columns[cot]!.DefaultCellStyle.Format = "N0";
                dgvHang.Columns[cot]!.DefaultCellStyle.FormatProvider = vn;
            }
            dgvHang.ClearSelection();
        }

        // ---------- Đổ dữ liệu khi bấm vào dòng ----------
        private void dgvHang_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvHang.Rows[e.RowIndex].DataBoundItem is not DataRowView r) return;

            txtMaHang.Text = r["MaHang"].ToString();
            txtMaHang.ReadOnly = true;                        // khóa chính, không cho sửa
            txtTenHang.Text = r["TenHang"].ToString();
            Chon(cboHang, r["MaHangSX"]);
            Chon(cboLoai, r["MaLoai"]);
            Chon(cboMau, r["MaMau"]);
            Chon(cboDungLuong, r["MaDungLuong"]);
            txtGiaNhap.Text = Convert.ToDecimal(r["DonGiaNhap"]).ToString("N0", vn);
            txtGiaBan.Text = Convert.ToDecimal(r["DonGiaBan"]).ToString("N0", vn);
            txtSoLuong.Text = r["SoLuongTon"].ToString();

            tenAnh = r["Anh"] as string ?? "";
            lblTenAnh.Text = tenAnh;
            HienAnh(tenAnh);
        }

        private static void Chon(ComboBox cbo, object giaTri)
        {
            if (giaTri is string s) cbo.SelectedValue = s;
            else cbo.SelectedIndex = -1;                      // NULL trong CSDL
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

        private SqlParameter[] ThamSo(decimal giaNhap, decimal giaBan, int soLuong) => new[]
        {
            KetNoiCSDL.Tham("@ma", txtMaHang.Text.Trim()),
            KetNoiCSDL.Tham("@ten", txtTenHang.Text.Trim()),
            KetNoiCSDL.Tham("@hang", cboHang.SelectedValue),
            KetNoiCSDL.Tham("@loai", cboLoai.SelectedValue),
            KetNoiCSDL.Tham("@mau", cboMau.SelectedValue),
            KetNoiCSDL.Tham("@dl", cboDungLuong.SelectedIndex < 0 ? null : cboDungLuong.SelectedValue),
            KetNoiCSDL.Tham("@gn", giaNhap),
            KetNoiCSDL.Tham("@gb", giaBan),
            KetNoiCSDL.Tham("@sl", soLuong),
            KetNoiCSDL.Tham("@anh", string.IsNullOrEmpty(tenAnh) ? null : tenAnh)
        };

        // ---------- Thêm / Sửa / Xóa / Làm lại / Tìm ----------
        private void btnThem_Click(object? sender, EventArgs e)
        {
            if (!KiemTra(out var gn, out var gb, out var sl)) return;
            try
            {
                int dem = Convert.ToInt32(KetNoiCSDL.LayGiaTri(
                    "SELECT COUNT(*) FROM tblHang WHERE MaHang = @ma",
                    KetNoiCSDL.Tham("@ma", txtMaHang.Text.Trim())));
                if (dem > 0)
                {
                    Loi("Mã hàng đã tồn tại, hãy nhập mã khác.", txtMaHang);
                    return;
                }
                KetNoiCSDL.ThucThi(@"
                    INSERT INTO tblHang
                        (MaHang, TenHang, MaHangSX, MaLoai, MaMau, MaDungLuong, DonGiaNhap, DonGiaBan, SoLuongTon, Anh)
                    VALUES (@ma, @ten, @hang, @loai, @mau, @dl, @gn, @gb, @sl, @anh)", ThamSo(gn, gb, sl));
                MessageBox.Show("Thêm thành công.");
                NapLuoi();
                LamLai();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm:\n" + ex.Message);
            }
        }

        private void btnSua_Click(object? sender, EventArgs e)
        {
            if (!txtMaHang.ReadOnly)
            {
                MessageBox.Show("Hãy bấm chọn một dòng trong danh sách để sửa.");
                return;
            }
            if (!KiemTra(out var gn, out var gb, out var sl)) return;
            try
            {
                int n = KetNoiCSDL.ThucThi(@"
                    UPDATE tblHang
                    SET TenHang = @ten, MaHangSX = @hang, MaLoai = @loai, MaMau = @mau, MaDungLuong = @dl,
                        DonGiaNhap = @gn, DonGiaBan = @gb, SoLuongTon = @sl, Anh = @anh
                    WHERE MaHang = @ma", ThamSo(gn, gb, sl));
                MessageBox.Show(n > 0 ? "Sửa thành công." : "Không tìm thấy mã hàng cần sửa.");
                NapLuoi();
                LamLai();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa:\n" + ex.Message);
            }
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
            try
            {
                int n = KetNoiCSDL.ThucThi("DELETE FROM tblHang WHERE MaHang = @ma",
                    KetNoiCSDL.Tham("@ma", txtMaHang.Text.Trim()));
                MessageBox.Show(n > 0 ? "Đã xóa." : "Không tìm thấy mã hàng cần xóa.");
                NapLuoi();
                LamLai();
            }
            catch (SqlException ex) when (ex.Number == 547)   // vi phạm khóa ngoại
            {
                MessageBox.Show("Không xóa được: mặt hàng này đã có trong hóa đơn bán hoặc hóa đơn nhập.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa:\n" + ex.Message);
            }
        }

        private void btnLamLai_Click(object? sender, EventArgs e)
        {
            txtTim.Clear();
            try { NapLuoi(); }
            catch (Exception ex) { MessageBox.Show("Lỗi khi tải danh sách:\n" + ex.Message); }
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
            try
            {
                NapLuoi(txtTim.Text);
                if (dgvHang.Rows.Count == 0)
                    MessageBox.Show("Không tìm thấy mặt hàng nào.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm:\n" + ex.Message);
            }
        }
    }
}