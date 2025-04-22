using PSD_Qualification.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD_Qualification.Factories
{
    public class TransactionFactory
    {

        public static Transaction Create(String id, String userId, String meowId)
        {

            Transaction transaction = new Transaction()
            {
                Id = id,
                UserID = userId,
                MeowID = meowId,
                TransactionDate = DateTime.Now,
            };

            return transaction;

        }

    }

}