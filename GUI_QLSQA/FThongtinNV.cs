using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO_QLSQA;
using BUS_QLSQA;
using System.IO;

namespace GUI_QLSQA
{
    public partial class FThongtinNV : Form
    {
        BUS_Nhanvien busnhanvien = new BUS_Nhanvien();
        string emailnv;
        string manv;
        string hoten;
        string diachi;
        string sdt;
        bool gioitinh;
        string hinhanh;
        string fileName;// tên file
        string filesavePath; // url Store image
        string fileAddress; // url load images
        string sourceDir;
        string backupDir;
        public FThongtinNV(string email)
        {
            InitializeComponent();
            emailnv = email;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            txtDiachi.ReadOnly = false;
            txtHoTen.ReadOnly = false;
            txtSDT.ReadOnly = false;
            btnLuu.Visible = true;
            btnHuy.Visible = true;
            btnAnh.Enabled = true;
            rdbNam.Enabled = true;
            rdbNu.Enabled = true;
        }

        private void btnDmk_Click(object sender, EventArgs e)
        {
            FDoimatkhau f = new FDoimatkhau();
            f.ShowDialog();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            bool checkdata;
            if (!busnhanvien.checkData(new string[] { txtDiachi.Text.Trim(), txtHoTen.Text.Trim(), txtSDT.Text.Trim() }))
                checkdata = false;
            else if (busnhanvien.checkcontainNumber(txtHoTen.Text) || busnhanvien.hasSpecialChar(txtHoTen.Text))
                checkdata = false;
            else if (busnhanvien.hasSpecialCharDiachi(txtDiachi.Text))
                checkdata = false;
            else if (!busnhanvien.checkisNumber(txtSDT.Text))
                checkdata = false;
            else
                checkdata = true;
            if (checkdata)
            {
                if (txtHoTen.Text.Trim().Length < 5 || txtHoTen.Text.Trim().Length > 30)
                {
                    MessageBox.Show("Họ tên chỉ chứa 5 - 30 ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtHoTen.Focus();
                }
                else if (txtDiachi.Text.Trim().Length < 4 || txtDiachi.Text.Trim().Length > 50)
                {
                    MessageBox.Show("Địa chỉ chứa 4 - 50 ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDiachi.Focus();
                }
                else if (txtSDT.Text.Trim().Length != 10)
                {
                    MessageBox.Show("Số ĐT chỉ chứa 10 ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSDT.Focus();
                }
                else
                {
                   if (rdbNam.Checked) gioitinh = false;
                   else gioitinh = true;
                    DTO_Nhanvien nv = new DTO_Nhanvien();
                    nv.DiaChi = txtDiachi.Text.Trim();
                    nv.Email = txtEmail.Text.Trim();
                    nv.Gioitinh = gioitinh;
                    nv.HinhAnh = hinhanh;
                    nv.HoTen = txtHoTen.Text.Trim();
                    nv.SDT = txtSDT.Text.Trim();
                    nv.Gioitinh = gioitinh;
                    
                    if (busnhanvien.ThaydoiTT(nv))
                    {
                        if(sourceDir!= null)
                        {
                            busnhanvien.LuuAnh(fileName, sourceDir, backupDir);
                        }
                        MessageBox.Show("Thông tin đã được thay đổi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadForm();
                    }
                    else
                    {
                        MessageBox.Show("Thay đổi thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                    
                }
            }
            else
            {
                MessageBox.Show("Dữ liệu không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FThongtinNV_Load(object sender, EventArgs e)
        {
            LoadForm();
        }
        public void LoadForm()
        {
            List<DTO_Nhanvien> nv = busnhanvien.ThongtincuaNVDangNhap(emailnv);
            txtManv.Text = nv[0].MaNV;
            txtDiachi.Text = nv[0].DiaChi;
            txtEmail.Text = nv[0].Email;
            txtHoTen.Text = nv[0].HoTen;
            txtSDT.Text = nv[0].SDT;
            if (nv[0].Gioitinh)
                rdbNu.Checked = true;
            else
            {
                rdbNam.Checked = true;
            }
            if (nv[0].VaiTro)
                lbChucvu.Text = "Chức vụ: Quản lý";
            else
                lbChucvu.Text = "Chức vụ: Nhân viên";
            manv = nv[0].MaNV;
            diachi = nv[0].DiaChi;
            hoten = nv[0].HoTen;
            sdt = nv[0].SDT; ;
            gioitinh = nv[0].Gioitinh;
            hinhanh = nv[0].HinhAnh;
            pbAnh.Image = Image.FromFile(Application.StartupPath + "\\Resources\\" + hinhanh);
            txtDiachi.ReadOnly = true;
            txtHoTen.ReadOnly = true;
            txtSDT.ReadOnly = true;
            btnLuu.Visible = false;
            btnAnh.Enabled = false;
            btnHuy.Visible = false;
            rdbNam.Enabled = false;
            rdbNu.Enabled = false;
        }

        private void btnAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|JPEG Image(*.jfif)|*.jfif|PNG(*.png)|*.png|All files(*.*)|*.*";
            dlgOpen.FilterIndex = 3;
            dlgOpen.Title = "Chọn ảnh nhân viên";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                fileAddress = dlgOpen.FileName;
                pbAnh.Image = Image.FromFile(fileAddress);
                fileName = Path.GetFileName(dlgOpen.FileName);
                string saveDirectory = Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);
                filesavePath = saveDirectory + fileName;
                hinhanh = fileName;
            }
            string FolderPathContainsImg = "";
            if (fileAddress != null)
            {
                string[] spFile = fileAddress.Split('\\');
                foreach (string item in spFile)
                {
                    if (!item.Contains(spFile[spFile.Length - 1]))
                    {
                        FolderPathContainsImg += item + "\\";
                    }
                }
                sourceDir = FolderPathContainsImg;
                backupDir = Application.StartupPath + @"\Resources";
                string[] picList = Directory.GetFiles(sourceDir, fileName);
            }

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            LoadForm();
            txtDiachi.ReadOnly = true;
            txtHoTen.ReadOnly = true;
            txtSDT.ReadOnly = true;
            btnLuu.Visible = false;
            btnHuy.Visible = false;
            rdbNam.Enabled = false;
            rdbNu.Enabled = false;
        }
    }
}
