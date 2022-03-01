
namespace GUI_QLSQA
{
    partial class FSanpham
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
            this.txtTim = new System.Windows.Forms.TextBox();
            this.txtGiaBan = new System.Windows.Forms.TextBox();
            this.dtgvdsSanpham = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnXoa = new FontAwesome.Sharp.IconButton();
            this.cbMausac = new DemoCTControls.NAControls.RJComboBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtMasp = new System.Windows.Forms.TextBox();
            this.cbTenloai1 = new DemoCTControls.NAControls.RJComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnChitiet = new DemoCTControls.NAToggleButton();
            this.lbmausac = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnAnhsau = new FontAwesome.Sharp.IconButton();
            this.pbAnh2 = new System.Windows.Forms.PictureBox();
            this.lbkichco = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rdbSizeXXL = new DemoCTControls.NARadioButton();
            this.rdbSizeXL = new DemoCTControls.NARadioButton();
            this.rdbSizeL = new DemoCTControls.NARadioButton();
            this.rdbSizeM = new DemoCTControls.NARadioButton();
            this.rdbSizeS = new DemoCTControls.NARadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rdbNamvaNu = new DemoCTControls.NARadioButton();
            this.rdbNu = new DemoCTControls.NARadioButton();
            this.rdbNam = new DemoCTControls.NARadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSl = new System.Windows.Forms.TextBox();
            this.lbsl = new System.Windows.Forms.Label();
            this.btnTailai = new FontAwesome.Sharp.IconButton();
            this.btnDanhsach = new FontAwesome.Sharp.IconButton();
            this.btnTim = new FontAwesome.Sharp.IconButton();
            this.btnSua = new FontAwesome.Sharp.IconButton();
            this.btnLuu = new FontAwesome.Sharp.IconButton();
            this.btnThem = new DemoCTControls.NAToggleButton();
            this.btnAnhtrc = new FontAwesome.Sharp.IconButton();
            this.pbAnh1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTensp = new System.Windows.Forms.TextBox();
            this.txtGiaNhap = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvdsSanpham)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAnh2)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAnh1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTim
            // 
            this.txtTim.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTim.ForeColor = System.Drawing.Color.LightGray;
            this.txtTim.Location = new System.Drawing.Point(14, 296);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(238, 33);
            this.txtTim.TabIndex = 64;
            this.txtTim.Text = "-- Nhập tên hoặc mã SP --";
            this.txtTim.Click += new System.EventHandler(this.txtTim_Click);
            this.txtTim.Leave += new System.EventHandler(this.txtTim_Leave);
            // 
            // txtGiaBan
            // 
            this.txtGiaBan.Enabled = false;
            this.txtGiaBan.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGiaBan.Location = new System.Drawing.Point(605, 122);
            this.txtGiaBan.MaxLength = 50;
            this.txtGiaBan.Name = "txtGiaBan";
            this.txtGiaBan.Size = new System.Drawing.Size(232, 33);
            this.txtGiaBan.TabIndex = 4;
            this.txtGiaBan.TextChanged += new System.EventHandler(this.txtGiaBan_TextChanged);
            // 
            // dtgvdsSanpham
            // 
            this.dtgvdsSanpham.AllowUserToAddRows = false;
            this.dtgvdsSanpham.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgvdsSanpham.BackgroundColor = System.Drawing.Color.White;
            this.dtgvdsSanpham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvdsSanpham.GridColor = System.Drawing.Color.Peru;
            this.dtgvdsSanpham.Location = new System.Drawing.Point(12, 13);
            this.dtgvdsSanpham.MultiSelect = false;
            this.dtgvdsSanpham.Name = "dtgvdsSanpham";
            this.dtgvdsSanpham.ReadOnly = true;
            this.dtgvdsSanpham.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvdsSanpham.Size = new System.Drawing.Size(1349, 444);
            this.dtgvdsSanpham.TabIndex = 57;
            this.dtgvdsSanpham.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvdsSanpham_CellClick);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnXoa);
            this.panel1.Controls.Add(this.cbMausac);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.txtMasp);
            this.panel1.Controls.Add(this.cbTenloai1);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.btnChitiet);
            this.panel1.Controls.Add(this.lbmausac);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.btnAnhsau);
            this.panel1.Controls.Add(this.pbAnh2);
            this.panel1.Controls.Add(this.lbkichco);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtSl);
            this.panel1.Controls.Add(this.lbsl);
            this.panel1.Controls.Add(this.btnTailai);
            this.panel1.Controls.Add(this.btnDanhsach);
            this.panel1.Controls.Add(this.btnTim);
            this.panel1.Controls.Add(this.txtTim);
            this.panel1.Controls.Add(this.btnSua);
            this.panel1.Controls.Add(this.btnLuu);
            this.panel1.Controls.Add(this.btnThem);
            this.panel1.Controls.Add(this.txtGiaBan);
            this.panel1.Controls.Add(this.btnAnhtrc);
            this.panel1.Controls.Add(this.pbAnh1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtTensp);
            this.panel1.Controls.Add(this.txtGiaNhap);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1373, 804);
            this.panel1.TabIndex = 45;
            // 
            // btnXoa
            // 
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.IconChar = FontAwesome.Sharp.IconChar.Trash;
            this.btnXoa.IconColor = System.Drawing.Color.DarkOrange;
            this.btnXoa.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnXoa.IconSize = 26;
            this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoa.Location = new System.Drawing.Point(843, 292);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnXoa.Size = new System.Drawing.Size(106, 37);
            this.btnXoa.TabIndex = 93;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Visible = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // cbMausac
            // 
            this.cbMausac.BackColor = System.Drawing.Color.White;
            this.cbMausac.BorderColor = System.Drawing.Color.Black;
            this.cbMausac.BorderSize = 1;
            this.cbMausac.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMausac.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMausac.ForeColor = System.Drawing.Color.Black;
            this.cbMausac.IconColor = System.Drawing.Color.Orange;
            this.cbMausac.ListBackColor = System.Drawing.Color.NavajoWhite;
            this.cbMausac.ListTextColor = System.Drawing.Color.DimGray;
            this.cbMausac.Location = new System.Drawing.Point(605, 198);
            this.cbMausac.MinimumSize = new System.Drawing.Size(200, 30);
            this.cbMausac.Name = "cbMausac";
            this.cbMausac.Padding = new System.Windows.Forms.Padding(1);
            this.cbMausac.Size = new System.Drawing.Size(232, 34);
            this.cbMausac.TabIndex = 92;
            this.cbMausac.Texts = "";
            this.cbMausac.OnSelectedIndexChanged += new System.EventHandler(this.cbMausac_OnSelectedIndexChanged);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dtgvdsSanpham);
            this.panel5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel5.Location = new System.Drawing.Point(0, 335);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1373, 469);
            this.panel5.TabIndex = 91;
            // 
            // txtMasp
            // 
            this.txtMasp.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMasp.Location = new System.Drawing.Point(221, 79);
            this.txtMasp.Name = "txtMasp";
            this.txtMasp.Size = new System.Drawing.Size(233, 33);
            this.txtMasp.TabIndex = 1;
            // 
            // cbTenloai1
            // 
            this.cbTenloai1.BackColor = System.Drawing.Color.White;
            this.cbTenloai1.BorderColor = System.Drawing.Color.Black;
            this.cbTenloai1.BorderSize = 1;
            this.cbTenloai1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTenloai1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTenloai1.ForeColor = System.Drawing.Color.Black;
            this.cbTenloai1.IconColor = System.Drawing.Color.Orange;
            this.cbTenloai1.ListBackColor = System.Drawing.Color.NavajoWhite;
            this.cbTenloai1.ListTextColor = System.Drawing.Color.DimGray;
            this.cbTenloai1.Location = new System.Drawing.Point(605, 160);
            this.cbTenloai1.MinimumSize = new System.Drawing.Size(200, 30);
            this.cbTenloai1.Name = "cbTenloai1";
            this.cbTenloai1.Padding = new System.Windows.Forms.Padding(1);
            this.cbTenloai1.Size = new System.Drawing.Size(232, 34);
            this.cbTenloai1.TabIndex = 89;
            this.cbTenloai1.Texts = "";
            this.cbTenloai1.OnSelectedIndexChanged += new System.EventHandler(this.cbTenloai1_OnSelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.White;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Orange;
            this.label13.Location = new System.Drawing.Point(437, 20);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(373, 47);
            this.label13.TabIndex = 88;
            this.label13.Text = "QUẢN LÝ SẢN PHẨM";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(119, 263);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(142, 21);
            this.label12.TabIndex = 87;
            this.label12.Text = "Chế độ xem chi tiết";
            // 
            // btnChitiet
            // 
            this.btnChitiet.AutoSize = true;
            this.btnChitiet.Location = new System.Drawing.Point(273, 260);
            this.btnChitiet.MinimumSize = new System.Drawing.Size(60, 30);
            this.btnChitiet.Name = "btnChitiet";
            this.btnChitiet.OffBackColor = System.Drawing.Color.Gray;
            this.btnChitiet.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.btnChitiet.OnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(212)))), ((int)(((byte)(59)))));
            this.btnChitiet.OnToggleColor = System.Drawing.Color.White;
            this.btnChitiet.Size = new System.Drawing.Size(60, 30);
            this.btnChitiet.TabIndex = 86;
            this.btnChitiet.UseVisualStyleBackColor = true;
            this.btnChitiet.CheckedChanged += new System.EventHandler(this.btnChitiet_CheckedChanged);
            // 
            // lbmausac
            // 
            this.lbmausac.AutoSize = true;
            this.lbmausac.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbmausac.Location = new System.Drawing.Point(508, 203);
            this.lbmausac.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbmausac.Name = "lbmausac";
            this.lbmausac.Size = new System.Drawing.Size(96, 30);
            this.lbmausac.TabIndex = 84;
            this.lbmausac.Text = "Màu sắc:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(1099, 50);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 21);
            this.label10.TabIndex = 83;
            this.label10.Text = "Mặt sau áo";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(939, 50);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 21);
            this.label9.TabIndex = 82;
            this.label9.Text = "Mặt trước áo";
            // 
            // btnAnhsau
            // 
            this.btnAnhsau.Enabled = false;
            this.btnAnhsau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnhsau.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnhsau.IconChar = FontAwesome.Sharp.IconChar.Upload;
            this.btnAnhsau.IconColor = System.Drawing.Color.Black;
            this.btnAnhsau.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAnhsau.IconSize = 26;
            this.btnAnhsau.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAnhsau.Location = new System.Drawing.Point(1067, 235);
            this.btnAnhsau.Name = "btnAnhsau";
            this.btnAnhsau.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnAnhsau.Size = new System.Drawing.Size(145, 37);
            this.btnAnhsau.TabIndex = 9;
            this.btnAnhsau.Text = "Tải ảnh lên";
            this.btnAnhsau.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAnhsau.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAnhsau.UseVisualStyleBackColor = true;
            this.btnAnhsau.Click += new System.EventHandler(this.btnAnhsau_Click);
            // 
            // pbAnh2
            // 
            this.pbAnh2.BackColor = System.Drawing.Color.White;
            this.pbAnh2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbAnh2.Location = new System.Drawing.Point(1067, 82);
            this.pbAnh2.Name = "pbAnh2";
            this.pbAnh2.Size = new System.Drawing.Size(145, 147);
            this.pbAnh2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbAnh2.TabIndex = 80;
            this.pbAnh2.TabStop = false;
            // 
            // lbkichco
            // 
            this.lbkichco.AutoSize = true;
            this.lbkichco.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbkichco.Location = new System.Drawing.Point(508, 240);
            this.lbkichco.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbkichco.Name = "lbkichco";
            this.lbkichco.Size = new System.Drawing.Size(86, 30);
            this.lbkichco.TabIndex = 78;
            this.lbkichco.Text = "Kích cỡ:";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.rdbSizeXXL);
            this.panel4.Controls.Add(this.rdbSizeXL);
            this.panel4.Controls.Add(this.rdbSizeL);
            this.panel4.Controls.Add(this.rdbSizeM);
            this.panel4.Controls.Add(this.rdbSizeS);
            this.panel4.Location = new System.Drawing.Point(588, 235);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(291, 41);
            this.panel4.TabIndex = 77;
            // 
            // rdbSizeXXL
            // 
            this.rdbSizeXXL.AutoSize = true;
            this.rdbSizeXXL.CheckedColor = System.Drawing.Color.Orange;
            this.rdbSizeXXL.Enabled = false;
            this.rdbSizeXXL.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbSizeXXL.Location = new System.Drawing.Point(223, 9);
            this.rdbSizeXXL.MinimumSize = new System.Drawing.Size(0, 21);
            this.rdbSizeXXL.Name = "rdbSizeXXL";
            this.rdbSizeXXL.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.rdbSizeXXL.Size = new System.Drawing.Size(64, 25);
            this.rdbSizeXXL.TabIndex = 54;
            this.rdbSizeXXL.Text = "XXL";
            this.rdbSizeXXL.UnCheckedColor = System.Drawing.Color.Gray;
            this.rdbSizeXXL.UseVisualStyleBackColor = true;
            // 
            // rdbSizeXL
            // 
            this.rdbSizeXL.AutoSize = true;
            this.rdbSizeXL.CheckedColor = System.Drawing.Color.Orange;
            this.rdbSizeXL.Enabled = false;
            this.rdbSizeXL.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbSizeXL.Location = new System.Drawing.Point(162, 9);
            this.rdbSizeXL.MinimumSize = new System.Drawing.Size(0, 21);
            this.rdbSizeXL.Name = "rdbSizeXL";
            this.rdbSizeXL.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.rdbSizeXL.Size = new System.Drawing.Size(55, 25);
            this.rdbSizeXL.TabIndex = 53;
            this.rdbSizeXL.Text = "XL";
            this.rdbSizeXL.UnCheckedColor = System.Drawing.Color.Gray;
            this.rdbSizeXL.UseVisualStyleBackColor = true;
            // 
            // rdbSizeL
            // 
            this.rdbSizeL.AutoSize = true;
            this.rdbSizeL.CheckedColor = System.Drawing.Color.Orange;
            this.rdbSizeL.Enabled = false;
            this.rdbSizeL.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbSizeL.Location = new System.Drawing.Point(117, 9);
            this.rdbSizeL.MinimumSize = new System.Drawing.Size(0, 21);
            this.rdbSizeL.Name = "rdbSizeL";
            this.rdbSizeL.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.rdbSizeL.Size = new System.Drawing.Size(46, 25);
            this.rdbSizeL.TabIndex = 52;
            this.rdbSizeL.Text = "L";
            this.rdbSizeL.UnCheckedColor = System.Drawing.Color.Gray;
            this.rdbSizeL.UseVisualStyleBackColor = true;
            // 
            // rdbSizeM
            // 
            this.rdbSizeM.AutoSize = true;
            this.rdbSizeM.CheckedColor = System.Drawing.Color.Orange;
            this.rdbSizeM.Enabled = false;
            this.rdbSizeM.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbSizeM.Location = new System.Drawing.Point(63, 9);
            this.rdbSizeM.MinimumSize = new System.Drawing.Size(0, 21);
            this.rdbSizeM.Name = "rdbSizeM";
            this.rdbSizeM.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.rdbSizeM.Size = new System.Drawing.Size(52, 25);
            this.rdbSizeM.TabIndex = 51;
            this.rdbSizeM.Text = "M";
            this.rdbSizeM.UnCheckedColor = System.Drawing.Color.Gray;
            this.rdbSizeM.UseVisualStyleBackColor = true;
            // 
            // rdbSizeS
            // 
            this.rdbSizeS.AutoSize = true;
            this.rdbSizeS.Checked = true;
            this.rdbSizeS.CheckedColor = System.Drawing.Color.Orange;
            this.rdbSizeS.Enabled = false;
            this.rdbSizeS.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbSizeS.Location = new System.Drawing.Point(15, 9);
            this.rdbSizeS.MinimumSize = new System.Drawing.Size(0, 21);
            this.rdbSizeS.Name = "rdbSizeS";
            this.rdbSizeS.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.rdbSizeS.Size = new System.Drawing.Size(47, 25);
            this.rdbSizeS.TabIndex = 49;
            this.rdbSizeS.TabStop = true;
            this.rdbSizeS.Text = "S";
            this.rdbSizeS.UnCheckedColor = System.Drawing.Color.Gray;
            this.rdbSizeS.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rdbNamvaNu);
            this.panel3.Controls.Add(this.rdbNu);
            this.panel3.Controls.Add(this.rdbNam);
            this.panel3.Location = new System.Drawing.Point(221, 199);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(242, 41);
            this.panel3.TabIndex = 76;
            // 
            // rdbNamvaNu
            // 
            this.rdbNamvaNu.AutoSize = true;
            this.rdbNamvaNu.CheckedColor = System.Drawing.Color.Orange;
            this.rdbNamvaNu.Enabled = false;
            this.rdbNamvaNu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbNamvaNu.Location = new System.Drawing.Point(152, 9);
            this.rdbNamvaNu.MinimumSize = new System.Drawing.Size(0, 21);
            this.rdbNamvaNu.Name = "rdbNamvaNu";
            this.rdbNamvaNu.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.rdbNamvaNu.Size = new System.Drawing.Size(96, 25);
            this.rdbNamvaNu.TabIndex = 52;
            this.rdbNamvaNu.Text = "Nam,Nữ";
            this.rdbNamvaNu.UnCheckedColor = System.Drawing.Color.Gray;
            this.rdbNamvaNu.UseVisualStyleBackColor = true;
            // 
            // rdbNu
            // 
            this.rdbNu.AutoSize = true;
            this.rdbNu.CheckedColor = System.Drawing.Color.Orange;
            this.rdbNu.Enabled = false;
            this.rdbNu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbNu.Location = new System.Drawing.Point(87, 9);
            this.rdbNu.MinimumSize = new System.Drawing.Size(0, 21);
            this.rdbNu.Name = "rdbNu";
            this.rdbNu.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.rdbNu.Size = new System.Drawing.Size(59, 25);
            this.rdbNu.TabIndex = 51;
            this.rdbNu.Text = "Nữ";
            this.rdbNu.UnCheckedColor = System.Drawing.Color.Gray;
            this.rdbNu.UseVisualStyleBackColor = true;
            // 
            // rdbNam
            // 
            this.rdbNam.AutoSize = true;
            this.rdbNam.Checked = true;
            this.rdbNam.CheckedColor = System.Drawing.Color.Orange;
            this.rdbNam.Enabled = false;
            this.rdbNam.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbNam.Location = new System.Drawing.Point(10, 9);
            this.rdbNam.MinimumSize = new System.Drawing.Size(0, 21);
            this.rdbNam.Name = "rdbNam";
            this.rdbNam.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.rdbNam.Size = new System.Drawing.Size(72, 25);
            this.rdbNam.TabIndex = 49;
            this.rdbNam.TabStop = true;
            this.rdbNam.Text = "Nam";
            this.rdbNam.UnCheckedColor = System.Drawing.Color.Gray;
            this.rdbNam.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(118, 203);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 30);
            this.label8.TabIndex = 72;
            this.label8.Text = "Dành cho:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(508, 160);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 30);
            this.label6.TabIndex = 71;
            this.label6.Text = "Tên loại:";
            // 
            // txtSl
            // 
            this.txtSl.Enabled = false;
            this.txtSl.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSl.Location = new System.Drawing.Point(222, 161);
            this.txtSl.MaxLength = 50;
            this.txtSl.Name = "txtSl";
            this.txtSl.Size = new System.Drawing.Size(232, 33);
            this.txtSl.TabIndex = 5;
            this.txtSl.TextChanged += new System.EventHandler(this.txtSl_TextChanged);
            this.txtSl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSl_KeyPress);
            // 
            // lbsl
            // 
            this.lbsl.AutoSize = true;
            this.lbsl.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbsl.Location = new System.Drawing.Point(118, 160);
            this.lbsl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbsl.Name = "lbsl";
            this.lbsl.Size = new System.Drawing.Size(101, 30);
            this.lbsl.TabIndex = 69;
            this.lbsl.Text = "Số lượng:";
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
            this.btnTailai.Location = new System.Drawing.Point(321, 296);
            this.btnTailai.Name = "btnTailai";
            this.btnTailai.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnTailai.Size = new System.Drawing.Size(57, 33);
            this.btnTailai.TabIndex = 67;
            this.btnTailai.UseVisualStyleBackColor = true;
            this.btnTailai.Click += new System.EventHandler(this.btnTailai_Click);
            // 
            // btnDanhsach
            // 
            this.btnDanhsach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDanhsach.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDanhsach.IconChar = FontAwesome.Sharp.IconChar.List;
            this.btnDanhsach.IconColor = System.Drawing.Color.Black;
            this.btnDanhsach.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDanhsach.IconSize = 26;
            this.btnDanhsach.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDanhsach.Location = new System.Drawing.Point(1216, 293);
            this.btnDanhsach.Name = "btnDanhsach";
            this.btnDanhsach.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnDanhsach.Size = new System.Drawing.Size(145, 35);
            this.btnDanhsach.TabIndex = 66;
            this.btnDanhsach.Text = "Danh sách";
            this.btnDanhsach.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDanhsach.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDanhsach.UseVisualStyleBackColor = true;
            this.btnDanhsach.Click += new System.EventHandler(this.btnDanhsach_Click);
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
            this.btnTim.Location = new System.Drawing.Point(258, 296);
            this.btnTim.Name = "btnTim";
            this.btnTim.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnTim.Size = new System.Drawing.Size(57, 33);
            this.btnTim.TabIndex = 65;
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // btnSua
            // 
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.IconChar = FontAwesome.Sharp.IconChar.Tools;
            this.btnSua.IconColor = System.Drawing.Color.DarkOrange;
            this.btnSua.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSua.IconSize = 26;
            this.btnSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSua.Location = new System.Drawing.Point(731, 292);
            this.btnSua.Name = "btnSua";
            this.btnSua.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnSua.Size = new System.Drawing.Size(106, 37);
            this.btnSua.TabIndex = 62;
            this.btnSua.Text = "Sửa";
            this.btnSua.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.IconChar = FontAwesome.Sharp.IconChar.Save;
            this.btnLuu.IconColor = System.Drawing.Color.DarkOrange;
            this.btnLuu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLuu.IconSize = 26;
            this.btnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuu.Location = new System.Drawing.Point(619, 292);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnLuu.Size = new System.Drawing.Size(106, 37);
            this.btnLuu.TabIndex = 61;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnThem
            // 
            this.btnThem.AutoCheck = false;
            this.btnThem.AutoSize = true;
            this.btnThem.Location = new System.Drawing.Point(546, 296);
            this.btnThem.MinimumSize = new System.Drawing.Size(60, 30);
            this.btnThem.Name = "btnThem";
            this.btnThem.OffBackColor = System.Drawing.Color.Gray;
            this.btnThem.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.btnThem.OnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(212)))), ((int)(((byte)(59)))));
            this.btnThem.OnToggleColor = System.Drawing.Color.White;
            this.btnThem.Size = new System.Drawing.Size(60, 30);
            this.btnThem.TabIndex = 59;
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.CheckedChanged += new System.EventHandler(this.btnThem_CheckedChanged);
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnAnhtrc
            // 
            this.btnAnhtrc.Enabled = false;
            this.btnAnhtrc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnhtrc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnhtrc.IconChar = FontAwesome.Sharp.IconChar.Upload;
            this.btnAnhtrc.IconColor = System.Drawing.Color.Black;
            this.btnAnhtrc.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAnhtrc.IconSize = 26;
            this.btnAnhtrc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAnhtrc.Location = new System.Drawing.Point(916, 235);
            this.btnAnhtrc.Name = "btnAnhtrc";
            this.btnAnhtrc.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnAnhtrc.Size = new System.Drawing.Size(145, 37);
            this.btnAnhtrc.TabIndex = 8;
            this.btnAnhtrc.Text = "Tải ảnh lên";
            this.btnAnhtrc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAnhtrc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAnhtrc.UseVisualStyleBackColor = true;
            this.btnAnhtrc.Click += new System.EventHandler(this.btnAnh_Click);
            // 
            // pbAnh1
            // 
            this.pbAnh1.BackColor = System.Drawing.Color.White;
            this.pbAnh1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbAnh1.Location = new System.Drawing.Point(916, 82);
            this.pbAnh1.Name = "pbAnh1";
            this.pbAnh1.Size = new System.Drawing.Size(145, 147);
            this.pbAnh1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbAnh1.TabIndex = 55;
            this.pbAnh1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(508, 121);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 30);
            this.label4.TabIndex = 48;
            this.label4.Text = "Giá bán:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(508, 82);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 30);
            this.label3.TabIndex = 47;
            this.label3.Text = "Tên sp:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(118, 121);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 30);
            this.label1.TabIndex = 46;
            this.label1.Text = "Giá nhập:";
            // 
            // txtTensp
            // 
            this.txtTensp.Enabled = false;
            this.txtTensp.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTensp.Location = new System.Drawing.Point(605, 83);
            this.txtTensp.MaxLength = 50;
            this.txtTensp.Name = "txtTensp";
            this.txtTensp.Size = new System.Drawing.Size(232, 33);
            this.txtTensp.TabIndex = 2;
            // 
            // txtGiaNhap
            // 
            this.txtGiaNhap.Enabled = false;
            this.txtGiaNhap.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGiaNhap.Location = new System.Drawing.Point(222, 122);
            this.txtGiaNhap.MaxLength = 50;
            this.txtGiaNhap.Multiline = true;
            this.txtGiaNhap.Name = "txtGiaNhap";
            this.txtGiaNhap.Size = new System.Drawing.Size(232, 33);
            this.txtGiaNhap.TabIndex = 3;
            this.txtGiaNhap.TextChanged += new System.EventHandler(this.txtGiaNhap_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(118, 82);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 30);
            this.label2.TabIndex = 43;
            this.label2.Text = "Mã sp:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1373, 5);
            this.panel2.TabIndex = 87;
            // 
            // FSanpham
            // 
            this.AcceptButton = this.btnTim;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1373, 804);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FSanpham";
            this.Text = "FSanpham";
            this.Load += new System.EventHandler(this.FSanpham_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvdsSanpham)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbAnh2)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAnh1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtTim;
        private FontAwesome.Sharp.IconButton btnTailai;
        private FontAwesome.Sharp.IconButton btnDanhsach;
        private FontAwesome.Sharp.IconButton btnTim;
        private FontAwesome.Sharp.IconButton btnSua;
        private FontAwesome.Sharp.IconButton btnLuu;
        private DemoCTControls.NAToggleButton btnThem;
        private System.Windows.Forms.TextBox txtGiaBan;
        private System.Windows.Forms.DataGridView dtgvdsSanpham;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton btnAnhtrc;
        private System.Windows.Forms.PictureBox pbAnh1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTensp;
        private System.Windows.Forms.TextBox txtGiaNhap;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSl;
        private System.Windows.Forms.Label lbsl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private DemoCTControls.NARadioButton rdbNamvaNu;
        private DemoCTControls.NARadioButton rdbNu;
        private DemoCTControls.NARadioButton rdbNam;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbkichco;
        private System.Windows.Forms.Panel panel4;
        private DemoCTControls.NARadioButton rdbSizeXL;
        private DemoCTControls.NARadioButton rdbSizeL;
        private DemoCTControls.NARadioButton rdbSizeM;
        private DemoCTControls.NARadioButton rdbSizeS;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private FontAwesome.Sharp.IconButton btnAnhsau;
        private System.Windows.Forms.PictureBox pbAnh2;
        private System.Windows.Forms.Label lbmausac;
        private System.Windows.Forms.Label label12;
        private DemoCTControls.NAToggleButton btnChitiet;
        private DemoCTControls.NARadioButton rdbSizeXXL;
        private System.Windows.Forms.Label label13;
        private DemoCTControls.NAControls.RJComboBox cbTenloai1;
        private System.Windows.Forms.TextBox txtMasp;
        private System.Windows.Forms.Panel panel5;
        private DemoCTControls.NAControls.RJComboBox cbMausac;
        private FontAwesome.Sharp.IconButton btnXoa;
    }
}