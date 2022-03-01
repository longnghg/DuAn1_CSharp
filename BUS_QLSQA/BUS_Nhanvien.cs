using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO_QLSQA;
using DTO_QLSQA;
namespace BUS_QLSQA
{
    public class BUS_Nhanvien
    {
        DAO_Nhanvien DAOnhanvien = new DAO_Nhanvien();
        public bool Role(string email)
        {
            return DAOnhanvien.Role(email);
        }
        public bool RestoneNV(string email)
        {
            return DAOnhanvien.RestoneNV(email);
        }
        public DataTable FindNVDeleted(string chuoi)
        {
            return DAOnhanvien.FindNVDeleted(chuoi);
        }
        public DataTable FindNV(string chuoi)
        {
            return DAOnhanvien.FindNV(chuoi);
        }
        public List<DTO_Nhanvien> ListNVdeleted()
        {
            return DAOnhanvien.ListNVdeleted();
        }
        public DataTable DanhSachNVDelete()
        {
            return DAOnhanvien.DanhSachNVDelete();
        }
        public DataTable TimKiemNV(string keyword)
        {
            return DAOnhanvien.TimKiemNV(keyword);
        }
        public bool isadmin(string email)
        {
            return DAOnhanvien.isadmin(email);
        }
        public bool NOTChangePhoneNumber(string email, string sdt)
        {
            return DAOnhanvien.NOTChangePhoneNumber(email, sdt);
        }
        public bool isEmailExists(string email)
        {
            return DAOnhanvien.isEmailExists(email);
        }
        public object LayMaNV(string email)
        {
            return DAOnhanvien.LayMaNV(email);
        }
        public List<DTO_Nhanvien> ListNV()
        {
            return DAOnhanvien.ListNV();
        }
        public bool QuenMatKhau(string email, string newpass)
        {
            return DAOnhanvien.QuenMatKhau(email, newpass);
        }
        public bool DoiMatKhau(string email, string curpass, string newpass, string repass)
        {
            return DAOnhanvien.DoiMatKhau(email, curpass, newpass, repass);
        }
        public bool ThaydoiTT(DTO_Nhanvien nv)
        {
            return DAOnhanvien.ThaydoiTT(nv);
        }
        public List<DTO_Nhanvien> ThongtincuaNVDangNhap(string email)
        {
            return DAOnhanvien.ThongtincuaNVDangNhap(email);
        }

        public bool nvDangNhap(string email, string password)
        {
            return DAOnhanvien.nvDangNhap(email, password);
        }
        public bool ThemNV(DTO_Nhanvien nv)
        {
            return DAOnhanvien.ThemNV(nv);
        }
        public bool CapNhatNV(DTO_Nhanvien nv)
        {
            return DAOnhanvien.CapNhatNV(nv);
        }
        public bool XoaNV(string emailbixoa, string emailxoa)
        {
            return DAOnhanvien.XoaNV(emailbixoa, emailxoa);
        }
        public DataTable DanhSachNV()
        {
            return DAOnhanvien.DanhSachNV();
        }

