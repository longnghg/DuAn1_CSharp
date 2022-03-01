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
    public partial class FThongKeCT : Form
    {
        int month;
        int day = 1;
        int dauthang;
        int cuoithang;
        int year;
        double tongtien = 0;
        BUS_Nhanvien nv = new BUS_Nhanvien();
        BUS_Sanpham sp = new BUS_Sanpham();
        BUS_Doanhthu busdt = new BUS_Doanhthu();
        BUS_CTSanPham ctsp = new BUS_CTSanPham();
        public FThongKeCT(int thang, int nam)
        {
            InitializeComponent();
            month = thang;
            year = nam;
            DateTime today = DateTime.Now;
            dauthang = 1;
            DateTime curMonth = new DateTime(today.Year, today.Month, 1);
            cuoithang = curMonth.AddMonths(1).AddDays(-1).Day;
            lbthang.Text = thang.ToString();
            lbnam.Text = nam.ToString();
        }
        private void settingGridview_dt()
        {
            dataGridView1.Columns["Ngay"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Tongtien"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["TongTien"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["TongTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["Gio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Madonmua"].HeaderText = "Mã đơn mua";
            dataGridView1.Columns["Ngay"].HeaderText = "Ngày";
            dataGridView1.Columns["Gio"].HeaderText = "Giờ";
            dataGridView1.Columns["TongTien"].HeaderText = "Tổng tiền";
        }
        private void settingGridview_cp()
        {
            dataGridView1.Columns["Ngay"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Tongtiennhap"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Dongianhap"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Tongtiennhap"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["Tongtiennhap"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["Dongianhap"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["Dongianhap"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["TongSL"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["Madonnhap"].HeaderText = "Mã đơn nhập";
            dataGridView1.Columns["Ngay"].HeaderText = "Ngày";
            dataGridView1.Columns["Gio"].HeaderText = "Giờ";
            dataGridView1.Columns["Tensp"].HeaderText = "Tên SP";
            dataGridView1.Columns["Dongianhap"].HeaderText = "Đơn giá Nhập";
            dataGridView1.Columns["TongSL"].HeaderText = "Tổng SL";
            dataGridView1.Columns["TongTienNhap"].HeaderText = "Tổng tiền Nhập";
        }
        private void FThongKeCT_Load(object sender, EventArgs e)
        {
            rdbdoanhthu.Checked = true;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Orange;
            rdbThang.Checked = true;
        }
        private void loadgridview_dt(DataTable tb)
        {
            tongtien = 0;
            dataGridView1.DataSource = tb;
            settingGridview_dt();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                tongtien += double.Parse(dataGridView1.Rows[i].Cells["Tongtien"].Value.ToString());
            }
            lbTongtien.Text = ctsp.GiaTien(tongtien.ToString()) + " VNĐ";
        }
        private void loadgridview_cp(DataTable tb)
        {
            tongtien = 0;
            dataGridView1.DataSource = tb;
            settingGridview_cp();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                tongtien += double.Parse(dataGridView1.Rows[i].Cells["Tongtiennhap"].Value.ToString());
            }
            lbTongtien.Text = ctsp.GiaTien(tongtien.ToString()) + " VNĐ";
        }
        private void rdbThang_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbngay.Checked) // xét theo ngày
            {
                nmrDay.Visible = true;
                btnFind.Visible = true;
                
                if (rdbdoanhthu.Checked) // xét theo doanh thu
                {
                    if (busdt.LoadMinDay(month, year) > 0)
                    {
                        day = busdt.LoadMinDay(month, year);
                    }
                    else
                    {
                        day = 1;
                    }
                    loadgridview_dt(busdt.getlistbyDayinMonth(month, day, year));
                }
                else // xét theo chi phí
                {
                    if (busdt.LoadMinDayDVC(month, year) > 0)
                    {
                        day = busdt.LoadMinDayDVC(month, year);
                    }
                    else
                    {
                        day = 1;
                    }
                    
                    loadgridview_cp(busdt.getlistDVCbyDayinMonth(month, day, year));
                }
                nmrDay.Value = day;
                lbNgay.Visible = true;
                lbsongay.Visible = true;
                lbsongay.Text = day.ToString();
            }
            else // xét theo tháng
            {
                nmrDay.Visible = false;
                btnFind.Visible = false;
                if (rdbdoanhthu.Checked) // xét theo doanh thu
                {
                    loadgridview_dt(busdt.getlistbyMonth(month, year));
                }
                else // xét theo chi phí
                {
                    loadgridview_cp(busdt.getlistDVCbyMonth(month, year));
                }
                lbNgay.Visible = false;
                lbsongay.Visible = false;
            }
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            if (nmrDay.Value > 0)
            {
                day = Convert.ToInt32(nmrDay.Value);
                if (rdbdoanhthu.Checked) // xét theo doanh thu
                {
                    loadgridview_dt(busdt.getlistbyDayinMonth(month,day, year));
                }
                else // xét theo chi phí
                {
                    loadgridview_cp(busdt.getlistDVCbyDayinMonth(month, day, year));
                }
            }
           
        }
        private void nmrDay_KeyUp(object sender, KeyEventArgs e)
        {
            if (nv.checkisNumber(nmrDay.Value.ToString()))
            {
                if(nmrDay.Value > cuoithang)
                {
                    nmrDay.Value = cuoithang;
                }
            }
            else
            {
                nmrDay.Value = 0;
            }
        }

        private void rdbdoanhthu_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbdoanhthu.Checked)
            {
                nmrDay.Value = 0;
                day = 1;
                rdbThang.Checked = true;
                loadgridview_dt(busdt.getlistbyMonth(month, year));
            }
            else
            {
                nmrDay.Value = 0;
                day = 1;
                rdbThang.Checked = true;
                loadgridview_cp(busdt.getlistDVCbyMonth(month, year));
            }
        }
        private void label6_Click(object sender, EventArgs e)
        {
            if (rdbChiphi.Checked)
            {
                List<DTO_ThongkeCP> list = new List<DTO_ThongkeCP>();
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DTO_ThongkeCP ctdvc = new DTO_ThongkeCP();
                    ctdvc.Madonnhap = int.Parse(dataGridView1.Rows[i].Cells["Madonnhap"].Value.ToString());
                    ctdvc.Ngay = dataGridView1.Rows[i].Cells["Ngay"].Value.ToString();
                    ctdvc.Gio = dataGridView1.Rows[i].Cells["Gio"].Value.ToString();
                    ctdvc.Tensp = dataGridView1.Rows[i].Cells["Tensp"].Value.ToString();
                    ctdvc.Soluong = int.Parse(dataGridView1.Rows[i].Cells["Tongsl"].Value.ToString());
                    ctdvc.Dongia = double.Parse(dataGridView1.Rows[i].Cells["dongianhap"].Value.ToString());
                    ctdvc.Tongtien = double.Parse(dataGridView1.Rows[i].Cells["Tongtiennhap"].Value.ToString());
                    list.Add(ctdvc);
                }
                ExportExcelTKCP(list);
            }
            else
            {
                List<DTO_ThongkeDT> list = new List<DTO_ThongkeDT>();
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DTO_ThongkeDT ctdt = new DTO_ThongkeDT();
                    ctdt.Madonmua = int.Parse(dataGridView1.Rows[i].Cells["madonmua"].Value.ToString());
                    ctdt.Ngay = dataGridView1.Rows[i].Cells["Ngay"].Value.ToString();
                    ctdt.Gio = dataGridView1.Rows[i].Cells["Gio"].Value.ToString();
                    ctdt.Tongtien = float.Parse(dataGridView1.Rows[i].Cells["Tongtien"].Value.ToString());
                    list.Add(ctdt);
                }
                ExportExcelTKDT(list);
            }
            
        }
        // hàm xuất excel doanh thu
        public void ExportExcelTKCP(List<DTO_ThongkeCP> list)
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
                    string[] arrColumnHeader = new string[7];
                    for (int i = 0; i < 7; i++)
                    {
                      arrColumnHeader[i] = dataGridView1.Columns[i].HeaderText;
                    }


                    // lấy ra số lượng cột cần dùng dựa vào số lượng header
                    var countColHeader = arrColumnHeader.Count();

                    // merge các column lại từ column 1 đến số column header
                    // gán giá trị cho cell vừa merge là Thống kê thông tni User 
                    ws.Cells[1, 1].Value = "Thống kê đơn mua hàng";
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
                    foreach (DTO_ThongkeCP item in list)
                    {
                        // bắt đầu ghi từ cột 1. Excel bắt đầu từ 1 không phải từ 0
                        colIndex = 1;

                        // rowIndex tương ứng từng dòng dữ liệu
                        rowIndex++;

                        //gán giá trị cho từng cell                      
                        ws.Cells[rowIndex, colIndex++].Value = item.Madonnhap;
                        ws.Cells[rowIndex, colIndex++].Value = item.Ngay;
                        ws.Cells[rowIndex, colIndex++].Value = item.Gio;
                        ws.Cells[rowIndex, colIndex++].Value = item.Tensp;
                        ws.Cells[rowIndex, colIndex++].Value = item.Soluong;
                        ws.Cells[rowIndex, colIndex++].Value = item.Dongia;
                        ws.Cells[rowIndex, colIndex++].Value = item.Tongtien;
                    }
                    // chi tiết
                   
                        ws.Cells["F3:F" + rowIndex.ToString()].Style.Numberformat.Format = "#,##0";
                        ws.Cells["G3:G" + rowIndex.ToString()].Style.Numberformat.Format = "#,##0";
                        ws.Columns[2].Width = 20;
                        ws.Columns[3].Width = 15;
                        ws.Columns[4].Width = 40;
                        ws.Columns[6].Width = 20;
                        ws.Columns[7].Width = 30;
                        ws.Cells[rowIndex + 2, 6].Value = "Tổng: ";
                        ws.Cells[rowIndex + 2, 7].Formula = $"SUM(G3:G{rowIndex.ToString()})";
                        ws.Cells["G" + (rowIndex + 2).ToString()].Style.Numberformat.Format = "#,##0";
                         ws.Cells["G" + (rowIndex + 2).ToString()].Style.Fill.PatternType = ExcelFillStyle.Solid;
                         ws.Cells["G" + (rowIndex + 2).ToString()].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);
                    //Lưu file lại
                    Byte[] bin = p.GetAsByteArray();
                    File.WriteAllBytes(filePath, bin);
                }
                MessageBox.Show("Xuất excel thành công!");
            }
            catch (Exception EE)
            {
                MessageBox.Show("Có lỗi khi lưu file!");
            }
        }
        // hàm xuất excel chi tiết
        public void ExportExcelTKDT(List<DTO_ThongkeDT> list)
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
                    ws.Cells[1, 1].Value = "Thống kê tổng doanh thu";
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
                    foreach (DTO_ThongkeDT item in list)
                    {
                        // bắt đầu ghi từ cột 1. Excel bắt đầu từ 1 không phải từ 0
                        colIndex = 1;

                        // rowIndex tương ứng từng dòng dữ liệu
                        rowIndex++;

                        //gán giá trị cho từng cell                      
                        ws.Cells[rowIndex, colIndex++].Value = item.Madonmua;
                        ws.Cells[rowIndex, colIndex++].Value = item.Ngay;
                        ws.Cells[rowIndex, colIndex++].Value = item.Gio;
                        ws.Cells[rowIndex, colIndex++].Value = item.Tongtien;
                    }
                    ws.Cells["D3:D" + rowIndex.ToString()].Style.Numberformat.Format = "#,##0";
                    ws.Columns[2].Width = 20;
                    ws.Columns[3].Width = 15;
                    ws.Columns[4].Width = 40;
                    ws.Cells[rowIndex+2, 3].Value = "Tổng: ";
                    ws.Cells[rowIndex+2, 4].Formula = $"SUM(D3:D{rowIndex.ToString()})";
                    ws.Cells["D" + (rowIndex + 2).ToString()].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    ws.Cells["D" + (rowIndex + 2).ToString()].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);
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

        private void btnExits_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void label1_Click(object sender, EventArgs e)
        {
            if (rdbdoanhthu.Checked)
            {
                if (rdbThang.Checked)
                {
                    CrystalReportDoanhThu r = new CrystalReportDoanhThu();
                    r.SetDataSource(busdt.getlistbyMonth(month, year));
                    FReportHDCT rp = new FReportHDCT();
                    rp.crystalReportViewer1.ReportSource = r;
                    rp.ShowDialog();
                }
                else
                {

                    CrystalReportDoanhThuByDay r = new CrystalReportDoanhThuByDay();
                    r.SetDataSource(busdt.getlistbyDayinMonth(month, day, year));
                    FReportHDCT rp = new FReportHDCT();
                    rp.crystalReportViewer1.ReportSource = r;
                    rp.ShowDialog();
                }
            }
            else
            {
                if (rdbThang.Checked)
                {
                    CrystalReportChiPhi r = new CrystalReportChiPhi();
                    r.SetDataSource(busdt.getlistDVCbyMonth(month, year));
                    FReportHDCT rp = new FReportHDCT();
                    rp.crystalReportViewer1.ReportSource = r;
                    rp.ShowDialog();
                }
                else
                {
                    CrystalReportChiPhiByDay r = new CrystalReportChiPhiByDay();
                    r.SetDataSource(busdt.getlistDVCbyDayinMonth(month, day, year));
                    FReportHDCT rp = new FReportHDCT();
                    rp.crystalReportViewer1.ReportSource = r;
                    rp.ShowDialog();
                }

            }
        }
    }
}
