using System;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    public class KhachHang : Nguoi, IKhachHang
    {
        public string MaKH { get; set; } = "";

        public KhachHang() { }

        public KhachHang(string maKH, string tenKH, string sdt, string diaChi)
            : base(tenKH, sdt, diaChi, "Khác", DateTime.Today)
        {
            MaKH = maKH;
        }

        public string LayThongTinRutGon()
        {
            return $"{MaKH} - {HoTen} ({SDT})";
        }
    }
}