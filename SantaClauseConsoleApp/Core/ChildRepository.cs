using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SantaClauseConsoleApp
{
    public  class ChildRepository : IObserver<Child>
    {
        public List<Child> Children;



        public ChildRepository()
        {
            this.Children = new List<Child>();
        }

       
        public void addChild(Child child)
        {
            this.Children.Add(child);
        }

        public void groupByTown()
        {
            var Query = this.Children.GroupBy(child => child.Town,
                child => child.ID
                );
                
            
        }

        public void OnCompleted()
        {
            this.Children.Add();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(Child value)
        {
            throw new NotImplementedException();
        }
    }
}