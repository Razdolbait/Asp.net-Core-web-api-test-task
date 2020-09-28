using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Test.Models
{
    public class MailSettings : MailMessage
    {
        public int Port { get; set; }
        public string Host { get; set; }
        public int Timeout { get; set; }
        public bool UseDefaultCredentials { get; set; }
        public System.Net.NetworkCredential Credentials { get; set; }
    }
}
