namespace XMLGenerator
{
    public class Person
    {

        private string _name;


        private string _surname;
        private string _middleName;
        private int _age;




        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string Surname
        {
            get => _surname;
            set => _surname = value;
        }

        public string MiddleName
        {
            get => _middleName;
            set => _middleName = value;
        }

        public int Age
        {
            get => _age;
            set => _age = value;
        }




        public override string ToString()
        {
            return $"{this.Surname} {this.Name} {this.MiddleName} Возраст: {this.Age}";
        }
    }
}