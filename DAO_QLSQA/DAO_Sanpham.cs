using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QLSQA;
namespace DAO_QLSQA
{
    public class DAO_Sanpham
    {
        // lấy tên sp
         public string GetNameByID(string masp)
        {
            string query = "sp_getnambyID  @masp";
            object result = DataProvider.Instance.ExecuteScalar(query, new object[] { masp });
            return result.ToString();
        }
        //xóa sản phẩm
        public bool DeleteSP(string masp, string manv)
        {
            string query = "sp_xoamasp @masp , @manv";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { masp, manv });
            if (result > 0)
                return true;
            return false;
        }

        //Tìm kiếm sản phẩm (rút gọn)
        public DataTable FindIteminListRG(string keyword)
        {
            DataTable dt = new DataTable();
            string query = "sp_Timkiemdanhsachsp @chuoi";
            dt = DataProvider.Instance.ExecuteQuery(query, new object[] { keyword });
            return dt;
        }
        //Tìm kiếm sản phẩm (chi tiết)
        public DataTable FindIteminListCT(string keyword)
        {
            DataTable dt = new DataTable();
            string query = "sp_timkiemdanhsachchitietsp @chuoi";
            dt = DataProvider.Instance.ExecuteQuery(query, new object[] { keyword });
            return dt;
        }
        //Tìm kiếm sản phẩm cho bảng giảm giá (co giam)
        public DataTable FindItemSale(string keyword)
        {
            DataTable dt = new DataTable();
            string query = "sp_timkiemspCoGiam @chuoitimkiem";
            dt = DataProvider.Instance.ExecuteQuery(query, new object[] { keyword });
            return dt;
        }
        //Tìm kiếm sản phẩm cho bảng giảm giá (ko giam)
        public DataTable FindItemNoSale(string keyword)
        {
            DataTable dt = new DataTable();
            string query = "sp_timkiemspKoGiam @chuoitimkiem";
            dt = DataProvider.Instance.ExecuteQuery(query, new object[] { keyword });
            return dt;
        }
        //Tìm kiếm sản phẩm cho bảng giảm giá (tất cả)
        public DataTable DSSPAfterFindForSale(string keyword)
        {
            DataTable dt = new DataTable();
            string query = "sp_timkiemsp  @chuoitimkiem";
            dt = DataProvider.Instance.ExecuteQuery(query, new object[] { keyword });
            return dt;
        }
        // Cập nhật lại giảm giá cho toàn bộ sản phẩm

