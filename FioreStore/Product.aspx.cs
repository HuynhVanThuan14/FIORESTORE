using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using FioreStore.Dal;
using System.Collections;

namespace FioreStore
{
    public partial class Product : System.Web.UI.Page
    {
        clsProduct product = new clsProduct();
        int ProID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            //switch (Request["p"])
            //{
            //    case "all":
            //        Control myCtrl = LoadControl("MyControl.ascx");
            //        ((MyControl)myCtrl).CustomText = "Sample Text";                   
            //        Page.FindControl("Content1").Controls.Add(myCtrl);
            //        break;
            //}
            if (!IsPostBack)
            {
                LoadDropDownListSearch();
                LoadDropDownListSort();
                LoadProduct();

            }



            if (Request.QueryString["id"] != null)
            {
                int ProID = int.Parse(Request.QueryString["id"].ToString());
                DataTable dt = new DataTable();
                dt = product.GetListProductCategoryById(ProID);


                if (dt.Rows.Count > 0)
                {
                    rptProduct.DataSource = dt;
                    rptProduct.DataBind();
                }

            }
        }

        void LoadDropDownListSearch()
        {
            DataTable dt = new DataTable();
            dt = product.GetListProductCategory();

            // generate the data you want to insert
            DataRow toInsert = dt.NewRow();
            toInsert[0] = 0;
            toInsert[1] = "All";
            // insert in the desired place
            dt.Rows.InsertAt(toInsert, 0);

            if (dt.Rows.Count > 0)
            {
                DropDownList1.DataSource = dt;
                DropDownList1.DataBind();
                DropDownList1.DataTextField = "Name";
                DropDownList1.DataValueField = "ProID";
                DropDownList1.DataBind();
            }
        }

        void LoadDropDownListSort()
        {
            DropDownList2.Items.Add("Relevance");
            DropDownList2.Items.Add("Sort by latest");
            DropDownList2.Items.Add("Sort by price: low to high");
            DropDownList2.Items.Add("Sort by price: high to low");


        }

        void LoadProduct()
        {
            DataTable dt = new DataTable();
            dt = product.GetAllProduct();

            if (dt.Rows.Count > 0)
            {
                rptProduct.DataSource = dt;
                rptProduct.DataBind();
            }
        }

        public void LoadProductSearch(string Name)
        {
            DataTable dt = new DataTable();
            dt = product.SearchProductByName(Name);
            rptProduct.DataSource = dt;
            rptProduct.DataBind();
            if (dt.Rows.Count > 0)
            {
                lblThongBao.Visible = false;
            }
            else
            {
                lblThongBao.Visible = true;
                lblThongBao.Text = "Không tìm thấy sản phẩm!";
            }


        }

