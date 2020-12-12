using System.Collections;

namespace OOPlab10
{
    public class SortByName : IComparer
    {
        /// <summary>
        /// Сравнение объектов по полю name
        /// </summary>
        /// <param name="o1">Объект для сравнения №1</param>
        /// <param name="o2">Объект для сравнения №2</param>
        /// <returns></returns>
        int IComparer.Compare(object o1, object o2)
        {
            Person p1 = (Person)o1;
            Person p2 = (Person)o2;

            return string.Compare(p1.Name, p2.Name);
        }
    }
}