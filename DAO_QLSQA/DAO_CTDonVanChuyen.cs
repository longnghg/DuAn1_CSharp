using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QLSQA;
namespace DAO_QLSQA
{
    public class DAO_CTDonVanChuyen
    {
        // xóa lại chi tiết đơn vận chuyển 
        public bool DeleteCTDVC(int madon, int mamau, int size)
        {
            string query = "sp_xoaspinbill @madon , @mamau , @masize";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { madon,mamau,size });
            if (result > 0)
                return true;
            return false;
        }
        // update lại chi tiết đơn vận chuyển 
        public bool UpdateCTDVC(string oldmasp,int oldsize,int oldcolor,string newmasp,int newsize, int newcolor, int idbill, string manv, int soluong)
        {
            string query = "sp_updateCTDVC @maspcu , @sizecu , @mamaucu , @maspmoi , @sizemoi , @mamaumoi , @madonnhap , @manv , @soluong";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { oldmasp, oldsize, oldcolor, newmasp, newsize, newcolor, idbill, manv, soluong });
            if (result > 0)
                return true;
            return false;
        }
        // LẤy mã size
        public int getIDSize(string ten)
        {
            string query = "sp_getIDSize @tensize";
            object result = DataProvider.Instance.ExecuteScalar(query, new object[] { ten });
            return int.Parse(result.ToString());
        }
        // LẤy mã màu
        public int getIDColor(string ten)
        {
            string query = "sp_getIDColor @tencolor";
            object result = DataProvider.Instance.ExecuteScalar(query,new object[] {ten });
            return int.Parse(result.ToString());
        }
        public DataTable loadDVCFromDateToDate(DateTime from,DateTime to)
        {
            string query = "sp_LoadBillDVCByDay @fromDay , @toDay";
            DataTable tb = DataProvider.Instance.ExecuteQuery(query, new object[] { from ,to });
            return tb;
        }
        public DataTable loadDSloadDSDVCtheoMaDonDVC(int madon)
        {
            string query = "sp_loadDVCbyID @madonnhap";
            DataTable tb = DataProvider.Instance.ExecuteQuery(query, new object[] { madon });
            return tb;
        }
        public List<DTO_ChiTietDVC> listCTDVC()
        {
            List<DTO_ChiTietDVC> list = new List<DTO_ChiTietDVC>();
            string query = "sp_ListDVC";
            DataTable tb = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in tb.Rows)
            {
                DTO_ChiTietDVC ctd = new DTO_ChiTietDVC(item);
                list.Add(ctd);
            }
            return list;
        }
        public DataTable loadDSDVC()
        {
            string query = "sp_loadDonVanChuyen";
            DataTable tb = DataProvider.Instance.ExecuteQuery(query);
            return tb;
        }
        public int getMaxIDDVC()
        {
            string query = "sp_getMaxIDDVC";
            object result = DataProvider.Instance.ExecuteScalar(query);
            return int.Parse(result.ToString());
        }
        public int getMinIDDVC()
        {
            string query = "sp_getMinIDDVC";
            object result = DataProvider.Instance.ExecuteScalar(query);
            return int.Parse(result.ToString());
        }
    }
}
