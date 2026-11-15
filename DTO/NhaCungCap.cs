
namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    public class NhaCungCap : INhaCungCap
    {
        public string MaNCC { get; set; } = "";
        public string TenNCC { get; set; } = "";
        public string SDT { get; set; } = "";
        public string DiaChi { get; set; } = "";
        public string Email { get; set; } = "";
        public string NguoiLH { get; set; } = "";

        public NhaCungCap() { }

        public NhaCungCap(
            string maNCC,
            string tenNCC,
            string sdt,
            string diaChi,
            string email,
            string nguoiLH)
        {
            MaNCC = maNCC;
            TenNCC = tenNCC;
            SDT = sdt;
            DiaChi = diaChi;
            Email = email;
            NguoiLH = nguoiLH;
        }

        // Giữ constructor 4 tham số để không ảnh hưởng
        // đến những vị trí khác đang sử dụng constructor cũ.
        public NhaCungCap(
            string maNCC,
            string tenNCC,
            string sdt,
            string diaChi)
        {
            MaNCC = maNCC;
            TenNCC = tenNCC;
            SDT = sdt;
            DiaChi = diaChi;
        }

        public string LayThongTinLienHe()
        {
            return $"{TenNCC} - Hotline: {SDT} - Email: {Email} - Người liên hệ: {NguoiLH}";
        }
    }
}
