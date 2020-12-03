using System;

namespace OOPlab10
{
    public class Engineer : Employee
    {
        private string university {get;set;}            //ВУЗ, который окончил инженер
        private int numOfSubdivision {get;set;}         //Номер подразделения

        /*Конструкторы*/
        public Engineer()
        {
            this.university = "ПНИПУ";
        }

        public Engineer(string Name, int Age, char Sex,/* string Company,*/ string Position, string University, int Subdivision) :base(Name,Age,Sex,/*Company,*/Position)
        {
            this.university = University;
            this.numOfSubdivision = Subdivision;
        }

        //Методы
        public override string Info()
        {
            string str = base.Info() + $"\nОкончил: {this.university}\nНомер подразделения: {this.numOfSubdivision}";
            return str;
        }

        public int NumOfSubdivision
        {
            get{ return this.numOfSubdivision;}
            set{ this.numOfSubdivision = value;}
        }
        
        
    }
}