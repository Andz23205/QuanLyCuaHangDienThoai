
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Linq;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    public class KhachHangBUS
    {
        private readonly KhachHangDAL dal = new KhachHangDAL();

        public DataTable LayDanhSach()
        {
            return dal.LayTatCa();
        }

        public bool Them(KhachHang kh, out string error)
        {
            error = "";

            if (string.IsNullOrWhiteSpace(kh.MaKH))
            {
                error = "Mã khách hàng không được để trống!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(kh.HoTen))
            {
                error = "Tên khách hàng không được để trống!";
                return false;
            }

            if (!Regex.IsMatch(kh.SDT.Trim(), @"^0\d{9}$"))
            {
                error = "Số điện thoại phải gồm 10 chữ số và bắt đầu bằng 0!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(kh.DiaChi))
            {
                error = "Địa chỉ không được để trống!";
                return false;
            }

            if (dal.KiemTraTonTai(kh.MaKH))
            {
                error = $"Mã khách hàng '{kh.MaKH}' đã tồn tại!";
                return false;
            }

            try
            {
                if (dal.Them(kh) > 0)
                    return true;

                error = "Không thể thêm khách hàng!";
                return false;
            }
            catch (Exception ex)
            {
                error = "Lỗi thêm khách hàng: " + ex.Message;
                return false;
            }
        }

        public bool Sua(KhachHang kh, out string error)
        {
            error = "";

            if (string.IsNullOrWhiteSpace(kh.MaKH))
            {
                error = "Mã khách hàng không hợp lệ!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(kh.HoTen))
            {
                error = "Tên khách hàng không được để trống!";
                return false;
            }

            if (!Regex.IsMatch(kh.SDT.Trim(), @"^0\d{9}$"))
            {
                error = "Số điện thoại phải gồm 10 chữ số và bắt đầu bằng 0!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(kh.DiaChi))
            {
                error = "Địa chỉ không được để trống!";
                return false;
            }

            try
            {
                if (dal.Sua(kh) > 0)
                    return true;

                error = "Không tìm thấy khách hàng cần sửa!";
                return false;
            }
            catch (Exception ex)
            {
                error = "Lỗi cập nhật khách hàng: " + ex.Message;
                return false;
            }
        }


        public bool Xoa(string maKH, out string error)
        {
            error = "";

            if (string.IsNullOrWhiteSpace(maKH))
            {
                error = "Chưa chọn khách hàng cần xóa!";
                return false;
            }

            try
            {
                // Kiểm tra khách hàng đã phát sinh hóa đơn chưa
                DataTable dtHoaDon = dal.LayHoaDonCuaKhachHang(maKH);

                if (dtHoaDon.Rows.Count > 0)
                {
                    string danhSachHoaDon = string.Join(
                        ", ",
                        dtHoaDon.AsEnumerable()
                            .Select(r => r["MaHDB"].ToString())
                    );

                    error =
                        $"Không thể xóa khách hàng {maKH} vì đã phát sinh hóa đơn.\n\n" +
                        $"Danh sách hóa đơn liên quan:\n{danhSachHoaDon}\n\n" +
                        "Để bảo vệ lịch sử giao dịch, khách hàng này không thể bị xóa.";

                    return false;
                }

                // Chưa có hóa đơn thì cho phép xóa
                if (dal.Xoa(maKH) > 0)
                    return true;

                error = "Không tìm thấy khách hàng cần xóa!";
                return false;
            }
            catch (Exception ex)
            {
                error = "Không thể xóa khách hàng: " + ex.Message;
                return false;
            }
        }

    }
}
