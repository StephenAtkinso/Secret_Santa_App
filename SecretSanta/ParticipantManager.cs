using System;
using System.Collections.Generic;

namespace SecretSanta
{
    public class ParticipantManager
    {

        public List<Participant> _participants;
        public List<int> _usedRecievers;
        public Dictionary<int, int> _giveRecievePairs;

        public ParticipantManager()
        {
            _participants = new List<Participant>();
            _usedRecievers = new List<int>();
            _giveRecievePairs = new Dictionary<int, int>();
        }

        public void AddParticipant()
        {
            Console.WriteLine("Enter Participant Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Participant Email: ");
            string email = Console.ReadLine();

            Participant part1 = new Participant(name, email);
            _participants.Add(part1);
        }

        public void ListParticipants()
        {
            foreach(var participant in _participants)
            {
                Console.WriteLine($"Name: {participant.Name}, Email: " +
                    $"{participant.EmailAddress}");

            }
        }

        //Seperate Lists for senders and recievers and take out when used
        //Make a method to generate the random number
        public void GeneratePairs()
        {
            var rnd = new Random();
            for (int sendingUser = 0; sendingUser < _participants.Count; sendingUser++)
            {
                var recievingUser = rnd.Next(0, (_participants.Count));
                bool invalidPair = true;

                do
                {
                    Console.WriteLine($"We are at the start of the do: {recievingUser}");
                    if (sendingUser == recievingUser)
                    {
                        recievingUser = rnd.Next(0, (_participants.Count));
                    }
                    else if (_usedRecievers.Contains(recievingUser))
                    {
                        recievingUser = rnd.Next(0, (_participants.Count));
                    }
                    else
                    {
                        invalidPair = false;

                    }

                }
                while (invalidPair);

                _usedRecievers.Add(recievingUser);
                _giveRecievePairs.Add(sendingUser, recievingUser);

            }

        }

        public void ListPairs()
        {
            foreach (var pair in _giveRecievePairs)
            {
                Console.WriteLine($"Pair: {pair.Key} , {pair.Value}");

            }
        }

        
        
    }
}
