using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Helper
{
    public static class SendEmail
    {
        public static void sendEmail( Email input)
        {
            var client=new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("abdullah.fayed43@gmail.com", "ctgqhxxshzhvtjos");
            client.Send("abdullah.fayed43@gmail.com", input.to, input.Supject, input.Body);
        }
    }
}
