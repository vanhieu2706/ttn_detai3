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
    public partial class ListDocGiaForm : Form
    {
        private static SqlConnection conn = new SqlConnection(DBAccess.connString);
        private static SqlDataAdapter adt = new SqlDataAdapter();
        private static SqlCommand cmd = new SqlCommand();
        DBAccess access = new DBAccess();
        DataTable table;
        int maDG = -1;
        string ten, ngaySinh, diaChi, sdt, gioiTinh, hanSD;

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (maDG == -1)
            {
                MessageBox.Show("Chua Chon Doc Gia De Xoa");
            }
            else
            {
                table = new DataTable();
                string query1 = "UPDATE dbo.NhuCauMuonTra SET MaDocGia = NULL WHERE MaDocGia = '"+maDG+"'";
                string query2 = "DELETE dbo.DocGia WHERE MaDocGia = '"+maDG+"'";
                GetData(query1, dataGridView1, table);
                GetData(query2, dataGridView1, table);
                GetData("SELECT *FROM dbo.DocGia", dataGridView1, table);
                MessageBox.Show("Xóa Thành Công");

            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectRow = dataGridView1.Rows[index];
            ten = selectRow.Cells[1].Value.ToString();
            diaChi = selectRow.Cells[2].Value.ToString();
            ngaySinh = selectRow.Cells[3].Value.ToString();
            gioiTinh = selectRow.Cells[4].Value.ToString();
            hanSD = selectRow.Cells[5].Value.ToString();
            sdt = selectRow.Cells[6].Value.ToString();
            maDG = int.Parse(selectRow.Cells[0].Value.ToString());



            txtTen.Text = ten;
            txtDiaChi.Text = diaChi;
            txtSDT.Text = sdt;
            dtpNgaySinh.Value = Convert.ToDateTime(ngaySinh);
            dtpHSD.Value = Convert.ToDateTime(hanSD);
            if (gioiTinh.Equals("True")) radioButtonNam.Checked = true;
            else radioButtonNu.Checked = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            table = new DataTable(); ten = txtTen.Text.Trim();
            ngaySinh = dtpNgaySinh.Value.Date.ToString("yyyy-MM-dd HH:mm:ss");
            sdt = txtSDT.Text;
            diaChi = txtDiaChi.Text;
            hanSD = dtpHSD.Value.Date.ToString("yyyy-MM-dd HH:mm:ss");
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
                if (ten.Equals("") || ngaySinh.Equals("") || diaChi.Equals("") || sdt.Equals("") || gioiTinh.Equals("") || hanSD.Equals(""))
                {
                    MessageBox.Show("Thieu Thong tin");

                }
                else
                {
                    conn.Open();
                    table = new DataTable();
                    string queryInsert = "UPDATE dbo.DocGia SET TenDocGia = N'"+ten+"', DiaChi = N'"+diaChi+"', NgaySinh = '"+ngaySinh+"'," +
                        " Sex = '"+gioiTinh+"', HanSuDung = '"+hanSD+"', SDT = '"+sdt+"' WHERE MaDocGia = '"+maDG+"'";
                    cmd = new SqlCommand(queryInsert, conn);
                    cmd.CommandType = CommandType.Text;
                    int i = cmd.ExecuteNonQuery();
                    if (i != 0)
                    {
                        MessageBox.Show("Sua Doc Gia Thanh Cong");
                        conn.Close();
                        string query = "SELECT *FROM dbo.DocGia";
                        GetData(query, dataGridView1, table);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Sai Định Dạng Ngày Tháng");
            }
        }

        public ListDocGiaForm()
        {
            InitializeComponent();
        }

        private void GetData(string query, DataGridView grid, DataTable table)
        {
            access.createConn();
            adt = new SqlDataAdapter(query, conn);
            adt.Fill(table);
            grid.DataSource = table;
            conn.Close();
        }
        private void PicSearch_Click(object sender, EventArgs e)
        {
            table = new DataTable();
            string key = txtKeySearch.Text.Trim();
            if (key.Equals(""))
            {
                string query = "SELECT *FROM dbo.DocGia";
                GetData(query, dataGridView1, table);
            }
            else
            {
                int a;
                bool check = int.TryParse(key, out a);
                if (check == true)
                {
                    string query = "SELECT *FROM dbo.DocGia WHERE MaDocGia = '"+key+"' OR NgaySinh LIKE '%"+key+"%' OR HanSuDung LIKE '%"+key+"%' OR SDT LIKE '%"+key+"%' ";
                    GetData(query, dataGridView1, table);
                }
                else
                {
                    string query = "SELECT *FROM dbo.DocGia WHERE TenDocGia LIKE N'%"+key+"%' OR DiaChi LIKE N'%"+key+"%'";
                    GetData(query, dataGridView1, table);
                }

            }
        }

    }
}
