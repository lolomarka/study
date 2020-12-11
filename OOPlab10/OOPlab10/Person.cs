using System.Threading.Tasks;
using System.Xml.Xsl;
using System.Security.Cryptography;
using System.Net.Cache;
using System;

namespace OOPlab10
{
    /// <summary>
    /// Класс - персона
    /// </summary>
    public class Person : IExecutable
    {
        private string name {get; set;}          //Имя персоны
        private int age {get; set;}              //Возраст персоны
        private readonly char sex;               //Пол персоны




        /*Конструкторы*/

        /// <summary>
        /// Пустой конструктор. Устанавливаются значения "по умолчанию"
        /// </summary>
        public Person()
        {
            Name = "Шеретов Марк Алексеевич";
            Age = 19;
            Sex = 'М';
        }

        /// <summary>
        /// Конструктор с параметрами. 
        /// </summary>
        /// <param name="Name">Имя персоны.</param>
        /// <param name="Age">Возраст персоны.</param>
        /// <param name="Sex">Пол персоны(Мужской/Женский)</param>
        public Person(string Name, int Age, char Sex)
        {
            this.name = Name;
            this.age = Age;
            this.Sex = Sex;                     //Доступ через свойство. Для корректной работы фильтра.            
        }

        // свойства
        
        public string Name{get{return this.name;} set{ this.name = value;}}

        /// <summary>
        /// свойство:  Пол персоны. На вход принимает литерал - "М" в любой форме, или "W"/"Ж" в любой форме. Если вводится другое, то заменяется на "-" 
        /// </summary>
        /// <value>Литерал</value>
        public char Sex 
        {
            get {return this.sex;}
            
            init                            //Ввод возможен только во время инициализации.
            {
                if(value == 'M' || value == 'm' || value == 'М' || value == 'м')
                    this.sex = 'М';
                else if(value == 'W' || value == 'w' || value == 'Ж' || value == 'ж')
                    this.sex = 'Ж';
                else
                    this.sex = '-';
            }    
        }

        /// <summary>
        /// свойство: Возраст персоны. На вход - целое число. Если возраст указан < 1, то в консоль выводится сообщение об ошибке
        /// </summary>
        /// <value>Целое число - возраст</value>
        public int Age 
        {
            get {return age;}
            set 
            {
                if(value < 1)
                {
                    Console.WriteLine($"Попытка присвоить возраст: {value}, Присвоено значение - 1.");
                    age = 1;                    
                }
                else
                {
                    age = value;
                }
            }
        }

        //Методы
        /// <summary>
        /// Выводит в консоль строку, сформированную виртуальным методом Info
        /// </summary>
        public void ShowInfo()          //Вывод информации о персоне
        {
            Console.WriteLine(Info());
        } 

        /// <summary>
        /// Выводит в консоль строку, сформированную невиртуальным методом Info_No_Virt
        /// </summary>
        public void ShowInfo_No_Virt()
        {
            Console.WriteLine(Info_No_Virt());
        }

        /// <summary>
        /// Формирует строку, содержащию информацию об экземпляре класса Person
        /// </summary>
        /// <returns>Строка с информацией об экземпляре класса</returns>
        public virtual string Info()    //Строчка - информация о персоне
        {
            return $"Имя: {this.name}\nВозраст: {this.age}\nПол: {this.sex}";
        }


        public string Info_No_Virt()
        {
            return $"Имя: {this.name}\nВозраст: {this.age}\nПол: {this.sex}";
        }

        /// <summary>
        /// Сравнение по возрасту
        /// </summary>
        /// <param name="o">объект для сравнения</param>
        /// <returns>int - возраст, или пробрассывается ошибка(если object == null)</returns>
        public virtual int CompareTo(object o)
        {
            Person tmp = o as Person;
            if(tmp != null)
                return Age.CompareTo(tmp.Age);
            else
                throw new ArgumentException();
        }


        /// <summary>
        /// Поверхностное копирование
        /// </summary>
        /// <returns>Неполная копия объекта</returns>
        public virtual object ShallowCopy()
        {
            return MemberwiseClone();
        }


        /// <summary>
        /// Создаёт клон объекта
        /// </summary>
        /// <returns>Полная копия объекта, в строчке name в начале добавлено: "Клон "</returns>
        public virtual object Clone()
        {
            return new Person("Клон " + this.name, Age, Sex);
        }


        /// <summary>
        /// Сравнение объектов.
        /// </summary>
        /// <param name="obj">Объект для сравнения с этим инстансом</param>
        /// <returns>true - если совпадает/false, если не совпадает.</returns>
        public override bool Equals(object obj)
        {
            if((obj == null) || !(GetType().Equals(obj.GetType())))
            {
                return false;
            }
            else
            {
                Person p = (Person) obj;
                return this.name.Equals(p.name) && Age == p.Age && Sex == p.Sex;
            }
        }

        /// <summary>
        /// Возвращает HashCode объекта
        /// </summary>
        /// <returns>int - хэш-код инстанса.</returns>
        public override int GetHashCode()
        {
            return this.name.GetHashCode() ^ Age ^ Sex;
        }
    }
}