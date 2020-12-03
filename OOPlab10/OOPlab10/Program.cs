using System;

namespace OOPlab10
{
    class Program
    {
        static Random rndGen = new Random();

        static void Main(string[] args)
        {
            Person[] Guys = new Person[3];

            Guys[0] = new Employee();
            Guys[1] = new Administration();
            Guys[2] = new Engineer();


            for(int i = 0; i < 3; i++)
            {
                Guys[i].ShowInfo();
                Console.WriteLine();
            }

            Wait();
            Query1(true);   //вывести мужиков из списка людей
            Wait();
            Query1(false);  //вывести женщин из списка людей
            Wait();
            Query2();       //Вывести количество инженеров на заводе
            Wait();
            Query3();       //Вывести количество инженеров в подразделение    
        }

        static Person[] GenerateExmpls(int length)    //Генератор записей об Персонах
        {
            
            Person[] persArr = new Person[length];

            for(int i = 0; i < persArr.Length; i++)
            {
                bool man = Convert.ToBoolean(rndGen.Next(0,255) % 2);
                char sex = man? 'М': 'Ж';

                switch (rndGen.Next(0,2))
                {
                    case 0:
                        persArr[i] = CreateNewEmployee(man,sex);
                        break;
                    case 1:
                        persArr[i] = CreateNewEngineer(man,sex);
                        break;
                    case 2:
                        persArr[i] = CreateNewAdministration(man,sex);
                        break;
                    default:
                        break;
                }
            }

            return persArr;
        }

        static Employee CreateNewEmployee(bool man, char sex)
        {
            return new Employee(GenerateName(rndGen,man), rndGen.Next(18,55),sex,/*GetRandomCompany(rndGen),*/GetRandomPosition(rndGen));
        }

        static Engineer CreateNewEngineer(bool man, char sex)
        {
            return new Engineer(GenerateName(rndGen,man), rndGen.Next(18,55),sex,/*GetRandomCompany(rndGen),*/"Инженер", GetRandomUniversity(rndGen),rndGen.Next(1,13));
        }

        static Administration CreateNewAdministration(bool man, char sex)
        {
            return new Administration(GenerateName(rndGen,man), rndGen.Next(18,55),sex,/*GetRandomCompany(rndGen),*/"Работник администрации", rndGen.Next(0,5));
        }

        static string GenerateName(Random generator,bool man)    //Генератор имён
        {
            string name = "";
            name += GetRandomFirstName(generator,man) + " ";
            name += GetRandomMiddleName(generator,man) + " ";
            name += GetRandomSecondName(generator,man);

            return name; 
        }

        static string GetRandomFirstName(Random generator, bool man)
        {
            string[] namesMen = {"Алексей","Аарон", "Абрам", "Аваз","Августин","Давид", "Давлат", "Дамир", "Дана","Максим", "Максимилиан", "Максуд", "Мансур" ,"Мар" ,"Марат" ,"Марк" ,"Марсель"};
            string[] namesWomen = {"Ава" ,"Августа", "Августина" ,"Авдотья", "Аврора", "Агапия","Агата" ,"Агафья" ,"Аглая" ,"Агния" ,"Агунда" ,"Ада" ,"Аделаида", "Аделина", "Адель", "Адиля", "Адриана", "Аза", "Азалия", "Азиза" ,"Аида", "Аиша", "Ай", "Айару" ,"Айгерим","Айгуль" ,"Айлин"};

            if(man)
                return namesMen[generator.Next(0,namesMen.Length-1)];
            else
                return namesWomen[generator.Next(0,namesWomen.Length-1)];
        }

        static string GetRandomMiddleName(Random generator, bool man)
        {
            string[] namesMen = {"Алексеевич","Ааронович", "Абрамович", "Авазович","Августинович","Давидович", "Давлатович", "Дамирович", "Данавич","Максимович", "Максимилианович", "Максудович", "Мансурович" ,"Марович" ,"Маратович" ,"Маркович" ,"Марселевич"};
            string[] namesWomen = {"Алексеевна","Аароновна", "Абрамовна", "Авазовна","Августиновна","Давидовна", "Давлатовна", "Дамировна", "Данавна","Максимовна", "Максимилиановна", "Максудовна", "Мансуровна" ,"Маровна" ,"Маратовна" ,"Марковна" ,"Марселевна"};

            if(man)
                return namesMen[generator.Next(0,namesMen.Length-1)];
            else
                return namesWomen[generator.Next(0,namesWomen.Length-1)];
        }

