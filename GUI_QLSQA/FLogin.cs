using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QLSQA;
using DTO_QLSQA;
namespace GUI_QLSQA
{
    public partial class FLogin : Form
    {
        
        BUS_Nhanvien busnhanvien = new BUS_Nhanvien();
        public FLogin()
        {
            InitializeComponent();
        }
        #region Events
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
           
            string taikhoan = txtEmail.Text;
            string pass = busnhanvien.encryption(busnhanvien.saltEncryp(txtMatkhau.Text));
            if (String.Compare(txtEmail.Text.Trim(), "ADMIN", true) == 0)
            {
                if (busnhanvien.nvDangNhap(taikhoan, pass))
                {
                    FMainnew f = new FMainnew();
                    FMainnew.mailnv = txtEmail.Text.Trim();
                    this.Hide();
                    f.ShowDialog();
                    
                }        
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (checkLogin(txtEmail.Text, txtMatkhau.Text))
                {
                    if (busnhanvien.nvDangNhap(taikhoan, pass))
                    {
                        FMainnew f = new FMainnew();
                        FMainnew.mailnv = txtEmail.Text.Trim();
                        this.Hide();
                        f.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản hoặc mật khẩu không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (txtEmail.Text.Trim() == "" || txtMatkhau.Text.Trim() == "")
                    {
                        MessageBox.Show("Bạn chưa nhập tài khoản hoặc mật khẩu", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản hoặc mật khẩu không hợp lệ", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            
        }
        #endregion
        #region codes
        private bool checkLogin(string email , string password)
        {
            if (email.Trim().Length == 0 || password.Trim().Length == 0)
                return false;
            else if (!busnhanvien.checkEmail(email))
                return false;
            else
                return true;
        }

        #endregion


        private void btnExits_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnHide_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        
        private void lbQMK_Click(object sender, EventArgs e)
        {
                if (busnhanvien.checkEmail(txtEmail.Text.Trim()))
                {
                //Tạo mã xác nhận
                    StringBuilder MaXN = new StringBuilder();
                    MaXN.Append(RandomString(6, true));              
                // Thực hiện hàm quên mật khẩu
                    if (busnhanvien.isEmailExists(txtEmail.Text.Trim()))
                    {
                    MessageBox.Show(MaXN.ToString());
                         busnhanvien.GuiMail("rotkbynbyn@gmail.com", "Mã xác nhận","Mã xác nhận của bạn là\n\t"+ MaXN.ToString());
                         MessageBox.Show("Mã xác nhận đã được gửi vào Email của bạn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                         FXacNhanQMK f = new FXacNhanQMK(MaXN.ToString(),txtEmail.Text.Trim());
                         this.Hide();
                         f.ShowDialog();
                         this.Show();
                    }
                    else
                    {
                        MessageBox.Show("Email bạn nhập không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Email không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
        }
        // code xử lý
        // Tạo chuỗi ngẫu nhiên
        public string RandomString(int size, bool Lowercases)
        {
            StringBuilder builder = new StringBuilder();
            Random rd = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * rd.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (Lowercases)
                return builder.ToString().ToLower();
            return builder.ToString();

        }

        // Tạo số ngẫu nhiên
        public string RandomNumber(int min, int max)
        {
            Random rd = new Random();
            return rd.Next(min, max).ToString();
        }

        private void FLogin_Load(object sender, EventArgs e)
        {
            txtEmail.PlaceholderText = "abc@gmail.com";
            txtMatkhau.PlaceholderText = "1231231231";
            
        }

        private void iconExit_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn thoát ứng dụng không?","Hỏi đáp",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
            Application.Exit();
        }


        private void iconHide_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FDSSanpham f = new FDSSanpham();
            f.ShowDialog();
        }
    }
}
