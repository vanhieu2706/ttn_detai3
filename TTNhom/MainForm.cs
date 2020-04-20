using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TTNhom.Properties;

namespace TTNhom
{
    public partial class MainForm : Form
    {
        private bool isCollapsed = true;
        private bool isCollapsed2 = true;
        private bool isCollapsed3 = true;
        private bool isCollapsed4 = true;
        private bool isCollapsed5 = true;

        private void init()
        {
            if (FormLogin.quyen.Equals("0"))
            {
                btnNhanVien.Enabled = true;
            }
            else
            {
                btnNhanVien.Enabled = false;
            }
        }
        public MainForm()
        {
            InitializeComponent();
            init();
        }
        private void AddForm(Form f)
        {
            f.MdiParent = this;
            groupBoxMain.Controls.Add(f);
            f.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                //buttonTeacher.Image = Resources.Collapse_Arrow_20px;
                panelSach.Height += 10;
                if (panelSach.Size == panelSach.MaximumSize)
                {
                    timer1.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                //panelSach.Image = Resources.Expand_Arrow_20px;
                panelSach.Height -= 10;
                if (panelSach.Size == panelSach.MinimumSize)
                {
                    timer1.Stop();
                    isCollapsed = true;
                }
            }
        }

        private void btnSach_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (isCollapsed2)
            {
                //buttonTeacher.Image = Resources.Collapse_Arrow_20px;
                panelDocGia.Height += 10;
                if (panelDocGia.Size == panelDocGia.MaximumSize)
                {
                    timer2.Stop();
                    isCollapsed2 = false;
                }
            }
            else
            {
                //panelSach.Image = Resources.Expand_Arrow_20px;
                panelDocGia.Height -= 10;
                if (panelDocGia.Size == panelDocGia.MinimumSize)
                {
                    timer2.Stop();
                    isCollapsed2 = true;
                }
            }
        }

        private void btnDocGia_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (isCollapsed3)
            {
                //buttonTeacher.Image = Resources.Collapse_Arrow_20px;
                panelNhuCau.Height += 10;
                if (panelNhuCau.Size == panelNhuCau.MaximumSize)
                {
                    timer3.Stop();
                    isCollapsed3 = false;
                }
            }
            else
            {
                //panelSach.Image = Resources.Expand_Arrow_20px;
                panelNhuCau.Height -= 10;
                if (panelNhuCau.Size == panelNhuCau.MinimumSize)
                {
                    timer3.Stop();
                    isCollapsed3 = true;
                }
            }
        }

        private void btnNhuCau_Click(object sender, EventArgs e)
        {
            timer3.Start();
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if (isCollapsed4)
            {
                //buttonTeacher.Image = Resources.Collapse_Arrow_20px;
                panelNhanVien.Height += 10;
                if (panelNhanVien.Size == panelNhanVien.MaximumSize)
                {
                    timer4.Stop();
                    isCollapsed4 = false;
                }
            }
            else
            {
                //panelSach.Image = Resources.Expand_Arrow_20px;
                panelNhanVien.Height -= 10;
                if (panelNhanVien.Size == panelNhanVien.MinimumSize)
                {
                    timer4.Stop();
                    isCollapsed4 = true;
                }
            }
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            timer4.Start();
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            if (isCollapsed5)
            {
                //buttonTeacher.Image = Resources.Collapse_Arrow_20px;
                panelAbout.Height += 10;
                if (panelAbout.Size == panelAbout.MaximumSize)
                {
                    timer5.Stop();
                    isCollapsed5 = false;
                }
            }
            else
            {
                //panelSach.Image = Resources.Expand_Arrow_20px;
                panelAbout.Height -= 10;
                if (panelAbout.Size == panelAbout.MinimumSize)
                {
                    timer5.Stop();
                    isCollapsed5 = true;
                }
            }
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            timer5.Start();
        }

        private void btnThemSach_Click(object sender, EventArgs e)
        {
            groupBoxMain.Controls.Clear();
            AddSachForm form = new AddSachForm();
            AddForm(form);
        }

        private void btnListSach_Click(object sender, EventArgs e)
        {
            groupBoxMain.Controls.Clear();
            ListSachForm form = new ListSachForm();
            AddForm(form);
        }

        private void btnThemDocGia_Click(object sender, EventArgs e)
        {
            groupBoxMain.Controls.Clear();
            AddDocGiaForm form = new AddDocGiaForm();
            AddForm(form);
        }

        private void btnListDocGia_Click(object sender, EventArgs e)
        {
            groupBoxMain.Controls.Clear();
            ListDocGiaForm form = new ListDocGiaForm();
            AddForm(form);
        }

        private void btnMuonSach_Click(object sender, EventArgs e)
        {
            groupBoxMain.Controls.Clear();
            MuonTraForm form = new MuonTraForm();
            AddForm(form);
        }

        private void btnTraSach_Click(object sender, EventArgs e)
        {
            groupBoxMain.Controls.Clear();
            ListMuonTra form = new ListMuonTra();
            AddForm(form);
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            groupBoxMain.Controls.Clear();
            AddNhanVienForm form = new AddNhanVienForm();
            AddForm(form);
        }

        private void btnListNV_Click(object sender, EventArgs e)
        {
            groupBoxMain.Controls.Clear();
            ListNhanVienForm form = new ListNhanVienForm();
            AddForm(form);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult pt = MessageBox.Show("Bạn muốn thoát không?", "Xác Nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(pt == DialogResult.OK)
            {
                Application.Exit();
            }
            //Application.Exit();
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            groupBoxMain.Controls.Clear();
            ThongtinForm form = new ThongtinForm();
            AddForm(form);
        }

        private void btnUserIF_Click(object sender, EventArgs e)
        {
            groupBoxMain.Controls.Clear();
            ThongTinUserActive form = new ThongTinUserActive();
            AddForm(form);
        }
    }
}
