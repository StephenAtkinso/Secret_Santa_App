using System;
using System.Collections.Generic;
using System.Configuration;

namespace SecretSanta
{
    class Program
    {
        static void Main(string[] args)
        {
            //Add app.config file with these properties
            string sendingEmailAddress = ConfigurationManager.AppSettings["sendingemailaddress"];
            string sendingEmailPassword = ConfigurationManager.AppSettings["sendingemailpassword"];

            var participantManager = new ParticipantManager();
			//var fileManager = new FileManager();
			var emailManager = new EmailManager(sendingEmailAddress, sendingEmailPassword);
            bool notQuit = true;

            while (notQuit)
            {
                Console.WriteLine("Enter what you would like to do: ");
                string userPref = Console.ReadLine();
                switch (userPref.ToLower().Replace(" ", "")) {

                    case "adduser":
                        participantManager.AddParticipant();
                        break;
                    case "quit":
                        notQuit = false;
                        break;
                    case "beep":
                        Console.Beep();
                        break;
                    case "listusers":
                        participantManager.ListParticipants();
                        break;
                    //case "savelist":
                        //fileManager.Save(participantManager._participants);
                        //break;
                    case "generatepairs":
                        participantManager.GeneratePairs();
                        break;
                    case "listpairs":
                        participantManager.ListPairs();
                        break;
                    case "addunallowedpair":
                        participantManager.AddUnallowedPair();
                        break;
					case "sendemails":
                        //Get these better
						emailManager.SendEmails(participantManager._participants, participantManager._giveRecievePairs);
						break;
                    case "help":
                        PrintHelp();
                        break;
                    default:
                        Console.ForegroundColor = System.ConsoleColor.Red;
                        Console.WriteLine("Command not recognised. Type help to see a list of commands");
                        Console.ResetColor();
                        break;
                }
            }
        }

        private static void PrintHelp()
        {
            Console.WriteLine("These are the commands that you can use:");
            Console.WriteLine("add user\nadd unallowed pair\nlist user\ngenerate pairs\nlistpairs\nsend emails\nhelp\nquit");

        }
    }
}
