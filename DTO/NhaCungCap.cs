using System;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    public class NhaCungCap : INhaCungCap
    {
        public string MaNCC { get; set; } = "";
        public string TenNCC { get; set; } = "";
        public string SDT { get; set; } = "";
        public string DiaChi { get; set; } = "";

        public NhaCungCap() { }

        public NhaCungCap(string maNCC, string tenNCC, string sdt, string diaChi)
        {
            MaNCC = maNCC;
            TenNCC = tenNCC;
            SDT = sdt;
            DiaChi = diaChi;
        }

        public string LayThongTinLienHe()
        {
            return $"{TenNCC} - Hotline: {SDT}";
        }
    }
}