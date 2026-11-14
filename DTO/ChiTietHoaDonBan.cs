using System;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    public class ChiTietHoaDonBan
    {
        public string MaHDB { get; set; } = "";
        public string MaHang { get; set; } = "";
        public string TenHang { get; set; } = "";
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal GiamGia { get; set; }
        public decimal ThanhTien { get; set; }

        public ChiTietHoaDonBan() { }

        public ChiTietHoaDonBan(string maHDB, string maHang, string tenHang, int soLuong, decimal donGia, decimal giamGia)
        {
            MaHDB = maHDB;
            MaHang = maHang;
            TenHang = tenHang;
            SoLuong = soLuong;
            DonGia = donGia;
            GiamGia = giamGia;
            ThanhTien = (soLuong * donGia) * (1 - giamGia / 100m);
        }
    }
}