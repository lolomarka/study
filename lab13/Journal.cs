using OOPlab10;
using System;
using System.Collections.Generic;

namespace L13
{
    public class Journal<T> where T : Person
    {
        private List<JournalEntry> journal;
        public string Name { get; set; }

        public int Count { get { return journal.Count; } }
        public Journal(string name)
        {
            journal = new List<JournalEntry>();
            Name = name;
        }
        public void AddCountChangeInfo(object source, TreeEventArgs args)
        {
            journal.Add(new JournalEntry(args.CollectionName, args.ChangeType, args.Object));
        }

        public void AddRefChangeInfo(object source, TreeEventArgs args)
        {
            journal.Add(new JournalEntry(args.CollectionName, args.ChangeType, args.Object));
        }

        public void Print()
        {
            Console.WriteLine($"{Name}: ");
            journal.ForEach((entry) => Console.WriteLine(entry));
        }
    }
}
