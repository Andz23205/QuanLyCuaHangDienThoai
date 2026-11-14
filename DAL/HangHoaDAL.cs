using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    public class HangHoaDAL
    {
        // Goi Stored Procedure: sp_LayDanhSachHang
        public DataTable LayTatCa()
        {
            return DatabaseAccess.DocBangProc("sp_LayDanhSachHang");
        }

        // Goi Stored Procedure: sp_ThemHang
        public int Them(HangHoa h)
        {
            SqlParameter[] pars = {
                new SqlParameter("@MaHang", h.MaHang),
                new SqlParameter("@TenHang", h.TenHang),
                new SqlParameter("@MaHangSX", (object?)h.MaHangSX ?? DBNull.Value),
                new SqlParameter("@MaLoai", (object?)h.MaLoai ?? DBNull.Value),
                new SqlParameter("@MaMau", (object?)h.MaMau ?? DBNull.Value),
                new SqlParameter("@MaDungLuong", (object?)h.MaDungLuong ?? DBNull.Value),
                new SqlParameter("@DonGiaNhap", h.GiaNhap),
                new SqlParameter("@DonGiaBan", h.GiaBan),
                new SqlParameter("@SoLuongTon", h.SoLuongTon)
            };
            return DatabaseAccess.ThucThiProc("sp_ThemHang", pars);
        }

        // Goi Stored Procedure: sp_CapNhatHang
        public int Sua(HangHoa h)
        {
            SqlParameter[] pars = {
                new SqlParameter("@MaHang", h.MaHang),
                new SqlParameter("@TenHang", h.TenHang),
                new SqlParameter("@MaHangSX", (object?)h.MaHangSX ?? DBNull.Value),
                new SqlParameter("@MaLoai", (object?)h.MaLoai ?? DBNull.Value),
                new SqlParameter("@MaMau", (object?)h.MaMau ?? DBNull.Value),
                new SqlParameter("@MaDungLuong", (object?)h.MaDungLuong ?? DBNull.Value),
                new SqlParameter("@DonGiaNhap", h.GiaNhap),
                new SqlParameter("@DonGiaBan", h.GiaBan),
                new SqlParameter("@SoLuongTon", h.SoLuongTon)
            };
            return DatabaseAccess.ThucThiProc("sp_CapNhatHang", pars);
        }

        // Goi Stored Procedure: sp_XoaHang
        public int Xoa(string maHang)
        {
            SqlParameter[] pars = { new SqlParameter("@MaHang", maHang) };
            return DatabaseAccess.ThucThiProc("sp_XoaHang", pars);
        }

        // Goi Stored Procedure: sp_TimKiemHang
        public DataTable TimKiem(string? ten, string? hang, string? loai, string? mau, decimal? giaTu, decimal? giaDen)
        {
            SqlParameter[] pars = {
                new SqlParameter("@TenHang", string.IsNullOrWhiteSpace(ten) ? (object)DBNull.Value : ten),
                new SqlParameter("@MaHangSX", string.IsNullOrWhiteSpace(hang) ? (object)DBNull.Value : hang),
                new SqlParameter("@MaLoai", string.IsNullOrWhiteSpace(loai) ? (object)DBNull.Value : loai),
                new SqlParameter("@MaMau", string.IsNullOrWhiteSpace(mau) ? (object)DBNull.Value : mau),
                new SqlParameter("@GiaTu", giaTu.HasValue ? (object)giaTu.Value : DBNull.Value),
                new SqlParameter("@GiaDen", giaDen.HasValue ? (object)giaDen.Value : DBNull.Value)
            };
            return DatabaseAccess.DocBangProc("sp_TimKiemHang", pars);
        }

        public bool KiemTraTonTai(string maHang)
        {
            object? res = DatabaseAccess.ThucThiGiaTri("SELECT COUNT(*) FROM tblHang WHERE MaHang=@Ma",
                new[] { new SqlParameter("@Ma", maHang) });
            return Convert.ToInt32(res) > 0;
        }
    }
}