using OOPlab10;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace L12
{
    public class TreeNode<T> where T: Person, new()
    {
        public TreeNode(T data)
        {
            Data = data;
        }

        public TreeNode(TreeNode<T> data)
        {
            this.Data = new T();
            Data.Name = data.Data.Name;
            Data.Age = data.Data.Age;
            Data.Sex = data.Data.Sex;
            this.Left = data.Left;
            this.Right = data.Right;

        }

        public TreeNode<T> Clone()
        {
            return new TreeNode<T>(this);
        }
        
        public T Data { get; set; }
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }
        
        
    }
    

    public class Tree<T> : IEnumerable<T>, ICloneable where T : Person, new()
    {
        private  int _height;

        public int Height
        {
            get
            {
                _height = HeightOfBinaryTree(Root);
                return _height;
            }
        }

        private int HeightOfBinaryTree(TreeNode<T> node)
        {
            if (node == null)
            {
                return 0;
            }
            else
            {
                return 1 + Math.Max(HeightOfBinaryTree(node.Left), HeightOfBinaryTree(node.Right));
            }
        }

        public Tree()
        {
            Root = null;
            Size = 0;
            Capacity = 0;
            
        }

        // public Tree(Stack<T> data)
        // {
        //     Size = data.Count;
        //     Root = IdealTree(ref data, data.Count);
        // }

        public Tree(ICollection<T> data)
        {
            Size = data.Count;
            Capacity = data.Count;
            Root = IdealTree(ref data, data.Count);
        }
        /// <summary>
        /// Конструктор пустого дерева с заданным размером. 
        /// </summary>
        /// <param name="capacity">Размер</param>
        public Tree(int capacity)
        {
            Size = 0;
            Capacity = capacity;

            ICollection<T> data = new List<T>();
            
            
            for (int i = 0; i < capacity; i++)
            {
                
                data.Add((T) new Employee("null",0,'-',"null").Base);
                
            }

            Root = IdealTree(ref data, capacity);
        }

        public int Capacity { get; private set; }

        // public Tree(Tree<T> baseTree)
        // {
        //     Size = baseTree.Size;
        //     ICollection<T> baseData = baseTree.ToList();
        //     Root = IdealTree(ref baseData, baseData.Count);
        // }
       
        
        //Обратный обход
        private void LCRPrint(TreeNode<T> node, ref string s, int spaces)
        {
            if (node != null)
            {
                spaces++;
                LCRPrint(node.Left, ref s, spaces);

                for (int i = 0; i < spaces; i++)
                    s += "- ";
                s += node.Data.ToString() + " \n"; 
                
                LCRPrint(node.Right, ref s, spaces); 
            }
        }

        private void LCRSearch(TreeNode<T> node, string name, ref int count, ref string founded)
        {
            if (node != null)
            {

                LCRSearch(node.Left, name, ref count, ref founded);

                if (node.Data is Person)
                {
                    if ((node.Data as Person).Name == name)
                    {
                        founded += node.Data.ToString() + '\n';
                        count++;
                    }
                }

                LCRSearch(node.Right, name, ref count, ref founded);
            }
        }

        public int Search(string surname)
        {
            if (IsEmpty()) return 0;

            int count = 0;
            string founded = "";
            LCRSearch(Root, surname, ref count, ref founded);

            ColorPrint.Print(founded, ConsoleColor.Magenta);

            return count;
        }

        public void Print()
        {
            if (IsEmpty() && this.Count() == 0) return;

            string s = "";

            LCRPrint(Root, ref s, 0);

            ColorPrint.Print(s, ConsoleColor.Magenta);
        }

        public bool Clear()
        {
            if (IsEmpty()) return false;

            Root = null;
            Size = 0;
            GC.Collect();
            return true;
        }

        public bool IsEmpty()
        {
            if (Size == 0)
            {
                ColorPrint.Error("Дерево пустое\n");
                return true;
            }
            return false;
        }

        public  TreeNode<T> GetNode(int index)
        {
            List<TreeNode<T>> lst = new List<TreeNode<T>>();
            ToList(ref lst,Root);

            return lst[index];
        }
        
        
        // private static void ConvertTreeToList(TreeNode<T> root, List<T> result)
        // {
        //     if (root == null)
        //     {
        //         return;
        //     }
        //     
        //     result.Add(root.Data);
        //     ConvertTreeToList(root.Left, result);
        //     ConvertTreeToList(root.Right, result);
        // }
        
        
        

        
        
        private static IEnumerable<T> ConvertTreeToList(TreeNode<T> root)
        {
            if (root == null)
                return Enumerable.Empty<T>();

            return new[] { root.Data }
                .Concat(ConvertTreeToList(root.Left))
                .Concat(ConvertTreeToList(root.Right));
        }
        public TreeNode<T> Root { get; set; }

        public int Size { get; private set; }


        private TreeNode<T> IdealTree(ref ICollection<T>data, int size)
        {
            TreeNode<T> r;
            int nl, nr;

            if (size == 0) 
            {
                return null;
            }

            nl = size / 2;
            nr = size - nl - 1;

            T inserted = data.First();
            data.Remove(data.First());
           
            r = new TreeNode<T>(inserted);

            r.Left = IdealTree(ref data, nl);
            r.Right = IdealTree(ref data, nr);

            return r;
        }

      

        // private TreeNode<T> IdealTree(ref Tree<T> data, int size)
        // {
        //     TreeNode<T> r;
        //     int nl, nr;
        //
        //     if (size == 0)
        //     {
        //         return null;
        //     }
        //
        //     nl = size / 2;
        //     nr = size - nl - 1;
        //
        //     ICollection<T> lData = data.ToList();
        //
        //     T inserted = lData.First();
        //     lData.Remove(lData.First());
        //
        //     r = new TreeNode<T>(inserted);
        //     
        //     r.Left = IdealTree(ref lData, nl);
        //     r.Right = IdealTree(ref lData, nr);
        //
        //     return r;
        // }

        public void Insert(T data)
        {
            Root = Insert(Root, data);
        }

        private TreeNode<T> Insert(TreeNode<T> root, T data)
        {
            if (root == null)
            {
                root = new TreeNode<T>(data);
                Size++;
                Capacity++;
                return root;
            }

            
            if (root.Data.Name.Equals("null"))
            {
                 
                 root.Data.Name = data.Name;
                 root.Data.Sex = data.Sex;
                 root.Data.Age = data.Age;

                 Size++;
                 return root;
            }
            
            Person rp = root.Data;
            Person dp = data;
            

            if (dp.CompareTo(rp) < 0 || (Capacity > Size && root.Right.Data.Name.Equals("null")))
            {
                root.Right = Insert(root.Right, data);
            }
            else 
            {
                root.Left = Insert(root.Left, data);
            }

            
            return root;
        }

        public void AddRange(ICollection<T> plist)
        {
            foreach (var p in plist)
            {
                this.Insert(this.Root, p);
            }
        }

        public void ToList(ref List<T> output, TreeNode<T> node)
        {
            if (node != null)
            {
                output.Add(node.Data);

                ToList(ref output, node.Left);
                
                ToList(ref output, node.Right);
            }
        }

        public void ToList(ref List<TreeNode<T>> output, TreeNode<T> node)
        {
            if (node != null)
            {
                output.Add(node);
                
                ToList(ref output, node.Left);
                
                ToList(ref output, node.Right);
            }
        }
        

        

        // public List<TreeNode<T>> ToList()
        // {
        //     var tmp = new List<TreeNode<T>>();
        //     foreach (var item in this)
        //     {
        //         tmp.Add(new TreeNode<T>(item));
        //     }
        //
        //     return tmp;
        // }

        public void ToSearchTree()
        {
            if (IsEmpty()) return;

            List<T> l = new List<T>();

            ToList(ref l, Root);

            //foreach (var item in l)
            //{
            //    Console.WriteLine(item.ToString());
            //}

            TreeNode<T> tmpRoot = new TreeNode<T>(l[0]);

            for (int i = 1; i < l.Count; i++)
            {
                tmpRoot = Insert(tmpRoot, l[i]);
            }

            Root = tmpRoot;

        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        // private TreeNode<T> IdealTree(ref Stack<T> data, int size)
        // {
        //     TreeNode<T> r;
        //     int nl, nr;
        //
        //     if (size == 0) 
        //     {
        //         return null;
        //     }
        //
        //     nl = size / 2;
        //     nr = size - nl - 1;
        //
        //     T inserted = data.Pop();
        //     //Console.WriteLine(inserted.ToString());
        //     r = new TreeNode<T>(inserted);
        //
        //     r.Left = IdealTree(ref data, nl);
        //     r.Right = IdealTree(ref data, nr);
        //
        //     return r;
        // }

        public object Clone()
        {
            var clone = new Tree<T>();
            for (int i = 0; i < this.Size; i++)
            {
                clone.Insert(clone.Root, this.ToList()[i]);
            }

            clone.Root = new TreeNode<T>(Root);
            return clone;
        }

        public Tree<T> Copy()
        {
            return this;
        }
        
        public void DeleteByKey(T key)
        {
            Root = deleteRec(Root, key);
        }
        
        public T minValue(TreeNode<T> node)
        {
            T minv = node.Data;
            while (node.Left != null)
            {
                minv = node.Left.Data;
                node = node.Left;
            }
            return minv;
        }
        private TreeNode<T> deleteRec(TreeNode<T> root, T key)
        {
            if (root == null)
                return null;
            if (((IComparable)key).CompareTo(root.Data) < 0)
                root.Left = deleteRec(root.Left, key);
            else if (((IComparable)key).CompareTo(root.Data) > 0)
                root.Right = deleteRec(root.Right, key);
            else
            {
                if (root.Left == null)
                    return root.Right;
                else if (root.Right == null)
                    return root.Left;
                root.Data = minValue(root.Right);
                root.Right = deleteRec(root.Right, root.Data);
            }
            return root;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            List<T> l = new List<T>();
            this.ToList(ref l, Root);

            foreach (T item in l)
            {
                yield return item;
            }
        }
    }
}
