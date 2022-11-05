using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FioreStore.Dal;

namespace FioreStore.display
{
    public partial class menuCountControl : System.Web.UI.UserControl
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
            DataTable dt = new DataTable();
            dt = product.GetListProductCategory();
           
            dt.Columns.Add("Count", typeof(int));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["Count"] = product.CountProductCatagory(int.Parse(dt.Rows[i]["ProID"].ToString())).ToString();
            }

            DataList1.DataSource = dt;
            DataList1.DataBind();
        }
    }
}