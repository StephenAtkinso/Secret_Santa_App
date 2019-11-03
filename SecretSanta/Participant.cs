using System;
using System.Collections.Generic;

namespace SecretSanta
{
    public class Participant
    {

        public string Name;
        public string EmailAddress;
        public List<string> UnallowedPairs { get; private set; }

        public Participant(string name, string emailAddress)
        {
            Name = name;
            EmailAddress = emailAddress;
            UnallowedPairs = new List<string>();

        }

        public void AddToUnallowedPairs(string unallowedEmail)
        {
            UnallowedPairs.Add(unallowedEmail);
        }

        //public List<string> GetUnallowedPairs()
        //{
        //    return UnallowedPairs;
        //} 
    }
}
