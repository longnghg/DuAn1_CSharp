using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QLSQA;
namespace DAO_QLSQA
{
    public class DAO_CTSanPham
    {
        
        public List<DTO_CTSanPham> ShowColorofImage(string masp)
        {
            List<DTO_CTSanPham> listctsp = new List<DTO_CTSanPham>();
            string query = "sp_loadColor @masp";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query, new object[] { masp });
            foreach (DataRow item in dt.Rows)
            {
                DTO_CTSanPham ctsp = new DTO_CTSanPham(item,true,false);
                listctsp.Add(ctsp);
            }
            return listctsp;
        }
        public List<DTO_CTSanPham> ShowSizeofItem(string masp)
        {
            List<DTO_CTSanPham> listctsp = new List<DTO_CTSanPham>();
            string query = "sp_loadSize @masp";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query, new object[] { masp });
            foreach (DataRow item in dt.Rows)
            {
                DTO_CTSanPham ctsp = new DTO_CTSanPham(item,false,true);
                listctsp.Add(ctsp);
            }
            return listctsp;
        }
       public List<DTO_CTSanPham>ShowColorBySize(string masp,int masize)
        {
            List<DTO_CTSanPham> listctsp = new List<DTO_CTSanPham>();
            string query = "sp_LoadColorBySize @masp , @masize";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query, new object[] { masp, masize });
            foreach (DataRow item in dt.Rows)
            {
                DTO_CTSanPham ctsp = new DTO_CTSanPham(item,true);
                listctsp.Add(ctsp);
            }
            return listctsp;
        }
       
        public List<DTO_CTSanPham> LoadQuantityBySizeAndColor(string masp, int masize, int mamau)
        {
            List<DTO_CTSanPham> listctsp = new List<DTO_CTSanPham>();
            string query = "sp_LoadQuantityBySizeAndColor @masp , @masize , @mamau";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query, new object[] { masp, masize, mamau });
            foreach (DataRow item in dt.Rows)
            {
                DTO_CTSanPham ctsp = new DTO_CTSanPham(item);
                listctsp.Add(ctsp);
            }
            return listctsp;
        }
        // DỮ LIỆU CHO BẢNG  THANHTOAN
        public List<DTO_CTSanPham> ShowSizeofItem1(string masp)
        {
            List<DTO_CTSanPham> listctsp = new List<DTO_CTSanPham>();
            string query = "sp_loadSize1 @masp";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query, new object[] { masp });
            foreach (DataRow item in dt.Rows)
            {
                DTO_CTSanPham ctsp = new DTO_CTSanPham(item, false, true,true,true);
                listctsp.Add(ctsp);
            }
            return listctsp;
        }
        public List<DTO_CTSanPham> ShowColorBySize1(string masp, int masize)
        {
            List<DTO_CTSanPham> listctsp = new List<DTO_CTSanPham>();
            string query = "sp_LoadColorBySize1 @masp , @masize";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query, new object[] { masp, masize });
            foreach (DataRow item in dt.Rows)
            {
                DTO_CTSanPham ctsp = new DTO_CTSanPham(item, true,true,true);
                listctsp.Add(ctsp);
            }
            return listctsp;
        }
    }
}
