using OOPlab10;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace L12
{
    public class TreeNode<T> where T: Person
    {
        public TreeNode(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }
    }

    public class Tree<T> : IEnumerable<T> where T : Person
    {
        public Tree()
        {
            Root = null;
            Size = 0;
        }

        public Tree(Stack<T> data)
        {
            Size = data.Count;
            Root = IdealTree(ref data, data.Count);
            
        }

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

            ColorPrint.Print(founded, ConsoleColor.Cyan);

            return count;
        }

        public void Print()
        {
            if (IsEmpty()) return;

            string s = "";

            LCRPrint(Root, ref s, 0);

            ColorPrint.Print(s, ConsoleColor.Cyan);
        }

        public bool Clear()
        {
            if (IsEmpty()) return false;

            Root = null;
            Size = 0;

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

        public TreeNode<T> Root { get; private set; }

        public int Size { get; private set; }

        private TreeNode<T> IdealTree(ref Stack<T> data, int size)
        {
            TreeNode<T> r;
            int nl, nr;

            if (size == 0) 
            {
                return null;
            }

            nl = size / 2;
            nr = size - nl - 1;

            T inserted = data.Pop();
            //Console.WriteLine(inserted.ToString());
            r = new TreeNode<T>(inserted);

            r.Left = IdealTree(ref data, nl);
            r.Right = IdealTree(ref data, nr);

            return r;
        }

        public TreeNode<T> Insert(TreeNode<T> root, T data)
        {

            if (root == null)
            {
                root = new TreeNode<T>(data);
                return root;
            }

            Person rp = root.Data;
            Person dp = data;

            if (dp.CompareTo(rp) < 0)
            {
                //ColorPrint.Print(dp.ToString() + " < " + rp.ToString() + '\n', ConsoleColor.DarkGray);
                root.Right = Insert(root.Right, data);
            }
            else
            {
                //ColorPrint.Print(rp.ToString() + " > " + dp.ToString() + '\n', ConsoleColor.DarkGray);
                root.Left = Insert(root.Left, data);
            }

            return root;
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
