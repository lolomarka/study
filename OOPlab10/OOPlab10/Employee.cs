using System;

namespace OOPlab10
{
    /// <summary>
    /// Дочерний класс персоны - Работник.
    /// </summary>
    public class Employee : Person                 //Рабочий, наследуется от Персоны. 
    {
        // private string company {get; set;}   //Название компании, в которой работает рабочий. 
        private string position;   //Позиция, на которой работает рабочий.

        /*Конструкторы*/
        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public Employee() : base()
        {
            // this.company = "ПНИПУ";
            this.position = "Лаборант";
        }


        /// <summary>
        /// Конструткор с параметрами
        /// </summary>
        /// <param name="Name">ФИО</param>
        /// <param name="Age">Возраст</param>
        /// <param name="Sex">Пол</param>
        /// <param name="Position">Позиция</param>
        /// <returns>ничего</returns>
        public Employee(string Name,int Age,char Sex, string Position) : base(Name,Age,Sex)   //Перегружаем конструктор для использования конструкторов предка
        {
            this.Position = Position;
        }

        //Свойства
        public string Position
        {
            get{ return this.position;}
            set{ this.position = value;}
        }

        public Person Base
        {
            get
            {
                return new Person(Name,Age,Sex);
            }
        }

        //Методы
        /// <summary>
        /// Генерирует строку с информацией об объекте
        /// </summary>
        /// <returns>Строка с инфо</returns>
        public override string Info()
        {
            string str = base.Info() + $"\nПозиция: {this.position}";
            return str;
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
        /// Полная копия объекта.
        /// </summary>
        /// <returns>Новый объект - полная копия этого объекта</returns>
        public override object Clone()
        {
            return new Employee("Клон " + this.Name,this.Age,this.Sex,this.position);
        }

        /// <summary>
        /// Сравнение объектов
        /// </summary>
        /// <param name="obj">объект для сравнения</param>
        /// <returns>true - одинаковы, false - неодинаковы</returns>
        public override bool Equals(object obj)
        {
            if((obj == null) || !(GetType().Equals(obj.GetType())))
            {
                return false;
            }
            else
            {
                Employee e = (Employee)obj;

                return this.Name.Equals(e.Name) && Age == e.Age
                && Sex == e.Sex && position.Equals(e.position);
            }
        }

        /// <summary>
        /// Получение хэшкода для объекта
        /// </summary>
        /// <returns>int - хэш-код объекта</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode() ^ position.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString() + $", {Position}";
        }

        // public override int CompareTo(object o)
        // {
        //     
        //     //Employee tmp = o as Employee;
        //     if (o is Employee tmp)
        //     {
        //         if (String.Compare(Name, tmp.Name, StringComparison.Ordinal) != 0)
        //             return String.Compare(Name, tmp.Name, StringComparison.Ordinal);
        //         if (Age.CompareTo(tmp.Age) != 0)
        //             return Age.CompareTo(tmp.Age);
        //         if (Sex.CompareTo(tmp.Sex) != 0)
        //             return Sex.CompareTo(tmp.Sex);
        //         if (String.Compare(position, tmp.position, StringComparison.Ordinal) != 0)
        //             return String.Compare(position, tmp.position, StringComparison.Ordinal);
        //     }
        //     else
        //        throw new ArgumentException();
        //
        //     return 0;
        // }
    }
}