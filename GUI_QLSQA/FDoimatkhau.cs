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
    public partial class FDoimatkhau : Form
    {
        public FDoimatkhau()
        {
            InitializeComponent();
            txtEmail.Text = FMainnew.mailnv;
        }
        BUS_Nhanvien busnhanvien = new BUS_Nhanvien();
        private void btnExits_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }
        private void ResetValue()
        {
            txtMKCu.Text = "";
            txtMkMoi.Text = "";
            txtNhapLai.Text = "";
        }
        private void btnDmk_Click(object sender, EventArgs e)
        {
            if(busnhanvien.checkData(new string[] {txtEmail.Text.Trim(), txtMKCu.Text.Trim() , txtMkMoi.Text.Trim() , txtNhapLai.Text.Trim() }))
            {
                if(txtMkMoi.Text.Length >5 && txtMkMoi.Text.Length<=30 )
                {
                    if(txtMkMoi.Text == txtNhapLai.Text)
                    {
                        string oldpass = busnhanvien.encryption(busnhanvien.saltEncryp(txtMKCu.Text));
                        string newpass = busnhanvien.encryption(busnhanvien.saltEncryp(txtMkMoi.Text));
                        string repass = busnhanvien.encryption(busnhanvien.saltEncryp(txtNhapLai.Text));
                        if (busnhanvien.DoiMatKhau(txtEmail.Text, oldpass, newpass, repass))
                        {
                            MessageBox.Show("Đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ResetValue();
                        }
                        else
                        {
                            MessageBox.Show("Đổi mật khẩu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            ResetValue();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu không khớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ResetValue();

                    }
                }
                else
                {
                    MessageBox.Show("Mật khẩu chứa từ 6 - 30 ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ResetValue();
                } 
            }
        }
    }
}
