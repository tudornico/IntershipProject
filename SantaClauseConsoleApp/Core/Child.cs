using System;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SantaClauseConsoleApp
{
    public class Child : IObservable<Child>
    {
        public String name { get; set; }
        public int ID { get; set; }

        public static int GlobalID;
        public DateTime dateOfBirth { get; set; }
        public BehaviorEnum isGood { get; set; }
        public String adress { get; set; }

        public String Town { get; set; }

        public void writeInJson()
        {
            // JsonArrayAttribute array = new JsonArrayAttribute();
            // String Json = JsonConvert.SerializeObject(this);
            // JsonAttribute jsonAttribute;
            JObject jObject = JObject.Load();
            File.AppendAllText("ChildJson.json", Json);
            File.AppendAllText("ChildJson.json",",\n");

        }

       
        public Child(string name, DateTime dateOfBirth, BehaviorEnum isGood, string adress , String town )
        {
            this.name = name;
            this.dateOfBirth = dateOfBirth;
            this.isGood = isGood;
            this.adress = adress;
            this.ID = Interlocked.Increment(ref GlobalID); // auto incremeted ID
            this.Town = town;
            this.Subscribe(ChildRepository);
            this.writeInJson();
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

        public IDisposable Subscribe(IObserver<Child> observer)
        {
            observer.OnCompleted();
        }
    }
}
