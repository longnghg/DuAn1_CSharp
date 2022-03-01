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
using FontAwesome.Sharp;

namespace GUI_QLSQA
{
    public partial class FChiTietSP : Form
    {
        // Thuộc tính
        private string masp;
        private int masize;
        private bool displayImage;
        private IconButton currentBtnSize;
        private IconButton currentBtnColor;
        public string Masp { get => masp; private set => masp = value; }
        public bool DisplayImage { get => displayImage; set => displayImage = value; }
        public int Masize { get => masize; set => masize = value; }

        Bitmap bm1;
        Bitmap bm2;
        string ForeImg;
        string BackImg;

        BUS_CTSanPham busctsp = new BUS_CTSanPham();
        BUS_Sanpham bussp = new BUS_Sanpham();
        public FChiTietSP(string masp)
        {
            InitializeComponent();
            Masp = masp;
        }
        private void LoadCTSP()
        {
            
            int colorDistance = 468;
            int sizeDistance = 468;
            List<DTO_CTSanPham> ListSize = busctsp.ShowSizeofItem(Masp);
            foreach (DTO_CTSanPham item in ListSize)
            {
                IconButton btnsize = new IconButton();
                btnsize.Click += Btnsize_Click;
                btnsize.Tag = item;
                btnsize.Size = new System.Drawing.Size(40, 30);
                btnsize.Name = item.ToString();
                if (item.Size == 1)
                    btnsize.Text = "S";
                else if (item.Size == 2)
                    btnsize.Text = "M";
                else if (item.Size == 3)
                    btnsize.Text = "L";
                else
                    btnsize.Text = "XL";
                btnsize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btnsize.Location = new System.Drawing.Point(sizeDistance, 300);
                btnsize.Size = new System.Drawing.Size(40, 30);
                this.Controls.Add(btnsize);
                sizeDistance += 46;
            }
            List<DTO_CTSanPham> Listmau =  busctsp.ShowColorofImage(Masp);
            foreach (DTO_CTSanPham item in Listmau)
            {
                IconButton btnColor = new IconButton();
                btnColor.Size = new System.Drawing.Size(40, 30);
                btnColor.Text = "";
                if (item.MaMau == 1)
                    btnColor.BackColor = Color.Black;
                else if (item.MaMau == 2)
                    btnColor.BackColor = Color.White;
                else if (item.MaMau == 3)
                    btnColor.BackColor = Color.Yellow;
                else if (item.MaMau == 4)
                    btnColor.BackColor = Color.Red;
                else if (item.MaMau == 5)
                    btnColor.BackColor = Color.Gray;
                else if (item.MaMau == 6)
                    btnColor.BackColor = Color.Violet;
                else if (item.MaMau == 7)
                    btnColor.BackColor = Color.Pink;
                else if (item.MaMau == 8)
                    btnColor.BackColor = Color.Orange;
                else if (item.MaMau == 9)
                    btnColor.BackColor = Color.Navy;
                else
                {
                    btnColor.IconChar = FontAwesome.Sharp.IconChar.Plus;
                    btnColor.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(172)))), ((int)(((byte)(75)))));
                    btnColor.IconFont = FontAwesome.Sharp.IconFont.Auto;
                    btnColor.IconSize = 30;
                    btnColor.Padding = new System.Windows.Forms.Padding(0, 2, 3, 0);
                    btnColor.Rotation = 45D;
                }
                btnColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btnColor.Location = new System.Drawing.Point(colorDistance,377);
                btnColor.Size = new System.Drawing.Size(40, 30);
                this.Controls.Add(btnColor);
                colorDistance += 46;
            }
            List<DTO_Sanpham> sp = bussp.ShowNameAndPriceItem(masp);
            lbMaSP.Text = Masp;
            lbName.Text = sp[0].TenSP;
            lbgiamoi.Text = busctsp.GiaTien(sp[0].DongiaBan.ToString()) + " VNĐ";
            if (sp[0].GiamGia > 0)
            {
                lbgiacu.Visible = true;
            }
            else
                lbgiacu.Visible = false;
            ForeImg = sp[0].HinhAnhtrc;
            BackImg = sp[0].HinhAnhsau;
            LoadImages(true);
        }
        #region Events
        private void Btnsize_Click(object sender, EventArgs e)
        {
            DisableButton();
            currentBtnSize = (IconButton)sender;
            currentBtnSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            currentBtnSize.FlatAppearance.BorderSize = 2;
            currentBtnSize.FlatAppearance.BorderColor = Color.FromArgb(255, 172, 75);

            foreach (Button item in this.Controls.OfType<Button>().ToList())
            {
                if (String.IsNullOrEmpty(item.Name))
                {
                    this.Controls.Remove(item);
                    item.Dispose();
                }
            }
            int colorDistance = 468;
            Masize = ((sender as IconButton).Tag as DTO_CTSanPham).Size;
            List<DTO_CTSanPham> ctsp = busctsp.ShowColorBySize(masp, masize);
            foreach (DTO_CTSanPham item in ctsp)
            {
                IconButton btnColor = new IconButton();
                btnColor.Click += BtnColor_Click;
                btnColor.Tag = item;
                btnColor.Size = new System.Drawing.Size(40, 30);
                btnColor.Text = "";
                if (item.MaMau == 1)
                    btnColor.BackColor = Color.Black;
                else if (item.MaMau == 2)
                    btnColor.BackColor = Color.White;
                else if (item.MaMau == 3)
                    btnColor.BackColor = Color.Yellow;
                else if (item.MaMau == 4)
                    btnColor.BackColor = Color.Red;
                else if (item.MaMau == 5)
                    btnColor.BackColor = Color.Gray;
                else if (item.MaMau == 6)
                    btnColor.BackColor = Color.Violet;
                else if (item.MaMau == 7)
                    btnColor.BackColor = Color.Pink;
                else if (item.MaMau == 8)
                    btnColor.BackColor = Color.Orange;
                else if (item.MaMau == 9)
                    btnColor.BackColor = Color.Navy;
                else
                {
                    btnColor.IconChar = FontAwesome.Sharp.IconChar.Plus;
                    btnColor.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(172)))), ((int)(((byte)(75)))));
                    btnColor.IconFont = FontAwesome.Sharp.IconFont.Auto;
                    btnColor.IconSize = 30;
                    btnColor.Padding = new System.Windows.Forms.Padding(0, 2, 3, 0);
                    btnColor.Rotation = 45D;
                }
                btnColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btnColor.Location = new System.Drawing.Point(colorDistance, 377);
                btnColor.Size = new System.Drawing.Size(40, 30);
                this.Controls.Add(btnColor);
                colorDistance += 46;
            }

        }

        private void BtnColor_Click(object sender, EventArgs e)
        {
            DisableButtonColor();
            currentBtnColor = (IconButton)sender;
            currentBtnColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            currentBtnColor.FlatAppearance.BorderSize = 2;
            currentBtnColor.FlatAppearance.BorderColor = Color.FromArgb(255, 172, 75);
            int mamau = ((sender as IconButton).Tag as DTO_CTSanPham).MaMau;
            List<DTO_CTSanPham> list = busctsp.LoadQuantityBySizeAndColor(masp, masize, mamau);
            if (list[0].SoLuong > 0)
            {
                lbSoluong.Visible = true;
                lbSoluong.Text = list[0].SoLuong.ToString();
                btnTrangThai.Text = "Còn hàng";
                btnTrangThai.BackColor = Color.FromArgb(255, 172, 75);
            }
            else if (list[0].SoLuong <= 0)
            {
                lbSoluong.Visible = true;
                lbSoluong.Text = list[0].SoLuong.ToString();
                btnTrangThai.Text = "Hết hàng";
                btnTrangThai.BackColor = Color.Moccasin;
            }
            else
            {
                MessageBox.Show("Mời bạn chọn size trước");
            }
        }

        private void FChiTietSP_Load(object sender, EventArgs e)
        {
            LoadCTSP();
        }
        private void pbAnhtrc_Click(object sender, EventArgs e)
        {
            LoadImages(true);
        }

        private void pbAnhsau_Click(object sender, EventArgs e)
        {
            LoadImages(false);
        }

        private void btnExits_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        #region Codes
        private void DisableButton()
        {
            DisableButtonColor();
            if (currentBtnSize != null)
            {
                currentBtnSize.FlatAppearance.BorderSize = 1;
                currentBtnSize.FlatAppearance.BorderColor = Color.Black;

            }
        }
        private void DisableButtonColor()
        {
            lbSoluong.Text = "";
            if (currentBtnColor != null)
            {
                currentBtnColor.FlatAppearance.BorderSize = 1;
                currentBtnColor.FlatAppearance.BorderColor = Color.Black;

            }
        }
        private void LoadImages(bool img)
        {

            if (img)
            {
                bm1 = new Bitmap(Application.StartupPath + "\\Resources\\" + ForeImg);
                pbAnhtrc.Image = bm1;
                pbDisplay.Image = bm1;
                bm2 = new Bitmap(Application.StartupPath + "\\Resources\\" + BackImg);
                pbAnhsau.Image = bm2;
                btnAnhtrc.Visible = true;
                btnAnhSau.Visible = false;
                pbAnhsau.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                pbAnhtrc.BorderStyle = System.Windows.Forms.BorderStyle.None;

            }
            else
            {
                bm1 = new Bitmap(Application.StartupPath + "\\Resources\\" + ForeImg);
                pbAnhtrc.Image = bm1;
                bm2 = new Bitmap(Application.StartupPath + "\\Resources\\" + BackImg);
                pbAnhsau.Image = bm2;
                pbDisplay.Image = bm2;
                btnAnhSau.Visible = true;
                btnAnhtrc.Visible = false;
                pbAnhtrc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                pbAnhsau.BorderStyle = System.Windows.Forms.BorderStyle.None;
            }
        }
        #endregion
    }
}
