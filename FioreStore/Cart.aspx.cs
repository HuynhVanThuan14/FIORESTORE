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
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["cart"] != null)
            {
                DataTable dtCart = (DataTable)Session["cart"];
                rptProductCart.DataSource = dtCart;
                rptProductCart.DataBind();


                int total = 0;
                for(int i = 0; i <dtCart.Rows.Count; i++)
                {
                    total += int.Parse(dtCart.Rows[i]["Money"].ToString());
                }
                ltTotal.Text = string.Format("{0:N0}",total);
            }
        }
    }
}