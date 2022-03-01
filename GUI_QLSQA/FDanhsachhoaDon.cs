using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QLSQA;
using DTO_QLSQA;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace GUI_QLSQA
{
    public partial class FDanhsachhoaDon : Form
    {
        string manv;
        int id=0;
        int idmax;
        int idmin;
        int rowindex;
        int madonmua;
        BUS_Nhanvien nv = new BUS_Nhanvien();
        BUS_HoadonThanhToan bushdtt = new BUS_HoadonThanhToan();
        BUS_Sanpham sp = new BUS_Sanpham();
        public FDanhsachhoaDon()
        {
            InitializeComponent();
            
        }
        #region EVents
        private void FDanhsachhoaDon_Load(object sender, EventArgs e)
        {
            loadGridview(bushdtt.showSimpleBill());
            loadDataTimePicker();
            if (dataGridView1.Rows.Count > 1)
            {
                idmax = bushdtt.idMax_HDM();
                idmin = bushdtt.idMin_HDM();
            }
            btnTim.BackColor = Color.White;
            manv = nv.LayMaNV(FMainnew.mailnv).ToString();
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Orange;
        }

        private void iconDoubleRight_Click_1(object sender, EventArgs e)
        {
            txtMadon.Text = idmax.ToString();
            id = idmax;
            if (btnChitiet.Checked)
            {
                loadGridviewCT(bushdtt.Show1HDbyID(id));

            }
            else
            {
                loadGridview(bushdtt.showSimpleBillbyID(id));
            }
        }

        private void iconRight_Click_1(object sender, EventArgs e)
        {
            // nếu mà không nhập mã hóa đơn
            if (id == 0)
            {
                txtMadon.Text = idmin.ToString();
                id++;
                if (btnChitiet.Checked)
                {
                    loadGridviewCT(bushdtt.Show1HDbyID(id));

                }
                else
                {
                    loadGridview(bushdtt.showSimpleBillbyID(id));
                }
            }
            else
            {
                id++;
                if (id > idmax)
                {
                    txtMadon.Text = idmax.ToString();
                    id = idmax;
                    if (btnChitiet.Checked)
                    {
                        loadGridviewCT(bushdtt.Show1HDbyID(id));

                    }
                    else
                    {
                        loadGridview(bushdtt.showSimpleBillbyID(id));
                    }
                }
                else
                {
                    txtMadon.Text = id.ToString();
                    if (btnChitiet.Checked)
                    {
                        loadGridviewCT(bushdtt.Show1HDbyID(id));

                    }
                    else
                    {
                        loadGridview(bushdtt.showSimpleBillbyID(id));
                    }
                }
            }
        }

        private void iconLeft_Click_1(object sender, EventArgs e)
        {
            if (id == 0)
            {
                id = idmin;
                txtMadon.Text = id.ToString();
                if (btnChitiet.Checked)
                {
                    loadGridviewCT(bushdtt.Show1HDbyID(id));

                }
                else
                {
                    loadGridview(bushdtt.showSimpleBillbyID(id));
                }
            }
            else
            {
                if (id > idmin)
                {
                    id--;
                    txtMadon.Text = id.ToString();
                    if (btnChitiet.Checked)
                    {
                        loadGridviewCT(bushdtt.Show1HDbyID(id));

                    }
                    else
                    {
                        loadGridview(bushdtt.showSimpleBillbyID(id));
                    }
                    if (id < idmin)
                    {
                        txtMadon.Text = idmin.ToString();
                        id = idmin;
                        if (btnChitiet.Checked)
                        {
                            loadGridviewCT(bushdtt.Show1HDbyID(id));

                        }
                        else
                        {
                            loadGridview(bushdtt.showSimpleBillbyID(id));
                        }
                    }

                }
            }
        }

        private void iconDoubleLeft_Click_1(object sender, EventArgs e)
        {

            txtMadon.Text = idmin.ToString();
            id = idmin;
            if (btnChitiet.Checked)
            {
                loadGridviewCT(bushdtt.Show1HDbyID(id));

            }
            else
            {
                loadGridview(bushdtt.showSimpleBillbyID(id));
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            txtMadon.Text = "";
            DateTime fromday = dtpngaybd.Value;
            DateTime today = dtpNgaykt.Value;
            if (btnChitiet.Checked)
            {
                loadGridviewCT(bushdtt.showBuyBillFromDayToDay(fromday, today));
            }
            else
            {
                loadGridview(bushdtt.showSimpleBillbyday(fromday, today));
            }
            btnTim.BackColor = Color.White;
        }

        private void btnTailai_Click(object sender, EventArgs e)
        {
            id = 0;
            loadDataTimePicker();
            btnTim.BackColor = Color.White;
            txtMadon.Text = "";
            if (btnChitiet.Checked)
            {
                loadGridviewCT(bushdtt.showHD());
            }
            else
            {
                loadGridview(bushdtt.showSimpleBill());
            }

        }

        private void dtpNgaykt_ValueChanged(object sender, EventArgs e)
        {
            btnTim.BackColor = Color.DarkOrange;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                rowindex = dataGridView1.CurrentCell.RowIndex;
                if (dataGridView1.Rows.Count > 1)
                {
                    if (dataGridView1.Rows[rowindex].Cells["madonmua"].Value.ToString() != "")
                    {
                        madonmua = int.Parse(dataGridView1.Rows[rowindex].Cells["madonmua"].Value.ToString());
                    }

                }
            }


        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
            {
                FHienthiChiTietBill f = new FHienthiChiTietBill(madonmua);
                f.ShowDialog();
            }

        }

        private void btnChitiet_CheckedChanged(object sender, EventArgs e)
        {
            id = 0;
            if (btnChitiet.Checked)
            {
                loadGridviewCT(bushdtt.showHD());
            }
            else
            {
                loadGridview(bushdtt.showSimpleBill());
            }
            loadDataTimePicker();
            btnTim.BackColor = Color.White;
            txtMadon.Text = "";
        }


        private void btnsearchMD_Click(object sender, EventArgs e)
        {
            if (txtMadon.Text.Trim().Length > 0)
            {
                if (nv.checkisNumber(txtMadon.Text.Trim()))
                {
                    id = int.Parse(txtMadon.Text.Trim());
                    if (btnChitiet.Checked)
                    {
                        loadGridviewCT(bushdtt.showHD());
                        if (int.Parse(txtMadon.Text) > idmax)
                        {
                            txtMadon.Text = idmax.ToString();
                            id = idmax;
                            loadGridviewCT(bushdtt.Show1HDbyID(id));
                        }
                        else
                        {
                            loadGridviewCT(bushdtt.Show1HDbyID(id));
                        }
                    }
                    else
                    {
                        loadGridview(bushdtt.showSimpleBill());
                        if (int.Parse(txtMadon.Text) > idmax)
                        {
                            txtMadon.Text = idmax.ToString();
                            id = idmax;
                            loadGridview(bushdtt.showSimpleBillbyID(id));
                        }
                        else
                        {
                            loadGridview(bushdtt.showSimpleBillbyID(id));
                        }
                    }
                }
                else
                {
                    txtMadon.Text = "";
                }
            }
        }

        private void txtMadon__TextChanged(object sender, EventArgs e)
        {
            if (!nv.checkisNumber(txtMadon.Text.Trim()))
            {
                txtMadon.Text = "";
            }
            if (txtMadon.Text.Trim() == "")
            {
                if (btnChitiet.Checked)
                {
                    loadGridviewCT(bushdtt.showHD());

                }
                else
                {
                    loadGridview(bushdtt.showSimpleBill());
                }
            }
            else
            {
                id = int.Parse(txtMadon.Text);
            }

        }
        #endregion
        #region Codes
        private void loadGridviewCT(DataTable dt)
        {
            dataGridView1.DataSource = default;
            dataGridView1.DataSource = dt;
            this.dataGridView1.Sort(this.dataGridView1.Columns["MaDonMua"], ListSortDirection.Ascending);
            dataGridView1.Columns["ThueVAT"].Visible = false;
            dataGridView1.Columns["TongTienHD"].Visible = false;
            dataGridView1.Columns["Ngay"].Visible = false;
            dataGridView1.Columns["gio"].Visible = false;
            dataGridView1.Columns["usepoints"].Visible = false;
            dataGridView1.Columns["SDt"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["TenSP"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["tongtien"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Madonmua"].HeaderText = "Mã Đơn";
            dataGridView1.Columns["tensp"].HeaderText = "Tên Sản Phẩm";
            dataGridView1.Columns["tensize"].HeaderText = "Size";
            dataGridView1.Columns["tenmau"].HeaderText = "Màu";
            dataGridView1.Columns["soluong"].HeaderText = "SL";
            dataGridView1.Columns["dongia"].HeaderText = "Đơn Giá";
            dataGridView1.Columns["giamgia"].HeaderText = "Giảm Giá";
            dataGridView1.Columns["sdt"].HeaderText = "Số Điện Thoại";
            dataGridView1.Columns["manv"].HeaderText = "Mã NV";
            dataGridView1.Columns["tongtien"].HeaderText = "Tổng Tiền";
            dataGridView1.Columns["tongtien"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["dongia"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["tongtien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["dongia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["soluong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["giamgia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }
        private void loadGridview(DataTable dt)
        {
            dataGridView1.DataSource = default;
            dataGridView1.DataSource = dt;
            this.dataGridView1.Sort(this.dataGridView1.Columns["MaDonMua"], ListSortDirection.Ascending);
            dataGridView1.Columns["SDt"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Tongtien"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["ngay"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["gio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["madonmua"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[0].HeaderText = "Mã Đơn";
            dataGridView1.Columns[1].HeaderText = "Số Điện Thoại";
            dataGridView1.Columns[2].HeaderText = "Tổng Tiền";
            dataGridView1.Columns[3].HeaderText = "Sài điểm";
            dataGridView1.Columns[4].HeaderText = "Ngày Mua";
            dataGridView1.Columns[5].HeaderText = "Giờ Mua";
            dataGridView1.Columns["tongtien"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["tongtien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        private void loadDataTimePicker()
        {
            DateTime today = DateTime.Now;
            dtpngaybd.Value = new DateTime(today.Year, today.Month, 1);
            dtpNgaykt.Value = dtpngaybd.Value.AddMonths(1).AddDays(-1);
        }
        #endregion
    }
}
