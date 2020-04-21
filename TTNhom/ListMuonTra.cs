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
using System.Text.RegularExpressions;

namespace TTNhom
{
    public partial class ListMuonTra : Form
    {
        int MaDocGia, MaNV, MaSach, SoLuong;
        string id, Note, NgayMuon, NgayTra;

        private static SqlConnection conn = new SqlConnection(DBAccess.connString);
        private static SqlDataAdapter adt = new SqlDataAdapter();
        private static SqlCommand cmd = new SqlCommand();
        DBAccess access = new DBAccess();
        DataTable table;
        List<string> list = new List<string>();
        List<string> listMaSach = new List<string>();

        public bool IsNumber(string pText)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
            return regex.IsMatch(pText);
        }


        public ListMuonTra()
        {
            InitializeComponent();
            addData();
            addComboBox(conn, cmd, list, "MaDocGia", "DocGia", comboBoxDocGia);
            addComboBox(conn, cmd, listMaSach, "MaSach", "DauSach", comboBoxMaSach);
            comboBoxNV.Text = FormLogin.MaNV.ToString();
            dateTimePickerMuon.Format = DateTimePickerFormat.Custom;
            dateTimePickerMuon.CustomFormat = "dd-MM-yyyy";
            dateTimePickerTra.Format = DateTimePickerFormat.Custom;
            dateTimePickerTra.CustomFormat = "dd-MM-yyyy";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            MaDocGia = Convert.ToInt32(comboBoxDocGia.Text);
            MaSach = Convert.ToInt32(comboBoxMaSach.Text);
            MaNV = Convert.ToInt32(comboBoxNV.Text);
            NgayMuon = dateTimePickerMuon.Value.Date.ToString("yyyy-MM-dd HH:mm:ss");
            NgayTra = dateTimePickerTra.Value.Date.ToString("yyyy-MM-dd HH:mm:ss");
            SoLuong = Convert.ToInt32(numericUpDownSoLuong.Value);
            Note = textBoxNote.Text;

            conn.Open();
            table = new DataTable();
            string queryUpdate = ("UPDATE NhuCauMuonTra SET MaDocGia = " + MaDocGia + ", MaNV = " + MaNV + ", NgayMuon = '" + NgayMuon + "'," +
                    "NgayTra = '" + NgayTra + "', MaSach = " + MaSach + ", SoLuong = " + SoLuong + ", GhiChu = N'" + Note + "' where MaPhieuMuon = " + int.Parse(id) + " ");
            cmd = new SqlCommand(queryUpdate, conn);
            cmd.CommandType = CommandType.Text;
            int i = cmd.ExecuteNonQuery();
            if (i != 0)
            {
                MessageBox.Show("Sửa thành công");
                conn.Close();
            }
            addData();
            clear();
        }

