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
    public class BUS_HoadonThanhToan
    {
        DAO_Hoadonthanhtoan daohoadonthanhtoan = new DAO_Hoadonthanhtoan();
        public bool DeleteItemInBuyingBill(string masp)
        {
            return daohoadonthanhtoan.DeleteItemInBuyingBill(masp);
        }
        public int QuantityInBuyingBill(int madon, string masp, int masize, int mamau)
        {
            return daohoadonthanhtoan.QuantityInBuyingBill(madon, masp, masize, mamau);
        }
        public DataTable showSimpleBill()
        {
            return daohoadonthanhtoan.showSimpleBill();
        }
        // show bill theo id đơn giản
        public DataTable showSimpleBillbyID(int id)
        {
            return daohoadonthanhtoan.showSimpleBillbyID(id);
        }
        //Show bill đơn giản theo ngày
        public DataTable showSimpleBillbyday(DateTime from, DateTime to)
        {
            return daohoadonthanhtoan.showSimpleBillbyday(from, to);
        }
        public DataTable showBuyBillFromDayToDay(DateTime from, DateTime to)
        {
            return daohoadonthanhtoan.showBuyBillFromDayToDay(from, to);
        }
        public int idMin_HDM()
        {
            return daohoadonthanhtoan.idMin_HDM();
        }
        public int idMax_HDM()
        {
            return daohoadonthanhtoan.idMax_HDM();
        }
        public DataTable showHD()
        {
            return daohoadonthanhtoan.listHD();
        }
        public DataTable Show1HDbyID(int madon)
        {
            return daohoadonthanhtoan.Show1HDbyID(madon);
        }
        public List<DTO_Hoadonchitiet> getListHDCT()
        {
            return daohoadonthanhtoan.getListHDCT();
        }
        public bool addItemsIntoBill(string masp, string manv, string sdt, int soluong, float dongia, int giamgia, float vat, int mamau,int masize)
        {
            return daohoadonthanhtoan.addItemsIntoBill(masp, manv, sdt, soluong, dongia, giamgia, vat,mamau,masize);
        }
        public bool PressBtnthanhToan(bool usePoint , string sdt)
        {
            return daohoadonthanhtoan.PressBtnthanhToan(usePoint , sdt);

        }
        public bool UpdateQuantity(string masp ,int madon, int mamau, int size, int soluong)
        {
            return daohoadonthanhtoan.UpdateQuantity(masp,madon, mamau, size, soluong);

        }
    }
}
