using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace FioreStore.Dal
{
    public class clsNew : System.Web.UI.Page
    {
        public clsNew()
        {
            LopKetNoi.ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename ='" + Server.MapPath("App_Data\\fiore_store.mdf") + "'; Integrated Security = True";
        }

        //
        public DataTable GetList()
        {
            SqlCommand sqlCom = new SqlCommand("select * from News_Categories");
            sqlCom.CommandType = CommandType.Text;

            return LopKetNoi.GetData(sqlCom);
        }

        public object GetContact()
        {
            throw new NotImplementedException();
        }

        public DataTable GetListbyCategoryID(int CategoryID)
        {
            SqlCommand sqlCom = new SqlCommand("Select * from News_Categories where CateID=@categoryID");
            sqlCom.CommandType = CommandType.Text;
            sqlCom.Parameters.AddWithValue("@categoryID", CategoryID);
            return LopKetNoi.GetData(sqlCom);

        }
        public void Insert(string Name, int Order, bool Active)
        {
            SqlCommand sqlCom = new SqlCommand("insert into News_Categories values(@name, @order, @active)");
            sqlCom.Parameters.AddWithValue("@name", Name);
            sqlCom.Parameters.AddWithValue("@order", Order);
            sqlCom.Parameters.AddWithValue("@active", Active);
            sqlCom.CommandType = CommandType.Text;
            LopKetNoi.ExecuteNoneQuery(sqlCom);
        }

        public void Update(int CategoryID, string CategoryName, int Order, bool Active)
        {
            SqlCommand sqlCom = new SqlCommand("Update News_Categories set Name=@categoryName, [Order]=@order, Active=@active where CateID=@categoryID");
                                                      
            sqlCom.CommandType = CommandType.Text;
            sqlCom.Parameters.AddWithValue("@categoryName", CategoryName);
            sqlCom.Parameters.AddWithValue("@order", Order);
            sqlCom.Parameters.AddWithValue("@active", Active);
            sqlCom.Parameters.AddWithValue("@categoryID", CategoryID);
            LopKetNoi.ExecuteNoneQuery(sqlCom);
        }

        public void Delete(int CategoryID)
        {
            SqlCommand sqlCom = new SqlCommand("Delete from News_Categories where CateID=@categoryID");

            sqlCom.CommandType = CommandType.Text;
            sqlCom.Parameters.AddWithValue("@categoryID", CategoryID);
            LopKetNoi.ExecuteNoneQuery(sqlCom);
        }

        public void InsertDetail(int CateID, string Title, string Desc, string Content, string Image, DateTime CreateDate, string Author, bool Active)
        {
            SqlCommand sqlCom = new SqlCommand("Insert into News_Detail values(@cateID,@Title,@Desc,@Content, @Image, @CreateDate, @Author, @Active)");
        
            sqlCom.CommandType = CommandType.Text;  
            sqlCom.Parameters.AddWithValue("@CateID", CateID);
            sqlCom.Parameters.AddWithValue("@Title", Title);
            sqlCom.Parameters.AddWithValue("@Desc", Desc);
            sqlCom.Parameters.AddWithValue("@Content", Content);
            sqlCom.Parameters.AddWithValue("@Image", Image);
            sqlCom.Parameters.AddWithValue("@CreateDate", CreateDate);
            sqlCom.Parameters.AddWithValue("@Author", Author);
            sqlCom.Parameters.AddWithValue("@Active", Active);
            LopKetNoi.ExecuteNoneQuery(sqlCom);
        }

        public DataTable GetListNewsDetail()
        {
            SqlCommand sqlCom = new SqlCommand("Select * from News_Detail");
            sqlCom.CommandType = CommandType.Text;
            return LopKetNoi.GetData(sqlCom); 
        }

        public DataTable GetListNewsDetail_by_DelID(int DelID)
        {
            SqlCommand sqlCom = new SqlCommand("Select * from News_Detail where DelID=@DelID");
            sqlCom.CommandType = CommandType.Text;
            sqlCom.Parameters.AddWithValue("@DelID", DelID);
            return LopKetNoi.GetData(sqlCom);
        }

        public void UpdateDetail(int DelID, int CateID, string Title, string Desc, string Content, string Image, string Author, bool Active)
        {
            SqlCommand sqlCom = new SqlCommand("Update News_Detail set CateID=@CateID, Title=@Title, Desc=@Desc, Content=@Content, Image=@Image, Author=@Author, Active=@Active where DelID=@DelID;");

            sqlCom.CommandType = CommandType.Text;
            sqlCom.Parameters.AddWithValue("@DelID", DelID);
            sqlCom.Parameters.AddWithValue("@CateID", CateID);
            sqlCom.Parameters.AddWithValue("@Title", Title);
            sqlCom.Parameters.AddWithValue("@Desc", Desc);
            sqlCom.Parameters.AddWithValue("@Content", Content);
            sqlCom.Parameters.AddWithValue("@Image", Image);
            sqlCom.Parameters.AddWithValue("@Author", Author);
            sqlCom.Parameters.AddWithValue("@Active", Active);
            LopKetNoi.ExecuteNoneQuery(sqlCom);
        }

        public DataTable GetNewsList() // hien thi danh sach tin tuc
        {
            // chọn từ tin tức chi tiết với điều kiện active =true, order(sắp xếp theo ngày tạo mới nhất)
            SqlCommand sqlCom = new SqlCommand("select * from News_Detail where Active='true' order by CreateDate DESC");
            sqlCom.CommandType = CommandType.Text;
            return LopKetNoi.GetData(sqlCom);
        }

        public DataTable GetNewsDetail(int DelID)
        {
            SqlCommand sqlCom = new SqlCommand("select * from News_Detail where DelID = "+DelID+" and Active='true'");
            sqlCom.CommandType = CommandType.Text;
            return LopKetNoi.GetData(sqlCom);
        }

        public DataTable GetNewsDetailOther(int DelID)
        {
            SqlCommand sqlCom = new SqlCommand("select * from News_Detail where DelID != " + DelID + " and Active='true'");
            sqlCom.CommandType = CommandType.Text;
            return LopKetNoi.GetData(sqlCom);
        }

        public DataTable GetContact(int DelID)
        {
            SqlCommand sqlCom = new SqlCommand("select * from Contact");
            sqlCom.CommandType = CommandType.Text;
            return LopKetNoi.GetData(sqlCom);
        }
    }
}