        public void LoadProductSearchById(string Name, int ProID)
        {
            DataTable dt = new DataTable();
            dt = product.SearchProductByNameWhereID(Name, ProID);
            rptProduct.DataSource = dt;
            rptProduct.DataBind();
            if (dt.Rows.Count > 0)
            {
                lblThongBao.Visible = false;
            }
            else
            {
                lblThongBao.Visible = true;
                lblThongBao.Text = "Không tìm thấy sản phẩm!";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ProID = int.Parse(DropDownList1.SelectedItem.Value);
            if (ProID == 0)
            {
                LoadProductSearch(TextBox1.Text.ToString());
            }
            else
            {
                LoadProductSearchById(TextBox1.Text.ToString(), ProID);
            }

        }

        // all product
        void LoadProductSortByPriceDesc()
        {

            DataTable dt = new DataTable();
            dt = product.SortHighToLowPrice();

            if (dt.Rows.Count > 0)
            {
                rptProduct.DataSource = dt;
                rptProduct.DataBind();
            }
        }

        void LoadProductSortByPriceAsc()
        {

            DataTable dt = new DataTable();
            dt = product.SortLowToHighPrice();

            if (dt.Rows.Count > 0)
            {
                rptProduct.DataSource = dt;
                rptProduct.DataBind();
            }
        }

        void LoadProductSortByCreateDateDesc()
        {

            DataTable dt = new DataTable();
            dt = product.SortAllNewProduct();

            if (dt.Rows.Count > 0)
            {
                rptProduct.DataSource = dt;
                rptProduct.DataBind();
            }
        }


        // product by id
        void LoadProductSortByPriceDescById()
        {

            DataTable dt = new DataTable();
            dt = product.SortProductByPriceDescWhereProId(ProID);

            if (dt.Rows.Count > 0)
            {
                rptProduct.DataSource = dt;
                rptProduct.DataBind();
            }
        }

        void LoadProductSortByPriceAscById()
        {

            DataTable dt = new DataTable();
            dt = product.SortProductByPriceAscWhereProId(ProID);

            if (dt.Rows.Count > 0)
            {
                rptProduct.DataSource = dt;
                rptProduct.DataBind();
            }
        }

        void LoadProductSortByCreateDateDescById()
        {

            DataTable dt = new DataTable();
            dt = product.SortProductByCreateDateWhereProId(ProID);

            if (dt.Rows.Count > 0)
            {
                rptProduct.DataSource = dt;
                rptProduct.DataBind();
            }
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

            ProID = int.Parse(DropDownList1.SelectedItem.Value);

            if (ProID == 0)
            {

                if (DropDownList2.SelectedItem.Text.ToString() == "Sort by latest")
                {
                    //lblThongBao.Visible = true;
                    //lblThongBao.Text = "(all product)  (orderby: latest)";
                    LoadProductSortByCreateDateDesc();
                }
                else if (DropDownList2.SelectedItem.Text.ToString() == "Sort by price: low to high")
                {
                    //lblThongBao.Visible = true;
                    //lblThongBao.Text = "(all product)  (orderby: low to high)";
                    LoadProductSortByPriceAsc();
                }
                else
                {
                    //lblThongBao.Visible = true;
                    //lblThongBao.Text = "(all product)  (orderby: high to low)";
                    LoadProductSortByPriceDesc();
                }
            }
            else
            {
                //lblThongBao.Visible = true;
                //lblThongBao.Text = "(" + DropDownList1.SelectedItem.Text + ")";
                if (DropDownList2.SelectedItem.Text.ToString() == "Sort by latest")
                {
                    //lblThongBao.Text += "  (orderby: latest)";
                    LoadProductSortByPriceDescById();
                }
                else if (DropDownList2.SelectedItem.Text.ToString() == "Sort by price: low to high")
                {
                    //lblThongBao.Text += "  (orderby: low to high)";
                    LoadProductSortByPriceAscById();
                }
                else
                {
                    //lblThongBao.Visible = true;
                    //lblThongBao.Text = ProID.ToString();
                    LoadProductSortByPriceDescById();
                }
            }
        }

        //public int PageNumber
        //{
        //    get
        //    {
        //        if (ViewState["PageNumber"] != null)
        //        {
        //            return Convert.ToInt32(ViewState["PageNumber"]);
        //        }
        //        else
        //        {
        //            return 0;
        //        }
        //    }
        //    set { ViewState["PageNumber"] = value; }
        //}


        //private void BindRepeater()
        //{
        //    //Do your database connection stuff and get your data
        //    SqlConnection cn = new SqlConnection(yourConnectionString);
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.Connection = cn;
        //    SqlDataAdapter ad = new SqlDataAdapter(cmd);
        //    cmd.CommandText = "Select * from YourTable";

        //    //save the result in data table
        //    DataTable dt = new DataTable();
        //    ad.SelectCommand = cmd;
        //    ad.Fill(dt);

        //    //Create the PagedDataSource that will be used in paging
        //    PagedDataSource pgitems = new PagedDataSource();
        //    pgitems.DataSource = dt.DefaultView;
        //    pgitems.AllowPaging = true;

        //    //Control page size from here 
        //    pgitems.PageSize = 4;
        //    pgitems.CurrentPageIndex = PageNumber;
        //    if (pgitems.PageCount > 1)
        //    {
        //        rptProduct.Visible = true;
        //        ArrayList pages = new ArrayList();
        //        for (int i = 0; i <= pgitems.PageCount - 1; i++)
        //        {
        //            pages.Add((i + 1).ToString());
        //        }
        //        rptProduct.DataSource = pages;
        //        rptProduct.DataBind();
        //    }
        //    else
        //    {
        //        rptProduct.Visible = false;
        //    }

        //    //Finally, set the datasource of the repeater
        //    rptProduct.DataSource = pgitems;
        //    rptProduct.DataBind();
        //}

        ////This method will fire when clicking on the page no link from the pager repeater
        //protected void rptPaging_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        //{
        //    PageNumber = Convert.ToInt32(e.CommandArgument) - 1;
        //    BindRepeater();
        //}
    }
}