using System;

namespace OOPlab10
{

    /// <summary>
    /// Дочерний класс Работника - Инженер.
    /// </summary>
    public class Engineer : Employee
    {
        private string university {get;set;}            //ВУЗ, который окончил инженер
        private int numOfSubdivision {get;set;}         //Номер подразделения

        /*Конструкторы*/

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        /// <returns>Шаблонный инстанс</returns>
        public Engineer() : base()
        {
            this.university = "ПНИПУ";
            this.numOfSubdivision = 1;
        }


        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="Name">ФИО</param>
        /// <param name="Age">Возраст</param>
        /// <param name="Sex">Пол</param>
        /// <param name="Position">Позиция в компании</param>
        /// <param name="University">Университет, который окончил инженер</param>
        /// <param name="Subdivision">Номер подразделения, в котором работает инженер</param>
        /// <returns>Инстанс с заданными параметрами</returns>
        public Engineer(string Name, int Age, char Sex, string Position, string University, int Subdivision) :base(Name,Age,Sex,Position)
        {
            this.university = University;
            this.numOfSubdivision = Subdivision;
        }

        //Свойства
        /// <summary>
        ///  Номер подразделения
        /// </summary>
        /// <value>Число, запишется абсолютное значение</value>
        public int NumOfSubdivision
        {
            get{ return this.numOfSubdivision;}
            set{ this.numOfSubdivision = Math.Abs(value);}
        }


        //Методы
        /// <summary>
        /// Генерация строки с информацией об объекте
        /// </summary>
        /// <returns>Строка с информацией об объекте</returns>
        public override string Info()
        {
            string str = base.Info() + $"\nОкончил: {this.university}\nНомер подразделения: {this.numOfSubdivision}";
            return str;
        }

        
        /// <summary>
        ///  Сравнение по возрасту
        /// </summary>
        /// <param name="o">Объект для сравнения</param>
        /// <returns></returns>
        public override int CompareTo(object o)
        {
            Engineer engineer = o as Engineer;
            if(engineer != null)
                return Age.CompareTo(engineer.Age);
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
            return new Engineer("Клон " + this.Name, this.Age, this.Sex, this.Position,this.university,this.numOfSubdivision);
        }


        /// <summary>
        /// Сравнение объектов
        /// </summary>
        /// <param name="obj">Объект для сравнения</param>
        /// <returns>true - если совпадает/false, если не совпадает</returns>
        public override bool Equals(object obj)
        {
            if((obj == null) || !(GetType().Equals(obj.GetType())))
            {
                return false;
            }
            else
            {
                Engineer engineer = (Engineer) obj;
                return this.Name.Equals(engineer.Name) && Age == engineer.Age &&
                Sex == engineer.Sex && Position.Equals(engineer.Position) &&
                university.Equals(engineer.university) && numOfSubdivision == engineer.numOfSubdivision;
            }
        }

        /// <summary>
        /// Возвращает HashCode объекта
        /// </summary>
        /// <returns>int - хэш-код объекта</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode() ^ this.university.GetHashCode() ^ numOfSubdivision;
        }
    }
}