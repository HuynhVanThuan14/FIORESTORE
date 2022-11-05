using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FioreStore.Dal;
using System.Data;
using System.Data.SqlClient;

namespace FioreStore.admin.News
{
    public partial class NewsCategory : System.Web.UI.UserControl
    {
        clsNew _news = new clsNew(); 
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        void LoadData()
        {
            rptNewsCategory.DataSource = _news.GetList();
            rptNewsCategory.DataBind();
        }

        protected void Delete_Load(object sender, System.EventArgs e)
        {
            ((LinkButton)sender).Attributes["onclick"] = "return confirm('Delete selected Category?')";
        }

        protected void lnkAddNew_Click(object sender, EventArgs e)
        {
            hdInsert.Value = "insert";
            mul.ActiveViewIndex = 1;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if(hdInsert.Value == "insert")
            {
                if (!string.IsNullOrEmpty(txtCategoryName.Text.Trim()))
                {
                    bool active = chkActive.Checked ? true : false;
                    _news.Insert(txtCategoryName.Text.Trim(), int.Parse(txtOrder.Text.Trim()), active);
                    Response.Redirect(Request.Url.ToString());
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(txtCategoryName.Text.Trim()))
                {
                    bool active = chkActive.Checked ? true : false;
                    _news.Update(int.Parse(hdCategoryID.Value),txtCategoryName.Text.Trim(), int.Parse(txtOrder.Text.Trim()), active);
                    Response.Redirect(Request.Url.ToString());
                }
            }
            
        }

        protected void rptNewsCategory_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            DataTable dt = new DataTable();
            switch (e.CommandName.ToString())
            {
                case "update":
                    dt = _news.GetListbyCategoryID(int.Parse(e.CommandArgument.ToString()));
                    if (dt.Rows.Count > 0)
                    {
                        txtCategoryName.Text = dt.Rows[0]["Name"].ToString();
                        txtOrder.Text = dt.Rows[0]["Order"].ToString();
                        chkActive.Checked = ((bool)dt.Rows[0]["Active"]) ? true : false;
                        hdCategoryID.Value = e.CommandArgument.ToString();
                        hdInsert.Value = "update";
                        mul.ActiveViewIndex = 1;
                    }
                    break;
                case "delete":
                    dt = _news.GetListbyCategoryID(int.Parse(e.CommandArgument.ToString()));
                    if (dt.Rows.Count > 0)
                    {
                        _news.Delete(int.Parse(e.CommandArgument.ToString()));
                        Response.Redirect(Request.Url.ToString());
                    }
                    break;
            }
        }
    }
}