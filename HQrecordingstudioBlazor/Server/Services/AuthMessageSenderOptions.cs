using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HQrecordingstudioBlazor.Server.Services
{
    //This class is to fetch the secure email key
    public class AuthMessageSenderOptions
    {
        public string SendGridUser { get; set; }
        public string SendGridKey { get; set; }
    }
}
