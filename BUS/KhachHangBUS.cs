
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

        // Thêm khách hàng
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

            if (!Regex.IsMatch(kh.SDT ?? "", @"^0\d{9}$"))
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

        // Sửa khách hàng
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

            if (!Regex.IsMatch(kh.SDT ?? "", @"^0\d{9}$"))
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

        // Xóa khách hàng
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

        // ĐĂNG KÝ TÀI KHOẢN KHÁCH HÀNG
        public bool DangKy(KhachHang kh, out string error)
        {
            error = "";

            if (string.IsNullOrWhiteSpace(kh.HoTen))
            {
                error = "Vui lòng nhập họ tên!";
                return false;
            }

            if (!Regex.IsMatch(kh.SDT ?? "", @"^0\d{9}$"))
            {
                error = "Số điện thoại phải gồm 10 chữ số và bắt đầu bằng 0!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(kh.Email) ||
                !Regex.IsMatch(kh.Email.Trim(),
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                error = "Email không hợp lệ!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(kh.TaiKhoan) ||
                kh.TaiKhoan.Trim().Length < 4)
            {
                error = "Tên tài khoản phải có ít nhất 4 ký tự!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(kh.MatKhau) ||
                kh.MatKhau.Length < 6)
            {
                error = "Mật khẩu phải có ít nhất 6 ký tự!";
                return false;
            }

            try
            {
                kh.HoTen = kh.HoTen.Trim();
                kh.SDT = kh.SDT.Trim();
                kh.Email = kh.Email.Trim();
                kh.TaiKhoan = kh.TaiKhoan.Trim();

                if (dal.KiemTraTaiKhoan(kh.TaiKhoan))
                {
                    error = "Tên tài khoản đã tồn tại!";
                    return false;
                }

                if (dal.KiemTraEmail(kh.Email))
                {
                    error = "Email này đã được đăng ký!";
                    return false;
                }

                if (dal.DangKyTaiKhoan(kh) > 0)
                    return true;

                error = "Đăng ký tài khoản không thành công!";
                return false;
            }
            catch (Exception ex)
            {
                error = "Lỗi đăng ký tài khoản: " + ex.Message;
                return false;
            }
        }

        // ĐĂNG NHẬP TÀI KHOẢN KHÁCH HÀNG
        public bool DangNhap(
            string taiKhoan,
            string matKhau,
            out KhachHang? kh,
            out string error)
        {
            kh = null;
            error = "";

            if (string.IsNullOrWhiteSpace(taiKhoan) ||
                string.IsNullOrWhiteSpace(matKhau))
            {
                error = "Vui lòng nhập tài khoản và mật khẩu!";
                return false;
            }

            try
            {
                kh = dal.DangNhap(taiKhoan.Trim(), matKhau);

                if (kh != null)
                    return true;

                error = "Tên tài khoản hoặc mật khẩu không chính xác!";
                return false;
            }
            catch (Exception ex)
            {
                error = "Lỗi đăng nhập: " + ex.Message;
                return false;
            }
        }
    }
}
