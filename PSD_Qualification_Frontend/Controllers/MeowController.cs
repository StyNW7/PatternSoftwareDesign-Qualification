using PSD_Qualification_Frontend.Models;
using PSD_Qualification_Frontend.Modules;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Xml.Linq;

namespace PSD_Qualification_Frontend.Controllers
{
    public class MeowController
    {

        public static Response<List<Meow>> GetMeows()
        {
            MeowWebService.MeowWebService meowWS  = new MeowWebService.MeowWebService(); 
            
            String jsonResponse = meowWS.GetMeows();

            return Json.Decode<Response<List<Meow>>>(jsonResponse);
        }

        public static Response<Meow> GetMeow(String id)
        {
            MeowWebService.MeowWebService meowWS = new MeowWebService.MeowWebService();

            String jsonResponse = meowWS.GetMeow(id);

            return Json.Decode<Response<Meow>>(jsonResponse);
        }

        public static Response<Meow> CreateMeow(String name, int price, String skin, int age)
        {

            //String error = "";
            //if (name.Equals("") || price.Equals("") || skin.Equals("") || age.Equals(""))
            //{
            //    error = "All fields must be fields";
            //}
            //else if (price <= 0)
            //{
            //    error = "Price must more than 0";
            //}
            //else if (age <= 0)
            //{
            //    error = "Age must more than 0";
            //}

            //if (error.Equals(""))
            //{
            //    return MeowHandler.CreateMeow(name, price, skin, age);
            //}

            //return new Response<Meow>
            //{
            //    Success = false,
            //    Message = error,
            //    PayLoad = null
            //};

            //return MeowHandler.CreateMeow(name, price, skin, age);

            MeowWebService.MeowWebService meowWS = new MeowWebService.MeowWebService();

            String jsonResponse = meowWS.CreateMeow(name, price, skin, age);

            return Json.Decode<Response<Meow>>(jsonResponse);

        }

        public static Response<Meow> UpdateMeow(String id, String name, int price, String skin, int age)
        {

            //String error = "";
            //if (name.Equals("") || price.Equals("") || skin.Equals("") || age.Equals(""))
            //{
            //    error = "All fields must be fields";
            //}
            //else if (price <= 0)
            //{
            //    error = "Price must more than 0";
            //}
            //else if (age <= 0)
            //{
            //    error = "Age must more than 0";
            //}

            //if (error.Equals(""))
            //{
            //    return MeowHandler.UpdateMeow(name, price, skin, age);
            //}

            //return new Response<Meow>
            //{
            //    Success = false,
            //    Message = error,
            //    PayLoad = null
            //};

            //return MeowHandler.UpdateMeow(id, name, price, skin, age);

            MeowWebService.MeowWebService meowWS = new MeowWebService.MeowWebService();

            String jsonResponse = meowWS.UpdateMeow(id, name, price, skin, age);

            return Json.Decode<Response<Meow>>(jsonResponse);

        }

        public static Response<Meow> DeleteMeow(String id)
        {
            //return MeowHandler.DeleteMeow(id);

            MeowWebService.MeowWebService meowWS = new MeowWebService.MeowWebService();
            String jsonResponse = meowWS.DeleteMeow(id);
            return Json.Decode<Response<Meow>>(jsonResponse);
        }
    }

}