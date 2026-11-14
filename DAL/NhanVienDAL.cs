using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    public class NhanVienDAL
    {
        // Goi Stored Procedure: sp_KiemTraDangNhap
        public DataTable KiemTraDangNhap(string tk, string mk)
        {
            SqlParameter[] pars = {
                new SqlParameter("@TaiKhoan", tk),
                new SqlParameter("@MatKhau", mk)
            };
            return DatabaseAccess.DocBangProc("sp_KiemTraDangNhap", pars);
        }

        public DataTable LayTatCa()
        {
            string sql = "SELECT MaNV, TenNV, GioiTinh, NgaySinh, SDT, DiaChi, TenDangNhap, MatKhau, VaiTro AS ChucVu FROM tblNhanVien ORDER BY MaNV";
            return DatabaseAccess.DocBang(sql);
        }

        public int Them(NhanVien nv)
        {
            string sql = @"
                INSERT INTO tblNhanVien (MaNV, TenNV, GioiTinh, NgaySinh, SDT, DiaChi, TenDangNhap, MatKhau, VaiTro)
                VALUES (@MaNV, @TenNV, @GioiTinh, @NgaySinh, @SDT, @DiaChi, @TenDangNhap, @MatKhau, @VaiTro)";

            SqlParameter[] pars = {
                new SqlParameter("@MaNV", nv.MaNV),
                new SqlParameter("@TenNV", nv.HoTen),
                new SqlParameter("@GioiTinh", nv.GioiTinh),
                new SqlParameter("@NgaySinh", nv.NgaySinh.Date),
                new SqlParameter("@SDT", nv.SDT),
                new SqlParameter("@DiaChi", nv.DiaChi),
                new SqlParameter("@TenDangNhap", nv.TenDangNhap),
                new SqlParameter("@MatKhau", nv.MatKhau),
                new SqlParameter("@VaiTro", nv.VaiTro)
            };
            return DatabaseAccess.ThucThi(sql, pars);
        }

        public int Sua(NhanVien nv)
        {
            string sql = @"
                UPDATE tblNhanVien 
                SET TenNV=@TenNV, GioiTinh=@GioiTinh, NgaySinh=@NgaySinh, SDT=@SDT, 
                    DiaChi=@DiaChi, MatKhau=@MatKhau, VaiTro=@VaiTro
                WHERE MaNV=@MaNV";

            SqlParameter[] pars = {
                new SqlParameter("@MaNV", nv.MaNV),
                new SqlParameter("@TenNV", nv.HoTen),
                new SqlParameter("@GioiTinh", nv.GioiTinh),
                new SqlParameter("@NgaySinh", nv.NgaySinh.Date),
                new SqlParameter("@SDT", nv.SDT),
                new SqlParameter("@DiaChi", nv.DiaChi),
                new SqlParameter("@MatKhau", nv.MatKhau),
                new SqlParameter("@VaiTro", nv.VaiTro)
            };
            return DatabaseAccess.ThucThi(sql, pars);
        }

        public int Xoa(string maNV)
        {
            return DatabaseAccess.ThucThi("DELETE FROM tblNhanVien WHERE MaNV=@MaNV",
                new[] { new SqlParameter("@MaNV", maNV) });
        }

        public bool KiemTraTonTai(string maNV)
        {
            object? res = DatabaseAccess.ThucThiGiaTri("SELECT COUNT(*) FROM tblNhanVien WHERE MaNV=@Ma",
                new[] { new SqlParameter("@Ma", maNV) });
            return Convert.ToInt32(res) > 0;
        }
    }
}