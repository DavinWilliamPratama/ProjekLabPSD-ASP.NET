using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ProjekLab.Controllers;
using ProjekLab.Model;

namespace ProjekLab.Views
{
    public partial class OrderPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id;
            if (int.TryParse(Request.QueryString["id"], out id))
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
                            
                            txtShowName.Text = ShowController.GetShowDetailById(id, txtShowName.Text);
                            txtShowPrice.Text = ShowController.GetShowDetailById(id, txtShowPrice.Text);
                            txtSellerName.Text = ShowController.GetShowDetailById(id, txtSellerName.Text);
                            txtShowDescription.Text = ShowController.GetShowDetailById(id, txtShowDescription.Text);
                            txtShowAvarageRating.Text = ReviewController.GetShowAverageRating(id);

                            FillGrid();
                        }
                        //FillGrid();
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
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[2] { new DataColumn("Id", typeof(int)),
                            new DataColumn("Time",typeof(string)) });
            for (int i = 0; i < 24; i++)
            {
                if (i < 10)
                {
                    dt.Rows.Add(i+1, ("0" + i + ":00 - " + i + ":59").ToString());
                }
                else
                {
                    dt.Rows.Add(i+1,(i + ":00 - " + i + ":59").ToString());
                }
                
            }

            gvSchedule.DataSource = dt;
            gvSchedule.DataBind();
        }

        protected void gvSchedule_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int showId = int.Parse(Request.QueryString["id"]);
                DateTime date = calDate.SelectedDate;
                TableCell startCell = e.Row.Cells[1];
                string start;
                start = startCell.Text.ToString().Substring(0,2);;

                if (date.AddHours(int.Parse(start)).CompareTo(DateTime.Now) < 0 || ShowController.CheckShowTime(showId, date.AddHours(int.Parse(start))) == false)
                {
                    Button btn = (Button)e.Row.FindControl("btnOrder");
                    btn.Text = "Unavailable";
                    btn.Enabled = false;

                }
            }
        }

        protected void gvSchedule_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "btnOrder")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument.ToString());
                int showId = int.Parse(Request.QueryString["id"]);
                User user = (User)Session["curr_User"];
                DateTime selectedDate = calDate.SelectedDate;
                GridViewRow row = gvSchedule.Rows[rowIndex];
                int hours;
                if (row.Cells[1].Text.ToString()[0].Equals(0))
                {
                    hours = int.Parse(row.Cells[1].Text.ToString().Substring(1, 1));
                }
                else
                {
                    hours = int.Parse(row.Cells[1].Text.ToString().Substring(0, 2));
                }

                DateTime orderDate = selectedDate.AddHours(hours);
                string qty = txtQty.Text;


                string response = TransactionController.AddOrder(user.Id, showId, orderDate, DateTime.Now, qty);
                if (response != null)
                {
                    lblError.Text = response;
                }
                else
                {
                    lblError.Text = "not working";
                }
            }
        }

        protected void calDate_SelectionChanged(object sender, EventArgs e)
        {
           FillGrid();
        }

        protected void btnOrder_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void gvSchedule_RowDataBound1(object sender, GridViewRowEventArgs e)
        {

        }
    }
}