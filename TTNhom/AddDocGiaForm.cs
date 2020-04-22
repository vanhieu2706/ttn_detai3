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
    public partial class AddDocGiaForm : Form
    {
        string ten, ngaySinh, diaChi, sdt, hanSD;
        int gioiTinh;
        private static SqlConnection conn = new SqlConnection(DBAccess.connString);
        private static SqlDataAdapter adt = new SqlDataAdapter();
        private static SqlCommand cmd = new SqlCommand();

        DBAccess access = new DBAccess();
        DataTable table;

        

        List<string> list = new List<string>();
        public AddDocGiaForm()
        {
            InitializeComponent();
            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.CustomFormat = "yyyy-MM-dd";
            dtpHSD.Format = DateTimePickerFormat.Custom;
            dtpHSD.CustomFormat = "yyyy-MM-dd";

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ten = txtTen.Text;
            ngaySinh = dtpNgaySinh.Value.Date.ToString("yyyy-MM-dd HH:mm:ss");
            sdt = txtSDT.Text;
            diaChi = txtDiaChi.Text;
            hanSD = dtpHSD.Value.Date.ToString("yyyy-MM-dd HH:mm:ss");
            if (radioButtonNam.Checked == true)
            {
                gioiTinh = 1;
            }
            else
            {
                gioiTinh = 0;
            }

                if (ten.Equals("") || ngaySinh.Equals("") || diaChi.Equals("") || sdt.Equals("") || gioiTinh.Equals("") || hanSD.Equals(""))
                {
                    MessageBox.Show("Thieu Thong tin");

                }
                else
                {
                    conn.Open();
                    table = new DataTable();
                    string queryInsert = "INSERT dbo.DocGia( TenDocGia ,DiaChi ,NgaySinh ,Sex ,HanSuDung ,SDT)" +
                        "VALUES  ( N'" + ten + "' ,N'" + diaChi + "' ,'" + ngaySinh + "' ," + gioiTinh + " ,'" + hanSD + "' ,'" + sdt + "')";
                    cmd = new SqlCommand(queryInsert, conn);
                    cmd.CommandType = CommandType.Text;
                    int i = cmd.ExecuteNonQuery();
                    if (i != 0)
                    {
                        MessageBox.Show("Them Độc Giả Thành Công");
                        conn.Close();
                    }
                }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
