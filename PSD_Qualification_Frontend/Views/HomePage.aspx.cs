using PSD_Qualification_Frontend.Controllers;
using PSD_Qualification_Frontend.Models;
using PSD_Qualification_Frontend.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSD_Qualification_Frontend.Views
{
    public partial class HomePage : System.Web.UI.Page
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

            if (currentUserRole.Equals("Admin"))
            {
                GVMeow.Columns[5].Visible = true;
                PanelInsert.Visible = true;
            }

            if (currentUserRole.Equals("User"))
            {
                GVMeow.Columns[6].Visible = true;
            }

            RefreshGridView();

        }


        public void RefreshGridView()
        {

            Response<List<Meow>> response = MeowController.GetMeows();

            if (response.Success)
            {
                GVMeow.DataSource = response.PayLoad;
                GVMeow.DataBind();
            }

        }

        protected void GVMeow_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            GridViewRow row = GVMeow.Rows[e.RowIndex];
            String id = row.Cells[0].Text;

            Response<Meow> response = MeowController.DeleteMeow(id);

            if (response.Success)
            {
                RefreshGridView();
            }

        }

        protected void GVMeow_RowEditing(object sender, GridViewEditEventArgs e)
        {

            GridViewRow row = GVMeow.Rows[e.NewEditIndex];
            String id = row.Cells[0].Text;

            Response.Redirect("~/Views/UpdateMeowPage.aspx?Id=" + id);

        }

        protected void GVMeow_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Buy")
            {

                Control sourceControl = e.CommandSource as Control;
                GridViewRow row = sourceControl.NamingContainer as GridViewRow;

                int rowIndex = row.RowIndex;
                String bookId = GVMeow.Rows[rowIndex].Cells[0].Text;

                User currentUser = Session["user"] as User;
                String userId = currentUser.Id;

                Response<Transaction> response = TransactionController.CreateTransaction(userId, bookId);

                if (response.Success)
                {
                    // Something
                }

            }

        }

        protected void BtnInsert_Click(object sender, EventArgs e)
        {

            String name = TxtName.Text;
            String skin = TxtSkin.Text;
            int age = Convert.ToInt32(TxtAge.Text);
            int price = Convert.ToInt32(TxtPrice.Text);

            Response<Meow> response = MeowController.CreateMeow(name, price, skin, age);

            if (response.Success)
            {

                // Clear Textbox

                TxtName.Text = "";
                TxtSkin.Text = "";
                TxtAge.Text = "";
                TxtPrice.Text = "";

                RefreshGridView();
                return;
            }

            else
            {
                // Label error
            }

        }

    }
}