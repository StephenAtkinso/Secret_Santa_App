using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace SecretSanta
{
    public class EmailManager
    {
        private string _sendingEmailAddress;
        private string _sendingEmailPassword;

        public EmailManager(string sendingEmailAddress, string sendingEmailPassword)
        {
            _sendingEmailAddress = sendingEmailAddress;
            _sendingEmailPassword = sendingEmailPassword;
        }

        public void SendEmails(List<Participant> participants, Dictionary<int, int> giveRecievePairs)
        {
            try
            {
                SmtpClient mySmtpClient = new SmtpClient("smtp.gmail.com");

                // set smtp-client with basicAuthentication
                mySmtpClient.UseDefaultCredentials = false;
                mySmtpClient.Port = 587;
                mySmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                NetworkCredential emailCredentials = new NetworkCredential(_sendingEmailAddress, _sendingEmailPassword);
                mySmtpClient.EnableSsl = true;
                mySmtpClient.Credentials = emailCredentials;

                MailAddress from = new MailAddress(emailCredentials.UserName);

                foreach (var pair in giveRecievePairs) 
                {
                    Participant sender = participants[pair.Key];
                    Participant reciever = participants[pair.Value];

                    MailAddress to = new MailAddress(sender.EmailAddress);
                    MailMessage myMail = new System.Net.Mail.MailMessage(from, to);

                    // set subject and encoding
                    var theDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
                    myMail.Subject = $"Secret Santa Test Run {theDate}";
                    myMail.SubjectEncoding = System.Text.Encoding.UTF8;

                    // set body-message and encoding
                    myMail.Body = $"You are giving a gift to {reciever.Name}!<br><br>Merry Christmas!.";
                    myMail.BodyEncoding = System.Text.Encoding.UTF8;
                    
                    // text or html
                    myMail.IsBodyHtml = true;

                    mySmtpClient.Send(myMail);
                }
                
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Couldn't send email. Exception: {ex.ToString()}" );
            }
        }
    }
}
