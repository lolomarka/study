using System.Collections;
using System.Collections.Generic;
using System.Linq;
using OOPlab10;
using OOPLAB11;

namespace L14
{
    public static class TestCollectionExtention
    {
        public static IEnumerable<string> Q1Males(this LinkedList<TestCollections<Person, Employee>> collection)
        {
            var results = collection.SelectMany(item => item, (item, i) => new {item, i})
                .Where(@t => @t.i.Sex == 'М')
                .Select(@t => @t.i.Name);
            return results;
        }
        
        public static IEnumerable<string> Q1Females(this LinkedList<TestCollections<Person, Employee>> collection)
        {
            var results = collection.SelectMany(item => item, (item, i) => new {item, i})
                .Where(@t => @t.i.Sex == 'Ж')
                .Select(@t => @t.i.Name);
            return results;
        }

        public static int Q2MalesCount(this LinkedList<TestCollections<Person, Employee>> collection)
        {
            var result = (collection.SelectMany(item => item, (item, i) => new {item, i})
                .Where(@t => @t.i.Sex == 'М')
                .Select(@t => @t.i)).Count();

            return result;
        }

        public static int Q2FemalesCount(this LinkedList<TestCollections<Person, Employee>> collection)
        {
            var result = (collection.SelectMany(item => item, (item, i) => new {item, i})
                    .Where(@t => @t.i.Sex == 'Ж')
                    .Select(@t => @t.i)).Count();

            return result;
        }

        public static IEnumerable<string> Q3_Intersect(this LinkedList<TestCollections<Person, Employee>> col1,LinkedList<TestCollections<Person, Employee>> col2)
        {
            return 
                col1.SelectMany(item => item, (item, j) => $"{j.Name}")
            .Intersect(
            (col2.SelectMany(item => item, (item, j) => $"{j.Name}")));
        }

        public static double Q4AverageAge(this LinkedList<TestCollections<Person, Employee>> collections)
        {
            var result = collections.SelectMany(item => item, (item, i) => i.Age).Average();

            return result;
        }

        public static IEnumerable<IGrouping<int, Person>> Q5_GroupByAge(this LinkedList<TestCollections<Person, Employee>> collections)
        {
            var result = collections.SelectMany(item => item, (item, i) => new {item, i})
                .GroupBy(@t => @t.i.Age, @t => @t.i)
                .OrderBy(newGroup => newGroup.Key);
            return result;
        }
    }
}