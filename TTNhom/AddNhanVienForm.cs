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
        string ten, diaChi, ngaySinh, gioiTinh, sdt, ngayVaoLam, taikhoan, matkhau, phanquyen;
        public AddNhanVienForm()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "yyyy-MM-dd";
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            ten = txtTen.Text.Trim();
            ngaySinh = dateTimePicker1.Value.Date.ToString("yyyy-MM-dd HH:mm:ss");
            diaChi = txtDiaChi.Text;
            sdt = txtPhone.Text;
            ngayVaoLam = dateTimePicker2.Value.Date.ToString("yyyy-MM-dd HH:mm:ss");
            taikhoan = txtTaiKhoan.Text;
            matkhau = txtMatKhau.Text;
            phanquyen = txtPhanQuyen.Text;

            if (radioButtonNam.Checked == true)
            {
                gioiTinh = "1";
            }
            else
            {
                gioiTinh = "0";
            }

            if (ten.Equals("") || ngaySinh.Equals("") || diaChi.Equals("") || sdt.Equals("") || gioiTinh.Equals("") || ngayVaoLam.Equals("") || taikhoan.Equals("") || matkhau.Equals("") || phanquyen.Equals(""))
            {
                MessageBox.Show("Thiếu Thông Tin");
            }
            else
            {
                conn.Open();
                table = new DataTable();
                string queryInsert = "INSERT dbo.NhanVien( HoTenNV ,DiaChiNV ,NgaySinh ,Sex ,SDT ,NgayVaoLam, TaiKhoan, MatKhau, PhanQuyen) VALUES" +
                    " ( N'"+ten+"' , N'"+diaChi+"' , '"+ngaySinh+"' , '"+gioiTinh+"' , '"+sdt+"' , '"+ngayVaoLam+ "', '" + taikhoan + "' , '" + matkhau + "' , '" + phanquyen + "' )";
                cmd = new SqlCommand(queryInsert, conn);
                cmd.CommandType = CommandType.Text;
                int i = cmd.ExecuteNonQuery();
                if (i != 0)
                {
                    MessageBox.Show("Thêm Nhân Viên Thành Công");
                    conn.Close();
                }
            }
        }
    }
}
