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
    public class BUS_CTDonVanChuyen
    {
        DAO_CTDonVanChuyen daoctdvc = new DAO_CTDonVanChuyen();
        public bool DeleteCTDVC(int madon, int mamau, int size)
        {
            return daoctdvc.DeleteCTDVC(madon, mamau, size);
        }
        public bool UpdateCTDVC(string oldmasp, int oldsize, int oldcolor, string newmasp, int newsize, int newcolor, int idbill, string manv, int soluong)
        {
            return daoctdvc.UpdateCTDVC(oldmasp, oldsize, oldcolor, newmasp, newsize, newcolor, idbill, manv, soluong);
        }
        public int getIDSize(string ten)
        {
            return daoctdvc.getIDSize(ten);
        }
 
        public int getIDColor(string ten)
        {
            return daoctdvc.getIDColor(ten);
        }
        public DataTable loadDVCFromDateToDate(DateTime from, DateTime to)
        {
            return daoctdvc.loadDVCFromDateToDate(from, to);
        }
        public int getMaxIDDVC()
        {
            return daoctdvc.getMaxIDDVC();
        }
        public int getMinIDDVC()
        {
            return daoctdvc.getMinIDDVC();
        }
        public DataTable loadDSDVCtheoMaDon(int madon)
        {
            return daoctdvc.loadDSloadDSDVCtheoMaDonDVC(madon);
        }
        public List<DTO_ChiTietDVC> listCTDVC()
        {
            return daoctdvc.listCTDVC();
        }
        public DataTable loadDSDVC()
        {
            return daoctdvc.loadDSDVC();
        }
    }
}
