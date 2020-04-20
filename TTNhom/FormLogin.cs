using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TTNhom
{
    public partial class FormLogin : Form
    {
        DBAccess dbAccess = new DBAccess();
        DataTable dt = new DataTable();
        private static SqlConnection conn = new SqlConnection(DBAccess.connString);
        private static SqlDataAdapter adt = new SqlDataAdapter();

        public static string ten;
        public static string quyen;
        public static string TaiKhoan;


        public FormLogin()
        {
            InitializeComponent();
        }


        private void btnHuy_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            TaiKhoan = txtUser.Text;
            string query = "SELECT * FROM dbo.TaiKhoan WHERE TaiKhoan = '" + txtUser.Text + "' AND MatKhau = '" + txtPass.Text + "' ";
            dbAccess.readDataToAdapter(query, dt);
            int a = dt.Rows.Count;
            if (a != 0)
            {
                this.Hide();
                adt = new SqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adt.Fill(table);

                ten = table.Rows[0][2].ToString();
                quyen = table.Rows[0][3].ToString();

                MainForm main = new MainForm();
                main.Show();
            }
            else
            {
                MessageBox.Show("Tài Khoản hoặc Mật Khẩu không đúng !! Vui Lòng thử lại.");
                txtUser.Clear();
                txtPass.Clear();
                txtUser.Focus();
            }
        }
    }
}
