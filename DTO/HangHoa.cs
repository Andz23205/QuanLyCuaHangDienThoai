using System;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    public class HangHoa : IHangHoa
    {
        public string MaHang { get; set; } = "";
        public string TenHang { get; set; } = "";
        public string? MaHangSX { get; set; }
        public string? MaLoai { get; set; }
        public string? MaMau { get; set; }
        public string? MaDungLuong { get; set; }
        public decimal GiaNhap { get; set; }
        public decimal GiaBan { get; set; }
        public int SoLuongTon { get; set; }

        public HangHoa() { }

        public HangHoa(string maHang, string tenHang, string? maHangSX, string? maLoai, 
                       string? maMau, string? maDungLuong, decimal giaNhap, decimal giaBan, int soLuongTon)
        {
            MaHang = maHang;
            TenHang = tenHang;
            MaHangSX = maHangSX;
            MaLoai = maLoai;
            MaMau = maMau;
            MaDungLuong = maDungLuong;
            GiaNhap = giaNhap;
            GiaBan = giaBan;
            SoLuongTon = soLuongTon;
        }

        public decimal TinhLoiNhuan()
        {
            return GiaBan - GiaNhap;
        }
    }
}