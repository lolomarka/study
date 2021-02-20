using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;
using OOPLAB11;
using OOPlab10;
    
namespace OOPLAB11TEST
{
    public class TestCollection_TEST
    {
        [Fact]
        public void ConstructorTest()
        {
            var tc = new TestCollections<object, object>();
            
            Assert.NotNull(tc);
        }

        [Theory]
        [InlineData(int.MinValue)]
        [InlineData(int.MaxValue)]
        [InlineData(null)]
        [InlineData(0)]
        public void CountGetterTest(int value)
        {
            if (value == null)
            {
                Assert.Null(value);
            }
            else
            {
                var obj = new TestCollections<object, object>();
                
                Assert.IsType(typeof(int),value);
                Assert.InRange(obj.Count,Int32.MinValue, Int32.MaxValue);
            }
        }

        // [Fact]
        // public void CountSetterTest()
        // {
        //     var a = new TestCollections<object, object>();
        //     a.Add(new object(),new object());
        //     Assert.Equal(a.Count, 1);
        //     a.Add(new Person(),new object());
        //     Assert.Equal(a.Count, 2);
        // }

        [Fact]
        public void ConstructorParamTest()
        {
            var tc = new TestCollections<object, object>(new Queue<object>(), new Queue<object>());
            Assert.NotNull(tc);

            var q = new Queue<object>();
            q.Enqueue(new object());
            Assert.Throws<ArgumentException>(() => new TestCollections<object, object>(q, new Queue<object>()));
        }
        
    }
}