using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    public class NhaCungCapDAL
    {
        public DataTable LayTatCa()
        {
            return DatabaseAccess.DocBang("SELECT MaNCC, TenNCC, SDT, DiaChi, '' AS Email, '' AS NguoiLH FROM tblNhaCungCap ORDER BY MaNCC");
        }

        public int Them(NhaCungCap ncc)
        {
            string sql = "INSERT INTO tblNhaCungCap (MaNCC, TenNCC, SDT, DiaChi) VALUES (@MaNCC, @TenNCC, @SDT, @DiaChi)";
            SqlParameter[] pars = {
                new SqlParameter("@MaNCC", ncc.MaNCC),
                new SqlParameter("@TenNCC", ncc.TenNCC),
                new SqlParameter("@SDT", ncc.SDT),
                new SqlParameter("@DiaChi", ncc.DiaChi)
            };
            return DatabaseAccess.ThucThi(sql, pars);
        }

        public int Sua(NhaCungCap ncc)
        {
            string sql = "UPDATE tblNhaCungCap SET TenNCC=@TenNCC, SDT=@SDT, DiaChi=@DiaChi WHERE MaNCC=@MaNCC";
            SqlParameter[] pars = {
                new SqlParameter("@MaNCC", ncc.MaNCC),
                new SqlParameter("@TenNCC", ncc.TenNCC),
                new SqlParameter("@SDT", ncc.SDT),
                new SqlParameter("@DiaChi", ncc.DiaChi)
            };
            return DatabaseAccess.ThucThi(sql, pars);
        }

        public int Xoa(string maNCC)
        {
            return DatabaseAccess.ThucThi("DELETE FROM tblNhaCungCap WHERE MaNCC=@MaNCC",
                new[] { new SqlParameter("@MaNCC", maNCC) });
        }

        public bool KiemTraTonTai(string maNCC)
        {
            object? res = DatabaseAccess.ThucThiGiaTri("SELECT COUNT(*) FROM tblNhaCungCap WHERE MaNCC=@Ma",
                new[] { new SqlParameter("@Ma", maNCC) });
            return Convert.ToInt32(res) > 0;
        }
    }
}