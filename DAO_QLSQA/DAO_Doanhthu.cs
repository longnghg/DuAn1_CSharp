using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QLSQA;
namespace DAO_QLSQA
{
    public class DAO_Doanhthu
    {
        // hiển thị list bill chi phí vận chuyển theo ngày trong tháng
        public DataTable getlistDVCbyDayinMonth(int month,int day ,int year)
        {
            string query = "sp_loadBillVCbyDayinMonth    @month , @day , @year";
            DataTable tb = DataProvider.Instance.ExecuteQuery(query, new object[] { month,day ,year });
            return tb;
        }
        // hiển thị list bill chi phí vận chuyển theo tháng
        public DataTable getlistDVCbyMonth(int month, int year)
        {
            string query = "sp_loadBillVCbyMonth  @month , @year";
            DataTable tb = DataProvider.Instance.ExecuteQuery(query, new object[] { month, year });
            return tb;
        }
        // hiển thị list bill theo ngày trong tháng
        public DataTable getlistbyDayinMonth(int month,int day, int year)
        {
            string query = "sp_loadBillhoadonByDayinMonth  @month , @day , @year";
            DataTable tb = DataProvider.Instance.ExecuteQuery(query, new object[] { month , day, year});
            return tb;
        }
        // lấy ra ngày thấp nhất của đơn nhập hàng để hiển thị 
        public int LoadMinDayDVC(int month, int year)
        {
            string query = "sp_loadMindayinDVC    @month , @year";
            object result = DataProvider.Instance.ExecuteScalar(query, new object[] { month, year });
            if (Convert.ToInt32(result) > 0)
                return Convert.ToInt32(result);
            else
                return 0;
        }
        // lấy ra ngày thấp nhất để hiển thị 
        public int LoadMinDay(int month, int year)
        {
            string query = "sp_loadMinDayHoaDon @month , @year";
            object result  = DataProvider.Instance.ExecuteScalar(query, new object[] { month, year });
            if (Convert.ToInt32(result) > 0)
                return Convert.ToInt32(result);
            else
                return 0;
        }
        // hiển thị list bill mua hàng theo tháng
        public DataTable getlistbyMonth(int month, int year)
        {
            string query = "sp_loadBillhoadonByMonth  @month , @year";
            DataTable tb = DataProvider.Instance.ExecuteQuery(query,new object[] { month,year});
            return tb;
        }
        public DataTable getlistYear()
        {
            string query = "sp_loadYearforDoanhthu";
            DataTable tb = DataProvider.Instance.ExecuteQuery(query);
            return tb;
        }
        public List<DTO_Doanhthu> getChart(int month ,int year)
        {
            List<DTO_Doanhthu> listhd = new List<DTO_Doanhthu>();
            string query = "sp_DoanhThu @thang , @nam";
            DataTable tb = DataProvider.Instance.ExecuteQuery(query, new object[] {month, year });
            foreach (DataRow item in tb.Rows)
            {
                DTO_Doanhthu dt = new DTO_Doanhthu(item);
                listhd.Add(dt);
            }
            return listhd;
        }
    }
}
