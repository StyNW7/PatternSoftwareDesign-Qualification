using PSD_Qualification_Frontend.Controllers;
using PSD_Qualification_Frontend.Datasets;
using PSD_Qualification_Frontend.Models;
using PSD_Qualification_Frontend.Modules;
using PSD_Qualification_Frontend.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSD_Qualification_Frontend.Views
{
    public partial class HistoryPage : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            // Middleware

            if (Session["user"] == null && Request.Cookies["user_cookie"] == null)
            {
                // Redirect ke Home Page
                Response.Redirect("~/Views/LoginPage.aspx");
                return;
            }

            if (Session["user"] == null && Request.Cookies["user_cookie"] != null)
            {

                String cookie = Request.Cookies["user_cookie"].Value;

                Response<User> response = UserController.LoginUserByCookie(cookie);

                if (!response.Success)
                {
                    Response.Cookies["user_cookie"].Expires = DateTime.Now.AddDays(-1);
                    Response.Redirect("~/Views/LoginPage.aspx");
                    return;
                }

                Session["user"] = response.PayLoad;

            }



            User currentUser = Session["user"] as User;

            String currentUserRole = currentUser.Role;

            if (currentUserRole == "Admin")
            {

                Response<List<Transaction>> response =
                    TransactionController.GetTransactions();
                if (response.Success)
                {

                    TransactionReport transactionReport = new TransactionReport();

                    CrystalReportViewer1.ReportSource = transactionReport;

                    transactionReport.SetDataSource(GetDataSet(response.PayLoad));

                    //GVTransactions.DataSource = response.PayLoad;
                    //GVTransactions.DataBind();
                }

            }

            else if (currentUserRole == "User")
            {

                Response<List<Transaction>> response =
                    TransactionController.GetTransaction(currentUser.Id);
                if (response.Success)
                {
                    //GVTransactions.DataSource = response.PayLoad;
                    //GVTransactions.DataBind();

                    TransactionReport transactionReport = new TransactionReport();
                    CrystalReportViewer1.ReportSource = transactionReport;

                    transactionReport.SetDataSource(GetDataSet(response.PayLoad));
                }

            }

        }

        public TransactionDataset GetDataSet(List<Transaction> transactions)
        {

            TransactionDataset dataset = new TransactionDataset();
            var transactionTable = dataset.Transactions;
            var meowTable = dataset.Meows;

            decimal totalHarga = 0;

            foreach (Transaction t in transactions) {

                var transactionTableRow = transactionTable.NewRow();

                transactionTableRow["Id"] = t.Id;
                transactionTableRow["UserId"] = t.UserID;
                transactionTableRow["MeowId"] = t.MeowID;
                transactionTableRow["TransactionDate"] = t.TransactionDate;

                transactionTable.Rows.Add(transactionTableRow);

                var meowTableRow = meowTable.NewRow();

                Meow meow = t.Meow;
                meowTableRow["Id"] = meow.Id;
                meowTableRow["Name"] = meow.Name;
                meowTableRow["Skin"] = meow.Skin;
                meowTableRow["Age"] = meow.Age;
                meowTableRow["Price"] = meow.Price;

                meowTable.Rows.Add(meowTableRow);

                totalHarga += meow.Price;

            }

            //var totalHargaRow = dataset.Transactions.NewRow();
            //totalHargaRow["TransactionDate"] = "Total Harga";
            //totalHargaRow["Price"] = totalHarga; // Menampilkan total harga

            //dataset.Transactions.Rows.Add(totalHargaRow);

            TotalPriceLbl.Text = "Total Price: " + totalHarga.ToString();

            return dataset;

        }


    }
}