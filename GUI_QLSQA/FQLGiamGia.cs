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
    public partial class FQLGiamGia : Form
    {
        BUS_Sanpham bussp = new BUS_Sanpham();
        BUS_Nhanvien nv = new BUS_Nhanvien();
        int activebtn; // = 0 no sale , = 1 sale, = 2 all
        public FQLGiamGia()
        {
            InitializeComponent();
        }

        private void FQLGiamGia_Load(object sender, EventArgs e)
        {
            LoadGridView_All();
            AutoComplete(bussp.ListSP());
            txtTim.GotFocus += TxtTim_GotFocus;
            activebtn = 2;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Orange;
        }
        private void TxtTim_GotFocus(object sender, EventArgs e)
        {
            txtTim.Text = "";
            txtTim.Focus();
            txtTim.ForeColor = Color.Black;
            btnTim.Enabled = true;
        }

        private void AutoComplete(List<DTO_Sanpham> list)
        {
            List<DTO_Sanpham> Listsp = list;
            AutoCompleteStringCollection autocptimsp = new AutoCompleteStringCollection();
            txtTim.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtTim.AutoCompleteSource = AutoCompleteSource.CustomSource;
            foreach (DTO_Sanpham item in Listsp)
            {
                autocptimsp.Add(item.MaSP);
            }
            foreach (DTO_Sanpham item in Listsp)
            {
                autocptimsp.Add(item.TenSP);
            }
            txtTim.AutoCompleteCustomSource = autocptimsp;
        }
        private void settingGridview()
        {
            dataGridView1.Columns[0].HeaderText = "Mã sản phẩm";
            dataGridView1.Columns[1].HeaderText = "Tên sản phẩm";
            dataGridView1.Columns[2].HeaderText = "Giá Bán";
            dataGridView1.Columns[4].HeaderText = "Giá Sau Khi Giảm";
            dataGridView1.Columns[3].HeaderText = "Giảm Giá";
            dataGridView1.Columns[2].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns[4].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        private void ResetValue()
        {
            txtGiamGia.Enabled = false;
            txtGiamGia.Text = "";
            txtMasp.Text = "";
            txtTensp.Text = "";
            txtTim.ForeColor = Color.LightGray;
            txtTim.Text = "--Nhập tên hoặc mã SP--";
            btnLuu.Visible = false;
            btnAllSaleMode.Checked = false;
        }
        private void LoadGridView_NoSale()
        {
            DataSet dataset = bussp.DSSPKhongGiamGia();
            dataGridView1.DataSource = dataset.Tables[0];
            btnResetAllSales.Visible = false;
            btnKhongSale.BackColor = Color.DarkGoldenrod;
            btnSale.BackColor = Color.Orange;
            btnTatCa.BackColor = Color.Orange;
            lbAllSaleMode.Visible = true;
            btnAllSaleMode.Visible = true;
            settingGridview();
        }
        private void btnTatCa_Click(object sender, EventArgs e)
        {
            LoadGridView_All();
            AutoComplete(bussp.ListSP());
            ResetValue();
            activebtn = 2;
        }
        private void LoadGridView_All()
        {
            DataSet dataset = bussp.DSSPKhongGiamGia();
            dataGridView1.DataSource = dataset.Tables[1];
            btnResetAllSales.Visible = false;
            btnKhongSale.BackColor = Color.Orange;
            btnSale.BackColor = Color.Orange;
            btnTatCa.BackColor = Color.DarkGoldenrod;
            lbAllSaleMode.Visible = false;
            btnAllSaleMode.Visible = false;
            btnResetAllSales.Visible = true;
            settingGridview();
        }
        private void LoadGridView_Sale()
        {
            dataGridView1.DataSource = bussp.DSSPDangGiamGia();
            btnResetAllSales.Visible = true;
            btnSale.BackColor = Color.DarkGoldenrod;
            btnKhongSale.BackColor = Color.Orange;
            btnTatCa.BackColor = Color.Orange;
            lbAllSaleMode.Visible = false;
            btnAllSaleMode.Visible = false;
            settingGridview();
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            LoadGridView_Sale();
            AutoComplete(bussp.ListSPSales());
            ResetValue();
            activebtn = 1;
        }

        private void btnKhongSale_Click(object sender, EventArgs e)
        {
            LoadGridView_NoSale();
            AutoComplete(bussp.ListSPnoSales());
            ResetValue();
            activebtn = 0;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int RowIndex = dataGridView1.CurrentCell.RowIndex;
            if (dataGridView1.Rows[RowIndex].Cells["masp"].Value.ToString() != "")
            {
                txtMasp.Text=dataGridView1.Rows[RowIndex].Cells["masp"].Value.ToString();
                txtTensp.Text = dataGridView1.Rows[RowIndex].Cells["tensp"].Value.ToString();
                txtGiamGia.Text = dataGridView1.Rows[RowIndex].Cells["giamgia"].Value.ToString();
                btnLuu.Visible = true;
                txtGiamGia.Enabled = true;

            }
            
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
           
            if(txtGiamGia.Text.Trim().Length > 0)
            {
                if (btnAllSaleMode.Checked)
                {
                    if (MessageBox.Show("Giảm giá tất cả sản phẩm thành " +txtGiamGia.Text +"% ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (int.Parse(txtGiamGia.Text.Trim()) > 0)
                        {
                            if (bussp.UpdateSalesAllProduct(int.Parse(txtGiamGia.Text)))
                            {
                                MessageBox.Show("Thao tác thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Thao tác không thành công", "Báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        LoadGridView_All();
                        ResetValue();
                    }
                }
                else
                {
                    if (MessageBox.Show("Giảm giá sản phẩm: " + txtTensp.Text + "\n thành " + txtGiamGia.Text + "% ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (bussp.UpdateSales(int.Parse(txtGiamGia.Text.Trim()), txtMasp.Text))
                        {
                            MessageBox.Show("Thao tác thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Thao tác không thành công", "Báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        LoadGridView_All();
                        ResetValue();
                    }
                }
               
            }
          
            
        }


        private void txtGiamGia_TextChanged(object sender, EventArgs e)
        {
            if (!nv.checkisNumber(txtGiamGia.Text)) txtGiamGia.Text = "0";
        }

        private void btnResetAllSales_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count>1)
            {
                if (MessageBox.Show("Bạn muốn hủy sale tất cả sản phẩm ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (bussp.UpdateSalesAllProduct(0))
                    {
                        MessageBox.Show("Thao tác thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadGridView_All();
                    }
                    else
                    {
                        MessageBox.Show("Thao tác không thành công", "Báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }
            }
            else
            {
                MessageBox.Show("Hiện tại không có sản phẩm sales", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnAllSaleMode_MouseClick(object sender, MouseEventArgs e)
        {
            if (!btnAllSaleMode.Checked)
            {
                if (MessageBox.Show("Bạn muốn bật chế độ sale tất cả sản phẩm ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    btnAllSaleMode.Checked = true;
                }
            }
            else
            {
                btnAllSaleMode.Checked = false;
                MessageBox.Show("Đã tắt sale tất cả sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void btnAllSaleMode_CheckedChanged(object sender, EventArgs e)
        {
            if (btnAllSaleMode.Checked)
            {
                btnLuu.Visible = true;
                txtGiamGia.Enabled = true;
            }
            else
            {
                ResetValue();
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if(activebtn == 0)
            {
                dataGridView1.DataSource = bussp.FindItemNoSale(txtTim.Text.Trim());
            }else if (activebtn == 1)
            {
                dataGridView1.DataSource = bussp.FindItemSale(txtTim.Text.Trim());
            }
            else
            {
                dataGridView1.DataSource = bussp.DSSPAfterFindForSale(txtTim.Text.Trim());
            }
            if (dataGridView1.Rows.Count > 1)
            {
                settingGridview();
                MessageBox.Show(dataGridView1.Rows.Count.ToString());
            }
            else
            {
                MessageBox.Show("Không tìm thấy", "Thông báo ",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (activebtn == 0)
                {
                    LoadGridView_NoSale();
                }
                else if (activebtn == 1)
                {
                    LoadGridView_Sale();
                }
                else
                {
                    LoadGridView_All();
                }
            }
        }

        private void txtTim_Click(object sender, EventArgs e)
        {
            txtTim.Text = "";
            txtTim.Focus();
            txtTim.ForeColor = Color.Black;
            btnTim.Enabled = true;
        }

        private void txtTim_Leave(object sender, EventArgs e)
        {
            if (txtTim.Text.Trim().Length == 0)
            {
                txtTim.ForeColor = Color.Gray;
                txtTim.Text = "--Nhập tên hoặc mã SP--";
                btnTim.Enabled = false;
            }
        }

        private void btnTailai_Click(object sender, EventArgs e)
        {
            if (activebtn == 0) LoadGridView_NoSale();
            else if (activebtn == 1) LoadGridView_Sale();
            else LoadGridView_All();
        }
    }
}
