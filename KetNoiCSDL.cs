using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    public static class KetNoiCSDL
    {
        public static string ChuoiKetNoi = @"Server=.\SQLEXPRESS;Database=QLCuaHangBanDienThoai;Integrated Security=True;TrustServerCertificate=True;";

        public static SqlConnection TaoKetNoi()
        {
            return new SqlConnection(ChuoiKetNoi);
        }

        public static DataTable DocBang(string sql, SqlParameter[]? parameters = null)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = TaoKetNoi())
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (parameters != null && parameters.Length > 0)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public static int ThucThi(string sql, SqlParameter[]? parameters = null)
        {
            using (SqlConnection conn = TaoKetNoi())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (parameters != null && parameters.Length > 0)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static object? ThucThiGiaTri(string sql, SqlParameter[]? parameters = null)
        {
            using (SqlConnection conn = TaoKetNoi())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (parameters != null && parameters.Length > 0)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    return cmd.ExecuteScalar();
                }
            }
        }
    }
}