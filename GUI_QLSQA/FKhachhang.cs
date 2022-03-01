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
    public partial class FKhachhang : Form
    {
        BUS_KhachHang buskh = new BUS_KhachHang();
        BUS_Nhanvien busnv = new BUS_Nhanvien();
        int active = 1; // 0  chế độ xem danh sách những nv tồn tại, 1 là chế độ xem  danh sách nv bị xóa
        public FKhachhang()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (busnv.checkData(new string[]{ txtSDT.Text.Trim() , txtTenKH.Text.Trim() }))
            {
                if (txtTenKH.Text.Trim().Length < 5 || txtTenKH.Text.Trim().Length > 30)
                {
                    MessageBox.Show("Họ tên chỉ chứa 5 - 30 ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTenKH.Focus();
                }
                else if (txtSDT.Text.Trim().Length != 10)
                {
                    MessageBox.Show("Số ĐT chỉ chứa 10 ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSDT.Focus();
                }
                else if (busnv.checkcontainNumber(txtTenKH.Text.Trim()))
                {
                    MessageBox.Show("Tên không được chứa số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSDT.Focus();
                }
                else if (busnv.hasSpecialChar(txtTenKH.Text.Trim()))
                {
                    MessageBox.Show("Tên không được chứa ký tự đặc biệt", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSDT.Focus();
                }
                else
                {
                    DTO_KhachHang khach = new DTO_KhachHang(txtSDT.Text, txtTenKH.Text);
                    if (buskh.themKH(khach))
                    {
                        txtTenKH.Text = "";
                        txtSDT.Text = "";
                        LoadGridview_Khachhang();
                    }
                    else
                    {
                        MessageBox.Show("Thêm Khách hàng thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Mời bạn nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }

        private void FKhachhang_Load(object sender, EventArgs e)
        {
            LoadGridview_Khachhang();
            AutoComplete(buskh.getListKH());
            txtTim.GotFocus += TxtTim_GotFocus;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Orange;
        }
        private void AutoComplete(List<DTO_KhachHang> list)
        {
            List<DTO_KhachHang> listkh = list;
            AutoCompleteStringCollection autocptimsp = new AutoCompleteStringCollection();
            txtTim.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtTim.AutoCompleteSource = AutoCompleteSource.CustomSource;
            foreach (DTO_KhachHang item in listkh)
            {
                autocptimsp.Add(item.SDT);
            }
            foreach (DTO_KhachHang item in listkh)
            {
                autocptimsp.Add(item.TEn);
            }
            txtTim.AutoCompleteCustomSource = autocptimsp;
        }
        private void TxtTim_GotFocus(object sender, EventArgs e)
        {
            btnTim.Enabled = true;
            txtTim.Text = "";
            txtTim.ForeColor = Color.Black;
        }
        private void txtTim_Leave(object sender, EventArgs e)
        {
            if (txtTim.Text.Trim().Length == 0)
            {
                txtTim.ForeColor = Color.Gray;
                txtTim.Text = "--Nhập tên hoặc số ĐT--";
                btnTim.Enabled = false;
            }
        }
        private void settinggridview()
        {
            dataGridView1.Columns[0].HeaderText = "Số điện thoại";
            dataGridView1.Columns[1].HeaderText = "Tên khách hàng";
            dataGridView1.Columns[2].HeaderText = "Điểm tích lũy";
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        private void LoadGridview_Khachhang()
        {
            dataGridView1.DataSource = buskh.getDanhSachKH();
            settinggridview();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtTenKH.Text.Trim().Length < 5 || txtTenKH.Text.Trim().Length > 30)
            {
                MessageBox.Show("Họ tên chỉ chứa 5 - 30 ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenKH.Focus();
            }
            else if (txtSDT.Text.Trim().Length != 10)
            {
                MessageBox.Show("Số ĐT chỉ chứa 10 ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSDT.Focus();
            }
            else if (busnv.checkcontainNumber(txtTenKH.Text.Trim()))
            {
                MessageBox.Show("Tên không được chứa số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSDT.Focus();
            }
            else if (busnv.hasSpecialChar(txtTenKH.Text.Trim()))
            {
                MessageBox.Show("Tên không được chứa ký tự đặc biệt", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSDT.Focus();
            }
            else
            {
                DTO_KhachHang khach = new DTO_KhachHang(txtSDT.Text, txtTenKH.Text);
                if (buskh.UpdateKH(khach))
                {
                    txtTenKH.Text = "";
                    txtSDT.Text = "";
                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadGridview_Khachhang();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string chuoi = txtTim.Text;
            if (active == 1)
            {
                DataTable dt = buskh.FindCustomer(chuoi);
                if (dt.Rows.Count > 0)
                {

                    dataGridView1.DataSource = dt;
                    settinggridview();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy  Khách hàng ", "Thông báo ",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadGridview_Khachhang();
                    settinggridview();
                }
            }
            else
            {
                DataTable dt = buskh.FindCustomerDeleted(chuoi);
                if (dt.Rows.Count > 0)
                {

                    dataGridView1.DataSource = dt;
                    settinggridview();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy  Khách hàng ", "Thông báo ",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = buskh.getDanhSachKHdabiXoa();
                }
            }
            settinggridview();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.Rows.Count > 0)
            {
                if(dataGridView1.CurrentRow.Cells[0].Value.ToString() != "")
                {
                    if(active == 1)
                    {
                        txtSDT.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                        txtTenKH.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                        txtSDT.Enabled = false;
                        btnLuu.Enabled = false;
                        btnHuy.Visible = true;
                    }
                    else
                    {
                        txtSDT.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                        txtTenKH.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    }
                    
                }
                
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtSDT.Text = "";
            txtTenKH.Text = "";
            btnLuu.Enabled = true;
            btnHuy.Visible = false;
            txtSDT.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(txtSDT.Text.Trim().Length > 0)
            {
                if(txtSDT.Text.Trim().Length == 10)
                {
                    if (MessageBox.Show("Bạn có muốn xóa khách hàng " + txtTenKH.Text.Trim() + " không?", "Tôi hỏi cậu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        buskh.DeleteKH(txtSDT.Text.Trim());
                    }
                   
                }
                else
                {
                    MessageBox.Show("Số điện thoại phải đủ 10 số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
            else
            {
                MessageBox.Show("Bạn cần nhập SĐT để thực hiện xóa khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSDT.Focus();
            }
            LoadGridview_Khachhang();
            settinggridview();
        }
        private void btnKhoiphuc_Click(object sender, EventArgs e)
        {
            if (txtSDT.Text.Trim().Length > 0)
            {
                if (txtSDT.Text.Trim().Length == 10)
                {
                    if (MessageBox.Show("Bạn có muốn khôi phục lại khách hàng " + txtTenKH.Text.Trim() + " không?", "Tôi hỏi cậu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        buskh.RestoneKH(txtSDT.Text.Trim());
                    }
                }
                else
                {
                    MessageBox.Show("Số điện thoại phải đủ 10 số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                MessageBox.Show("Bạn cần nhập SĐT để thực hiện khôi phục khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSDT.Focus();
            }
          
            dataGridView1.DataSource = buskh.getDanhSachKHdabiXoa();
            settinggridview();
        }
        private void btnDsBiXoa_Click(object sender, EventArgs e)
        {
            if(active == 1)
            {
                btnDsBiXoa.Text = "Xem những khách hàng tồn tại";
                btnDsBiXoa.IconChar = FontAwesome.Sharp.IconChar.Users;
                dataGridView1.DataSource = buskh.getDanhSachKHdabiXoa();
                settinggridview();
                btnHuy.Visible = false;
                btnLuu.Visible = false;
                btnXoa.Visible = false;
                btnSua.Visible = false;
                btnKhoiphuc.Visible = true;
                txtSDT.Text = "";
                txtTenKH.Text = "";
                txtSDT.Enabled = false;
                txtTenKH.Enabled = false;
                AutoComplete(buskh.getListKHDeleted());
                active = 0;
            }
            else
            {
                btnDsBiXoa.Text = "Xem những khách hàng bị xóa";
                btnDsBiXoa.IconChar = FontAwesome.Sharp.IconChar.UsersSlash;
                LoadGridview_Khachhang();
                settinggridview();
                btnHuy.Visible = false;
                btnLuu.Visible = true;
                btnLuu.Enabled = true;
                btnXoa.Visible = true;
                btnSua.Visible = true;
                btnKhoiphuc.Visible = false;
                txtSDT.Text = "";
                txtTenKH.Text = "";
                txtSDT.Enabled = true;
                txtTenKH.Enabled = true;
                AutoComplete(buskh.getListKH());
                active = 1;
            }
        }

        private void btnTailai_Click(object sender, EventArgs e)
        {
            if (active == 1)
            {
               LoadGridview_Khachhang();
            }
            else
            {
               dataGridView1.DataSource = buskh.getDanhSachKHdabiXoa();
            }
            txtTim.ForeColor = Color.Gray;
            txtTim.Text = "--Nhập tên hoặc số ĐT--";
            btnTim.Enabled = false;
            btnLuu.Enabled = true;
            txtSDT.Text = "";
            txtTenKH.Text = "";
            txtSDT.Enabled = true;
            btnHuy.Visible = false;
            settinggridview();
        }
    }
}
