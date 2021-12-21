using System;
using System.Threading;

namespace SantaClauseConsoleApp
{
    public class Child
    {
        public String name { get; set; }
        public  int ID { get; set; }

        public static int GlobalID;
        public DateTime dateOfBirth { get; set; }
        public BehaviorEnum isGood { get; set; }
        public String adress { get; set; }
        // <summary>
        // constror for the child clas
        //     
        // </summary>
        public Child(string name, DateTime dateOfBirth, BehaviorEnum isGood, string adress )
        {
            this.name = name;
            this.dateOfBirth = dateOfBirth;
            this.isGood = isGood;
            this.adress = adress;
            this.ID = Interlocked.Increment(ref GlobalID); // auto incremeted ID
        }

        public void Writer()
        {
            Console.WriteLine("Name : " + this.name + ", Date Of Birth : " + this.dateOfBirth + ", Behaviour : " + this.isGood 
            + ", ID : " +ID);
            
        }

        public double calculateAge()
        {
            TimeSpan age = this.dateOfBirth.Subtract(DateTime.Now) ;
            return Math.Floor(age.TotalDays / 365);
        }
    }
}
