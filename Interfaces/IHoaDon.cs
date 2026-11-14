using System;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    public interface IHoaDon
    {
        string MaHD { get; set; }
        string MaNV { get; set; }
        DateTime NgayLap { get; set; }
        decimal TongTien { get; set; }

        decimal TinhTongTien();
    }
}