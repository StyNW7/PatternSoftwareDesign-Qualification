using PSD_Qualification.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD_Qualification.Factories
{
    public class UserFactory
    {
        public static User Create(String id, String email, String name, String password, String role)
        {
            User user = new User()
            {
                Id = id,
                Name = name,
                Email = email,
                Password = password,
                Role = role
            };

            return user;
        }
    }

}