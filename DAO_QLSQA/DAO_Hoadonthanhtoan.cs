using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QLSQA;

namespace DAO_QLSQA
{
    public class DAO_Hoadonthanhtoan
    {
        // xóa hóa đơn đang mua
        //
        public bool DeleteItemInBuyingBill(string masp)
        {
            string query = "sp_deleteBuyingBill @masp";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] {masp});
            if (result > 0)
                return true;
            return false;
        }

        // Kiểm tra số lượng của sản phẩm trong bill đang mua để so với trong kho
        public int QuantityInBuyingBill(int madon,string masp,int masize,int mamau)
        {
            string query = " sp_CheckQuantityWhenBuying @madon , @masp , @masize , @mamau";
            object result = DataProvider.Instance.ExecuteScalar(query, new object[] { madon, masp, masize, mamau });
            return Convert.ToInt32(result);
        }
        // show bill đơn giản
        public DataTable showSimpleBill()
        {
            string query = "sp_showHOADON";
            DataTable tb = DataProvider.Instance.ExecuteQuery(query);
            return tb;
        }
        // show bill theo id đơn giản
        public DataTable showSimpleBillbyID(int id)
        {
            string query = "sp_showHOADONbyID @id";
            DataTable tb = DataProvider.Instance.ExecuteQuery(query, new object[] { id });
            return tb;
        }
        //Show bill đơn giản theo ngày
        public DataTable showSimpleBillbyday(DateTime from, DateTime to)
        {
            string query = "sp_showHOADONbydate @fromDay , @today";
            DataTable tb = DataProvider.Instance.ExecuteQuery(query, new object[] { from, to });
            return tb;
        }
        // show bill từ ngày đến ngày 
        public DataTable showBuyBillFromDayToDay(DateTime from, DateTime to)
        {
            string query = "sp_showbillHDMbyDay @fromDay , @today";
            DataTable tb = DataProvider.Instance.ExecuteQuery(query,new object[] {from,to });
            return tb;
        }
        // lấy ra id nhỏ nhất của bill mua
        public int idMin_HDM()
        {
            string query = " select min(MaDonMua) from HOADONCHITIET";
            object result = DataProvider.Instance.ExecuteScalar(query);
            return Convert.ToInt32(result);
        }
        // lấy ra id lớn nahast của bill mua
        public int idMax_HDM()
        {
            string query = "select max(MaDonMua) from HOADONCHITIET";
            object result = DataProvider.Instance.ExecuteScalar(query);
            return Convert.ToInt32(result);
        }
        // hiển thị bill đã mua xong     
        public DataTable listHD()
        {
            string query = "sp_showbillHDM";
            DataTable tb = DataProvider.Instance.ExecuteQuery(query);
            return tb;
        }
        // hiển thị 1 bill đã mua xong
        public DataTable Show1HDbyID(int madon)
        {
            string query = "sp_showbill1HDM @madon";
            DataTable tb = DataProvider.Instance.ExecuteQuery(query, new object[] { madon});
            return tb;
        }
        // hiển thị bill đang mua
        public List<DTO_Hoadonchitiet> getListHDCT()
        {
            List<DTO_Hoadonchitiet> listhdct = new List<DTO_Hoadonchitiet>();
            string query = "sp_showBuyingBill";
            DataTable tb = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in tb.Rows)
            {
                DTO_Hoadonchitiet hdct = new DTO_Hoadonchitiet(item);
                listhdct.Add(hdct);
            }
            return listhdct;
        }
        // Thêm sản phẩm mua vào bill
        public bool addItemsIntoBill(string masp,string manv, string sdt, int soluong, float dongia,int giamgia,float vat,int mamau,int size)
        {
            string query = "sp_addItemCTHDM @masp , @manv , @sdt , @soluong  , @dongia , @giamgia , @vat , @mamau , @size";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { masp,manv,sdt,soluong,dongia,giamgia,vat,mamau,size});
            if (result > 0)
                return true;
            return false;   
            
        }
        // đổi trạng thái từ chưa thanh toán thành đã thanh toán
        public bool PressBtnthanhToan(bool usePoint ,string sdt)
        {
            string query = "sp_thanhToan @usePoint , @sdt";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { usePoint,sdt});
            if (result > 0)
                return true;
            return false;

        }
        //  Cập nhật lại số lượng
        public bool UpdateQuantity(string masp ,int madon, int mamau,int size,int soluong)
        {
            string query = "sp_updateItemCTHDM @masp , @madonmua , @mamau , @masize , @soluong";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] {masp, madon, mamau, size, soluong });
            if (result > 0)
                return true;
            return false;

        }

    }
}
