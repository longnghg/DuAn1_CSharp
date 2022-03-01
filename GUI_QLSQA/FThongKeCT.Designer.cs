
namespace GUI_QLSQA
{
    partial class FThongKeCT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FThongKeCT));
            this.label4 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbTongtien = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnExits = new FontAwesome.Sharp.IconButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.nmrDay = new System.Windows.Forms.NumericUpDown();
            this.panel11 = new System.Windows.Forms.Panel();
            this.rdbChiphi = new DemoCTControls.NARadioButton();
            this.rdbdoanhthu = new DemoCTControls.NARadioButton();
            this.lbnam = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbthang = new System.Windows.Forms.Label();
            this.lbsongay = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbNgay = new System.Windows.Forms.Label();
            this.rdbThang = new DemoCTControls.NARadioButton();
            this.rdbngay = new DemoCTControls.NARadioButton();
            this.btnFind = new FontAwesome.Sharp.IconPictureBox();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrDay)).BeginInit();
            this.panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnFind)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 30);
            this.label4.TabIndex = 118;
            this.label4.Text = "Thống kê theo:";
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.dataGridView1);
            this.panel10.Location = new System.Drawing.Point(56, 211);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(1105, 431);
            this.panel10.TabIndex = 113;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.Peru;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1099, 423);
            this.dataGridView1.TabIndex = 78;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.label1);
            this.panel8.Controls.Add(this.pictureBox2);
            this.panel8.Controls.Add(this.label6);
            this.panel8.Controls.Add(this.pictureBox1);
            this.panel8.Controls.Add(this.lbTongtien);
            this.panel8.Controls.Add(this.label2);
            this.panel8.Controls.Add(this.panel9);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel8.Location = new System.Drawing.Point(3, 648);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1228, 110);
            this.panel8.TabIndex = 108;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(351, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 37);
            this.label1.TabIndex = 122;
            this.label1.Text = "Xuất PDF";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::GUI_QLSQA.Properties.Resources._337946;
            this.pictureBox2.Location = new System.Drawing.Point(280, 9);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(66, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 121;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.label1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(130, 14);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 37);
            this.label6.TabIndex = 111;
            this.label6.Text = "Xuất Excel";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GUI_QLSQA.Properties.Resources.IMGExcel;
            this.pictureBox1.Location = new System.Drawing.Point(59, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(66, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 110;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.label6_Click);
            // 
            // lbTongtien
            // 
            this.lbTongtien.AutoSize = true;
            this.lbTongtien.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTongtien.Location = new System.Drawing.Point(971, 3);
            this.lbTongtien.Name = "lbTongtien";
            this.lbTongtien.Size = new System.Drawing.Size(28, 30);
            this.lbTongtien.TabIndex = 119;
            this.lbTongtien.Text = "...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(839, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 30);
            this.label2.TabIndex = 117;
            this.label2.Text = "Tổng số tiền:";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.DarkOrange;
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1228, 1);
            this.panel9.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.DarkOrange;
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(3, 108);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1228, 1);
            this.panel7.TabIndex = 101;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label3);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(3, 41);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1228, 67);
            this.panel6.TabIndex = 100;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Orange;
            this.label3.Location = new System.Drawing.Point(451, 3);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(352, 47);
            this.label3.TabIndex = 86;
            this.label3.Text = "THỐNG KÊ CHI TIẾT";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.DarkOrange;
            this.panel5.Controls.Add(this.btnExits);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(3, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1228, 41);
            this.panel5.TabIndex = 82;
            // 
            // btnExits
            // 
            this.btnExits.BackColor = System.Drawing.Color.Transparent;
            this.btnExits.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExits.FlatAppearance.BorderSize = 0;
            this.btnExits.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExits.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.btnExits.IconColor = System.Drawing.Color.Black;
            this.btnExits.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnExits.IconSize = 35;
            this.btnExits.Location = new System.Drawing.Point(1188, 0);
            this.btnExits.Name = "btnExits";
            this.btnExits.Size = new System.Drawing.Size(40, 41);
            this.btnExits.TabIndex = 16;
            this.btnExits.UseVisualStyleBackColor = false;
            this.btnExits.Click += new System.EventHandler(this.btnExits_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Orange;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(1231, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(3, 758);
            this.panel4.TabIndex = 81;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Orange;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(3, 758);
            this.panel3.TabIndex = 80;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Orange;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 758);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1234, 3);
            this.panel1.TabIndex = 79;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.nmrDay);
            this.panel2.Controls.Add(this.panel11);
            this.panel2.Controls.Add(this.lbnam);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.lbthang);
            this.panel2.Controls.Add(this.lbsongay);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.lbNgay);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.rdbThang);
            this.panel2.Controls.Add(this.rdbngay);
            this.panel2.Controls.Add(this.btnFind);
            this.panel2.Controls.Add(this.panel10);
            this.panel2.Controls.Add(this.panel8);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1234, 761);
            this.panel2.TabIndex = 90;
            // 
            // nmrDay
            // 
            this.nmrDay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nmrDay.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmrDay.Location = new System.Drawing.Point(979, 163);
            this.nmrDay.Name = "nmrDay";
            this.nmrDay.Size = new System.Drawing.Size(120, 39);
            this.nmrDay.TabIndex = 126;
            this.nmrDay.Visible = false;
            this.nmrDay.KeyUp += new System.Windows.Forms.KeyEventHandler(this.nmrDay_KeyUp);
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.rdbChiphi);
            this.panel11.Controls.Add(this.rdbdoanhthu);
            this.panel11.Location = new System.Drawing.Point(778, 113);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(270, 39);
            this.panel11.TabIndex = 125;
            // 
            // rdbChiphi
            // 
            this.rdbChiphi.AutoSize = true;
            this.rdbChiphi.CheckedColor = System.Drawing.Color.DarkOrange;
            this.rdbChiphi.Location = new System.Drawing.Point(158, 4);
            this.rdbChiphi.MinimumSize = new System.Drawing.Size(0, 21);
            this.rdbChiphi.Name = "rdbChiphi";
            this.rdbChiphi.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.rdbChiphi.Size = new System.Drawing.Size(100, 29);
            this.rdbChiphi.TabIndex = 127;
            this.rdbChiphi.Text = "Chi phí";
            this.rdbChiphi.UnCheckedColor = System.Drawing.Color.Gray;
            this.rdbChiphi.UseVisualStyleBackColor = true;
            // 
            // rdbdoanhthu
            // 
            this.rdbdoanhthu.AutoSize = true;
            this.rdbdoanhthu.CheckedColor = System.Drawing.Color.DarkOrange;
            this.rdbdoanhthu.Location = new System.Drawing.Point(14, 3);
            this.rdbdoanhthu.MinimumSize = new System.Drawing.Size(0, 21);
            this.rdbdoanhthu.Name = "rdbdoanhthu";
            this.rdbdoanhthu.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.rdbdoanhthu.Size = new System.Drawing.Size(129, 29);
            this.rdbdoanhthu.TabIndex = 126;
            this.rdbdoanhthu.Text = "Doanh thu";
            this.rdbdoanhthu.UnCheckedColor = System.Drawing.Color.Gray;
            this.rdbdoanhthu.UseVisualStyleBackColor = true;
            this.rdbdoanhthu.CheckedChanged += new System.EventHandler(this.rdbdoanhthu_CheckedChanged);
            // 
            // lbnam
            // 
            this.lbnam.AutoSize = true;
            this.lbnam.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbnam.Location = new System.Drawing.Point(688, 114);
            this.lbnam.Name = "lbnam";
            this.lbnam.Size = new System.Drawing.Size(30, 32);
            this.lbnam.TabIndex = 124;
            this.lbnam.Text = "...";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(628, 115);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 32);
            this.label9.TabIndex = 123;
            this.label9.Text = "Năm";
            // 
            // lbthang
            // 
            this.lbthang.AutoSize = true;
            this.lbthang.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbthang.Location = new System.Drawing.Point(592, 114);
            this.lbthang.Name = "lbthang";
            this.lbthang.Size = new System.Drawing.Size(30, 32);
            this.lbthang.TabIndex = 122;
            this.lbthang.Text = "...";
            // 
            // lbsongay
            // 
            this.lbsongay.AutoSize = true;
            this.lbsongay.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbsongay.Location = new System.Drawing.Point(480, 114);
            this.lbsongay.Name = "lbsongay";
            this.lbsongay.Size = new System.Drawing.Size(30, 32);
            this.lbsongay.TabIndex = 121;
            this.lbsongay.Text = "...";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(516, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 32);
            this.label5.TabIndex = 120;
            this.label5.Text = "Tháng";
            // 
            // lbNgay
            // 
            this.lbNgay.AutoSize = true;
            this.lbNgay.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNgay.Location = new System.Drawing.Point(413, 114);
            this.lbNgay.Name = "lbNgay";
            this.lbNgay.Size = new System.Drawing.Size(71, 32);
            this.lbNgay.TabIndex = 119;
            this.lbNgay.Text = "Ngày";
            // 
            // rdbThang
            // 
            this.rdbThang.AutoSize = true;
            this.rdbThang.CheckedColor = System.Drawing.Color.DarkOrange;
            this.rdbThang.Location = new System.Drawing.Point(275, 177);
            this.rdbThang.MinimumSize = new System.Drawing.Size(0, 21);
            this.rdbThang.Name = "rdbThang";
            this.rdbThang.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.rdbThang.Size = new System.Drawing.Size(93, 29);
            this.rdbThang.TabIndex = 117;
            this.rdbThang.Text = "Tháng";
            this.rdbThang.UnCheckedColor = System.Drawing.Color.Gray;
            this.rdbThang.UseVisualStyleBackColor = true;
            this.rdbThang.CheckedChanged += new System.EventHandler(this.rdbThang_CheckedChanged);
            // 
            // rdbngay
            // 
            this.rdbngay.AutoSize = true;
            this.rdbngay.CheckedColor = System.Drawing.Color.DarkOrange;
            this.rdbngay.Location = new System.Drawing.Point(185, 177);
            this.rdbngay.MinimumSize = new System.Drawing.Size(0, 21);
            this.rdbngay.Name = "rdbngay";
            this.rdbngay.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.rdbngay.Size = new System.Drawing.Size(84, 29);
            this.rdbngay.TabIndex = 116;
            this.rdbngay.Text = "Ngày";
            this.rdbngay.UnCheckedColor = System.Drawing.Color.Gray;
            this.rdbngay.UseVisualStyleBackColor = true;
            // 
            // btnFind
            // 
            this.btnFind.BackColor = System.Drawing.Color.White;
            this.btnFind.ForeColor = System.Drawing.Color.DarkOrange;
            this.btnFind.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnFind.IconColor = System.Drawing.Color.DarkOrange;
            this.btnFind.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnFind.IconSize = 49;
            this.btnFind.Location = new System.Drawing.Point(1105, 157);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(56, 49);
            this.btnFind.TabIndex = 115;
            this.btnFind.TabStop = false;
            this.btnFind.Visible = false;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // FThongKeCT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 761);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FThongKeCT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "...";
            this.Load += new System.EventHandler(this.FThongKeCT_Load);
            this.panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrDay)).EndInit();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnFind)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private DemoCTControls.NARadioButton rdbThang;
        private DemoCTControls.NARadioButton rdbngay;
        private FontAwesome.Sharp.IconPictureBox btnFind;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbsongay;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbNgay;
        private System.Windows.Forms.Label lbnam;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbthang;
        private System.Windows.Forms.Label lbTongtien;
        private System.Windows.Forms.Panel panel11;
        private DemoCTControls.NARadioButton rdbChiphi;
        private DemoCTControls.NARadioButton rdbdoanhthu;
        private System.Windows.Forms.NumericUpDown nmrDay;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private FontAwesome.Sharp.IconButton btnExits;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}