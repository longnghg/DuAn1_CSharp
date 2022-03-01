using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QLSQA;
using DTO_QLSQA;
namespace GUI_QLSQA
{
    public partial class FDSSanpham : Form
    {
        private static FDSSanpham instance;
        public static FDSSanpham Instance
        {
            get { return instance = new FDSSanpham();  }
            private set { FDSSanpham.instance = value; }
        }
        BUS_Sanpham bussp = new BUS_Sanpham();
        List<DTO_CTSanPham> Listctsp = new List<DTO_CTSanPham>();
        BUS_CTSanPham busctsp = new BUS_CTSanPham();
        string checkurlImage; //kiểm tra hình khi cập nhật
        string fileName;// tên file
        string filesavePath; // url Store image
        string fileAddress; // url load images
        private Label currentLb;
        private static int i = 0;

        private void ActiveLabel(object senderlb, Color color)
        {
            if (senderlb != null)
            {
                DisableLabel();
                lbtatca.ForeColor = Color.Black;
                currentLb = (Label)senderlb;
                currentLb.ForeColor = color;
            }
        }
        private void resetValue()
        {
            foreach (Label item in this.Controls.OfType<Label>().ToList())
            {
                item.ForeColor = Color.Black;
            }
            lbtatca.ForeColor = Color.DarkRed;
            Ao.ForeColor = Color.Black;
            Aotaydai.ForeColor = Color.Black;
            Aotee.ForeColor = Color.Black;
            quan.ForeColor = Color.Black;
            quandai.ForeColor = Color.Black;
            quanshort.ForeColor = Color.Black;
            vay.ForeColor = Color.Black;
            hoodie.ForeColor = Color.Black;
        }
        private void DeleteImage()
        {
            foreach (Panel item in panelDesktop.Controls.OfType<Panel>().ToList())
            {
                if (item.Name == "pn")
                {
                    panelDesktop.Controls.Remove(item);
                    item.Dispose();
                }
            }
        }
        private void DisableLabel()
        {
            if (currentLb != null)
            {
                currentLb.ForeColor = Color.Black;
            }
        }
        private void lbAo_Click(object sender, EventArgs e)
        {
            DeleteImage();
            ActiveLabel(sender, Color.DarkRed);
            loadDS(bussp.ShowListImageAo());

        }
        private void lbQuan_Click(object sender, EventArgs e)
        {
            DeleteImage();
            ActiveLabel(sender, Color.DarkRed);
            loadDS(bussp.ShowListImageQuan());
        }

        private void lbVest_Click(object sender, EventArgs e)
        {
            DeleteImage();
            ActiveLabel(sender, Color.DarkRed);
            loadDS(bussp.ShowListImageQDam());
        }

        private void lbtatca_Click(object sender, EventArgs e)
        {
            DeleteImage();
            ActiveLabel(sender, Color.DarkRed);
            loadDS(bussp.LoadShowListImage());
        }
        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            resetValue();
            DeleteImage();
            loadDS(bussp.LoadShowListImage());
        }
        private void Ao_Click(object sender, EventArgs e)
        {
            DeleteImage();
            ActiveLabel(sender, Color.DarkRed);
            loadDS(bussp.ShowListImageAo());
        }

        private void Aotee_Click(object sender, EventArgs e)
        {
            DeleteImage();
            ActiveLabel(sender, Color.DarkRed);
            loadDS(bussp.ShowListImageAT());
        }

        private void Aotaydai_Click(object sender, EventArgs e)
        {
            DeleteImage();
            ActiveLabel(sender, Color.DarkRed);
            loadDS(bussp.ShowListImageATD());
        }

        private void hoodie_Click(object sender, EventArgs e)
        {
            DeleteImage();
            ActiveLabel(sender, Color.DarkRed);
            loadDS(bussp.ShowListImageHDTW());
        }

        private void quan_Click(object sender, EventArgs e)
        {
            DeleteImage();
            ActiveLabel(sender, Color.DarkRed);
            loadDS(bussp.ShowListImageQuan());
        }

        private void quanshort_Click(object sender, EventArgs e)
        {
            DeleteImage();
            ActiveLabel(sender, Color.DarkRed);
            loadDS(bussp.ShowListImageQS());
        }

