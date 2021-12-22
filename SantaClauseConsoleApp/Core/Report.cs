using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace SantaClauseConsoleApp
{   //todo argument better the singelton use
    //We can implement a Singelton pattern in this class because the reporting of the toys requires only an intance that will be updated
    // from the files of each Child created as Letter + increment
    public sealed class Report
    {
        public List<ToyReport> reports { get; set; }

        private static Report _instance= null;

       
        //setting up the reports from the files we already have
        private Report()
        {
            int counter = 1;
            String line="";
            while (counter!=0)
            {
                String Filename = "Letter" + counter+".txt";
                FileInfo fileInfo = new FileInfo(Filename);
                if (fileInfo.Exists)
                {
                    StreamReader reader = new StreamReader(Filename);
                    line = "";
                    Console.Write(fileInfo.Directory.FullName);
                    Console.WriteLine();
                    Console.WriteLine();
                    while (string.IsNullOrEmpty(line = reader.ReadLine()))
                    {
                        //todo all data from :
                        line = line.Substring(line.LastIndexOf(':') + 1);
                        List<String> presents = new List<string>(line.Split(','));
                        foreach (String present in presents)
                        {
                            _instance.addToy(new Item(present));
                        }
                    }

                }
                else
                {
                    break;
                }

                counter++;
            }
            //this.reports = this.reports.OrderByDescending(o=>o.counter).ToList();
        }

        public static Report Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Report();
                }

                return _instance;
            }
        }
        public bool addToy(Item toy)
        {
            foreach (ToyReport toyreport in this.reports)
            {
                if (toyreport.toy.Equals(toy))
                {
                    toyreport.increment();
                    _instance.reports = this.reports.OrderByDescending(o=>o.counter).ToList();
                    return true;
                }
            }

            ToyReport newReport = new ToyReport(toy);
            _instance.reports.Add(newReport);
            _instance.reports= _instance.reports.OrderByDescending(o=>o.counter).ToList();
            return true;
        }
        
    }
}