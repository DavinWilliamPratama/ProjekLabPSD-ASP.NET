using ProjekLab.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjekLab.Views
{
    public partial class RedeemTokenPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string token = txtRedeem.Text;
            int thId = TransactionController.GetThIdByToken(token);

            if (thId != 0)
            {
                Response.Redirect("ReviewPage.aspx?Token=" + token);
            }
            else
            {
                lblError.Text = "Invalid Token!";
            }
        }
    }
}