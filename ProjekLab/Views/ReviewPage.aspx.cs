using ProjekLab.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjekLab.Views
{
    public partial class ReviewPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string token = Request.QueryString["Token"];
            
            if (TransactionController.GetThIdByToken(token) != 0) 
            {
                int thId = TransactionController.GetThIdByToken(token);
                int showId = TransactionController.GetShowId(thId);
                if (!IsPostBack)
                {
                    lblShowName.Text = ShowController.GetShowDetailById(showId, lblShowName.Text);
                    lblSellerName.Text = ShowController.GetShowDetailById(showId, lblSellerName.Text);
                    lblShowDescription.Text = ShowController.GetShowDetailById(showId, lblShowDescription.Text);

                    string url = ShowController.GetShowUrl(showId);

                    if (TransactionController.CheckTokenStatus(token))
                    {
                        if (TransactionController.UseToken(token))
                        {
                            Response.Write("<script> window.open('" + url + "','_blank'); </script>");
                        }
                    }
                    
                }
                if (ReviewController.GetReviewStatus(token))
                {
                    btnRate.Visible = false;
                }
                else
                {
                    btnDelete.Visible = false;
                    btnUpdate.Visible = false;
                }
            }
            else
            {
                Response.Redirect("HomePage.aspx");
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string token = Request.QueryString["Token"];
            string rating = txtRating.Text;
            string desc = txtDesc.Text;
            string response = ReviewController.UpdateReview(token, rating, desc);
            lblError.Text = response;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string token = Request.QueryString["Token"];
            string response = ReviewController.DeleteReview(token);
            lblError.Text = response;
        }

        protected void btnRate_Click(object sender, EventArgs e)
        {
            string token = Request.QueryString["Token"];
            string rating = txtRating.Text;
            string desc = txtDesc.Text;
            string response = ReviewController.AddReview(token, rating, desc);
            lblError.Text = response;
        }
    }
}