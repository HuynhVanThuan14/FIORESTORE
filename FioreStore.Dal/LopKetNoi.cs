using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;

namespace FioreStore.Dal
{
    public class LopKetNoi : System.Web.UI.Page
    {
        static string _ConnectionString = "";

        public LopKetNoi()
        {
            //ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename ='" + Server.MapPath("App_Data\\fiore_store.mdf") + "'; Integrated Security = True";
        }
        public static string ConnectionString
        {
            set
            {
                _ConnectionString = value;

            }
            get
            {
                return _ConnectionString;
            }
        }

        public static SqlConnection GetConnection()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            return con;
        }

        public static void ExecuteNoneQuery(SqlCommand cmd)
        {
            if (cmd.Connection != null)
            {
                cmd.ExecuteNonQuery();
            }
            else
            {
                using (SqlConnection con = GetConnection())
                {
                    cmd.Connection = GetConnection();
                    cmd.ExecuteNonQuery();
                }
            }
        }



        public static DataTable GetData(SqlCommand cmd)
        {
            if (cmd.Connection != null)
            {
                using (DataSet ds = new DataSet())
                {
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = cmd;
                        da.Fill(ds);
                        return ds.Tables[0];
                    }
                }
            }
            else
            {
                using (SqlConnection con = GetConnection())
                {
                    using (DataSet ds = new DataSet())
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter())
                        {
                            cmd.Connection = con;
                            da.SelectCommand = cmd;
                            da.Fill(ds);
                            return ds.Tables[0];
                        }
                    }
                }
            }
        }

        public static int ExcuteScalar(SqlCommand cmd)
        {
            int a;
            if (cmd.Connection != null)
            {
                a = int.Parse(cmd.ExecuteScalar().ToString());
            }
            else
            {
                using (SqlConnection con = GetConnection())
                {
                    cmd.Connection = GetConnection();
                    a = int.Parse(cmd.ExecuteScalar().ToString());
                }
            }
            return a;
        }
    }
}
