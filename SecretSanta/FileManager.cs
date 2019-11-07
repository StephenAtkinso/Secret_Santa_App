using System;
using System.Collections.Generic;
using System.IO;

namespace SecretSanta
{
    public class FileManager
    {
        public FileManager()
        {
        }

        public void Save(List<Participant> savingParticipants)
        {
            if (savingParticipants.Count > 0)
            {
                string path = @"Users/stephenatkinson/Projects/SecretSanta/testFileWrite.txt";
                using (StreamWriter test = File.CreateText(@path))
                {
           
                    //Macintosh HD\Users\stephenatkinson\Projects\SecretSanta\poo.txt
                    test.WriteLine("If you are reading this and the file is in teh write place this is working");

                    test.Flush(); 

                }  
            } 
        }
    }
}
