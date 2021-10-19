using ProjekLab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjekLab.Views
{
    public partial class UpdateProfilePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["curr_User"] == null)
            {
                Response.Redirect("LoginPage.aspx");
            }
            else
            {
                User user = (User)Session["curr_User"];
                lblUsername.Text = UserController.ShowUserDetail(user.Id, "txtUsername");
                lblNameOld.Text = UserController.ShowUserDetail(user.Id, "txtName");
                lblRole.Text = UserController.ShowUserDetail(user.Id, "txtRole");
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string oldpassword = txtOldPassword.Text;
            string newpassword = txtNewPassword.Text;
            string confirmpassword = txtConfirmPassword.Text;
            User user = (User)Session["curr_User"];
            if (newpassword == "")
            {
                if (UserController.CheckUpdateFieldWithoutPass(user.Id, name) == "")
                {
                    lblError.Text = "Update Profile Success!";
                }
                else
                {
                    lblError.Text = UserController.CheckUpdateFieldWithoutPass(user.Id, name);
                }
            }
            else
            {
                if (UserController.CheckUpdateField(user.Id, name, oldpassword, newpassword, confirmpassword) == "")
                {
                    lblError.Text = "Update Profile Success!";
                }
                else
                {
                    lblError.Text = UserController.CheckUpdateField(user.Id, name, oldpassword, newpassword, confirmpassword);
                }
            }
        }
    }
}