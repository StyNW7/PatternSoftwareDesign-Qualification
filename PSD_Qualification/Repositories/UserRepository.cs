using PSD_Qualification.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD_Qualification.Repositories
{
    public class UserRepository
    {
        public static User GetUserByEmail(String email)
        {
            
            LocalDatabaseEntities db = DatabaseSingleton.GetInstance();

            User user = db.Users.Where(u => u.Email == email).FirstOrDefault();

            return user;

        }

        public static User GetLastUser()
        {
            LocalDatabaseEntities db = DatabaseSingleton.GetInstance();
            User user = db.Users.ToList().LastOrDefault();
            return user;
        }

        public static User GetUserById(String id)
        {
            LocalDatabaseEntities db = DatabaseSingleton.GetInstance();
            User user = db.Users.Find(id);
            return user;
        }

        public static void CreateUser(User user)
        {

            LocalDatabaseEntities db = DatabaseSingleton.GetInstance();

            db.Users.Add(user);

            db.SaveChanges();

        }

    }

}