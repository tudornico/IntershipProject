using System;
using System.Collections.Generic;
using System.IO;

namespace SantaClauseConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question1(); // works
            Question2(); 
            Question3();
            Question4();
            Question5();
            Question6();
        }

        static void Question1()
        {
            //creating the children
            DateTime date1 = new DateTime(2001, 11, 06);
            Child child1 = new Child("Tudor", date1, BehaviorEnum.Good, "Crisan 16");

            DateTime date2 = new DateTime(2001, 8, 05);
            Child child2 = new Child("Calin Pop", date2, BehaviorEnum.Bad, "Decembrie 21");

            DateTime date3 = new DateTime(1997, 03, 30);
            Child child3 = new Child("Andrei Nicolaescu", date3, BehaviorEnum.Good, "Qualle");

            //setting up presents
            Item present1 = new Item("Car");
            Item present2 = new Item("Sword");
            Item present3 = new Item("Doll");
            List<Item> presents1 = new List<Item>();
            presents1.Add(present1);
            presents1.Add(present2);
            //first Letter
            Letter letter1 = new Letter(child1, DateTime.Now, presents1);
            child1.Writer();
            letter1.Writer();
            Console.WriteLine();
            Console.WriteLine();
            //setting up presents
            List<Item> presents2 = new List<Item>();
            presents2.Add(present2);
            presents2.Add(present3);
            //second letter 
            Letter letter2 = new Letter(child2, DateTime.Now, presents2);
            child2.Writer();
            letter2.Writer();
            Console.WriteLine();
            Console.WriteLine();

            //setting up presents
            List<Item> presents3 = new List<Item>();
            presents3.Add(present1);
            presents3.Add(present3);
            //third letter
            Letter letter3 = new Letter(child3, DateTime.Now, presents3);
            child3.Writer();
            letter3.Writer();
        }

        static void Question2()
        { //todo create data
            DateTime date1 = new DateTime(2001, 11, 06);
            Child child1 = new Child("Tudor", date1, BehaviorEnum.Good, "Crisan 16");

            DateTime date2 = new DateTime(2001, 8, 05);
            Child child2 = new Child("Calin Pop", date2, BehaviorEnum.Bad, "Decembrie 21");

            DateTime date3 = new DateTime(1997, 03, 30);
            Child child3 = new Child("Andrei Nicolaescu", date3, BehaviorEnum.Good, "Qualle");

            //setting up presents
            Item present1 = new Item("Car");
            Item present2 = new Item("Sword");
            Item present3 = new Item("Doll");
            List<Item> presents1 = new List<Item>();
            presents1.Add(present1);
            presents1.Add(present2);
            //first Letter
            Letter letter1 = new Letter(child1, DateTime.Now, presents1);
            child1.Writer();
            letter1.createFileLetter("Letter1.txt");
            Console.WriteLine();
            Console.WriteLine();
            //setting up presents
            List<Item> presents2 = new List<Item>();
            presents2.Add(present2);
            presents2.Add(present3);
            //second letter 
            Letter letter2 = new Letter(child2, DateTime.Now, presents2);
            child2.Writer();
            letter2.createFileLetter("Letter2.txt");
            Console.WriteLine();
            Console.WriteLine();

            //setting up presents
            List<Item> presents3 = new List<Item>();
            
            presents3.Add(present1);
            presents3.Add(present3);
            //third letter
            Letter letter3 = new Letter(child3, DateTime.Now, presents3);
            child3.Writer();
            letter3.createFileLetter("Letter3.txt");
        }

        static void Question3()
        {
            ;
        }

        static void Question4()
        {
        }

        static void Question5()
        {
        }

        static void Question6()
        {
        }
    }
}