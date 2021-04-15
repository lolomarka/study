using System.Collections;
using System.Collections.Generic;
using System.Linq;
using OOPlab10;
using OOPLAB11;

namespace L14
{
    public static class TestCollectionExtention
    {
        public static IEnumerable<string> Q1Males(this TestCollections<Person, Employee> collection)
        {
            var results = collection.Keys.Where(item => item.Sex == 'М').Select(p => p.Name);
            return results;
        }
        
        public static IEnumerable<string> Q1Females(this TestCollections<Person, Employee> collection)
        {
            var results = collection.Keys.Where(item => item.Sex == 'Ж').Select(p => p.Name);
            return results;
        }

        public static int Q2MalesCount(this TestCollections<Person, Employee> collection)
        {
            var result = collection.Keys.Where(item => item.Sex == 'М').Count();
            return result;
        }

        public static int Q2FemalesCount(this TestCollections<Person, Employee> collections)
        {
            var result = collections.Keys.Where(item => item.Sex == 'Ж').Count();
            return result;
        }

        public static IEnumerable<Person> Q3InterAgesPers(this TestCollections<Person, Employee> collections)
        {
            var result = collections.Keys.SelectMany(p => collections.Values, (p, e) => new {p, e})
                .Where(@t => @t.p.Age == @t.e.Age)
                .Select(@t => @t.p);

            return result;
        }

        public static IEnumerable<Employee> Q3InterAgesEmps(this TestCollections<Person, Employee> collections)
        {
            var result = collections.Keys.SelectMany(p => collections.Values, (p, e) => new {p, e})
                .Where(@t => @t.p.Age == @t.e.Age)
                .Select(@t => @t.e);

            return result;
        }

        public static int Q4AverageAge(this TestCollections<Person, Employee> collections)
        {
            var ka = collections.Keys.Select(item => item.Age).Average();
            var va = collections.Values.Select(item => item.Age).Average();

            return (int)((ka + va) / 2);
        }

        public static IEnumerable<IGrouping<int, Person>> Q5_GroupByAge(this TestCollections<Person, Employee> collections)
        {
            var tc = collections.Keys.Union(collections.Values);
            
            var result = tc.GroupBy(person => person.Age).OrderBy(newGroup => newGroup.Key);
            return result;
        }
    }
}