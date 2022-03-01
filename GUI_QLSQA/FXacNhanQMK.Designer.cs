
namespace GUI_QLSQA
{
    partial class FXacNhanQMK
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FXacNhanQMK));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtXacnhan = new DemoCTControls.NAControls.RJTextbox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnExits = new FontAwesome.Sharp.IconButton();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.iconNo = new FontAwesome.Sharp.IconPictureBox();
            this.iconYes = new FontAwesome.Sharp.IconPictureBox();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconYes)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.txtXacnhan);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.iconButton1);
            this.panel1.Controls.Add(this.iconNo);
            this.panel1.Controls.Add(this.iconYes);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(577, 108);
            this.panel1.TabIndex = 11;
            // 
            // txtXacnhan
            // 
            this.txtXacnhan.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtXacnhan.BorderColor = System.Drawing.Color.DarkOrange;
            this.txtXacnhan.BorderFocusColor = System.Drawing.Color.Navy;
            this.txtXacnhan.BorderSize = 2;
            this.txtXacnhan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtXacnhan.ForeColor = System.Drawing.Color.DimGray;
            this.txtXacnhan.Location = new System.Drawing.Point(94, 53);
            this.txtXacnhan.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.txtXacnhan.Multiline = false;
            this.txtXacnhan.Name = "txtXacnhan";
            this.txtXacnhan.Padding = new System.Windows.Forms.Padding(7);
            this.txtXacnhan.PasswordChar = false;
            this.txtXacnhan.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtXacnhan.PlaceholderText = "Mã xác nhận";
            this.txtXacnhan.Size = new System.Drawing.Size(279, 36);
            this.txtXacnhan.TabIndex = 19;
            this.txtXacnhan.UnderlinedStyle = true;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(212)))), ((int)(((byte)(59)))));
            this.panel6.Controls.Add(this.btnExits);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(3, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(571, 30);
            this.panel6.TabIndex = 18;
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
            this.btnExits.Location = new System.Drawing.Point(531, 0);
            this.btnExits.Name = "btnExits";
            this.btnExits.Size = new System.Drawing.Size(40, 30);
            this.btnExits.TabIndex = 15;
            this.btnExits.UseVisualStyleBackColor = false;
            this.btnExits.Click += new System.EventHandler(this.btnExits_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Orange;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(3, 105);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(571, 3);
            this.panel5.TabIndex = 17;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Orange;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(574, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(3, 105);
            this.panel4.TabIndex = 16;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Orange;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(3, 105);
            this.panel3.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Orange;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(577, 3);
            this.panel2.TabIndex = 14;
            // 
            // iconButton1
            // 
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconButton1.IconColor = System.Drawing.Color.Black;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.Location = new System.Drawing.Point(382, 54);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(92, 33);
            this.iconButton1.TabIndex = 12;
            this.iconButton1.Text = "Xác nhận";
            this.iconButton1.UseVisualStyleBackColor = true;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // iconNo
            // 
            this.iconNo.BackColor = System.Drawing.Color.White;
            this.iconNo.ForeColor = System.Drawing.Color.Red;
            this.iconNo.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.iconNo.IconColor = System.Drawing.Color.Red;
            this.iconNo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconNo.IconSize = 33;
            this.iconNo.Location = new System.Drawing.Point(480, 60);
            this.iconNo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.iconNo.Name = "iconNo";
            this.iconNo.Rotation = 45D;
            this.iconNo.Size = new System.Drawing.Size(38, 33);
            this.iconNo.TabIndex = 11;
            this.iconNo.TabStop = false;
            this.iconNo.Visible = false;
            // 
            // iconYes
            // 
            this.iconYes.BackColor = System.Drawing.Color.White;
            this.iconYes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.iconYes.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.iconYes.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.iconYes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconYes.IconSize = 33;
            this.iconYes.Location = new System.Drawing.Point(480, 57);
            this.iconYes.Name = "iconYes";
            this.iconYes.Size = new System.Drawing.Size(38, 33);
            this.iconYes.TabIndex = 13;
            this.iconYes.TabStop = false;
            this.iconYes.Visible = false;
            // 
            // FXacNhanQMK
            // 
            this.AcceptButton = this.iconButton1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(577, 108);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FXacNhanQMK";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FXacNhanQMK";
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconYes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconPictureBox iconNo;
        private FontAwesome.Sharp.IconPictureBox iconYes;
        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private FontAwesome.Sharp.IconButton btnExits;
        private DemoCTControls.NAControls.RJTextbox txtXacnhan;
    }
}