using ProjekLab.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjekLab.Dataset;
using ProjekLab.Report;
using ProjekLab.Controllers;

namespace ProjekLab.Views
{
    public partial class TransactionReportPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["curr_User"] != null)
            {
                User user = (User)Session["curr_User"];
                if (user.RoleId == 1)
                {
                    TransactionReport report = new TransactionReport();
                    rptViewer.ReportSource = report;
                    DataSet1 data = getData(ShowController.GetAllSellerShows(user.Id));
                    report.SetDataSource(data);
                }
                else
                {
                    Response.Redirect("HomePage.aspx"); ;
                }
            }
            else
            {
                Response.Redirect("HomePage.aspx");
            }
            

            
        }

        private DataSet1 getData(List<Show> showTrans)
        {
            labelError.Text = showTrans.Count.ToString();
            DataSet1 data = new DataSet1();
            var showTable = data.Shows;
            var headerTable = data.TransactionHeaders;
            var detailTable = data.TransactionDetails;

            foreach (Show show in showTrans)
            {
                var showRow = showTable.NewRow();
                showRow["Id"] = show.Id;
                showRow["Name"] = show.Name;
                showRow["Url"] = show.Url;
                showRow["Price"] = show.Price;
                showRow["Description"] = show.Description;
                showTable.Rows.Add(showRow);

                foreach (TransactionHeader th in show.TransactionHeaders)
                {
                    var headerRow = headerTable.NewRow();
                    headerRow["Id"] = th.Id;
                    headerRow["BuyerId"] = th.BuyerId;
                    headerRow["ShowId"] = th.ShowId;
                    headerRow["CreatedAt"] = th.CreatedAt;
                    headerRow["ShowTime"] = th.ShowTime;
                    headerRow["Quantity"] = th.Quantity;

                    headerTable.Rows.Add(headerRow);

                    foreach (TransactionDetail td in th.TransactionDetails)
                    {
                        var detailRow = detailTable.NewRow();
                        detailRow["Id"] = td.Id;
                        detailRow["TransactionHeaderId"] = td.TransactionHeaderId;
                        detailRow["StatusId"] = td.StatusId;
                        detailRow["Token"] = td.Token;

                        detailTable.Rows.Add(detailRow);
                    }
                }
            }
        return data;
        }

        protected void rptViewer_Init(object sender, EventArgs e)
        {

        }
    }
}