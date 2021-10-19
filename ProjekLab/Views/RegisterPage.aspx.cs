using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjekLab.Views
{
    public partial class RegisterPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                Response.Redirect("HomePage.aspx");
            }
        }

        protected void linkLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string confirmpassword = txtConfirmPassword.Text;
            string role = ddlRole.Text;

            string response = UserController.CheckRegister(name, username, password, confirmpassword, role);

            if (response == "")
            {
                Response.Redirect("LoginPage.aspx");
            }
            else
            {
                lblError.Text = response;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

        }
    }
}
