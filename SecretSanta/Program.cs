using System;
using System.Collections.Generic;

namespace SecretSanta
{
    class Program
    {

        static void Main(string[] args)
        {

            var participantManager = new ParticipantManager();
            //var fileManager = new FileManager();
            bool notQuit = true;

            while (notQuit)
            {
                Console.WriteLine("Enter What you would like to do: ");
                string userPref = Console.ReadLine();
                switch (userPref.ToLower().Replace(" ", "")) {

                    case "adduser":
                        participantManager.AddParticipant();
                        break;
                    case "quit":
                        notQuit = false;
                        break;
                    case "listuser":
                        participantManager.ListParticipants();
                        break;
                    //case "savelist":
                        //fileManager.Save(participantManager._participants);
                        //break;
                    case "generatepairs":
                        participantManager.GeneratePairs();
                        participantManager.ListPairs();
                        break;
                    case "addunallowedpair":
                        participantManager.AddUnallowedPair();
                        break;
                    case "help":
                        PrintHelp();
                        break;
         
                }
            }
        }

        private static void PrintHelp()
        {
            Console.WriteLine("These are the commands that you can use:");
            Console.WriteLine("add user\nadd unallowed pair\nlist user\ngenerate pairs\nhelp\nquit");

        }
    }
}
