using Xunit;
using System;
using System.Collections.Generic;
using OOPlab10;
namespace OOPlab10.TEST
{
    public class ProgramTests
    {
        [Fact]
        public void isNullOrEmptyTEST()
        {
            List<Person> perslist1 = null;
            List<Person> perslist2 = new List<Person>();
            
            List<Person> perslist3 = null;
            Program.GenerateList(out perslist3,10,10,10);

            List<IExecutable> IExecList = null;

            Program.GenerateList(out IExecList,10,10,10);

            Assert.True(Program.IsNullOrEmpty(perslist1));
            Assert.True(Program.IsNullOrEmpty(perslist2));
            Assert.False(Program.IsNullOrEmpty(perslist3));
            Assert.False(Program.IsNullOrEmpty(IExecList));

            Program.PrintIExecutableList();
            Program.Print("Hello world!");
            Program.PrintList(IExecList);
            Program.PrintList(perslist3);

            List<IExecutable> IExecList1 = null;
            Program.PrintList(IExecList1);
            Program.PrintList(perslist1);

        }


        [Fact]
        public void Query1Test()
        {
            Program.Query1(true);
            Program.Query1(false);
        }


        [Fact]
        public void PrintArrOfPersonTest()
        {
            List<Person> persList = null;
            Program.GenerateList(out persList,10,10,10);
            Person[] persArr = persList.ToArray();

            Program.PrintArrOfPerson(persArr);
        }

        [Fact]
        public void PrintArrOfIExecutableTest()
        {
            List<IExecutable> IExecList = null;
            Program.GenerateList(out IExecList,10,10,10);
            IExecutable[] IExecArr = IExecList.ToArray();

            Program.PrintArrOfIExecutable(IExecArr);
        }

        [Fact]
        public void Query2Test()
        {
            Program.Query2();
        }

        [Fact]
        public void Query3Test()
        {
            Program.Query3();
        }
        
        [Fact]
        public void SearchNameTest()
        {
            List<Person> persList = null;
            Program.GenerateList(out persList,10,10,10);

            int k = Program.SearchName(persList,new SortByName(), "Волков");
            Assert.Equal(-1,k);
            k = Program.SearchName(persList,new SortByName(), "Волкова Людмила");
            Assert.Equal(14,k);
        }

        [Fact]
        public void OtherTests()
        {
            Program.SearchExample();
            Program.SortExample();
            Program.CreateIExecutableList();
        }
    }
}