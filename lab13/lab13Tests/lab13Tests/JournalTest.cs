using System.Collections.Generic;
using Xunit;
using lab13;
using OOPlab10;
namespace lab13Tests
{
    public class JournalTest
    {
        [Fact]
        public void ConstructorWithNameTest()
        {
            Journal<Person> jp = new Journal<Person>("TEST");
            
            Assert.Equal("TEST", jp.Name);
        }

        [Fact]
        public void AddCountChangeInfoTest()
        {
            MyNewTree<Person> lTest = new MyNewTree<Person>("TEST");

            Journal<Person> jTest = new Journal<Person>("JOUR_TEST");

            lTest.CountChanged += jTest.AddCountChangeInfo;

            lTest.Add(new Person());
            
            Assert.Equal(1,jTest.Count);
            
            lTest.Delete(lTest[0]);
            Assert.Equal(2,jTest.Count);
        }
        
        [Fact]
        public void AddRefChangeInfoTest()
        {
            MyNewTree<Person> lTest = new MyNewTree<Person>("TEST");

            Journal<Person> jTest = new Journal<Person>("JOUR_TEST");

            lTest.RefChanged += jTest.AddRefChangeInfo;

            lTest.Add(new Person());
            
            Assert.Equal(0,jTest.Count);

            lTest[0] = new Person();
            Assert.Equal(1,jTest.Count);
        }
        
    }

    public class JournalEntryTest
    {
        [Fact]
        public void ConstructorTest()
        {
            JournalEntry je = new JournalEntry("TEST", "TEST", "TEST");
            
            Assert.Equal("TEST",je.CollectionName);
            Assert.Equal("TEST",je.ChangeType);
            Assert.Equal("TEST",je.Object);
        }
    }
}