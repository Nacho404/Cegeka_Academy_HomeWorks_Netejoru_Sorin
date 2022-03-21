using System;
using System.Collections.Generic;

namespace Tema_01
{
    public class Set<T>
    {
        private List<T> myList = new List<T>();

        // Insert new items in Set
        public void Insert(T item)
        {

            if (myList.Contains(item))
            {
                Console.WriteLine($"The item '{item}' already exist in Set");
            }
            else
            {
                myList.Add(item);

            }
        }

        // Remove items from Set
        public void Remove(T item)
        {
            myList.Remove(item);
        }

        // Check if already exist in Set
        public bool Contains(T item)
        {
            return myList.Contains(item);
        }

        // Merge two Sets
        public Set<T> Merge(Set<T> set2)
        {
            Set<T> mergedSets = new Set<T>();

            foreach (T item in this.myList.ToArray())
            {
                mergedSets.Insert(item);
            }

            foreach (T item in set2.myList.ToArray())
            {
                mergedSets.Insert(item);
            }

            return mergedSets;
        }


        // Filter method
        public Func<Set<T>, Set<T>> filter = mySet =>
        {

            Set<T> filtredSet = new Set<T>();

            for (var i = 0; i < mySet.myList.Count; i++)
            {

                if (mySet.myList[i] is string)
                {
                    if (mySet.myList[i].ToString().Contains("Samsung"))
                    {
                        filtredSet.Insert(mySet.myList[i]);
                    }



                } else if(mySet.myList[i] is int)
                {
                    // Nu pot manipula elementele din Lista care sunt de tip "INT"
                    //if (mySet.myList[i].TryParse())
                    //{
                    //    filtredSet.Insert(mySet.myList[i]);
                    //}
                }

                
            }

            return filtredSet;
        };


        // Display my Set
        public string DisplayList()
        {
            var output = "";
            foreach (T element in myList.ToArray())
            {
                output += (element + ", ");
            }

            return output;
        }

    }


}
