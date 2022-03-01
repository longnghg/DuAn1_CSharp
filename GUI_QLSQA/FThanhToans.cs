using DTO_QLSQA;
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
    public partial class FThanhToans : Form
    {
        double dongiaban;
        int idColor;// Lấy idMau từ Tên Màu
        int idSize; // Lấy idSize từ Tên size
        double diemtichluy;
        int loadcbsize = 0; // 0 load lần đầu , >1 đã load rồi (hàm fix lỗi load cb)
        int loadcbmau = 0;// 0 load lần đầu , >1 đã load rồi (hàm fix lỗi load cb)
        int soluongsptrongbillmua;
        BUS_KhachHang buskh = new BUS_KhachHang();
        BUS_Nhanvien nv = new BUS_Nhanvien();
        BUS_Sanpham bussp = new BUS_Sanpham();
        BUS_CTSanPham busctsp = new BUS_CTSanPham();
        BUS_HoadonThanhToan bustt = new BUS_HoadonThanhToan();
        BUS_CTDonVanChuyen busctdvc = new BUS_CTDonVanChuyen();
        string manv;
        string mailnv;
        double tongsotien;
        double tiensaugiam;
        int madon;
        List<DTO_CTSanPham> listMau = new List<DTO_CTSanPham>();
        List<DTO_CTSanPham> listSize = new List<DTO_CTSanPham>();
        List<DTO_Hoadonchitiet> listHD = new List<DTO_Hoadonchitiet>();
        List<DTO_CTSanPham> listSLcuaSP = new List<DTO_CTSanPham>();
        public FThanhToans()
        {
            InitializeComponent();
           
        }
        private void settingGridview()
        {
            dataGridView1.Columns["Tongtien"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["Dongia"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["Tongtien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["Dongia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["GiamGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["SoLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["Tensp"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Tongtien"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Tensp"].HeaderText = "Tên sản phẩm";
            dataGridView1.Columns["Tensize"].HeaderText = "Size";
            dataGridView1.Columns["tenmau"].HeaderText = "Màu";
            dataGridView1.Columns["dongia"].HeaderText = "Đơn giá";
            dataGridView1.Columns["soluong"].HeaderText = "SL";
            dataGridView1.Columns["Tongtien"].HeaderText = "Tổng tiền";
            dataGridView1.Columns["giamgia"].HeaderText = "Giảm giá";
        }

        private void FThanhToans_Load(object sender, EventArgs e)
        {
            txtVAT.Text = "10";
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Orange;
            checkboxDiscount.Visible = false;
            txtGiamgia.ReadOnly = true;
            LoadGridview();
            mailnv = FMainnew.mailnv;
            manv = nv.LayMaNV(mailnv).ToString();
            settingGridview();
            Autocomplete();
        }
        private void Autocomplete()
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
        }
        private void rdbvat10_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbvat10.Checked)
            {
                txtVAT.BorderColor = Color.Orange;
                txtVATKHAC.BorderColor = Color.Black;
            }
        }

        private void rdbKhac_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbKhac.Checked)
            {
                txtVATKHAC.BorderColor = Color.Orange;
                txtVAT.BorderColor = Color.Black;
                txtVATKHAC.Enabled = true;
            }
        }
        private void LoadGridview()
        {
            ResetValue();
            lbDiem.Text = "0";
            if (int.Parse(lbDiem.Text) >= 1000)
            {
                checkboxDiscount.Visible = true;
            }
            listHD = bustt.getListHDCT();
            foreach (DTO_Hoadonchitiet item in listHD)
            {
                tongsotien += item.Tongtien;
            }
            txtTongtien.Text = busctsp.GiaTien(tongsotien.ToString());
            dataGridView1.DataSource = bustt.getListHDCT();
            if (dataGridView1.Rows.Count>0)
            {
                txtSDT.Text = dataGridView1.Rows[0].Cells["SDT"].Value.ToString();
                txtSDT.Enabled = false;

                if (dataGridView1.Rows[0].Cells["VAT"].Value.ToString() == "10")
                {
                    rdbvat10.Checked = true;
                    lbVAT.Text = "10 %";
                    rdbvat10.Enabled = false;
                    rdbKhac.Enabled = false;
                }
                else
                {
                    txtVATKHAC.Text = dataGridView1.Rows[0].Cells["VAT"].Value.ToString();
                    rdbKhac.Checked = true;
                    lbVAT.Text = txtVATKHAC.Text + " %";
                    rdbvat10.Enabled = false;
                    rdbKhac.Enabled = false;
                }

            }
            else
            {
                txtSDT.Enabled = true;
            }
            dataGridView1.Columns["Madonmua"].Visible = false;
            dataGridView1.Columns["VAT"].Visible = false;
            dataGridView1.Columns["Ngay"].Visible = false;
            dataGridView1.Columns["Gio"].Visible = false;
            dataGridView1.Columns["MaNV"].Visible = false;
            dataGridView1.Columns["MaSP"].Visible = false;
            dataGridView1.Columns["SDT"].Visible = false;
            if (dataGridView1.Rows.Count > 0)
            {
                txtSDT.Text = dataGridView1.Rows[0].Cells["SDT"].Value.ToString();
                madon = Convert.ToInt32(dataGridView1.Rows[0].Cells["Madonmua"].Value);
            }
            btnSua.Visible = false;
            btnHuy.Visible = false;
            btnDelete.Visible = false;
            
        }
        private void btnThem_Click(object sender, EventArgs e)
        {

            if(nv.checkData(new string[] { txtGiamgia.Text, txtMasp.Text, txtSDT.Text, txtSoluong.Text }))
            {
                if (rdbKhac.Checked)
                {
                    if (txtVATKHAC.Text.Trim().Length > 0)
                    {
                        if (isSamePhoneNumber(txtSDT.Text.Trim()))
                        {
                            if (nv.checkisNumber(txtSDT.Text.Trim()))
                            {
                                if (!nv.hasSpecialChar(txtMasp.Text.Trim()))
                                {
                                    if (cbSize.Texts=="" || cbMausac.Texts == "")
                                    {
                                        MessageBox.Show("Bạn chưa chọn đủ size và màu", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    else
                                    {
                                        if (checkExistsItem(txtMasp.Text.Trim()))
                                        {
                                            // check số lượng mua với số lượng trong kho
                                            listSLcuaSP = busctsp.LoadQuantityBySizeAndColor(txtMasp.Text.Trim(), idSize, idColor);
                                            int sltrongkho = listSLcuaSP[0].SoLuong; // lấy ra số lượng của sp đó trogn kho
                                            soluongsptrongbillmua = bustt.QuantityInBuyingBill(madon, txtMasp.Text.Trim(), idSize, idColor);
                                            if (soluongsptrongbillmua + int.Parse(txtSoluong.Text) <= sltrongkho)
                                            {
                                                if (bustt.addItemsIntoBill(txtMasp.Text.Trim(), manv, txtSDT.Text.Trim(), int.Parse(txtSoluong.Text.Trim()), float.Parse(txtDongia.Text), int.Parse(txtGiamgia.Text), float.Parse(txtVATKHAC.Text), int.Parse(cbMausac.SelectedValue.ToString()), int.Parse(cbSize.SelectedValue.ToString())))
                                                {
                                                    LoadGridview();
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Thêm vào bill thất bại rồi đại vương ơi", "Báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Sản phẩm: " + txtMasp.Text.Trim() + "Chỉ còn: " + sltrongkho, "Vượt quá giới hạn mua", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Mã sản phẩm không tồn tại", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            txtMasp.Focus();
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Mã sản phẩm không hợp lệ", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtMasp.Focus();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Số điện thoại không hợp lệ", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtSDT.Focus();
                            }
                        }
                        else
                        {
                            if (MessageBox.Show("Khách hàng chưa tồn tại, bạn có muốn thêm không?", "Nè bạn nè", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                FAddKH f = new FAddKH(txtSDT.Text.Trim());
                                f.ShowDialog();

                            }

                           
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bạn chưa nhập VAT", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtVATKHAC.Focus();
                    }
                }
                else
                {

                    if (isSamePhoneNumber(txtSDT.Text.Trim()))
                    {
                        if (nv.checkisNumber(txtSDT.Text.Trim()))
                        {
                            if (!nv.hasSpecialChar(txtMasp.Text.Trim()))
                            {
                                if (checkExistsItem(txtMasp.Text.Trim()))
                                {
                                    // check số lượng mua với số lượng trong kho
                                    listSLcuaSP = busctsp.LoadQuantityBySizeAndColor(txtMasp.Text.Trim(), idSize, idColor);
                                    int sltrongkho = listSLcuaSP[0].SoLuong; // lấy ra số lượng của sp đó trogn kho
                                    soluongsptrongbillmua = bustt.QuantityInBuyingBill(madon, txtMasp.Text.Trim(), idSize, idColor);
                                    
                                    if(soluongsptrongbillmua +int.Parse(txtSoluong.Text) <= sltrongkho)
                                    {
                                        if (bustt.addItemsIntoBill(txtMasp.Text.Trim(), manv, txtSDT.Text.Trim(), int.Parse(txtSoluong.Text.Trim()), float.Parse(txtDongia.Text), int.Parse(txtGiamgia.Text), float.Parse(txtVAT.Text), int.Parse(cbMausac.SelectedValue.ToString()), int.Parse(cbSize.SelectedValue.ToString())))
                                        {
                                            LoadGridview();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Thêm vào bill thất bại rồi đại vương ơi", "Báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Sản phẩm: "+txtMasp.Text.Trim()+"Chỉ còn: "+sltrongkho, "Vượt quá giới hạn mua", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    //
                                  
                                }
                                else
                                {
                                    MessageBox.Show("Mã sản phẩm không tồn tại", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txtMasp.Focus();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Mã sản phẩm không hợp lệ", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtMasp.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Số điện thoại không hợp lệ", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtSDT.Focus();
                        }
                    }
                    else
                    {
                        if( MessageBox.Show("Khách hàng chưa tồn tại, bạn có muốn thêm khách hàng này không?", "Nè bạn nè", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            FAddKH f = new FAddKH(txtSDT.Text.Trim());
                            f.ShowDialog();
                            // 
                        }
                       
                    }
                }
            }
            else
            {
                MessageBox.Show("Mời bạn nhập đầy đủ thông tin", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private bool isSamePhoneNumber(string phonenumber)
        {
            List<DTO_KhachHang> listKH = buskh.getListKH();
            foreach (DTO_KhachHang item in listKH)
            {
                if (phonenumber == item.SDT)
                {
                    return true; break;
                }

            }
            return false;
        }
        private void getTTbyPhone(string phonenumber)
        
        {
            List<DTO_KhachHang> listKH = buskh.getListKH();
            foreach (DTO_KhachHang item in listKH)
            {
                if (phonenumber == item.SDT)
                {
                    lbTenKH.Text = item.TEn;
                    lbDiem.Text = item.Diemtichluy.ToString();
                    break;
                }
                else
                {
                    lbTenKH.Text = "";
                    lbDiem.Text = "";
                }
                

            }
        }

        private void txtVATKHAC__TextChanged(object sender, EventArgs e)
        {
            string[] chuoiVatkhac = txtVATKHAC.Text.Split(',');
            // kiểm lỗi (KHông nên theo cách này, nên tạo hàm kiểm lỗi theo ý mình)
            if(chuoiVatkhac.Length < 3) // tránh lỗi có 2 dấu phẩy trong số vd: 12,2,2
            {
                if (txtVATKHAC.Text != " ")
                {
                    if (txtVATKHAC.Text.StartsWith("1") || txtVATKHAC.Text.StartsWith("2") || txtVATKHAC.Text.StartsWith("3") || txtVATKHAC.Text.StartsWith("4") || txtVATKHAC.Text.StartsWith("5") || txtVATKHAC.Text.StartsWith("6") || txtVATKHAC.Text.StartsWith("7") || txtVATKHAC.Text.StartsWith("8") || txtVATKHAC.Text.StartsWith("9"))
                    {
                        if (!hasSpecialChar(txtVATKHAC.Text.Trim()))
                        {
                            if (nv.checkisNumber(txtVATKHAC.Text) || txtVATKHAC.Text.Contains(","))
                            {
                                if (double.Parse(txtVATKHAC.Text.Trim()) > 100) txtVATKHAC.Text = "";
                                else
                                {
                                    if (txtVATKHAC.Text.Length > 6) txtVATKHAC.Text = "";
                                }
                            }
                            else
                            {
                                txtVATKHAC.Text = "";
                            }

                        }
                        else
                        {
                            txtVATKHAC.Text = "";
                        }
                    }
                    else
                    {
                        txtVATKHAC.Text = "";
                    }
                }
                else
                {
                    txtVATKHAC.Text = "";
                }
            }
            else
            {
                txtVATKHAC.Text = "";
            }
           
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            if (txtSDT.Text.Trim().Length >= 10)
            {
                if (nv.checkisNumber(txtSDT.Text.Trim()))
                {
                    if (isSamePhoneNumber(txtSDT.Text.Trim()))
                    {
                        getTTbyPhone(txtSDT.Text.Trim());
                        if (int.Parse(lbDiem.Text) >= 1000)
                        {
                            checkboxDiscount.Visible = true;
                        }
                    }
                }
            }
            else
            {
                lbTenKH.Text = "";
                lbDiem.Text = "0";
            }
        }
        private bool checkExistsItem(string masp)
        {
            List<DTO_Sanpham> listsp = bussp.ListSP();
            foreach (DTO_Sanpham item in listsp)
            {
                if (String.Compare(txtMasp.Text.Trim(), item.MaSP, true) == 0)
                {
                    return true;
                }
            }
            return false;   
        }
        private void getTTbyProductID(string masp)
        {
            List<DTO_Sanpham> listsp = bussp.ListSP();
            foreach (DTO_Sanpham item in listsp)
            {
                if (String.Compare(txtMasp.Text.Trim(),item.MaSP,true) == 0)
                {
                    txtDongia.Text = busctsp.GiaTien(item.DongiaBan.ToString());
                    dongiaban = item.DongiaBan;
                    txtGiamgia.Text = item.GiamGia.ToString();
                    break;
                }
                else
                {
                    txtDongia.Text = "";
                    txtGiamgia.Text = "";
                }
            }
        }
        private void txtMasp_TextChanged(object sender, EventArgs e)
        {
            getTTbyProductID(txtMasp.Text.Trim());
            
            if (checkExistsItem(txtMasp.Text))
            {
                listSize = busctsp.ShowSizeofItem1(txtMasp.Text);
                cbSize.DataSource = listSize;
                cbSize.DisplayMember = "tensize";
                cbSize.ValueMember = "size";
                cbSize.Enabled = true;
                cbMausac.Enabled = true;
                idSize = int.Parse(cbSize.SelectedValue.ToString());
                listMau = busctsp.ShowColorBySize1(txtMasp.Text,idSize) ;
                cbMausac.DataSource = listMau;
                cbMausac.DisplayMember = "tenmau";
                cbMausac.ValueMember = "mamau";
                         // lấy sl dựa vào size , màu , mã ssp
                // Lấy ra id màu mới mỗi lần thay đổi
                idColor = Convert.ToInt32(cbMausac.SelectedValue);
                listSLcuaSP = busctsp.LoadQuantityBySizeAndColor(txtMasp.Text.Trim(), idSize, idColor);
                if (listSLcuaSP[0].SoLuong <= 0)
                {
                    lbsl.Visible = true;
                    btnThem.Enabled = false;
                }
                else
                {
                    lbsl.Visible = false;
                    btnThem.Enabled = true;
                }
            }
            else
            {
                cbSize.DataSource = default;
                cbMausac.DataSource = default;
                cbMausac.Enabled = false;
                cbSize.Enabled = false;
                lbsl.Visible = false;
            }

        }
        private void txtSoluong_TextChanged(object sender, EventArgs e)
        {
            if (!nv.checkisNumber(txtSoluong.Text.Trim()))
            {
                txtSoluong.Text = "";
            }
        }

       

        private void btnXacnhan_CheckedChanged(object sender, EventArgs e)
        {
            if (btnXacnhan.Checked)
                btnThanhToan.Enabled = true;
            else btnThanhToan.Enabled = false;  
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc là muốn thanh toán không?", "Nè bạn nè", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (checkboxDiscount.Checked)
                {
                    if (bustt.PressBtnthanhToan(true,txtSDT.Text.Trim()))
                    {
                        MessageBox.Show("Thanh toán thành công?", "Nè bạn nè", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        diemtichluy = tongsotien / 10000;
                        buskh.AddDiem(txtSDT.Text, diemtichluy);
                        LoadGridview();
                        diemtichluy = 0;
                    }
                    else
                    {
                        MessageBox.Show("Thanh toán không thành công?", "Báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (bustt.PressBtnthanhToan(false, txtSDT.Text.Trim()))
                    {
                        MessageBox.Show("Thanh toán thành công?", "Nè bạn nè", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        diemtichluy = tongsotien / 10000;
                        buskh.AddDiem(txtSDT.Text, diemtichluy);
                        LoadGridview();
                        diemtichluy = 0;
                    }
                    else
                    {
                        MessageBox.Show("Thanh toán không thành công?", "Báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                LoadGridview();
               
            }
        }


    

        private void cbSize_Leave(object sender, EventArgs e)
        {
            if(checkExistsItem(txtMasp.Text.Trim()))
            {
                listMau = busctsp.ShowColorBySize1(txtMasp.Text, int.Parse(cbSize.SelectedValue.ToString()));
                cbMausac.DataSource = listMau;
                cbMausac.DisplayMember = "tenmau";
                cbMausac.ValueMember = "mamau";
            }    
                
        }

        private void cbSize_OnSelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbSize.Texts !="")
            {
                // fix lỗi không load được combobox màu
                if (loadcbsize > 1) // sau khi cbsize đã load xong hoàn toàn thì thực hiện
                {
                    // Lấy ra id size mới mỗi lần thay đổi
                    idSize = int.Parse(cbSize.SelectedValue.ToString());
                    listMau = busctsp.ShowColorBySize1(txtMasp.Text, idSize);
                    cbMausac.DataSource = listMau;
                    // lấy ra số lượng dựa vào size, màu và masp
                    idColor = Convert.ToInt32(cbMausac.SelectedValue);
                    listSLcuaSP = busctsp.LoadQuantityBySizeAndColor(txtMasp.Text.Trim(), idSize, idColor);
                }
                else
                {
                    loadcbsize++;
                }
            }
            
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count>0)
            {
                int rowindex = dataGridView1.CurrentCell.RowIndex;
                txtSDT.Text = dataGridView1.Rows[rowindex].Cells["SDT"].Value.ToString();
                txtMasp.Text = dataGridView1.Rows[rowindex].Cells["Masp"].Value.ToString();
                idSize = busctdvc.getIDSize(dataGridView1.Rows[rowindex].Cells["Tensize"].Value.ToString());
                cbSize.SelectedValue = idSize;
                idColor = busctdvc.getIDColor(dataGridView1.Rows[rowindex].Cells["Tenmau"].Value.ToString());
                cbMausac.SelectedValue = idColor;
                txtSoluong.Text = dataGridView1.Rows[rowindex].Cells["soluong"].Value.ToString();
                txtGiamgia.Text = dataGridView1.Rows[rowindex].Cells["giamgia"].Value.ToString();
                madon = int.Parse(dataGridView1.Rows[rowindex].Cells["MaDonMua"].Value.ToString());
                if (dataGridView1.Rows[rowindex].Cells["VAT"].Value.ToString() == "10")
                {
                    rdbvat10.Checked = true;
                }
                else
                {
                    rdbKhac.Checked = true;
                }
                txtMasp.Enabled = false;
                btnSua.Visible = true;
                btnHuy.Visible = true;
                btnDelete.Visible = true;
                cbMausac.Enabled = false;
                cbSize.Enabled = false;
            }

        }
        private void ResetValue()
        {
            lbTenKH.Text = "";
            lbDiem.Text = "0";
            btnXacnhan.Checked = false;
            txtTongtien.Text = "";
            txtSDT.Text = "";
            txtMasp.Text = "";
            cbMausac.DataSource = default;
            cbSize.DataSource = default;
            txtSoluong.Text = "";
            txtDongia.Text = "";
            txtGiamgia.Text = "";
            tongsotien = 0;
            checkboxDiscount.Checked = false;
            checkboxDiscount.Visible = false;
            rdbvat10.Enabled = true;
            rdbKhac.Enabled = true;
            lbVAT.Text = "...";
        }

        private void checkboxDiscount_Click(object sender, EventArgs e)
        {
            if(checkboxDiscount.Checked == false)
            {
                if (MessageBox.Show("Bạn có muốn sử dụng 1000 điểm để giảm 10% tổng hóa đơn ?", "Nè bạn nè", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    checkboxDiscount.Checked = true;
                    tiensaugiam = tongsotien;
                    txtTongtien.Text = busctsp.GiaTien((tiensaugiam - ((tiensaugiam * 10) / 100)).ToString());
                }
            }
            else
            {
                checkboxDiscount.Checked = false;
                txtTongtien.Text = busctsp.GiaTien(tongsotien.ToString());
            }
           
           
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            idColor = int.Parse(cbMausac.SelectedValue.ToString());
            // check số lượng mua với số lượng trong kho
            listSLcuaSP = busctsp.LoadQuantityBySizeAndColor(txtMasp.Text.Trim(), idSize, idColor);
            MessageBox.Show(listSLcuaSP[0].SoLuong.ToString());
            int sltrongkho = listSLcuaSP[0].SoLuong; // lấy ra số lượng của sp đó trogn kho
            MessageBox.Show("sản phẩm trong bill" + soluongsptrongbillmua.ToString());
            if (int.Parse(txtSoluong.Text) <= sltrongkho)
            {
                if (bustt.UpdateQuantity(txtMasp.Text.Trim(), madon, idColor, idSize, int.Parse(txtSoluong.Text.Trim())))
                {
                    MessageBox.Show("Thao tác thành công", "Tôi báo cậu tin vui", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thao tác không thành công", "Tôi báo cậu tin buồn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                LoadGridview();
            }
            else
            {
                MessageBox.Show("Sản phẩm: " + txtMasp.Text.Trim() + "Chỉ còn: " + sltrongkho, "Vượt quá giới hạn mua", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            LoadGridview();
        }

        private void cbMausac_OnSelectedIndexChanged(object sender, EventArgs e)
        {
           
            // fix lỗi  load  combobox màu
            if (loadcbmau > 1) // sau khi cbmau đã load xong hoàn toàn thì thực hiện
            {
                // Lấy ra id màu mới mỗi lần thay đổi
                if(cbMausac.SelectedValue != null)
                {
                    idColor = Convert.ToInt32(cbMausac.SelectedValue);
                    listSLcuaSP = busctsp.LoadQuantityBySizeAndColor(txtMasp.Text.Trim(), idSize, idColor);
                    if (listSLcuaSP[0].SoLuong <= 0)
                    {
                        lbsl.Visible = true;
                        btnThem.Enabled = false;
                    }
                    else
                    {
                        lbsl.Visible = false;
                        btnThem.Enabled = true;
                    }

                }
               
            }
            else
            {
                loadcbmau++;
            }

        }

   
        public bool hasSpecialChar(string input)
        {
            string specialChar = @"\|!#$%&/()=?»«@£§€{}.-;'<>_";
            foreach (var item in specialChar)
            {
                if (input.Contains(item))
                {
                    return true;
                }
            }

            return false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn xóa sản phẩm này ra khỏi bill không?", "Hỏi đáp", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (bustt.DeleteItemInBuyingBill(txtMasp.Text.Trim()))
                {
                    MessageBox.Show("Thao tác thành công", "Tôi báo cậu tin vui", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thao tác không thành công", "Tôi báo cậu tin buồn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
            LoadGridview();
        }
    }
}
// 
//if (MessageBox.Show("Bạn muốn sử dụng 1000 điểm để giảm giá 10% tổng hóa đơn \n từ " + tongsotien.ToString() + "xuống" + tiensaugiam.ToString(), "Nè bạn nè", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)