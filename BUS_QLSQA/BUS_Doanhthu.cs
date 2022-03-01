using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QLSQA;
using DAO_QLSQA;
using System.Data;

namespace BUS_QLSQA
{
    public class BUS_Doanhthu
    {
        DAO_Doanhthu daodt = new DAO_Doanhthu();
        public int LoadMinDayDVC(int month, int year)
        {
            return daodt.LoadMinDayDVC(month, year);
        }
        // lấy ra ngày thấp nhất để hiển thị 
        public int LoadMinDay(int month, int year)
        {
            return daodt.LoadMinDay(month, year);
        }
        public DataTable getlistDVCbyDayinMonth(int month, int day, int year)
        {
            return daodt.getlistDVCbyDayinMonth(month,day ,year);
        }
        // hiển thị list bill chi phí vận chuyển theo tháng
        public DataTable getlistDVCbyMonth(int month, int year)
        {
            return daodt.getlistDVCbyMonth(month, year);
        }
        public DataTable getlistbyDayinMonth(int month, int day , int year)
        {
            return daodt.getlistbyDayinMonth(month, day, year);
        }
        // hiển thị list bill theo tháng
        public DataTable getlistbyMonth(int month , int year)
        {
            return daodt.getlistbyMonth(month,year);
        }
        public DataTable getlistYear()
        {
            return daodt.getlistYear();
        }
        public List<DTO_Doanhthu> getChart(int month ,int year)
        {
            return daodt.getChart(month, year);
        }
    }
}
