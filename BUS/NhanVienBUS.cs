using System;
using System.Data;
using System.Text.RegularExpressions;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    public class NhanVienBUS
    {
        private readonly NhanVienDAL dal = new NhanVienDAL();

        public bool DangNhap(string tk, string mk, out NhanVien? nv, out string error)
        {
            nv = null;
            error = "";
            if (string.IsNullOrWhiteSpace(tk) || string.IsNullOrWhiteSpace(mk))
            {
                error = "Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!";
                return false;
            }

            DataTable dt = dal.KiemTraDangNhap(tk.Trim(), mk.Trim());
            if (dt.Rows.Count > 0)
            {
                DataRow r = dt.Rows[0];
                nv = new NhanVien
                {
                    MaNV = r["MaNV"].ToString()!,
                    HoTen = r["TenNV"].ToString()!,
                    TenDangNhap = tk,
                    VaiTro = r["VaiTro"]?.ToString() ?? "Nhân viên"
                };
                return true;
            }

            error = "Tên đăng nhập hoặc mật khẩu không chính xác!";
            return false;
        }

        public DataTable LayDanhSach()
        {
            return dal.LayTatCa();
        }

        public bool Them(NhanVien nv, out string error)
        {
            error = "";
            if (string.IsNullOrWhiteSpace(nv.MaNV)) { error = "Mã nhân viên không được để trống!"; return false; }
            if (string.IsNullOrWhiteSpace(nv.HoTen)) { error = "Tên nhân viên không được để trống!"; return false; }
            if (!Regex.IsMatch(nv.SDT.Trim(), @"^0\d{9}$")) { error = "Số điện thoại phải có 10 chữ số bắt đầu bằng 0!"; return false; }
            if (string.IsNullOrWhiteSpace(nv.DiaChi)) { error = "Địa chỉ không được để trống!"; return false; }
            if (string.IsNullOrWhiteSpace(nv.MatKhau)) { error = "Mật khẩu không được để trống!"; return false; }

            if (dal.KiemTraTonTai(nv.MaNV))
            {
                error = $"Mã nhân viên '{nv.MaNV}' đã tồn tại!";
                return false;
            }

            return dal.Them(nv) > 0;
        }

        public bool Sua(NhanVien nv, out string error)
        {
            error = "";
            if (string.IsNullOrWhiteSpace(nv.MaNV)) { error = "Mã nhân viên không hợp lệ!"; return false; }
            if (string.IsNullOrWhiteSpace(nv.HoTen)) { error = "Tên nhân viên không được để trống!"; return false; }
            if (!Regex.IsMatch(nv.SDT.Trim(), @"^0\d{9}$")) { error = "Số điện thoại phải có 10 chữ số bắt đầu bằng 0!"; return false; }
            if (string.IsNullOrWhiteSpace(nv.DiaChi)) { error = "Địa chỉ không được để trống!"; return false; }
            if (string.IsNullOrWhiteSpace(nv.MatKhau)) { error = "Mật khẩu không được để trống!"; return false; }

            return dal.Sua(nv) > 0;
        }

        public bool Xoa(string maNV, out string error)
        {
            error = "";
            if (string.IsNullOrWhiteSpace(maNV)) { error = "Chưa chọn nhân viên cần xóa!"; return false; }
            try
            {
                return dal.Xoa(maNV) > 0;
            }
            catch (Exception ex)
            {
                error = "Không thể xóa nhân viên (có thể nhân viên đã lập hóa đơn): " + ex.Message;
                return false;
            }
        }
    }
}