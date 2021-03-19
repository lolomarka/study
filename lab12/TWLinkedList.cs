using System;
using System.Collections.Generic;
using System.Collections;


namespace L12
{
    public class TWNode<T>
    {
        public TWNode(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public TWNode<T> Next { get; set; }
        public TWNode<T> Prev { get; set; }
    }

    public class TWLinkedList<T> : IEnumerable<T>
    {
        TWNode<T> head;
        TWNode<T> tail;

        public TWLinkedList()
        {
            head = null;
            tail = null;
            Size = 0;
        }

        public TWLinkedList(List<T> data)
        {
            foreach (T item in data)
            {
                AddLast(item);
            }
            Size = data.Count;
        }
        public TWNode<T> Head { get { return head; } }
        public TWNode<T> Tail { get { return tail; } }
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
            TWNode<T> node = new TWNode<T>(data);

            if (head == null)
            {
                head = node;
                tail = head;
            }
            else
            {
                node.Next = head;
                head.Prev = node;
                head = node;
            }

            Size++;
        }

        public void AddLast(T data)
        {
            TWNode<T> node = new TWNode<T>(data);

            if (head == null)
                head = node;
            else
            {
                tail.Next = node;
                node.Prev = tail;
            }

            tail = node;
            Size++;
        }

        public bool AddAt(T data, int pos)
        {

            TWNode<T> node = new TWNode<T>(data);
            
            if (pos > 0 && pos <= Size + 1)
            {
                if (pos == 1)
                    AddFirst(data);
                else if (pos == Size + 1)
                    AddLast(data);
                else
                {
                    TWNode<T> tmp = head;
                    for (int i = 1; i < pos-1; i++)
                    {
                        tmp = tmp.Next;
                    }
                    node.Prev = tmp;
                    node.Next = tmp.Next;
                    tmp.Next.Prev = node;
                    tmp.Next = node;

                    Size++;
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

            TWNode<T> cur = head;

            //поиск необходимого узла
            while (cur != null)
            {
                if (cur.Data.Equals(data))
                {
                    break;
                }
                cur = cur.Next;
            }

            if (cur != null)
            {
                if (cur.Next != null)
                {
                    cur.Next.Prev = cur.Prev;
                }
                else
                {
                    tail = cur.Prev;
                }

                if (cur.Prev != null)
                {
                    cur.Prev.Next = cur.Next;
                }
                else
                {
                    head = cur.Next;
                }
                Size--;
                return true;
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
            TWNode<T> cur = head;
            while (cur != null)
            {
                yield return cur.Data;
                cur = cur.Next;
            }
        }
    }
}
