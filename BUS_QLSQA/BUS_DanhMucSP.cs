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
    public class BUS_DanhMucSP
    {
        DAO_DanhMucSP daodmsp = new DAO_DanhMucSP();
        public List<DTO_Loaisp> loadCBLoaisp()
        {
            return daodmsp.loadCBLoaisp();
        }
        public bool ThemDMSP(string maloai, string tenloai)
        {
            return daodmsp.ThemDMSP(maloai, tenloai);
        }
        public bool CapNhatDMSP(string maloai, string tenloai)
        {
            return daodmsp.CapNhatDMSP(maloai, tenloai);
        }
        public DataTable DanhsachDMSP()
        {
            return daodmsp.DanhsachDMSP();
        }
        public bool XoaLoaiHang(string maloaihang)
        {
            return daodmsp.XoaLoaiHang(maloaihang);
        }
        public DataTable timkiemDM(string tenloai, string maloai)
        {
            return daodmsp.TimkiemDM(tenloai, maloai);
        }
    }
}