        private void txtKeySearch_TextChanged(object sender, EventArgs e)
        {
            string keyword;
            keyword = txtKeySearch.Text;
            table = new DataTable();
            string date_search = dateTimePicker2.Text;
            if(date_search == " ")
            {
                date_search = dateTimePicker2.Value.Date.ToString("yyyy-MM-dd");
                if (keyword != "")
                {
                    table = new DataTable();
                    if (IsNumber(keyword))
                    {
                        GetData("select * from NhuCauMuonTra WHERE ( MaPhieuMuon = " + keyword + " " +
                        "OR MaDocGia = " + keyword + " " +
                        "OR MaNV = " + keyword + " " +
                        "OR MaSach = " + keyword + " ) " +
                        "AND ( NgayMuon LIKE '" + date_search + "' " +
                        "OR NgayTra LIKE '" + date_search + "' )"
                        , dataGridView1, table);
                    }
                    else
                    {
                        GetData("select * from NhuCauMuonTra WHERE GhiChu LIKE N'" + keyword + "' " +
                        "AND ( NgayMuon LIKE '" + date_search + "' " +
                        "OR NgayTra LIKE '" + date_search + "' )"
                        , dataGridView1, table);
                    }
                }
                else
                {
                    GetData("select * from NhuCauMuonTra WHERE NgayMuon LIKE '" + date_search + "' " +
                        "OR NgayTra LIKE '" + date_search + "' "
                        , dataGridView1, table);
                }
            } else
            {
                if (IsNumber(keyword))
                {
                    GetData("select * from NhuCauMuonTra WHERE MaPhieuMuon = " + keyword + " " +
                    "OR MaDocGia = " + keyword + " " +
                    "OR MaNV = " + keyword + " " +
                    "OR MaSach = " + keyword + " "
                    , dataGridView1, table);
                }
                else
                {
                    GetData("select * from NhuCauMuonTra WHERE GhiChu LIKE N'" + keyword + "' "
                    , dataGridView1, table);
                }
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.CustomFormat = "dd-MM-yyyy";
            table = new DataTable();
            string date_search = dateTimePicker2.Value.Date.ToString("yyyy-MM-dd");
            string keyword;
            keyword = txtKeySearch.Text;
            label1.Text = keyword;
            if (keyword != "")
            {
                if (IsNumber(keyword))
                {
                    GetData("select * from NhuCauMuonTra WHERE ( MaPhieuMuon = " + keyword + " " +
                    "OR MaDocGia = " + keyword + " " +
                    "OR MaNV = " + keyword + " " +
                    "OR MaSach = " + keyword + " ) " +
                    "AND ( NgayMuon LIKE '" + date_search + "' " +
                    "OR NgayTra LIKE '" + date_search + "' )"
                    , dataGridView1, table);
                }
                else
                {
                    GetData("select * from NhuCauMuonTra WHERE GhiChu LIKE N'" + keyword + "' " +
                    "AND ( NgayMuon LIKE '" + date_search + "' " +
                    "OR NgayTra LIKE '" + date_search + "' )"
                    , dataGridView1, table);
                }
            } else
            {
                GetData("select * from NhuCauMuonTra WHERE NgayMuon LIKE '" + date_search + "' " +
                    "OR NgayTra LIKE '" + date_search + "' "
                    , dataGridView1, table);
            }
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            clear();
            int index = e.RowIndex;
            DataGridViewRow selectRow = dataGridView1.Rows[index];
            id = selectRow.Cells[0].Value.ToString();
            comboBoxDocGia.Text = selectRow.Cells[1].Value.ToString().Trim();
            comboBoxNV.Text = selectRow.Cells[2].Value.ToString().Trim();
            dateTimePickerMuon.Value = Convert.ToDateTime(selectRow.Cells[3].Value.ToString());
            comboBoxMaSach.Text = selectRow.Cells[4].Value.ToString().Trim();
            dateTimePickerTra.Value = Convert.ToDateTime(selectRow.Cells[5].Value.ToString());
            numericUpDownSoLuong.Value = Convert.ToDecimal(selectRow.Cells[6].Value);
            textBoxNote.Text = selectRow.Cells[7].Value.ToString().Trim();
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

        private void addData()
        {
            table = new DataTable();
            GetData("select * from NhuCauMuonTra", dataGridView1, table);
        }
        
        private void clear()
        {
            comboBoxDocGia.Text = "";
            comboBoxNV.Text = "";
            comboBoxMaSach.Text = "";
            numericUpDownSoLuong.Value = 0;
            textBoxNote.Text = "";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (id != null)
            {
                table = new DataTable();
                string query1 = "DELETE dbo.NhuCauMuonTra WHERE MaPhieuMuon = '" + id + "'";
                GetData(query1, dataGridView1, table);
                MessageBox.Show("Xóa thành công");
                addData();
                clear();
            }
            else
            {
                MessageBox.Show("Xin mời chọn nhân viên cần xóa !!");
            }
        }
    }
}
