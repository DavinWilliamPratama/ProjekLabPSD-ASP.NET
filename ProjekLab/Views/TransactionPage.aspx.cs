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
    public partial class TransactionPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
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
                    FillGrid();
                    }
                }
        }
        protected void FillGrid()
        {
            User user = (User)Session["curr_User"];
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[] {
                        new DataColumn("CreatedAt", typeof(DateTime)) ,
                        new DataColumn("Title", typeof(string)),
                        new DataColumn("ShowTime", typeof(DateTime)),
                        new DataColumn("Quantity", typeof(int)),
                        new DataColumn("TotalPrice", typeof(int))});

            List<TransactionHeader> tdList = TransactionController.GetAllOrder(user.Id);

            for (int i = 0; i < TransactionController.GetAllOrder(user.Id).Count; i++)
            {
                int total = tdList[i].Quantity * tdList[i].Show.Price;
                dt.Rows.Add(tdList[i].CreatedAt, tdList[i].Show.Name, tdList[i].ShowTime, tdList[i].Quantity, total);
                total = 0;
            }
            gvShowOrder.DataSource = dt;
            gvShowOrder.DataBind();
        }

        protected void gvShowOrder_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "btnSelect")
            {
                User user = (User)Session["curr_User"];
                int currentRow = Convert.ToInt32(e.CommandArgument.ToString());
                string title = gvShowOrder.Rows[currentRow].Cells[1].Text;
                DateTime showTime = DateTime.Parse(gvShowOrder.Rows[currentRow].Cells[2].Text);
                int qty = int.Parse(gvShowOrder.Rows[currentRow].Cells[3].Text);
                DateTime createdAt = DateTime.Parse(gvShowOrder.Rows[currentRow].Cells[0].Text);

                int id = TransactionController.FindTransactionHeaderId(user.Id, title, createdAt, showTime, qty);

                Response.Redirect("TransactionDetailPage.aspx?id=" + id);
            }
        }
    }
}