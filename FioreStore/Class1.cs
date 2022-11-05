using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using FioreStore.Dal;

namespace FioreStore
{
    public class Class1 : System.Web.UI.Page
    {
        public Class1()
        {
            LopKetNoi.ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename ='" + Server.MapPath("App_Data\\fiore_store.mdf") + "'; Integrated Security = True";
        }

        public DataTable GetContact()
        {
            // chọn từ tin tức chi tiết với điều kiện active =true, order(sắp xếp theo ngày tạo mới nhất)
            SqlCommand sqlCom = new SqlCommand("select * from Contacts");
            sqlCom.CommandType = CommandType.Text;
            return LopKetNoi.GetData(sqlCom);
        }
    }
}