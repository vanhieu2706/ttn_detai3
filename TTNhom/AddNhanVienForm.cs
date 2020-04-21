using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TTNhom
{
    public partial class AddNhanVienForm : Form
    {
        private static SqlConnection conn = new SqlConnection(DBAccess.connString);
        private static SqlDataAdapter adt = new SqlDataAdapter();
        private static SqlCommand cmd = new SqlCommand();
        DBAccess access = new DBAccess();
        DataTable table;
        string ten, diaChi, ngaySinh, gioiTinh, sdt, ngayVaoLam;
        public AddNhanVienForm()
        {
            InitializeComponent();
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            ten = txtTen.Text.Trim();
            ngaySinh = dateTimePicker1.Value.Date.ToString("yyyy-MM-dd HH:mm:ss");
            diaChi = txtDiaChi.Text;
            sdt = txtPhone.Text;
            ngayVaoLam = dateTimePicker2.Value.Date.ToString("yyyy-MM-dd HH:mm:ss");

            if (radioButtonNam.Checked == true)
            {
                gioiTinh = "1";
            }
            else
            {
                gioiTinh = "0";
            }
            try
            {
                if (ten.Equals("") || ngaySinh.Equals("") || diaChi.Equals("") || sdt.Equals("") || gioiTinh.Equals(""))
                {
                    MessageBox.Show("Thieu Thong tin");

                }
                else
                {
                    conn.Open();
                    table = new DataTable();
                    string queryInsert = "INSERT dbo.NhanVien( HoTenNV ,DiaChiNV ,NgaySinh ,Sex ,SDT ,NgayVaoLam) VALUES" +
                        " ( N'"+ten+"' , N'"+diaChi+"' , '"+ngaySinh+"' , '"+gioiTinh+"' , '"+sdt+"' , '"+ngayVaoLam+"' )";
                    cmd = new SqlCommand(queryInsert, conn);
                    cmd.CommandType = CommandType.Text;
                    int i = cmd.ExecuteNonQuery();
                    if (i != 0)
                    {
                        MessageBox.Show("Them Hoc Sinh Thanh Cong");
                        conn.Close();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Sai Định Dạng Ngày Tháng");
            }
        }
    }
}
