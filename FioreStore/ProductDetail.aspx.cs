using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using FioreStore.Dal;

namespace FioreStore
{
    public partial class ProductDetail : System.Web.UI.Page
    {
        
        clsProductCart _cart = new clsProductCart();
        clsProduct product = new clsProduct();
        int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }
            if (Request.QueryString["id"] != null)
            {
                int ProDelID = int.Parse(Request.QueryString["id"].ToString());
                id = ProDelID;
                DataTable dt = new DataTable();
                dt = product.GetProductDetailById(ProDelID);
                int ProID = int.Parse(dt.Rows[0]["ProID"].ToString());


                if (dt.Rows.Count > 0)
                {
                    rptProDetail.DataSource = dt;
                    rptProDetail.DataBind();
                    
                }

                //DataTable dt1 = new DataTable();
                dt = product.GetListProductByProId(ProDelID, ProID);
                if (dt.Rows.Count > 0)
                {
                    rptProduct.DataSource = dt;
                    rptProduct.DataBind();
                }

                dt = product.GetNameByProID(ProID);
                lblDanhmuc.Text = dt.Rows[0]["Name"].ToString();


            }

        }

        protected void lnkCart_Click(object sender, EventArgs e)
        {
            LinkButton bt = (LinkButton)sender;
            RepeaterItem item = (RepeaterItem)bt.Parent;
            int soluong = int.Parse(((TextBox)item.FindControl("txtQuantity")).Text);

            
            _cart.ShoppingCart_AddCart(id, soluong);
            Response.Redirect("Cart.aspx");
        }


    }
}