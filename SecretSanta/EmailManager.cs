using System;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace SecretSanta
{
    public class EmailManager
    {
        public EmailManager()
        {

        }

        public void sendEmails()
        {
            try
            {
                SmtpClient mySmtpClient = new SmtpClient("smtp.gmail.com");

                // set smtp-client with basicAuthentication
                mySmtpClient.UseDefaultCredentials = false;
                mySmtpClient.Port = 587;
                mySmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                NetworkCredential emailCredentials = new NetworkCredential("anemail", "apassword");
                mySmtpClient.EnableSsl = true;
                mySmtpClient.Credentials = emailCredentials;

                // add from,to mailaddresses
                MailAddress from = new MailAddress(emailCredentials.UserName);
                MailAddress to = new MailAddress("sendtoemail");
                MailMessage myMail = new System.Net.Mail.MailMessage(from, to);

                //// add ReplyTo
                //MailAddress replyTo = new MailAddress("reply@example.com");
                //myMail.ReplyToList.Add(replyTo);

                // set subject and encoding
                myMail.Subject = "Hello I am an app";
                myMail.SubjectEncoding = System.Text.Encoding.UTF8;

                // set body-message and encoding
                myMail.Body = "<b>Test Mail</b><br>Denver is fat, Storm is cute - You just got santa emailed by the bois.";
                myMail.BodyEncoding = System.Text.Encoding.UTF8;
                // text or html
                myMail.IsBodyHtml = true;

                mySmtpClient.Send(myMail);
                
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Couldn't send email. Exception: {ex.ToString()}" );
            }
        }
    }
}
