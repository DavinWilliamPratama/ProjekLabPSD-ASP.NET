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
    public partial class UpdateShowPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id;
            if (int.TryParse(Request.QueryString["id"], out id))
            {
                if (!IsPostBack)
                {
                    txtShowName.Text = ShowController.GetShowDetailById(id, txtShowName.Text);
                    txtShowPrice.Text = ShowController.GetShowDetailById(id, txtShowPrice.Text);
                    txtSellerName.Text = ShowController.GetShowDetailById(id, txtSellerName.Text);
                    txtShowDescription.Text = ShowController.GetShowDetailById(id, txtShowDescription.Text);

                }
                if (Session["curr_User"] == null)
                {
                    Response.Redirect("HomePage.aspx");
                }
                else
                {
                    User currUser = (User)Session["curr_User"];

                    if (currUser.RoleId == 2 || ShowController.CheckShow(id, currUser.Id) == false)
                    {
                        Response.Redirect("HomePage.aspx");
                    }
                }
            }
            else 
            {
                Response.Redirect("HomePage.aspx");
            }

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            User currUser = (User)Session["curr_User"];
            int id = int.Parse(Request.QueryString["id"].ToString());
            string name = txtName.Text;
            string url = txtUrl.Text;
            string description = txtDescription.Text;
            int sellerId = currUser.Id;
            string price = txtPrice.Text;

            string response = ShowController.UpdateShow(currUser.Id, id, name, url, price, description);

            lblError.Text = response;
        }
    }
}