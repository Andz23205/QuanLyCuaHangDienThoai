
using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    public class KhachHangDAL
    {
        // Lấy danh sách khách hàng
        public DataTable LayTatCa()
        {
            string sql = @"
                SELECT MaKH, TenKH, SDT, DiaChi, Email, TaiKhoan
                FROM tblKhachHang
                ORDER BY MaKH";

            return KetNoiCSDL.DocBang(sql);
        }

        // Thêm khách hàng bằng chức năng quản lý
        public int Them(KhachHang kh)
        {
            string sql = @"
                INSERT INTO tblKhachHang
                (MaKH, TenKH, SDT, DiaChi, Email)
                VALUES
                (@MaKH, @TenKH, @SDT, @DiaChi, @Email)";

            SqlParameter[] pars =
            {
                new SqlParameter("@MaKH", kh.MaKH),
                new SqlParameter("@TenKH", kh.HoTen),
                new SqlParameter("@SDT", kh.SDT),
                new SqlParameter("@DiaChi", kh.DiaChi),
                new SqlParameter("@Email",
                    string.IsNullOrWhiteSpace(kh.Email)
                    ? DBNull.Value : kh.Email)
            };

            return KetNoiCSDL.ThucThi(sql, pars);
        }

        // Sửa khách hàng
        public int Sua(KhachHang kh)
        {
            string sql = @"
                UPDATE tblKhachHang
                SET TenKH = @TenKH,
                    SDT = @SDT,
                    DiaChi = @DiaChi,
                    Email = @Email
                WHERE MaKH = @MaKH";

            SqlParameter[] pars =
            {
                new SqlParameter("@MaKH", kh.MaKH),
                new SqlParameter("@TenKH", kh.HoTen),
                new SqlParameter("@SDT", kh.SDT),
                new SqlParameter("@DiaChi", kh.DiaChi),
                new SqlParameter("@Email",
                    string.IsNullOrWhiteSpace(kh.Email)
                    ? DBNull.Value : kh.Email)
            };

            return KetNoiCSDL.ThucThi(sql, pars);
        }

        // Kiểm tra mã khách hàng
        public bool KiemTraTonTai(string maKH)
        {
            object? res = KetNoiCSDL.ThucThiGiaTri(
                "SELECT COUNT(*) FROM tblKhachHang WHERE MaKH = @MaKH",
                new[]
                {
                    new SqlParameter("@MaKH", maKH)
                });

            return Convert.ToInt32(res) > 0;
        }

        // Kiểm tra tài khoản đã tồn tại
        public bool KiemTraTaiKhoan(string taiKhoan)
        {
            object? res = KetNoiCSDL.ThucThiGiaTri(
                @"SELECT COUNT(*) FROM tblKhachHang
                  WHERE TaiKhoan = @TaiKhoan",
                new[]
                {
                    new SqlParameter("@TaiKhoan", taiKhoan)
                });

            return Convert.ToInt32(res) > 0;
        }

        // Kiểm tra Email đã tồn tại
        public bool KiemTraEmail(string email)
        {
            object? res = KetNoiCSDL.ThucThiGiaTri(
                @"SELECT COUNT(*) FROM tblKhachHang
                  WHERE Email = @Email",
                new[]
                {
                    new SqlParameter("@Email", email)
                });

            return Convert.ToInt32(res) > 0;
        }

        // Đăng ký khách hàng và tự sinh mã KH
        public int DangKyTaiKhoan(KhachHang kh)
        {
            using (SqlConnection conn = KetNoiCSDL.TaoKetNoi())
            {
                conn.Open();

                using (SqlTransaction transaction =
                       conn.BeginTransaction(IsolationLevel.Serializable))
                {
                    try
                    {
                        // Tự sinh mã KH tiếp theo
                        string sqlMa = @"
                            SELECT ISNULL(
                                MAX(TRY_CONVERT(INT, SUBSTRING(MaKH, 3, 18))),
                                0
                            ) + 1
                            FROM dbo.tblKhachHang WITH (UPDLOCK, HOLDLOCK)
                            WHERE MaKH LIKE N'KH[0-9]%';";

                        int soMoi;

                        using (SqlCommand cmdMa =
                               new SqlCommand(sqlMa, conn, transaction))
                        {
                            soMoi = Convert.ToInt32(cmdMa.ExecuteScalar());
                        }

                        kh.MaKH = "KH" + soMoi.ToString("D3");

                        string sql = @"
                            INSERT INTO dbo.tblKhachHang
                            (
                                MaKH,
                                TenKH,
                                SDT,
                                DiaChi,
                                Email,
                                TaiKhoan,
                                MatKhau
                            )
                            VALUES
                            (
                                @MaKH,
                                @TenKH,
                                @SDT,
                                @DiaChi,
                                @Email,
                                @TaiKhoan,
                                @MatKhau
                            );";

                        using (SqlCommand cmd =
                               new SqlCommand(sql, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@MaKH", kh.MaKH);
                            cmd.Parameters.AddWithValue("@TenKH", kh.HoTen);
                            cmd.Parameters.AddWithValue("@SDT", kh.SDT);

                            cmd.Parameters.AddWithValue(
                                "@DiaChi",
                                string.IsNullOrWhiteSpace(kh.DiaChi)
                                    ? DBNull.Value
                                    : kh.DiaChi);

                            cmd.Parameters.AddWithValue("@Email", kh.Email);
                            cmd.Parameters.AddWithValue("@TaiKhoan", kh.TaiKhoan);
                            cmd.Parameters.AddWithValue("@MatKhau", kh.MatKhau);

                            int result = cmd.ExecuteNonQuery();

                            transaction.Commit();
                            return result;
                        }
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        // Đăng nhập khách hàng
        public KhachHang? DangNhap(string taiKhoan, string matKhau)
        {
            string sql = @"
                SELECT MaKH, TenKH, SDT, DiaChi, Email, TaiKhoan
                FROM dbo.tblKhachHang
                WHERE TaiKhoan = @TaiKhoan
                  AND MatKhau = @MatKhau";

            SqlParameter[] pars =
            {
                new SqlParameter("@TaiKhoan", taiKhoan),
                new SqlParameter("@MatKhau", matKhau)
            };

            DataTable dt = KetNoiCSDL.DocBang(sql, pars);

            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];

            return new KhachHang(
                row["MaKH"].ToString() ?? "",
                row["TenKH"].ToString() ?? "",
                row["SDT"].ToString() ?? "",
                row["DiaChi"] == DBNull.Value
                    ? ""
                    : row["DiaChi"].ToString() ?? "",
                row["Email"] == DBNull.Value
                    ? ""
                    : row["Email"].ToString() ?? "")
            {
                TaiKhoan = row["TaiKhoan"].ToString() ?? ""
            };
        }

        // Lấy danh sách hóa đơn của khách hàng
        public DataTable LayHoaDonCuaKhachHang(string maKH)
        {
            string sql = @"
                SELECT MaHDB
                FROM tblHoaDonBan
                WHERE MaKH = @MaKH
                ORDER BY MaHDB";

            SqlParameter[] pars =
            {
                new SqlParameter("@MaKH", maKH)
            };

            return KetNoiCSDL.DocBang(sql, pars);
        }

        // Xóa khách hàng
        public int Xoa(string maKH)
        {
            string sql = @"
                DELETE FROM tblKhachHang
                WHERE MaKH = @MaKH";

            SqlParameter[] pars =
            {
                new SqlParameter("@MaKH", maKH)
            };

            return KetNoiCSDL.ThucThi(sql, pars);
        }
    }
}
