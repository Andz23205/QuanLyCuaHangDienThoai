using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    public partial class Form8 : Form
    {
        private readonly DataTable bangChiTiet = new DataTable();
        private bool hoaDonDaLuu = false;
        private bool dangNapDuLieu = false;

        public Form8()
        {
            InitializeComponent();
            KhoiTaoBangChiTiet();
            CauHinhGiaoDien();
            GanSuKien();
            NapDuLieuBanDau();
            TaoMaHoaDonMoi();
        }

        private void KhoiTaoBangChiTiet()
        {
            bangChiTiet.Columns.Add("MaHang", typeof(string));
            bangChiTiet.Columns.Add("TenHang", typeof(string));
            bangChiTiet.Columns.Add("DonGiaNhap", typeof(decimal));
            bangChiTiet.Columns.Add("SoLuong", typeof(int));
            bangChiTiet.Columns.Add("ThanhTien", typeof(decimal));

            dgvChiTiet.DataSource = bangChiTiet;
            dgvChiTiet.AllowUserToAddRows = false;
            dgvChiTiet.ReadOnly = true;
            dgvChiTiet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTiet.Columns["MaHang"].HeaderText = "Mã hàng";
            dgvChiTiet.Columns["TenHang"].HeaderText = "Tên hàng";
            dgvChiTiet.Columns["DonGiaNhap"].HeaderText = "Đơn giá nhập";
            dgvChiTiet.Columns["SoLuong"].HeaderText = "Số lượng";
            dgvChiTiet.Columns["ThanhTien"].HeaderText = "Thành tiền";
            dgvChiTiet.Columns["DonGiaNhap"].DefaultCellStyle.Format = "N0";
            dgvChiTiet.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
        }

        private void CauHinhGiaoDien()
        {
            txtTenNV.ReadOnly = true;
            txtMaNCC.ReadOnly = true;
            txtSDT.ReadOnly = true;
            txtDiaChi.ReadOnly = true;
            txtTenHang.ReadOnly = true;
            txtDonGiaNhap.ReadOnly = true;
            txtThanhTien.ReadOnly = true;
            cboMaHang.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNCC.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMaHDN.DropDownStyle = ComboBoxStyle.DropDown;
            dtpNgayNhap.Value = DateTime.Today;
        }

        private void GanSuKien()
        {
            cboMaHang.SelectedIndexChanged -= cboMaHang_SelectedIndexChanged;
            cboMaHang.SelectedIndexChanged += cboMaHang_SelectedIndexChanged;
            cboNCC.SelectedIndexChanged -= cboNCC_SelectedIndexChanged;
            cboNCC.SelectedIndexChanged += cboNCC_SelectedIndexChanged;
            txtSoLuong.TextChanged -= txtSoLuong_TextChanged;
            txtSoLuong.TextChanged += txtSoLuong_TextChanged;

            button1.Click -= button1_Click;
            button1.Click += button1_Click;
            btnThemHD.Click -= btnThemHD_Click;
            btnThemHD.Click += btnThemHD_Click;
            btnLuu.Click -= btnLuu_Click;
            btnLuu.Click += btnLuu_Click;
            btnHuy.Click -= btnHuy_Click;
            btnHuy.Click += btnHuy_Click;
            btnTim.Click -= btnTim_Click;
            btnTim.Click += btnTim_Click;
            btnThoat.Click -= btnThoat_Click;
            btnThoat.Click += btnThoat_Click;
            btnIn.Click -= btnIn_Click;
            btnIn.Click += btnIn_Click;
        }

        private void NapDuLieuBanDau()
        {
            try
            {
                dangNapDuLieu = true;
                using (SqlConnection conn = KetNoiCSDL.TaoKetNoi())
                {
                    conn.Open();

                    cboMaHang.Items.Clear();
                    using (SqlCommand cmd = new SqlCommand("SELECT MaHang FROM tblHang ORDER BY MaHang", conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                        while (reader.Read()) cboMaHang.Items.Add(reader["MaHang"].ToString());

                    cboNCC.Items.Clear();
                    using (SqlCommand cmd = new SqlCommand("SELECT MaNCC FROM tblNhaCungCap ORDER BY MaNCC", conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                        while (reader.Read()) cboNCC.Items.Add(reader["MaNCC"].ToString());

                    cboMaHDN.Items.Clear();
                    using (SqlCommand cmd = new SqlCommand("SELECT MaHDN FROM tblHoaDonNhap ORDER BY MaHDN", conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                        while (reader.Read()) cboMaHDN.Items.Add(reader["MaHDN"].ToString());

                    if (!string.IsNullOrWhiteSpace(txtMaNV.Text)) NapTenNhanVien(conn, txtMaNV.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tải được dữ liệu từ SQL Server. Hãy kiểm tra kết nối CSDL.\n" + ex.Message,
                    "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { dangNapDuLieu = false; }
        }

        private void NapTenNhanVien(SqlConnection conn, string maNV)
        {
            using (SqlCommand cmd = new SqlCommand("SELECT TenNV FROM tblNhanVien WHERE MaNV=@MaNV", conn))
            {
                cmd.Parameters.AddWithValue("@MaNV", maNV);
                object kq = cmd.ExecuteScalar();
                txtTenNV.Text = kq == null || kq == DBNull.Value ? "" : kq.ToString();
            }
        }

        private void cboMaHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dangNapDuLieu || string.IsNullOrWhiteSpace(cboMaHang.Text)) return;
            try
            {
                using (SqlConnection conn = KetNoiCSDL.TaoKetNoi())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT TenHang, DonGiaNhap FROM tblHang WHERE MaHang=@MaHang", conn))
                    {
                        cmd.Parameters.AddWithValue("@MaHang", cboMaHang.Text.Trim());
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtTenHang.Text = reader["TenHang"].ToString();
                                txtDonGiaNhap.Text = Convert.ToDecimal(reader["DonGiaNhap"]).ToString("N0");
                            }
                            else { txtTenHang.Clear(); txtDonGiaNhap.Clear(); }
                        }
                    }
                }
                TinhThanhTien();
            }
            catch (Exception ex) { MessageBox.Show("Không lấy được thông tin hàng: " + ex.Message); }
        }

        private void cboNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dangNapDuLieu || string.IsNullOrWhiteSpace(cboNCC.Text)) return;
            try
            {
                using (SqlConnection conn = KetNoiCSDL.TaoKetNoi())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT MaNCC, SDT, DiaChi FROM tblNhaCungCap WHERE MaNCC=@MaNCC", conn))
                    {
                        cmd.Parameters.AddWithValue("@MaNCC", cboNCC.Text.Trim());
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtMaNCC.Text = reader["MaNCC"].ToString();
                                txtSDT.Text = reader["SDT"] == DBNull.Value ? "" : reader["SDT"].ToString();
                                txtDiaChi.Text = reader["DiaChi"] == DBNull.Value ? "" : reader["DiaChi"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Không lấy được thông tin nhà cung cấp: " + ex.Message); }
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e) { TinhThanhTien(); }

        private decimal DocDonGia()
        {
            decimal gia;
            string s = txtDonGiaNhap.Text.Trim().Replace(",", "").Replace(".", "");
            if (!decimal.TryParse(s, NumberStyles.Number, CultureInfo.InvariantCulture, out gia))
                decimal.TryParse(txtDonGiaNhap.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out gia);
            return gia;
        }

        private void TinhThanhTien()
        {
            int sl;
            decimal gia = DocDonGia();
            if (int.TryParse(txtSoLuong.Text.Trim(), out sl) && sl > 0 && gia > 0)
                txtThanhTien.Text = (gia * sl).ToString("N0");
            else txtThanhTien.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (hoaDonDaLuu) { MessageBox.Show("Hóa đơn này đã lưu. Hãy bấm Thêm hóa đơn để tạo hóa đơn mới."); return; }
            string ma = cboMaHang.Text.Trim();
            int sl;
            decimal gia = DocDonGia();
            if (ma == "") { MessageBox.Show("Bạn hãy chọn mã hàng."); return; }
            if (!int.TryParse(txtSoLuong.Text.Trim(), out sl) || sl <= 0)
            { MessageBox.Show("Số lượng phải là số nguyên lớn hơn 0."); txtSoLuong.Focus(); return; }
            if (gia <= 0) { MessageBox.Show("Đơn giá nhập không hợp lệ."); return; }

            foreach (DataRow row in bangChiTiet.Rows)
            {
                if (row["MaHang"].ToString() == ma)
                {
                    int slMoi = Convert.ToInt32(row["SoLuong"]) + sl;
                    row["SoLuong"] = slMoi;
                    row["DonGiaNhap"] = gia;
                    row["ThanhTien"] = gia * slMoi;
                    CapNhatTongTien(); LamMoiNhapHang(); return;
                }
            }
            bangChiTiet.Rows.Add(ma, txtTenHang.Text.Trim(), gia, sl, gia * sl);
            CapNhatTongTien();
            LamMoiNhapHang();
        }

        private void CapNhatTongTien()
        {
            decimal tong = 0;
            foreach (DataRow row in bangChiTiet.Rows) tong += Convert.ToDecimal(row["ThanhTien"]);
            lblTongTien.Text = "Tổng tiền: " + tong.ToString("N0") + " VNĐ";
        }

        private void LamMoiNhapHang()
        {
            cboMaHang.SelectedIndex = -1;
            txtTenHang.Clear(); txtSoLuong.Clear(); txtDonGiaNhap.Clear(); txtThanhTien.Clear();
        }

        private void TaoMaHoaDonMoi()
        {
            cboMaHDN.Text = "HDN_" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            hoaDonDaLuu = false;
        }

        private void btnThemHD_Click(object sender, EventArgs e)
        {
            if (!hoaDonDaLuu && bangChiTiet.Rows.Count > 0)
            {
                DialogResult xacNhan = MessageBox.Show("Hóa đơn hiện tại chưa lưu. Bạn muốn bỏ các dòng đang nhập và tạo hóa đơn mới?",
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (xacNhan != DialogResult.Yes) return;
            }
            bangChiTiet.Clear();
            cboNCC.SelectedIndex = -1; txtMaNCC.Clear(); txtSDT.Clear(); txtDiaChi.Clear();
            dtpNgayNhap.Value = DateTime.Today;
            LamMoiNhapHang(); CapNhatTongTien(); TaoMaHoaDonMoi();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (hoaDonDaLuu) { MessageBox.Show("Hóa đơn này đã được lưu."); return; }
            string maHDN = cboMaHDN.Text.Trim();
            string maNV = txtMaNV.Text.Trim();
            string maNCC = cboNCC.Text.Trim();
            if (maHDN == "") { MessageBox.Show("Bạn hãy nhập mã hóa đơn."); return; }
            if (maNV == "" || txtTenNV.Text.Trim() == "") { MessageBox.Show("Mã nhân viên không tồn tại trong CSDL."); return; }
            if (maNCC == "") { MessageBox.Show("Bạn hãy chọn nhà cung cấp."); return; }
            if (bangChiTiet.Rows.Count == 0) { MessageBox.Show("Hóa đơn chưa có mặt hàng."); return; }

            decimal tong = 0;
            foreach (DataRow row in bangChiTiet.Rows) tong += Convert.ToDecimal(row["ThanhTien"]);

            using (SqlConnection conn = KetNoiCSDL.TaoKetNoi())
            {
                conn.Open();
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand kiemTra = new SqlCommand("SELECT COUNT(*) FROM tblHoaDonNhap WHERE MaHDN=@MaHDN", conn, tran))
                        {
                            kiemTra.Parameters.AddWithValue("@MaHDN", maHDN);
                            if (Convert.ToInt32(kiemTra.ExecuteScalar()) > 0)
                                throw new Exception("Mã hóa đơn đã tồn tại. Hãy tạo mã hóa đơn mới.");
                        }

                        using (SqlCommand cmd = new SqlCommand("INSERT INTO tblHoaDonNhap(MaHDN,MaNV,MaNCC,NgayNhap,TongTien) VALUES(@MaHDN,@MaNV,@MaNCC,@NgayNhap,@TongTien)", conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@MaHDN", maHDN);
                            cmd.Parameters.AddWithValue("@MaNV", maNV);
                            cmd.Parameters.AddWithValue("@MaNCC", maNCC);
                            cmd.Parameters.AddWithValue("@NgayNhap", dtpNgayNhap.Value);
                            cmd.Parameters.AddWithValue("@TongTien", tong);
                            cmd.ExecuteNonQuery();
                        }

                        foreach (DataRow row in bangChiTiet.Rows)
                        {
                            string maHang = row["MaHang"].ToString();
                            int sl = Convert.ToInt32(row["SoLuong"]);
                            decimal gia = Convert.ToDecimal(row["DonGiaNhap"]);
                            decimal thanhTien = Convert.ToDecimal(row["ThanhTien"]);
                            using (SqlCommand capNhatKho = new SqlCommand("UPDATE tblHang SET SoLuongTon=SoLuongTon+@SoLuong, DonGiaNhap=@DonGia WHERE MaHang=@MaHang", conn, tran))
                            {
                                capNhatKho.Parameters.AddWithValue("@SoLuong", sl);
                                capNhatKho.Parameters.AddWithValue("@DonGia", gia);
                                capNhatKho.Parameters.AddWithValue("@MaHang", maHang);
                                if (capNhatKho.ExecuteNonQuery() != 1) throw new Exception("Không tìm thấy mã hàng " + maHang + " trong kho.");
                            }
                            using (SqlCommand chiTiet = new SqlCommand("INSERT INTO tblChiTietHDN(MaHDN,MaHang,SoLuong,DonGiaNhap,ThanhTien) VALUES(@MaHDN,@MaHang,@SoLuong,@DonGiaNhap,@ThanhTien)", conn, tran))
                            {
                                chiTiet.Parameters.AddWithValue("@MaHDN", maHDN);
                                chiTiet.Parameters.AddWithValue("@MaHang", maHang);
                                chiTiet.Parameters.AddWithValue("@SoLuong", sl);
                                chiTiet.Parameters.AddWithValue("@DonGiaNhap", gia);
                                chiTiet.Parameters.AddWithValue("@ThanhTien", thanhTien);
                                chiTiet.ExecuteNonQuery();
                            }
                        }
                        tran.Commit();
                        hoaDonDaLuu = true;
                        if (!cboMaHDN.Items.Contains(maHDN)) cboMaHDN.Items.Add(maHDN);
                        MessageBox.Show("Lưu hóa đơn nhập thành công!\nMã hóa đơn: " + maHDN + "\n" + lblTongTien.Text,
                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        try { tran.Rollback(); } catch { }
                        MessageBox.Show("Không lưu được hóa đơn. Dữ liệu đã được hoàn tác.\n" + ex.Message,
                            "Lỗi lưu hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (hoaDonDaLuu)
            {
                MessageBox.Show("Hóa đơn đã lưu vào CSDL nên không thể hủy bằng nút này. Nếu cần xóa hóa đơn, phải có chức năng xóa riêng để hoàn tác tồn kho.");
                return;
            }
            DialogResult kq = MessageBox.Show("Bạn có chắc muốn xóa các mặt hàng đang nhập?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                bangChiTiet.Clear(); cboNCC.SelectedIndex = -1;
                txtMaNCC.Clear(); txtSDT.Clear(); txtDiaChi.Clear();
                LamMoiNhapHang(); CapNhatTongTien(); TaoMaHoaDonMoi();
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string maHDN = cboMaHDN.Text.Trim();
            if (maHDN == "") { MessageBox.Show("Hãy nhập hoặc chọn mã hóa đơn cần tìm."); return; }
            try
            {
                using (SqlConnection conn = KetNoiCSDL.TaoKetNoi())
                {
                    conn.Open();
                    DataTable hd = new DataTable();
                    using (SqlDataAdapter da = new SqlDataAdapter(
                        "SELECT h.MaHDN,h.MaNV,n.TenNV,h.MaNCC,ncc.SDT,ncc.DiaChi,h.NgayNhap,h.TongTien FROM tblHoaDonNhap h " +
                        "INNER JOIN tblNhanVien n ON h.MaNV=n.MaNV INNER JOIN tblNhaCungCap ncc ON h.MaNCC=ncc.MaNCC WHERE h.MaHDN=@MaHDN", conn))
                    {
                        da.SelectCommand.Parameters.AddWithValue("@MaHDN", maHDN);
                        da.Fill(hd);
                    }
                    if (hd.Rows.Count == 0) { MessageBox.Show("Không tìm thấy hóa đơn có mã " + maHDN + "."); return; }
                    DataRow r = hd.Rows[0];
                    txtMaNV.Text = r["MaNV"].ToString(); txtTenNV.Text = r["TenNV"].ToString();
                    cboNCC.SelectedItem = r["MaNCC"].ToString();
                    if (cboNCC.SelectedIndex < 0) cboNCC.Text = r["MaNCC"].ToString();
                    txtMaNCC.Text = r["MaNCC"].ToString();
                    txtSDT.Text = r["SDT"] == DBNull.Value ? "" : r["SDT"].ToString();
                    txtDiaChi.Text = r["DiaChi"] == DBNull.Value ? "" : r["DiaChi"].ToString();
                    dtpNgayNhap.Value = Convert.ToDateTime(r["NgayNhap"]);

                    bangChiTiet.Clear();
                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT c.MaHang,h.TenHang,c.DonGiaNhap,c.SoLuong,c.ThanhTien FROM tblChiTietHDN c " +
                        "INNER JOIN tblHang h ON c.MaHang=h.MaHang WHERE c.MaHDN=@MaHDN ORDER BY c.MaHang", conn))
                    {
                        cmd.Parameters.AddWithValue("@MaHDN", maHDN);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                                bangChiTiet.Rows.Add(reader["MaHang"].ToString(), reader["TenHang"].ToString(),
                                    Convert.ToDecimal(reader["DonGiaNhap"]), Convert.ToInt32(reader["SoLuong"]), Convert.ToDecimal(reader["ThanhTien"]));
                        }
                    }
                    CapNhatTongTien(); hoaDonDaLuu = true;
                    MessageBox.Show("Đã tải hóa đơn " + maHDN + ".");
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tìm hóa đơn: " + ex.Message); }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (bangChiTiet.Rows.Count == 0) { MessageBox.Show("Không có dữ liệu để xuất Excel."); return; }
            Excel.Application excel = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet sheet = null;
            try
            {
                excel = new Excel.Application();
                workbook = excel.Workbooks.Add();
                sheet = (Excel.Worksheet)workbook.Worksheets[1];
                sheet.Name = "HoaDonNhap";
                sheet.Cells[1, 1] = "HÓA ĐƠN NHẬP HÀNG";
                sheet.Range["A1", "E1"].Merge();
                sheet.Range["A1", "E1"].Font.Bold = true;
                sheet.Range["A1", "E1"].Font.Size = 16;
                sheet.Cells[3, 1] = "Mã hóa đơn:"; sheet.Cells[3, 2] = cboMaHDN.Text;
                sheet.Cells[4, 1] = "Ngày nhập:"; sheet.Cells[4, 2] = dtpNgayNhap.Value.ToString("dd/MM/yyyy");
                sheet.Cells[5, 1] = "Mã nhân viên:"; sheet.Cells[5, 2] = txtMaNV.Text;
                sheet.Cells[6, 1] = "Tên nhân viên:"; sheet.Cells[6, 2] = txtTenNV.Text;
                sheet.Cells[7, 1] = "Mã nhà cung cấp:"; sheet.Cells[7, 2] = txtMaNCC.Text;
                sheet.Cells[8, 1] = "Số điện thoại:"; sheet.Cells[8, 2] = txtSDT.Text;
                sheet.Cells[9, 1] = "Địa chỉ:"; sheet.Cells[9, 2] = txtDiaChi.Text;
                string[] headers = { "Mã hàng", "Tên hàng", "Đơn giá nhập", "Số lượng", "Thành tiền" };
                for (int i = 0; i < headers.Length; i++) { sheet.Cells[11, i + 1] = headers[i]; sheet.Cells[11, i + 1].Font.Bold = true; }
                int dong = 12;
                foreach (DataRow row in bangChiTiet.Rows)
                {
                    sheet.Cells[dong, 1] = row["MaHang"].ToString();
                    sheet.Cells[dong, 2] = row["TenHang"].ToString();
                    sheet.Cells[dong, 3] = Convert.ToDecimal(row["DonGiaNhap"]);
                    sheet.Cells[dong, 4] = Convert.ToInt32(row["SoLuong"]);
                    sheet.Cells[dong, 5] = Convert.ToDecimal(row["ThanhTien"]);
                    dong++;
                }
                sheet.Cells[dong + 1, 4] = "TỔNG TIỀN:";
                decimal tong = 0;
                foreach (DataRow row in bangChiTiet.Rows) tong += Convert.ToDecimal(row["ThanhTien"]);
                sheet.Cells[dong + 1, 5] = tong;
                sheet.Columns.AutoFit();

                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
                    sfd.FileName = "HoaDonNhap_" + cboMaHDN.Text + ".xlsx";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        workbook.SaveAs(sfd.FileName);
                        MessageBox.Show("Xuất Excel thành công: " + sfd.FileName);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Không xuất được Excel. Hãy kiểm tra Microsoft Excel và COM reference.\n" + ex.Message); }
            finally
            {
                if (workbook != null) workbook.Close(false);
                if (excel != null) excel.Quit();
                if (sheet != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(sheet);
                if (workbook != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                if (excel != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e) { Close(); }
    }
}
