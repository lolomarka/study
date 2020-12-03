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
            Person[] persArr = new Person[3];

            persArr[0] = new Employee();
            persArr[1] = new Engineer();
            persArr[2] = new Administration();

            for (int i = 0; i < 3; i++)
            {
                Assert.Contains("Имя: Шеретов Марк Алексеевич\nВозраст: 19\nПол: М", persArr[i].Info());
            }
        }
    }
    

}