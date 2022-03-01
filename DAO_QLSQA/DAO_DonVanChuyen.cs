using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO_QLSQA
{
    public class DAO_DonVanChuyen
    {
        
       
        //public int GetIDMaxDVC()
        //{
        //    string query = "select MAX(MaDonNhap) from DONVANCHUYEN";
        //    object result = DataProvider.Instance.ExecuteScalar(query);
        //    return Convert.ToInt32(result);
        //}
        public bool ThemBillVC()
        {
            string query = "sp_taodonvanchuyen";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            if (result > 0)
            {
                return true;
            }
            return false;
        }
    }
}
