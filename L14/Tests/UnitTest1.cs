using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using L14;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Program = Microsoft.VisualStudio.TestPlatform.TestHost.Program;
using OOPlab10;
using OOPLAB11;
using L12;

namespace Tests
{
    public class Test
    {
        [Fact]
        public void Q1TestLINQ()
        {
            var tVal = new Queue<Employee>();
            tVal.Enqueue(new Employee("A",19,'Ж',"ЖЖАЖАЖА"));
            tVal.Enqueue(new Employee("A",19,'М',"ЖЖАЖАфывА"));
            var tS = new Queue<Person>();
            tS.Enqueue(new Person("VFa",23,'М'));
            tS.Enqueue(new Person("VF",23,'Ж'));
            TestCollections<Person, Employee> testCollections = new TestCollections<Person, Employee>(tVal,tS);

            List<string> lPers = new List<string>() {new Person("VFa",23,'М').Name};
            
            Assert.Equal(lPers,L14.Program.Q1Males(testCollections).ToList());
            
            List<string> lPers2 = new List<string>() {new Person("VF",23,'Ж').Name};
            
            Assert.Equal(lPers2,L14.Program.Q1Females(testCollections).ToList());
        }
        
        [Fact]
        public void Q1TestExt()
        {
            var tVal = new Queue<Employee>();
            tVal.Enqueue(new Employee("A",19,'Ж',"ЖЖАЖАЖА"));
            tVal.Enqueue(new Employee("A",19,'М',"ЖЖАЖАфывА"));
            var tS = new Queue<Person>();
            tS.Enqueue(new Person("VFa",23,'М'));
            tS.Enqueue(new Person("VF",23,'Ж'));
            TestCollections<Person, Employee> testCollections = new TestCollections<Person, Employee>(tVal,tS);

            List<string> lPers = new List<string>() {new Person("VFa",23,'М').Name};
            
            Assert.Equal(lPers,testCollections.Q1Males().ToList());
            
            List<string> lPers2 = new List<string>() {new Person("VF",23,'Ж').Name};
            
            Assert.Equal(lPers2,testCollections.Q1Females().ToList());
        }


        [Fact]
        public void Q2TestLINQ()
        {
            var tVal = new Queue<Employee>();
            tVal.Enqueue(new Employee("A",19,'Ж',"ЖЖАЖАЖА"));
            tVal.Enqueue(new Employee("A",19,'М',"ЖЖАЖАфывА"));
            tVal.Enqueue(new Employee("A",19,'М',"ЖЖАЖАфывА"));
            tVal.Enqueue(new Employee("A",19,'М',"ЖЖАЖАфывА"));
            tVal.Enqueue(new Employee("A",19,'М',"ЖЖАЖАфывА"));
            
            var tS = new Queue<Person>();
            tS.Enqueue(new Person("VFa",23,'М'));
            tS.Enqueue(new Person("VF2",23,'М'));
            tS.Enqueue(new Person("VF3",23,'Ж'));
            tS.Enqueue(new Person("VфF",23,'М'));
            tS.Enqueue(new Person("VвF",23,'Ж'));
            TestCollections<Person, Employee> testCollections = new TestCollections<Person, Employee>(tVal,tS);
            
            Assert.Equal(3, L14.Program.Q2MalesCounter(testCollections));
            Assert.Equal(2, L14.Program.Q2FemalesCounter(testCollections));
        }
        
        [Fact]
        public void Q2TestExt()
        {
            var tVal = new Queue<Employee>();
            tVal.Enqueue(new Employee("A",19,'Ж',"ЖЖАЖАЖА"));
            tVal.Enqueue(new Employee("A",19,'М',"ЖЖАЖАфывА"));
            tVal.Enqueue(new Employee("A",19,'М',"ЖЖАЖАфывА"));
            tVal.Enqueue(new Employee("A",19,'М',"ЖЖАЖАфывА"));
            tVal.Enqueue(new Employee("A",19,'М',"ЖЖАЖАфывА"));
            
            var tS = new Queue<Person>();
            tS.Enqueue(new Person("VFa",23,'М'));
            tS.Enqueue(new Person("VF2",23,'М'));
            tS.Enqueue(new Person("VF3",23,'Ж'));
            tS.Enqueue(new Person("VфF",23,'М'));
            tS.Enqueue(new Person("VвF",23,'Ж'));
            TestCollections<Person, Employee> testCollections = new TestCollections<Person, Employee>(tVal,tS);
            
            Assert.Equal(3, testCollections.Q2MalesCount());
            Assert.Equal(2, testCollections.Q2FemalesCount());
        }
        
        [Fact]
        public void Q3TestLINQ()
        {
            List<Person> lPers = new List<Person>() {new Person(), new Person(), new Person("Hello world", 25, 'М')};
            List<Employee> lEmps = new List<Employee>() {new Employee(), new Employee(), new Employee("Hello world", 32, 'М', "Junior Dev")};
            
            Assert.Equal(new List<Person>(){new Person(),new Person(), new Person() ,new  Person()}, L14.Program.Q3_InterAgesPers(lPers,lEmps).ToList());
            Assert.Equal(new List<Employee>(){new Employee(),new Employee(), new Employee() ,new  Employee()}, L14.Program.Q3_InterAgesEmps(lPers,lEmps).ToList());
        }
        
