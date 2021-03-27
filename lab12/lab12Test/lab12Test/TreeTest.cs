using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Xunit;
using L12;
using OOPlab10;
using OOPLAB11;

namespace lab12Test
{
    public class TreeTest
    {
        [Fact]
        public void TreeNodeTConstructorTest()
        {
            Person p = new Person("A",16,'M');
            
            TreeNode<Person> node = new TreeNode<Person>(p);
            
            Assert.Equal("A",node.Data.Name);
            
            
        }
        
        [Fact]
        public void TreeNodeTreeNodeTConstructorTest()
        {
            Person p = new Person("A",16,'M');
            
            TreeNode<Person> node = new TreeNode<Person>(p);
            node.Left = node;
            TreeNode<Person> node2 = new TreeNode<Person>(node);
            Assert.Equal("A",node2.Data.Name);
            Assert.Equal(node.Left, node2.Left);
        }
        

        [Fact]
        public void DataPropertyTest()
        {
            string expString = "Hello world";
            TreeNode<Person> node = new(new Person());
            node.Data.Name = expString;
            
            Assert.Equal(expString,node.Data.Name);
        }

        [Fact]
        public void TreeNodeTLeftRightPropertyTest()
        {
            
            Person p = new Employee();
            Person p1 = new Employee();
            TreeNode<Person> a = new TreeNode<Person>(p);
            TreeNode<Person> b = new TreeNode<Person>(p1);
            b.Data.Name = "World Hello";
            a.Left = b;
            a.Right = b;
            Assert.Equal("World Hello",a.Left.Data.Name);
            Assert.Equal("World Hello",a.Right.Data.Name);
            Assert.Null(b.Left);
            Assert.Null(b.Right);
        }

        [Fact]
        public void TreeConstructorWithoutParamsTest()
        {
            Tree<Person> t = new Tree<Person>();
            Assert.Null(t.Root);
            Assert.Equal(0,t.Size);
        }
        
        [Fact]
        public void TreeConstructorWithICollParamsTest()
        {
            Person p = Generator.CreateNewEmployee().Base;
            ICollection<Person> d = new List<Person>();
            d.Add(p);
            Tree<Person> t = new Tree<Person>(d);
            Assert.Equal(p,t.Root.Data);
            Assert.Equal(1,t.Size);
        }

        [Fact]
        public void TreeConstructorWithCapacityParamTest()
        {
            Tree<Person> tp = new Tree<Person>(10);
            
            Assert.Equal(0,tp.Size);
        }

        [Fact]
        public void SearchTest()
        {
            string name = "Вахтанг Кикабидзе";

            ICollection<Person> persCol = new List<Person>();
            for (int i = 0; i < 10; i++)
            {
                persCol.Add(Generator.CreateNewEmployee().Base);
            }
            persCol.Add(new Person(name,16,'М'));

            Tree<Person> t = new Tree<Person>(persCol);
            
            Assert.Equal(1,t.Search(name));


        }
        
        [Fact]
        public void ClearTest()
        {
            string name = "Вахтанг Кикабидзе";

            ICollection<Person> persCol = new List<Person>();
            for (int i = 0; i < 10; i++)
            {
                persCol.Add(Generator.CreateNewEmployee().Base);
            }
            persCol.Add(new Person(name,16,'М'));

            Tree<Person> t = new Tree<Person>(persCol);

            t.Clear();
            
            Assert.Equal(0,t.Size);
            Assert.Null(t.Root);
        }

        [Fact]
        public void InsertTest()
        {
            string name = "Вахтанг Кикабидзе";

            ICollection<Person> persCol = new List<Person>();
            for (int i = 0; i < 10; i++)
            {
                persCol.Add(Generator.CreateNewEmployee().Base);
            }
            

            Tree<Person> t = new Tree<Person>(persCol);

            t.Insert(t.Root, new Person(name, 16, 'М'));
            Assert.Equal(1,t.Search(name));
        }
        
        
        [Fact]
        public void AddRangeTest()
        {
            ICollection<Person> persCol = new List<Person>();
            for (int i = 0; i < 10; i++)
            {
                persCol.Add(Generator.CreateNewEmployee().Base);
            }
            

            Tree<Person> t = new Tree<Person>();

            t.AddRange(persCol);
            
            Assert.Equal(10,t.Size);
        }

        [Fact]
        public void CloneTest()
        {
            ICollection<Person> persCol = new List<Person>();
            for (int i = 0; i < 10; i++)
            {
                persCol.Add(Generator.CreateNewEmployee().Base);
            }
            

            Tree<Person> t = new Tree<Person>(persCol);

            var tC = (Tree<Person>)t.Clone();
            
            Assert.Equal(t.Size,tC.Size);
            Assert.Equal(t.Height,tC.Height);
        }

        [Fact]
        public void CopyTest()
        {
            ICollection<Person> persCol = new List<Person>();
            for (int i = 0; i < 10; i++)
            {
                persCol.Add(Generator.CreateNewEmployee().Base);
            }
            

            Tree<Person> t = new Tree<Person>(persCol);

            var tC = t.Copy();
            
            Assert.Equal(t.Size,tC.Size);
            Assert.Equal(t.Height,tC.Height);
            Assert.Equal(t.GetHashCode(),tC.GetHashCode());
        }
    }
}