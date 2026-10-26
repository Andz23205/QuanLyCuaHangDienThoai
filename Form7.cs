using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    public partial class Form7 : Form
    {
        private readonly DataTable bangChiTiet = new DataTable();
        private bool hoaDonDaTonTai = false;

        public Form7()
        {
            InitializeComponent();

            // Tao bang chi tiet hoa don
            bangChiTiet.Columns.Add("MaHang", typeof(string));
            bangChiTiet.Columns.Add("TenHang", typeof(string));
            bangChiTiet.Columns.Add("DonGia", typeof(decimal));
            bangChiTiet.Columns.Add("SoLuong", typeof(int));
            bangChiTiet.Columns.Add("GiamGia", typeof(decimal));
            bangChiTiet.Columns.Add("ThanhTien", typeof(decimal));

            dgvChiTiet.DataSource = bangChiTiet;
            dgvChiTiet.AllowUserToAddRows = false;
            dgvChiTiet.ReadOnly = true;
            dgvChiTiet.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvChiTiet.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            // Cau hinh cac o chi doc
            txtTenHang.ReadOnly = true;
            txtDonGia.ReadOnly = true;
            txtThanhTien.ReadOnly = true;
            txtTenNV.ReadOnly = true;
            txtTenKH.ReadOnly = true;
            txtSDT.ReadOnly = true;
            txtDiaChi.ReadOnly = true;

            // Cho phep nhap ma de tim nhanh
            txtMaNV.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtMaNV.AutoCompleteSource = AutoCompleteSource.CustomSource;

            txtMaKH.ReadOnly = false;
            txtMaKH.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtMaKH.AutoCompleteSource = AutoCompleteSource.CustomSource;

            cboMaHang.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMaHD.DropDownStyle = ComboBoxStyle.DropDown;

            // Gan su kien: go bo truoc de tranh xu ly hai lan
            cboMaHang.SelectedIndexChanged -= cboMaHang_SelectedIndexChanged;
            cboMaHang.SelectedIndexChanged += cboMaHang_SelectedIndexChanged;

            txtSoLuong.TextChanged -= txtSoLuong_TextChanged;
            txtSoLuong.TextChanged += txtSoLuong_TextChanged;

            txtGiamGia.TextChanged -= txtGiamGia_TextChanged;
            txtGiamGia.TextChanged += txtGiamGia_TextChanged;

            txtMaNV.TextChanged -= txtMaNV_TextChanged;
            txtMaNV.TextChanged += txtMaNV_TextChanged;

            txtMaKH.TextChanged -= txtMaKH_TextChanged;
            txtMaKH.TextChanged += txtMaKH_TextChanged;

            btnThemHang.Click -= btnThemHang_Click;
            btnThemHang.Click += btnThemHang_Click;

            btnThemHD.Click -= btnThemHD_Click;
            btnThemHD.Click += btnThemHD_Click;

            btnHuy.Click -= btnHuy_Click;
            btnHuy.Click += btnHuy_Click;

            btnLuu.Click -= btnLuu_Click;
            btnLuu.Click += btnLuu_Click;

            btnTim.Click -= btnTim_Click;
            btnTim.Click += btnTim_Click;

            btnThoat.Click -= btnThoat_Click;
            btnThoat.Click += btnThoat_Click;

            btnIn.Click -= btnIn_Click;
            btnIn.Click += btnIn_Click;

            dgvChiTiet.CellClick -= dgvChiTiet_CellClick;
            dgvChiTiet.CellClick += dgvChiTiet_CellClick;

            dtpNgayLap.Value = DateTime.Today;
            lblTongTien.Text = "Tổng tiền: 0 VNĐ";

            NapDanhSachNhanVien();
            NapDanhSachKhachHang();
            NapDanhSachHang();
            NapDanhSachHoaDon();
        }

        // =========================
        // HAM KET NOI VA DOC DU LIEU
        // =========================

        private void NapDanhSachNhanVien()
        {
            try
            {
                AutoCompleteStringCollection danhSach =
                    new AutoCompleteStringCollection();

                using (SqlConnection conn = KetNoiCSDL.TaoKetNoi())
                {
                    conn.Open();

                    string sql =
                        "SELECT MaNV FROM tblNhanVien ORDER BY MaNV";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            danhSach.Add(reader["MaNV"].ToString());
                        }
                    }
                }

                txtMaNV.AutoCompleteCustomSource = danhSach;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không tải được danh sách nhân viên:\n" + ex.Message);
            }
        }

        private void NapDanhSachKhachHang()
        {
            try
            {
                AutoCompleteStringCollection danhSach =
                    new AutoCompleteStringCollection();

                using (SqlConnection conn = KetNoiCSDL.TaoKetNoi())
                {
                    conn.Open();

                    string sql =
                        "SELECT MaKH FROM tblKhachHang ORDER BY MaKH";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            danhSach.Add(reader["MaKH"].ToString());
                        }
                    }
                }

                txtMaKH.AutoCompleteCustomSource = danhSach;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không tải được danh sách khách hàng:\n" + ex.Message);
            }
        }

        private void NapDanhSachHang()
        {
            try
            {
                using (SqlConnection conn = KetNoiCSDL.TaoKetNoi())
                {
                    conn.Open();

                    string sql =
                        "SELECT MaHang FROM tblHang ORDER BY MaHang";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        cboMaHang.Items.Clear();

                        while (reader.Read())
                        {
                            cboMaHang.Items.Add(reader["MaHang"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không tải được danh sách hàng hóa:\n" + ex.Message);
            }
        }

        private void NapDanhSachHoaDon()
        {
            try
            {
                using (SqlConnection conn = KetNoiCSDL.TaoKetNoi())
                {
                    conn.Open();

                    string sql =
                        "SELECT MaHDB FROM tblHoaDonBan ORDER BY MaHDB DESC";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        cboMaHD.Items.Clear();

                        while (reader.Read())
                        {
                            cboMaHD.Items.Add(reader["MaHDB"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không tải được danh sách hóa đơn:\n" + ex.Message);
            }
        }

        // =========================
        // CHON NHAN VIEN
        // =========================

        private void txtMaNV_TextChanged(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text.Trim();

            if (maNV == "")
            {
                txtTenNV.Clear();
                return;
            }

            try
            {
                using (SqlConnection conn = KetNoiCSDL.TaoKetNoi())
                {
                    conn.Open();

                    string sql =
                        "SELECT TenNV FROM tblNhanVien WHERE MaNV = @MaNV";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaNV", maNV);

                        object ketQua = cmd.ExecuteScalar();

                        txtTenNV.Text =
                            ketQua == null || ketQua == DBNull.Value
                            ? ""
                            : ketQua.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không lấy được thông tin nhân viên:\n" + ex.Message);
            }
        }

        // =========================
        // CHON KHACH HANG
        // =========================

        private void txtMaKH_TextChanged(object sender, EventArgs e)
        {
            string maKH = txtMaKH.Text.Trim();

            if (maKH == "")
            {
                txtTenKH.Clear();
                txtSDT.Clear();
                txtDiaChi.Clear();
                return;
            }

            try
            {
                using (SqlConnection conn = KetNoiCSDL.TaoKetNoi())
                {
                    conn.Open();

                    string sql = @"
                        SELECT TenKH, SDT, DiaChi
                        FROM tblKhachHang
                        WHERE MaKH = @MaKH";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaKH", maKH);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtTenKH.Text = reader["TenKH"].ToString();
                                txtSDT.Text = reader["SDT"].ToString();
                                txtDiaChi.Text = reader["DiaChi"].ToString();
                            }
                            else
                            {
                                txtTenKH.Clear();
                                txtSDT.Clear();
                                txtDiaChi.Clear();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không lấy được thông tin khách hàng:\n" + ex.Message);
            }
        }

        // =========================
        // CHON HANG HOA
        // =========================

        private void cboMaHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maHang = cboMaHang.Text.Trim();

            if (maHang == "")
            {
                txtTenHang.Clear();
                txtDonGia.Clear();
                txtThanhTien.Clear();
                return;
            }

            try
            {
                using (SqlConnection conn = KetNoiCSDL.TaoKetNoi())
                {
                    conn.Open();

                    string sql = @"
                        SELECT TenHang, DonGiaBan
                        FROM tblHang
                        WHERE MaHang = @MaHang";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaHang", maHang);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtTenHang.Text = reader["TenHang"].ToString();

                                decimal gia =
                                    Convert.ToDecimal(reader["DonGiaBan"]);

                                txtDonGia.Text = gia.ToString("N0");
                            }
                            else
                            {
                                txtTenHang.Clear();
                                txtDonGia.Clear();
                            }
                        }
                    }
                }

                TinhThanhTien();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không lấy được thông tin hàng hóa:\n" + ex.Message);
            }
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            TinhThanhTien();
        }

        private void txtGiamGia_TextChanged(object sender, EventArgs e)
        {
            TinhThanhTien();
        }

        // Doc so tien, ho tro dinh dang hien thi co dau phan cach
        private bool DocSoTien(string chuoi, out decimal giaTri)
        {
            chuoi = chuoi.Trim();

            if (decimal.TryParse(
                chuoi,
                NumberStyles.Number,
                CultureInfo.CurrentCulture,
                out giaTri))
            {
                return true;
            }

            return decimal.TryParse(
                chuoi,
                NumberStyles.Number,
                CultureInfo.InvariantCulture,
                out giaTri);
        }

        private void TinhThanhTien()
        {
            decimal donGia, giamGia;
            int soLuong;

            if (DocSoTien(txtDonGia.Text, out donGia) &&
                int.TryParse(txtSoLuong.Text, out soLuong) &&
                DocSoTien(txtGiamGia.Text, out giamGia) &&
                soLuong > 0 &&
                giamGia >= 0 &&
                giamGia <= 100)
            {
                decimal thanhTien =
                    donGia * soLuong * (100 - giamGia) / 100;

                txtThanhTien.Text = thanhTien.ToString("N0");
            }
            else
            {
                txtThanhTien.Clear();
            }
        }

        // =========================
        // THEM MAT HANG
        // =========================

        private void btnThemHang_Click(object sender, EventArgs e)
        {
            if (hoaDonDaTonTai)
            {
                MessageBox.Show(
                    "Đây là hóa đơn đã lưu. Hãy bấm Thêm hóa đơn để lập hóa đơn mới.");
                return;
            }

            string maHang = cboMaHang.Text.Trim();

            if (maHang == "" || txtTenHang.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn mã hàng!");
                return;
            }

            if (!int.TryParse(txtSoLuong.Text, out int soLuong) ||
                soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên lớn hơn 0!");
                return;
            }

            if (!DocSoTien(txtGiamGia.Text, out decimal giamGia) ||
                giamGia < 0 || giamGia > 100)
            {
                MessageBox.Show("Giảm giá phải từ 0 đến 100%!");
                return;
            }

            if (!DocSoTien(txtDonGia.Text, out decimal donGia))
            {
                MessageBox.Show("Đơn giá không hợp lệ!");
                return;
            }

            // Neu ma hang da co thi cong them so luong
            foreach (DataRow row in bangChiTiet.Rows)
            {
                if (row["MaHang"].ToString() == maHang)
                {
                    int soLuongMoi =
                        Convert.ToInt32(row["SoLuong"]) + soLuong;

                    decimal giamGiaCu =
                        Convert.ToDecimal(row["GiamGia"]);

                    if (giamGia != giamGiaCu)
                    {
                        MessageBox.Show(
                            "Mặt hàng này đã có trong hóa đơn với mức giảm giá khác. " +
                            "Hãy xóa dòng cũ trước khi thêm lại.");
                        return;
                    }

                    row["SoLuong"] = soLuongMoi;
                    row["ThanhTien"] =
                        donGia * soLuongMoi * (100 - giamGia) / 100;

                    TinhTongTien();
                    XoaThongTinHangDangChon();
                    return;
                }
            }

            decimal thanhTien =
                donGia * soLuong * (100 - giamGia) / 100;

            bangChiTiet.Rows.Add(
                maHang,
                txtTenHang.Text,
                donGia,
                soLuong,
                giamGia,
                thanhTien);

            TinhTongTien();
            XoaThongTinHangDangChon();
        }

        private void XoaThongTinHangDangChon()
        {
            cboMaHang.SelectedIndex = -1;
            txtTenHang.Clear();
            txtDonGia.Clear();
            txtSoLuong.Clear();
            txtGiamGia.Clear();
            txtThanhTien.Clear();
        }

        private void TinhTongTien()
        {
            decimal tongTien = 0;

            foreach (DataRow row in bangChiTiet.Rows)
            {
                tongTien += Convert.ToDecimal(row["ThanhTien"]);
            }

            lblTongTien.Text =
                "Tổng tiền: " + tongTien.ToString("N0") + " VNĐ";
        }

        // =========================
        // TAO HOA DON MOI
        // =========================

        private void btnThemHD_Click(object sender, EventArgs e)
        {
            DialogResult xacNhan = MessageBox.Show(
                "Tạo hóa đơn mới? Các mặt hàng chưa lưu hiện tại sẽ bị xóa.",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (xacNhan != DialogResult.Yes)
                return;

            bangChiTiet.Rows.Clear();

            txtMaNV.Clear();
            txtTenNV.Clear();
            txtMaKH.Clear();
            txtTenKH.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();

            XoaThongTinHangDangChon();

            cboMaHD.Text = "HDB_" +
                DateTime.Now.ToString("yyyyMMddHHmmssfff");

            dtpNgayLap.Value = DateTime.Now;

            hoaDonDaTonTai = false;
            TinhTongTien();

            MessageBox.Show(
                "Đã tạo hóa đơn mới. Hãy chọn mã nhân viên, khách hàng (nếu có) và mặt hàng.");
        }

        // =========================
        // HUY CAC MAT HANG DANG LAP
        // =========================

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (hoaDonDaTonTai)
            {
                MessageBox.Show(
                    "Đây là hóa đơn đã lưu. Chức năng này không xóa hóa đơn trong CSDL.");
                return;
            }

            DialogResult xacNhan = MessageBox.Show(
                "Bạn có chắc muốn xóa tất cả mặt hàng đang lập?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (xacNhan == DialogResult.Yes)
            {
                bangChiTiet.Rows.Clear();
                TinhTongTien();
            }
        }

        // =========================
        // LUU HOA DON VA CHI TIET
        // =========================


        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (hoaDonDaTonTai)
            {
                MessageBox.Show(
                    "Hóa đơn này đã được lưu. Hãy tạo hóa đơn mới nếu muốn lập hóa đơn khác.");
                return;
            }

            string maHD = cboMaHD.Text.Trim();
            string maNV = txtMaNV.Text.Trim();
            string maKH = txtMaKH.Text.Trim();

            if (maHD == "")
            {
                MessageBox.Show("Vui lòng tạo mã hóa đơn!");
                return;
            }

            if (maNV == "" || txtTenNV.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn mã nhân viên hợp lệ!");
                txtMaNV.Focus();
                return;
            }

            if (maKH != "" && txtTenKH.Text.Trim() == "")
            {
                MessageBox.Show("Mã khách hàng không hợp lệ!");
                txtMaKH.Focus();
                return;
            }

            if (bangChiTiet.Rows.Count == 0)
            {
                MessageBox.Show("Hóa đơn chưa có mặt hàng!");
                return;
            }

            decimal tongTien = 0;

            foreach (DataRow row in bangChiTiet.Rows)
            {
                tongTien += Convert.ToDecimal(row["ThanhTien"]);
            }

            try
            {
                using (SqlConnection conn = KetNoiCSDL.TaoKetNoi())
                {
                    conn.Open();

                    using (SqlTransaction tran = conn.BeginTransaction())
                    {
                        try
                        {
                            // 1. Kiem tra ma hoa don da ton tai chua
                            string sqlKiemTra =
                                "SELECT COUNT(*) FROM tblHoaDonBan WHERE MaHDB = @MaHD";

                            using (SqlCommand cmd =
                                new SqlCommand(sqlKiemTra, conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@MaHD", maHD);

                                if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                                {
                                    throw new Exception(
                                        "Mã hóa đơn đã tồn tại. Hãy tạo mã mới.");
                                }
                            }

                            // 2. Kiem tra va tru ton kho
                            // UPDATE co dieu kien giup tranh ban vuot ton kho
                            string sqlTruKho = @"
                        UPDATE tblHang
                        SET SoLuongTon = SoLuongTon - @SoLuong
                        WHERE MaHang = @MaHang
                          AND SoLuongTon >= @SoLuong";

                            foreach (DataRow row in bangChiTiet.Rows)
                            {
                                using (SqlCommand cmd =
                                    new SqlCommand(sqlTruKho, conn, tran))
                                {
                                    cmd.Parameters.AddWithValue(
                                        "@MaHang", row["MaHang"]);

                                    cmd.Parameters.AddWithValue(
                                        "@SoLuong", row["SoLuong"]);

                                    int soDong = cmd.ExecuteNonQuery();

                                    if (soDong == 0)
                                    {
                                        throw new Exception(
                                            "Mặt hàng " + row["MaHang"] +
                                            " không tồn tại hoặc số lượng tồn kho không đủ. " +
                                            "Hóa đơn chưa được lưu.");
                                    }
                                }
                            }

                            // 3. Luu hoa don ban
                            string sqlHoaDon = @"
                        INSERT INTO tblHoaDonBan
                            (MaHDB, MaNV, MaKH, NgayLap, TongTien)
                        VALUES
                            (@MaHD, @MaNV, @MaKH, @NgayLap, @TongTien)";

                            using (SqlCommand cmd =
                                new SqlCommand(sqlHoaDon, conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@MaHD", maHD);
                                cmd.Parameters.AddWithValue("@MaNV", maNV);

                                cmd.Parameters.AddWithValue(
                                    "@MaKH",
                                    maKH == "" ? (object)DBNull.Value : maKH);

                                cmd.Parameters.AddWithValue(
                                    "@NgayLap", dtpNgayLap.Value);

                                cmd.Parameters.AddWithValue(
                                    "@TongTien", tongTien);

                                cmd.ExecuteNonQuery();
                            }

                            // 4. Luu chi tiet hoa don
                            string sqlChiTiet = @"
                        INSERT INTO tblChiTietHDB
                            (MaHDB, MaHang, SoLuong, DonGia, GiamGia, ThanhTien)
                        VALUES
                            (@MaHD, @MaHang, @SoLuong, @DonGia, @GiamGia, @ThanhTien)";

                            foreach (DataRow row in bangChiTiet.Rows)
                            {
                                using (SqlCommand cmd =
                                    new SqlCommand(sqlChiTiet, conn, tran))
                                {
                                    cmd.Parameters.AddWithValue("@MaHD", maHD);
                                    cmd.Parameters.AddWithValue(
                                        "@MaHang", row["MaHang"]);
                                    cmd.Parameters.AddWithValue(
                                        "@SoLuong", row["SoLuong"]);
                                    cmd.Parameters.AddWithValue(
                                        "@DonGia", row["DonGia"]);
                                    cmd.Parameters.AddWithValue(
                                        "@GiamGia", row["GiamGia"]);
                                    cmd.Parameters.AddWithValue(
                                        "@ThanhTien", row["ThanhTien"]);

                                    cmd.ExecuteNonQuery();
                                }
                            }

                            // 5. Chi xac nhan khi tat ca thao tac thanh cong
                            tran.Commit();
                        }
                        catch
                        {
                            tran.Rollback();
                            throw;
                        }
                    }
                }

                hoaDonDaTonTai = true;
                NapDanhSachHoaDon();

                MessageBox.Show(
                    "Lưu hóa đơn thành công!\nTồn kho đã được cập nhật.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lưu hóa đơn thất bại:\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // =========================
        // TIM HOA DON DA LUU
        // =========================

        private void btnTim_Click(object sender, EventArgs e)
        {
            string maHD = cboMaHD.Text.Trim();

            if (maHD == "")
            {
                MessageBox.Show("Vui lòng nhập hoặc chọn mã hóa đơn cần tìm!");
                return;
            }

            try
            {
                using (SqlConnection conn = KetNoiCSDL.TaoKetNoi())
                {
                    conn.Open();

                    string sqlHoaDon = @"
                        SELECT h.MaHDB, h.MaNV, n.TenNV,
                               h.MaKH, k.TenKH, k.SDT, k.DiaChi,
                               h.NgayLap
                        FROM tblHoaDonBan h
                        INNER JOIN tblNhanVien n ON h.MaNV = n.MaNV
                        LEFT JOIN tblKhachHang k ON h.MaKH = k.MaKH
                        WHERE h.MaHDB = @MaHD";

                    using (SqlCommand cmd =
                        new SqlCommand(sqlHoaDon, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaHD", maHD);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                MessageBox.Show("Không tìm thấy hóa đơn này.");
                                return;
                            }

                            txtMaNV.Text = reader["MaNV"].ToString();
                            txtTenNV.Text = reader["TenNV"].ToString();
                            txtMaKH.Text = reader["MaKH"] == DBNull.Value
                                ? ""
                                : reader["MaKH"].ToString();

                            txtTenKH.Text = reader["TenKH"] == DBNull.Value
                                ? ""
                                : reader["TenKH"].ToString();

                            txtSDT.Text = reader["SDT"] == DBNull.Value
                                ? ""
                                : reader["SDT"].ToString();

                            txtDiaChi.Text = reader["DiaChi"] == DBNull.Value
                                ? ""
                                : reader["DiaChi"].ToString();

                            dtpNgayLap.Value =
                                Convert.ToDateTime(reader["NgayLap"]);
                        }
                    }

                    bangChiTiet.Rows.Clear();

                    string sqlChiTiet = @"
                        SELECT ct.MaHang, h.TenHang, ct.DonGia,
                               ct.SoLuong, ct.GiamGia, ct.ThanhTien
                        FROM tblChiTietHDB ct
                        INNER JOIN tblHang h ON ct.MaHang = h.MaHang
                        WHERE ct.MaHDB = @MaHD";

                    using (SqlCommand cmd =
                        new SqlCommand(sqlChiTiet, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaHD", maHD);

                        using (SqlDataAdapter adapter =
                            new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            foreach (DataRow row in dt.Rows)
                            {
                                bangChiTiet.Rows.Add(
                                    row["MaHang"],
                                    row["TenHang"],
                                    row["DonGia"],
                                    row["SoLuong"],
                                    row["GiamGia"],
                                    row["ThanhTien"]);
                            }
                        }
                    }
                }

                cboMaHD.Text = maHD;
                hoaDonDaTonTai = true;
                TinhTongTien();

                MessageBox.Show("Tìm thấy hóa đơn!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tìm hóa đơn:\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================
        // XOA MOT DONG CHI TIET
        // =========================

        private void dgvChiTiet_CellClick(
            object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 ||
                e.RowIndex >= bangChiTiet.Rows.Count)
                return;

            if (hoaDonDaTonTai)
            {
                MessageBox.Show(
                    "Đây là hóa đơn đã lưu. Không thể xóa dòng trực tiếp trên giao diện.");
                return;
            }

            DialogResult xacNhan = MessageBox.Show(
                "Bạn có muốn xóa mặt hàng này khỏi hóa đơn đang lập?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (xacNhan == DialogResult.Yes)
            {
                bangChiTiet.Rows.RemoveAt(e.RowIndex);
                TinhTongTien();
            }
        }

        // =========================
        // IN HOA DON
        // =========================


        private void btnIn_Click(object sender, EventArgs e)
        {
            if (bangChiTiet.Rows.Count == 0)
            {
                MessageBox.Show("Hóa đơn chưa có mặt hàng để xuất!");
                return;
            }

            string maHD = cboMaHD.Text.Trim();

            if (maHD == "")
            {
                MessageBox.Show("Vui lòng tạo hoặc tìm hóa đơn trước!");
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
                sfd.FileName = "HoaDon_" + maHD + ".xlsx";
                sfd.Title = "Lưu hóa đơn Excel";

                if (sfd.ShowDialog() != DialogResult.OK)
                    return;

                Excel.Application excelApp = null;
                Excel.Workbook workbook = null;
                Excel.Worksheet sheet = null;

                try
                {
                    excelApp = new Excel.Application();
                    workbook = excelApp.Workbooks.Add();
                    sheet = (Excel.Worksheet)workbook.Worksheets[1];

                    // Tieu de
                    sheet.Cells[1, 1] = "HÓA ĐƠN BÁN HÀNG";
                    Excel.Range title = sheet.Range["A1", "G1"];
                    title.Merge();
                    title.Font.Bold = true;
                    title.Font.Size = 16;
                    title.HorizontalAlignment =
                        Excel.XlHAlign.xlHAlignCenter;

                    // Thong tin hoa don
                    sheet.Cells[3, 1] = "Mã hóa đơn:";
                    sheet.Cells[3, 2] = maHD;
                    sheet.Cells[4, 1] = "Ngày lập:";
                    sheet.Cells[4, 2] = dtpNgayLap.Value.ToString("dd/MM/yyyy");

                    sheet.Cells[5, 1] = "Mã nhân viên:";
                    sheet.Cells[5, 2] = txtMaNV.Text;
                    sheet.Cells[6, 1] = "Tên nhân viên:";
                    sheet.Cells[6, 2] = txtTenNV.Text;

                    sheet.Cells[5, 4] = "Mã khách hàng:";
                    sheet.Cells[5, 5] = txtMaKH.Text;
                    sheet.Cells[6, 4] = "Tên khách hàng:";
                    sheet.Cells[6, 5] = txtTenKH.Text;
                    sheet.Cells[7, 4] = "SĐT khách:";
                    sheet.Cells[7, 5] = txtSDT.Text;
                    sheet.Cells[8, 4] = "Địa chỉ:";
                    sheet.Cells[8, 5] = txtDiaChi.Text;

                    // Tieu de bang chi tiet
                    int dongTieuDe = 10;

                    sheet.Cells[dongTieuDe, 1] = "Mã hàng";
                    sheet.Cells[dongTieuDe, 2] = "Tên hàng";
                    sheet.Cells[dongTieuDe, 3] = "Đơn giá";
                    sheet.Cells[dongTieuDe, 4] = "Số lượng";
                    sheet.Cells[dongTieuDe, 5] = "Giảm giá (%)";
                    sheet.Cells[dongTieuDe, 6] = "Thành tiền";

                    Excel.Range header = sheet.Range[
                        "A" + dongTieuDe, "F" + dongTieuDe];

                    header.Font.Bold = true;
                    header.Interior.Color =
                        System.Drawing.Color.LightGray;
                    header.Borders.LineStyle =
                        Excel.XlLineStyle.xlContinuous;

                    // Ghi danh sach hang
                    int dong = dongTieuDe + 1;
                    decimal tongTien = 0;

                    foreach (DataRow row in bangChiTiet.Rows)
                    {
                        sheet.Cells[dong, 1] = row["MaHang"].ToString();
                        sheet.Cells[dong, 2] = row["TenHang"].ToString();
                        sheet.Cells[dong, 3] =
                            Convert.ToDecimal(row["DonGia"]);
                        sheet.Cells[dong, 4] =
                            Convert.ToInt32(row["SoLuong"]);
                        sheet.Cells[dong, 5] =
                            Convert.ToDecimal(row["GiamGia"]);
                        sheet.Cells[dong, 6] =
                            Convert.ToDecimal(row["ThanhTien"]);

                        tongTien += Convert.ToDecimal(row["ThanhTien"]);
                        dong++;
                    }

                    // Dinh dang tien te
                    sheet.Range["C11", "C" + (dong - 1)].NumberFormat = "#,##0";
                    sheet.Range["F11", "F" + (dong - 1)].NumberFormat = "#,##0";

                    Excel.Range detail = sheet.Range[
                        "A" + dongTieuDe, "F" + (dong - 1)];

                    detail.Borders.LineStyle =
                        Excel.XlLineStyle.xlContinuous;

                    // Tong tien
                    dong++;
                    sheet.Cells[dong, 5] = "TỔNG TIỀN:";
                    sheet.Cells[dong, 6] = tongTien;

                    Excel.Range oNhanTongTien = (Excel.Range)sheet.Cells[dong, 5];
                    Excel.Range oGiaTriTongTien = (Excel.Range)sheet.Cells[dong, 6];

                    oNhanTongTien.Font.Bold = true;
                    oGiaTriTongTien.Font.Bold = true;
                    oGiaTriTongTien.NumberFormat = "#,##0";

                    // Can chinh do rong cac cot
                    Excel.Range cacCot = sheet.Range["A:F"];
                    cacCot.Columns.AutoFit();


                    // Luu file
                    workbook.SaveAs(sfd.FileName);

                    MessageBox.Show(
                        "Xuất hóa đơn Excel thành công!\n" + sfd.FileName,
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    excelApp.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Xuất Excel thất bại:\n" + ex.Message,
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                finally
                {
                    if (workbook != null)
                        workbook.Close(false);

                    if (excelApp != null)
                        excelApp.Quit();

                    if (sheet != null)
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(sheet);

                    if (workbook != null)
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);

                    if (excelApp != null)
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
                }
            }
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label13_Click(object sender, EventArgs e)
        {
        }
    }
}