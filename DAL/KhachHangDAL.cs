using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    public class KhachHangDAL
    {
        public DataTable LayTatCa()
        {
            return DatabaseAccess.DocBang("SELECT MaKH, TenKH, SDT, DiaChi, '' AS Email FROM tblKhachHang ORDER BY MaKH");
        }

        public int Them(KhachHang kh)
        {
            string sql = "INSERT INTO tblKhachHang (MaKH, TenKH, SDT, DiaChi) VALUES (@MaKH, @TenKH, @SDT, @DiaChi)";
            SqlParameter[] pars = {
                new SqlParameter("@MaKH", kh.MaKH),
                new SqlParameter("@TenKH", kh.HoTen),
                new SqlParameter("@SDT", kh.SDT),
                new SqlParameter("@DiaChi", kh.DiaChi)
            };
            return DatabaseAccess.ThucThi(sql, pars);
        }

        public int Sua(KhachHang kh)
        {
            string sql = "UPDATE tblKhachHang SET TenKH=@TenKH, SDT=@SDT, DiaChi=@DiaChi WHERE MaKH=@MaKH";
            SqlParameter[] pars = {
                new SqlParameter("@MaKH", kh.MaKH),
                new SqlParameter("@TenKH", kh.HoTen),
                new SqlParameter("@SDT", kh.SDT),
                new SqlParameter("@DiaChi", kh.DiaChi)
            };
            return DatabaseAccess.ThucThi(sql, pars);
        }

        public int Xoa(string maKH)
        {
            return DatabaseAccess.ThucThi("DELETE FROM tblKhachHang WHERE MaKH=@MaKH",
                new[] { new SqlParameter("@MaKH", maKH) });
        }

        public bool KiemTraTonTai(string maKH)
        {
            object? res = DatabaseAccess.ThucThiGiaTri("SELECT COUNT(*) FROM tblKhachHang WHERE MaKH=@Ma",
                new[] { new SqlParameter("@Ma", maKH) });
            return Convert.ToInt32(res) > 0;
        }
    }
}