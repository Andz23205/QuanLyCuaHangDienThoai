using System;
using System.Data;
using System.Text.RegularExpressions;

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
            if (string.IsNullOrWhiteSpace(kh.MaKH)) { error = "Mã khách hàng không được để trống!"; return false; }
            if (string.IsNullOrWhiteSpace(kh.HoTen)) { error = "Tên khách hàng không được để trống!"; return false; }
            if (!Regex.IsMatch(kh.SDT.Trim(), @"^0\d{9}$")) { error = "Số điện thoại không hợp lệ!"; return false; }
            if (string.IsNullOrWhiteSpace(kh.DiaChi)) { error = "Địa chỉ không được để trống!"; return false; }

            if (dal.KiemTraTonTai(kh.MaKH))
            {
                error = $"Mã khách hàng '{kh.MaKH}' đã tồn tại!";
                return false;
            }

            return dal.Them(kh) > 0;
        }

        public bool Sua(KhachHang kh, out string error)
        {
            error = "";
            if (string.IsNullOrWhiteSpace(kh.MaKH)) { error = "Mã khách hàng không hợp lệ!"; return false; }
            if (string.IsNullOrWhiteSpace(kh.HoTen)) { error = "Tên khách hàng không được để trống!"; return false; }
            if (!Regex.IsMatch(kh.SDT.Trim(), @"^0\d{9}$")) { error = "Số điện thoại không hợp lệ!"; return false; }
            if (string.IsNullOrWhiteSpace(kh.DiaChi)) { error = "Địa chỉ không được để trống!"; return false; }

            return dal.Sua(kh) > 0;
        }

        public bool Xoa(string maKH, out string error)
        {
            error = "";
            if (string.IsNullOrWhiteSpace(maKH)) { error = "Chưa chọn khách hàng cần xóa!"; return false; }
            try
            {
                return dal.Xoa(maKH) > 0;
            }
            catch (Exception ex)
            {
                error = "Không thể xóa khách hàng: " + ex.Message;
                return false;
            }
        }
    }
}