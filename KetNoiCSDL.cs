using System.Data;
using Microsoft.Data.SqlClient;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    /// <summary>
    /// Kết nối SQL Server dùng chung cho cả nhóm (Form7, Form8 đang gọi KetNoiCSDL.TaoKetNoi()).
    /// Form khác muốn truy vấn nhanh thì dùng LayBang / ThucThi / LayGiaTri bên dưới.
    /// </summary>
    internal static class KetNoiCSDL
    {
        // >>> CHỈ SỬA 2 DÒNG NÀY nếu máy bạn dùng SQL Server khác <<<
        // LocalDB (đi kèm Visual Studio): @"(localdb)\MSSQLLocalDB"
        // SQL Server Express:             @".\SQLEXPRESS"
        // SQL Server mặc định:            "."
        private const string MayChu = @".\SQLEXPRESS";
        private const string TenCSDL = "QLCuaHangBanDienThoai";

        public static string ChuoiKetNoi =>
            $"Server={MayChu};Database={TenCSDL};Integrated Security=True;TrustServerCertificate=True;";

        /// <summary>Tạo kết nối mới (chưa mở). Dùng: using (var conn = KetNoiCSDL.TaoKetNoi()) { conn.Open(); ... }</summary>
        public static SqlConnection TaoKetNoi() => new SqlConnection(ChuoiKetNoi);

        /// <summary>Tạo tham số; giá trị null tự đổi thành NULL của SQL.</summary>
        public static SqlParameter Tham(string ten, object? giaTri) =>
            new SqlParameter(ten, giaTri ?? DBNull.Value);

        /// <summary>SELECT nhiều dòng, trả về DataTable.</summary>
        public static DataTable LayBang(string sql, params SqlParameter[] thamSo)
        {
            using var conn = TaoKetNoi();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddRange(thamSo);
            using var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        /// <summary>INSERT / UPDATE / DELETE, trả về số dòng bị ảnh hưởng.</summary>
        public static int ThucThi(string sql, params SqlParameter[] thamSo)
        {
            using var conn = TaoKetNoi();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddRange(thamSo);
            conn.Open();
            return cmd.ExecuteNonQuery();
        }

        /// <summary>SELECT một giá trị (ví dụ COUNT(*)).</summary>
        public static object? LayGiaTri(string sql, params SqlParameter[] thamSo)
        {
            using var conn = TaoKetNoi();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddRange(thamSo);
            conn.Open();
            return cmd.ExecuteScalar();
        }

        /// <summary>Kiểm tra mở được kết nối không (dùng khi khởi động chương trình).</summary>
        public static bool KiemTraKetNoi(out string loi)
        {
            try
            {
                using var conn = TaoKetNoi();
                conn.Open();
                loi = "";
                return true;
            }
            catch (Exception ex)
            {
                loi = ex.Message;
                return false;
            }
        }
    }
}