using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazorcrud.Data
{
    public static class Extensions
    {
        public static string ToJson(this object value)
        {
            if (value == null) return null;

            try
            {
                string json = JsonConvert.SerializeObject(value);
                return json;
            }
            catch (Exception exception)
            {
                //log exception but dont throw one
                return "";
            }
        }
    }
}
