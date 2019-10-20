using System;
using System.Collections.Generic;

namespace SecretSanta
{
    class Program
    {

        static void Main(string[] args)
        {

            var participantManager = new ParticipantManager();
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
                    case "savelist":
                        break;
                    case "generatepairs":
                        participantManager.GeneratePairs();
                        participantManager.ListPairs();
                        break;
         
                }
            }
        }
    }
}
