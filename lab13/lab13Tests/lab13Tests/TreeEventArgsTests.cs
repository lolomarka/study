using System;
using Xunit;
using lab13;
using OOPlab10;

namespace lab13Tests
{
    public class TreeEventArgsTests
    {
        [Fact]
        public void TreeEventArgsConstructorTest()
        {
            string name = "TestCollection";
            string changeType = "TestChangeType";
            Person p = new Person();

            TreeEventArgs tea = new TreeEventArgs(name, changeType, p);
            
            Assert.Equal("TestCollection",tea.CollectionName);
            Assert.Equal("TestChangeType",tea.ChangeType);
            Assert.Equal(new Person(), tea.Object);

            tea.CollectionName = "TestChangeType";
            tea.ChangeType = "TestCollection";
            tea.Object = new Engineer();
            
            Assert.Equal("TestChangeType",tea.CollectionName);
            Assert.Equal("TestCollection",tea.ChangeType);
            Assert.Equal(new Engineer(), tea.Object);
        }
        
        [Fact]
        public void TreeEventArgsToStringTest()
        {
            string name = "TestCollection";
            string changeType = "TestChangeType";
            Person p = new Person();

            TreeEventArgs tea = new TreeEventArgs(name, changeType, p);
            
            Assert.Equal($"TestCollection: 'TestChangeType' for {new Person()}",tea.ToString());
        }
        
        
    }
    
    
}