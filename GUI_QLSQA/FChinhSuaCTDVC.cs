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
    public partial class FChinhSuaCTDVC : Form
    {
        BUS_Sanpham bussp = new BUS_Sanpham();
        BUS_CTDonVanChuyen busctdvc = new BUS_CTDonVanChuyen();
        BUS_Nhanvien nv = new BUS_Nhanvien();
        string masanphamold;
        int   mamauold;
        int sizeold;
        int soluongold;
        int madon;
        string idNV;
        public FChinhSuaCTDVC(string maspcu,int mamaucu ,int sizeocu,int soluongcu,int madonnhap,string manv)
        {
            InitializeComponent();
            masanphamold = maspcu;
            mamauold = mamaucu;
            sizeold = sizeocu;
            soluongold = soluongcu;
            madon = madonnhap;
            idNV = manv;
        }

        private void FChinhSuaCTDVC_Load(object sender, EventArgs e)
        {
            LoadCombobox();
            txtmaspcu.Text = masanphamold;
            cbmaucu.SelectedValue = mamauold;
            cbsizecu.SelectedValue = sizeold;
            cbMausac.SelectedValue = mamauold;
            cbSize.SelectedValue = sizeold;
            txtSlcu.Text = soluongold.ToString();
            txtMasp.Text = masanphamold;
            txtslmoi.Text = soluongold.ToString();
        }
       

        #region Event
        private void btnLuu_Click(object sender, EventArgs e)
        {

            if (nv.checkData(new string[] { txtslmoi.Text.Trim(), txtMasp.Text.Trim() }))
            {
                if (!nv.hasSpecialChar(txtMasp.Text))
                {
                    string newMasp = txtMasp.Text.Trim();
                    int newsoluong = int.Parse(txtslmoi.Text.Trim());
                    int newMaMau = int.Parse(cbMausac.SelectedValue.ToString());
                    int newSize = int.Parse(cbSize.SelectedValue.ToString());
                    if (MessageBox.Show(" Bạn có muốn thay đổi không ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (busctdvc.UpdateCTDVC(masanphamold, sizeold, mamauold, newMasp, newSize, newMaMau, madon, idNV, newsoluong))
                        {
                            MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Đã quá hạn cập nhật đơn vận chuyển", "Báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Mã sp không chứa ký tự đặc biệt", "Báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Nhập thông tin kìa bạn ơi", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtslmoi_TextChanged(object sender, EventArgs e)
        {
            if (!nv.checkisNumber(txtslmoi.Text)) txtslmoi.Text = "";
        }


        private void btnExits_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExits_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn xóa không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)==DialogResult.Yes)
            if (busctdvc.DeleteCTDVC(madon, busctdvc.getIDColor(cbmaucu.Texts), busctdvc.getIDSize(cbSize.Texts)))
            {
                MessageBox.Show("Xóa bill thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Đã quá hạn xóa bill", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
        #region Codes
        public void LoadCombobox()
        {
            // cb old data 
            cbmaucu.DataSource = bussp.hienthiComboboxMauSac();
            cbmaucu.DisplayMember = "tenmau";
            cbmaucu.ValueMember = "mamau";
            cbsizecu.DataSource = bussp.hienthiComboboxSize();
            cbsizecu.DisplayMember = "tensize";
            cbsizecu.ValueMember = "masize";
            // new data 
            cbMausac.DataSource = bussp.hienthiComboboxMauSac();
            cbMausac.DisplayMember = "tenmau";
            cbMausac.ValueMember = "mamau";
            cbSize.DataSource = bussp.hienthiComboboxSize();
            cbSize.DisplayMember = "tensize";
            cbSize.ValueMember = "masize";
            
        }
        #endregion

    }
}
