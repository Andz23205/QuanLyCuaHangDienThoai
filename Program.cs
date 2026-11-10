namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            using (Form9 dangNhap = new Form9())
            {
                if (dangNhap.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new Form10());
                }
            }
        }
    }
}