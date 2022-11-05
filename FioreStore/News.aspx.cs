using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FioreStore.Dal;

namespace FioreStore
{
    public partial class News : System.Web.UI.Page
    {
        clsNew _news = new clsNew();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadList();
            }
        }

        void LoadList()
        {
            DataList1.DataSource = _news.GetNewsList();
            DataList1.DataBind();
            DataList2.DataSource = _news.GetNewsList();
            DataList2.DataBind();
        }
    }
}