using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QLSQA;
namespace DAO_QLSQA
{
    public class DAO_DanhMucSP
    {
        // danh mục sản phẩm
        public List<DTO_Loaisp> loadCBLoaisp()
        {
            string query = "select * from PHANLOAISP";
            List<DTO_Loaisp> listloaisp = new List<DTO_Loaisp>();
            DataTable db = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in db.Rows)
            {
                DTO_Loaisp sp = new DTO_Loaisp(item);
                listloaisp.Add(sp);
            }
            return listloaisp;
        }
        // thêm danh mục sp
        public bool ThemDMSP(string maloai, string tenloai)
        {
            string query = "sp_insertDMSP @maloai , @tenloai";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maloai, tenloai });
            if (result > 0)
                return true;
            return false;   
        }
        public bool CapNhatDMSP(string maloai, string tenloai)
        {
            string query = "sp_updateDMSP @maloai , @tenloai";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maloai, tenloai });
            if (result > 0)
                return true;
            return false;
        }
        public DataTable DanhsachDMSP()
        {
            DataTable dt = new DataTable();
            string query = "select * from PHANLOAISP";
            dt = DataProvider.Instance.ExecuteQuery(query);
            return dt;
        }
        public bool XoaLoaiHang(string maloaihang)
        {
            string query = " sp_deleteDMSP @maloai";
            int dt = DataProvider.Instance.ExecuteNonQuery(query, new object[] { maloaihang });
            if (dt > 0)
            {
                return true;
            }
            return false;
        }
        public DataTable TimkiemDM(string tenloai, string maloai)
        {
            DataTable dt = new DataTable();
            string query = "sp_TimkiemDM_SP @tenloai , @maloai";
            dt = DataProvider.Instance.ExecuteQuery(query, new object[] { tenloai, maloai });
            return dt;
        }
    }
}
