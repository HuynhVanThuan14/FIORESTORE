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
    public partial class SiteMaster : MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                return;
            }
            DropDownListt1.Items.Add("All");
            //DropDownList1.Items.Add("Sort by latest");
            //DropDownList1.Items.Add("Sort by price: low to high");
            //DropDownList1.Items.Add("Sort by price: high to low");
        }
    }
}