using System;
using System.Collections.Generic;
using Xunit;
using OOPLAB11;
using static OOPLAB11.Program;
using OOPlab10;
namespace OOPLAB11TEST
{
    public class ProgramTest
    {
        
        TestCollections<Person, Employee> _tColl;

        public ProgramTest()
        {
            _tColl = new TestCollections<Person, Employee>();
        }

        internal void Dispose()
        {
            _tColl.Dispose();
        }
        
        [Fact]
        public void CreateCollCountTest()
        {
            int n = 1000;
            
            CreateColl(ref _tColl, n);
            
            Assert.Equal(n,_tColl.Count);
            
            Dispose();
        }


        [Theory]
        [InlineData(0)]
        [InlineData(16)]
        public void AddElemCountTest_CountMustMatch(int n)
        {
            TestCollections<Person, Employee> tc = null;    //Для увеличения покрытия
            AddElem(ref tc);
            
            
            for (int i = 0; i < n; i++)
            {
               AddElem(ref _tColl);
            }
            
            Assert.Equal(n,_tColl.Count);
            
            Dispose();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(100)]
        public void DelElemCountTest_CountMustBeNMinusOne(int n)
        {
            TestCollections<Person,Employee> tc = null;
            DelElem(ref tc);
            
            
            CreateColl(ref _tColl,n);
            
            DelElem(ref _tColl);
            
            Assert.Equal(n-1,_tColl.Count);
            
            Dispose();
        }

        [Fact]
        public void TestSearch_ReturnTrueOrFalse()
        {
            Assert.False(TestSearch(null,50));              //False, если коллекция не существует
            
            CreateColl(ref _tColl,1000);

            Assert.True(TestSearch(_tColl, -1));
            Assert.True(TestSearch(_tColl, 0));
            Assert.True(TestSearch(_tColl, 500));
            Assert.True(TestSearch(_tColl,999));
            
            Assert.Throws<NullReferenceException>(() => TestSearch(_tColl,10001));
            
            Dispose();
        }
    }
}