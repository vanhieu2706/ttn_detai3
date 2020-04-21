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
    public partial class MuonTraForm : Form
    {
        int MaDocGia, MaNV, MaSach, SoLuong;
        string Note, NgayMuon, NgayTra;

        private static SqlConnection conn = new SqlConnection(DBAccess.connString);
        private static SqlDataAdapter adt = new SqlDataAdapter();
        private static SqlCommand cmd = new SqlCommand();
        DBAccess access = new DBAccess();
        DataTable table;
        List<string> list = new List<string>();
        List<string> listMaSach = new List<string>();

        public MuonTraForm()
        {
            InitializeComponent();
            addComboBox(conn, cmd, list, "MaDocGia", "DocGia", comboBoxDocGia);
            addComboBox(conn, cmd, listMaSach, "MaSach", "DauSach", comboBoxMaSach);
            comboBoxNV.Text = FormLogin.MaNV.ToString();
            dateTimePickerMuon.Format = DateTimePickerFormat.Custom;
            dateTimePickerMuon.CustomFormat = "dd-MM-yyyy";
            dateTimePickerTra.Format = DateTimePickerFormat.Custom;
            dateTimePickerTra.CustomFormat = "dd-MM-yyyy";
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

        private void button1_Click(object sender, EventArgs e)
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
            string queryInsert = "INSERT dbo.NhuCauMuonTra( MaDocGia ,MaNV ,NgayMuon ,MaSach ,NgayTra ,SoLuong ,GhiChu)VALUES" +
                "  ( '" + MaDocGia + "' ,'" + MaNV + "' ,'" + NgayMuon + "' ,'" + MaSach + "' , '" + NgayTra + "' , '" + SoLuong + "' , N'" + Note + "'  )";
            cmd = new SqlCommand(queryInsert, conn);
            cmd.CommandType = CommandType.Text;
            int i = cmd.ExecuteNonQuery();
            if (i != 0)
            {
                MessageBox.Show("Thêm lịch mượn thành công");
                conn.Close();
            }
        }
    }
}
