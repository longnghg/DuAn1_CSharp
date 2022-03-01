using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QLSQA;
namespace DAO_QLSQA
{
    public class DataProvider
    {
        private static DataProvider instance;
        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set { DataProvider.instance = value; }
        }
        private  DataProvider()
        {

        }
        private string connetionSTR = ConfigurationManager.ConnectionStrings["QLSQA"].ToString();
        public DataTable ExecuteQuery(string Query, object[] parameters = null)
        {
            DataTable table = new DataTable();
            using (SqlConnection connect = new SqlConnection(connetionSTR))
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand(Query, connect);
                if(parameters!= null)
                {
                    string[] listPara = Query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains("@"))
                        {
                            cmd.Parameters.AddWithValue(item, parameters[i]);
                                i++;
                        }
                    }
                }
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(table);
                connect.Close();
            }
            return table;

        }// xuất ds
        public DataSet ExecuteQueryDataSet(string Query, object[] parameters = null)
        {
            DataSet table = new DataSet();
            using (SqlConnection connect = new SqlConnection(connetionSTR))
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand(Query, connect);
                if (parameters != null)
                {
                    string[] listPara = Query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains("@"))
                        {
                            cmd.Parameters.AddWithValue(item, parameters[i]);
                            i++;
                        }
                    }
                }
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(table);
                connect.Close();
            }
            return table;

        }// xuất ds
        public int ExecuteNonQuery(string Query, object[] parameters = null)
        {
            int data = 0;
            using (SqlConnection connect = new SqlConnection(connetionSTR))
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand(Query, connect);
                SqlTransaction transaction;                     //khai báo một transaction
                transaction = connect.BeginTransaction();       //bắt đầu quá trình quản lý transaction
                cmd.Transaction = transaction;                  //gắn transaction với đối tượng cmd
                if (parameters != null)
                {
                    string[] listPara = Query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains("@"))
                        {
                            cmd.Parameters.AddWithValue(item, parameters[i]);
                            i++;
                        }
                    }
                }
                try
                {
                    data = cmd.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
                connect.Close();
            }
            return data;
        } // quản lý
        public object ExecuteScalar(string Query, object[] parameters = null)
        {
            object data = 0;
            using (SqlConnection connect = new SqlConnection(connetionSTR))
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand(Query, connect);
                if (parameters != null)
                {
                    string[] listPara = Query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains("@"))
                        {
                            cmd.Parameters.AddWithValue(item, parameters[i]);
                            i++;
                        }
                    }
                }
                data = cmd.ExecuteScalar();
                connect.Close();
            }
            return data;
        }// login ,...
    }
}
