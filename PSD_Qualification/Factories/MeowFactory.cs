using PSD_Qualification.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD_Qualification.Factories
{
    public class MeowFactory
    {

        public static Meow Create(String id, String name, int price, String skin, int age)
        {
            Meow meow = new Meow()
            {
                Id = id,
                Name = name,
                Price = price,
                Skin = skin,
                Age = age
            };

            return meow;
        }

    }
}