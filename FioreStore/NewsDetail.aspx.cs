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
    public partial class NewsDetail : System.Web.UI.Page
    {
        clsNew _news = new clsNew();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            DataList2.DataSource = _news.GetNewsList();
            DataList2.DataBind();
            if (Request.QueryString["id"] != null) 
            {
                int DelID = int.Parse(Request.QueryString["id"].ToString()); 
                DataTable dt = new DataTable();
                dt = _news.GetNewsDetail(DelID); 
                if(dt.Rows.Count > 0) 
                {
                    ltTitle.Text = dt.Rows[0]["Title"].ToString();
                    ltContent.Text = dt.Rows[0]["Content"].ToString();
                    ltDesc.Text = dt.Rows[0]["Desc"].ToString();
                    ltAuthor.Text = dt.Rows[0]["Author"].ToString();
                    img.ImageUrl = "Image/" + dt.Rows[0]["Image"].ToString();

                    dt = _news.GetNewsDetailOther(DelID);
                    if(dt.Rows.Count > 0)
                    {
                        DataList1.DataSource = dt;
                        DataList1.DataBind();
                    }

                }
            }
        }
    }
}