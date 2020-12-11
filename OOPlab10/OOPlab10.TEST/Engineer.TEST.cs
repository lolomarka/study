using Xunit;
using System;
using OOPlab10;
namespace OOPlab10.TEST
{
    public class EngineerTests
    {
        [Fact]
        public void Constructors()
        {
            Engineer engineerWithoutP = new Engineer();
            Engineer engineerWithP = new Engineer("Шеретов Марк Алексеевич",19,'М',"Инженер","ПНИПУ",1);
            
            Assert.Equal(engineerWithoutP,engineerWithP);
            Assert.Equal(new Engineer().GetHashCode(),engineerWithoutP.GetHashCode());
            Assert.Equal(new Engineer("Шеретов Марк Алексеевич",19,'М',"Инженер","ПНИПУ", 1).GetHashCode(),engineerWithP.GetHashCode());
        }
        
        [Theory]
        [InlineData(-5)]
        [InlineData(0)]
        [InlineData(5)]
        public void NumOfSubdivision(int num)
        {
            Engineer eng = new Engineer();
            eng.NumOfSubdivision = num;
            if(num != 0)
                Assert.Equal(Math.Abs(num),eng.NumOfSubdivision);
            else
                Assert.Equal(1, eng.NumOfSubdivision);
        }

        [Fact]
        public void InfoTest()
        {
            Engineer eng = new Engineer();
            Assert.Equal("Имя: Шеретов Марк Алексеевич\nВозраст: 19\nПол: М\nПозиция: Инженер\nОкончил: ПНИПУ\nНомер подразделения: 1", eng.Info());
        }

        [Fact]
        public void CompareToTest()
        {
            object o = null;
            Engineer engExp = new Engineer();

            Assert.Throws<ArgumentException>(()=> engExp.CompareTo(o));
        }

        [Fact]
        public void ShallowCopyTest()
        {
            Engineer eng = new Engineer("Шагиахметов Сергей Артурович",25,'M',"Инженер","ПНИПУ",1);
            
            Engineer engCopy = (Engineer) eng.ShallowCopy();

            Assert.Equal(eng,engCopy);
        }

        [Fact]
        public void CloneTest()
        {
            Engineer eng = new Engineer("Абубакир Абубакирович Намазов", 25, 'М',"Инженер","ПНИПУ", 1);

            Engineer clone = (Engineer)eng.Clone();

            eng.Name = "Клон " + eng.Name;

            Assert.Equal(eng,clone);
        }

        [Fact]
        public void EqualsTest()
        {
            Engineer eng = new Engineer();
            Engineer engExp = new Engineer("Шеретов Марк Алексеевич", 19, 'М', "Инженер","ПНИПУ",1);

            Assert.True(engExp.Equals(eng));
            eng.Age = 35;
            Assert.False(engExp.Equals(eng));

            Assert.False(engExp.Equals(null));
        }
    }
}