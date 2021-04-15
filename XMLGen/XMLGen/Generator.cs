using System.Collections.Generic;
using System;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace XMLGenerator
{
    public class Generator
    {
        private XmlDocument _xDocNames = new XmlDocument();
        private XmlElement _xRootNames { get; set; }

        private XmlDocument _xDocSurnames = new XmlDocument();
        private XmlElement _xRootSurnames { get; set; }

        private List<Person> _persons = new List<Person>();

        public Generator()
        {
            _xDocNames.Load(Path.GetFullPath(@".\xmlDatabases\russian_names.xml"));          //Файлик с именами. 
            _xRootNames = _xDocNames.DocumentElement;                           //Мужские имена также будем использовать для генерации отчеств

            _xDocSurnames.Load(Path.GetFullPath(@".\xmlDatabases\russian_surnames.xml"));
            _xRootSurnames = _xDocSurnames.DocumentElement;
        }

        //public void Print()
        //{
        //    foreach (XmlNode xNode in _xRootNames)
        //    {

        //        foreach (XmlNode childNode in xNode.ChildNodes)
        //        {
        //            foreach (XmlNode childchildNode in childNode.ChildNodes)
        //            {
        //                foreach (XmlNode chchchNode in childchildNode.ChildNodes)
        //                {
        //                    if (chchchNode.Name == "Name")
        //                    {
        //                        Console.Write($"Имя: {chchchNode.InnerText}\t");

        //                    }
        //                    if (chchchNode.Name == "Sex")
        //                    {
        //                        Console.WriteLine($"Пол: {chchchNode.InnerText}");
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}

        public void MakeFile()
        {
            string path = Path.GetFullPath(@"..\Persons.xml");

            XDocument xdoc = new XDocument();

            XElement persons = new XElement("Persons");

            var list = GenerateList();

            foreach (var p in list)
            {
                XElement person = new XElement("Person");
                XAttribute name = new XAttribute("Name", p.Name);
                XAttribute surname = new XAttribute("Surname", p.Surname);
                XAttribute middleName = new XAttribute("MiddleName", p.MiddleName);
                XAttribute age = new XAttribute("Age", p.Age.ToString());

                person.Add(name);
                person.Add(surname);
                person.Add(middleName);
                person.Add(age);

                persons.Add(person);
            }

            xdoc.Add(persons);

            try
            {
                xdoc.Save(path);
            }
            catch
            {
                File.Delete(path);
                xdoc.Save(path);
            }
        }

        private List<Person> GenerateList()
        {
            Random rnd = new Random();
            List<Person> personsbuff = new List<Person>();

            var names = ExtractNames();

            var maleNames = getOnlyMale();
            var femaleNames = getOnlyFemale();

            var surnames = ExtractSurnames();
            var middleNames = MakeMiddleNames();



            foreach (var item in middleNames)
            {
                string name = "Марк";
                string middleName = "Алексеевич";
                string surname = "Шеретов";

                if (item.Value.Equals("Ж"))
                {
                    name = femaleNames[rnd.Next(0, femaleNames.Count)];
                    middleName = item.Key;
                    surname = surnames[rnd.Next(0, surnames.Count)];
                }

                if (item.Value.Equals("М"))
                {
                    name = maleNames[rnd.Next(0, maleNames.Count)];
                    middleName = item.Key;
                    surname = surnames[rnd.Next(0, surnames.Count)];
                }
                var p = new Person();
                p.Name = name;
                p.MiddleName = middleName;
                p.Surname = surname;

                p.Age = rnd.Next(18, 100);

                personsbuff.Add(p);
            }


            return personsbuff;
        }

        //public void PrintList()
        //{
        //    var persons = GenerateList();
        //    foreach (var p in persons)
        //    {
        //        Console.WriteLine(p.ToString());
        //    }
        //}

        private List<string> getOnlyMale()
        {
            List<string> men = new List<string>();

            var names = ExtractNames();

            foreach (var item in names)
            {
                if (item.Value.Equals("М"))
                {
                    men.Add(item.Key);
                }
            }

            return men;
        }

        private List<string> getOnlyFemale()
        {
            List<string> women = new List<string>();

            var names = ExtractNames();

            foreach (var item in names)
            {
                if (item.Value.Equals("Ж"))
                {
                    women.Add(item.Key);
                }
            }

            return women;
        }

        private List<string> ExtractSurnames()
        {
            var surnames = new List<string>();

            foreach (XmlNode xNode in _xRootSurnames)
            {

                foreach (XmlNode childNode in xNode.ChildNodes)
                {
                    foreach (XmlNode childchildNode in childNode.ChildNodes)
                    {
                        string surname = "Шеретов";

                        foreach (XmlNode chchchNode in childchildNode.ChildNodes)
                        {
                            if (chchchNode.Name == "Surname")
                            {
                                surname = chchchNode.InnerText;
                            }

                        }
                        surnames.Add(surname);
                    }
                }
            }


            return surnames;
        }

        private Dictionary<string, string> ExtractNames()
        {
            Dictionary<string, string> names = new Dictionary<string, string>();

            foreach (XmlNode xNode in _xRootNames)
            {

                foreach (XmlNode childNode in xNode.ChildNodes)
                {
                    foreach (XmlNode childchildNode in childNode.ChildNodes)
                    {
                        string name = "Марк";
                        string sex = "М";
                        foreach (XmlNode chchchNode in childchildNode.ChildNodes)
                        {
                            if (chchchNode.Name == "Name")
                            {
                                name = chchchNode.InnerText;
                            }
                            if (chchchNode.Name == "Sex")
                            {
                                sex = chchchNode.InnerText;
                                names.Add(name, sex);               //Если нашло поле Sex, то точно name и sex заполнены(совпадений не будет)
                            }

                        }

                    }
                }
            }

            return names;
        }

        private Dictionary<string, string> MakeMiddleNames()
        {
            var middleNames = new Dictionary<string, string>();

            var dict = ExtractNames();

            foreach (KeyValuePair<string, string> kvp in dict)
            {
                if (kvp.Value == "М")
                {
                    middleNames.Add(kvp.Key + "вич", "М");
                    middleNames.Add(kvp.Key + "овна", "Ж");
                }
            }

            return middleNames;
        }


    }


}
