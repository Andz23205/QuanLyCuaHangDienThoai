
using System;
using System.Data;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    public class ThongKeDAL
    {
        // ==========================================
        // 1. TỔNG SỐ SẢN PHẨM
        // ==========================================
        public int DemTongSanPham()
        {
            string sql = @"
                SELECT COUNT(*)
                FROM dbo.tblHang";

            return Convert.ToInt32(
                DatabaseAccess.ThucThiGiaTri(sql));
        }

        // ==========================================
        // 2. TỔNG SỐ KHÁCH HÀNG
        // ==========================================
        public int DemTongKhachHang()
        {
            string sql = @"
                SELECT COUNT(*)
                FROM dbo.tblKhachHang";

            return Convert.ToInt32(
                DatabaseAccess.ThucThiGiaTri(sql));
        }

        // ==========================================
        // 3. SỐ HÓA ĐƠN HÔM NAY
        // ==========================================
        public int DemHoaDonHomNay()
        {
            string sql = @"
                SELECT COUNT(*)
                FROM dbo.tblHoaDonBan
                WHERE NgayLap >= CONVERT(date, GETDATE())
                  AND NgayLap < DATEADD(day, 1, CONVERT(date, GETDATE()))";

            return Convert.ToInt32(
                DatabaseAccess.ThucThiGiaTri(sql));
        }

        // ==========================================
        // 4. DOANH THU HÔM NAY
        // ==========================================
        public decimal TinhDoanhThuHomNay()
        {
            string sql = @"
                SELECT ISNULL(SUM(TongTien), 0)
                FROM dbo.tblHoaDonBan
                WHERE NgayLap >= CONVERT(date, GETDATE())
                  AND NgayLap < DATEADD(day, 1, CONVERT(date, GETDATE()))";

            return Convert.ToDecimal(
                DatabaseAccess.ThucThiGiaTri(sql));
        }

        // ==========================================
        // 5. DOANH THU 7 NGÀY GẦN NHẤT
        // Bao gồm cả ngày không có hóa đơn
        // ==========================================
        public DataTable LayDoanhThu7Ngay()
        {
            string sql = @"
                ;WITH NgayGanDay AS
                (
                    SELECT
                        CONVERT(date, DATEADD(day, -6, GETDATE())) AS Ngay

                    UNION ALL

                    SELECT DATEADD(day, 1, Ngay)
                    FROM NgayGanDay
                    WHERE Ngay < CONVERT(date, GETDATE())
                )
                SELECT
                    n.Ngay,
                    ISNULL(SUM(h.TongTien), 0) AS DoanhThu
                FROM NgayGanDay n
                LEFT JOIN dbo.tblHoaDonBan h
                    ON h.NgayLap >= n.Ngay
                   AND h.NgayLap < DATEADD(day, 1, n.Ngay)
                GROUP BY n.Ngay
                ORDER BY n.Ngay
                OPTION (MAXRECURSION 7)";

            return DatabaseAccess.DocBang(sql);
        }

        // ==========================================
        // 6. TOP 5 SẢN PHẨM BÁN CHẠY
        // ==========================================
        public DataTable LayTop5SanPhamBanChay()
        {
            string sql = @"
                SELECT TOP 5
                    h.MaHang,
                    h.TenHang,
                    SUM(ct.SoLuong) AS TongSoLuongBan,
                    SUM(ct.ThanhTien) AS TongDoanhThu
                FROM dbo.tblChiTietHDB ct
                INNER JOIN dbo.tblHang h
                    ON ct.MaHang = h.MaHang
                GROUP BY h.MaHang, h.TenHang
                ORDER BY SUM(ct.SoLuong) DESC";

            return DatabaseAccess.DocBang(sql);
        }

        // ==========================================
        // 7. SẢN PHẨM SẮP HẾT HÀNG
        // Mặc định cảnh báo khi tồn kho <= 10
        // ==========================================
        public DataTable LaySanPhamSapHetHang()
        {
            string sql = @"
                SELECT
                    MaHang,
                    TenHang,
                    SoLuongTon
                FROM dbo.tblHang
                WHERE SoLuongTon <= 10
                ORDER BY SoLuongTon ASC";

            return DatabaseAccess.DocBang(sql);
        }

        // ==========================================
        // 8. TỔNG SỐ LƯỢNG HÀNG TỒN KHO
        // ==========================================
        public int DemTongHangTonKho()
        {
            string sql = @"
                SELECT ISNULL(SUM(SoLuongTon), 0)
                FROM dbo.tblHang";

            return Convert.ToInt32(
                DatabaseAccess.ThucThiGiaTri(sql));
        }
    }
}
