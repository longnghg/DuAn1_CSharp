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
    public partial class FNhanvien : Form
    {
        BUS_Nhanvien busnhanvien = new BUS_Nhanvien();
        private bool gioitinh;
        private bool vaitro;
        string fileName;// tên file
        string fileAddress; // url load images
        string hinhanh;
        string loadanh;
        string sourceDir;
        string backupDir;
        int active = 1; // 1 đang hiển thị danh sách còn hoạt động , 0 đang hiển thị danh sách ko hoat động
        public FNhanvien()
        {
            InitializeComponent();
        }


        #region events
        private void btnAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|JPEG Image(*.jfif)|*.jfif|PNG(*.png)|*.png|All files(*.*)|*.*";
            dlgOpen.FilterIndex = 5;
            dlgOpen.Title = "Chọn ảnh nhân viên";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                fileAddress = dlgOpen.FileName;
                pbAnh.Image = Image.FromFile(fileAddress);
                fileName = Path.GetFileName(dlgOpen.FileName);
                hinhanh = fileName;
                // lấy đường dẫn file  chứa ảnh
                string FolderPathContainsImg = "";
               if(fileAddress!= null)
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
                }
            }
           
        }
        private void FNhanvien_Load(object sender, EventArgs e)
        {
            txtTim.GotFocus += TxtTim_GotFocus;
            txtEmail.LostFocus += TxtEmail_GotFocus;
            Load_GridView();
            Autocomple(busnhanvien.ListNV());
            TurnOff();
            dtgvdsNhanvien.DefaultCellStyle.SelectionBackColor = Color.Orange;
        }

        private void TxtEmail_GotFocus(object sender, EventArgs e)
        {
            if (String.Compare(txtEmail.Text.Trim(), "ADMIN", true) == 0)
            {
                ResetValue();
            }
        }

        private void TxtTim_GotFocus(object sender, EventArgs e)
        {
            btnTim.Enabled = true;
            txtTim.Text = "";
            txtTim.ForeColor = Color.Black;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            InsertHoacUpdateNV(false);
            Load_GridView();
            ResetValue();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cần thêm chức năng phân quyền vào đây");
            if (txtEmail.Text.Length > 0)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn xóa nhân viên này ko", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (busnhanvien.isadmin(txtEmail.Text.Trim()))
                    {
                        MessageBox.Show("Không xóa ADMIN đc đâu bạn ơi. Đừng cố gắng :P ", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (busnhanvien.XoaNV(txtEmail.Text, FMainnew.mailnv))
                        {
                            MessageBox.Show("Xóa nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Tại sao lại xóa chính bạn vậy hả.Bạn thật ngu ngốc", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

            }
            Load_GridView();
            ResetValue();
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            InsertHoacUpdateNV(true);
            Load_GridView();
            ResetValue();
        }
        #endregion
        #region codes
        // truyền vào true để thực hiện chức năng insert 
        // truyền vào false để thực hiện chức năng update
        public void InsertHoacUpdateNV(bool insert)
        {
            bool checkdata;
            bool finalcheck = true;
            bool checktextbox = busnhanvien.checkData(new string[] { txtHoten.Text.Trim(), txtDiachi.Text.Trim(),
                txtEmail.Text.Trim(),txtSDT.Text.Trim()});
            // kiểm tra các controls đã được nhập liệu hay chưa
            if (!checktextbox)
                checkdata = false;
            else if (!rdbNam.Checked && !rdbNu.Checked)
                checkdata = false;
            else if (!rdbNhanvien.Checked && !rdbQuanly.Checked)
                checkdata = false;
            else 
                checkdata = true;
            if (checkdata)
            {
                if (!busnhanvien.checkEmail(txtEmail.Text.Trim()))
                    finalcheck = false;
                else if (busnhanvien.hasSpecialChar(txtHoten.Text) || busnhanvien.hasSpecialCharDiachi(txtDiachi.Text) || busnhanvien.hasSpecialChar(txtSDT.Text))
                    finalcheck = false;
                else if (busnhanvien.checkcontainNumber(txtHoten.Text) || !busnhanvien.checkisNumber(txtSDT.Text))
                    finalcheck = false;
                else
                    finalcheck = true;
                if (finalcheck)
                {
                    if (txtHoten.Text.Trim().Length < 5 || txtHoten.Text.Trim().Length > 30)
                    {
                        MessageBox.Show("Họ tên chỉ chứa 5 - 30 ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtHoten.Focus();
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
                        if (rdbNhanvien.Checked) vaitro = false;
                        else vaitro = true;
                        DTO_Nhanvien nv = new DTO_Nhanvien();
                        nv.DiaChi = txtDiachi.Text.Trim();
                        nv.Email = txtEmail.Text.Trim();
                        nv.Gioitinh = gioitinh;
                        nv.HoTen = txtHoten.Text.Trim();
                        nv.SDT = txtSDT.Text.Trim();
                        nv.VaiTro = vaitro;
                        // Xảy ra khi thêm nhân viên
                        if (insert)
                        {
                            // Nếu có hình ảnh
                            if (!string.IsNullOrEmpty(hinhanh))
                            {
                                nv.HinhAnh = hinhanh;
                                // Lưu ảnh người dùng vào debug
                                busnhanvien.LuuAnh(fileName, sourceDir, backupDir);
                                // check trùng Email
                                if (isSameEmail(txtEmail.Text.Trim()))
                                {
                                    MessageBox.Show("Email đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    txtEmail.Focus();
                                }
                                else
                                {
                                    // check trùng SDT
                                    if (isSamePhoneNumber(txtSDT.Text.Trim()))
                                    {
                                        MessageBox.Show("Số điện thoại đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        txtSDT.Focus();
                                    }
                                    else
                                    {
                                        MessageBox.Show(hinhanh);
                                        if (busnhanvien.ThemNV(nv))
                                        {
                                            hinhanh = "";
                                            MessageBox.Show(hinhanh);
                                            MessageBox.Show("Nhập nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        else
                                        {
                                            MessageBox.Show("Trục trặc rồi đại vương ơi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }

                                }
                            }
                            else
                            {
                                MessageBox.Show("Bạn chưa nhập ảnh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        // Xảy ra khi cập nhật nhân viên
                        else
                        {
                            // Nếu không thay đổi ảnh
                            if (String.IsNullOrEmpty(hinhanh))
                            {
                                MessageBox.Show("Không thay đổi hình ảnh");
                                nv.HinhAnh = loadanh;
                                // Kiểm tra người dùng có thay đổi sđt khi sửa thông tin hay không
                                if (busnhanvien.NOTChangePhoneNumber(txtEmail.Text.Trim(), txtSDT.Text.Trim()))
                                {
                                    // Hàm code cập nhật nv 
                                    if (busnhanvien.CapNhatNV(nv))
                                    {

                                        MessageBox.Show("Cập nhật nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Cập nhật nhân viên thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    if (isSamePhoneNumber(txtSDT.Text))
                                    {
                                        MessageBox.Show("Số điện thoại đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        txtSDT.Focus();
                                    }
                                    else
                                    {
                                        if (busnhanvien.CapNhatNV(nv))
                                        {

                                            MessageBox.Show("Cập nhật nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        else
                                        {
                                            MessageBox.Show("Cập nhật nhân viên thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                }
                            }
                            // Nếu có thay đổi ảnh
                            else
                            {
                                MessageBox.Show("Có thay đổi hình ảnh");
                                nv.HinhAnh = hinhanh;
                                // Kiểm tra người dùng có thay đổi sđt khi sửa thông tin hay không
                                if (busnhanvien.NOTChangePhoneNumber(txtEmail.Text.Trim(), txtSDT.Text.Trim()))
                                {
                                    // Hàm code cập nhật nv 
                                    if (busnhanvien.CapNhatNV(nv))
                                    {

                                        MessageBox.Show("Cập nhật nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Cập nhật nhân viên thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    if (isSamePhoneNumber(txtSDT.Text))
                                    {
                                        MessageBox.Show("Số điện thoại đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        txtSDT.Focus();
                                    }
                                    else
                                    {
                                        if (busnhanvien.CapNhatNV(nv))
                                        {
                                            hinhanh = "";
                                            MessageBox.Show("Cập nhật nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        else
                                        {
                                            MessageBox.Show("Cập nhật nhân viên thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                }
                            }
                            //////////
                            


                        }
                        
                    }
                }
                else
                {
                    MessageBox.Show("Thông tin bạn nhập không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Hãy nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Load_GridView()
        {
            dtgvdsNhanvien.DataSource = busnhanvien.DanhSachNV();
            settinggridview();
        }

        #endregion
        private bool isSameEmail(string email)
        {
            List<DTO_Nhanvien> listNV = busnhanvien.ListNV();
            foreach (DTO_Nhanvien item in listNV)
            {
                if (email == item.Email)
                {
                    return true; break;
                }
               
            }
            return false;
        }
        private bool isSamePhoneNumber(string phonenumber)
        {
            List<DTO_Nhanvien> listNV = busnhanvien.ListNV();
            foreach (DTO_Nhanvien item in listNV)
            {
                if (phonenumber == item.SDT)
                {
                    return true; break;
                }

            }
            return false;
        }
        private void TurnOff()
        {
            txtDiachi.Enabled = false;
            txtEmail.Enabled = false;
            txtHoten.Enabled = false;
            txtSDT.Enabled = false;
            rdbNam.Enabled = false;
            rdbNhanvien.Enabled = false;
            rdbNu.Enabled = false;
            rdbQuanly.Enabled = false;
            btnAnh.Enabled = false;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }
        private void TurnOn()
        {
            txtEmail.Enabled = true;
            btnLuu.Enabled = true;
            txtDiachi.Enabled = true;
            txtHoten.Enabled = true;
            txtSDT.Enabled = true;
            rdbNam.Enabled = true;
            rdbNhanvien.Enabled = true;
            rdbNu.Enabled = true;
            rdbQuanly.Enabled = true;
            btnAnh.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }
        private void ResetValue()
        {
            txtDiachi.Text = "";
            txtEmail.Text = "";
            txtHoten.Text = "";
            txtSDT.Text = "";
            rdbNhanvien.Checked = true;
            rdbNu.Checked = true;
            pbAnh.Image = default;
        }
        private void dtgvdsNhanvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int RowIndex = dtgvdsNhanvien.CurrentCell.RowIndex;
            if (active == 1)
            {
                if (String.Compare(dtgvdsNhanvien.Rows[RowIndex].Cells["Email"].Value.ToString(), "ADMIN", true) == 0)
                {
                    ResetValue();
                }
                else
                {
                    if (dtgvdsNhanvien.Rows[RowIndex].Cells["manv"].Value.ToString() != "")
                    {

                        txtEmail.Text = dtgvdsNhanvien.Rows[RowIndex].Cells["Email"].Value.ToString();
                        txtHoten.Text = dtgvdsNhanvien.Rows[RowIndex].Cells["TenNV"].Value.ToString();
                        txtDiachi.Text = dtgvdsNhanvien.Rows[RowIndex].Cells["Diachi"].Value.ToString();
                        txtSDT.Text = dtgvdsNhanvien.Rows[RowIndex].Cells["SDT"].Value.ToString();
                        loadanh = dtgvdsNhanvien.Rows[RowIndex].Cells["hinhanh"].Value.ToString();
                        txtEmail.Text = dtgvdsNhanvien.Rows[RowIndex].Cells["Email"].Value.ToString();
                        gioitinh = bool.Parse(dtgvdsNhanvien.Rows[RowIndex].Cells["gioitinh"].Value.ToString());
                        dtgvdsNhanvien.Rows[RowIndex].Cells["gioitinh"].ReadOnly = true;
                        vaitro = bool.Parse(dtgvdsNhanvien.Rows[RowIndex].Cells["vaitro"].Value.ToString());
                        dtgvdsNhanvien.Rows[RowIndex].Cells["vaitro"].ReadOnly = true;
                        if (gioitinh)
                            rdbNu.Checked = true;
                        else
                            rdbNam.Checked = true;
                        if (vaitro)
                            rdbQuanly.Checked = true;
                        else
                            rdbNhanvien.Checked = true;
                        // Load images
                        pbAnh.Image = Image.FromFile(Application.StartupPath + "\\Resources\\" + loadanh);
                        //mở các controls
                        txtDiachi.Enabled = true;
                        txtHoten.Enabled = true;
                        txtSDT.Enabled = true;
                        rdbNam.Enabled = true;
                        rdbNhanvien.Enabled = true;
                        rdbNu.Enabled = true;
                        rdbQuanly.Enabled = true;
                        btnAnh.Enabled = true;
                        btnSua.Enabled = true;
                        btnXoa.Enabled = true;
                        btnThem.Checked = false;
                        txtEmail.Enabled = false;
                    }
                }
            }
            else
            {
                if (dtgvdsNhanvien.Rows[RowIndex].Cells["manv"].Value.ToString() != "")
                {
                    txtEmail.Text = dtgvdsNhanvien.Rows[RowIndex].Cells["Email"].Value.ToString();
                    txtHoten.Text = dtgvdsNhanvien.Rows[RowIndex].Cells["TenNV"].Value.ToString();
                    txtDiachi.Text = dtgvdsNhanvien.Rows[RowIndex].Cells["Diachi"].Value.ToString();
                    txtSDT.Text = dtgvdsNhanvien.Rows[RowIndex].Cells["SDT"].Value.ToString();
                    loadanh = dtgvdsNhanvien.Rows[RowIndex].Cells["hinhanh"].Value.ToString();
                    txtEmail.Text = dtgvdsNhanvien.Rows[RowIndex].Cells["Email"].Value.ToString();
                    gioitinh = bool.Parse(dtgvdsNhanvien.Rows[RowIndex].Cells["gioitinh"].Value.ToString());
                    dtgvdsNhanvien.Rows[RowIndex].Cells["gioitinh"].ReadOnly = true;
                    vaitro = bool.Parse(dtgvdsNhanvien.Rows[RowIndex].Cells["vaitro"].Value.ToString());
                    dtgvdsNhanvien.Rows[RowIndex].Cells["vaitro"].ReadOnly = true;
                    if (gioitinh)
                        rdbNu.Checked = true;
                    else
                        rdbNam.Checked = true;
                    if (vaitro)
                        rdbQuanly.Checked = true;
                    else
                        rdbNhanvien.Checked = true;
                    // Load images
                    pbAnh.Image = Image.FromFile(Application.StartupPath + "\\Resources\\" + loadanh);
                }
                
            }
        }
        private void settinggridview()
        {
            dtgvdsNhanvien.Columns[0].HeaderText = "Mã nhân viên";
            dtgvdsNhanvien.Columns[1].HeaderText = "Tên nhân viên";
            dtgvdsNhanvien.Columns[2].HeaderText = "Địa Chỉ";
            dtgvdsNhanvien.Columns[3].HeaderText = "Số Điện Thoại";
            dtgvdsNhanvien.Columns[4].HeaderText = "Email";
            dtgvdsNhanvien.Columns[5].HeaderText = "Giới tính";
            dtgvdsNhanvien.Columns[6].HeaderText = "Vai Trò";
            dtgvdsNhanvien.Columns[7].HeaderText = "Hình Ảnh";
        }
        private void btnThem_MouseClick(object sender, MouseEventArgs e)
        {
            if (btnThem.Checked == true)
            {
                TurnOn();
                ResetValue();
            }
            else
            {
                TurnOff();
                ResetValue();
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string chuoi = txtTim.Text;
            if (active == 1)
            {
                DataTable dt = busnhanvien.FindNV(chuoi);
                if (dt.Rows.Count > 0)
                {
                    dtgvdsNhanvien.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy  nhân viên ", "Thông báo ",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtgvdsNhanvien.DataSource = busnhanvien.DanhSachNV();
                }
            }
            else
            {
                DataTable dt = busnhanvien.FindNVDeleted(chuoi);
                if (dt.Rows.Count > 0)
                {

                    dtgvdsNhanvien.DataSource = dt;                }
                else
                {
                    MessageBox.Show("Không tìm thấy  nhân viên ", "Thông báo ",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtgvdsNhanvien.DataSource = busnhanvien.DanhSachNVDelete();
                }
            }
            settinggridview();
        }

        private void btnTailai_Click(object sender, EventArgs e)
        {
            if(active == 1)
            {
                Load_GridView();
            }
            else
            {
                dtgvdsNhanvien.DataSource = busnhanvien.DanhSachNVDelete();
            }
            ResetValue();
            btnThem.Checked = false;
            txtTim.ForeColor = Color.Gray;
            txtTim.Text = "--Nhập tên hoặc tên NV--";
            btnTim.Enabled = false;
        }

        private void txtTim_Leave(object sender, EventArgs e)
        {
            if (txtTim.Text.Trim().Length == 0)
            {
                txtTim.ForeColor = Color.Gray;
                txtTim.Text = "--Nhập tên hoặc tên NV--";
                btnTim.Enabled = false;
            }
        }

        private void btnDsBiXoa_Click(object sender, EventArgs e)
        {
            if (active == 1)
            {
                btnDsBiXoa.Text = "Xem những nhân viên tồn tại";
                btnDsBiXoa.IconChar = FontAwesome.Sharp.IconChar.Users;
                dtgvdsNhanvien.DataSource = busnhanvien.DanhSachNVDelete();
                Autocomple(busnhanvien.ListNVdeleted());
                settinggridview();
                ResetValue();
                txtDiachi.Enabled = false;
                txtEmail.Enabled = false; 
                txtHoten.Enabled = false;
                txtSDT.Enabled = false;
                rdbNam.Enabled = false;
                rdbNhanvien.Enabled = false;
                rdbNu.Enabled = false;
                rdbQuanly.Enabled = false;
                btnAnh.Enabled = false; 
                btnLuu.Visible = false;
                btnSua.Visible = false;
                btnXoa.Visible = false;
                btnThem.Checked = false;
                btnThem.Visible = false;
                btnKhoiphuc.Visible = true;
                active = 0;
            }
            else
            {
                btnDsBiXoa.Text = "Xem những nhân viên bị xóa";
                btnDsBiXoa.IconChar = FontAwesome.Sharp.IconChar.UsersSlash;
                dtgvdsNhanvien.DataSource = busnhanvien.DanhSachNV();
                Autocomple(busnhanvien.ListNV());
                settinggridview();
                ResetValue();
                btnLuu.Visible = true;
                btnSua.Visible = true;
                btnXoa.Visible = true;
                btnThem.Checked = false;
                btnThem.Visible = true;
                btnKhoiphuc.Visible = false;
                active = 1;
            }
        }

        private void btnKhoiphuc_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text.Trim().Length > 0)
            {
                if (MessageBox.Show("Bạn có muốn khôi phục lại nhân viên " + txtHoten.Text.Trim() +"không?","Tôihỏicậu",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    busnhanvien.RestoneNV(txtEmail.Text.Trim());
                }
            }
            else
            {
                MessageBox.Show("Bạn cần nhập SĐT để thực hiện khôi phục lại nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSDT.Focus();
            }
            dtgvdsNhanvien.DataSource = busnhanvien.DanhSachNVDelete();
            settinggridview();
            ResetValue();
        }
        private void Autocomple(List<DTO_Nhanvien> list)
        {
            List<DTO_Nhanvien> listkh = list;
            AutoCompleteStringCollection autocptimsp = new AutoCompleteStringCollection();
            txtTim.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtTim.AutoCompleteSource = AutoCompleteSource.CustomSource;
            foreach (DTO_Nhanvien item in listkh)
            {
                autocptimsp.Add(item.MaNV);
            }
            foreach (DTO_Nhanvien item in listkh)
            {
                autocptimsp.Add(item.HoTen);
            }
            txtTim.AutoCompleteCustomSource = autocptimsp;
        }
    }
}
