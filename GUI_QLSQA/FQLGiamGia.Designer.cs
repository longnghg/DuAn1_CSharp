
namespace GUI_QLSQA
{
    partial class FQLGiamGia
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnTim = new FontAwesome.Sharp.IconButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMasp = new System.Windows.Forms.TextBox();
            this.txtTensp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGiamGia = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnLuu = new FontAwesome.Sharp.IconButton();
            this.lbAllSaleMode = new System.Windows.Forms.Label();
            this.btnSale = new FontAwesome.Sharp.IconButton();
            this.btnKhongSale = new FontAwesome.Sharp.IconButton();
            this.btnResetAllSales = new FontAwesome.Sharp.IconButton();
            this.btnTatCa = new FontAwesome.Sharp.IconButton();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAllSaleMode = new DemoCTControls.NAToggleButton();
            this.btnTailai = new FontAwesome.Sharp.IconButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTim = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.Peru;
            this.dataGridView1.Location = new System.Drawing.Point(2, 3);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1012, 386);
            this.dataGridView1.TabIndex = 79;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // btnTim
            // 
            this.btnTim.Enabled = false;
            this.btnTim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTim.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTim.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnTim.IconColor = System.Drawing.Color.Black;
            this.btnTim.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnTim.IconSize = 30;
            this.btnTim.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnTim.Location = new System.Drawing.Point(496, 256);
            this.btnTim.Name = "btnTim";
            this.btnTim.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnTim.Size = new System.Drawing.Size(57, 33);
            this.btnTim.TabIndex = 81;
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(251, 295);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1015, 377);
            this.panel1.TabIndex = 82;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(441, 152);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 30);
            this.label3.TabIndex = 87;
            this.label3.Text = "Tên sp:";
            // 
            // txtMasp
            // 
            this.txtMasp.Enabled = false;
            this.txtMasp.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMasp.Location = new System.Drawing.Point(328, 153);
            this.txtMasp.MaxLength = 50;
            this.txtMasp.Name = "txtMasp";
            this.txtMasp.Size = new System.Drawing.Size(107, 33);
            this.txtMasp.TabIndex = 84;
            // 
            // txtTensp
            // 
            this.txtTensp.Enabled = false;
            this.txtTensp.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTensp.Location = new System.Drawing.Point(522, 153);
            this.txtTensp.MaxLength = 50;
            this.txtTensp.Name = "txtTensp";
            this.txtTensp.Size = new System.Drawing.Size(232, 33);
            this.txtTensp.TabIndex = 85;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(252, 152);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 30);
            this.label2.TabIndex = 86;
            this.label2.Text = "Mã sp:";
            // 
            // txtGiamGia
            // 
            this.txtGiamGia.Enabled = false;
            this.txtGiamGia.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGiamGia.Location = new System.Drawing.Point(879, 153);
            this.txtGiamGia.MaxLength = 50;
            this.txtGiamGia.Name = "txtGiamGia";
            this.txtGiamGia.Size = new System.Drawing.Size(66, 33);
            this.txtGiamGia.TabIndex = 1;
            this.txtGiamGia.TextChanged += new System.EventHandler(this.txtGiamGia_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(774, 152);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 30);
            this.label4.TabIndex = 90;
            this.label4.Text = "Giảm giá:";
            // 
            // btnLuu
            // 
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.IconChar = FontAwesome.Sharp.IconChar.Save;
            this.btnLuu.IconColor = System.Drawing.Color.Black;
            this.btnLuu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLuu.IconSize = 26;
            this.btnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuu.Location = new System.Drawing.Point(992, 152);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnLuu.Size = new System.Drawing.Size(106, 34);
            this.btnLuu.TabIndex = 2;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Visible = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // lbAllSaleMode
            // 
            this.lbAllSaleMode.AutoSize = true;
            this.lbAllSaleMode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAllSaleMode.Location = new System.Drawing.Point(253, 222);
            this.lbAllSaleMode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbAllSaleMode.Name = "lbAllSaleMode";
            this.lbAllSaleMode.Size = new System.Drawing.Size(239, 21);
            this.lbAllSaleMode.TabIndex = 93;
            this.lbAllSaleMode.Text = "Chế độ giảm giá tất cả sản phẩm:";
            this.lbAllSaleMode.Visible = false;
            // 
            // btnSale
            // 
            this.btnSale.BackColor = System.Drawing.Color.White;
            this.btnSale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSale.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSale.ForeColor = System.Drawing.Color.Black;
            this.btnSale.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnSale.IconColor = System.Drawing.Color.Black;
            this.btnSale.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSale.Location = new System.Drawing.Point(58, 298);
            this.btnSale.Name = "btnSale";
            this.btnSale.Size = new System.Drawing.Size(193, 72);
            this.btnSale.TabIndex = 95;
            this.btnSale.Text = "Có Sale";
            this.btnSale.UseVisualStyleBackColor = false;
            this.btnSale.Click += new System.EventHandler(this.btnSale_Click);
            // 
            // btnKhongSale
            // 
            this.btnKhongSale.BackColor = System.Drawing.Color.White;
            this.btnKhongSale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKhongSale.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKhongSale.ForeColor = System.Drawing.Color.Black;
            this.btnKhongSale.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnKhongSale.IconColor = System.Drawing.Color.Black;
            this.btnKhongSale.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnKhongSale.Location = new System.Drawing.Point(58, 376);
            this.btnKhongSale.Name = "btnKhongSale";
            this.btnKhongSale.Size = new System.Drawing.Size(193, 83);
            this.btnKhongSale.TabIndex = 96;
            this.btnKhongSale.Text = "Không Sale";
            this.btnKhongSale.UseVisualStyleBackColor = false;
            this.btnKhongSale.Click += new System.EventHandler(this.btnKhongSale_Click);
            // 
            // btnResetAllSales
            // 
            this.btnResetAllSales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetAllSales.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetAllSales.IconChar = FontAwesome.Sharp.IconChar.Eraser;
            this.btnResetAllSales.IconColor = System.Drawing.Color.Black;
            this.btnResetAllSales.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnResetAllSales.IconSize = 26;
            this.btnResetAllSales.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnResetAllSales.Location = new System.Drawing.Point(1074, 258);
            this.btnResetAllSales.Name = "btnResetAllSales";
            this.btnResetAllSales.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnResetAllSales.Size = new System.Drawing.Size(192, 34);
            this.btnResetAllSales.TabIndex = 3;
            this.btnResetAllSales.Text = "Hủy Sale tất cả SP";
            this.btnResetAllSales.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnResetAllSales.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnResetAllSales.UseVisualStyleBackColor = true;
            this.btnResetAllSales.Visible = false;
            this.btnResetAllSales.Click += new System.EventHandler(this.btnResetAllSales_Click);
            // 
            // btnTatCa
            // 
            this.btnTatCa.BackColor = System.Drawing.Color.White;
            this.btnTatCa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTatCa.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTatCa.ForeColor = System.Drawing.Color.Black;
            this.btnTatCa.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnTatCa.IconColor = System.Drawing.Color.Black;
            this.btnTatCa.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnTatCa.Location = new System.Drawing.Point(58, 465);
            this.btnTatCa.Name = "btnTatCa";
            this.btnTatCa.Size = new System.Drawing.Size(193, 83);
            this.btnTatCa.TabIndex = 98;
            this.btnTatCa.Text = "Tất cả";
            this.btnTatCa.UseVisualStyleBackColor = false;
            this.btnTatCa.Click += new System.EventHandler(this.btnTatCa_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(947, 154);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 30);
            this.label5.TabIndex = 99;
            this.label5.Text = "%";
            // 
            // btnAllSaleMode
            // 
            this.btnAllSaleMode.AutoCheck = false;
            this.btnAllSaleMode.AutoSize = true;
            this.btnAllSaleMode.Location = new System.Drawing.Point(494, 220);
            this.btnAllSaleMode.MinimumSize = new System.Drawing.Size(60, 30);
            this.btnAllSaleMode.Name = "btnAllSaleMode";
            this.btnAllSaleMode.OffBackColor = System.Drawing.Color.Gray;
            this.btnAllSaleMode.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.btnAllSaleMode.OnBackColor = System.Drawing.Color.Orange;
            this.btnAllSaleMode.OnToggleColor = System.Drawing.Color.White;
            this.btnAllSaleMode.Size = new System.Drawing.Size(60, 30);
            this.btnAllSaleMode.TabIndex = 92;
            this.btnAllSaleMode.UseVisualStyleBackColor = true;
            this.btnAllSaleMode.Visible = false;
            this.btnAllSaleMode.CheckedChanged += new System.EventHandler(this.btnAllSaleMode_CheckedChanged);
            this.btnAllSaleMode.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnAllSaleMode_MouseClick);
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
            this.btnTailai.Location = new System.Drawing.Point(559, 256);
            this.btnTailai.Name = "btnTailai";
            this.btnTailai.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnTailai.Size = new System.Drawing.Size(57, 33);
            this.btnTailai.TabIndex = 100;
            this.btnTailai.UseVisualStyleBackColor = true;
            this.btnTailai.Click += new System.EventHandler(this.btnTailai_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1445, 5);
            this.panel2.TabIndex = 101;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Orange;
            this.label1.Location = new System.Drawing.Point(470, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(549, 47);
            this.label1.TabIndex = 78;
            this.label1.Text = "QUẢN LÝ GIẢM GIÁ SẢN PHẨM";
            // 
            // txtTim
            // 
            this.txtTim.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTim.ForeColor = System.Drawing.Color.LightGray;
            this.txtTim.Location = new System.Drawing.Point(251, 256);
            this.txtTim.MaxLength = 50;
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(233, 33);
            this.txtTim.TabIndex = 97;
            this.txtTim.Text = "-- Nhập tên hoặc mã SP --";
            this.txtTim.Click += new System.EventHandler(this.txtTim_Click);
            this.txtTim.Leave += new System.EventHandler(this.txtTim_Leave);
            // 
            // FQLGiamGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1445, 684);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnTailai);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnTatCa);
            this.Controls.Add(this.btnResetAllSales);
            this.Controls.Add(this.txtTim);
            this.Controls.Add(this.btnKhongSale);
            this.Controls.Add(this.btnSale);
            this.Controls.Add(this.lbAllSaleMode);
            this.Controls.Add(this.btnAllSaleMode);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.txtGiamGia);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMasp);
            this.Controls.Add(this.txtTensp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnTim);
            this.Name = "FQLGiamGia";
            this.Text = "FQLGiamGia";
            this.Load += new System.EventHandler(this.FQLGiamGia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private FontAwesome.Sharp.IconButton btnTim;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMasp;
        private System.Windows.Forms.TextBox txtTensp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGiamGia;
        private System.Windows.Forms.Label label4;
        private FontAwesome.Sharp.IconButton btnLuu;
        private System.Windows.Forms.Label lbAllSaleMode;
        private DemoCTControls.NAToggleButton btnAllSaleMode;
        private FontAwesome.Sharp.IconButton btnSale;
        private FontAwesome.Sharp.IconButton btnKhongSale;
        private FontAwesome.Sharp.IconButton btnResetAllSales;
        private FontAwesome.Sharp.IconButton btnTatCa;
        private System.Windows.Forms.Label label5;
        private FontAwesome.Sharp.IconButton btnTailai;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTim;
    }
}