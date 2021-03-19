using System;
using System.Collections.Generic;
using System.Collections;


namespace L12
{
    public class OWNode<T> 
    {
        public OWNode(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public OWNode<T> Next { get; set; }
    }

    public class OWLinkedList<T> : IEnumerable<T>
    {
        OWNode<T> head;
        OWNode<T> tail;

        public OWLinkedList()
        {
            head = null;
            tail = null;
            Size = 0;
        }

        public OWLinkedList(List<T> data)
        {
            foreach (T item in data)
            {
                AddLast(item);
            }
            Size = data.Count;
        }
        public OWNode<T> Head { get { return head; } }
        public OWNode<T> Tail { get { return tail; } }
        public int Size { get; private set; }
        public bool IsEmpty()
        {
            if (Size == 0)
            {
                ColorPrint.Error("Список пуст\n");
                return true;
            }
            return false;
        }

        public void AddFirst(T data)
        {
            OWNode<T> node = new OWNode<T>(data);

            node.Next = head;
            head = node;

            if (Size == 0)
                tail = head;

            Size++;
        }

        public void AddLast(T data)
        {
            OWNode<T> node = new OWNode<T>(data);

            if (head == null)
                head = node;
            else
                tail.Next = node;

            tail = node;
            Size++;
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
                            tail = prev;
                    }
                    else
                    {
                        head = head.Next;

                        //если элемент 1 в списке
                        if (head == null)
                            tail = null;
                    }
                    Size--;
                    return true;
                }
                //переход в след. элементу
                prev = cur;
                cur = cur.Next;
            }
            return false;
        }

        public bool DeleteList()
        {
            if (IsEmpty()) return false;

            head = null;
            tail = null;
            Size = 0;
            return true;
        }

        public void Print()
        {

            if (IsEmpty()) return;

            foreach (T item in this)
            {
                ColorPrint.Print(item.ToString() + '\n', ConsoleColor.Cyan);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            OWNode<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
}
}
