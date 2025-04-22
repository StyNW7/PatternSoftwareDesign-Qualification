using PSD_Qualification.Factories;
using PSD_Qualification.Models;
using PSD_Qualification.Modules;
using PSD_Qualification.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace PSD_Qualification.Handlers
{
    public class MeowHandler
    {

        public static Response<List<Meow>> GetMeows()
        {

            List<Meow> meows = MeowRepository.GetMeows();
            return new Response<List<Meow>>()
            {
                Success = true,
                Message = "Success Get Meows",
                PayLoad = meows,
            };

        }

        public static Response<Meow> GetMeow(String id)
        {
            Meow meow = MeowRepository.GetMeow(id);

            if (meow == null)
            {
                return new Response<Meow>()
                {
                    Success = false,
                    Message = "Meow Not Found :(",
                    PayLoad = null,
                };
            }

            return new Response<Meow>()
            {
                Success = true,
                Message = "Meow Found :)",
                PayLoad = meow,
            };

        }


        public static String GenerateID()
        {

            Meow meow = MeowRepository.GetLastMeow();
            if (meow == null)
            {
                return "NW001";
            }
            String lastMeowId = meow.Id;
            int lastIDNumber = Convert.ToInt32(lastMeowId.Substring(2));
            lastIDNumber++;
            String newID = String.Format("NW{0:000}", lastIDNumber);
            return newID;

        }


        public static Response<Meow> CreateMeow(String name, int price, String skin, int age)
        {

            Meow meow = MeowFactory.Create(GenerateID(), name, price, skin, age);

            MeowRepository.CreateMeow(meow);

            return new Response<Meow>()
            {
                Success = true,
                Message = "Success Added NewmeoW",
                PayLoad = meow,
            };

        }


        public static Response<Meow> UpdateMeow(String id, String name, int price, String skin, int age)
        {

            Meow meow = MeowFactory.Create(id, name, price, skin, age);

            Meow updatedMeow = MeowRepository.UpdateMeow(meow);

            if (updatedMeow == null)
            {
                return new Response<Meow>()
                {
                    Success = false,
                    Message = "Meow Not Found :(",
                    PayLoad = null,
                };
            }

            return new Response<Meow>()
            {
                Success = true,
                Message = "Meow Updated :)",
                PayLoad = updatedMeow,
            };

        }

        public static Response<Meow> DeleteMeow(String id)
        {

            Boolean isDeleted = MeowRepository.DeleteMeow(id);

            if (isDeleted == false)
            {
                return new Response<Meow>()
                {
                    Success = false,
                    Message = "Meow Not Found :(",
                    PayLoad = null,
                };
            }

            return new Response<Meow>()
            {
                Success = true,
                Message = "Meow Deleted :(",
                PayLoad = null,
            };

        }

    }

}