using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TTNhom
{
    public partial class ListSachForm : Form
    {
        DBAccess access = new DBAccess();
        DataTable table;

        private static SqlConnection conn = new SqlConnection(DBAccess.connString);
        private static SqlDataAdapter adt = new SqlDataAdapter();
        private static SqlCommand cmd = new SqlCommand();

        int maSach = -1;
        string tenSach,tacGia,maLoaiSach,maNXB,noiDung;
        int soLuong;
        List<string> listSach = new List<string>();
        List<string> listNXB = new List<string>();
        public ListSachForm()
        {
            InitializeComponent();
            addComboBox(conn , cmd , listSach , "MaLoaiSach" , "LoaiSach" , comboBoxMaLoaiSach);
            addComboBox(conn , cmd , listNXB , "MaNXB" , "NXB" , comboBoxMaNXB);
            addData();
        }
        private void GetData(string query , DataGridView grid , DataTable table) {
            access.createConn();
            adt = new SqlDataAdapter(query , conn);
            adt.Fill(table);
            grid.DataSource = table;
            conn.Close();
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
        private void addData() {
            table = new DataTable();
            GetData("select * from DauSach" , tableMain , table);
        }

        private void tableMain_CellClick(object sender , DataGridViewCellEventArgs e) {
            int index = e.RowIndex;
            DataGridViewRow selectRow = tableMain.Rows[index];
            maSach = int.Parse(selectRow.Cells[0].Value.ToString().Trim());
            tenSach = selectRow.Cells[1].Value.ToString().Trim();
            tacGia = selectRow.Cells[2].Value.ToString().Trim();
            maLoaiSach = selectRow.Cells[3].Value.ToString().Trim();
            maNXB = selectRow.Cells[4].Value.ToString().Trim();
            soLuong = int.Parse(selectRow.Cells[5].Value.ToString().Trim());
            noiDung = selectRow.Cells[6].Value.ToString().Trim();

            textBoxTenSach.Text = tenSach;
            textBoxTacgia.Text = tacGia;
            textBoxNote.Text = noiDung;
            numericUpDownSoLuong.Value = soLuong;
            comboBoxMaLoaiSach.SelectedIndex = comboBoxMaLoaiSach.FindStringExact(maLoaiSach.ToString());
            comboBoxMaNXB.SelectedIndex = comboBoxMaNXB.FindStringExact(maNXB.ToString());
        }
        private void btnXoa_Click(object sender , EventArgs e) {
            if(maSach == -1) {
                MessageBox.Show("Chưa chọn sách nào để xoá");
            }
            else {
                table = new DataTable();
                string query1 = "UPDATE dbo.NhuCauMuonTra SET MaSach = NULL WHERE MaSach = '" + maSach + "'";
                string query2 = "DELETE dbo.DauSach WHERE MaSach = " + maSach;

                GetData(query1 , tableMain , table);
                GetData(query2 , tableMain , table);
                GetData("select * from DauSach" , tableMain , table);
                MessageBox.Show("Done");

            }
        }
        private void btnSua_Click(object sender , EventArgs e) {
            table = new DataTable();
            tenSach = textBoxTenSach.Text.Trim();
            tacGia = textBoxTacgia.Text.Trim();
            maLoaiSach = comboBoxMaLoaiSach.Text.ToString();
            noiDung = textBoxNote.Text.ToString();
            maNXB = comboBoxMaNXB.Text.ToString();
            soLuong = int.Parse(numericUpDownSoLuong.Value.ToString());

            if(tenSach.Equals("")||tacGia.Equals("")) {
                MessageBox.Show("Thieu Thong tin");
            }
            else {
                string query = "UPDATE dbo.DauSach SET TenSach = N'" + tenSach + "' , TacGia = N' " + tacGia + "', MaLoaiSach = '" + maLoaiSach + "' , MaNXB = '" + maNXB + "' , SoLuong = " + soLuong + " , NoiDung = N'" + noiDung + "' WHERE MaSach = '" + maSach + "'";
                GetData(query , tableMain , table);
                GetData("select * from DauSach" , tableMain , table);
                MessageBox.Show("Done");
            }
        }
        private void textBoxSearch_TextChanged(object sender , EventArgs e) {
            string keyword;
            keyword = textBoxSearch.Text;
            table = new DataTable();
            GetData("select * from DauSach WHERE TenSach LIKE N'%" + keyword + "%' "
                + "OR TacGia LIKE N'%" + keyword + "%' "
                + "OR MaLoaiSach LIKE N'%" + keyword + "%'"
                + "OR MaNXB LIKE N'%" + keyword + "%'"
                + "OR SoLuong LIKE N'%" + keyword + "%'"
                + "OR NoiDung LIKE N'%" + keyword + "%'"
                , tableMain , table);
        }
        private void button3_Click(object sender , EventArgs e) {
            string keyword;
            keyword = textBoxSearch.Text;
            table = new DataTable();
            GetData("select * from DauSach WHERE TenSach LIKE N'%" + keyword + "%' " 
                +"OR TacGia LIKE N'%" + keyword + "%' "
                + "OR MaLoaiSach LIKE N'%" + keyword + "%'"
                + "OR MaNXB LIKE N'%" + keyword + "%'"
                + "OR SoLuong LIKE N'%" + keyword + "%'"
                + "OR NoiDung LIKE N'%" + keyword + "%'"
                , tableMain , table);
        }
    }
}
