using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digify.Registration.Application
{
    public static class Messages
    {
        public const string DATA_CREATED = "Data Created";
        public const string DATA_UPDATED = "Data Updated";
        public const string DATA_DELETED = "Data Deleted";
        public const string DATA_NOT_FOUND = "Data Not Found";

        public static string Translate(Exception ex)
        {
            return "Error Occured : " + ex.Message;
        }
    }
}
