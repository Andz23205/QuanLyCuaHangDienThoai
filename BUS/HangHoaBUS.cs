using System;
using System.Data;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    public class HangHoaBUS
    {
        private readonly HangHoaDAL dal = new HangHoaDAL();

        public DataTable LayDanhSach()
        {
            return dal.LayTatCa();
        }

        public bool Them(HangHoa h, out string error)
        {
            error = "";

            if (string.IsNullOrWhiteSpace(h.MaHang))
            {
                error = "Mã hàng không được để trống!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(h.TenHang))
            {
                error = "Tên hàng không được để trống!";
                return false;
            }

            if (h.GiaNhap < 0)
            {
                error = "Giá nhập không thể âm!";
                return false;
            }

            if (h.GiaBan < 0)
            {
                error = "Giá bán không thể âm!";
                return false;
            }

            if (h.SoLuongTon < 0)
            {
                error = "Số lượng tồn không thể âm!";
                return false;
            }

            try
            {
                if (dal.KiemTraTonTai(h.MaHang))
                {
                    error = $"Mã hàng '{h.MaHang}' đã tồn tại trong hệ thống!";
                    return false;
                }

                int soDong = dal.Them(h);

                if (soDong > 0)
                    return true;

                // Kiểm tra lại trong SQL Server để tránh báo thất bại
                // khi dữ liệu thực tế đã được thêm thành công.
                if (dal.KiemTraTonTai(h.MaHang))
                    return true;

                error = "Không thể thêm sản phẩm. SQL Server không ghi nhận dữ liệu!";
                return false;
            }
            catch (Exception ex)
            {
                // Nếu có lỗi sau khi INSERT, kiểm tra xem sản phẩm
                // đã thực sự tồn tại trong cơ sở dữ liệu hay chưa.
                try
                {
                    if (dal.KiemTraTonTai(h.MaHang))
                        return true;
                }
                catch
                {
                    // Giữ lại thông báo lỗi ban đầu.
                }

                error = "Lỗi thêm sản phẩm: " + ex.Message;
                return false;
            }
        }

        public bool Sua(HangHoa h, out string error)
        {
            error = "";
            if (string.IsNullOrWhiteSpace(h.MaHang)) { error = "Mã hàng không hợp lệ!"; return false; }
            if (string.IsNullOrWhiteSpace(h.TenHang)) { error = "Tên hàng không được để trống!"; return false; }
            if (h.GiaNhap < 0) { error = "Giá nhập không thể âm!"; return false; }
            if (h.GiaBan < 0) { error = "Giá bán không thể âm!"; return false; }
            if (h.SoLuongTon < 0) { error = "Số lượng tồn không thể âm!"; return false; }

            return dal.Sua(h) > 0;
        }

        public bool Xoa(string maHang, out string error)
        {
            error = "";
            if (string.IsNullOrWhiteSpace(maHang)) { error = "Chưa chọn mặt hàng cần xóa!"; return false; }
            try
            {
                return dal.Xoa(maHang) > 0;
            }
            catch (Exception ex)
            {
                error = "Không thể xóa mặt hàng (có thể mặt hàng đã phát sinh hóa đơn): " + ex.Message;
                return false;
            }
        }

        public DataTable TimKiem(string? ten, string? hang, string? loai, string? mau, decimal? giaTu, decimal? giaDen)
        {
            return dal.TimKiem(ten, hang, loai, mau, giaTu, giaDen);
        }
    }
}