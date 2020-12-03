using System;

namespace OOPlab10
{
    public abstract class Person
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

        //Методы
        
        public void ShowInfo()          //Вывод информации о персоне
        {
            Console.WriteLine(Info());
        } 

        public virtual string Info()    //Строчка - информация о персоне
        {
            return $"Имя: {this.name}\nВозраст: {this.age}\nПол: {this.sex}";
        }

    }
}