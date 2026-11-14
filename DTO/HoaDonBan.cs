using System;
using System.Collections.Generic;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    // The hien quan he KET TAP (Composition): Hoa don gom nhieu chi tiet hoa don
    public class HoaDonBan : IHoaDon
    {
        public string MaHD { get; set; } = "";
        public string MaNV { get; set; } = "";
        public string MaKH { get; set; } = "";
        public DateTime NgayLap { get; set; } = DateTime.Now;
        public decimal TongTien { get; set; }

        // Danh sach ket tap
        public List<ChiTietHoaDonBan> ChiTietList { get; set; } = new List<ChiTietHoaDonBan>();

        public HoaDonBan() { }

        public HoaDonBan(string maHD, string maNV, string maKH, DateTime ngayLap)
        {
            MaHD = maHD;
            MaNV = maNV;
            MaKH = maKH;
            NgayLap = ngayLap;
        }

        public decimal TinhTongTien()
        {
            decimal tong = 0;
            foreach (var item in ChiTietList)
            {
                tong += item.ThanhTien;
            }
            TongTien = tong;
            return tong;
        }
    }
}