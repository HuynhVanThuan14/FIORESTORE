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
    public partial class _Default : Page
    {
        clsProduct product = new clsProduct();
        protected void Page_Load(object sender, EventArgs e)
        {
            //switch (Request["f"])
            //{
            //    case "news":
            //        Controls.Add(LoadControl("display/news/dNewsList.ascx"));
            //        break;
            //    case "contact":
            //        break;
            //    default:
            //        break;
            //}
            if (!IsPostBack)
            {
                LoadNewProduct();
                LoadBestPriceProduct();
            }

        }

        void LoadNewProduct()
        {
            DataTable dt = new DataTable();
            dt = product.GetNewProduct(6);
            if(dt.Rows.Count > 0)
            {
                rptNewProduct.DataSource = dt;
                rptNewProduct.DataBind();
            }
        }

        void LoadBestPriceProduct()
        {
            DataTable dt = new DataTable();
            dt = product.GetBestPriceProduct(8);
            if (dt.Rows.Count > 0)
            {
                rptPriceProduct.DataSource = dt;
                rptPriceProduct.DataBind();
            }
        }
    }
}