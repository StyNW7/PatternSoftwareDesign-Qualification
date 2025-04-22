using PSD_Qualification.Factories;
using PSD_Qualification.Models;
using PSD_Qualification.Modules;
using PSD_Qualification.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Util;

namespace PSD_Qualification.Handlers
{
    public class TransactionHandler
    {

        public static Response<List<Transaction>> GetTransactions()
        {
            List <Transaction> transactions = TransactionRepository.GetTransactions();
            return new Response<List<Transaction>>()
            {
                Success = true,
                Message = "Success get all transactions",
                PayLoad = transactions,
            };
        }

        public static Response<List<Transaction>> GetUserTransactions(String userId)
        {
            List<Transaction> transactions = TransactionRepository.GetTransaction(userId);
            return new Response<List<Transaction>>()
            {
                Success = true,
                Message = "Success get user transactions",
                PayLoad = transactions,
            };
        }

        public static String GenerateID()
        {

            Transaction transaction = TransactionRepository.GetLastTransaction();
            if (transaction == null)
            {
                return "TR001";
            }
            String lastTransactionId = transaction.Id;
            int lastIDNumber = Convert.ToInt32(lastTransactionId.Substring(2));
            lastIDNumber++;
            String newID = String.Format("TR{0:000}", lastIDNumber);
            return newID;

        }

        public static Response <Transaction> CreateTransaction(String userId, String meowId)
        {

            Transaction transaction = TransactionFactory.Create(GenerateID(), userId, meowId);

            TransactionRepository.CreateTransaction(transaction);

            return new Response<Transaction>()
            {
                Success = true,
                Message = "Success create transaction",
                PayLoad = transaction,
            };

        }


    }
}