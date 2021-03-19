using System.Collections.Generic;
using System.Linq;
using Xunit;
using L12;
namespace lab12Test
{
    public class TWLinkedListTest
    {
        [Fact]
        public void TwNodeTConstructorTest()
        {
            string expString = "Hello world";
            TWNode<string> node = new(expString);
            
            Assert.Equal(expString,node.Data);
            Assert.Null(node.Prev);
            Assert.Null(node.Next);
        }

        [Fact]
        public void DataPropertyTest()
        {
            string expString = "Hello world";
            TWNode<string> node = new("a");
            node.Data = expString;
            
            Assert.Equal(expString,node.Data);
        }

        [Fact]
        public void TwNodeTNextPrevPropertyTest()
        {
            TWNode<string> a = new TWNode<string>("Hello World");
            TWNode<string> b = new TWNode<string>("World Hello");

            a.Next = b;
            b.Prev = a;
            Assert.Equal("World Hello",a.Next.Data);
            Assert.Equal("Hello World",b.Prev.Data);
            Assert.Null(a.Prev);
            Assert.Null(b.Next);
        }

        [Fact]
        public void AddFirstTest()
        {
            List<char> l = "HelloWorl".ToCharArray().ToList();
            TWLinkedList<char> a = new TWLinkedList<char>(l);
            a.AddFirst('d');
            Assert.Equal('d',a.Head.Data);
            Assert.Equal(9,l.Count);
        }
        [Fact]
        public void AddLastTest()
        {
            List<char> l = "HelloWorld".ToCharArray().ToList();
            TWLinkedList<char> a = new TWLinkedList<char>(l);
            
            Assert.Equal('d',a.Tail.Data);
            Assert.Equal(10,l.Count);
        }

        [Fact]
        public void AddAtTest()
        {
            List<char> l = "HelloWorld".ToCharArray().ToList();
            TWLinkedList<char> a = new TWLinkedList<char>(l);
            a.AddAt('M', 2);
            Assert.Equal('M',a.Head.Next.Data);
            
        }
        
        [Fact]
        public void RemoveTest()
        {
            List<char> l = "HelloWorld".ToCharArray().ToList();
            TWLinkedList<char> a = new TWLinkedList<char>(l);

            Assert.True(a.Remove('W'));
            Assert.False(a.Remove('0'));
            Assert.DoesNotContain('W',a);
            Assert.Equal(9,a.Size);
        }

        [Fact]
        public void DeleteListTest()
        {
            TWLinkedList<char> a = new TWLinkedList<char>("hello".ToCharArray().ToList());
            TWLinkedList<char> b = new TWLinkedList<char>("".ToCharArray().ToList());
            
            Assert.True(a.DeleteList());
            Assert.False(b.DeleteList());
        }
    }
}