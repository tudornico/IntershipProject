﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace SantaClauseConsoleApp
{
    public  class Letter
    {
        public int ID;
        public static int globalId;
        public Child sender;
        public DateTime sendDate { get; set; }

        public List<Item> presents;

        public Letter(Child sender, DateTime sendDate,List<Item> items)
        {
            this.sender = sender;
            this.sendDate = sendDate;
            this.presents = items;
            this.ID = Interlocked.Increment(ref globalId); // auto incermeted ID
        }

        public void createTextLetter() // todo make the file work
        {  
            StreamReader reader = new StreamReader("letter-template.txt");
            string line;
            while (!string.IsNullOrEmpty(line = reader.ReadLine()))
            {
                line = line.Replace("[FULL_NAME]", this.sender.name);
                line = line.Replace("[AGE]", this.sender.calculateAge().ToString());
                line = line.Replace("[ADDRESS]", this.sender.adress);
                line = line.Replace("[BEHAVIOR]", this.sender.isGood.ToString());

                if (line.Contains("[PRESENT1]"))
                {   // if we get to the present line then we delete all and just add the presents
                    line = null;
                    for (int i = 0; i<this.presents.Count;i++)
                    {
                        line += this.presents.ElementAt(i).name + " , ";
                    }
                }
                Console.WriteLine(line);
            }
            
            
        }

        public void Writer()
        {
            
            Console.WriteLine("Child : "+this.sender.name + ", Date : "+this.sendDate + ", ID : "+this.ID
            +", Presents : ");
            foreach (Item present in this.presents)
            {
                Console.Write(present.name + " ; ");
            }
        }
        //hopefully if the first works this works as well
        public void createFileLetter(String FileName)
        {
            String FullLetter="";
            
            if(!File.Exists(FileName))
                File.Create(FileName);
            StreamWriter writer = new StreamWriter(FileName);
            StreamReader reader = new StreamReader("letter-template.txt");
            string line;
            while (!string.IsNullOrEmpty(line = reader.ReadLine()))
            {
                line = line.Replace("[FULL_NAME]", this.sender.name);
                line = line.Replace("[AGE]", this.sender.calculateAge().ToString());
                line = line.Replace("[ADRESS]", this.sender.adress);
                line = line.Replace("[BEHAVIOR]", this.sender.isGood.ToString());

                if (line.Contains("[PRESENT1]"))
                {   // if we get to the present line then we delete all and just add the presents
                    line = null;
                    for (int i = 0; i<this.presents.Count;i++)
                    {
                        line += this.presents.ElementAt(i).name + " , ";
                    }
                }

                FullLetter += line;
            }
            reader.Close();
            writer.WriteLine(FullLetter);
        }
    }
}
