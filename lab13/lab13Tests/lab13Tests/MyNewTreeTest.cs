using System.Collections.Generic;
using Xunit;
using lab13;
using OOPlab10;

namespace lab13Tests
{
    public class MyNewTreeTest
    {
        [Fact]
        public void ConstructorWithName()
        {
            MyNewTree<Engineer> mnt = new MyNewTree<Engineer>("TEST");
            Assert.Equal("TEST",mnt.Name);
        }
        
        [Fact]
        public void ConstructorWithCapacityName()
        {
            MyNewTree<Person> mnt = new MyNewTree<Person>(10,"TEST");
            Assert.Equal("TEST",mnt.Name);
            Assert.Equal(10,mnt.Capacity);
        }

        [Fact]
        public void ConstructorWithDataName()
        {
            List<Person> lst = new List<Person>();
            
            //
            lst.Add(Generator.CreateNewAdministration());
            lst.Add(Generator.CreateNewAdministration());
            lst.Add(Generator.CreateNewAdministration());
            lst.Add(Generator.CreateNewAdministration());
            lst.Add(Generator.CreateNewAdministration());
            //5

            var llst = (ICollection<Person>)lst;
            MyNewTree<Person> mnt = new MyNewTree<Person>(llst,"TEST");
            Assert.Equal("TEST",mnt.Name);
            Assert.Equal(5,mnt.Size);
        }
        
    }
}