using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QLSQA;
using DTO_QLSQA;
namespace GUI_QLSQA
{
    public partial class FSanpham : Form
    {
        BUS_DanhMucSP busdmsp = new BUS_DanhMucSP();
        BUS_Nhanvien nv = new BUS_Nhanvien();
        BUS_Sanpham bussp = new BUS_Sanpham();
        BUS_DonVanChuyen busdvc = new BUS_DonVanChuyen();
        BUS_CTDonVanChuyen busctdvc = new BUS_CTDonVanChuyen();
        string fileName;// tên file
        string fileName1;// tên file
        string emailnv;
        string manv;
        string fileAddress; // url load images
        // được gán khi chọn ảnh
        string hinhanhtrc; 
        string hinhanhsau;
        // được gán khi load ảnh lên = grid view
        string loadanhtrc;
        string loadanhsau;
        string sourceDirFore;
        string backupDir = Application.StartupPath + @"\Resources";
        string sourceDirBack;
        int doituong;
        int size;
        int color;
        bool isExistItem = default;
        public FSanpham()
        {
            InitializeComponent();
            emailnv = FMainnew.mailnv;

        }
        private void settingGridview()
        {
            if (btnChitiet.Checked)
            {
                dtgvdsSanpham.Columns["masp"].HeaderText = "Mã SP";
                dtgvdsSanpham.Columns["tensp"].HeaderText = "Tên Sản Phẩm";
                dtgvdsSanpham.Columns["dongianhap"].HeaderText = "Giá Nhập";
                dtgvdsSanpham.Columns["Dongiaban"].HeaderText = "Giá Bán";
                dtgvdsSanpham.Columns["tensize"].HeaderText = "Size";
                dtgvdsSanpham.Columns["Doituong"].HeaderText = "Đối Tượng";
                dtgvdsSanpham.Columns["hinhanhtrc"].HeaderText = "Hình Ảnh Trước";
                dtgvdsSanpham.Columns["hinhanhsau"].HeaderText = "Hình Ảnh Sau";
                dtgvdsSanpham.Columns["tenmau"].HeaderText = "Màu";
                dtgvdsSanpham.Columns["Tenloai"].HeaderText = "Tên Loại";
                dtgvdsSanpham.Columns["SoLuong"].HeaderText = "Số Lượng";
                dtgvdsSanpham.Columns["SoLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            else
            {
                dtgvdsSanpham.Columns[0].HeaderText = "Mã SP";
                dtgvdsSanpham.Columns[1].HeaderText = "Tên Sản Phẩm";
                dtgvdsSanpham.Columns[2].HeaderText = "Giá Nhập";
                dtgvdsSanpham.Columns[3].HeaderText = "Giá Bán";
                dtgvdsSanpham.Columns["TongSoluong"].HeaderText = "Tổng SL";
                dtgvdsSanpham.Columns[5].HeaderText = "Đối Tượng";
                dtgvdsSanpham.Columns[6].HeaderText = "Hình Ảnh Trước";
                dtgvdsSanpham.Columns[7].HeaderText = "Hình Ảnh Sau";
                dtgvdsSanpham.Columns[8].HeaderText = "Giảm Giá";
                dtgvdsSanpham.Columns[9].HeaderText = "Tên Loại";
                dtgvdsSanpham.Columns["Maloai"].Visible = false;
                dtgvdsSanpham.Columns["GiamGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dtgvdsSanpham.Columns["TongSoluong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            dtgvdsSanpham.Columns["tensp"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dtgvdsSanpham.Columns["dongianhap"].DefaultCellStyle.Format = "N0";
            dtgvdsSanpham.Columns["dongiaban"].DefaultCellStyle.Format = "N0";
            dtgvdsSanpham.Columns["dongianhap"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgvdsSanpham.Columns["dongiaban"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        // Tải lại form

        #region code
        public void LoadForm()
        {
            manv = nv.LayMaNV(emailnv).ToString();
            if (manv.Contains("QL"))
            {
                btnXoa.Visible = true;
            }
            if (btnChitiet.Checked)
            {
                dtgvdsSanpham.DataSource = bussp.hienthiDSSP();
            }
            else
            {
                dtgvdsSanpham.DataSource = bussp.hienthiDSSP_rutgon();  
            }
            settingGridview();

        }
        public void LoadCombobox()  
        {
            cbTenloai1.DataSource = bussp.hienthiCombobox();
            cbTenloai1.DisplayMember = "TenLoai";
            cbTenloai1.ValueMember = "MaLoai";
            cbMausac.DataSource = bussp.hienthiComboboxMauSac();
            cbMausac.DisplayMember = "tenmau";
            cbMausac.ValueMember = "mamau";
        }
        private void resetValue()
        {
            txtGiaBan.Text = "";
            txtGiaNhap.Text = "";
            txtMasp.Text = "";
       
            txtSl.Text = "";
            txtTensp.Text = "";
            pbAnh1.Image = default;
            pbAnh2.Image = default;
        }
        private void activeSizeAndColor()
        {
            lbkichco.Visible = true;
            rdbSizeL.Visible = true;
            rdbSizeM.Visible = true;
            rdbSizeS.Visible = true;
            rdbSizeXL.Visible = true;
            rdbSizeXXL.Visible = true;
            lbmausac.Visible = true;
            cbMausac.Visible = true;
            txtSl.Text = "";
            txtMasp.Enabled = true;
            txtSl.Enabled = true;
        }
        private void disableSizeAndColor()
        {
              lbkichco.Visible = false;
            rdbSizeL.Visible = false;
            rdbSizeM.Visible = false;
            rdbSizeS.Visible = false;
            rdbSizeXL.Visible = false;
            rdbSizeXXL.Visible = false;
            lbmausac.Visible = false;
            cbMausac.Visible = false;
            txtSl.Text = "Không hiển thị";
            txtMasp.Enabled = false;
            txtSl.Enabled = false;

        }
        #endregion
        #region EVents
        private void btnDanhsach_Click(object sender, EventArgs e)
        {
            FDSSanpham.Instance.ShowDialog();
        }
        // btn add ảnh phía trước của sản phẩm
        private void btnAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|JPEG Image(*.jfif)|*.jfif|PNG(*.png)|*.png|All files(*.*)|*.*";
            dlgOpen.FilterIndex = 5;
            dlgOpen.Title = "Chọn ảnh sản phẩm";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                fileAddress = dlgOpen.FileName;
                pbAnh1.Image = Image.FromFile(fileAddress);
                fileName = Path.GetFileName(dlgOpen.FileName);
                // lấy đường dẫn file chứa ảnh
                string FolderPathContainsImg = "";
                if (fileAddress != null)
                {
                    string[] spFile = fileAddress.Split('\\');
                    hinhanhtrc = spFile[spFile.Length - 1];
                    foreach (string item in spFile)
                    {
                        if (!item.Contains(spFile[spFile.Length - 1]))
                        {
                            FolderPathContainsImg += item + "\\";
                        }
                    }
                    sourceDirFore = FolderPathContainsImg;
                }
            }
           
        }
        // btn add ảnh phía sau của sản phẩm
        private void btnAnhsau_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|JPEG Image(*.jfif)|*.jfif|PNG(*.png)|*.png|All files(*.*)|*.*";
            dlgOpen.FilterIndex = 5;
            dlgOpen.Title = "Chọn ảnh sản phẩm";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                fileAddress = dlgOpen.FileName;
                pbAnh2.Image = Image.FromFile(fileAddress);
                fileName1 = Path.GetFileName(dlgOpen.FileName);
                // lấy đường dẫn file chứa ảnh
                string FolderPathContainsImg = "";
                if(fileAddress!= null)
                {
                    string[] spFile = fileAddress.Split('\\');
                    hinhanhsau = spFile[spFile.Length - 1];
                    foreach (string item in spFile)
                    {
                        if (!item.Contains(spFile[spFile.Length - 1]))
                        {
                            FolderPathContainsImg += item + "\\";
                        }
                    }
                    sourceDirBack = FolderPathContainsImg;
                }
            }
        }

        public void FSanpham_Load(object sender, EventArgs e)
        {
            LoadForm();
            LoadCombobox();
            btnThem.Checked = false;
            TurnOff();
            disableSizeAndColor();
            AutoCompleteTextbox();
            txtTim.GotFocus += TxtTim_GotFocus;
            txtMasp.LostFocus += TxtMasp_LostFocus;
            dtgvdsSanpham.DefaultCellStyle.SelectionBackColor = Color.Orange;
            if (FMainnew.active_addItem == 1)
            {
                activeSizeAndColor();
                btnThem.Checked = true;
                TurnOn();
            }
               
        }
        private string UpperCase(string input)
        {
            string upperstring = input.ToUpper();
            return upperstring;
        }
        private void TxtMasp_LostFocus(object sender, EventArgs e)
        {
            txtMasp.Text =  UpperCase(txtMasp.Text.Trim());
            List<DTO_Sanpham> Listsp = bussp.ListSP();
            foreach (DTO_Sanpham item in Listsp)
            {
                if (txtMasp.Text.Trim() == item.MaSP)
                {
                    txtTensp.Text = item.TenSP;
                    txtGiaBan.Text = item.DongiaBan.ToString();
                    txtGiaNhap.Text = item.DongiaNhap.ToString();
                    cbTenloai1.SelectedValue = item.MaLoai;
                    pbAnh1.Image = Image.FromFile(Application.StartupPath + "\\Resources\\" + item.HinhAnhtrc);
                    loadanhtrc = item.HinhAnhtrc;
                    loadanhsau = item.HinhAnhsau;
                    pbAnh2.Image = Image.FromFile(Application.StartupPath + "\\Resources\\" + item.HinhAnhsau);
                    selectrdbButtonDoiTuong(item.DoiTuong);
                    rdbNam.Enabled = false;
                    rdbNamvaNu.Enabled = false;
                    rdbNu.Enabled = false;
                    isExistItem = true;
                    break;
                }
                isExistItem = false;
                rdbNam.Enabled = true;
                rdbNamvaNu.Enabled = true;
                rdbNu.Enabled = true;
            }
            ItemExist();
        }
        // tự chọn rdb đối tượng
        private void selectrdbButtonDoiTuong(int doituong)
        {
            if (doituong == 0) rdbNam.Checked = true;
            else if (doituong == 1) rdbNu.Checked = true;
            else rdbNamvaNu.Checked = true;
            
        }
        private void TxtTim_GotFocus(object sender, EventArgs e)
        {
            txtTim.Text = "";
            txtTim.Focus();
            txtTim.ForeColor = Color.Black;
            btnTim.Enabled = true;
        }

        private void AutoCompleteTextbox()
        {
            // auto masp
            List<DTO_Sanpham> Listsp = bussp.ListSP();
            AutoCompleteStringCollection autocpMasp = new AutoCompleteStringCollection();
            txtMasp.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtMasp.AutoCompleteSource = AutoCompleteSource.CustomSource;
            foreach (DTO_Sanpham item in Listsp)
            {
              autocpMasp.Add(item.MaSP);
            }
            txtMasp.AutoCompleteCustomSource = autocpMasp;
            // auto tensp
            AutoCompleteStringCollection autocptensp = new AutoCompleteStringCollection();
            txtTensp.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtTensp.AutoCompleteSource = AutoCompleteSource.CustomSource;
            foreach (DTO_Sanpham item in Listsp)
            {
                autocptensp.Add(item.TenSP);
            }
            txtTensp.AutoCompleteCustomSource = autocptensp;
            // auto tim kiem
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

        private void btnChitiet_CheckedChanged(object sender, EventArgs e)
        {
            LoadForm();
        }
        private void ItemExist()
        {
            if (isExistItem)
            {
                txtTensp.Enabled = false;
                txtGiaNhap.Enabled = false;
                txtGiaBan.Enabled = false;
                cbTenloai1.Enabled = false;
                btnAnhsau.Enabled = false;
                btnAnhtrc.Enabled = false;
            }
            else
            {
                txtTensp.Enabled = true;
                txtGiaNhap.Enabled = true;
                txtGiaBan.Enabled = true;
                cbTenloai1.Enabled = true;
                btnAnhsau.Enabled = true;
                btnAnhtrc.Enabled = true;
                txtTensp.Text = "";
                txtGiaBan.Text = "";
                txtGiaNhap.Text = "";
                pbAnh1.Image = default;
                pbAnh2.Image = default;
                cbTenloai1.SelectedIndex = 0;
            }
        }
        private bool checkItemIsExist() // hàm bỏ
        {
            //int mamau;
            //int masize;
            //if (rdbSizeS.Checked) masize = 1;
            //else if (rdbSizeM.Checked) masize = 2;
            //else if (rdbSizeL.Checked) masize = 3;
            //else if (rdbSizeXL.Checked) masize = 4;
            //else masize = 5;
            //mamau = busctdvc.getIDColor(cbMausac.Texts);
            //listctsp = bussp.checkItemisExists();
            //foreach (DTO_DieuChinhSLNhapHang item in listctsp)
            //{
            //    if (txtMasp.Text.Trim() == item.MaSP && mamau == item.MaMau && masize == item.Size)
            //    {
            //        return true; break;
            //    }
            //}
            return false;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (nv.checkData(new string[] { txtMasp.Text.Trim(), txtTensp.Text.Trim(), txtGiaNhap.Text.Trim(), txtGiaBan.Text.Trim(), txtSl.Text.Trim() }))
            {
                bool checkdata;
                if (nv.hasSpecialChar(txtMasp.Text) || nv.hasSpecialChar(txtTensp.Text))
                    checkdata = false;
                else if (!nv.checkisNumber(txtGiaBan.Text) || !nv.checkisNumber(txtGiaNhap.Text) || !nv.checkisNumber(txtSl.Text))
                    checkdata = false;
                else
                    checkdata = true;
                if (checkdata)
                {
                    if( txtMasp.Text.Trim().Length > 5)
                    {
                        MessageBox.Show("Mã sp chỉ từ 1 - 5 ký tự", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }else if(txtTensp.Text.Trim().Length > 30)
                        MessageBox.Show("Tên sp quá dài", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (txtTensp.Text.Trim().Length < 5)
                        MessageBox.Show("Tên sp quá ngắn", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if(float.Parse(txtGiaNhap.Text)>10000000 || float.Parse(txtGiaBan.Text) > 10000000)
                        MessageBox.Show("Giá không hợp lệ", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (int.Parse(txtSl.Text)>1000)
                        MessageBox.Show("Vượt quá số lượng nhập hàng", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        if (rdbNam.Checked) doituong = 0;
                        else if (rdbNu.Checked) doituong = 1;
                        else doituong = 2;
                        if (rdbSizeS.Checked) size = 1;
                        else if (rdbSizeM.Checked) size = 2;
                        else if (rdbSizeL.Checked) size = 3;
                        else if (rdbSizeXL.Checked) size = 4;
                        else size = 5;

                        DTO_Sanpham sp = new DTO_Sanpham();
                        sp.DoiTuong = doituong;
                        sp.DongiaBan = float.Parse(txtGiaBan.Text);
                        sp.DongiaNhap = float.Parse(txtGiaNhap.Text);
                        sp.MaLoai = cbTenloai1.SelectedValue.ToString();
                        sp.Mamau = int.Parse(cbMausac.SelectedValue.ToString());
                        sp.MaSP = txtMasp.Text;
                        sp.Size = size;
                        sp.SoLuong = int.Parse(txtSl.Text);
                        sp.TenSP = txtTensp.Text.Trim();
                        if (isExistItem) // sản phẩm đã có trong kho
                        {
                            sp.HinhAnhsau = loadanhsau;
                            sp.HinhAnhtrc = loadanhtrc;
                            if (bussp.ThemSP(sp, manv))
                            {
                                MessageBox.Show("Thêm sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                resetValue();
                                LoadForm();
                            }
                            else
                            {
                                MessageBox.Show("Không thêm được rồi đại vương ơi", "Báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                        }
                        else
                        {
                            sp.HinhAnhsau = hinhanhsau;
                            sp.HinhAnhtrc = hinhanhtrc;
                            if (sourceDirFore != null && sourceDirBack != null)
                            {
                                if (bussp.ThemSP(sp, manv))
                                {
                                    nv.LuuAnh(fileName, sourceDirFore, backupDir);
                                    nv.LuuAnh(fileName1, sourceDirBack, backupDir);
                                    MessageBox.Show("Thêm sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    resetValue();
                                    LoadForm();
                                }
                                else
                                {
                                    MessageBox.Show("Không thêm được rồi đại vương ơi", "Báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                }
                            }
                            else
                            {
                                MessageBox.Show("Xin mời bạn chọn ảnh", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                        }
                        
                    }


                }
                else
                {
                    MessageBox.Show("Dữ liệu không hợp lệ", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Nhập đầy đủ dữ liệu", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtTensp.Enabled = true;
            txtGiaBan.Enabled = true;
            txtGiaNhap.Enabled = true;

        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (nv.checkData(new string[] {txtTensp.Text.Trim(), txtGiaNhap.Text.Trim(), txtGiaBan.Text.Trim()}))
            {
                bool checkdata;
                if (nv.hasSpecialChar(txtTensp.Text))
                    checkdata = false;
                else if (!nv.checkisNumber(txtGiaBan.Text) || !nv.checkisNumber(txtGiaNhap.Text))
                    checkdata = false;
                else
                    checkdata = true;
                if (checkdata)
                {
                    if (txtTensp.Text.Trim().Length > 30)
                        MessageBox.Show("Tên sp quá dài", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (txtTensp.Text.Trim().Length < 5)
                        MessageBox.Show("Tên sp quá ngắn", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (float.Parse(txtGiaNhap.Text) > 10000000 || float.Parse(txtGiaBan.Text) > 10000000)
                        MessageBox.Show("Giá không hợp lệ", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {

                        if (rdbNam.Checked) doituong = 0;
                        else if (rdbNu.Checked) doituong = 1;
                        else doituong = 2;
                        if (rdbSizeS.Checked) size = 1;
                        else if (rdbSizeM.Checked) size = 2;
                        else if (rdbSizeL.Checked) size = 3;
                        else if (rdbSizeXL.Checked) size = 4;
                        else size = 5;
                        DTO_Sanpham sp = new DTO_Sanpham();
                        sp.DoiTuong = doituong;
                        sp.DongiaBan = float.Parse(txtGiaBan.Text);
                        sp.DongiaNhap = float.Parse(txtGiaNhap.Text);
                        sp.MaLoai = cbTenloai1.SelectedValue.ToString();
                        sp.MaSP = txtMasp.Text.Trim();
                        sp.TenSP = txtTensp.Text.Trim();
                       
                        // không sửa ảnh
                        if (String.IsNullOrEmpty(hinhanhtrc) && String.IsNullOrEmpty(hinhanhsau))
                        {
                            sp.HinhAnhsau = loadanhsau;
                            sp.HinhAnhtrc = loadanhtrc;
                            // không thay đổi tên
                            if (bussp.NOTchangeNameItem(sp.MaSP, sp.TenSP))
                            {
                                UpdateSP(sp);
                            }
                            else // có thay đổi tên
                            {
                                if (isNameitemExists(txtTensp.Text.Trim()))
                                {
                                    MessageBox.Show("Tên sản phẩm bị trùng.Vui lòng nhập lại tên khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    UpdateSP(sp);
                                }
                            }
                        }
                        else // có sửa ảnh
                        {
                            if (String.IsNullOrEmpty(hinhanhsau) || String.IsNullOrEmpty(hinhanhtrc))
                            {
                                MessageBox.Show("Bạn vui lòng chọn lại đủ 2 ảnh, nếu bạn muốn thay đổi ảnh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                sp.HinhAnhsau = hinhanhsau;
                                sp.HinhAnhtrc = hinhanhtrc;
                                // không thay đổi tên
                                if (bussp.NOTchangeNameItem(sp.MaSP, sp.TenSP))
                                {

                                    nv.LuuAnh(fileName, sourceDirFore, backupDir);
                                    nv.LuuAnh(fileName1, sourceDirBack, backupDir);
                                    UpdateSP(sp);
                                }
                                else // có thay đổi tên
                                {
                                    if (isNameitemExists(txtTensp.Text.Trim()))
                                    {
                                        MessageBox.Show("Tên sản phẩm bị trùng.Vui lòng nhập lại tên khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {

                                        nv.LuuAnh(fileName, sourceDirFore, backupDir);
                                        nv.LuuAnh(fileName1, sourceDirBack, backupDir);
                                        UpdateSP(sp);
                                    }
                                }
                            }
                           
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Dữ liệu không hợp lệ", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                LoadForm();

            }
            else
            {
                MessageBox.Show("Nhập đầy đủ dữ liệu", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TurnOn()
        {
            txtGiaNhap.Enabled = true;
            txtMasp.Enabled = true;
            txtTensp.Enabled = true;
            txtGiaBan.Enabled = true;
            txtSl.Enabled = true;
            cbTenloai1.Enabled = true;
            cbMausac.Enabled = true;
            rdbNam.Enabled = true;
            rdbNu.Enabled = true;
            rdbNamvaNu.Enabled = true;
            rdbSizeL.Enabled = true;
            rdbSizeM.Enabled = true;
            rdbSizeS.Enabled = true;
            rdbSizeXL.Enabled = true;
            rdbSizeXXL.Enabled = true;
            btnAnhtrc.Enabled = true;
            btnAnhsau.Enabled = true;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            resetValue();
        }
        private void TurnOff()
        {
            txtGiaNhap.Enabled = false;
            txtMasp.Enabled = false;
            txtTensp.Enabled = false;
            txtGiaBan.Enabled = false;
            txtSl.Enabled = false;
            cbTenloai1.Enabled = false;
            cbMausac.Enabled = false;
            rdbNam.Enabled = false;
            rdbNu.Enabled = false;
            rdbNamvaNu.Enabled = false;
            rdbSizeL.Enabled = false;
            rdbSizeM.Enabled = false;
            rdbSizeS.Enabled = false;
            rdbSizeXL.Enabled = false;
            rdbSizeXXL.Enabled = false;
            btnAnhtrc.Enabled = false;
            btnAnhsau.Enabled = false;
            resetValue();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!btnThem.Checked)
            {
                if (MessageBox.Show("Bạn có muốn BẬT chế độ nhập sản phẩm ?", "Tớ hỏi cậu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    activeSizeAndColor();
                    btnThem.Checked = true;
                    TurnOn();
                    busdvc.ThemBillVC();
                    FMainnew.active_addItem = 1;
                }
            }
            else
            {
                if (MessageBox.Show("Bạn có muốn TẮT chế độ nhập sản phẩm ?", "Tớ hỏi cậu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if(cbTenloai1.SelectedIndex != 0)
                    {
                        cbTenloai1.SelectedIndex = 0;
                    }
                    disableSizeAndColor();
                    btnThem.Checked = false;
                    TurnOff();
                    FMainnew.active_addItem = 0;
                }
            }
        }
        private bool CheckThayDoiCbLoaiSP(string value)
        {
            List<DTO_Loaisp> listloaisp = busdmsp.loadCBLoaisp();
            foreach (DTO_Loaisp item in listloaisp)
            {
                if (item.MaLoai.Contains(value))
                {
                    return true; break;
                }
            }
            return false;
        }

        private void txtSl_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void btnTailai_Click(object sender, EventArgs e)
        {
            if (btnChitiet.Checked)
            {
                dtgvdsSanpham.DataSource = bussp.hienthiDSSP();
            }
            else
            {
                dtgvdsSanpham.DataSource = bussp.hienthiDSSP_rutgon();
            }
            settingGridview();
            btnThem.Checked = false;
            TurnOff();
        }

        private void dtgvdsSanpham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvdsSanpham.CurrentRow.Cells["masp"].Value.ToString() != "")
            {
                disableSizeAndColor();
                    txtMasp.Text = dtgvdsSanpham.CurrentRow.Cells["masp"].Value.ToString();
                    txtTensp.Text = dtgvdsSanpham.CurrentRow.Cells["tensp"].Value.ToString();
                    txtGiaNhap.Text = dtgvdsSanpham.CurrentRow.Cells["dongianhap"].Value.ToString();
                    txtGiaBan.Text = dtgvdsSanpham.CurrentRow.Cells["dongiaban"].Value.ToString();
                doituong = Convert.ToInt32(dtgvdsSanpham.CurrentRow.Cells["doituong"].Value);
                selectrdbButtonDoiTuong(doituong);
                loadanhtrc = dtgvdsSanpham.CurrentRow.Cells["hinhanhtrc"].Value.ToString();
                loadanhsau = dtgvdsSanpham.CurrentRow.Cells["hinhanhsau"].Value.ToString();
                pbAnh1.Image = Image.FromFile(Application.StartupPath + "\\Resources\\" + loadanhtrc);
                pbAnh2.Image = Image.FromFile(Application.StartupPath + "\\Resources\\" + loadanhsau);
                cbTenloai1.SelectedValue = bussp.getMaloaisp(dtgvdsSanpham.CurrentRow.Cells["TenLoai"].Value.ToString());

                cbTenloai1.Enabled = true;
                rdbNam.Enabled = true;
                rdbNamvaNu.Enabled = true;
                rdbNu.Enabled = true;
                txtGiaBan.Enabled = true;
                txtTensp.Enabled = true;
                txtGiaNhap.Enabled = true;
                btnAnhtrc.Enabled = true;
                btnAnhsau.Enabled = true;
                btnLuu.Enabled = false;
                btnThem.Checked = false;
                btnSua.Enabled = true;
            }

        }

        private void txtMasp_KeyDown(object sender, KeyEventArgs e)
        {
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
                txtTim.ForeColor = Color.LightGray;
                txtTim.Text = "--Nhập tên hoặc mã SP--";
                btnTim.Enabled = false;
            }
            else
            {
                txtTim.Text = UpperCase(txtTim.Text.Trim());
            }

        }

        private void cbTenloai1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private bool isNameitemExists(string name)
        {
            List<DTO_Sanpham> Listsp = bussp.ListSP();
            foreach (DTO_Sanpham item in Listsp)
            {
                if(name == item.TenSP)
                {
                    return true;break;
                }
                    
            }
            return false;
        }
        private void UpdateSP(DTO_Sanpham sp)
        {
            if (bussp.UpdateSP(sp))
            {
                MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không cập nhật được rồi đại vương ơi", "Báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbMausac_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnTim_Click(object sender, EventArgs e)
        {
          
            if (btnChitiet.Checked)
            {
                DataTable dt = bussp.FindIteminListCT(txtTim.Text.Trim());
                if (dt.Rows.Count > 0)
                {
                    dtgvdsSanpham.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                DataTable dt = bussp.FindIteminListRG(txtTim.Text.Trim());
                if (dt.Rows.Count > 0)
                {
                    dtgvdsSanpham.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            settingGridview();
        }

        private void txtSl_TextChanged(object sender, EventArgs e)
        {
            if (!nv.checkisNumber(txtSl.Text)) txtSl.Text = "0";
        }

        private void txtGiaNhap_TextChanged(object sender, EventArgs e)
        {
            if (!nv.checkisNumber(txtGiaNhap.Text)) txtGiaNhap.Text = "0";
        }

        private void txtGiaBan_TextChanged(object sender, EventArgs e)
        {
            if (!nv.checkisNumber(txtGiaBan.Text)) txtGiaBan.Text = "0";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(txtMasp.Text.Trim().Length > 0)
            {
                if (MessageBox.Show("Bạn có muốn xóa không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    if (bussp.DeleteSP(txtMasp.Text.Trim(), manv))
                    {
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadForm();
                        TurnOff();
                        AutoCompleteTextbox();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa sản phẩm đã có trong hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Mời bạn nhập mã sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
    #endregion
}
