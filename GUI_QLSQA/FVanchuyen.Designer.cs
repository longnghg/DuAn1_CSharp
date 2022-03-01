
namespace GUI_QLSQA
{
    partial class FVanchuyen
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpNgaykt = new System.Windows.Forms.DateTimePicker();
            this.dtpngaybd = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMadon = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.iconLeft = new FontAwesome.Sharp.IconButton();
            this.iconDoubleLeft = new FontAwesome.Sharp.IconButton();
            this.iconRight = new FontAwesome.Sharp.IconButton();
            this.iconDoubleRight = new FontAwesome.Sharp.IconButton();
            this.btnTailai = new FontAwesome.Sharp.IconButton();
            this.btnTim = new FontAwesome.Sharp.IconButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Orange;
            this.label3.Location = new System.Drawing.Point(482, 34);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(416, 47);
            this.label3.TabIndex = 77;
            this.label3.Text = "HÓA ĐƠN NHẬP HÀNG";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(614, 126);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 30);
            this.label1.TabIndex = 74;
            this.label1.Text = "Đến ngày:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(294, 123);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 30);
            this.label2.TabIndex = 73;
            this.label2.Text = "Từ ngày:";
            // 
            // dtpNgaykt
            // 
            this.dtpNgaykt.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgaykt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgaykt.Location = new System.Drawing.Point(726, 124);
            this.dtpNgaykt.Name = "dtpNgaykt";
            this.dtpNgaykt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpNgaykt.Size = new System.Drawing.Size(200, 33);
            this.dtpNgaykt.TabIndex = 72;
            this.dtpNgaykt.ValueChanged += new System.EventHandler(this.dtpNgaykt_ValueChanged);
            // 
            // dtpngaybd
            // 
            this.dtpngaybd.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpngaybd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpngaybd.Location = new System.Drawing.Point(391, 124);
            this.dtpngaybd.Name = "dtpngaybd";
            this.dtpngaybd.Size = new System.Drawing.Size(200, 33);
            this.dtpngaybd.TabIndex = 71;
            this.dtpngaybd.ValueChanged += new System.EventHandler(this.dtpNgaykt_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1373, 5);
            this.panel1.TabIndex = 87;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1106, 127);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 30);
            this.label4.TabIndex = 89;
            this.label4.Text = "Nhập mã đơn:";
            // 
            // txtMadon
            // 
            this.txtMadon.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMadon.Location = new System.Drawing.Point(1258, 128);
            this.txtMadon.Name = "txtMadon";
            this.txtMadon.Size = new System.Drawing.Size(100, 33);
            this.txtMadon.TabIndex = 90;
            this.txtMadon.TextChanged += new System.EventHandler(this.txtMadon_TextChanged);
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(12, 167);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1349, 578);
            this.panel2.TabIndex = 95;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.Peru;
            this.dataGridView1.Location = new System.Drawing.Point(3, 14);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1343, 561);
            this.dataGridView1.TabIndex = 70;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // iconLeft
            // 
            this.iconLeft.FlatAppearance.BorderSize = 0;
            this.iconLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconLeft.IconChar = FontAwesome.Sharp.IconChar.AngleLeft;
            this.iconLeft.IconColor = System.Drawing.Color.Orange;
            this.iconLeft.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconLeft.IconSize = 60;
            this.iconLeft.Location = new System.Drawing.Point(260, 751);
            this.iconLeft.Name = "iconLeft";
            this.iconLeft.Size = new System.Drawing.Size(74, 41);
            this.iconLeft.TabIndex = 94;
            this.iconLeft.Text = " ";
            this.iconLeft.UseVisualStyleBackColor = true;
            this.iconLeft.Click += new System.EventHandler(this.iconLeft_Click);
            // 
            // iconDoubleLeft
            // 
            this.iconDoubleLeft.FlatAppearance.BorderSize = 0;
            this.iconDoubleLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconDoubleLeft.IconChar = FontAwesome.Sharp.IconChar.AngleDoubleLeft;
            this.iconDoubleLeft.IconColor = System.Drawing.Color.Orange;
            this.iconDoubleLeft.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconDoubleLeft.IconSize = 60;
            this.iconDoubleLeft.Location = new System.Drawing.Point(180, 751);
            this.iconDoubleLeft.Name = "iconDoubleLeft";
            this.iconDoubleLeft.Size = new System.Drawing.Size(74, 41);
            this.iconDoubleLeft.TabIndex = 93;
            this.iconDoubleLeft.Text = " ";
            this.iconDoubleLeft.UseVisualStyleBackColor = true;
            this.iconDoubleLeft.Click += new System.EventHandler(this.iconDoubleLeft_Click);
            // 
            // iconRight
            // 
            this.iconRight.FlatAppearance.BorderSize = 0;
            this.iconRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconRight.IconChar = FontAwesome.Sharp.IconChar.AngleRight;
            this.iconRight.IconColor = System.Drawing.Color.Orange;
            this.iconRight.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconRight.IconSize = 60;
            this.iconRight.Location = new System.Drawing.Point(1037, 751);
            this.iconRight.Name = "iconRight";
            this.iconRight.Size = new System.Drawing.Size(74, 41);
            this.iconRight.TabIndex = 92;
            this.iconRight.Text = " ";
            this.iconRight.UseVisualStyleBackColor = true;
            this.iconRight.Click += new System.EventHandler(this.iconRight_Click);
            // 
            // iconDoubleRight
            // 
            this.iconDoubleRight.FlatAppearance.BorderSize = 0;
            this.iconDoubleRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconDoubleRight.IconChar = FontAwesome.Sharp.IconChar.AngleDoubleRight;
            this.iconDoubleRight.IconColor = System.Drawing.Color.Orange;
            this.iconDoubleRight.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconDoubleRight.IconSize = 60;
            this.iconDoubleRight.Location = new System.Drawing.Point(1117, 751);
            this.iconDoubleRight.Name = "iconDoubleRight";
            this.iconDoubleRight.Size = new System.Drawing.Size(74, 41);
            this.iconDoubleRight.TabIndex = 91;
            this.iconDoubleRight.Text = " ";
            this.iconDoubleRight.UseVisualStyleBackColor = true;
            this.iconDoubleRight.Click += new System.EventHandler(this.iconDoubleRight_Click);
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
            this.btnTailai.Location = new System.Drawing.Point(1004, 123);
            this.btnTailai.Name = "btnTailai";
            this.btnTailai.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnTailai.Size = new System.Drawing.Size(61, 34);
            this.btnTailai.TabIndex = 76;
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
            this.btnTim.Location = new System.Drawing.Point(932, 123);
            this.btnTim.Name = "btnTim";
            this.btnTim.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnTim.Size = new System.Drawing.Size(66, 34);
            this.btnTim.TabIndex = 75;
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GUI_QLSQA.Properties.Resources.IMGExcel;
            this.pictureBox1.Location = new System.Drawing.Point(15, 107);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(66, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 96;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.label5_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(86, 112);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(187, 37);
            this.label5.TabIndex = 97;
            this.label5.Text = "Xuất file Excel";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // FVanchuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1373, 804);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.iconLeft);
            this.Controls.Add(this.iconDoubleLeft);
            this.Controls.Add(this.iconRight);
            this.Controls.Add(this.iconDoubleRight);
            this.Controls.Add(this.txtMadon);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnTailai);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpNgaykt);
            this.Controls.Add(this.dtpngaybd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FVanchuyen";
            this.Text = "FVanchuyen";
            this.Load += new System.EventHandler(this.FVanchuyen_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private FontAwesome.Sharp.IconButton btnTailai;
        private FontAwesome.Sharp.IconButton btnTim;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpNgaykt;
        private System.Windows.Forms.DateTimePicker dtpngaybd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMadon;
        private FontAwesome.Sharp.IconButton iconDoubleRight;
        private FontAwesome.Sharp.IconButton iconRight;
        private FontAwesome.Sharp.IconButton iconDoubleLeft;
        private FontAwesome.Sharp.IconButton iconLeft;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
    }
}