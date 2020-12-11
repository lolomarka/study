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
        


        [Fact]
        public void InfoTest()
        {
            Person pers = new Person();
            Assert.Equal("Имя: Шеретов Марк Алексеевич\nВозраст: 19\nПол: М", pers.Info());
        }
        [Fact]
        public void Info_No_Virt_Test()
        {
            Person pers = new Person();
            Assert.Equal("Имя: Шеретов Марк Алексеевич\nВозраст: 19\nПол: М", pers.Info_No_Virt());
        }


        [Fact]
        public void ShowInfoTest()
        {
        //Given
            Person p = null;
            new Person().ShowInfo();
        //Then
            Assert.Throws<NullReferenceException>(() => p.ShowInfo());
        }

        [Fact]
        public void ShowInfo_No_Virt_Test()
        {
            //Given
            Person p = null;
            new Person().ShowInfo_No_Virt();
            //Then
            Assert.Throws<NullReferenceException>(() => p.ShowInfo_No_Virt());
        }

        [Fact]
        public void Constructors()
        {
        //Given
            Person personWithoutP = new Person();
            Person personWithP = new Person("Шеретов Марк Алексеевич",19,'М');
            
            Assert.Equal(personWithoutP,personWithP);
            Assert.Equal(new Person().GetHashCode(),personWithoutP.GetHashCode());
            Assert.Equal(new Person("Шеретов Марк Алексеевич",19,'М').GetHashCode(),personWithP.GetHashCode());
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


        [Theory]
        [InlineData('м')]
        [InlineData('М')]
        [InlineData('M')]
        [InlineData('m')]
        [InlineData('W')]
        [InlineData('w')]
        [InlineData('Ж')]
        [InlineData('ж')]
        [InlineData('a')]
        public void SexTest(char expSex)
        {
            Person p = new Person("AASSA",19,expSex);

             if(expSex == 'M' || expSex == 'm' || expSex == 'М' || expSex == 'м')
                    Assert.Equal('М', p.Sex);
                else if(expSex == 'W' || expSex == 'w' || expSex == 'Ж' || expSex == 'ж')
                    Assert.Equal('Ж', p.Sex);
                else
                    Assert.Equal('-', p.Sex);
        }

        [Fact]
        public void CompareToTest()
        {
            object o = null;
            Person pExp = new Person();

            Assert.Throws<ArgumentException>(() => pExp.CompareTo(o));
        }

        [Fact]
        public void ShallowCopyTest()
        {
            Person p = new Person("Абубакир Абубакирович Намазов", 25, 'М');

            Person pCopy = (Person) p.ShallowCopy();

            Assert.Equal(p,pCopy);    
        }

        [Fact]
        public void CloneTest()
        {
            Person p = new Person("Абубакир Абубакирович Намазов", 25, 'М');

            Person clone = (Person)p.Clone();

            p.Name = "Клон " + p.Name;

            Assert.Equal(p,clone);
        }

        [Fact]
        public void EqualsTest()
        {
            Person p = new Person();
            Person pExp = new Person("Шеретов Марк Алексеевич",19,'М');

            Assert.True(pExp.Equals(p));

            p.Age = 35;
            Assert.False(pExp.Equals(p));
            
            Assert.False(pExp.Equals(null));
        }
    }
    

}