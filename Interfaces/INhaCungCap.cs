using System;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    public interface INhaCungCap
    {
        string MaNCC { get; set; }
        string TenNCC { get; set; }
        string SDT { get; set; }
        string DiaChi { get; set; }

        string LayThongTinLienHe();
    }
}