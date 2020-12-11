using Xunit;
using System;
using OOPlab10;
namespace OOPlab10.TEST
{
    public class AdministrationTests
    {
        [Fact]
        public void Constructors()
        {
            Administration admWithoutP = new Administration();
            Administration admWithP = new Administration("Шеретов Марк Алексеевич",19,'М',"Работник администрации",1);
            
            Assert.Equal(admWithoutP,admWithP);
            Assert.Equal(new Administration().GetHashCode(),admWithoutP.GetHashCode());
            Assert.Equal(new Administration("Шеретов Марк Алексеевич",19,'М',"Работник администрации",1).GetHashCode(),admWithP.GetHashCode());
        }
        
        [Theory]
        [InlineData(-5)]
        [InlineData(0)]
        [InlineData(5)]
        public void NumOfDeputy(int num)
        {
            Administration adm = new Administration();
            adm.NumOfDeputy = num;
            Assert.Equal(Math.Abs(num),adm.NumOfDeputy);
        }

        [Fact]
        public void InfoTest()
        {
            Administration adm = new Administration();
            Assert.Equal("Имя: Шеретов Марк Алексеевич\nВозраст: 19\nПол: М\nПозиция: Работник администрации\nКол-во заместителей: 1", adm.Info());
        }

        [Fact]
        public void CompareToTest()
        {
            object o = null;
            Administration admExp = new Administration();

            Assert.Throws<ArgumentException>(()=> admExp.CompareTo(o));
        }

        [Fact]
        public void ShallowCopyTest()
        {
            Administration adm = new Administration("Шагиахметов Сергей Артурович",25,'M',"Работник администрации",1);
            
            Administration admCopy = (Administration) adm.ShallowCopy();

            Assert.Equal(adm,admCopy);
        }

        [Fact]
        public void CloneTest()
        {
            Administration adm = new Administration("Абубакир Абубакирович Намазов", 25, 'М',"Работник администрации", 1);

            Administration clone = (Administration)adm.Clone();

            adm.Name = "Клон " + adm.Name;

            Assert.Equal(adm,clone);
        }

        [Fact]
        public void EqualsTest()
        {
            Administration adm = new Administration();
            Administration admExp = new Administration("Шеретов Марк Алексеевич",19,'М',"Работник администрации",1);

            Assert.True(admExp.Equals(adm));
            adm.Age = 35;
            Assert.False(admExp.Equals(adm));

            Assert.False(admExp.Equals(null));
        }
    
    }
}