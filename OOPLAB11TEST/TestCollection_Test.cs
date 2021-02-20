using System;
using System.Collections.Generic;
using Xunit;
using OOPLAB11;
using OOPlab10;

namespace OOPLAB11TEST
{
    public class TestCollectionTest : IDisposable
    {
        TestCollections<Person, Employee> _tColl;

        public TestCollectionTest()
        {
            _tColl = new TestCollections<Person, Employee>();
        }

        public void Dispose()
        {
            _tColl.Dispose();
        }

        [Fact]
        public void WithNoItem_CountShouldReturnZero()
        {
            var count = _tColl.Count;

            Assert.Equal(0, count);
        }

        [Fact]
        public void AfterPushingItem_CountShouldReturnOne()
        {
            _tColl.Add(Generator.CreateNewEmployee().Base,Generator.CreateNewEmployee());

            var count = _tColl.Count;

            Assert.Equal(1, count);
            Dispose();
        }

        [Fact]
        public void KeysWithoutItems_CountShouldReturnZero()
        {
            

            var count = _tColl.Keys.Count;
            
            Assert.Equal(0,count);
        }
        
        [Fact]
        public void KeysWithOneItem_CountShouldReturnOne()
        {
            _tColl.Add(Generator.CreateNewEmployee().Base,Generator.CreateNewEmployee());
            
            var count = _tColl.Keys.Count;
            
            Assert.Equal(1,count);
            
            Dispose();
        }
        
        
        [Fact]
        public void ValuesWithoutItems_CountShouldReturnZero()
        {
            

            var count = _tColl.Values.Count;
            
            Assert.Equal(0,count);
        }
        
        [Fact]
        public void VakuesWithOneItem_CountShouldReturnOne()
        {
            _tColl.Add(Generator.CreateNewEmployee().Base,Generator.CreateNewEmployee());
            
            var count = _tColl.Values.Count;
            
            Assert.Equal(1,count);
            
            Dispose();
        }
        
        [Fact]
        public void StringsWithoutItems_CountShouldReturnZero()
        {
            

            var count = _tColl.Strings.Count;
            
            Assert.Equal(0,count);
        }
        
        [Fact]
        public void StringsWithOneItem_CountShouldReturnOne()
        {
            _tColl.Add(Generator.CreateNewEmployee().Base,Generator.CreateNewEmployee());
            
            var count = _tColl.Strings.Count;
            
            Assert.Equal(1,count);
            
            Dispose();
        }

        
        [Theory]
        [InlineData(5)]
        [InlineData(256)]
        [InlineData(1000)]
        [InlineData(2000)]
        public void TestCollectionAfterNPushing_CountShouldReturnN(int n)
        {
            
            for (int i = 0; i < n; i++)
            {
                _tColl.Add(new Person(i.ToString(),18,'М'),new Employee());
            }

            

            Assert.Equal(n, _tColl.Count);
            
            Dispose();
        }

        [Theory]
        [InlineData(5)]
        [InlineData(256)]
        [InlineData(1000)]
        [InlineData(2000)]
        public void TestCollectionAfterNPushingAndRemove_CountShouldReturnNMinusOne(int n)
        {
            
            for (int i = 0; i < n; i++)
            {
                _tColl.Add(new Person(i.ToString(),18,'М'),new Employee());
            }

            _tColl.Remove(new Person("1",18,'М'));

            Assert.Equal(n - 1, _tColl.Count);
            
            Dispose();
        }

        [Fact]
        public void RemoveInZeroCollection_ShouldReturnFalse()
        {
            bool res = _tColl.Remove(new Person());
            Assert.False(res);
        }

        [Fact]
        public void RemoveElementWhichNotExist_ShouldReturnFalseAndPrintMsg()
        {
            for (int i = 0; i < 1000; i++)
            {
                _tColl.Add(new Person(i.ToString(),18,'М'),new Employee());
            }

            bool res = _tColl.Remove(Generator.CreateNewEmployee().Base);
            Assert.False(res);
            
            Dispose();
        }


        [Fact]
        public void SearchQueueTKeyElementExist_ShouldReturnTrue()
        {
            for (int i = 0; i < 1000; i++)
            {
                _tColl.Add(new Person(i.ToString(),18,'М'),new Employee());
            }

            Person p = new Person("500", 18, 'М');

            bool res = _tColl.SearchQueue(p);
            
            Assert.True(res);
            Dispose();
        }
        
        [Fact]
        public void SearchQueueTKeyElementDoesNotExist_ShouldReturnFalse()
        {
            for (int i = 0; i < 1000; i++)
            {
                _tColl.Add(new Person(i.ToString(),18,'М'),new Employee());
            }

            Person p = new Person("аааа", 18, 'М');

            bool res = _tColl.SearchQueue(p);
            
            Assert.False(res);
            Dispose();
        }
        
