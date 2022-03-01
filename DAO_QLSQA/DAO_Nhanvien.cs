using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QLSQA;
namespace DAO_QLSQA
{
    public class DAO_Nhanvien
    {
        public DAO_Nhanvien()
        {

        }
        // Phân quyền
        public bool Role(string email)
        {
            string query = "sp_getRolebyEmail @email";
            object result = DataProvider.Instance.ExecuteScalar(query, new object[] { email });
            if (Convert.ToInt32(result) > 0)
                return true;
            return false;
        }
        // Tìm kiếm nhân viên 
        public DataTable TimKiemNV(string keyword)
        {
            DataTable dt = new DataTable();
            string query = "sp_TimkiemNV @keyword";
            dt = DataProvider.Instance.ExecuteQuery(query, new object[] {keyword});
            return dt;
        }
        // kiểm tra có phải admin hay không

        public bool isadmin (string email)
        {
            string query = " sp_isAdmin @email";
            object result = DataProvider.Instance.ExecuteScalar(query, new object[] { email });
            if (Convert.ToInt32(result) > 0)
                return true;
            return false;
        }
        // Kiểm tra số điện thoại có thay đổi sđt hay không
        public bool NOTChangePhoneNumber(string email,string sdt)
        {
            string query = "sp_SamePhoneNumber @email , @sdtht";
            object result = DataProvider.Instance.ExecuteScalar(query, new object[] { email ,sdt});
            if (Convert.ToInt32(result) > 0)
                return true;
            return false;
        }
        // Kiểm tra email có tồn tại hay không
        public bool isEmailExists(string email)
        {
            string query = "sp_isEmailExists @email";
            object result = DataProvider.Instance.ExecuteScalar(query, new object[] { email });
            if (Convert.ToInt32(result) > 0)
                return true;
            return false;
        }
        // Lấy mã nhân viên
        public object LayMaNV(string email)
        {
            string query = "sp_getIDnvByEmail @email";
            object result = DataProvider.Instance.ExecuteScalar(query, new object[]
            {email});
            return result;
        }
        // Thay đổi mật khẩu
        public bool DoiMatKhau(string email, string curpass, string newpass, string repass)
        {
            string query = "sp_changePW @email , @curPass , @newpass , @rePass";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[]
            {email,curpass,newpass,repass});
            if (result > 0)
            {
                return true;
            }
            return false;
        }
        // Quên mật khẩu

        public bool QuenMatKhau(string email, string newpass)
        {
            string query = " sp_QuenMK @email , @randompass";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[]
            {email,newpass});
            if (result > 0)
            {
                return true;
            }
            return false;
        }
        // Thay đổi thông tin nv
        public bool ThaydoiTT(DTO_Nhanvien nv)
        {
             string query = "sp_changeTTNV @email , @hoten , @diachi , @sdt , @gioitinh , @anh";
             int result = DataProvider.Instance.ExecuteNonQuery(query, new object[]
             { nv.Email,nv.HoTen,nv.DiaChi,nv.SDT,nv.Gioitinh,nv.HinhAnh });
             if (result > 0)
             {
                 return true;
             }
             return false;
        }

        // đăng nhập
        public bool nvDangNhap(string email , string password )
        {
            string query = "exec sp_loginNV @email , @pass";
            object result = DataProvider.Instance.ExecuteScalar(query, new object[] { email, password });
            if (Convert.ToInt32(result) > 0)
            {
                return true;
            }
            return false;
        }
        // Thêm nhân viên
        public bool ThemNV(DTO_Nhanvien nv )
        {
            string query = "exec sp_insertNV @hoten , @diachi , @sdt , @email , @gioitinh , @vaitro , @hinhanh";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] 
            { nv.HoTen,nv.DiaChi,nv.SDT,nv.Email,nv.Gioitinh,nv.VaiTro,nv.HinhAnh });
            if(result > 0)
            {
                return true;
            }
            return false;
        }

        // Sửa nhân viên
        public bool CapNhatNV(DTO_Nhanvien nv)
        {
            string query = "exec sp_updateNV @hoten , @diachi , @sdt , @email , @gioitinh , @vaitro , @hinhanh";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[]
            { nv.HoTen,nv.DiaChi,nv.SDT,nv.Email,nv.Gioitinh,nv.VaiTro,nv.HinhAnh });
            if (result > 0)
            {
                return true;
            }
            return false;
        }
        // Xóa nhân viên
        public bool XoaNV(string emailbixoa, string emailxoa)
        {
            string query = "sp_deleteNV @emailBixoa , @emailXoa";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[]
            { emailbixoa,emailxoa });
            if (result > 0)
            {
                return true;
            }
            return false;
        }
        
         // khôi phục nv
        public bool RestoneNV(string email)
        {
            string query = "sp_restoneNV @email";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[]
            { email });
            if (result > 0)
            {
                return true;
            }
            return false;
        }
        //  tìm kiếm nhân viên  bị xóa
        public DataTable FindNVDeleted(string chuoi)
        {
            DataTable dt = new DataTable();
            string query = "sp_findNVdeleted @chuoi";
            dt = DataProvider.Instance.ExecuteQuery(query, new object[] { chuoi });
            return dt;
        }
        //  tìm kiếm nhân viên chưa bị xóa
        public DataTable FindNV(string chuoi)
        {
            DataTable dt = new DataTable();
            string query = "sp_findNV @chuoi";
            dt = DataProvider.Instance.ExecuteQuery(query,new object[] {chuoi });
            return dt;
        }
        // danh sách nv đã bị xóa 

        public DataTable DanhSachNVDelete()
        {
            DataTable dt = new DataTable();
            string query = "sp_getlistStaffdeleted";
            dt = DataProvider.Instance.ExecuteQuery(query);
            return dt;
        }
        public List<DTO_Nhanvien> ListNVdeleted()
        {
            List<DTO_Nhanvien> listnv = new List<DTO_Nhanvien>();
            DataTable dt = new DataTable();
            string query = "sp_getlistStaffdeleted";
            dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in dt.Rows)
            {
                DTO_Nhanvien nv = new DTO_Nhanvien(item);
                listnv.Add(nv);
            }
            return listnv;
        }
        // Xuất danh sách nhân viên
        public DataTable DanhSachNV()
        {
            DataTable dt = new DataTable();
            string query = "sp_getListStaff";
            dt = DataProvider.Instance.ExecuteQuery(query);
            return dt;
        }
        // Xuất thoogn tin của 1 nhân viên đăg nhập vào tk
        public List<DTO_Nhanvien> ThongtincuaNVDangNhap(string email)
        {
            List<DTO_Nhanvien> listnv = new List<DTO_Nhanvien>();
            DataTable dt = new DataTable();
            string query = "sp_getListStaff @email";
            dt = DataProvider.Instance.ExecuteQuery(query,new object[] {email});
            foreach (DataRow item in dt.Rows)
            {
                DTO_Nhanvien nv = new DTO_Nhanvien(item);
                listnv.Add(nv);
            }
            return listnv;
        }
        // get list nhân viên
        public List<DTO_Nhanvien> ListNV()
        {
            List<DTO_Nhanvien> listnv = new List<DTO_Nhanvien>();
            DataTable dt = new DataTable();
            string query = "sp_getListStaff";
            dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in dt.Rows)
            {
                DTO_Nhanvien nv = new DTO_Nhanvien(item);
                listnv.Add(nv);
            }
            return listnv;
        }

    }
}
