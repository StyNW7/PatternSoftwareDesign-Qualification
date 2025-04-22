using PSD_Qualification.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD_Qualification.Repositories
{
    public class DatabaseSingleton
    {

        public static LocalDatabaseEntities instance;

        public static LocalDatabaseEntities GetInstance()
        {
            if (instance == null)
            {
                instance = new LocalDatabaseEntities();
            }
            return instance;
        }

    }

}