        [Fact]
        public void SearchQueueStringsElementExist_ShouldReturnTrue()
        {
            for (int i = 0; i < 1000; i++)
            {
                _tColl.Add(new Person(i.ToString(),18,'М'),new Employee());
            }

            Person p = new Person("500", 18, 'М');

            bool res = _tColl.SearchQueue(p.ToString());
            
            Assert.True(res);
            Dispose();
        }
        
        [Fact]
        public void SearchQueueStringsElementDoesNotExist_ShouldReturnFalse()
        {
            for (int i = 0; i < 1000; i++)
            {
                _tColl.Add(new Person(i.ToString(),18,'М'),new Employee());
            }

            Person p = new Person("аааа", 18, 'М');

            bool res = _tColl.SearchQueue(p.ToString());
            
            Assert.False(res);
            Dispose();
        }
        
        [Fact]
        public void SearchDictKeyElementExist_ShouldReturnTrue()
        {
            for (int i = 0; i < 1000; i++)
            {
                _tColl.Add(new Person(i.ToString(),18,'М'),new Employee());
            }

            Person p = new Person("500", 18, 'М');

            bool res = _tColl.SearchDictKey(p);
            
            Assert.True(res);
            Dispose();
        }
        
        [Fact]
        public void SearchDictKeyElementDoesNotExist_ShouldReturnFalse()
        {
            for (int i = 0; i < 1000; i++)
            {
                _tColl.Add(new Person(i.ToString(),18,'М'),new Employee());
            }

            Person p = new Person("аааа", 18, 'М');

            bool res = _tColl.SearchDictKey(p);
            
            Assert.False(res);
            Dispose();
        }
        
        [Fact]
        public void SearchDictValueTKeyElementExist_ShouldReturnTrue()
        {
            Employee emp = null;
            for (int i = 0; i < 1000; i++)
            {
                emp = new Employee(i.ToString(), 18, 'М', "Работник");
                _tColl.Add(new Person(),emp);
            }

            

            bool res = _tColl.SearchDictValue(emp);
            
            Assert.True(res);
            Dispose();
        }
        
        [Fact]
        public void SearchDictValueTKeyElementDoesNotExist_ShouldReturnFalse()
        {
           
            for (int i = 0; i < 1000; i++)
            {
                
                _tColl.Add(new Person(),new Employee(i.ToString(), 18, 'М', "Работник"));
            }

            

            bool res = _tColl.SearchDictValue(new Employee());
            
            Assert.False(res);
            Dispose();
        }
        
        [Fact]
        public void SearchDictKeyStringElementExist_ShouldReturnTrue()
        {
            
            for (int i = 0; i < 1000; i++)
            {
                
                _tColl.Add(new Person(i.ToString(), 18, 'М'), new Employee());
            }

            Person p = new Person("500", 18,'М');

            bool res = _tColl.SearchDictKey(p.ToString());
            
            Assert.True(res);
            Dispose();
        }
        
        [Fact]
        public void SearchDictKeyStringElementDoesNotExist_ShouldReturnFalse()
        {
            
            for (int i = 0; i < 1000; i++)
            {
                
                _tColl.Add(new Person(i.ToString(), 18, 'М'), new Employee());
            }

            Person p = new Person("aaaa", 18,'М');

            bool res = _tColl.SearchDictKey(p.ToString());
            
            Assert.False(res);
            Dispose();
        }

        [Fact]
        public void ConstructorTestCollectionsQTValueQTKeyElemCountDoNotMatch_ShouldReturnArgumentException()
        {
            Queue<object> sourceVal = new Queue<object>();
            Queue<object> sourceKey = new Queue<object>();


            for (int i = 0; i < 10; i++)
            {
                sourceKey.Enqueue(new object());
                sourceVal.Enqueue(new object());
            }
            
            sourceKey.Enqueue(new object());

            Action act = () =>
            {
                var v = new TestCollections<object, object>(sourceVal, sourceKey);
            };
            
            Assert.Throws<ArgumentException>(act);

        }
        
        [Fact]
        public void ConstructorTestCollectionsQTValueQTKeyElemCountMatch_ShouldReturnNewMatchInstance()
        {

            TestCollections<Person, Employee> temp = new TestCollections<Person, Employee>();
            
            Queue<Employee> sourceVal = new Queue<Employee>();
            Queue<Person> sourceKey = new Queue<Person>();
            
            for (int i = 0; i < 10; i++)
            {
                sourceKey.Enqueue(new Person(i.ToString(),18,'М'));
                sourceVal.Enqueue(new Employee(i.ToString(),18,'М',"Позиция"));
                
                temp.Add(new Person(i.ToString(),18,'М'), new Employee(i.ToString(),18,'М',"Позиция"));
            }
            
            TestCollections<Person,Employee> tc = new TestCollections<Person,Employee>(sourceVal,sourceKey);
           
            Assert.Equal(temp.Values,tc.Values);
            Assert.Equal(temp.Keys,tc.Keys);
            Assert.Equal(temp.Strings,tc.Strings);
            Assert.Equal(temp.Count,tc.Count);

        }

    }
}