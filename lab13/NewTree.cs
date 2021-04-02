using System;
using System.Collections.Generic;
using L12;
using OOPlab10;

namespace L13
{
    public class TreeEventArgs : EventArgs
    {
        public string CollectionName { get; private set; }
        public string ChangeType { get; private set; }
        
        public object Object { get; private set; }
        
        public TreeEventArgs(string name, string changeType, object obj)
        {
            CollectionName = name;
            ChangeType = changeType;
            Object = obj;
        }

        public override string ToString()
        {
            return $"{CollectionName}: '{ChangeType}' for {Object}";
        }
        
    }

    public delegate void TreeHandler(object source, TreeEventArgs args);
    
    
    public class MyNewTree<T> : Tree<T> where T: Person, new()
    {
        public event TreeHandler CountChanged;
        public event TreeHandler RefChanged;
        
        
        public string Name { get; private set; }

        public MyNewTree(string name) : base()
        {
            Name = name;
        }

        public MyNewTree(int capacity, string name) : base(capacity)
        {
            Name = name;
        }

        public MyNewTree(ICollection<T> data, string name) : base(data)
        {
            Name = name;
        }

        public void OnCountChanged(object source, TreeEventArgs args)
        {
            CountChanged?.Invoke(source,args);
        }

        public void OnRefChanged(object source, TreeEventArgs args)
        {
            RefChanged?.Invoke(source,args);
        }
        

        public void Add(T data)
        {
            Insert(data);
            OnCountChanged(this,new TreeEventArgs(Name,"Add",data));
            
            ColorPrint.Print($"{Name}: Adding -> new value [end]: {data}\n",ConsoleColor.Yellow);
        }

        public T this[int index]
        {
            get
            {
                if (index >= Size || index < 0)
                    throw new ArgumentOutOfRangeException();
                return GetNode(index).Data;
            }
            set
            {
                if (index >= Size || index < 0)
                    throw new ArgumentOutOfRangeException();

                TreeNode<T> node = GetNode(index);
                node.Data = value;
                OnRefChanged(this, new TreeEventArgs(Name, "Ref change", value));

                ColorPrint.Print($"{Name}: RefChanging -> new value[{index}]: {value}\n", ConsoleColor.Yellow);

            }
        }

        public void Sort(Comparison<T> comp)
        {
            T[] arr = new T[Size];
            
            for(int i = 0; i < Size;i++)
            {
                arr[i] = this[i];
            }

            Array.Sort(arr, comp);

            for (int i = 0; i < Size; i++)
            {
                this[i] = arr[i];
            }
        }

        public void Delete(T key)
        {
            DeleteByKey(key);
            OnCountChanged(this,new TreeEventArgs(Name,"Delete",key));
            ColorPrint.Print($"{Name}: Deleting -> new value [end]: {key}\n",ConsoleColor.Yellow);
        }


        public new void Print()
        {
            ColorPrint.Success(Name + "\n");
            base.Print();
        }
        

    }
}