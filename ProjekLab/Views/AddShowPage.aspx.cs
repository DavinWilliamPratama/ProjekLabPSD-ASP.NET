using ProjekLab.Controllers;
using ProjekLab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjekLab.Views
{
    public partial class AddShowPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["curr_user"] == null)
            {
                Response.Redirect("LoginPage.aspx");
            }
            else
            {
                User currUser = (User)Session["curr_user"];
                if (currUser.RoleId != 1)
                {
                    Response.Redirect("HomePage.aspx");
                }
            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            User currUser = (User)Session["curr_User"];
            string name = txtName.Text;
            string url = txtUrl.Text;
            string description = txtDescription.Text;
            int sellerId = currUser.Id;
            string price = txtPrice.Text;

            string response = ShowController.AddShow(name, url, price, description, sellerId);

            if (response == "")
            {
                lblError.Text = "";
            }
            else
            {
                lblError.Text = response;
            }
        }
    }
}
