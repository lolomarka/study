using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using L12;
namespace lab12Test
{
    public class LinkedListTest
    {
        [Fact]
        public void OwNodeTConstructorTest()
        {
            string expString = "Hello world";
            OWNode<string> node = new(expString);
            
            Assert.Equal(expString,node.Data);
        }

        [Fact]
        public void DataPropertyTest()
        {
            string expString = "Hello world";
            OWNode<string> node = new("a");
            node.Data = expString;
            
            Assert.Equal(expString,node.Data);
        }

        [Fact]
        public void OwNodeTNextPropertyTest()
        {
            OWNode<string> a = new OWNode<string>("Hello World");
            OWNode<string> b = new OWNode<string>("World Hello");

            a.Next = b;
            
            Assert.Equal("World Hello",a.Next.Data);
        }

        [Fact]
        public void AddFirstTest()
        {
            List<char> l = "HelloWorl".ToCharArray().ToList();
            OWLinkedList<char> a = new OWLinkedList<char>(l);
            a.AddFirst('d');
            Assert.Equal('d',a.Head.Data);
            Assert.Equal(9,l.Count);
        }
        [Fact]
        public void AddLastTest()
        {
            List<char> l = "HelloWorld".ToCharArray().ToList();
            OWLinkedList<char> a = new OWLinkedList<char>(l);
            
            Assert.Equal('d',a.Tail.Data);
            Assert.Equal(10,l.Count);
        }

        [Fact]
        public void RemoveTest()
        {
            List<char> l = "HelloWorld".ToCharArray().ToList();
            OWLinkedList<char> a = new OWLinkedList<char>(l);

            Assert.True(a.Remove('W'));
            Assert.False(a.Remove('0'));
            Assert.DoesNotContain('W',a);
            Assert.Equal(9,a.Size);
        }

        [Fact]
        public void DeleteListTest()
        {
            OWLinkedList<char> a = new OWLinkedList<char>("hello".ToCharArray().ToList());
            OWLinkedList<char> b = new OWLinkedList<char>("".ToCharArray().ToList());
            
            Assert.True(a.DeleteList());
            Assert.False(b.DeleteList());
        }
    }
}