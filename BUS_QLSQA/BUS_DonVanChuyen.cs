using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO_QLSQA;
namespace BUS_QLSQA
{
    public class BUS_DonVanChuyen
    {
        DAO_DonVanChuyen daoDonVC = new DAO_DonVanChuyen();

        //public int GetIDMaxDVC()
        //{
        //    return daoDonVC.GetIDMaxDVC();
        //}
        public bool ThemBillVC()
        {
            return daoDonVC.ThemBillVC();
        }

    }
}
