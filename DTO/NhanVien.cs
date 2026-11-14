using System;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    public class NhanVien : Nguoi, INhanVien
    {
        public string MaNV { get; set; } = "";
        public string TenDangNhap { get; set; } = "";
        public string MatKhau { get; set; } = "";
        public string VaiTro { get; set; } = "Nhân viên";

        public NhanVien() { }

        public NhanVien(string maNV, string tenNV, string gioiTinh, DateTime ngaySinh, 
                        string sdt, string diaChi, string tenDangNhap, string matKhau, string vaiTro)
            : base(tenNV, sdt, diaChi, gioiTinh, ngaySinh)
        {
            MaNV = maNV;
            TenDangNhap = tenDangNhap;
            MatKhau = matKhau;
            VaiTro = vaiTro;
        }

        public bool KiemTraQuyenQuanLy()
        {
            return VaiTro.Equals("Quản lý", StringComparison.OrdinalIgnoreCase) || 
                   VaiTro.Equals("Admin", StringComparison.OrdinalIgnoreCase);
        }

        public override string LayThongTin()
        {
            return $"[NV] {MaNV} - {HoTen} ({VaiTro})";
        }
    }
}