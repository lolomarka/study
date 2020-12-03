using System;

namespace OOPlab10
{
    public class Administration : Employee
    {
        private int numOfDeputy {get;set;}      //Количество заместителей


        /*Конструкторы*/

        public Administration ()
        {
            this.numOfDeputy = 1;
        }

        public Administration (string Name,int Age,char Sex,/*string Company,*/ string Position, int NumOfDeputy) :base (Name,Age,Sex,/*Company,*/Position)
        {
            this.numOfDeputy = NumOfDeputy;
        }

        //Методы
        
        public override string Info()
        {
            string str = base.Info() + $"\nКол-во заместителей: {this.numOfDeputy}";
            return str;
        }
    }
}