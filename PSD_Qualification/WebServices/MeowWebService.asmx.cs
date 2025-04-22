using PSD_Qualification.Handlers;
using PSD_Qualification.Modules;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Xml.Linq;

namespace PSD_Qualification.WebServices
{
    /// <summary>
    /// Summary description for MeowWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MeowWebService : System.Web.Services.WebService
    {

        [WebMethod]

        public String GetMeows()
        {
            return Json.Encode(MeowHandler.GetMeows());
        }


        [WebMethod]

        public String GetMeow(String id)
        {
            return Json.Encode(MeowHandler.GetMeow(id));
        }


        [WebMethod]

        public String CreateMeow(String name, int price, String skin, int age)
        {
            return Json.Encode(MeowHandler.CreateMeow(name, price, skin, age));
        }


        [WebMethod]

        public String UpdateMeow(String id, String name, int price, String skin, int age)
        {
            return Json.Encode(MeowHandler.UpdateMeow(id, name, price, skin, age));
        }


        [WebMethod]

        public String DeleteMeow(String id)
        {
            return Json.Encode(MeowHandler.DeleteMeow(id));
        }

    }
}
