using System;
using System.Collections.Generic;

namespace SantaClauseConsoleApp
{
    public class UI
    {
        public void Innit()
        {
            
        }

        private void NewChild(String name,String town,String andress,DateTime birthDate,BehaviorEnum isGood)
        {
            Child child = new Child(name, birthDate, isGood, andress, town);
        }

        private void SeeAllChildren(List<Child> childList)
        {
            foreach (Child child in childList)
            {
                child.Writer();
            }
           
        }

        private void SortedChildren()
        {
            ChildRepository repo = ChildRepository.Instace;
            SeeAllChildren(repo.Children);
        }

       
        
        private void CreateLetter(Child child)
        {
            
        }
    }
}
