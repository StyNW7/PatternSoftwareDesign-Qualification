using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD_Qualification_Frontend.Modules
{
    public class Response<T>
    {
        public Boolean Success { get; set; }
        public String Message { get; set; }
        public T PayLoad { get; set; }
    }

}