using System;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    public interface INhanVien
    {
        string MaNV { get; set; }
        string TenDangNhap { get; set; }
        string MatKhau { get; set; }
        string VaiTro { get; set; }

        bool KiemTraQuyenQuanLy();
    }
}