        static string GetRandomSecondName(Random generator, bool man)
        {
            string[] namesMen = {"Смирнов", "Иванов", "Кузнецов", "Соколов", "Попов", "Лебедев", "Козлов", "Новиков", "Морозов", "Петров", "Волков", "Соловьёв","Васильев", "Зайцев", "Павлов", "Семёнов", "Голубев", "Виноградов","Богданов", "Воробьёв", "Фёдоров", "Михайлов", "Беляев", "Тарасов", "Белов"};
            // string[] namesWomen = {"Смирнов", "Иванов", "Кузнецов", "Соколов", "Попов", "Лебедев", "Козлов", "Новиков", "Морозов", "Петров", "Волков", "Соловьёв","Васильев", "Зайцев", "Павлов", "Семёнов", "Голубев", "Виноградов","Богданов", "Воробьёв", "Фёдоров", "Михайлов", "Беляев", "Тарасов", "Белов"};

            if(man)
                return namesMen[generator.Next(0,namesMen.Length-1)];
            else
                return namesMen[generator.Next(0,namesMen.Length-1)] + "а";
        }

        static string GetRandomCompany(Random generator)
        {
            string[] companies = {"ПНИПУ", "Газпрос", "ПГТУ", "Лукойл", "Экойл", "Сбербанк","Банк открытие","Мировой суд","Полиция","Школа"};

            return companies[generator.Next(0,companies.Length)];
        }

        static string GetRandomPosition(Random generator)
        {
           string[] positions = {"Лаборант", "Стажёр", "Начальник", "Специалист", "Помощник", "Архивариус","Уборщик","Сантехник","Механик"};

            return positions[generator.Next(0,positions.Length)];
        }

        static string GetRandomUniversity(Random generator)
        {
            string[] positions = {"ПНИПУ", "ПГТУ", "ПГИК", "ВШЭ", "ИТМО", "СПБГТУ","ИжУОрС","MIT"};

            return positions[generator.Next(0,positions.Length)];
        }
        static void Query1(bool man) //Имена всех лиц мужского (женского) пола.
        {
            Person[] persArr = GenerateExmpls(10);

            ShowExamples(persArr);


            Console.WriteLine(man?"Мужские имена из списка:\n":"Женские имена из списка:\n");
            for(int i =0; i < persArr.Length;i++)
            {
                if(man)
                {
                    if(persArr[i].Sex == 'М')
                    {
                        Console.WriteLine(persArr[i].name);
                    }
                }
                else
                {
                    if(persArr[i].Sex == 'Ж')
                    {
                        Console.WriteLine(persArr[i].name);
                    }
                }
            }
        }

        static void ShowExamples(Person[] persArr)
        {
            Console.WriteLine("Список персон: ");
            for(int i = 0; i < persArr.Length;i++)
            {   
                persArr[i].ShowInfo();
                Console.WriteLine();
            }
        }

        static void Query2()                        //Сколько инженеров на заводе
        {
            Person[] persArr = GenerateExmpls(100);

            ShowExamples(persArr);
            
            Wait();

            int cnt = 0;

            foreach(Person pers in persArr)
            {
                if(pers is Engineer)
                {
                    cnt++;
                }
            }

            Console.WriteLine($"Кол-во инженеров на заводе: {cnt}");
        }

        static void Query3()
        {
            Person[] persArr = GenerateExmpls(255);

            int len = 0;
            foreach(Person pers in persArr)
            {
                if(pers is Engineer)
                {
                    len++;
                }
            }

            Engineer[] engArr = new Engineer[len];
            int i = 0;
            foreach(Person pers in persArr)
            {
                if(pers is Engineer)
                {
                    engArr[i] = pers as Engineer;
                    i++;
                }
            }

            int[] subdArr = {0,0,0,0,0,0,0,0,0,0,0,0,0};

            for(i = 0; i < engArr.Length;i++)
            {
                int index = engArr[i].NumOfSubdivision - 1;
                subdArr[index] += 1;
            }


            ShowExamples(persArr);
            Wait();
            ShowExamples(engArr);
            Wait();
            for(i = 0; i < subdArr.Length; i++)
            {
                Console.Write($"\nКол-во инженеров в подразделение №{i+1} = {subdArr[i]}\n");
            }
            Wait();
        }



        static void Wait()
        {
            Console.WriteLine("Нажмите любую кнопку для продолжения...");
            Console.ReadKey();
        }
    }
}
