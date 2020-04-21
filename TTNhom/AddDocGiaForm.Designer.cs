namespace TTNhom
{
    partial class AddDocGiaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.dtpHSD = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButtonNam = new System.Windows.Forms.RadioButton();
            this.radioButtonNữ = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(80, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên Độc Giả";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(80, 241);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Địa Chỉ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(80, 342);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "SDT";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(442, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ngày Sinh";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(442, 342);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "HSD";
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(204, 145);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(126, 22);
            this.txtTen.TabIndex = 7;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(204, 241);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(126, 22);
            this.txtDiaChi.TabIndex = 8;
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(204, 335);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(126, 22);
            this.txtSDT.TabIndex = 9;
            this.txtSDT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSDT_KeyPress);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(166)))), ((int)(((byte)(46)))));
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.Color.Black;
            this.btnThem.Location = new System.Drawing.Point(358, 464);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(107, 46);
            this.btnThem.TabIndex = 13;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // dtpNgaySinh
            // 
            this.dtpNgaySinh.Location = new System.Drawing.Point(560, 150);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(200, 22);
            this.dtpNgaySinh.TabIndex = 16;
            // 
            // dtpHSD
            // 
            this.dtpHSD.Location = new System.Drawing.Point(560, 335);
            this.dtpHSD.MinDate = new System.DateTime(2020, 4, 21, 0, 0, 0, 0);
            this.dtpHSD.Name = "dtpHSD";
            this.dtpHSD.Size = new System.Drawing.Size(200, 22);
            this.dtpHSD.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(91, 67);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(639, 20);
            this.label6.TabIndex = 136;
            this.label6.Text = "______________________________________________________________________";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(89, 37);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(168, 29);
            this.label9.TabIndex = 135;
            this.label9.Text = "Thêm Độc Giả";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(442, 233);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 17);
            this.label8.TabIndex = 40;
            this.label8.Text = "Giới tính";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButtonNữ);
            this.panel1.Controls.Add(this.radioButtonNam);
            this.panel1.Location = new System.Drawing.Point(560, 220);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 43);
            this.panel1.TabIndex = 137;
            // 
            // radioButtonNam
            // 
            this.radioButtonNam.AutoSize = true;
            this.radioButtonNam.Location = new System.Drawing.Point(12, 11);
            this.radioButtonNam.Name = "radioButtonNam";
            this.radioButtonNam.Size = new System.Drawing.Size(58, 21);
            this.radioButtonNam.TabIndex = 0;
            this.radioButtonNam.TabStop = true;
            this.radioButtonNam.Text = "Nam";
            this.radioButtonNam.UseVisualStyleBackColor = true;
            // 
            // radioButtonNữ
            // 
            this.radioButtonNữ.AutoSize = true;
            this.radioButtonNữ.Location = new System.Drawing.Point(123, 11);
            this.radioButtonNữ.Name = "radioButtonNữ";
            this.radioButtonNữ.Size = new System.Drawing.Size(47, 21);
            this.radioButtonNữ.TabIndex = 1;
            this.radioButtonNữ.TabStop = true;
            this.radioButtonNữ.Text = "Nữ";
            this.radioButtonNữ.UseVisualStyleBackColor = true;
            // 
            // AddDocGiaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(237)))), ((int)(((byte)(190)))));
            this.ClientSize = new System.Drawing.Size(900, 742);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dtpHSD);
            this.Controls.Add(this.dtpNgaySinh);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtSDT);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AddDocGiaForm";
            this.Text = "AddDocGiaForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.DateTimePicker dtpHSD;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButtonNữ;
        private System.Windows.Forms.RadioButton radioButtonNam;
    }
}