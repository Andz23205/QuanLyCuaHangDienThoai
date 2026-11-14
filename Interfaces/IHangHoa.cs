using System;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    public interface IHangHoa
    {
        string MaHang { get; set; }
        string TenHang { get; set; }
        string? MaHangSX { get; set; }
        string? MaLoai { get; set; }
        string? MaMau { get; set; }
        string? MaDungLuong { get; set; }
        decimal GiaNhap { get; set; }
        decimal GiaBan { get; set; }
        int SoLuongTon { get; set; }

        decimal TinhLoiNhuan();
    }
}