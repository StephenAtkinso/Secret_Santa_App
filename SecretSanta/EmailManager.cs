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

                SmtpClient mySmtpClient = new SmtpClient();

                // set smtp-client with basicAuthentication
                mySmtpClient.UseDefaultCredentials = false;
                System.Net.NetworkCredential basicAuthenticationInfo = new
                System.Net.NetworkCredential("username", "password");
                mySmtpClient.Credentials = basicAuthenticationInfo;

                // add from,to mailaddresses
                MailAddress from = new MailAddress("test@example.com", "TestFromName");
                MailAddress to = new MailAddress("doscube@gmail.com", "TestToName");
                MailMessage myMail = new System.Net.Mail.MailMessage(from, to);

                //// add ReplyTo
                //MailAddress replyTo = new MailAddress("reply@example.com");
                //myMail.ReplyToList.Add(replyTo);

                // set subject and encoding
                myMail.Subject = "Test message";
                myMail.SubjectEncoding = System.Text.Encoding.UTF8;

                // set body-message and encoding
                myMail.Body = "<b>Test Mail</b><br>Fart Gas Denver is fat <b>HTML</b>.";
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
