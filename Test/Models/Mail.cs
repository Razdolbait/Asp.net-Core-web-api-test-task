using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;
using Test.Models;

namespace Test.Models
{
    [Table("Mails")]
    public partial class Mail
    {
        [JsonIgnore]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
        [JsonIgnore]
        public string MailDetails { get; set; }
        public DateTime Date { get; set; }
        public bool Result { get; set; }
        public string FailedMessage { get; set; } = "";
        [NotMapped]
        public MailDetails Details
        {
            get
            {
                return JsonConvert.DeserializeObject<MailDetails>(MailDetails);
            }

            set
            {
                MailDetails = JsonConvert.SerializeObject(value);
            }
        }
        public Mail(MailDetails mailDetails)
        {
            Details = mailDetails;
            Date = DateTime.Now;
            try
            {
                MailSettings mailSettings = new MailSettings();
                MailMessage objeto_mail = new MailMessage();
                SmtpClient client = new SmtpClient
                {
                    //Port = mailSettings.Port,
                    //Host = mailSettings.Host,
                    //Timeout = mailSettings.Timeout,
                    //UseDefaultCredentials = mailSettings.UseDefaultCredentials,
                    //Credentials = mailSettings.Credentials
                    Port = 587,
                    Host = "smtp.gmail.com",
                    Timeout = 10000,
                    UseDefaultCredentials = false,
                    Credentials = new System.Net.NetworkCredential("spamer@gmail.com", "password")
                };
                objeto_mail.From = new MailAddress("spamer@gmail.com");
                foreach (var to in Details.Recipients)
                {
                    objeto_mail.To.Add(to);
                }
                objeto_mail.Subject = Details.Subject;
                objeto_mail.Body = Details.Body;
                client.Send(objeto_mail);
                Result = true;
            }
            catch (Exception ex)
            {
                Result = false;
                //FailedMessage = ex.Message;
            }
            //Постоянные ошибки отправки не интересно. Далее для разнообразия:-)
            Result = Results();
            if (Result == false)
            {
                FailedMessage = "Письмо не отправлено: на почте обед!";
            }
        }
        public Mail()
        {
        }

        private bool Results()
        {
            Random rnd = new Random();
            int value = rnd.Next(1, 4);
            return value == 3 ? false : true;
        }
    }
}
