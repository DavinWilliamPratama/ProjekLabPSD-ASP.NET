using ProjekLab.Controllers;
using ProjekLab.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjekLab.Views
{
    public partial class TransactionDetailPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int thId;
            if (int.TryParse(Request.QueryString["id"], out thId))
            {
                if (Session["curr_User"] == null)
                {
                    Response.Redirect("HomePage.aspx");
                }
                else
                {
                    User currUser = (User)Session["curr_User"];

                    if (currUser.RoleId == 1)
                    {
                        Response.Redirect("HomePage.aspx");
                    }
                    else
                    {
                        if (!IsPostBack)
                        {
                            FillGridUnUsedToken();
                            FillGridUsedToken();
                            int showId = TransactionController.GetShowId(thId);
                            lblShowName.Text = ShowController.GetShowDetailById(showId, lblShowName.Text);
                            lblShowAvarageRating.Text = ReviewController.GetShowAverageRating(showId);
                            lblShowDescription.Text = ShowController.GetShowDetailById(showId, lblShowDescription.Text);;
                            
                            if(TransactionController.GetAllUsedToken(thId).Count != 0)
                            {
                                btnCancel.Visible = false;
                            }
                        }
                        
                    }
                }
            }
            else
            {
                Response.Redirect("HomePage.aspx");
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            int thId = int.Parse(Request.QueryString["id"]);

            if(TransactionController.CheckTimeNow(DateTime.Now, thId) == true && TransactionController.GetAllUsedToken(thId).Count == 0)
            {
                lblerror.Text = TransactionController.DeleteOrder(thId);
            }
        }

        protected void FillGridUnUsedToken()
        {
            int thId = int.Parse(Request.QueryString["id"]);
            gvToken.DataSource = TransactionController.GetAllUnUsedToken(thId);
            gvToken.DataBind();
        }


        protected void FillGridUsedToken()
        {
            int thId = int.Parse(Request.QueryString["id"]);
            gvToken2.DataSource = TransactionController.GetAllUsedToken(thId);
            gvToken2.DataBind();
        }
    }
}