        private void quandai_Click(object sender, EventArgs e)
        {
            DeleteImage();
            ActiveLabel(sender, Color.DarkRed);
            loadDS(bussp.ShowListImageQD());
        }

        private void vay_Click(object sender, EventArgs e)
        {
            DeleteImage();
            ActiveLabel(sender, Color.DarkRed);
            loadDS(bussp.ShowListImageQV());
        }
        public FDSSanpham()
        {
            InitializeComponent();  
    }
        private void btnExits_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        // biến tạo panel chứa ảnh sản phẩm

        // biến tạo picturebox chứa ảnh
        private int stt = 0;
        // biến tạo label giá iền trong ảnh
        private int sttlabel = 0;
        public void loadDS(List<DTO_Sanpham> list)
        {

            List<DTO_Sanpham> listSP = list;
            foreach (DTO_Sanpham sp in listSP)
            {
                Panel p = new Panel();
                p.Name = "pn";
                p.BackColor = Color.White;
                p.Size = new System.Drawing.Size(400, 415);

                panelDesktop.Controls.Add(p);
                // add Right border
                Panel prb = new Panel();
                prb.Dock = DockStyle.Right;
                prb.Size = new System.Drawing.Size(100, 350);
                prb.BackColor = Color.White;
                // add top border
                Panel ptb = new Panel();
                prb.Dock = DockStyle.Top;
                prb.Size = new System.Drawing.Size(100, 30);
                prb.BackColor = Color.White;
                // label giá 
                Label lb = new Label();
                lb.BackColor = Color.White;
                lb.Name = "lbgia" + sp.MaSP;
                lb.Dock = DockStyle.Top;
                lb.Text = busctsp.GiaTien(sp.DongiaBan.ToString()) + " VNĐ";
                lb.Padding = new System.Windows.Forms.Padding(182 - ((lb.Text.Trim().Length - 1) * 5), 5, 0, 0);
                lb.Font = new System.Drawing.Font("Segoe UI", 16.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lb.Size = new System.Drawing.Size(82, 40);
                lb.ForeColor = Color.Black;
                // label tên sp
                Label lbTen = new Label();
                lbTen.BackColor = Color.White;
                lbTen.Dock = DockStyle.Top;
                lbTen.Text = sp.TenSP;
                lbTen.Padding = new System.Windows.Forms.Padding(185 - ((lbTen.Text.Trim().Length - 1) * 5), 0, 0, 5);
                lbTen.BackColor = Color.White;
                lbTen.Size = new System.Drawing.Size(150, 35);
                lbTen.Font = new System.Drawing.Font("Segoe UI", 16.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lbTen.ForeColor = Color.Black;
                // picture box ảnh sp
                PictureBox pic = new PictureBox();
                pic.Dock = DockStyle.Top;
                pic.Size = new System.Drawing.Size(240, 285);
                pic.Click += Pic_Click;
                pic.MouseHover += Pic_MouseHover;
                pic.MouseLeave += Pic_MouseLeave;
                pic.Tag = sp;
                pic.BackColor = Color.White;
                Bitmap bm = new Bitmap(Application.StartupPath + "\\Resources\\" + sp.HinhAnhtrc);
                pic.Image = bm;
                pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                stt++;
                // add controls
                p.Controls.Add(lb);
                p.Controls.Add(lbTen);
                p.Controls.Add(pic);
                //p.Controls.Add(bp);
                p.Controls.Add(prb);
                p.Controls.Add(ptb);
            }
        }
        private void FDSSanpham_Load(object sender, EventArgs e)
        {
            resetValue();
            loadDS(bussp.LoadShowListImage());
            WindowState = FormWindowState.Maximized;

        }

        private void Pic_MouseLeave(object sender, EventArgs e)
        {
           (sender as PictureBox).BackColor = Color.White;
        }

        private void Pic_MouseHover(object sender, EventArgs e)
        {
            
            (sender as PictureBox).BackColor = Color.GhostWhite;
        }

        private void Pic_Click(object sender, EventArgs e)
        {
            string masp = ((sender as PictureBox).Tag as DTO_Sanpham).MaSP;
            FChiTietSP f = new FChiTietSP(masp);
            f.ShowDialog();
        }

      
    }
}
