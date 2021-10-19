using ProjekLab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjekLab.Views
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["curr_User"] == null)
            {
                //Response.Redirect("LoginPage.aspx");
                btnTransactions.Visible = false;
                btnAccount.Visible = false;
                btnAddShow.Visible = false;
                btnReports.Visible = false;
                btnLogout.Visible = false;
                lblName.Text = "Hello Guest!";
              
            }
            else
            {
                User currUser = (User)Session["curr_User"];
                lblName.Text = "Hello " + currUser.Name + " !";
                if (currUser.RoleId == 2)
                {
                    btnLogin.Visible = false;
                    btnRegister.Visible = false;
                    btnAddShow.Visible = false;
                    btnReports.Visible = false;
                }
                else
                {
                    btnLogin.Visible = false;
                    btnRegister.Visible = false;
                    btnTransactions.Visible = false;
                }
            }

        }
        
        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterPage.aspx");
        }

        protected void btnRedeem_Click(object sender, EventArgs e)
        {
            Response.Redirect("RedeemTokenPage.aspx");
        }

        protected void btnTransactions_Click(object sender, EventArgs e)
        {
            Response.Redirect("TransactionPage.aspx");
        }

        protected void btnAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateProfilePage.aspx");
        }

        protected void btnAddShow_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddShowPage.aspx");
        }

        protected void btnReports_Click(object sender, EventArgs e)
        {
            Response.Redirect("TransactionReportPage.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {

            Session["curr_User"] = null;
            Session.Remove("curr_User");

            Response.Redirect("LoginPage.aspx");
        }
    }
}