using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TTNhom
{
    public partial class ThongTinUserActive : Form
    {
        

        private void init()
        {
            txtTen.Text = FormLogin.ten;
            if (FormLogin.quyen.Equals("0"))
            {
                txtTen.Text = "Admin";
                txtChucVu.Text = "Quản Lý";
                pictureBox1.Show();
            }
            else
            {
                txtChucVu.Text = "Nhân Viên";
            }
        }
        public ThongTinUserActive()
        {
            InitializeComponent();
            init();
        }

        

    }
}
