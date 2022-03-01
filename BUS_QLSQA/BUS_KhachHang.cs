using DTO_QLSQA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO_QLSQA;
using DTO_QLSQA;
namespace BUS_QLSQA
{
    public class BUS_KhachHang
    {
        DAO_KhachHang daokh = new DAO_KhachHang();
        public bool RestoneKH(string sdt)
        {
            return daokh.RestoneKH(sdt);
        }
        // xóa khách hàng
        public bool DeleteKH(string sdt)
        {
            return daokh.DeleteKH(sdt);
        }
        // get list khách hàng đã bị xóa
        public List<DTO_KhachHang> getListKHDeleted()
        {
            return daokh.getListKHDeleted();
        }
        // tìm kiếm  khách hàng đã bị xóa 
        public DataTable FindCustomerDeleted(string chuoi)
        {
            return daokh.FindCustomerDeleted(chuoi);
        }

        public DataTable FindCustomer(string chuoi)
        {
            return daokh.FindCustomer(chuoi);
        }
        public bool AddDiem(string sdt, double diem)
        {
            return daokh.AddDiem(sdt, diem);
        }

        public List<DTO_KhachHang> getListKH()
        {
            return daokh.getListKH();
        }
        public DataTable getDanhSachKHdabiXoa()
        {
            return daokh.getDanhSachKHdabiXoa();
        }
        public DataTable getDanhSachKH()
        {
            return daokh.getDanhSachKH();
        }
        public bool themKH(DTO_KhachHang kh)
        {
            return daokh.themKH(kh);
        }
        public bool UpdateKH(DTO_KhachHang kh)
        {
            return daokh.UpdateKH(kh);
        }
    }
}