        #region codes kiểm lỗi
        // Hàm check email
        public bool checkEmail(string email)
        {
            if (email.Contains("@"))
            {
                string[] E = email.Split('@');
                if (E[1].Contains(".com") && E[1].Length > 5 && E[0].Length >= 4 && !hasSpecialChar(E[0]))
                {
                    return true;
                }
            }
            return false;
        }
        // hàm kiểm tra chuỗi truyền vào có phải là số ko
        public bool checkisNumber(string str)
        {
            foreach (char item in str)
            {
                if (!Char.IsNumber(item))
                {
                    return false;
                }
            }
            return true;
        }
        // Kiểm tra chuỗi có chứa số hay không
        public bool checkcontainNumber(string str)
        {
            foreach (char item in str)
            {
                if (Char.IsNumber(item))
                {
                    return true;
                }
            }
            return false;
        }
        // nếu có ký tự đặc biệt sẽ trả ra true và ngược lại
        public bool hasSpecialChar(string input)
        {
            string specialChar = @"\|!#$%&/()=?»«@£§€{}.-;'<>_,";
            foreach (var item in specialChar)
            {
                if (input.Contains(item))
                {
                    return true;
                }
            }

            return false;
        }
        public bool hasSpecialCharDiachi(string input)
        {
            string specialChar = @"\|!#$%&()=?»«@£§€{}-;'<>_,";
            foreach (var item in specialChar)
            {
                if (input.Contains(item))
                {
                    return true;
                }
            }

            return false;
        }
        // hàm check dữ liệu trogn textbox
        public bool checkData(string[] data = null)
        {
            bool check = true;
            foreach (string item in data)
            {
                if (string.IsNullOrWhiteSpace(item))
                {
                    check = false; break;
                }
            }
            return check;
        }
        // mã hóa mật khẩu
        public string encryption(string password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encrypt;
            UTF8Encoding encode = new UTF8Encoding();
            // mã hóa mật khẩu thành dữ liệu mã hóa
            encrypt = md5.ComputeHash(encode.GetBytes(password));
            StringBuilder encryptData = new StringBuilder();
            // tạo ra một chuỗi ký tự mới từ dữ liệu đã mã hóa
            for (int i = 0; i < encrypt.Length; i++)
            {
                encryptData.Append(encrypt[i].ToString());
            }
            return encryptData.ToString();
        }
        //  Hàm đảo ngược chuỗi
        public static string ReverseString(string s)
        {
            char[] arr = s.ToCharArray(); // chuỗi thành mảng ký tự
            Array.Reverse(arr); // đảo ngược mảng
            return new string(arr); // trả về chuỗi mới sau khi đảo mảng
        }
        // gắn salt cho hàm mã hóa
        public string saltEncryp(string password)
        {
            string finalpass = "";
            if (!String.IsNullOrEmpty(password))
            {
                string substring = password.Substring((password.Length - 1) - (password.Length - 2), password.Length - 1);
                string reverse = ReverseString(substring);
                for (int i = 0; i < password.Length - 1; i++)
                {
                    if (password.Length <= 9)
                    {
                        if (checkisNumber(password[i].ToString()) && i <= 2)
                        {
                            finalpass += "!" + "@" + password[i] + password.Substring((password.Length - 1) - (password.Length - 2), password.Length - 1) + reverse;
                        }
                        else
                        {
                            finalpass += "*" + reverse + "!" + password[i] + ReverseString(finalpass);
                        }
                    }
                    else
                    {
                        finalpass += substring + "!" + "@" + password[i] + password.Substring((password.Length - 2) - (password.Length - 3), password.Length - 1) + reverse;
                    }
                }
                
            }
            return finalpass;
        }
        // TRUYỀN PASS VÀO SALT SAU ĐÓ TRUYỀN SALT VÀO ENCRYPT
        public void LuuAnh(string fileName, string sourceDir,string backupDir)
        {
            try
            {
                string[] picList = Directory.GetFiles(sourceDir, fileName);
                // Copy picture files.
                foreach (string f in picList)
                {
                    // Remove path from the file name.
                    string fName = f.Substring(sourceDir.Length);
                    //// Use the Path.Combine method to safely append the file name to the path.
                    //// Will overwrite if the destination file already exists.
                    File.Copy(Path.Combine(sourceDir, fName), Path.Combine(backupDir, fName), true);
                }
            }
            catch 
            {
            }
        }
        #endregion
        // Tự động gởi mail
        public void GuiMail(string email, string tieude, string matkhau)
        {

                MailMessage mess = new MailMessage("professional8778782@gmail.com", email, tieude, matkhau);

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("professional8778782@gmail.com", "0936229300");
                client.Send(mess);
            
        }


    }
}
