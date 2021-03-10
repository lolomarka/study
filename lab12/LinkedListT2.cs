
using System;
using System.Collections.Generic;
using System.Collections;
using OOPlab10;
using OOPLAB11;

namespace L12
{
    public class LinkedListT2<T> /*: IEnumerable<T>*/ where T: Person
    {
        public LinkedListT2()
        {
            Head = null;
            Tail = null;
            Count = 0;
            Capacity = 0;
        }

        public LinkedListT2(int capacity)
        {
            for (int i = 0; i < capacity; i++)
            {
                AddLast(null);
            }
            Capacity = capacity;
            Count = 0;
        }

        public LinkedListT2(ICollection<T> data)
        {
            foreach (T item in data)
            {
                AddLast(item);
            }
            Capacity = Count = data.Count;

        }

        public OWNode<T> Head { get; private set; }
        public OWNode<T> Tail { get; private set; }
        public int Count { get; private set; }
        public int Capacity { get; private set; }

        public bool IsEmpty()
        {
            if (Count == 0)
            {
                ColorPrint.Error("Список пуст\n");
                return true;
            }
            return false;
        }

        public void AddFirst(T data)
        {
            if (Count == 0 && Capacity != 0)
                Head.Data = data;
            else
            {
                OWNode<T> node = new OWNode<T>(data);
                node.Next = Head;
                Head = node;
            }
           
            if (Capacity == 0)
                Tail = Head;

            Count++;

            if (Count > Capacity)
                Capacity++;
        }

        public void AddLast(T data)
        {
            OWNode<T> node = new OWNode<T>(data);

            if (Head == null) //если список пуст и емкость = 0
            {
                Head = node;
                Tail = node;
                Count++;
            }

            else if (data == null) //добавление пустого элемента в конец
            {
                Tail.Next = node;
                Tail = node;
            }

            else
            {
                if (Count < Capacity) //если есть пустые элементы
                {
                    AddAt(data, Count + 1);
                }

                else //если нет, то добавление в конец
                {
                    Tail.Next = node;
                    Tail = node;
                    Count++;
                }
            }

            if (Count > Capacity)
                Capacity++;

        }

        public void AddRange(ICollection<T> data)
        {
            foreach (T item in data)
            {
                AddLast(item);
            }
        }

        private OWNode<T> GetNode(int index)
        {
            OWNode<T> node = Head;

            for (int i = 0; i < index; i++)
            {
                node = node.Next;
            }

            return node;
        }

        public bool AddAt(T data, int pos)
        {

            if (pos > 0 && pos <= Capacity + 1)
            {
                if (pos == 1) //добавление к начало
                    AddFirst(data);
                else if (pos == Capacity + 1) //добавление в конец
                    AddLast(data);
                else
                {
                    OWNode<T> prev = GetNode(pos-2);

                    if (prev.Next.Data == null) //если выбранный узел пуст
                    {
                        prev.Next.Data = data;
                    }
                    else
                    {
                        OWNode<T> node = new OWNode<T>(data);

                        node.Next = prev.Next;
                        prev.Next = node;
                    }

                    Count++;

                    if (Count > Capacity)
                        Capacity++;
                }
                return true;
            }
            else
            {
                ColorPrint.Error("Не удалось добавить элемент. Неверный номер\n");
                return false;
            }
        }

        public bool Remove(T data)
        {
            if (IsEmpty()) return false;

            OWNode<T> cur = Head;
            OWNode<T> prev = null;

            //пока не дошли до конца списка
            while (cur != null)
            {
                if (cur.Data.Equals(data))
                {
                    //перекидываем ссылку предыдущего узла на следующий
                    if (prev != null)
                    {
                        prev.Next = cur.Next;
                        //если после след. элемента ничего нет, то обозначаем его как хвост списка
                        if (cur.Next == null)
                            Tail = prev;
                    }
                    else
                    {
                        Head = Head.Next;

                        //если элемент 1 в списке
                        if (Head == null)
                            Tail = null;
                    }
                    AddLast(null);
                    cur.Data = null;
                    Count--;
                    return true;
                }
                //переход в след. элементу
                prev = cur;
                cur = cur.Next;
            }
            return false;


        }

        public int RemoveRange(int startPos, int endPos)
        {

            if (startPos > endPos)
            {
                int temp = startPos;
                startPos = endPos;
                endPos = temp;
            }

            if (startPos < 1)
                startPos = 1;
            if (endPos > Count)
                endPos = Count;

            for (int i = startPos; i <= endPos; i++)
            {
               RemoveAt(startPos);
            }

            int deleted = endPos-startPos+1;
            ColorPrint.Success("Удалено элементов: " + deleted + '\n');

            return deleted;
                
        }

        public bool RemoveLast()
        {
            return RemoveAt(Count);
        }

        public bool RemoveAt(int pos)
        {
            if (IsEmpty()) return false;

            if (pos > 0 && pos <= Capacity)
            {
                OWNode<T> node = GetNode(pos - 1);

                if (node.Data != null)
                {
                    if (Count == 1)
                    {
                        Head.Data = null;
                    }
                    else if (node == Head)
                    {
                        Head = Head.Next;
                        AddLast(null);
                    }
                    else if (node == Tail)
                    {
                        Tail.Data = null;

                    }
                    else
                    {
                        OWNode<T> prev = GetNode(pos - 2);
                        prev.Next = node.Next;
                        AddLast(null);
                    }
                        
                    Count--;
                    ColorPrint.Success($"Элемент удален\n");
                    return true;
                }
                ColorPrint.Error($"Элемента на позиции {pos} не существует\n") ;
                return false;
            }
            else
            {
                ColorPrint.Error("Не удалось удалить элемент. Неверный номер\n");
                return false;
            }
        }

        public int Search(string name, ref string output)
        {
            if (IsEmpty()) return 0;

            int count = 0;
            foreach (T item in this)
            {
                if (item != null && item.Name == name)
                {
                    count++;
                    output += item.ToString() + '\n';
                }
            }

            return count;
        }

        public LinkedListT2<T> Clone()
        {
            LinkedListT2<T> tmp = new LinkedListT2<T>();

            foreach (T item in this)
            {
                if (item != null)
                    tmp.AddLast((T)item.Clone());
                else
                    tmp.AddLast(null);
            }

            return tmp;
        }
        public LinkedListT2<T> Copy()
        {
            LinkedListT2<T> tmp = new LinkedListT2<T>();

            foreach (T item in this)
            {
                tmp.AddLast(item);
            }

            return tmp;
        }

        public bool Clear()
        {
            if (IsEmpty()) return false;

            Head = null;
            Tail = null;
            Count = 0;
            Capacity = 0;

            return true;
        }

        public void Print()
        {
            if (IsEmpty()) return;

            foreach (T item in this)
            {
                if (item != null)
                    ColorPrint.Print(item.ToString() + '\n', ConsoleColor.Cyan);
                else
                    ColorPrint.Print("Пусто" + '\n', ConsoleColor.Gray);
            }
        }
        // Н А С Л Е Д О В А Н И Е
        // не парам в интерфейсе IEnumerable, парам в интерфейсе IEnumerable<T>
        // и получается, что это 2 совсем разных метода
        //+ старый интерфейс используется в некоторых реализациях (обратная совместимость)

        //Явная реализация не парам. интерфейса
        //IEnumerator IEnumerable.GetEnumerator() 
        //{
        //    //возвращаем реальный итератор
        //    return ((IEnumerable)this).GetEnumerator();
        //}

        public IEnumerator<T> GetEnumerator()
        {
            //реальный итератор
            OWNode<T> current = Head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}
