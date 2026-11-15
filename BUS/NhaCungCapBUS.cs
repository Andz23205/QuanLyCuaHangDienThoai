
using System;
using System.Data;
using System.Text.RegularExpressions;
using Microsoft.Data.SqlClient;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    public class NhaCungCapBUS
    {
        private readonly NhaCungCapDAL dal = new NhaCungCapDAL();

        public DataTable LayDanhSach()
        {
            return dal.LayTatCa();
        }

        private bool KiemTraThongTin(NhaCungCap ncc, out string error)
        {
            error = "";

            if (string.IsNullOrWhiteSpace(ncc.MaNCC))
            {
                error = "Mã nhà cung cấp không được để trống!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(ncc.TenNCC))
            {
                error = "Tên nhà cung cấp không được để trống!";
                return false;
            }

            if (!Regex.IsMatch(ncc.SDT.Trim(), @"^0\d{9}$"))
            {
                error = "Số điện thoại phải gồm 10 chữ số và bắt đầu bằng số 0!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(ncc.DiaChi))
            {
                error = "Địa chỉ không được để trống!";
                return false;
            }

            if (!string.IsNullOrWhiteSpace(ncc.Email) &&
                !Regex.IsMatch(ncc.Email.Trim(),
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                error = "Địa chỉ email không hợp lệ!";
                return false;
            }

            if (ncc.Email?.Length > 255)
            {
                error = "Email không được vượt quá 255 ký tự!";
                return false;
            }

            if (ncc.NguoiLH?.Length > 100)
            {
                error = "Tên người liên hệ không được vượt quá 100 ký tự!";
                return false;
            }

            return true;
        }

        public bool Them(NhaCungCap ncc, out string error)
        {
            error = "";

            if (!KiemTraThongTin(ncc, out error))
                return false;

            if (dal.KiemTraTonTai(ncc.MaNCC))
            {
                error = $"Mã nhà cung cấp '{ncc.MaNCC}' đã tồn tại!";
                return false;
            }

            try
            {
                if (dal.Them(ncc) > 0)
                    return true;

                error = "Thêm nhà cung cấp không thành công!";
                return false;
            }
            catch (Exception ex)
            {
                error = "Lỗi thêm nhà cung cấp: " + ex.Message;
                return false;
            }
        }

        public bool Sua(NhaCungCap ncc, out string error)
        {
            error = "";

            if (!KiemTraThongTin(ncc, out error))
                return false;

            try
            {
                if (!dal.KiemTraTonTai(ncc.MaNCC))
                {
                    error = "Nhà cung cấp không còn tồn tại trong cơ sở dữ liệu!";
                    return false;
                }

                int ketQua = dal.Sua(ncc);

                if (ketQua > 0)
                    return true;

                error = "Không có dữ liệu nào được cập nhật!";
                return false;
            }
            catch (Exception ex)
            {
                error = "Lỗi cập nhật nhà cung cấp: " + ex.Message;
                return false;
            }
        }

        public bool Xoa(string maNCC, out string error)
        {
            error = "";

            if (string.IsNullOrWhiteSpace(maNCC))
            {
                error = "Chưa chọn nhà cung cấp cần xóa!";
                return false;
            }

            try
            {
                if (!dal.KiemTraTonTai(maNCC))
                {
                    error = "Nhà cung cấp không còn tồn tại trong cơ sở dữ liệu!";
                    return false;
                }

                int ketQua = dal.Xoa(maNCC);

                if (ketQua > 0)
                    return true;

                error = "Không tìm thấy nhà cung cấp cần xóa!";
                return false;
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                error =
                    "Không thể xóa nhà cung cấp này vì đã có hóa đơn nhập liên quan!\n\n" +
                    "Hãy giữ lại nhà cung cấp để bảo toàn lịch sử hóa đơn.";
                return false;
            }
            catch (Exception ex)
            {
                error = "Lỗi xóa nhà cung cấp: " + ex.Message;
                return false;
            }
        }
    }
}
