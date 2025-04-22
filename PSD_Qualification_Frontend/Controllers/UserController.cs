using PSD_Qualification_Frontend.Models;
using PSD_Qualification_Frontend.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace PSD_Qualification_Frontend.Controllers
{
    public class UserController
    {
        public static Response<User> LoginUser(String email, String password)
        {

            String error = "";
            if (email.Equals("") || password.Equals(""))
            {
                error = "All fields must be fields";
            }
            else if (!email.Contains("@"))
            {
                error = "Error must contains @";
            }

            if (error.Equals(""))
            {
                //return UserHandler.LoginUser(email, password);

                UserWebService.UserWebService userWS = new UserWebService.UserWebService();
                String jsonResponse = userWS.LoginUser(email, password);
                return Json.Decode<Response<User>>(jsonResponse);

            }

            return new Response<User>
            {
                Success = false,
                Message = error,
                PayLoad = null
            };

        }

        public static Response<User> RegisterUser(String email, String name,
            String password)
        {

            String error = "";

            if (email.Equals("") || password.Equals("") || name.Equals(""))
            {
                error = "All fields must be fields";
            }
            else if (!email.Contains("@"))
            {
                error = "Error email must contains @";
            }

            if (error.Equals(""))
            {
                //return UserHandler.RegisterUser(email, name, password);

                UserWebService.UserWebService userWS = new UserWebService.UserWebService();
                String jsonResponse = userWS.RegisterUser(email, name, password);
                return Json.Decode<Response<User>>(jsonResponse);

            }

            return new Response<User>
            {
                Success = false,
                Message = error,
                PayLoad = null
            };

        }

        public static Response<User> LoginUserByCookie(String cookie)
        {

            //return UserHandler.LoginUserByCookie(cookie);

            UserWebService.UserWebService userWS = new UserWebService.UserWebService();
            String jsonResponse = userWS.LoginUserByCookie(cookie);
            return Json.Decode<Response<User>>(jsonResponse);

        }

    }

}