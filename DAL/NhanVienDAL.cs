
using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    public class NhanVienDAL
    {
        public DataTable KiemTraDangNhap(string tk, string mk)
        {
            SqlParameter[] pars =
            {
                new SqlParameter("@TaiKhoan", tk),
                new SqlParameter("@MatKhau", mk)
            };

            return DatabaseAccess.DocBangProc(
                "sp_KiemTraDangNhap", pars);
        }

        public DataTable LayTatCa()
        {
            string sql = @"
                SELECT
                    MaNV,
                    TenNV,
                    GioiTinh,
                    NgaySinh,
                    SDT,
                    DiaChi,
                    TaiKhoan AS TenDangNhap,
                    MatKhau,
                    ChucVu,
                    ISNULL(TrangThai, N'Đang làm việc') AS TrangThai
                FROM tblNhanVien
                ORDER BY MaNV";

            return DatabaseAccess.DocBang(sql);
        }

        public int Them(NhanVien nv)
        {
            string sql = @"
                INSERT INTO tblNhanVien
                (MaNV, TenNV, GioiTinh, NgaySinh, SDT, DiaChi,
                 TaiKhoan, MatKhau, ChucVu, TrangThai)
                VALUES
                (@MaNV, @TenNV, @GioiTinh, @NgaySinh, @SDT, @DiaChi,
                 @TaiKhoan, @MatKhau, @ChucVu, @TrangThai)";

            SqlParameter[] pars =
            {
                new SqlParameter("@MaNV", nv.MaNV),
                new SqlParameter("@TenNV", nv.HoTen),
                new SqlParameter("@GioiTinh", nv.GioiTinh),
                new SqlParameter("@NgaySinh", nv.NgaySinh.Date),
                new SqlParameter("@SDT", nv.SDT),
                new SqlParameter("@DiaChi", nv.DiaChi),
                new SqlParameter("@TaiKhoan", nv.TenDangNhap),
                new SqlParameter("@MatKhau", nv.MatKhau),
                new SqlParameter("@ChucVu", nv.VaiTro),
                new SqlParameter("@TrangThai", nv.TrangThai)
            };

            return DatabaseAccess.ThucThi(sql, pars);
        }


        public int Sua(NhanVien nv)
        {
            string sql = @"
        UPDATE tblNhanVien
        SET
            TenNV = @TenNV,
            GioiTinh = @GioiTinh,
            NgaySinh = @NgaySinh,
            SDT = @SDT,
            DiaChi = @DiaChi,
            MatKhau = @MatKhau,
            ChucVu = @ChucVu,
            TrangThai = @TrangThai
        WHERE MaNV = @MaNV";

            SqlParameter[] pars =
            {
        new SqlParameter("@MaNV", nv.MaNV),
        new SqlParameter("@TenNV", nv.HoTen),
        new SqlParameter("@GioiTinh", nv.GioiTinh),
        new SqlParameter("@NgaySinh", nv.NgaySinh.Date),
        new SqlParameter("@SDT", nv.SDT),
        new SqlParameter("@DiaChi", nv.DiaChi),
        new SqlParameter("@MatKhau", nv.MatKhau),
        new SqlParameter("@ChucVu", nv.VaiTro),
        new SqlParameter("@TrangThai", nv.TrangThai)
    };

            return DatabaseAccess.ThucThi(sql, pars);
        }


        public int CapNhatTrangThai(string maNV, string trangThai)
        {
            string sql = @"
                UPDATE tblNhanVien
                SET TrangThai = @TrangThai
                WHERE MaNV = @MaNV";

            SqlParameter[] pars =
            {
                new SqlParameter("@MaNV", maNV),
                new SqlParameter("@TrangThai", trangThai)
            };

            return DatabaseAccess.ThucThi(sql, pars);
        }

        public int Xoa(string maNV)
        {
            string sql =
                "DELETE FROM tblNhanVien WHERE MaNV = @MaNV";

            SqlParameter[] pars =
            {
                new SqlParameter("@MaNV", maNV)
            };

            return DatabaseAccess.ThucThi(sql, pars);
        }

        public bool KiemTraTonTai(string maNV)
        {
            string sql =
                "SELECT COUNT(*) FROM tblNhanVien WHERE MaNV = @MaNV";

            SqlParameter[] pars =
            {
                new SqlParameter("@MaNV", maNV)
            };

            return Convert.ToInt32(
                DatabaseAccess.ThucThiGiaTri(sql, pars)) > 0;
        }
    }
}
