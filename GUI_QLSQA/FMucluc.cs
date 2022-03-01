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
    public partial class FMucluc : Form
    {
        BUS_DanhMucSP busdmsp = new BUS_DanhMucSP();
        BUS_Nhanvien busnv = new BUS_Nhanvien();
        public FMucluc()
        {
            InitializeComponent();
        }

        private void FMucluc_Load(object sender, EventArgs e)
        {
            txtTim.GotFocus += TxtTim_GotFocus;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Orange;
            Load_gridview();
        }
        private void resetvalue()
        {
            txtMaloai.Text = "";
            txtTenloai.Text = "";
            txtTim.Text = "";
        }
        private void TxtTim_GotFocus(object sender, EventArgs e)
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
                txtTim.ForeColor = Color.LightGray;
                txtTim.Text = "--Nhập tên hoặc mã SP--";
                btnTim.Enabled = false;
            }
        }

        private void Load_gridview()
        {
            dataGridView1.DataSource = busdmsp.DanhsachDMSP();
            dataGridView1.Columns[0].HeaderText = "Mã Loại";
            dataGridView1.Columns[1].HeaderText = "Tên Loại";
        }
        private void InsertOrUpdate(bool check , string maloai,string tenloai)
        {
            bool checkdata ;
            bool checktextbox = busnv.checkData(new string[] {txtMaloai.Text.Trim(),txtTenloai.Text.Trim()});
            if (!checktextbox)
                checkdata = false;
            else if (busnv.hasSpecialChar(txtMaloai.Text) || busnv.hasSpecialChar(txtTenloai.Text))
                checkdata = false;
            else
                checkdata = true;
            if (checkdata)
            {
                if (check)
                {
                    if (busdmsp.ThemDMSP(maloai, tenloai))
                    {
                        MessageBox.Show("Thêm danh mục thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thêm danh mục thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (busdmsp.CapNhatDMSP(maloai, tenloai))
                    {
                        MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Thông tin bạn nhập không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Load_gridview();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            InsertOrUpdate(true, txtMaloai.Text, txtTenloai.Text);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            InsertOrUpdate(false, txtMaloai.Text, txtTenloai.Text);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maloaihang = txtMaloai.Text;
            if (MessageBox.Show("Bạn có chắc muốn xóa dữ liệu", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (busdmsp.XoaLoaiHang(maloaihang))
                {
                    MessageBox.Show("Xóa dữ liệu thành công");
                    Load_gridview();
                }
                else
                {
                    MessageBox.Show("Xóa không thành công");
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                txtMaloai.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtTenloai.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string tenloai = txtTim.Text;
            string maloai = txtTim.Text;
            DataTable dt = busdmsp.timkiemDM(tenloai, maloai);
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].HeaderText = "Tên Loại";
                dataGridView1.Columns[1].HeaderText = "Mã Loại";
            }
            else
            {

                MessageBox.Show("Không tìm thấy danh mục sản phẩm ", "Thông báo ",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnTailai_Click(object sender, EventArgs e)
        {
            resetvalue();
            Load_gridview();
        }
    }
}
