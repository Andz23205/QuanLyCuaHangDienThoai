using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
            txtMatKhau.UseSystemPasswordChar = true;
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string maNhanVien = txtMaNhanVien.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();

            if (maNhanVien == "" || matKhau == "")
            {
                MessageBox.Show(
                    "Vui lòng nhập đầy đủ mã nhân viên và mật khẩu!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

  
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void Form9_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
