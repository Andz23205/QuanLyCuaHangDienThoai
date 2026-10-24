using System.Data;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    /// <summary>
    /// Kho dữ liệu tạm trong bộ nhớ (chưa dùng SQL). Các form khác trong nhóm có thể dùng chung.
    /// Dữ liệu mất khi tắt chương trình. Sau này có SQL chỉ cần thay phần truy cập dữ liệu.
    /// </summary>
    public static class DuLieuTam
    {
        public static readonly string[] DanhSachHang = { "Apple", "Samsung", "Xiaomi", "Oppo" };
        public static readonly string[] DanhSachLoai = { "Smartphone", "Phụ kiện" };
        public static readonly string[] DanhSachMau = { "Titan tự nhiên", "Titan xanh", "Đen", "Xanh", "Bạc", "Hồng", "Trong suốt" };
        public static readonly string[] DanhSachDungLuong = { "128 GB", "256 GB", "512 GB", "1 TB" };
        public static readonly string[] DanhSachChucVu = { "Quản lý", "Bán hàng", "Thu ngân", "Kho" };

        public static DataTable Hang { get; } = TaoBangHang();
        public static DataTable NhanVien { get; } = TaoBangNhanVien();

        private static DataTable TaoBangHang()
        {
            var dt = new DataTable("Hang");
            dt.Columns.Add("MaHang", typeof(string));
            dt.Columns.Add("TenHang", typeof(string));
            dt.Columns.Add("Hang", typeof(string));
            dt.Columns.Add("Loai", typeof(string));
            dt.Columns.Add("Mau", typeof(string));
            dt.Columns.Add("DungLuong", typeof(string));
            dt.Columns.Add("GiaNhap", typeof(decimal));
            dt.Columns.Add("GiaBan", typeof(decimal));
            dt.Columns.Add("SoLuong", typeof(int));
            dt.Columns.Add("Anh", typeof(string));
            dt.PrimaryKey = new[] { dt.Columns["MaHang"]! };

            dt.Rows.Add("DT001", "iPhone 15 Pro Max", "Apple", "Smartphone", "Titan tự nhiên", "256 GB", 27000000m, 30990000m, 15, "iphone15.jpg");
            dt.Rows.Add("DT002", "Galaxy S24 Ultra", "Samsung", "Smartphone", "Đen", "512 GB", 24500000m, 28490000m, 8, DBNull.Value);
            dt.Rows.Add("DT003", "Redmi Note 13", "Xiaomi", "Smartphone", "Xanh", "128 GB", 4200000m, 5290000m, 30, DBNull.Value);
            dt.Rows.Add("DT004", "Oppo Reno11", "Oppo", "Smartphone", "Bạc", "256 GB", 7800000m, 9490000m, 12, DBNull.Value);
            dt.Rows.Add("PK001", "Ốp lưng iPhone 15", "Apple", "Phụ kiện", "Trong suốt", DBNull.Value, 80000m, 150000m, 50, DBNull.Value);
            return dt;
        }

        private static DataTable TaoBangNhanVien()
        {
            var dt = new DataTable("NhanVien");
            dt.Columns.Add("MaNV", typeof(string));
            dt.Columns.Add("TenNV", typeof(string));
            dt.Columns.Add("NgaySinh", typeof(DateTime));
            dt.Columns.Add("GioiTinh", typeof(string));
            dt.Columns.Add("SDT", typeof(string));
            dt.Columns.Add("DiaChi", typeof(string));
            dt.Columns.Add("ChucVu", typeof(string));
            dt.Columns.Add("Passw", typeof(string));
            dt.PrimaryKey = new[] { dt.Columns["MaNV"]! };

            dt.Rows.Add("NV001", "Nguyễn Văn An", new DateTime(2003, 5, 12), "Nam", "0912345678", "Hai Bà Trưng, Hà Nội", "Bán hàng", "12345678");
            dt.Rows.Add("NV002", "Trần Thị Bình", new DateTime(2002, 9, 3), "Nữ", "0987654321", "Cầu Giấy, Hà Nội", "Thu ngân", "12345678");
            dt.Rows.Add("NV003", "Lê Hoàng Minh", new DateTime(2001, 1, 21), "Nam", "0903112233", "Đống Đa, Hà Nội", "Quản lý", "12345678");
            dt.Rows.Add("NV004", "Đoàn Thu Trang", new DateTime(2003, 7, 30), "Nữ", "0977445566", "Thanh Xuân, Hà Nội", "Kho", "12345678");
            return dt;
        }

        /// <summary>Làm sạch chuỗi để dùng trong DataView.RowFilter (LIKE).</summary>
        public static string ThoatLike(string s)
        {
            var sb = new System.Text.StringBuilder();
            foreach (char c in s)
            {
                if (c == '\'') sb.Append("''");
                else if (c == '[' || c == ']' || c == '*' || c == '%') sb.Append('[').Append(c).Append(']');
                else sb.Append(c);
            }
            return sb.ToString();
        }
    }
}