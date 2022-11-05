using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace FioreStore.Dal
{
    public class Class1 : System.Web.UI.Page
    {
        public Class1()
        {
            LopKetNoi.ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename ='" + Server.MapPath("App_Data\\fiore_store.mdf") + "'; Integrated Security = True";
        }
        public DataTable GetList()
        {
            SqlCommand sqlCom = new SqlCommand("select * from Contacts");
            sqlCom.CommandType = CommandType.Text;

            return LopKetNoi.GetData(sqlCom);
        }
    }
}
