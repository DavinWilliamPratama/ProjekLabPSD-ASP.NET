using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjekLab.Views
{
    public partial class ManageShowPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("LoginPage.aspx");
            }
            else
            {
                User currUser = (User)Session["user"];
                if (currUser.Role != "Admin")
                {
                    Response.Redirect("HomePage.aspx");
                }
                else
                {
                    FillGrid();
                }
            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string s_price = txtPrice.Text;
            string s_qty = txtQty.Text;

            string response = ProductController.CheckInsert(name, s_price, s_qty);

            if (response == "")
            {
                lblError.Text = "";
                FillGrid();
            }
            else
            {
                lblError.Text = response;
            }
        }

        protected void FillGrid()
        {
            gvProduct.DataSource = ProductController.GetProductList();
            gvProduct.DataBind();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);

            string response = ProductController.CheckDelete(id);

            if (response == "")
            {
                lblError.Text = "";
                FillGrid();
            }
            else
            {
                lblError.Text = response;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            string name = txtName.Text;
            string s_price = txtPrice.Text;
            string s_description = txtDescription.Text;

            string response = ProductController.CheckUpdate(id, name, s_price, s_description);

            if (response == "")
            {
                lblError.Text = "";
                FillGrid();
            }
            else
            {
                lblError.Text = response;
            }
        }

        protected void linkHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}