using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace OOPLAB11
{
    public class TestCollections<TKey,TValue>
    {
        private static Queue<TKey> queueTKey;                           //Базовые
        private static Queue<string> queueString;                       //Базовые string
        private static SortedDictionary<TKey, TValue> sortDictTKey;     //Базовый - производный
        private static SortedDictionary<string, TValue> sortDictString; //Базовый string - производный
        
        public int Count { get; private set; }

        public Queue<TKey> Keys
        {
            get
            {
                return new Queue<TKey>(queueTKey);
            }
        }

        public Queue<TValue> Values
        {
            get
            {
                return new Queue<TValue>(sortDictTKey.Values);
            }
        }

        public Queue<string> Strings
        {
            get
            {
                return new Queue<string>(queueString);
            }
        }

        public TestCollections(Queue<TValue> sourceVal, Queue<TKey> sourceKey)
        {
            if (sourceKey.Count != sourceVal.Count)
                throw new ArgumentException("Параметры должны иметь одинаковый размер");

            queueTKey = new Queue<TKey>();
            queueString = new Queue<string>();
            sortDictTKey = new SortedDictionary<TKey, TValue>();
            sortDictString = new SortedDictionary<string, TValue>();
            Count = sourceVal.Count;

            for (int i = 0; i < Count; i++)
            {
                TKey tempKey = sourceKey.Dequeue();
                TValue tempValue = sourceVal.Dequeue();
                queueTKey.Enqueue(tempKey);    
                queueString.Enqueue(tempKey.ToString());
                sortDictTKey.Add(tempKey, tempValue);
                sortDictString.Add(tempKey.ToString(), tempValue);
            }
        }

        public TestCollections()
        {
            queueTKey = new Queue<TKey>();
            queueString = new Queue<string>();
            sortDictTKey = new SortedDictionary<TKey, TValue>();
            sortDictString = new SortedDictionary<string, TValue>();
            Count = 0;
        }

        public void PrintQueueKey()
        {
            foreach (TKey item in queueTKey)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void PrintQueueString()
        {
            foreach (string item in queueString)
            {
                Console.WriteLine(item);
            }
        }

        public void PrintDictKey()
        {
            foreach (KeyValuePair<TKey, TValue> item in sortDictTKey)
            {
                Console.WriteLine(item.Key.ToString() + " : " + item.Value.ToString());
            }
        }
        public void PrintDictString()
        {
            foreach (KeyValuePair<string, TValue> item in sortDictString)
            {
                Console.WriteLine(item.Key + " : " + item.Value.ToString());
            }
        }

        public void PrintColl()
        {
            Console.WriteLine("\nKeyDict: ");
            PrintDictKey();
        }

        public bool Remove(TKey del)
        {
            if (IsEmpty()) return false;
            bool res = QueueRemove(del);
            QueueRemove(del.ToString());
            sortDictTKey.Remove(del);
            sortDictString.Remove(del.ToString());
            Count--;
            
            if(res)
                Console.WriteLine("Элемент удалён");
            else
                Console.WriteLine("Элемент не существует");

            return res;
        }

        private bool QueueRemove(TKey del)
        {
            bool b = false;
            Queue<TKey> _queue = new Queue<TKey>();
            foreach (var item in queueTKey)
            {
                if (!item.Equals(del))
                {
                    _queue.Enqueue(item);
                }
                else
                {
                    b = true;
                }
            }

            queueTKey = _queue;

            return b;
        }

        private bool QueueRemove(string del)
        {
            bool b = false;
            Queue<string> _queue = new Queue<string>();
            foreach (var item in queueString)
            {
                if (!item.Equals(del))
                {
                    _queue.Enqueue(item);
                }
                else
                {
                    b = true;
                }
            }
            queueString = _queue;
            return b;
        }

        private bool IsEmpty()
        {
            if (Count == 0)
            {
                Console.WriteLine("Коллекция пуста");
                return true;
            }

            return false;
        }

        public void Add(TKey addKey, TValue addVal)
        {
            if (!Contains(addKey))
            {
                queueTKey.Enqueue((addKey));
                queueString.Enqueue(addKey.ToString());
                Count++;
            }

            sortDictTKey[addKey] = addVal;
            sortDictString[addKey.ToString()] = addVal;
            Console.WriteLine("Элемент добавлен");
        }

        public bool Contains(TKey item)
        {
            return queueTKey.Contains(item);
        }

        public bool SearchQueue(TKey key)
        {
            Stopwatch sw = new Stopwatch();
            sw.Restart();

            bool result = queueTKey.Contains(key);

            sw.Stop();
            Console.WriteLine($"Время поиска: {sw.ElapsedTicks} тиков");

            return result;
        }

        public bool SearchQueue(string key)
        {
            Stopwatch sw = new Stopwatch();
            sw.Restart();

            bool result = queueString.Contains(key);

            sw.Stop();
            Console.WriteLine("Время поиска: " + sw.ElapsedTicks + " тиков");

            return result;
        }

        public bool SearchDictKey(TKey key)
        {
            Stopwatch sw = new Stopwatch();
            sw.Restart();

            bool result = sortDictTKey.ContainsKey(key);

            sw.Stop();
            Console.WriteLine("Время поиска: " + sw.ElapsedTicks + " тиков");

            return result;
        }

        public bool SearchDictKey(string key)
        {
            Stopwatch sw = new Stopwatch();
            sw.Restart();

            bool result = sortDictString.ContainsKey(key);

            sw.Stop();
            Console.WriteLine("Время поиска: " + sw.ElapsedTicks + " тиков");

            return result;
        }
        
        public bool SearchDictValue(TValue value)
        {
            Stopwatch sw = new Stopwatch();
            sw.Restart();

            bool result = sortDictTKey.ContainsValue(value);

            sw.Stop();
            Console.WriteLine("Время поиска: " + sw.ElapsedTicks + " тиков");

            return result;
        }
        
    }

    
}