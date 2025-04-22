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
    public partial class RegisterPage : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            // Middleware

            if (Session["user"] != null || Request.Cookies["user_cookie"] != null)
            {
                // Redirect ke Home Page
                Response.Redirect("~/Views/HomePage.aspx");
                return;
            }

            LblError.ForeColor = System.Drawing.Color.Red;

        }

        protected void BtnRegister_Click(object sender, EventArgs e)
        {

            String email = TxtEmail.Text;
            String name = TxtName.Text;
            String password = TxtPassword.Text;

            Response<User> response = UserController.RegisterUser(email, name, password);

            if (response.Success)
            {
                Response.Redirect("~/Views/LoginPage.aspx");
            }

            LblError.Text = response.Message;

        }

        protected void LBLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/LoginPage.aspx");
        }

    }
}