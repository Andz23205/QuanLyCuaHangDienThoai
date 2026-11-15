
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
                SELECT MaKH, TenKH, SDT, DiaChi, Email
                FROM tblKhachHang
                ORDER BY MaKH";

            return DatabaseAccess.DocBang(sql);
        }

        // Thêm khách hàng
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
                    ? DBNull.Value
                    : kh.Email)
            };

            return DatabaseAccess.ThucThi(sql, pars);
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
                    ? DBNull.Value
                    : kh.Email)
            };

            return DatabaseAccess.ThucThi(sql, pars);
        }

        // Xóa khách hàng

        // Lấy danh sách mã hóa đơn của khách hàng
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

            return DatabaseAccess.DocBang(sql, pars);
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

            return DatabaseAccess.ThucThi(sql, pars);
        }


        // Kiểm tra mã khách hàng đã tồn tại
        public bool KiemTraTonTai(string maKH)
        {
            object? res = DatabaseAccess.ThucThiGiaTri(
                "SELECT COUNT(*) FROM tblKhachHang WHERE MaKH=@Ma",
                new[]
                {
                    new SqlParameter("@Ma", maKH)
                }
            );

            return Convert.ToInt32(res) > 0;
        }
    }
}
