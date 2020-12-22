using System.Collections.Generic;

namespace diskret_lab2
{
    public class Element
    {
        public string Value { get; private set;} //Значение элемента

        public HashSet<Element> UpperRelations{get;private set;} //Связи на уровень выше на диаграмме

        public HashSet<Element> LowerRelations{ get; private set;} //Связи на уровент ниже на диаграмме


        /// <summary>
        /// Конструктор с параметром
        /// </summary>
        /// <param name="value">значение для элемента</param>
        public Element(string value)
        {
            this.Value = value;
            UpperRelations = new HashSet<Element>();
            LowerRelations = new HashSet<Element>();
        }


        /// <summary>
        /// Получение  всех отношений выше
        /// </summary>
        /// <returns></returns>
        public HashSet<Element> GetAllUpperRelations()
        {
            HashSet<Element> relations = new HashSet<Element>(UpperRelations);

            foreach (Element elem in UpperRelations) relations.UnionWith(elem.GetAllUpperRelations());

            return relations;
        }

        /// <summary>
        /// Получение всех отношений ниже
        /// </summary>
        /// <returns></returns>
        public HashSet<Element> GetAllLowerRelations()
        {
            HashSet<Element> relations = new HashSet<Element>(LowerRelations);

            foreach( Element elem in LowerRelations) relations.UnionWith(elem.GetAllLowerRelations());

            return relations;
        }

        /// <summary>
        /// Добавление отношения к элементу
        /// </summary>
        /// <param name="element">Элемент</param>
        /// <returns></returns>
        public bool AddRelation(Element element)
        {
            return AddUpperRelation(element);
        }


        /// <summary>
        /// Добавить связь на уровень выше
        /// </summary>
        /// <param name="element">Элемент</param>
        /// <returns></returns>
        private bool AddUpperRelation(Element element)
        {
            if(!this.UpperRelations.Contains(element) && !this.LowerRelations.Contains(element))
            {
                this.UpperRelations.Add(element);//Добавление отношения
                element.AddLowerRelation(this); // Добавление противоположного отношения новому элементу
                return true;//Добавление успешно
            }
            else return false;//если отношение есть - то не успешно
        }


        /// <summary>
        /// Добавить связь на уровень ниже
        /// </summary>
        /// <param name="element">Элемент</param>
        /// <returns></returns>
        private bool AddLowerRelation(Element element)
        {
            if(!this.LowerRelations.Contains(element))
            {
                this.LowerRelations.Add(element);
                element.AddUpperRelation(this);
                return true;
            }
            else return false;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns>Значение Value</returns>
        public override string ToString()
        {
            return Value;
        }
    }
}