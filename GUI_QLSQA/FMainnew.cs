using BUS_QLSQA;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_QLSQA
{
    public partial class FMainnew : Form
    {
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;
        public static string mailnv;
        public static int active_addItem = 0; // 0 : không có đang nhập sản phẩm , 1 đang nhập sản phẩm
        BUS_Nhanvien nv = new BUS_Nhanvien();
        public FMainnew()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 80);
            panelMenu.Controls.Add(leftBorderBtn);
            //Form

        }
        #region codeform
        //Structs
        private struct RGBColors
        {
            public static Color color1 = Color.Black;
        }
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.Goldenrod;
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //Left border button
                leftBorderBtn.BackColor = Color.Black;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                //Current Child Form Icon
                iconCurrentChildForm.IconChar = currentBtn.IconChar;
                iconCurrentChildForm.IconColor = color;
            }
        }
        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(255, 212, 59);
                currentBtn.ForeColor = Color.Black;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Black;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }
        public void OpenChildForm(Form childForm)
        {
            //open only form
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            iconCurrentChildForm.IconChar = IconChar.Home;
            iconCurrentChildForm.IconColor = Color.Black;
            lblTitleChildForm.Text = "Trang chủ";
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
                Reset();
            }
        }

        //private void Thongtinnv()
        //{
        //    FThongtinNV childForm = new FThongtinNV(mailnv);
        //    childForm.TopLevel = false;
        //    childForm.FormBorderStyle = FormBorderStyle.None;
        //    childForm.Dock = DockStyle.Fill;
        //    panelDesktop.Controls.Add(childForm);
        //    panelDesktop.Tag = childForm;
        //    childForm.BringToFront();
        //    childForm.Show();
        //}

        #endregion
        private void FMainnew_Load(object sender, EventArgs e)
        {
            if(nv.Role(FMainnew.mailnv))
            {
                btnGiamgia.Visible = true;
                btnNhanvien.Visible = true;
                btnDoanhthu.Visible = true;
                btnMucluc.Visible = true;
            }
            else
            {
                btnGiamgia.Visible = false;
                btnNhanvien.Visible = false;
                btnDoanhthu.Visible = false;
                btnMucluc.Visible = false;
            }
        }
        private void pbLogo_Click(object sender, EventArgs e)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
                Reset();
            }
        }
        private void btnThanhToan_Click_1(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new FThanhToans());
            lblTitleChildForm.Text = btnThanhToan.Text;
        }
        private void btnSanPham_Click_1(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new FSanpham());
            lblTitleChildForm.Text = btnSanPham.Text;
        }
        private void btnDoanhthu_Click_1(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new FDoanhThu());
            lblTitleChildForm.Text = btnDoanhthu.Text;
        }
        private void btnHoaDon_Click_1(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new FDanhsachhoaDon());
            lblTitleChildForm.Text = btnHoaDon.Text;
        }
        private void btnVanchuyen_Click_1(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new FVanchuyen());
            lblTitleChildForm.Text = btnVanchuyen.Text;
        }
        private void btnKhachhang_Click_1(object sender, EventArgs e)
        {
            lblTitleChildForm.Text = btnKhachhang.Text;
            OpenChildForm(new FKhachhang());
            ActivateButton(sender, RGBColors.color1);
        }
        private void btnMucluc_Click_1(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new FMucluc());
            lblTitleChildForm.Text = btnMucluc.Text;
        }

        private void btnNhanvien_Click_1(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new FNhanvien());
            lblTitleChildForm.Text = btnNhanvien.Text;
        }

        private void btnGiamgia_Click_1(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new FQLGiamGia());
            lblTitleChildForm.Text = btnGiamgia.Text;
        }
        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panelTitle_MouseDown_1(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void iconExit_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát ứng dụng không?", "Hỏi đáp", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                Application.Exit();
        }
        private void iconRestone_Click_1(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }
        private void iconHide_Click_2(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void iconLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng xuất không?", "Hỏi đáp", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                FLogin f = new FLogin();
                this.Close();
                f.Show();
            }
        }

        private void lblTennguoidung_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FThongtinNV(mailnv));
            iconCurrentChildForm.IconChar = IconChar.User;
            lblTitleChildForm.Text = "Thông tin nhân viên";
        }
    }
}
