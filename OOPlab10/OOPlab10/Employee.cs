using System;

namespace OOPlab10
{
    public class Employee : Person                 //Рабочий, наследуется от Персоны. 
    {
        // private string company {get; set;}   //Название компании, в которой работает рабочий. 
        private string position{get; set;}   //Позиция, на которой работает рабочий.

        /*Конструкторы*/
        public Employee() 
        {
            // this.company = "ПНИПУ";
            this.position = "Лаборант";
        }

        public Employee(string Name,int Age,char Sex,/*string Company*/ string Position) : base(Name,Age,Sex)   // Перегружаем конструктор для использования конструкторов предка
        {
            // this.company = Company;
            this.position = Position;
        }


        //Методы

        public override string Info()
        {
            string str = base.Info() + $"\nПозиция: {this.position}";
            return str;
        }
    }
}