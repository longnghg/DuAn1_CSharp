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
    public partial class FVanchuyen : Form
    {
        BUS_DonVanChuyen busdvc = new BUS_DonVanChuyen();
        BUS_Nhanvien nv = new BUS_Nhanvien();
        BUS_Sanpham sp = new BUS_Sanpham();
        BUS_CTDonVanChuyen busctdvc = new BUS_CTDonVanChuyen();
        int id = 0;
        int idmax ;
        int idmin;
        int rowindex;
        // properties để  cập nhật ctdvc
        string maspcu;
        int sizecu;
        int mamaucu;
        string maspmoi;
        int sizemoi;
        int mamaumoi;
        int madonnhap;
        string manv;
        int soluong;
        public FVanchuyen()
        {
            InitializeComponent();
        }

        private void FVanchuyen_Load(object sender, EventArgs e)
        {
                loadGridview();
            if (dataGridView1.Rows.Count > 1)
            {
                idmax = busctdvc.getMaxIDDVC();
                idmin = busctdvc.getMinIDDVC();
            }
                loadDataTimePicker();    
                manv = nv.LayMaNV(FMainnew.mailnv).ToString();
                dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Orange;
                 btnTim.BackColor = Color.White;
                
        }
        private void loadGridview()
        {
            dataGridView1.DataSource = busctdvc.loadDSDVC();
            dataGridView1.Columns[0].HeaderText = "Mã Đơn";
            dataGridView1.Columns[1].HeaderText = "Mã SP";
            dataGridView1.Columns[2].HeaderText = "Mã NV";
            dataGridView1.Columns[3].HeaderText = "Size";
            dataGridView1.Columns[4].HeaderText = "Màu";
            dataGridView1.Columns[5].HeaderText = "Số Lượng";
            dataGridView1.Columns[6].HeaderText = "Ngày";
            dataGridView1.Columns[7].HeaderText = "Giờ";
        }

        private void loadDataTimePicker()
        {
            DateTime today = DateTime.Now;
            dtpngaybd.Value = new DateTime(today.Year, today.Month, 1);
            dtpNgaykt.Value = dtpngaybd.Value.AddMonths(1).AddDays(-1);
        }

        private void txtMadon_TextChanged(object sender, EventArgs e)
        {
            if (nv.checkisNumber(txtMadon.Text.Trim()))
            {
                loadGridview();
                if (txtMadon.Text.Trim().Length > 0)
                {
                    dataGridView1.DataSource = busctdvc.loadDSDVCtheoMaDon(int.Parse(txtMadon.Text.Trim()));
                    id = int.Parse(txtMadon.Text.Trim());
                    if(id > idmax)
                    {
                        id = idmax;
                        txtMadon.Text = id.ToString();
                    }
                    if (id == 0)
                    {
                        id = idmin;
                        txtMadon.Text = id.ToString();
                    }
                    if (dataGridView1.Rows.Count == 1)
                    {
                        loadGridview();
                    }
                }
            }
            else
            {
                txtMadon.Text = "";
            }

        }

        private void iconRight_Click(object sender, EventArgs e)
        {
            // nếu mà không nhập mã hóa đơn
            if(id == 0)
            {
                txtMadon.Text = idmin.ToString();
            }
            else
            {
                id++;
                if (id > idmax)
                {
                    txtMadon.Text = idmax.ToString();
                    id = idmax;
                }
                else
                {
                    txtMadon.Text = id.ToString();
                }
            }
           
        }

        private void iconDoubleRight_Click(object sender, EventArgs e)
        {
            txtMadon.Text = idmax.ToString();
        }

        private void iconLeft_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                id = idmin;
                txtMadon.Text = id.ToString();
            }
            else
            {
                if (id > idmin)
                {
                    id--;
                    txtMadon.Text = id.ToString();
                    if (id < idmin)
                    {
                        txtMadon.Text = idmin.ToString();
                        id = idmin;
                    }

                }
            }
        }
        private void iconDoubleLeft_Click(object sender, EventArgs e)
        {
            txtMadon.Text = idmin.ToString();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = busctdvc.loadDVCFromDateToDate(dtpngaybd.Value, dtpNgaykt.Value);
            txtMadon.Text = "";
        }

        private void btnTailai_Click(object sender, EventArgs e)
        {
            loadGridview();
            loadDataTimePicker();
            txtMadon.Text = "";
            btnTim.BackColor = Color.White;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.Rows.Count > 0)
            {
                if (dataGridView1.CurrentRow.Cells["masp"].Value != null)
                {
                    rowindex = dataGridView1.CurrentCell.RowIndex;
                    if (dataGridView1.Rows[rowindex].Cells["masp"].Value.ToString() != "")
                    {
                        madonnhap = int.Parse(dataGridView1.Rows[rowindex].Cells["madonnhap"].Value.ToString());
                        maspcu = dataGridView1.Rows[rowindex].Cells["masp"].Value.ToString();
                        mamaucu = busctdvc.getIDColor(dataGridView1.Rows[rowindex].Cells["tenmau"].Value.ToString());
                        sizecu = busctdvc.getIDSize(dataGridView1.Rows[rowindex].Cells["TenSize"].Value.ToString());
                        soluong = int.Parse(dataGridView1.Rows[rowindex].Cells["soluong"].Value.ToString());
                    }
                }
            }
            
    
        }
   

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                if (dataGridView1.Rows[rowindex].Cells["masp"].Value.ToString() != "")
                {
                    FChinhSuaCTDVC f = new FChinhSuaCTDVC(maspcu, mamaucu, sizecu, soluong, madonnhap, manv);
                    f.ShowDialog();
                    loadGridview();
                }
            }
           
            
        }

        private void dtpNgaykt_ValueChanged(object sender, EventArgs e)
        {
            btnTim.BackColor = Color.DarkOrange;
        }

        public void ExportExcelDVC(List<DTO_ChiTietDVC>list )
        {
            string filePath = "";
            // tạo SaveFileDialog để lưu file excel
            SaveFileDialog dialog = new SaveFileDialog();
          
            // chỉ lọc ra các file có định dạng Excel
            dialog.Filter = "Excel | *.xlsx | Excel 2003 | *.xls";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                filePath = dialog.FileName;
            }
            // nếu đường dẫn null hoặc rỗng thì báo không hợp lệ và return hàm
            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("Đường dẫn báo cáo không hợp lệ");
                return;
            }
            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            try
            {
                using (ExcelPackage p = new ExcelPackage())
                {
                    // đặt tên người tạo file
                    p.Workbook.Properties.Author = "HoangLong";

                    // đặt tiêu đề cho file
                    p.Workbook.Properties.Title = "Báo cáo thống kê";

                    //Tạo một sheet để làm việc trên đó
                    p.Workbook.Worksheets.Add("HoangLongExcel");

                    // lấy sheet vừa add ra để thao tác
                    ExcelWorksheet ws = p.Workbook.Worksheets[0];

                    // đặt tên cho sheet
                    ws.Name = "Hlong sheet";
                    // fontsize mặc định cho cả sheet
                    ws.Cells.Style.Font.Size = 14;
                    // font family mặc định cho cả sheet
                    ws.Cells.Style.Font.Name = "Calibri";
                    string[] arrColumnHeader = new string[dataGridView1.Columns.Count];
                    //string[] arrColumnHeader = {
                    //                            "Mã đơn",
                    //                            "Tên sản phẩm",
                    //                            "Mã NV",
                    //                            "Tên size",
                    //                            "Tên màu",
                    //                            "Số lượng",
                    //                            "Ngày",
                    //                            "Giờ"
                    //};
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        arrColumnHeader[i] = dataGridView1.Columns[i].HeaderText;
                    }
                    // lấy ra số lượng cột cần dùng dựa vào số lượng header
                    var countColHeader = arrColumnHeader.Count();

                    // merge các column lại từ column 1 đến số column header
                    // gán giá trị cho cell vừa merge là Thống kê thông tni User Kteam
                    ws.Cells[1, 1].Value = "Thống kê đơn nhập hàng";
                    ws.Cells[1, 1, 1, countColHeader].Merge = true;
                    // in đậm
                    ws.Cells[1, 1, 1, countColHeader].Style.Font.Bold = true;
                    // căn giữa
                    ws.Cells[1, 1, 1, countColHeader].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    int colIndex = 1;
                    int rowIndex = 2;

                    //tạo các header từ column header đã tạo từ bên trên
                    foreach (var item in arrColumnHeader)
                    {
                        var cell = ws.Cells[rowIndex, colIndex];

                        //set màu thành gray
                        var fill = cell.Style.Fill;
                        fill.PatternType = ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);

                        //căn chỉnh các border
                        var border = cell.Style.Border;
                        border.Bottom.Style =
                            border.Top.Style =
                            border.Left.Style =
                            border.Right.Style = ExcelBorderStyle.Thin;

                        //gán giá trị
                        cell.Value = item;

                        colIndex++;
                    }


                    // với mỗi item trong danh sách sẽ ghi trên 1 dòng
                    foreach (DTO_ChiTietDVC item in list)
                    {
                        // bắt đầu ghi từ cột 1. Excel bắt đầu từ 1 không phải từ 0
                        colIndex = 1;

                        // rowIndex tương ứng từng dòng dữ liệu
                        rowIndex++;

                        //gán giá trị cho từng cell                      
                        ws.Cells[rowIndex, colIndex++].Value = item.Madonnhap;

                        // lưu ý phải .ToShortDateString để dữ liệu khi in ra Excel là ngày như ta vẫn thấy.Nếu không sẽ ra tổng số :v
                        ws.Cells[rowIndex, colIndex++].Value = item.Tensp;
                        ws.Cells[rowIndex, colIndex++].Value = item.Manv;
                        ws.Cells[rowIndex, colIndex++].Value = item.Tensize;
                        ws.Cells[rowIndex, colIndex++].Value = item.Tenmau;
                        ws.Cells[rowIndex, colIndex++].Value = item.Soluong;
                        ws.Cells[rowIndex, colIndex++].Value = item.Ngay;
                        ws.Cells[rowIndex, colIndex++].Value = item.Gio;
                    }

                    //Lưu file lại
                    Byte[] bin = p.GetAsByteArray();
                    File.WriteAllBytes(filePath, bin);
                }
                MessageBox.Show("Xuất excel thành công!");
            }
            catch (Exception EE)
            {
                MessageBox.Show(EE.ToString());
                MessageBox.Show("Có lỗi khi lưu file!");
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            List<DTO_ChiTietDVC> list = new List<DTO_ChiTietDVC>();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DTO_ChiTietDVC ctdvc = new DTO_ChiTietDVC();
                ctdvc.Madonnhap = int.Parse(dataGridView1.Rows[i].Cells["Madonnhap"].Value.ToString());
                ctdvc.Tensp = sp.GetNameByID(dataGridView1.Rows[i].Cells["Masp"].Value.ToString());
                ctdvc.Manv = dataGridView1.Rows[i].Cells["Manv"].Value.ToString();
                ctdvc.Tensize = dataGridView1.Rows[i].Cells["TenSize"].Value.ToString();
                ctdvc.Tenmau = dataGridView1.Rows[i].Cells["tenmau"].Value.ToString();
                ctdvc.Soluong = int.Parse(dataGridView1.Rows[i].Cells["Soluong"].Value.ToString());
                ctdvc.Ngay = dataGridView1.Rows[i].Cells["ngay"].Value.ToString();
                ctdvc.Gio = dataGridView1.Rows[i].Cells["Gio"].Value.ToString();
                list.Add(ctdvc);
            }

            ExportExcelDVC(list);
        }
    }
}
