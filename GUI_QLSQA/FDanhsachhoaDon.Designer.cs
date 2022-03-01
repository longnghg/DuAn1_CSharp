
namespace GUI_QLSQA
{
    partial class FDanhsachhoaDon
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
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnTailai = new FontAwesome.Sharp.IconButton();
            this.btnTim = new FontAwesome.Sharp.IconButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpNgaykt = new System.Windows.Forms.DateTimePicker();
            this.dtpngaybd = new System.Windows.Forms.DateTimePicker();
            this.iconLeft = new FontAwesome.Sharp.IconButton();
            this.iconDoubleLeft = new FontAwesome.Sharp.IconButton();
            this.iconRight = new FontAwesome.Sharp.IconButton();
            this.iconDoubleRight = new FontAwesome.Sharp.IconButton();
            this.label12 = new System.Windows.Forms.Label();
            this.btnsearchMD = new FontAwesome.Sharp.IconButton();
            this.txtMadon = new DemoCTControls.NAControls.RJTextbox();
            this.btnChitiet = new DemoCTControls.NAToggleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Orange;
            this.label3.Location = new System.Drawing.Point(523, 28);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(282, 47);
            this.label3.TabIndex = 85;
            this.label3.Text = "HÓA ĐƠN MUA";
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
            this.dataGridView1.Size = new System.Drawing.Size(1343, 526);
            this.dataGridView1.TabIndex = 78;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1373, 5);
            this.panel1.TabIndex = 86;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(12, 152);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1349, 532);
            this.panel2.TabIndex = 87;
            // 
            // btnTailai
            // 
            this.btnTailai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTailai.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTailai.IconChar = FontAwesome.Sharp.IconChar.Sync;
            this.btnTailai.IconColor = System.Drawing.Color.Black;
            this.btnTailai.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnTailai.IconSize = 30;
            this.btnTailai.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnTailai.Location = new System.Drawing.Point(986, 112);
            this.btnTailai.Name = "btnTailai";
            this.btnTailai.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnTailai.Size = new System.Drawing.Size(61, 34);
            this.btnTailai.TabIndex = 96;
            this.btnTailai.UseVisualStyleBackColor = true;
            this.btnTailai.Click += new System.EventHandler(this.btnTailai_Click);
            // 
            // btnTim
            // 
            this.btnTim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTim.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTim.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnTim.IconColor = System.Drawing.Color.Black;
            this.btnTim.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnTim.IconSize = 30;
            this.btnTim.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnTim.Location = new System.Drawing.Point(914, 112);
            this.btnTim.Name = "btnTim";
            this.btnTim.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnTim.Size = new System.Drawing.Size(66, 34);
            this.btnTim.TabIndex = 95;
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(596, 112);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 30);
            this.label1.TabIndex = 94;
            this.label1.Text = "Đến ngày:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(248, 112);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 30);
            this.label2.TabIndex = 93;
            this.label2.Text = "Từ ngày:";
            // 
            // dtpNgaykt
            // 
            this.dtpNgaykt.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgaykt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgaykt.Location = new System.Drawing.Point(708, 113);
            this.dtpNgaykt.Name = "dtpNgaykt";
            this.dtpNgaykt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpNgaykt.Size = new System.Drawing.Size(200, 33);
            this.dtpNgaykt.TabIndex = 92;
            this.dtpNgaykt.ValueChanged += new System.EventHandler(this.dtpNgaykt_ValueChanged);
            // 
            // dtpngaybd
            // 
            this.dtpngaybd.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpngaybd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpngaybd.Location = new System.Drawing.Point(345, 114);
            this.dtpngaybd.Name = "dtpngaybd";
            this.dtpngaybd.Size = new System.Drawing.Size(200, 33);
            this.dtpngaybd.TabIndex = 91;
            this.dtpngaybd.ValueChanged += new System.EventHandler(this.dtpNgaykt_ValueChanged);
            // 
            // iconLeft
            // 
            this.iconLeft.FlatAppearance.BorderSize = 0;
            this.iconLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconLeft.IconChar = FontAwesome.Sharp.IconChar.AngleLeft;
            this.iconLeft.IconColor = System.Drawing.Color.Orange;
            this.iconLeft.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconLeft.IconSize = 60;
            this.iconLeft.Location = new System.Drawing.Point(250, 703);
            this.iconLeft.Name = "iconLeft";
            this.iconLeft.Size = new System.Drawing.Size(74, 41);
            this.iconLeft.TabIndex = 102;
            this.iconLeft.Text = " ";
            this.iconLeft.UseVisualStyleBackColor = true;
            this.iconLeft.Click += new System.EventHandler(this.iconLeft_Click_1);
            // 
            // iconDoubleLeft
            // 
            this.iconDoubleLeft.FlatAppearance.BorderSize = 0;
            this.iconDoubleLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconDoubleLeft.IconChar = FontAwesome.Sharp.IconChar.AngleDoubleLeft;
            this.iconDoubleLeft.IconColor = System.Drawing.Color.Orange;
            this.iconDoubleLeft.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconDoubleLeft.IconSize = 60;
            this.iconDoubleLeft.Location = new System.Drawing.Point(170, 703);
            this.iconDoubleLeft.Name = "iconDoubleLeft";
            this.iconDoubleLeft.Size = new System.Drawing.Size(74, 41);
            this.iconDoubleLeft.TabIndex = 101;
            this.iconDoubleLeft.Text = " ";
            this.iconDoubleLeft.UseVisualStyleBackColor = true;
            this.iconDoubleLeft.Click += new System.EventHandler(this.iconDoubleLeft_Click_1);
            // 
            // iconRight
            // 
            this.iconRight.FlatAppearance.BorderSize = 0;
            this.iconRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconRight.IconChar = FontAwesome.Sharp.IconChar.AngleRight;
            this.iconRight.IconColor = System.Drawing.Color.Orange;
            this.iconRight.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconRight.IconSize = 60;
            this.iconRight.Location = new System.Drawing.Point(1027, 703);
            this.iconRight.Name = "iconRight";
            this.iconRight.Size = new System.Drawing.Size(74, 41);
            this.iconRight.TabIndex = 100;
            this.iconRight.Text = " ";
            this.iconRight.UseVisualStyleBackColor = true;
            this.iconRight.Click += new System.EventHandler(this.iconRight_Click_1);
            // 
            // iconDoubleRight
            // 
            this.iconDoubleRight.FlatAppearance.BorderSize = 0;
            this.iconDoubleRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconDoubleRight.IconChar = FontAwesome.Sharp.IconChar.AngleDoubleRight;
            this.iconDoubleRight.IconColor = System.Drawing.Color.Orange;
            this.iconDoubleRight.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconDoubleRight.IconSize = 60;
            this.iconDoubleRight.Location = new System.Drawing.Point(1107, 702);
            this.iconDoubleRight.Name = "iconDoubleRight";
            this.iconDoubleRight.Size = new System.Drawing.Size(74, 41);
            this.iconDoubleRight.TabIndex = 99;
            this.iconDoubleRight.Text = " ";
            this.iconDoubleRight.UseVisualStyleBackColor = true;
            this.iconDoubleRight.Click += new System.EventHandler(this.iconDoubleRight_Click_1);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(22, 119);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(142, 21);
            this.label12.TabIndex = 105;
            this.label12.Text = "Chế độ xem chi tiết";
            // 
            // btnsearchMD
            // 
            this.btnsearchMD.FlatAppearance.BorderSize = 0;
            this.btnsearchMD.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnsearchMD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsearchMD.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsearchMD.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnsearchMD.IconColor = System.Drawing.Color.Black;
            this.btnsearchMD.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnsearchMD.IconSize = 35;
            this.btnsearchMD.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnsearchMD.Location = new System.Drawing.Point(1295, 112);
            this.btnsearchMD.Name = "btnsearchMD";
            this.btnsearchMD.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnsearchMD.Size = new System.Drawing.Size(66, 34);
            this.btnsearchMD.TabIndex = 107;
            this.btnsearchMD.UseVisualStyleBackColor = true;
            this.btnsearchMD.Click += new System.EventHandler(this.btnsearchMD_Click);
            // 
            // txtMadon
            // 
            this.txtMadon.BackColor = System.Drawing.Color.White;
            this.txtMadon.BorderColor = System.Drawing.Color.Orange;
            this.txtMadon.BorderFocusColor = System.Drawing.Color.DarkOrange;
            this.txtMadon.BorderSize = 2;
            this.txtMadon.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMadon.ForeColor = System.Drawing.Color.Navy;
            this.txtMadon.Location = new System.Drawing.Point(1210, 105);
            this.txtMadon.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.txtMadon.Multiline = false;
            this.txtMadon.Name = "txtMadon";
            this.txtMadon.Padding = new System.Windows.Forms.Padding(7);
            this.txtMadon.PasswordChar = false;
            this.txtMadon.PlaceholderColor = System.Drawing.Color.Gray;
            this.txtMadon.PlaceholderText = "Mã đơn";
            this.txtMadon.Size = new System.Drawing.Size(87, 45);
            this.txtMadon.TabIndex = 106;
            this.txtMadon.UnderlinedStyle = true;
            this.txtMadon._TextChanged += new System.EventHandler(this.txtMadon__TextChanged);
            // 
            // btnChitiet
            // 
            this.btnChitiet.AutoSize = true;
            this.btnChitiet.Location = new System.Drawing.Point(169, 116);
            this.btnChitiet.MinimumSize = new System.Drawing.Size(60, 30);
            this.btnChitiet.Name = "btnChitiet";
            this.btnChitiet.OffBackColor = System.Drawing.Color.Gray;
            this.btnChitiet.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.btnChitiet.OnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(212)))), ((int)(((byte)(59)))));
            this.btnChitiet.OnToggleColor = System.Drawing.Color.White;
            this.btnChitiet.Size = new System.Drawing.Size(60, 30);
            this.btnChitiet.TabIndex = 104;
            this.btnChitiet.UseVisualStyleBackColor = true;
            this.btnChitiet.CheckedChanged += new System.EventHandler(this.btnChitiet_CheckedChanged);
            // 
            // FDanhsachhoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1373, 804);
            this.Controls.Add(this.btnsearchMD);
            this.Controls.Add(this.txtMadon);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnChitiet);
            this.Controls.Add(this.iconLeft);
            this.Controls.Add(this.iconDoubleLeft);
            this.Controls.Add(this.iconRight);
            this.Controls.Add(this.iconDoubleRight);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnTailai);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.dtpNgaykt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpngaybd);
            this.Controls.Add(this.label2);
            this.Name = "FDanhsachhoaDon";
            this.Text = "FDanhsachhoaDon";
            this.Load += new System.EventHandler(this.FDanhsachhoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconButton btnTailai;
        private FontAwesome.Sharp.IconButton btnTim;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpNgaykt;
        private System.Windows.Forms.DateTimePicker dtpngaybd;
        private FontAwesome.Sharp.IconButton iconLeft;
        private FontAwesome.Sharp.IconButton iconDoubleLeft;
        private FontAwesome.Sharp.IconButton iconRight;
        private FontAwesome.Sharp.IconButton iconDoubleRight;
        private System.Windows.Forms.Label label12;
        private DemoCTControls.NAToggleButton btnChitiet;
        private DemoCTControls.NAControls.RJTextbox txtMadon;
        private FontAwesome.Sharp.IconButton btnsearchMD;
    }
}