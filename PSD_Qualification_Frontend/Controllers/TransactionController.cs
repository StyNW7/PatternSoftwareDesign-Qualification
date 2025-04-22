using PSD_Qualification_Frontend.Models;
using PSD_Qualification_Frontend.Modules;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Xml.Linq;

namespace PSD_Qualification_Frontend.Controllers
{
    public class TransactionController
    {

        public static Response<List<Transaction>> GetTransactions()
        {

            //return TransactionHandler.GetTransactions();

            TransactionWebService.TransactionWebService transactionWS = new TransactionWebService.TransactionWebService();
            String jsonResponse = transactionWS.GetTransactions();
            return Json.Decode<Response<List<Transaction>>>(jsonResponse);

        }

        public static Response<List<Transaction>> GetTransaction(String userId)
        {

            //return TransactionHandler.GetUserTransactions(userId);

            TransactionWebService.TransactionWebService transactionWS = new TransactionWebService.TransactionWebService();
            String jsonResponse = transactionWS.GetUserTransactions(userId);
            return Json.Decode<Response<List<Transaction>>>(jsonResponse);

        }

        public static Response<Transaction> CreateTransaction(String userId, String bookId)
        {

            //return TransactionHandler.CreateTransaction(userId, bookId);

            TransactionWebService.TransactionWebService transactionWS = new TransactionWebService.TransactionWebService();
            String jsonResponse = transactionWS.CreateTransaction(userId, bookId);
            return Json.Decode<Response<Transaction>>(jsonResponse);

        }

    }

}