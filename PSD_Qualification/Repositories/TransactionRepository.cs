using PSD_Qualification.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace PSD_Qualification.Repositories
{
    public class TransactionRepository
    {

        public static List<Transaction> GetTransactions()
        {
            LocalDatabaseEntities db = DatabaseSingleton.GetInstance();
            List<Transaction> transactions = db.Transactions.ToList();
            return transactions;
        }
        public static List<Transaction> GetTransaction(String userId)
        {
            LocalDatabaseEntities db = DatabaseSingleton.GetInstance();
            List<Transaction> userTransactions = db.Transactions.Where(
                t => t.UserID == userId).ToList();
            return userTransactions;
        }

        public static Transaction GetLastTransaction()
        {
            LocalDatabaseEntities db = DatabaseSingleton.GetInstance();
            Transaction lastTransaction = db.Transactions.ToList().LastOrDefault();

            return lastTransaction;
        }

        public static void CreateTransaction(Transaction transaction)
        {
            LocalDatabaseEntities db = DatabaseSingleton.GetInstance();
            db.Transactions.Add(transaction);
            db.SaveChanges();
        }

    }
}