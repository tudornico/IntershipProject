using System;
using System.IO;
using System.Net;
using System.Threading;


namespace SantaClauseConsoleApp
{
    public class Child 
    {
        
        public String name { get; set; }
        public int ID { get; set; }

        public static int GlobalID;
        public DateTime dateOfBirth { get; set; }
        public BehaviorEnum isGood { get; set; }
        public String adress { get; set; }

        public String Town { get; set; } 
        public Child(string name, DateTime dateOfBirth, BehaviorEnum isGood, string adress , String town )
        {
            this.name = name;
            this.dateOfBirth = dateOfBirth;
            this.isGood = isGood;
            this.adress = adress;
            this.ID = Interlocked.Increment(ref GlobalID); // auto incremeted ID
            this.Town = town;
            ChildRepository repoInstace = ChildRepository.Instace;
            repoInstace.addChild(this); // all children created will be instantly added to the repository
           
        }

        public void Writer()
        {
            Console.WriteLine("Name : " + this.name + ", Date Of Birth : " + this.dateOfBirth + ", Behaviour : " + this.isGood 
            + ", ID : " +ID + " , Town : "+this.Town);
            
        }

        public double calculateAge()
        {
            TimeSpan age = DateTime.Now.Subtract(this.dateOfBirth) ;
            return Math.Floor(age.TotalDays / 365);
        }


        
    }
}
