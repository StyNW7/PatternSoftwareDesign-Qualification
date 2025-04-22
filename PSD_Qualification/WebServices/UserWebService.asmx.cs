using PSD_Qualification.Handlers;
using PSD_Qualification.Models;
using PSD_Qualification.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace PSD_Qualification.WebServices
{
    /// <summary>
    /// Summary description for UserWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class UserWebService : System.Web.Services.WebService
    {

        [WebMethod]

        public String LoginUser(String email, String password)
        {
            return Json.Encode(UserHandler.LoginUser(email, password));
        }

        [WebMethod]
        public String RegisterUser(String email, String name,
            String password)
        {
            return Json.Encode(UserHandler.RegisterUser(email, name, password));
        }

        [WebMethod]
        public String LoginUserByCookie(String cookie)
        {
            return Json.Encode(UserHandler.LoginUserByCookie(cookie));
        }

    }

}