        public bool UpdateSalesAllProduct(int sales)
        {
            string query = "sp_SetupGiamGia @giamgia";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { sales });
            if (result > 0)
                return true;
            return false;

        }
        // cập nhật lại giảm giá cho 1 sản phẩm
        public bool UpdateSales( int sales , string masp)
        {
            string query = "sp_SetupGiamGia @giamgia , @masp";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { sales, masp });
            if (result > 0)
                return true;
            return false;
                
        }

        // hiển thị danh sách sản phẩm đang sale
        public DataTable DSSPDangGiamGia(bool isSale)
        {
            DataTable dt = new DataTable();
            string query = "sp_ListProductSaleOrNot @isSale";
            dt = DataProvider.Instance.ExecuteQuery(query, new object[] { isSale});
            return dt;
        }
        // hiển thị danh sách sản phẩm không có  sale
        public DataSet DSSPKhongGiamGia(bool isSale)
        {
            DataSet dt = new DataSet();
            string query = "sp_ListProductSaleOrNot @isSale";
            dt = DataProvider.Instance.ExecuteQueryDataSet(query, new object[] { isSale });
            return dt;
        }
        // Kiểm tra có thay đổi tên sp khi sửa hay không
         public bool NOTchangeNameItem(string masp,string tensp)
        {
            string query = " sp_NotChangeNameItem @masp , @tensp";
            object result = DataProvider.Instance.ExecuteScalar(query, new object[] {masp,tensp});
            if (Convert.ToInt32(result) > 0)
                return true;
            return false;
        }
        // Cập nhật lại thông tin sản phẩm
        public bool UpdateSP(DTO_Sanpham sp)
        {
            string query = "sp_UpdateSP  @masp , @tensp , @dgn , @dgb , @doituong , @hinhanhtrc , @hinhanhsau , @maloai";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { sp.MaSP, sp.TenSP, sp.DongiaNhap, sp.DongiaBan, sp.DoiTuong, sp.HinhAnhtrc, sp.HinhAnhsau, sp.MaLoai});
            if (result > 0)
                return true;
            return false;
        }
        // Thêm sản phẩm
        public bool ThemSP(DTO_Sanpham sp,string manv)
        {
            string query = "sp_themSP @masp , @tensp , @dgn , @dgb , @doituong , @hinhanhtrc , @hinhanhsau , @maloai , @soluong  , @size , @mamau , @manv ";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { sp.MaSP, sp.TenSP, sp.DongiaNhap, sp.DongiaBan, sp.DoiTuong, sp.HinhAnhtrc, sp.HinhAnhsau, sp.MaLoai, sp.SoLuong, sp.Size, sp.Mamau, manv });
            if (result > 0) 
                return true;
            return false;
        }
        // hiển thị dssp chi tiết
        public DataTable hienthiDSSP()
        {
            DataTable dt = new DataTable();
            string query = "sp_danhsachchitietsp";
           dt =  DataProvider.Instance.ExecuteQuery(query);
            return dt;
        }
        //
        public string getMaloaisp( string tenloai)
        {
            DataTable dt = new DataTable();
            string query = "sp_getMaloai @tenloai";
            object result = DataProvider.Instance.ExecuteScalar(query, new object[] { tenloai });
            return result.ToString();
        }
        // hiển thị dssp rút gọn
        public DataTable hienthiDSSP_rutgon()
        {
            DataTable dt = new DataTable();
            string query = "sp_danhsachsp";
            dt = DataProvider.Instance.ExecuteQuery(query);
            return dt;
        }
      
        // hiển thị ảnh sản phẩm lọc theo Đầm
        public List<DTO_Sanpham> ShowListImageQDam()
        {
            List<DTO_Sanpham> listsp = new List<DTO_Sanpham>();
            string query = "select MASP,TenSP,DonGiaBan,DonGiaNhap,DoiTuong,HinhAnhTrc,HinhAnhSau,Giamgia,MaLoai from SANPHAM where MaLoai like '%DB%' and tongsoluong > 0";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in dt.Rows)
            {
                DTO_Sanpham sp = new DTO_Sanpham(item);
                listsp.Add(sp);
            }
            return listsp;
        }
        // hiển thị ảnh sản phẩm lọc theo quần váy
        public List<DTO_Sanpham> ShowListImageQV()
        {
            List<DTO_Sanpham> listsp = new List<DTO_Sanpham>();
            string query = "select MASP,TenSP,DonGiaBan,DonGiaNhap,DoiTuong,HinhAnhTrc,HinhAnhSau,Giamgia,MaLoai from SANPHAM where MaLoai like '%QVA%' and tongsoluong > 0";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in dt.Rows)
            {
                DTO_Sanpham sp = new DTO_Sanpham(item);
                listsp.Add(sp);
            }
            return listsp;
        }
        // hiển thị ảnh sản phẩm lọc theo quần dài
        public List<DTO_Sanpham> ShowListImageQD()
        {
            List<DTO_Sanpham> listsp = new List<DTO_Sanpham>();
            string query = "select MASP,TenSP,DonGiaBan,DonGiaNhap,DoiTuong,HinhAnhTrc,HinhAnhSau,Giamgia,MaLoai from SANPHAM where MaLoai like '%QD%' and tongsoluong > 0";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in dt.Rows)
            {
                DTO_Sanpham sp = new DTO_Sanpham(item);
                listsp.Add(sp);
            }
            return listsp;
        }
        // hiển thị ảnh sản phẩm lọc theo quần
        public List<DTO_Sanpham> ShowListImageQS()
        {
            List<DTO_Sanpham> listsp = new List<DTO_Sanpham>();
            string query = "select MASP,TenSP,DonGiaBan,DonGiaNhap,DoiTuong,HinhAnhTrc,HinhAnhSau,Giamgia,MaLoai from SANPHAM where MaLoai like '%QN%' and tongsoluong > 0";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in dt.Rows)
            {
                DTO_Sanpham sp = new DTO_Sanpham(item);
                listsp.Add(sp);
            }
            return listsp;
        }
        // hiển thị ảnh sản phẩm lọc theo Áo HD and TW
        public List<DTO_Sanpham> ShowListImageHDTW()
        {
            List<DTO_Sanpham> listsp = new List<DTO_Sanpham>();
            string query = "select MASP,TenSP,DonGiaBan,DonGiaNhap,DoiTuong,HinhAnhTrc,HinhAnhSau,Giamgia,MaLoai from SANPHAM where MaLoai like '%AHW%' and tongsoluong > 0";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in dt.Rows)
            {
                DTO_Sanpham sp = new DTO_Sanpham(item);
                listsp.Add(sp);
            }
            return listsp;
        }
        // hiển thị ảnh sản phẩm lọc theo Áo tee
        public List<DTO_Sanpham> ShowListImageATD()
        {
            List<DTO_Sanpham> listsp = new List<DTO_Sanpham>();
            string query = "select MASP,TenSP,DonGiaBan,DonGiaNhap,DoiTuong,HinhAnhTrc,HinhAnhSau,Giamgia,MaLoai from SANPHAM where MaLoai like '%AD%' and tongsoluong > 0";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in dt.Rows)
            {
                DTO_Sanpham sp = new DTO_Sanpham(item);
                listsp.Add(sp);
            }
            return listsp;
        }
        // hiển thị ảnh sản phẩm lọc theo Áo tee
        public List<DTO_Sanpham> ShowListImageAT()
        {
            List<DTO_Sanpham> listsp = new List<DTO_Sanpham>();
            string query = "select MASP,TenSP,DonGiaBan,DonGiaNhap,DoiTuong,HinhAnhTrc,HinhAnhSau,Giamgia,MaLoai from SANPHAM where MaLoai like '%AN%' and tongsoluong > 0";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in dt.Rows)
            {
                DTO_Sanpham sp = new DTO_Sanpham(item);
                listsp.Add(sp);
            }
            return listsp;
        }
        // hiển thị ảnh sản phẩm lọc theo quàn
        public List<DTO_Sanpham> ShowListImageQuan()
        {
            List<DTO_Sanpham> listsp = new List<DTO_Sanpham>();
            string query = "select MASP,TenSP,DonGiaBan,DonGiaNhap,DoiTuong,HinhAnhTrc,HinhAnhSau,Giamgia,MaLoai from SANPHAM where MaLoai like 'Q%' and tongsoluong > 0";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in dt.Rows)
            {
                DTO_Sanpham sp = new DTO_Sanpham(item);
                listsp.Add(sp);
            }
            return listsp;
        }
        // hiển thị ảnh sản phẩm lọc theo áo
        public List<DTO_Sanpham> ShowListImageAo()
        {
            List<DTO_Sanpham> listsp = new List<DTO_Sanpham>();
            string query = "select MASP,TenSP,DonGiaBan,DonGiaNhap,DoiTuong,HinhAnhTrc,HinhAnhSau,Giamgia,MaLoai from SANPHAM where MaLoai like 'A%' and tongsoluong > 0";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in dt.Rows)
            {
                DTO_Sanpham sp = new DTO_Sanpham(item);
                listsp.Add(sp);
            }
            return listsp;
        }

        //
        // hiển thị ảnh sản phẩm
        public List<DTO_Sanpham> ShowListImage()
        {
            List<DTO_Sanpham> listsp = new List<DTO_Sanpham>();
            string query = "sp_loadImage";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in dt.Rows)
            {
                DTO_Sanpham sp = new DTO_Sanpham(item);
                listsp.Add(sp);
            }
            return listsp;
        }
        // hiển thị các loại mặt hàng lên combo box
        public DataTable hienthiCombobox()
        {
            string query = "select * from PHANLOAISP";
            DataTable tb = DataProvider.Instance.ExecuteQuery(query);
            return tb;
        }
        // hiển thị các loại mặt hàng lên combo box size
        public DataTable hienthiComboboxSize()
        {
            string query = "select * from KICHCO";
            DataTable tb = DataProvider.Instance.ExecuteQuery(query);
            return tb;
        }
        // hiển thị các loại màu sắc lên combo box
        public DataTable hienthiComboboxMauSac()
        {
            string query = "select * from Mausac";
            DataTable tb = DataProvider.Instance.ExecuteQuery(query);
            return tb;
        }
        // hiển thị giá và tên sp
        public List<DTO_Sanpham> ShowNameAndPriceItem(string masp)
        {
            List<DTO_Sanpham> listsp = new List<DTO_Sanpham>();
            string query = "sp_danhsachsp @masp";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query, new object[] { masp });
            foreach (DataRow item in dt.Rows)
            {
                DTO_Sanpham sp = new DTO_Sanpham(item);
                listsp.Add(sp);
            }
            return listsp;
        }
        // list sp sale
        public List<DTO_Sanpham> ListSPSales()
        {
            List<DTO_Sanpham> listsp = new List<DTO_Sanpham>();
            string query = "select * from sanpham where giamgia <> 0";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in dt.Rows)
            {
                DTO_Sanpham sp = new DTO_Sanpham(item);
                listsp.Add(sp);
            }
            return listsp;
        }
        // list sp no sale
        public List<DTO_Sanpham> ListSPnoSales()
        {
            List<DTO_Sanpham> listsp = new List<DTO_Sanpham>();
            string query = "select * from sanpham where giamgia = 0";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in dt.Rows)
            {
                DTO_Sanpham sp = new DTO_Sanpham(item);
                listsp.Add(sp);
            }
            return listsp;
        }
        // Load list sản phẩm
        public List<DTO_Sanpham> ListSP()
        {
            List<DTO_Sanpham> listsp = new List<DTO_Sanpham>();
            string query = "sp_danhsachsp";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in dt.Rows)
            {
                DTO_Sanpham sp = new DTO_Sanpham(item);
                listsp.Add(sp);
            }
            return listsp;
        }

    }
}
