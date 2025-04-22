using PSD_Qualification.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD_Qualification.Repositories
{
    public class MeowRepository
    {

        public static List<Meow> GetMeows()
        {
            LocalDatabaseEntities db = DatabaseSingleton.GetInstance();
            List<Meow> meows = db.Meows.ToList();
            return meows;
        }

        public static Meow GetMeow(String id)
        {
            LocalDatabaseEntities db = DatabaseSingleton.GetInstance();
            Meow meow = db.Meows.Find(id);
            return meow;
        }

        public static Meow GetLastMeow()
        {
            LocalDatabaseEntities db = DatabaseSingleton.GetInstance();
            Meow meow = db.Meows.ToList().LastOrDefault();
            return meow;
        }

        public static void CreateMeow(Meow meow)
        {
            LocalDatabaseEntities db = DatabaseSingleton.GetInstance();

            db.Meows.Add(meow);
            db.SaveChanges();
        }

        public static Meow UpdateMeow(Meow meow)
        {

            LocalDatabaseEntities db = DatabaseSingleton.GetInstance();

            Meow updateMeow = db.Meows.Find(meow.Id);

            if (updateMeow == null)
            {
                return updateMeow;
            }

            updateMeow.Name = meow.Name;
            updateMeow.Price = meow.Price;
            updateMeow.Skin = meow.Skin;
            updateMeow.Age = meow.Age;

            db.SaveChanges();

            return updateMeow;

        }

        public static Boolean DeleteMeow(String id)
        {

            LocalDatabaseEntities db = DatabaseSingleton.GetInstance();

            Meow meow = db.Meows.Find(id);

            if (meow == null)
            {
                return false;
            }

            db.Meows.Remove(meow);
            db.SaveChanges();

            return true;

        }

    }

}