using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace FioreStore.Dal
{
    public class clsProductCart
    {

        public void ShoppingCart_CreateCart()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("PID", typeof(int));//ProDelID
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Price", typeof(int));
            dt.Columns.Add("Quantity", typeof(int));
            dt.Columns.Add("Money", typeof(int));
            System.Web.HttpContext.Current.Session["cart"] = dt; 
        }

        public  void ShoppingCart_AddCart(int PID, int Quantity)
        {
            if(System.Web.HttpContext.Current.Session["cart"] == null)
            {
                ShoppingCart_CreateCart();
                ShoppingCart_AddCart(PID, Quantity);

            }
            else
            {
                DataTable dt = new DataTable();
                dt = new clsProduct().GetProductDetailById(PID);
                if(dt.Rows.Count > 0)
                {
                    string name = dt.Rows[0]["Name"].ToString();
                    int price = int.Parse(dt.Rows[0]["Price"].ToString());
                    int money = price * Quantity;

                    DataTable dtCart = new DataTable();
                    dtCart = (DataTable)System.Web.HttpContext.Current.Session["cart"];

                    bool hdInsert = false;

                    for(int i = 0; i < dtCart.Rows.Count; i++)
                    {
                        if (dtCart.Rows[0]["PID"].ToString().Equals(PID))
                        {
                            hdInsert = true;
                            Quantity += int.Parse(dtCart.Rows[i]["Quantity"].ToString());
                            dtCart.Rows[i]["Quantity"] = Quantity;
                            dtCart.Rows[i]["Money"] = Quantity * Convert.ToSingle(dtCart.Rows[i]["Price"].ToString());
                            System.Web.HttpContext.Current.Session["cart"] = dtCart;
                            break;

                        }
                    }

                    if(hdInsert == false)
                    {
                        if (dtCart != null)
                        {
                            DataRow dr = dtCart.NewRow();

                            dr["PID"] = PID;
                            dr["Name"] = name;
                            dr["Quantity"] = Quantity;
                            dr["Price"] = price;
                            dr["Money"] = money;

                            dtCart.Rows.Add(dr);
                            System.Web.HttpContext.Current.Session["cart"] = dtCart;
                        }
                    }
                    
                }
            }
        }
    }
}
