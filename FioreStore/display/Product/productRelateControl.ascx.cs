using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using FioreStore.Dal;

namespace FioreStore.display.Product
{
    public partial class productRelateControl : System.Web.UI.UserControl
    {
        clsProduct product = new clsProduct();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProduct();
            }
        }

        void LoadProduct()
        {
            rptProduct.DataSource = product.GetTopProduct(6);
            rptProduct.DataBind();

        }
    }
}