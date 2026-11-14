using System;
using System.Data;
using System.Text.RegularExpressions;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    public class NhaCungCapBUS
    {
        private readonly NhaCungCapDAL dal = new NhaCungCapDAL();

        public DataTable LayDanhSach()
        {
            return dal.LayTatCa();
        }

        public bool Them(NhaCungCap ncc, out string error)
        {
            error = "";
            if (string.IsNullOrWhiteSpace(ncc.MaNCC)) { error = "Mã NCC không được để trống!"; return false; }
            if (string.IsNullOrWhiteSpace(ncc.TenNCC)) { error = "Tên NCC không được để trống!"; return false; }
            if (!Regex.IsMatch(ncc.SDT.Trim(), @"^0\d{9}$")) { error = "Số điện thoại không hợp lệ!"; return false; }
            if (string.IsNullOrWhiteSpace(ncc.DiaChi)) { error = "Địa chỉ không được để trống!"; return false; }

            if (dal.KiemTraTonTai(ncc.MaNCC))
            {
                error = $"Mã nhà cung cấp '{ncc.MaNCC}' đã tồn tại!";
                return false;
            }

            return dal.Them(ncc) > 0;
        }

        public bool Sua(NhaCungCap ncc, out string error)
        {
            error = "";
            if (string.IsNullOrWhiteSpace(ncc.MaNCC)) { error = "Mã NCC không hợp lệ!"; return false; }
            if (string.IsNullOrWhiteSpace(ncc.TenNCC)) { error = "Tên NCC không được để trống!"; return false; }
            if (!Regex.IsMatch(ncc.SDT.Trim(), @"^0\d{9}$")) { error = "Số điện thoại không hợp lệ!"; return false; }
            if (string.IsNullOrWhiteSpace(ncc.DiaChi)) { error = "Địa chỉ không được để trống!"; return false; }

            return dal.Sua(ncc) > 0;
        }

        public bool Xoa(string maNCC, out string error)
        {
            error = "";
            if (string.IsNullOrWhiteSpace(maNCC)) { error = "Chưa chọn nhà cung cấp cần xóa!"; return false; }
            try
            {
                return dal.Xoa(maNCC) > 0;
            }
            catch (Exception ex)
            {
                error = "Không thể xóa nhà cung cấp: " + ex.Message;
                return false;
            }
        }
    }
}