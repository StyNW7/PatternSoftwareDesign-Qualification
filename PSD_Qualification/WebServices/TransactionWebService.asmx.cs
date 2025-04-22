using PSD_Qualification.Handlers;
using PSD_Qualification.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace PSD_Qualification.WebServices
{
    /// <summary>
    /// Summary description for TransactionWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class TransactionWebService : System.Web.Services.WebService
    {

        [WebMethod]

        public String GetTransactions()
        {
            return Json.Encode(TransactionHandler.GetTransactions());
        }

        [WebMethod]

        public String GetUserTransactions(String userId)
        {
            return Json.Encode(TransactionHandler.GetUserTransactions(userId));
        }

        [WebMethod]

        public String CreateTransaction(String userId, String meowId)
        {
            return Json.Encode(TransactionHandler.CreateTransaction(userId, meowId));
        }

    }
}
