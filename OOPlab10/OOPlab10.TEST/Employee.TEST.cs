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


    }
}