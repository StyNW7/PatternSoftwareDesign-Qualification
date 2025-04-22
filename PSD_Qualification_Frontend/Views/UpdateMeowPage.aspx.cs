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
    public partial class UpdateMeowPage : System.Web.UI.Page
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

            if (currentUserRole != "Admin")
            {
                Response.Redirect("~/Views/HomePage.aspx");
                return;
            }

            if (!IsPostBack)
            {

                String id = Request["id"];

                Response<Meow> response = MeowController.GetMeow(id);

                if (response.Success)
                {
                    Meow meow = response.PayLoad;
                    TxtId.Text = meow.Id;
                    TxtName.Text = meow.Name;
                    TxtSkin.Text = meow.Skin;
                    TxtAge.Text = Convert.ToString(meow.Age);
                    TxtPrice.Text = Convert.ToString(meow.Price);
                }

                else
                {
                    Response.Redirect("~/Views/HomePage.aspx");
                    return;
                }

            }

        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {

            String id = TxtId.Text;
            String name = TxtName.Text;
            String skin = TxtSkin.Text;
            int age = Convert.ToInt32(TxtAge.Text);
            int price = Convert.ToInt32(TxtPrice.Text);

            Response<Meow> response = MeowController.UpdateMeow(id, name, price, skin, age);

            if (response.Success)
            {
                Response.Redirect("~/Views/HomePage.aspx");
                return;
            }

            else
            {
                // Kalau mau ada label error kayak di register / login page
            }

        }

    }
}