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
    public partial class FAddKH : Form
    {
        BUS_KhachHang buskh = new BUS_KhachHang();
        BUS_Nhanvien nv = new BUS_Nhanvien();
        string sdtkh;
        public FAddKH(string sdt)
        {
            InitializeComponent();
            sdtkh = sdt;
        }


        private void FAddKH_Load(object sender, EventArgs e)
        {
            txtSDT.Text = sdtkh;
            txtSDT.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(txtSDT.Text.Trim().Length>0 && txtTenKH.Text.Trim().Length > 0)
            {
                if (nv.checkisNumber(txtSDT.Text.Trim()))
                {
                    if(txtSDT.Text.Trim().Length>= 10 && txtSDT.Text.Trim().Length<= 15)
                    {
                        if (nv.checkcontainNumber(txtTenKH.Text.Trim()) || nv.hasSpecialChar(txtTenKH.Text.Trim()))
                        {
                            MessageBox.Show("Tên không hợp lệ", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            DTO_KhachHang kh = new DTO_KhachHang();
                            kh.SDT = txtSDT.Text.Trim();
                            kh.TEn = txtTenKH.Text.Trim();
                            
                            if (buskh.themKH(kh))
                            {
                                MessageBox.Show("Thêm khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Thêm khách hàng không thành công", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Số điện thoại chứa từ 10 - 15 ký tự", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }
                else
                {
                    MessageBox.Show("Số điện thoại không hợp lệ", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Mời bạn nhập đầy đủ thông tin", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
