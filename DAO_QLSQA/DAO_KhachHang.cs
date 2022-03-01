using DTO_QLSQA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO_QLSQA
{
    public class DAO_KhachHang
    {
        // Khôi phục khách hàng
        public bool RestoneKH(string sdt)
        {
            string query = "sp_restoneKH @sdt";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { sdt });
            if (result > 0)
            {
                return true;
            }
            return false;
        }
        // xóa khách hàng
        public bool DeleteKH(string sdt)
        {
            string query = "sp_deleteKH @sdt";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { sdt });
            if (result > 0)
            {
                return true;
            }
            return false;
        }
      
        // get list khách hàng
        public List<DTO_KhachHang> getListKH()
        {
            List<DTO_KhachHang> listkh = new List<DTO_KhachHang>();
            string query = "select sdt,tenkh,diemtichluy from khachhang where isdelete = 0";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in dt.Rows)
            {
                DTO_KhachHang kh = new DTO_KhachHang(item);
                listkh.Add(kh);

            }
            return listkh;
        }
        // get list khách hàng đã bị xóa
        public List<DTO_KhachHang> getListKHDeleted()
        {
            List<DTO_KhachHang> listkh = new List<DTO_KhachHang>();
            string query = "select sdt,tenkh,diemtichluy from khachhang where isdelete = 1";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in dt.Rows)
            {
                DTO_KhachHang kh = new DTO_KhachHang(item);
                listkh.Add(kh);

            }
            return listkh;
        }
        // tìm kiếm  khách hàng đã bị xóa 
        public DataTable FindCustomerDeleted(string chuoi)
        {
            string query = " sp_TimkiemKHbixoa @Chuoi";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query, new object[] { chuoi });
            return dt;
        }
       
       // tìm kiếm  khách hàng
            public DataTable FindCustomer(string chuoi) 
        {
            string query = "sp_TimkiemKH @Chuoi";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query,new object[] { chuoi });
            return dt;
        }
        public DataTable getDanhSachKHdabiXoa()
        {
            string query = "select sdt,tenkh,diemtichluy from khachhang where isDelete = 1";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            return dt;
        }
        public DataTable getDanhSachKH()
        {
            string query = "select sdt,tenkh,diemtichluy from khachhang where isDelete = 0";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            return dt;
        }
        public bool themKH(DTO_KhachHang kh)
        {
            string query = "exec sp_insertKh @sdt , @tenkh";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[]
            { kh.SDT  , kh.TEn });
            if (result > 0)
            {
                return true;
            }
            return false;
        }
        public bool UpdateKH(DTO_KhachHang kh)
        {
            string query = "sp_updateKh @sdt , @tenkh";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[]{kh.SDT,kh.TEn});
            if (result > 0)
            {
                return true;
            }
            return false;
        }
        // add điểm tích lũy
        public bool AddDiem(string sdt, double diem)
        {
            string query = "sp_addDiem @sdt , @diem";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { sdt,diem});
            if (result > 0)
            {
                return true;
            }
            return false;
        }

    }
}
