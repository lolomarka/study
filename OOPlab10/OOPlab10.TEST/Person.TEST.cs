using Xunit;
using Xunit.Abstractions;
using System;
using System.IO;
using System.Diagnostics;
using OOPlab10;
using System.Text;

namespace OOPlab10.TEST
{
    
    public  class PersonTest
    {
        private Person[] person {get;set;}


        [Fact]
        public void InfoTest()
        {
            Person pers = new Person();
            Assert.Equal("Имя: Шеретов Марк Алексеевич\nВозраст: 19\nПол: М", pers.Info());
        }

        [Fact]
        public void Constructors()
        {
        //Given
            Person personWithoutP = new Person();
            Person personWithP = new Person("Шеретов Марк Алексеевич",19,'М');

            Assert.Equal(personWithoutP,personWithP);
        }

        [Fact]
        public void NameTest()
        {
            Person person = new Person();
            string expectName = "Шарифулин Вадим Абубакирович";
            person.Name = expectName;

            Assert.Equal(expectName,person.Name);
        }

        [Theory]
        [InlineData (-256)]
        [InlineData (125)]
        [InlineData (0)]
        public void AgeTest(int expAge)
        {
            Person p = new Person();
            p.Age = expAge;

            if(expAge < 1)
                Assert.Equal(1,p.Age);
            else
                Assert.Equal(expAge,p.Age);   
        }




    }
    

}