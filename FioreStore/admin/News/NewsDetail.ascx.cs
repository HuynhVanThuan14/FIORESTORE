using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FioreStore.Dal;

namespace FioreStore.admin.News
{
    public partial class NewsDetail : System.Web.UI.UserControl
    {

        clsNew _news = new clsNew();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadNewsDetail();
                LoadDataDropDownlist();
            }
        }

        void LoadDataDropDownlist()
        {
            drpNewsCategory.DataSource = _news.GetList();
            drpNewsCategory.DataValueField = "CateID";
            drpNewsCategory.DataTextField = "Name";
            drpNewsCategory.DataBind();
        }
        

        void LoadNewsDetail()
        {
            rptNewsDetails.DataSource = _news.GetListNewsDetail();
            rptNewsDetails.DataBind();
        }

        protected void btnTest_Click(object sender, EventArgs e)
        {
            Response.Write(txtContent.Text);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //upload image
            string typefile = "";
            string file = "";
            if(fUp.FileName.Length > 0)
            {
                if(fUp.PostedFile.ContentLength < 5000000)
                {
                    if(fUp.PostedFile.ContentType.Equals("image/jpeg") || fUp.PostedFile.ContentType.Equals("image/pjpeg") || fUp.PostedFile.ContentType.Equals("image/x-png") || fUp.PostedFile.ContentType.Equals("image/png") || fUp.PostedFile.ContentType.Equals("image/gif") || fUp.PostedFile.ContentType.Equals("application/x-shockwave-flash"))
                    {
                        typefile = Path.GetExtension(fUp.FileName).ToLower();
                        file = System.IO.Path.GetFileName(fUp.PostedFile.FileName);
                        file = fUp.FileName.Replace(file, "group1" + DateTime.Now.Hour + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Minute + DateTime.Now.Second + typefile);
                        fUp.PostedFile.SaveAs(Server.MapPath("~/Image/") + file);
                    }
                }
            }

            // them moi data
            if (!string.IsNullOrEmpty(txtTitle.Text.Trim()))
            {

                if(hdInsert.Value == "insert")
                {
                    //insert
                    bool active = chkActive.Checked ? true : false;
                    _news.InsertDetail(int.Parse(drpNewsCategory.SelectedValue.ToString()), txtTitle.Text.Trim(), txtDesc.Text.Trim(), txtContent.Text.Trim(), file, DateTime.Now, txtAuthor.Text.Trim(), active);
                }
                else
                {
                    // cap nhat
                    bool active = chkActive.Checked ? true : false;
                    _news.UpdateDetail(int.Parse(hdDelID.Value.ToString()),int.Parse(drpNewsCategory.SelectedValue.ToString()), txtTitle.Text.Trim(), txtDesc.Text.Trim(), txtContent.Text.Trim(), file, txtAuthor.Text.Trim(), active);
                }
                
                Response.Redirect(Request.Url.ToString());
            }
        }

        protected void lnkAdd_Click(object sender, EventArgs e)
        {
            hdInsert.Value = "insert";

            mul.ActiveViewIndex = 1;
        }

        protected void rptNewsDetails_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = _news.GetListNewsDetail_by_DelID(int.Parse(e.CommandArgument.ToString()));
            switch (e.CommandName.ToString())
            {
                case "update":
                    if(dt.Rows.Count > 0)
                    {
                        txtTitle.Text = dt.Rows[0]["Title"].ToString();
                        txtDesc.Text = dt.Rows[0]["Desc"].ToString();
                        txtContent.Text = dt.Rows[0]["Content"].ToString();
                        txtAuthor.Text = dt.Rows[0]["Author"].ToString();
                        chkActive.Checked = ((bool)dt.Rows[0]["Active"]) ? true : false;
                        hdImage.Value = dt.Rows[0]["Image"].ToString();

                        hdDelID.Value = e.CommandArgument.ToString();
                        hdInsert.Value = "update";
                    }
                    break;
                case "delete":

                    break;
            }
        }

        protected void lnkUpdate_Click(object sender, EventArgs e)
        {
            hdInsert.Value = "update";

            mul.ActiveViewIndex = 1;

        }
    }
}