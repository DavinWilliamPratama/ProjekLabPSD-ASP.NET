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
    public partial class ShowDetailPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id;
            if(int.TryParse(Request.QueryString["id"], out id))
            {
                txtShowName.Text = ShowController.GetShowDetailById(id, txtShowName.Text);
                txtShowPrice.Text = ShowController.GetShowDetailById(id, txtShowPrice.Text);
                txtSellerName.Text = ShowController.GetShowDetailById(id, txtSellerName.Text);
                txtShowDescription.Text = ShowController.GetShowDetailById(id, txtShowDescription.Text);
                txtShowAvarageRating.Text = ReviewController.GetShowAverageRating(id);
                FillGrid();
                if (Session["curr_User"] == null)
                {
                    btnOrder.Visible = false;
                    btnUpdate.Visible = false;
                }
                else
                {
                    User currUser = (User)Session["curr_User"];

                    if (currUser.RoleId == 1 && ShowController.CheckShow(id, currUser.Id))
                    {
                        btnOrder.Visible = false;
                    }
                    else if (currUser.RoleId == 2)
                    {
                        btnUpdate.Visible = false;
                    }
                }
            }
            else
            {
                Response.Redirect("HomePage.aspx");
            }
        }

        protected void FillGrid()
        {
            int id = int.Parse(Request.QueryString["id"].ToString());
            gvReview.DataSource = ReviewController.GetShowReview(id);
            gvReview.DataBind();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"].ToString());
            Response.Redirect("UpdateShowPage.aspx?id=" + id);
        }

        protected void btnOrder_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"].ToString());
            Response.Redirect("OrderPage.aspx?id=" + id);
        }
    }
}