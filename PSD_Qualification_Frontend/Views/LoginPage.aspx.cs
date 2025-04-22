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
    public partial class LoginPage : System.Web.UI.Page
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

        protected void BtnLogin_Click(object sender, EventArgs e)
        {

            String email = TxtEmail.Text;
            String password = TxtPassword.Text;
            Boolean rememberMe = CBRememberMe.Checked;

            //LocalDatabaseEntities db = new LocalDatabaseEntities();

            //User user = (from u in db.Users where u.Email == email select u).FirstOrDefault();

            //if (user == null)
            //{
            //    LblError.Text = "Email not found!";
            //    return;
            //}

            //if (user.Password != password)
            //{
            //    LblError.Text = "Invalid Credentials";
            //    return;
            //}

            Response<User> response = UserController.LoginUser(email, password);

            //if (response.Success)
            //{
            //    LblError.ForeColor = System.Drawing.Color.Green;
            //    LblError.Text = response.Message;
            //    return;
            //}

            if (!response.Success)
            {
                LblError.Text = response.Message;
                return;
            }

            if (rememberMe)
            {
                HttpCookie cookie = new HttpCookie("user_cookie");
                cookie.Value = response.PayLoad.Id;
                cookie.Expires = DateTime.Now.AddHours(1);
                Response.Cookies.Add(cookie);
            }

            LblError.ForeColor = System.Drawing.Color.Green;

            LblError.Text = response.Message;

            Session["user"] = response.PayLoad;

            Response.Redirect("~/Views/HomePage.aspx");

        }

        protected void LBRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/RegisterPage.aspx");
        }

    }
}