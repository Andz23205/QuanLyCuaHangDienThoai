using System;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    // Lop truu tuong co so the hien tinh ke thua
    public abstract class Nguoi
    {
        public string HoTen { get; set; } = "";
        public string SDT { get; set; } = "";
        public string DiaChi { get; set; } = "";
        public string GioiTinh { get; set; } = "Nam";
        public DateTime NgaySinh { get; set; } = DateTime.Today;

        protected Nguoi() { }

        protected Nguoi(string hoTen, string sdt, string diaChi, string gioiTinh, DateTime ngaySinh)
        {
            HoTen = hoTen;
            SDT = sdt;
            DiaChi = diaChi;
            GioiTinh = gioiTinh;
            NgaySinh = ngaySinh;
        }

        public virtual string LayThongTin()
        {
            return $"{HoTen} - SĐT: {SDT} - ĐC: {DiaChi}";
        }
    }
}