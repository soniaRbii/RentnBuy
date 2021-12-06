
using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace RentnBuy.Utility
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("projet.net.stm@gmail.com");
            mailMessage.To.Add(new MailAddress(email));

            mailMessage.Subject = subject;
            mailMessage.IsBodyHtml = true;

            mailMessage.Body = "<h2> Dear Customer You registered an account on Rent&Buy Website, before being able to use" +
            " your account you need to verify that this is your email address by clicking here </h2><br>" +
            "https://localhost:5001/Customer/Home" +
            "<br><h2>Kind Regards, Rent&Buy</h2>";

            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("projet.net.stm@gmail.com", "X**123456");
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.Host = "smtp.gmail.com";
            client.Port = 587;

            try
            {
                client.Send(mailMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}