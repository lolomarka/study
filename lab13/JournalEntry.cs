using System;
using System.Collections.Generic;
using System.Text;

namespace L13
{
    public class JournalEntry
    {
        public string CollectionName { get; set; }
        public string ChangeType { get; set; }
        public object Object { get; set; }

        public JournalEntry(string name, string changeType, object obj)
        {
            CollectionName = name;
            ChangeType = changeType;
            Object = obj;
        }

        public override string ToString() => $"{CollectionName}: `{ChangeType}` of {Object}";
    }
}
