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
    public partial class ListNhanVienForm : Form
    {
        private static SqlConnection conn = new SqlConnection(DBAccess.connString);
        private static SqlDataAdapter adt = new SqlDataAdapter();
        private static SqlCommand cmd = new SqlCommand();
        DBAccess access = new DBAccess();
        DataTable table;
        List<string> list = new List<string>();
        string ten, diaChi, ngaySinh, gioiTinh, sdt, ngayVaoLam;
        public static int maNV = -1;
        public ListNhanVienForm()
        {
            InitializeComponent();
            comboBoxColumn.SelectedItem = comboBoxColumn.Items[0];
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (maNV == -1)
            {
                MessageBox.Show("Chua Chon hoc sinh de XOA");
            }
            else
            {
                table = new DataTable();
                string query1 = "UPDATE dbo.NhuCauMuonTra SET MaNV = NULL WHERE MaNV = '"+maNV+"' ";
                string query2 = "DELETE dbo.NhanVien WHERE MaNV = '" + maNV + "'";
                GetData(query1, dataGridView1, table);
                GetData(query2, dataGridView1, table);
                GetData("select * from NhanVien", dataGridView1, table);
                MessageBox.Show("Done");

            }
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            table = new DataTable();

            ten = txtTen.Text.Trim();
            ngaySinh = dateTimePicker1.Value.Date.ToString("yyyy-MM-dd HH:mm:ss");
            diaChi = txtDiaChi.Text;
            sdt = txtPhone.Text.Trim();
            ngayVaoLam = dateTimePicker2.Value.Date.ToString("yyyy-MM-dd HH:mm:ss");

            if (radioButtonNam.Checked == true)
            {
                gioiTinh = "1";
            }
            else
            {
                gioiTinh = "0";
            }

            if (ten.Equals("") || ngaySinh.Equals("") || diaChi.Equals("") || sdt.Equals("") || gioiTinh.Equals(""))
            {
                MessageBox.Show("Thieu Thong tin");

            }
            else
            {
                string query = "UPDATE dbo.NhanVien SET  HoTenNV = N'"+ten+"',DiaChiNV = N'"+diaChi+"',NgaySinh = N'"+ngaySinh+"'" +
                    ",Sex = '"+gioiTinh+"',SDT= '"+sdt+"', NgayVaoLam = '"+ngayVaoLam+"' WHERE MaNV = '"+maNV+"' ";
                GetData(query, dataGridView1, table);
                GetData("select * from NhanVien", dataGridView1, table);
                MessageBox.Show("Done");
            }
        }

        private void addComboBox(SqlConnection conn, SqlCommand cmd, List<string> list, string tenCot, string tenTable, ComboBox cb)
        {
            conn.Open();
            cmd = new SqlCommand("Select " + tenCot + " FROM " + tenTable, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                list.Add(dr.GetInt32(0).ToString());
            }
            cb.DataSource = list;
            conn.Close();

        }
        private void GetData(string query, DataGridView grid, DataTable table)
        {
            access.createConn();
            adt = new SqlDataAdapter(query, conn);
            adt.Fill(table);
            grid.DataSource = table;
            conn.Close();
        }

        private void ListNhanVienForm_Load(object sender, EventArgs e)
        {
            table = new DataTable();
            GetData("select * from NhanVien", dataGridView1, table);
        }

        private void TxtKeySearch_TextChanged(object sender, EventArgs e)
        {
            table = new DataTable();
            string keySearch = comboBoxColumn.Text;
            string keySearchCompare = txtKeySearch.Text;
            switch (keySearch)
            {
                case ("Mã Nhân Viên"):
                    {

                        GetData("select * from NhanVien where MaNV like N'%" + keySearchCompare + "%' ", dataGridView1, table);
                        break;
                    }
                case ("Tên Nhân Viên"):
                    {
                        GetData("select * from NhanVien where HoTenNV like N'%" + keySearchCompare + "%' ", dataGridView1, table);
                        break;
                    }
                case ("Địa Chỉ"):
                    {
                        GetData("select * from NhanVien where DiaChiNV like N'%" + keySearchCompare + "%' ", dataGridView1, table);
                        break;
                    }
                case ("Ngày Sinh"):
                    {
                        GetData("select * from NhanVien where NgaySinh like N'%" + keySearchCompare + "%' ", dataGridView1, table);
                        break;
                    }
                case ("Giới Tính"):
                    {
                        GetData("select * from NhanVien where Sex like N'%" + keySearchCompare + "%' ", dataGridView1, table);
                        break;
                    }
                case ("SĐT"):
                    {
                        GetData("select * from NhanVien where SDT like N'%" + keySearchCompare + "%' ", dataGridView1, table);
                        break;
                    }
                case ("Ngày Vào Làm"):
                    {
                        GetData("select * from NhanVien where NgayVaoLam like N'%" + keySearchCompare + "%' ", dataGridView1, table);
                        break;
                    }
                case (""):
                    {
                        GetData("SELECT * FROM dbo.NhanVien", dataGridView1, table);
                        break;
                    }

            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                DataGridViewRow selectRow = dataGridView1.Rows[index];

                maNV = int.Parse(selectRow.Cells[0].Value.ToString());
                
                ten = selectRow.Cells[1].Value.ToString();

                diaChi = selectRow.Cells[2].Value.ToString();
                ngaySinh = selectRow.Cells[3].Value.ToString();
                gioiTinh = selectRow.Cells[4].Value.ToString();
                sdt = selectRow.Cells[5].Value.ToString();
                ngayVaoLam = selectRow.Cells[6].Value.ToString();



                txtTen.Text = ten;
                txtDiaChi.Text = diaChi;
                txtPhone.Text = sdt;

                dateTimePicker1.Value = Convert.ToDateTime(ngaySinh);
                dateTimePicker2.Value = Convert.ToDateTime(ngayVaoLam);

                if (gioiTinh.Equals("True")) radioButtonNam.Checked = true;
                else radioButtonNu.Checked = true;
            }
            catch
            {

            }
            
        }
    }
}
