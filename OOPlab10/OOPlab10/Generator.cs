using System;
namespace OOPlab10
{
    public class Generator
    {
        //данные для генерации
        private static string[] surnames = { "Иванов", "Смирнов", "Кузнецов", "Попов", "Васильев", "Петров", "Соколов", "Михайлов", "Новиков", "Федоров", "Морозов", "Волков", "Алексеев", "Лебедев", "Егоров", "Козлов", };
        private static string[] namesMale = { "Иван", "Петр", "Сергей", "Владимир", "Алексей", "Марк", "Максим", "Андрей" };
        private static string[] namesFemale = { "Марина", "Ольга", "Надежда", "Алина", "Александра", "Людмила", "Татьяна", "Полина" };
        private static string[] faculties = { "ЭТФ", "ГНФ", "ГФ", "ФПММ", "СФ", "АКФ" };
        private static string[] positions = { "Рабочий", "Уборщик", "Юрист", "Специалист", "Работник столовой"};

        
        ///...Служебные функции

        public static int RandInt(int bound1, int bound2)
        {
            Random r = new Random();
            return r.Next(bound1,bound2 + 1);
        }
        
        
        /// <summary>
        /// Случайный работник
        /// </summary>
        /// <returns>Возвращает случайного работника(не инженера и не работника администрации)</returns>
        public static Employee CreateNewEmployee()
        {
            char gender = RandInt(1,2) == 1 ? 'М' : 'Ж';
            string name;
            int age;
            string position;

            if(gender == 'Ж')
            {
                name = surnames[RandInt(0, surnames.Length-1)] + "а " + namesFemale[RandInt(0,namesFemale.Length - 1)]; 
            }
            else
            {
                name = surnames[RandInt(0, surnames.Length-1)] + " " + namesMale[RandInt(0,namesMale.Length - 1)]; 
            }
            
            age = RandInt(18,65);

            position = positions[RandInt(0,positions.Length-1)];

            return new Employee(name,age,gender,position);
        }

        public static Engineer CreateNewEngineer()
        {
            char gender = RandInt(1,2) == 1 ? 'М' : 'Ж';
            string name;
            int age;
            string position = "Инженер";
            string university = "ПНИПУ";
            int subdivision;

            if(gender == 'Ж')
            {
                name = surnames[RandInt(0, surnames.Length-1)] + "а " + namesFemale[RandInt(0,namesFemale.Length - 1)]; 
            }
            else
            {
                name = surnames[RandInt(0, surnames.Length-1)] + " " + namesMale[RandInt(0,namesMale.Length - 1)]; 
            }
            
            age = RandInt(18,65);

            

            university += " " + faculties[RandInt(0,faculties.Length-1)];
            subdivision = RandInt(1,16);

            return new Engineer(name,age,gender,position,university,subdivision);
        }

        public static Administration CreateNewAdministration()
        {
            char gender = RandInt(1,2) == 1 ? 'М' : 'Ж';
            string name;
            int age;
            string position = "Работник администрации";
            int numOfDeputy = 1;
            

            if(gender == 'Ж')
            {
                name = surnames[RandInt(0, surnames.Length-1)] + "а " + namesFemale[RandInt(0,namesFemale.Length - 1)]; 
            }
            else
            {
                name = surnames[RandInt(0, surnames.Length-1)] + " " + namesMale[RandInt(0,namesMale.Length - 1)]; 
            }
            
            age = RandInt(18,65);

            position = positions[RandInt(0,positions.Length-1)];

            numOfDeputy = RandInt(0,6);

            return new Administration(name,age,gender,position,numOfDeputy);
        }
       
    }
}