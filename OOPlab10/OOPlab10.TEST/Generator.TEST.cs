using Xunit;
using System;
using OOPlab10;
namespace OOPlab10.TEST
{
    public class GeneratorTests
    {
        

        [Theory]
        [InlineData(0,20)]
        [InlineData(10,10)]
        [InlineData(5,4)]
        public void RandIntTest(int bound1, int bound2)
        {
            Assert.Equal(new Random(0).Next(bound1,bound2+1),Generator.RandInt(bound1,bound2));
        }

        [Fact]
        public void CreateNewEmployeeTest()
        {

            Employee emp = new Employee("Волкова Людмила", 52, 'Ж',"Специалист");
            Assert.Equal(emp, Generator.CreateNewEmployee());           
        }

        [Fact]
        public void CreateNewEngineerTest()
        {
            Engineer eng = new Engineer("Волкова Людмила", 52, 'Ж',"Инженер", "ПНИПУ АКФ",1);
            Assert.Equal(eng, Generator.CreateNewEngineer());
        }

        [Fact]
        public void CreateNewAdministrationTest()
        {
            Administration adm = new Administration("Волкова Людмила", 52, 'Ж',"Работник администрации", 5);
            Assert.Equal(adm, Generator.CreateNewAdministration());
        }


    }
}