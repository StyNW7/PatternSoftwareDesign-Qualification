using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSD_Qualification_Frontend.Layouts
{
    public partial class Header : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/HomePage.aspx");
        }

        protected void BtnHistory_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/Views/HistoryPage.aspx");

        }

        protected void BtnLogout_Click(object sender, EventArgs e)
        {

            HttpCookie cookie = Request.Cookies["user_cookie"];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
            }
            Session.Remove("user");
            Response.Redirect("~/Views/LoginPage.aspx");

        }

    }
}