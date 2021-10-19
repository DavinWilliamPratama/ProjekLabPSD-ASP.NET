using ProjekLab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjekLab.Views
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session["curr_user"] != null)
                {
                    Response.Redirect("HomePage.aspx");
                }
                else
                {
                    if (Request.Cookies["username"] != null && Request.Cookies["password"] != null)
                    {
                        txtUsername.Text = Request.Cookies["username"].Value;
                        txtPassword.Attributes["value"] = Request.Cookies["password"].Value;
                    }
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            string response = UserController.CheckLogin(username, password);

            if (response == "")
            {
                Session["curr_User"] = UserController.GetUser(username, password);

                if (chkRemember.Checked)
                {
                    HttpCookie newCookie = new HttpCookie("username", username);
                    newCookie.Expires = DateTime.Now.AddHours(2);
                    Response.Cookies.Add(newCookie);

                    newCookie = new HttpCookie("password", password);
                    newCookie.Expires = DateTime.Now.AddHours(2);
                    Response.Cookies.Add(newCookie); newCookie = new HttpCookie("username", username);
                    newCookie.Expires = DateTime.Now.AddHours(2);
                    Response.Cookies.Add(newCookie);
                }

                Response.Redirect("HomePage.aspx");

            }
            else
            {
                lblError.Text = "Username or Password Incorrect";
            }

        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterPage.aspx");
        }
    }
}