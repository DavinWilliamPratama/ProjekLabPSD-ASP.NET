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
    public partial class HomePage : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //gvShow.Columns[0].Visible = false;
            /*    User user = (User)Session["user"];

                 if (!user.Role.Equals("1"))
                 {
                 btnManageShow.Visible = false;

                 }
                 else
                 {
                     btnRedeem.Visible = false;
                 btnHistory.Visible = false;
             }

             if (user)
             {
                 btnRegister.Visible = false;
                 btnSignin.Visible = false;
             }
             */

            fillGrid();
        }


        protected void fillGrid()
        {

            gvShow.DataSource = ShowController.GetAllShows();
            gvShow.DataBind();

        }


        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            Session.Abandon();
            Response.Redirect("LoginPage.aspx");
        }

        protected void btnManageShow_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageProductPage.aspx");
        }

        protected void btnRedeem_Click(object sender, EventArgs e)
        {
            Response.Redirect("RedeemPage.aspx");
        }

        protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "btnDetail")
            {
                int currentRow = Convert.ToInt32(e.CommandArgument.ToString());
                int id = int.Parse(gvShow.Rows[currentRow].Cells[0].Text);


                Response.Redirect("ShowDetailPage.aspx?id=" + id);
            }
        }

    }
}