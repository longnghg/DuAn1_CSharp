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
namespace GUI_QLSQA
{
    public partial class FDoanhThu : Form
    {
        BUS_Doanhthu busdt = new BUS_Doanhthu();
        BUS_CTSanPham busctsp = new BUS_CTSanPham();
        List<DTO_Doanhthu> listdt = new List<DTO_Doanhthu>();
        int curyear;

        public FDoanhThu()
        {
            InitializeComponent();
            DateTime today = DateTime.Now;
            curyear = today.Year;
        }
        private void FDoanhThu_Load(object sender, EventArgs e)
        {
            cbNam.DataSource = busdt.getlistYear();
            cbNam.DisplayMember = "Nam";
            cbNam.ValueMember = "Nam";
        }
        private void drawChart(int nam)
        {
            List<DTO_Chart> chartlist = new List<DTO_Chart>();
            int curmonth;
            int stt = 0;
            int vitri = 215;
            double Tongtien = 0;
            DateTime today = DateTime.Now;
            curmonth = today.Month;
            for (int i = 1; i < 13; i++)
            {
                DTO_Chart charitem = new DTO_Chart();
                charitem.Thang = i;
                charitem.Nam = nam;
                listdt = busdt.getChart(i, nam);
                foreach (DTO_Doanhthu item in listdt)
                {
                    Tongtien += item.Tongtien;
                }
                charitem.Tongtien = Tongtien;
                chartlist.Add(charitem);
                Tongtien = 0;
            }
            if (chartlist.Count > 0)
            {
                foreach (DTO_Chart item in chartlist)
                {
                    int y = 655;
                    int chieucaobtn = Convert.ToInt32(item.Tongtien / 500000);
                    // chiều cao tối đa
                    if (chieucaobtn > 500)
                    {
                        chieucaobtn = 500;
                    }
                    // chiều cao tối thiểu
                    if (chieucaobtn > 0 && chieucaobtn < 20)
                    {
                        chieucaobtn = 20;
                    }
                    Button btn = new Button();
                    btn.Click += Btn_Click;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Tag = item;
                    btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    btn.Name = "C" + item.Thang;
                    if (item.Thang == curmonth)
                    {
                        btn.BackColor = System.Drawing.Color.DarkRed;
                    }
                    else
                    {
                        btn.BackColor = System.Drawing.Color.Orange;
                    }
                    btn.Location = new System.Drawing.Point(vitri, y - chieucaobtn);
                    btn.Size = new System.Drawing.Size(80, chieucaobtn);
                    ToolTip tip = new ToolTip();
                    tip.SetToolTip(btn, "Tổng doanh thu tháng " + item.Thang + " năm " + item.Nam + ": " + busctsp.GiaTien(item.Tongtien.ToString()) + " VNĐ");
                    tip.IsBalloon = true;
                    tip.AutoPopDelay = 50000;
                    tip.BackColor = Color.DarkOrange;
                    this.Controls.Add(btn);
                    btn.BringToFront();
                    vitri += 90;
                }
            }
           
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            int thang = ((sender as Button).Tag as DTO_Chart).Thang;
            int nam = ((sender as Button).Tag as DTO_Chart).Nam;
            FThongKeCT f = new FThongKeCT(thang, nam);
            f.ShowDialog();
        }

        private void cbNam_OnSelectedValueChanged(object sender, EventArgs e)
        {
            // khi  có bill mới thực hiện
            if (cbNam.Texts !="")
            {
                if (cbNam.SelectedValue.ToString() != "System.Data.DataRowView")
                {
                    curyear = int.Parse(cbNam.SelectedValue.ToString());
                    foreach (Button item in this.Controls.OfType<Button>().ToList())
                    {
                        if (item.Name.Contains("C"))
                        {
                            this.Controls.Remove(item);
                            item.Dispose();
                        }
                    }
                    drawChart(curyear);
                }
            }
        }
    }
}
