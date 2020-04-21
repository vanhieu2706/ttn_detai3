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
    public partial class AddSachForm : Form
    {
        DBAccess access = new DBAccess();

        private static SqlConnection conn = new SqlConnection(DBAccess.connString);
        private static SqlDataAdapter adt = new SqlDataAdapter();
        private static SqlCommand cmd = new SqlCommand();

        string variable;
        public AddSachForm()
        {
            InitializeComponent();
            addData();
        }
        private void addData() {
            List<string> listLoaiSach = new List<string>();
            List<string> listNXB = new List<string>();

            addComboBox(conn , cmd , listLoaiSach , "LoaiSach" , "LoaiSach" , comboBoxLoaiSach);
            addComboBox(conn , cmd , listNXB , "TenNXB" , "NXB" , comboBoxNXB);
        }

        private void addComboBox(SqlConnection conn , SqlCommand cmd , List<string> list , string tenCot , string tenTable , ComboBox cb) {
            conn.Open();
            cmd = new SqlCommand("Select " + tenCot + " From " + tenTable , conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read()) {
                list.Add(dr.GetValue(0).ToString());
            }
            cb.DataSource = list;
            conn.Close();
        }
        private string queryID(SqlCommand sql , string colomn , string table , string dieuKien , string ndDieuKien) {
            conn.Open();
            cmd = new SqlCommand("SELECT " + colomn + " FROM " + table + " WHERE " + dieuKien + " = N'" + ndDieuKien + "'  " , conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read()) {
                variable = dr.GetInt32(0).ToString();
            }
            conn.Close();
            return variable;
        }
        
        private void buttonAdd_Click(object sender , EventArgs e) {
            string tenSach, maSach,tacGia,loaiSach,maLoaiSach,NXB,maNXB,noiDung;
            int soLuong;
            tenSach = textBoxTenSach.Text;
            tacGia = textBoxTacgia.Text;
            noiDung = textBoxNote.Text;
            soLuong = Convert.ToInt32(numericUpDownSoLuong.Value);
            NXB = comboBoxNXB.Text;
            loaiSach = comboBoxLoaiSach.Text;

            maSach = queryID(cmd , "MaSach" , "DauSach" , "TenSach" , tenSach);
            if(tenSach.Equals("")) {
                MessageBox.Show("Nhập thiếu thông tin!");
            }
            else if(maSach != null) {
                MessageBox.Show("Tên sách đã tồn tại!");
            }
            else if(soLuong == 0) {
                MessageBox.Show("Số lượng sách phải lơn hơn 0!");
            }
            else {
                maLoaiSach = queryID(cmd , "MaNXB" , "NXB" , "TenNXB" , NXB);
                maNXB = queryID(cmd , "MaLoaiSach" , "LoaiSach" , "LoaiSach" , loaiSach);

                conn.Open();
                string queryInsert = "INSERT INTO dbo.DauSach (TenSach , TacGia ,  MaLoaiSach , MaNXB , SoLuong , NoiDung ) VALUES  ( N'"+ tenSach+"' , N'"+ tacGia+"' , '"+ maLoaiSach + "' , '"+ maNXB + "' ,"+ soLuong + " , N'"+ noiDung + "')";
                cmd = new SqlCommand(queryInsert , conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Thêm môn sách mới thành công");
            }
        }
    }
}
