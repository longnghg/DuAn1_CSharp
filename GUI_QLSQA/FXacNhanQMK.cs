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
namespace GUI_QLSQA
{
    public partial class FXacNhanQMK : Form
    {
        string Code;
        string mailnv;
        BUS_Nhanvien busnv = new BUS_Nhanvien();
        public FXacNhanQMK(string maxn,string email)
        {
            InitializeComponent();
            Code = maxn;
            mailnv = email;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if(txtXacnhan.Text.Trim() == Code)
            {
                iconYes.Visible = true;
                // tạo đối tượng FLogin để sử dụng hàm random chuỗi
                FLogin f = new FLogin();
                // Tạo các chuỗi ký tự random và ghép lại
                StringBuilder Builder = new StringBuilder();
                Builder.Append(f.RandomString(2, true));
                Builder.Append(f.RandomNumber(100, 999));
                Builder.Append(f.RandomString(3, false));
                Builder.Append(f.RandomString(2, true));
                // mã hóa chuỗi ký tự vừa được random
                string newpass = busnv.encryption(busnv.saltEncryp(Builder.ToString()));
                if(busnv.QuenMatKhau(mailnv,newpass)) // Thực hiện thành công
                {
                    busnv.GuiMail("rotkbynbyn@gmail.com", "Mật khẩu mới", "Bạn đã sử dụng chức năng quên mật khẩu. Và đây là mật khẩu mới của bạn\t\n " + Builder.ToString());
                    MessageBox.Show("Mật khẩu đã được gửi tới Email của bạn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else // thực hiện thất bại
                {
                    MessageBox.Show("Trục trặc gì đó rồi đại vương ơi", "Cấp báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                iconNo.Visible = true;
                txtXacnhan.Focus();
                
            }
        }


        private void btnExits_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
