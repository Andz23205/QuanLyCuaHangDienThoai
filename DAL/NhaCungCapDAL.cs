
using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    public class NhaCungCapDAL
    {
        // Lấy toàn bộ danh sách nhà cung cấp
        public DataTable LayTatCa()
        {
            string sql = @"
                SELECT
                    MaNCC,
                    TenNCC,
                    SDT,
                    DiaChi,
                    Email,
                    NguoiLH
                FROM dbo.tblNhaCungCap
                ORDER BY MaNCC";

            return DatabaseAccess.DocBang(sql);
        }

        // Thêm nhà cung cấp
        public int Them(NhaCungCap ncc)
        {
            string sql = @"
                INSERT INTO dbo.tblNhaCungCap
                (MaNCC, TenNCC, SDT, DiaChi, Email, NguoiLH)
                VALUES
                (@MaNCC, @TenNCC, @SDT, @DiaChi, @Email, @NguoiLH)";

            SqlParameter[] pars =
            {
                new SqlParameter("@MaNCC", ncc.MaNCC),
                new SqlParameter("@TenNCC", ncc.TenNCC),
                new SqlParameter("@SDT", ncc.SDT),
                new SqlParameter("@DiaChi", ncc.DiaChi),
                new SqlParameter("@Email", ncc.Email),
                new SqlParameter("@NguoiLH", ncc.NguoiLH)
            };

            return DatabaseAccess.ThucThi(sql, pars);
        }

        // Cập nhật nhà cung cấp
        public int Sua(NhaCungCap ncc)
        {
            string sql = @"
                UPDATE dbo.tblNhaCungCap
                SET
                    TenNCC = @TenNCC,
                    SDT = @SDT,
                    DiaChi = @DiaChi,
                    Email = @Email,
                    NguoiLH = @NguoiLH
                WHERE MaNCC = @MaNCC";

            SqlParameter[] pars =
            {
                new SqlParameter("@MaNCC", ncc.MaNCC),
                new SqlParameter("@TenNCC", ncc.TenNCC),
                new SqlParameter("@SDT", ncc.SDT),
                new SqlParameter("@DiaChi", ncc.DiaChi),
                new SqlParameter("@Email", ncc.Email),
                new SqlParameter("@NguoiLH", ncc.NguoiLH)
            };

            return DatabaseAccess.ThucThi(sql, pars);
        }

        // Xóa nhà cung cấp
        public int Xoa(string maNCC)
        {
            return DatabaseAccess.ThucThi(
                "DELETE FROM dbo.tblNhaCungCap WHERE MaNCC=@MaNCC",
                new[]
                {
                    new SqlParameter("@MaNCC", maNCC)
                });
        }

        // Kiểm tra mã nhà cung cấp tồn tại
        public bool KiemTraTonTai(string maNCC)
        {
            object? res = DatabaseAccess.ThucThiGiaTri(
                "SELECT COUNT(*) FROM dbo.tblNhaCungCap WHERE MaNCC=@Ma",
                new[]
                {
                    new SqlParameter("@Ma", maNCC)
                });

            return Convert.ToInt32(res) > 0;
        }
    }
}
