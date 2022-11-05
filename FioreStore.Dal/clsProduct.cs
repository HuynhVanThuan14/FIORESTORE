using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace FioreStore.Dal
{
    public class clsProduct : System.Web.UI.Page
    {

        public clsProduct()
        {
            LopKetNoi.ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename ='" + Server.MapPath("App_Data\\fiore_store.mdf") + "'; Integrated Security = True";
        }
        public DataTable GetListProductCategory()
        {
            SqlCommand sqlComm = new SqlCommand("select * from Product_Categories where Active = 'True' order by [Order]");
            sqlComm.CommandType = CommandType.Text;
            return LopKetNoi.GetData(sqlComm);
        }

        public DataTable GetListProductCategoryById(int ProID)
        {
            SqlCommand sqlComm = new SqlCommand("select * from Product_Detail where Active = 'True' and ProID = " + ProID);
            sqlComm.CommandType = CommandType.Text;
            return LopKetNoi.GetData(sqlComm);
        }

        // chon top san pham moi nhat
        public DataTable GetNewProduct(int top)
        {
            SqlCommand sqlComm = new SqlCommand("select top " + top + " * from Product_Detail where Active = 'True' Order by CreateDate Desc");
            sqlComm.CommandType = CommandType.Text;
            return LopKetNoi.GetData(sqlComm);
        }

        public DataTable SortAllNewProduct()
        {
            SqlCommand sqlComm = new SqlCommand("select  * from Product_Detail where Active = 'True' Order by CreateDate Desc");
            sqlComm.CommandType = CommandType.Text;
            return LopKetNoi.GetData(sqlComm);
        }

        public DataTable GetBestPriceProduct(int top)
        {
            SqlCommand sqlComm = new SqlCommand("select top " + top + " * from Product_Detail where Active = 'True' Order by Price Desc");
            sqlComm.CommandType = CommandType.Text;
            return LopKetNoi.GetData(sqlComm);
        }

        public DataTable SortHighToLowPrice()
        {
            SqlCommand sqlComm = new SqlCommand("select  * from Product_Detail where Active = 'True' Order by Price Desc");
            sqlComm.CommandType = CommandType.Text;
            return LopKetNoi.GetData(sqlComm);
        }

        public DataTable SortLowToHighPrice()
        {
            SqlCommand sqlComm = new SqlCommand("select  * from Product_Detail where Active = 'True' Order by Price Asc");
            sqlComm.CommandType = CommandType.Text;
            return LopKetNoi.GetData(sqlComm);
        }

        public int CountProductCatagory(int ProID)
        {
            SqlCommand sqlComm = new SqlCommand("select count(*) from Product_Detail where ProID = " + ProID);
            sqlComm.CommandType = CommandType.Text;
            return LopKetNoi.ExcuteScalar(sqlComm);
        }

        public DataTable GetAllProduct()
        {
            SqlCommand sqlComm = new SqlCommand("select * from Product_Detail where Active = 'True'");
            sqlComm.CommandType = CommandType.Text;
            return LopKetNoi.GetData(sqlComm);
        }

        public DataTable GetTopProduct(int top)
        {
            SqlCommand sqlComm = new SqlCommand("select top "+top+" * from Product_Detail where Active = 'True'");
            sqlComm.CommandType = CommandType.Text;
            return LopKetNoi.GetData(sqlComm);
        }

        public DataTable GetTopNewProduct(int top)
        {
            SqlCommand sqlComm = new SqlCommand("select top " + top + " * from Product_Detail where Active = 'True' order by CreateDate Desc");
            sqlComm.CommandType = CommandType.Text;
            return LopKetNoi.GetData(sqlComm);
        }

        //tim kiem san pham 
        public DataTable SearchProductByName(string Name)
        {
            SqlCommand sqlComm = new SqlCommand("select * from Product_Detail where Active = 'True' and Name like N'%" + Name + "%'");
            sqlComm.CommandType = CommandType.Text;
            return LopKetNoi.GetData(sqlComm);
        }

        public DataTable SearchProductByNameWhereID(string Name, int ProID)
        {
            SqlCommand sqlComm = new SqlCommand("select * from Product_Detail where Active = 'True' and ProID = " + ProID + " and Name like N'%" + Name + "%'");
            sqlComm.CommandType = CommandType.Text;
            return LopKetNoi.GetData(sqlComm);
        }

        public DataTable SortProductByPriceDescWhereProId(int ProID)
        {
            SqlCommand sqlComm = new SqlCommand("select * from Product_Detail where Active = 'True' and ProID = " + ProID + " Order by Price Desc");
            sqlComm.CommandType = CommandType.Text;
            return LopKetNoi.GetData(sqlComm);
        }

        public DataTable SortProductByPriceAscWhereProId(int ProID)
        {
            SqlCommand sqlComm = new SqlCommand("select * from Product_Detail where Active = 'True' and ProID = " + ProID + " Order by Price Asc");
            sqlComm.CommandType = CommandType.Text;
            return LopKetNoi.GetData(sqlComm);
        }

        public DataTable SortProductByCreateDateWhereProId(int ProID)
        {
            SqlCommand sqlComm = new SqlCommand("select * from Product_Detail where Active = 'True' and ProID = " + ProID + " Order by CreateDate Desc");
            sqlComm.CommandType = CommandType.Text;
            return LopKetNoi.GetData(sqlComm);
        }

        // load chi tiet san pham theo id
        public DataTable GetProductDetailById(int ProDelID)
        {
            SqlCommand sqlComm = new SqlCommand("select * from Product_Detail where Active = 'True' and ProDelID = " + ProDelID);
            sqlComm.CommandType = CommandType.Text;
            return LopKetNoi.GetData(sqlComm);
        }

        //load danh sach san pham cung ProID
        public DataTable GetListProductByProId(int ProDelID, int ProID)
        {
            SqlCommand sqlComm = new SqlCommand("select top 4 * from Product_Detail where Active = 'True' and ProDelID != " + ProDelID + " and ProID = " + ProID);
            sqlComm.CommandType = CommandType.Text;
            return LopKetNoi.GetData(sqlComm);
        }

        //lay ten cua danh muc san pham
        public DataTable GetNameByProID(int ProID)
        {
            SqlCommand sqlComm = new SqlCommand("select * from Product_Categories where Active = 'True' and ProID = " + ProID);
            sqlComm.CommandType = CommandType.Text;
            return LopKetNoi.GetData(sqlComm);
        }
    }
}
