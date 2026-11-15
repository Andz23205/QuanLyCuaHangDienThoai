
using System;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    public class KhachHang : Nguoi, IKhachHang
    {
        public string MaKH { get; set; } = "";
        public string Email { get; set; } = "";

        public KhachHang()
        {
        }

        // Constructor cũ: giữ tương thích với code đang sử dụng 4 tham số
        public KhachHang(string maKH, string tenKH, string sdt, string diaChi)
            : this(maKH, tenKH, sdt, diaChi, "")
        {
        }

        // Constructor mới: có thêm Email
        public KhachHang(string maKH, string tenKH, string sdt, string diaChi, string email)
            : base(tenKH, sdt, diaChi, "Khác", DateTime.Today)
        {
            MaKH = maKH;
            Email = email;
        }

        public string LayThongTinRutGon()
        {
            return $"{MaKH} - {HoTen} ({SDT})";
        }
    }
}
