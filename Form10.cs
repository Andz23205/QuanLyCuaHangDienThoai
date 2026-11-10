using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Cửa_Hàng_Bán_Điện_Thoại___Nhóm_4
{
    public partial class Form10 : Form
    {
        private Dictionary<Type, Form> cacFormDangMo = new Dictionary<Type, Form>();

        public Form10()
        {
            InitializeComponent();
            this.IsMdiContainer = true;

            this.WindowState = FormWindowState.Maximized;

            // Hiển thị ngày hiện tại
            tslNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");

            // Thêm chức năng vào menu
            KhoiTaoMenu();

            MoForm<Form1>();
        }
        private void MoForm<T>() where T : Form, new()
        {
            Type loaiForm = typeof(T);

            // Nếu Form đã mở thì đưa lên trước
            if (cacFormDangMo.ContainsKey(loaiForm))
            {
                Form formCu = cacFormDangMo[loaiForm];

                if (!formCu.IsDisposed)
                {
                    formCu.Activate();
                    return;
                }

                cacFormDangMo.Remove(loaiForm);
            }

            // Nếu chưa mở thì tạo Form mới
            T formMoi = new T();

            formMoi.MdiParent = this;
            formMoi.WindowState = FormWindowState.Maximized;

            cacFormDangMo.Add(loaiForm, formMoi);

            formMoi.FormClosed += (s, e) =>
            {
                cacFormDangMo.Remove(loaiForm);
            };

            formMoi.Show();
        }
        private void KhoiTaoMenu()
        {
            // Danh mục
            đIệnThoạiToolStripMenuItem.Click += (s, e) => MoForm<Form1>();

            danhMụcFrmDanhMucToolStripMenuItem.Click +=
                (s, e) => MoForm<frmDanhMuc>();

            nhânViênFrmNhanVienToolStripMenuItem.Click +=
                (s, e) => MoForm<Form2>();

            kháchHàngToolStripMenuItem.Click +=
                (s, e) => MoForm<Form3>();

            nhàCungCấpFrmNhaCungcapToolStripMenuItem.Click +=
                (s, e) => MoForm<Form4>();

            // Tìm kiếm
            ToolStripMenuItem timKiem = new ToolStripMenuItem("Tìm kiếm dữ liệu");
            timKiem.Click += (s, e) => MoForm<Form6>();
            mnuTimKiem.DropDownItems.Add(timKiem);

            // Hóa đơn ( thang nao lam phan nay thi de no hien len form 7 va form 8 ) 

            // Thoat 
            mnuThoat.Click += (s, e) =>
            {
                DialogResult ketQua = MessageBox.Show(
                    "Bạn có chắc chắn muốn thoát chương trình?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (ketQua == DialogResult.Yes)
                {
                    Application.Exit();
                }
            };
        }



        private void đIệnThoạiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void danhMụcFrmDanhMucToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
