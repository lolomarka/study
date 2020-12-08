using System.Threading.Tasks;
using System.Xml.Xsl.Runtime;
using System.Security.Cryptography;
using System.Net.Cache;
using System;

namespace OOPlab10
{
    public abstract class Person : IExecutable
    {
        public string name {get; set;}          //Имя персоны
        private int age {get; set;}              //Возраст персоны
        private readonly char sex;               //Пол персоны


    

        /*Конструкторы*/
        public Person()
        {
            this.name = "Шеретов Марк Алексеевич";
            this.age = 19;
            this.sex = 'М';
        }

        public Person(string Name, int Age, char Sex)
        {
            this.name = Name;
            this.age = Age;
            this.Sex = Sex;                     //Доступ через свойство. Для корректной работы фильтра.            
        }

        // свойства

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
        
        public void ShowInfo()          //Вывод информации о персоне
        {
            Console.WriteLine(Info());
        } 

        public virtual string Info()    //Строчка - информация о персоне
        {
            return $"Имя: {this.name}\nВозраст: {this.age}\nПол: {this.sex}";
        }


        public virtual int CompareTo(object o)
        {
            Person tmp = o as Person;
            if(tmp != null)
                return Age.CompareTo(tmp.Age);
            else
                throw new Exception("Ошибка сравнения");
        }

        public virtual object ShallowCopy()
        {
            return MemberwiseClone();
        }

        public virtual object Clone()
        {
            return new Person("Клон " + this.name, Age, Sex);
        }

        public override bool Equals(object obj)
        {
            if((obj == null) || !(GetType().Equals(obj.GetType())))
            {
                return false;
            }
            else
            {
                Person p = (Person) obj;
                return this.name.Equals(p.Surname) && Age == p.Age && Sex == p.Sex;
            }
        }

        public override int GetHashCode()
        {
            return this.name.GetHashCode();
        }
    }
}