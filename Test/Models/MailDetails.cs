using System.Collections.Generic;

namespace Test.Models
{
    public class MailDetails
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<string> Recipients { get; set; }
    }
}
