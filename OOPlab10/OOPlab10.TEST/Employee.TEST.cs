using System.Linq.Expressions;
using Xunit;
using Xunit.Abstractions;
using System;
using System.IO;
using System.Diagnostics;
using OOPlab10;
using System.Text;

namespace OOPlab10.TEST
{
    public class EmployeeTest
    {
        [Fact]
        public void Constructors()
        {
        
            Employee employeeWithoutP = new Employee();
            Employee employeeWithP = new Employee("Шеретов Марк Алексеевич",19,'М',"Лаборант");
            
            Assert.Equal(employeeWithoutP,employeeWithP);
            Assert.Equal(new Employee().GetHashCode(),employeeWithoutP.GetHashCode());
            Assert.Equal(new Employee("Шеретов Марк Алексеевич",19,'М',"Лаборант").GetHashCode(),employeeWithP.GetHashCode());
        }
        [Fact]
        public void PositionTest()
        {
            Employee emp = new Employee();

            string postExp = "Уборщик";

            emp.Position = postExp;

            Assert.Equal(postExp,emp.Position);  
        }

        [Fact]
        public void InfoTest()
        {
            Employee emp = new Employee();
            Assert.Equal("Имя: Шеретов Марк Алексеевич\nВозраст: 19\nПол: М\nПозиция: Лаборант", emp.Info());
        }
        [Fact]
        public void Info_No_Virt_Test()
        {
            Employee emp = new Employee();
            Assert.Equal("Имя: Шеретов Марк Алексеевич\nВозраст: 19\nПол: М", emp.Info_No_Virt());
        }

        [Fact]
        public void ShallowCopyTest()
        {
            Employee emp = new Employee("Шагиахметов Сергей Артурович",25,'M',"Стажёр");
            
            Employee empCopy = (Employee) emp.ShallowCopy();

            Assert.Equal(emp,empCopy);
        }

        [Fact]
        public void CloneTest()
        {
            Employee emp = new Employee("Шагиахметов Сергей Артурович",25,'M',"Стажёр");

            Employee clone = (Employee)emp.Clone();

            emp.Name = "Клон " + emp.Name;

            Assert.Equal(emp,clone);
        }

        [Fact]
        public void EqualsTest()
        {
            Employee emp = new Employee();
            Employee empExp = new Employee("Шеретов Марк Алексеевич", 19, 'М', "Лаборант");

            Assert.True(empExp.Equals(emp));
            emp.Age = 35;
            Assert.False(empExp.Equals(emp));

            Assert.False(empExp.Equals(null));
        }

    }
}