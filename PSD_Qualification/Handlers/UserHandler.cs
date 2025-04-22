using PSD_Qualification.Factories;
using PSD_Qualification.Models;
using PSD_Qualification.Modules;
using PSD_Qualification.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD_Qualification.Handlers
{
    public class UserHandler
    {
        public static Response<User> LoginUser(String email, String password)
        {
            User user = UserRepository.GetUserByEmail(email);

            if (user == null)
            {
                return new Response<User>
                {
                    Success = false,
                    Message = "User not found!",
                    PayLoad = null
                };
            }

            if (user.Password != password)
            {
                return new Response<User>
                {
                    Success = false,
                    Message = "Invalid credentials!",
                    PayLoad = null
                };

            }

            return new Response<User>
            {
                Success = true,
                Message = "Login Success",
                PayLoad = user
            };

        }

        private static String GenerateID()
        {
            User user = UserRepository.GetLastUser();
            if (user == null)
            {
                return "US001";
            }
            String lastUserID = user.Id;
            int lastIDNumber = Convert.ToInt32(lastUserID.Substring(2));
            lastIDNumber++;
            String newID = String.Format("US{0:000}", lastIDNumber);
            return newID;
        }

        public static Response <User> RegisterUser(String email, String name,
            String password)
        {

            String role = "User";

            if (name.Contains("admin"))
            {
                role = "Admin";
            }

            User user = UserFactory.Create(GenerateID(), email, name, password, role);

            UserRepository.CreateUser(user);

            return new Response<User>
            {
                Success = true,
                Message = "Register Success!",
                PayLoad = user
            };

        }

        public static Response<User> LoginUserByCookie(String cookie)
        {

            // Logic Decrypt Cookie

            String userID = cookie;

            User user = UserRepository.GetUserById(userID);

            if (user == null)
            {
                return new Response<User>
                {
                    Success = false,
                    Message = "User not found!",
                    PayLoad = null
                };
            }

            else
            {
                return new Response<User>
                {
                    Success = true,
                    Message = "User login by Cookie!",
                    PayLoad = user
                };
            }

        }


    }

}