        [Fact]
        public void Q3TestExt()
        {
            var tVal = new Queue<Employee>();
            tVal.Enqueue(new Employee("М",16,'Ж',"aaa"));
            tVal.Enqueue(new Employee("S",16,'Ж',"aa2a"));
            tVal.Enqueue(new Employee("Hello world", 32, 'М', "Junior Dev"));

            
            var tS = new Queue<Person>();
            tS.Enqueue(new Person("М",16,'Ж'));
            tS.Enqueue(new Person("S",16,'Ж'));
            tS.Enqueue( new Person("Hello world", 25, 'М'));
            
            TestCollections<Person, Employee> testCollections = new TestCollections<Person, Employee>(tVal,tS); 
            
            List<Person> lPers = new List<Person>() {new Person(), new Person(), new Person("Hello world", 25, 'М')};
            List<Employee> lEmps = new List<Employee>() {new Employee(), new Employee(), new Employee("Hello world", 32, 'М', "Junior Dev")};
            
            Assert.Equal(new List<Person>(){new Person("М",16,'Ж'),new Person("М",16,'Ж'),new Person("S",16,'Ж'),new Person("S",16,'Ж')}, testCollections.Q3InterAgesPers().ToList());
            Assert.Equal(new List<Employee>(){new Employee("S",16,'Ж',"aa2a"), new Employee("М",16,'Ж',"aaa"), new Employee("S",16,'Ж',"aa2a"), new Employee("М",16,'Ж',"aaa")}, testCollections.Q3InterAgesEmps().ToList());
        }

        [Fact]
        public void Q4TestLINQ()
        {
            var tVal = new Queue<Employee>();
            tVal.Enqueue(new Employee("М",16,'Ж',"aaa"));
            tVal.Enqueue(new Employee("S",16,'Ж',"aa2a"));
            tVal.Enqueue(new Employee("Hello world", 32, 'М', "Junior Dev"));

            
            var tS = new Queue<Person>();
            tS.Enqueue(new Person("М",16,'Ж'));
            tS.Enqueue(new Person("S",16,'Ж'));
            tS.Enqueue( new Person("Hello world", 25, 'М'));
            
            TestCollections<Person, Employee> testCollections = new TestCollections<Person, Employee>(tVal,tS); 
            
            Assert.Equal(20, L14.Program.Q4_AverageAge(testCollections));
        }
        
        
        [Fact]
        public void Q4TestExt()
        {
            var tVal = new Queue<Employee>();
            tVal.Enqueue(new Employee("М",16,'Ж',"aaa"));
            tVal.Enqueue(new Employee("S",16,'Ж',"aa2a"));
            tVal.Enqueue(new Employee("Hello world", 32, 'М', "Junior Dev"));

            
            var tS = new Queue<Person>();
            tS.Enqueue(new Person("М",16,'Ж'));
            tS.Enqueue(new Person("S",16,'Ж'));
            tS.Enqueue( new Person("Hello world", 25, 'М'));
            
            TestCollections<Person, Employee> testCollections = new TestCollections<Person, Employee>(tVal,tS); 
            
            Assert.Equal(20, testCollections.Q4AverageAge());
        }
        
        [Fact]
        public void Q5TestLINQ()
        {
            var tVal = new Queue<Employee>();
            tVal.Enqueue(new Employee("М",16,'Ж',"aaa"));
            tVal.Enqueue(new Employee("S",16,'Ж',"aa2a"));
            tVal.Enqueue(new Employee("Hello world", 32, 'М', "Junior Dev"));

            
            var tS = new Queue<Person>();
            tS.Enqueue(new Person("М",15,'Ж'));
            tS.Enqueue(new Person("S",15,'Ж'));
            tS.Enqueue( new Person("Hello world", 25, 'М'));
            
            TestCollections<Person, Employee> testCollections = new TestCollections<Person, Employee>(tVal,tS); 
            
            Assert.Equal(new Person("М",15,'Ж'), L14.Program.Q5_GroupByAge(testCollections).ToList()[0].First());
        }
        
        [Fact]
        public void Q5TestExt()
        {
            var tVal = new Queue<Employee>();
            tVal.Enqueue(new Employee("М",16,'Ж',"aaa"));
            tVal.Enqueue(new Employee("S",16,'Ж',"aa2a"));
            tVal.Enqueue(new Employee("Hello world", 32, 'М', "Junior Dev"));

            
            var tS = new Queue<Person>();
            tS.Enqueue(new Person("М",15,'Ж'));
            tS.Enqueue(new Person("S",15,'Ж'));
            tS.Enqueue( new Person("Hello world", 25, 'М'));
            
            TestCollections<Person, Employee> testCollections = new TestCollections<Person, Employee>(tVal,tS); 
            
            Assert.Equal(new Person("М",15,'Ж'), testCollections.Q5_GroupByAge().ToList()[0].First());
        }
    }
}