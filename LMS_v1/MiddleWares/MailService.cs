using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
namespace LMS_v1.MiddleWares
{
    public class MailService
    {
        public void sendMail(string subject, string body,string toemail)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(toemail);
                mail.Subject = subject;
                mail.Body = body;
                mail.From = new MailAddress("librarykonoha@gmail.com", "Konoha Digital Library");
                mail.IsBodyHtml = true;
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.EnableSsl = true;
                smtpClient.Send(mail);
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}