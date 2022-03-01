using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QLSQA;
using DAO_QLSQA;
using System.Data;
using DTO_QLSQA;
namespace BUS_QLSQA
{
    public class BUS_Sanpham
    {
        DAO_Sanpham daosanpham = new DAO_Sanpham();
        public string GetNameByID(string masp)
        {
            return daosanpham.GetNameByID(masp);
        }
        public DataTable FindIteminListRG(string keyword)
        {
            return daosanpham.FindIteminListRG(keyword);
        }
        //Tìm kiếm sản phẩm (chi tiết)
        public DataTable FindIteminListCT(string keyword)
        {
            return daosanpham.FindIteminListCT(keyword);
        }
        public DataTable FindItemSale(string keyword)
        {
            return daosanpham.FindItemSale(keyword);
        }
        //Tìm kiếm sản phẩm cho bảng giảm giá (ko giam)
        public DataTable FindItemNoSale(string keyword)
        {
            return daosanpham.FindItemNoSale(keyword);
        }
        public bool NOTchangeNameItem(string masp, string tensp)
        {
            return daosanpham.NOTchangeNameItem(masp, tensp);
        }
        public bool UpdateSP(DTO_Sanpham sp)
        {
            return daosanpham.UpdateSP(sp);
        }
        public string getMaloaisp(string tenloai)
        {
            return daosanpham.getMaloaisp(tenloai);
        }
        public DataTable DSSPAfterFindForSale(string keyword)
        {
            return daosanpham.DSSPAfterFindForSale(keyword);
        }
        public bool UpdateSalesAllProduct(int sales)
        {
            return daosanpham.UpdateSalesAllProduct( sales);
        }
        public bool UpdateSales( int sales , string masp)
        {
            return daosanpham.UpdateSales( sales , masp);
        }
        public DataTable DSSPDangGiamGia()
        {
            return daosanpham.DSSPDangGiamGia(true);
        }
        public DataSet DSSPKhongGiamGia()
        {
            return daosanpham.DSSPKhongGiamGia(false);
        }
        public bool DeleteSP(string masp, string manv)
        {
            return daosanpham.DeleteSP(masp, manv);
        }
        public bool ThemSP(DTO_Sanpham sp, string manv)
        {
            return daosanpham.ThemSP(sp, manv);
        }
        public DataTable hienthiDSSP()
        {
            return daosanpham.hienthiDSSP();
        }
        public DataTable hienthiDSSP_rutgon()
        {
            return daosanpham.hienthiDSSP_rutgon();
        }
        public List<DTO_Sanpham> LoadShowListImage()
        {
            return daosanpham.ShowListImage();
        }
        public DataTable hienthiCombobox()
        {
            return daosanpham.hienthiCombobox();
        }
        public DataTable hienthiComboboxMauSac()
        {
            return daosanpham.hienthiComboboxMauSac();

        }
        public DataTable hienthiComboboxSize()
        {
            return daosanpham.hienthiComboboxSize();
        }
        public List<DTO_Sanpham> ShowNameAndPriceItem(string masp)
        {
            return daosanpham.ShowNameAndPriceItem(masp);
        }
        public List<DTO_Sanpham> ListSPSales()
        {
            return daosanpham.ListSPSales();
        }
        // list sp no sale
        public List<DTO_Sanpham> ListSPnoSales()
        {
            return daosanpham.ListSPnoSales();
        }
        public List<DTO_Sanpham> ListSP()
        {
            return daosanpham.ListSP();
        }
        public List<DTO_Sanpham> ShowListImageQDam()
        {
            return daosanpham.ShowListImageQDam();
        }
        // hiển thị ảnh sản phẩm lọc theo quần váy
        public List<DTO_Sanpham> ShowListImageQV()
        {
            return daosanpham.ShowListImageQV();
        }
        // hiển thị ảnh sản phẩm lọc theo quần dài
        public List<DTO_Sanpham> ShowListImageQD()
        {
            return daosanpham.ShowListImageQD();
        }
        // hiển thị ảnh sản phẩm lọc theo quần
        public List<DTO_Sanpham> ShowListImageQS()
        {
            return daosanpham.ShowListImageQS();
        }
        // hiển thị ảnh sản phẩm lọc theo Áo HD and TW
        public List<DTO_Sanpham> ShowListImageHDTW()
        {
            return daosanpham.ShowListImageHDTW();
        }
        // hiển thị ảnh sản phẩm lọc theo Áo tay dai
        public List<DTO_Sanpham> ShowListImageATD()
        {
            return daosanpham.ShowListImageATD();
        }
        // hiển thị ảnh sản phẩm lọc theo Áo tee
        public List<DTO_Sanpham> ShowListImageAT()
        {
            return daosanpham.ShowListImageAT();
        }
        // hiển thị ảnh sản phẩm lọc theo quàn
        public List<DTO_Sanpham> ShowListImageQuan()
        {
            return daosanpham.ShowListImageQuan();
        }
        // hiển thị ảnh sản phẩm lọc theo áo
        public List<DTO_Sanpham> ShowListImageAo()
        {
            return daosanpham.ShowListImageAo();
        }
    }
}
