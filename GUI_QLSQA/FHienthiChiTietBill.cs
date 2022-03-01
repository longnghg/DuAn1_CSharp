using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QLSQA;
namespace GUI_QLSQA
{
    public partial class FHienthiChiTietBill : Form
    {
        int madonmua;
        double dongia;
        int soluong;
        int giamgia;
        double tongtien;
        double vat;
        double thanhtien =0;
        double tongtiencovat;
        BUS_CTSanPham ctsp = new BUS_CTSanPham();
        BUS_HoadonThanhToan bushdtt = new BUS_HoadonThanhToan();
        public FHienthiChiTietBill(int madon)
        {
            InitializeComponent();
            madonmua = madon;
        }

        private void FHienthiChiTietBill_Load(object sender, EventArgs e)
        {
            loadGridview(bushdtt.Show1HDbyID(madonmua));
           
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Orange;
        }
        private void settinggridview()
        {
            dataGridView1.Columns["tensp"].HeaderText = "Tên sản phẩm";
            dataGridView1.Columns["tensize"].HeaderText = "Size";
            dataGridView1.Columns["tenmau"].HeaderText = "Màu";
            dataGridView1.Columns["soluong"].HeaderText = "SL";
            dataGridView1.Columns["dongia"].HeaderText = "Đơn giá";
            dataGridView1.Columns["giamgia"].HeaderText = "Giảm giá";
            dataGridView1.Columns["Tongtien"].HeaderText = "Tổng tiền";
            dataGridView1.Columns["Tongtien"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["Dongia"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["Tongtien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["Dongia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["giamgia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["soluong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        private void loadGridview(DataTable dt)
        {

            dataGridView1.DataSource = dt;
            dataGridView1.Columns["tensp"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["dongia"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Giamgia"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["tongtien"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["MaDonMua"].Visible = false;
            dataGridView1.Columns["ThueVAT"].Visible = false;
            dataGridView1.Columns["TongTienHD"].Visible = false;
            dataGridView1.Columns["SDT"].Visible = false;
            dataGridView1.Columns["MaNV"].Visible = false;
            dataGridView1.Columns["usepoints"].Visible = false;
            dataGridView1.Columns["Ngay"].Visible = false;
            dataGridView1.Columns["gio"].Visible = false;
            vat = float.Parse(dataGridView1.Rows[0].Cells["ThueVAT"].Value.ToString());
            lbmadon.Text = dataGridView1.Rows[0].Cells["MaDonMua"].Value.ToString();
            lbMaNV.Text = dataGridView1.Rows[0].Cells["manv"].Value.ToString();
            lbngay.Text = dataGridView1.Rows[0].Cells["ngay"].Value.ToString(); 
            lbSDT.Text = dataGridView1.Rows[0].Cells["sdt"].Value.ToString();
            lbthoigian.Text = dataGridView1.Rows[0].Cells["gio"].Value.ToString();
            lbVAT.Text = dataGridView1.Rows[0].Cells["ThueVAT"].Value.ToString() + " %";
            for (int i = 0; i < dataGridView1.Rows.Count ; i++)
            {
                dongia = float.Parse(dataGridView1.Rows[i].Cells["Dongia"].Value.ToString());
                soluong = int.Parse(dataGridView1.Rows[i].Cells["soluong"].Value.ToString());
                giamgia = int.Parse(dataGridView1.Rows[i].Cells["giamgia"].Value.ToString());
                tongtien = dongia * soluong;
                double finalprice = tongtien - (tongtien * giamgia) / 100;
                double priceVAT = tongtien + (tongtien * vat) / 100;
                double finalVAT = priceVAT - (priceVAT * giamgia) / 100;
                thanhtien += finalprice;
                tongtiencovat += finalVAT;
            }
            lbTongTien.Text = ctsp.GiaTien(thanhtien.ToString()) + " VNĐ";  // tổng tiền chưa vat

            lbcoVAT.Text = ctsp.GiaTien(tongtiencovat.ToString()) + " VNĐ";   // tổng tiền có vat

            lbgiatrcgiam.Text = ctsp.GiaTien(tongtiencovat.ToString()) + " VNĐ"; // giá trước khi giảm
            if (bool.Parse(dataGridView1.Rows[0].Cells["usepoints"].Value.ToString()))
            {
                lbusepoints.Visible = true;
                lbgiatrcgiam.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lbkogiam.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lbcogiam.Visible = true;
                lbtonggiasaugiam.Visible = true;
                lbtonggiasaugiam.Text =ctsp.GiaTien((tongtiencovat - (tongtiencovat * 10) / 100).ToString()) + " VNĐ";
            }    
            else
            {
                lbusepoints.Visible = false;
            }

            settinggridview();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CrystalReportHDCT r = new CrystalReportHDCT();
            r.SetDataSource(bushdtt.Show1HDbyID(madonmua));
            FReportHDCT rp = new FReportHDCT();
            rp.crystalReportViewer1.ReportSource = r;
            rp.ShowDialog();
        }
    }
    
}


