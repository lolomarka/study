using System;

namespace OOPlab10
{
    public class Administration : Employee
    {
        private int numOfDeputy;      //Количество заместителей


        /*Конструкторы*/

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        /// <returns></returns>
        public Administration () : base()
        {
            this.numOfDeputy = 1;
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="Name">Имя</param>
        /// <param name="Age">Возраст</param>
        /// <param name="Sex">Пол</param>
        /// <param name="Position">Позиция, занимаемая в компании</param>
        /// <param name="NumOfDeputy">Количество заместителей</param>
        /// <returns></returns>
        public Administration (string Name,int Age,char Sex, string Position, int NumOfDeputy) :base (Name,Age,Sex, Position)
        {
            this.numOfDeputy = NumOfDeputy;
        }

        //Свойства

        /// <summary>
        /// Публичное свойства для поля класса numOfDeputy
        /// </summary>
        /// <value>Количество заместителей работника админестрации(Запишется по модулю)</value>
        public int NumOfDeputy
        {
            get { return this.numOfDeputy;}
            set { this.numOfDeputy = Math.Abs(value);}
        }

        //Методы
        
        /// <summary>
        /// Построение строки с информацией об объекте
        /// </summary>
        /// <returns>Строка с информацией об объекте</returns>
        public override string Info()
        {
            string str = base.Info() + $"\nКол-во заместителей: {this.numOfDeputy}";
            return str;
        }

        public override int CompareTo(object o)
        {
            Administration administration = o as Administration;
            if(administration != null)
                return Age.CompareTo(administration.Age);
            else
                throw new Exception("Ошибка сравнения");
        }

        /// <summary>
        /// Поверхностное копирование
        /// </summary>
        /// <returns>Неполная копия объекта</returns>
        public override object ShallowCopy()
        {
            return MemberwiseClone();
        }


        /// <summary>
        /// Создание полной копии объекта
        /// </summary>
        /// <returns>Полная копия объекта</returns>
        public override object Clone()
        {
            return new Administration("Клон " + this.Name, this.Age, this.Sex, this.Position, this.NumOfDeputy);
        }

        
        /// <summary>
        /// Сравнение объектов
        /// </summary>
        /// <param name="obj">Объект для сравнения</param>
        /// <returns>true - если совпадает / false, если не совпадает</returns>
        public override bool Equals(object obj)
        {
            if((obj == null) || !(GetType().Equals(obj.GetType())))
                return false;
            else
            {
                Administration administration = (Administration) obj;
                return this.Name.Equals(administration.Name) && Age == administration.Age && 
                Sex == administration.Sex && Position.Equals(administration.Position) &&
                numOfDeputy == administration.numOfDeputy;
            }
        }

        /// <summary>
        /// Генерация HashCode объекта
        /// </summary>
        /// <returns>Хэш-код объекта</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode() ^ numOfDeputy;
        }











        
    }
}