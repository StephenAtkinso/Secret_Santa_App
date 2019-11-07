using System;
using System.Collections.Generic;
using System.Linq;

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

        //Ensure no duplicate name or email addresses
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
                string unallowedPairList = String.Empty;
                participant.UnallowedPairs.ForEach(x => unallowedPairList = unallowedPairList + $", {x}");
                Console.WriteLine($"Name: {participant.Name}, Email: " +
                    $"{participant.EmailAddress} NoNo List: {unallowedPairList}");

            }
        }

        //ToDo
        //Seperate Lists for senders and recievers and take out when used
        //Make a method to generate the random number
        public void GeneratePairs()
        {

            int senderAttempts = 0;
            _usedRecievers = new List<int>();
            _giveRecievePairs = new Dictionary<int, int>();

            var rnd = new Random();
            for (int sendingUser = 0; sendingUser < _participants.Count; sendingUser++)
            {
                var recievingUser = rnd.Next(0, _participants.Count);
                bool invalidPair = true;
                var senderUnallowed = _participants[sendingUser].UnallowedPairs;
                senderAttempts = 0;

                do
                {
                    var recieverEmail = _participants[recievingUser].EmailAddress;

                    if (sendingUser == recievingUser)
                    {
                        recievingUser = rnd.Next(0, (_participants.Count));
                        senderAttempts++;
                    }
                    else if (_usedRecievers.Contains(recievingUser))
                    {
                        recievingUser = rnd.Next(0, (_participants.Count));
                        senderAttempts++;
                    }
                    else if (senderUnallowed.Contains(recieverEmail))
                    {
                        recievingUser = rnd.Next(0, (_participants.Count));
                        senderAttempts++;
                    }
                    else
                    {
                        invalidPair = false;
                    }

                }
                while (invalidPair && senderAttempts < 15);

                if(senderAttempts == 15)
                {
                    break;
                }

                _usedRecievers.Add(recievingUser);
                _giveRecievePairs.Add(sendingUser, recievingUser);

            }

            if(senderAttempts == 15)
            {
                GeneratePairs();
            }

        }

        public void ListPairs()
        {
            foreach (var pair in _giveRecievePairs)
            {
                Console.WriteLine($"Pair: {pair.Key} , {pair.Value}");

            }
        }

        public void AddUnallowedPair()
        {
            try
            {
                Console.WriteLine("Enter First Participants Email: ");
                string emailOne = Console.ReadLine();
                Participant participantOne = _participants.Single(x => x.EmailAddress == emailOne);

                Console.WriteLine("Enter Second Participants Email: ");
                string emailTwo = Console.ReadLine();
                Participant participantTwo = _participants.Single(x => x.EmailAddress == emailTwo);

                participantOne.AddToUnallowedPairs(emailTwo);
                participantTwo.AddToUnallowedPairs(emailOne);

                _participants[_participants.FindIndex(x => x.EmailAddress == emailOne)] = participantOne;
                _participants[_participants.FindIndex(x => x.EmailAddress == emailTwo)] = participantTwo;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Invalid Email Has Been Entered, Exception: {ex.ToString()}");
            }

        }



    }
}
