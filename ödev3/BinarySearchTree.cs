using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication5
{
    class BinarySearchTree<T> where T:IComparable
    {
        TreeNode<T> root;
        public void Insert(T val)
        {
            if (root == null)
                root = new TreeNode<T>(val);
            else
            {
                TreeNode<T> iterator = root;
                TreeNode<T> parent = root;
                while (iterator != null)
                {
                    parent = iterator;
                    if (iterator.Value.CompareTo(val) == 1)
                        iterator = iterator.Left;
                    else if (iterator.Value.CompareTo(val) == -1)
                        iterator = iterator.Right;
                    else
                    {
                        Console.WriteLine("cift değer hatası");
                        return;
                    }

                }
                if (parent.Value.CompareTo(val) == 1)
                {

                    parent.Left = new TreeNode<T>(val);    
                    TreeNode<T> parentt = FindParent(val);  //verilen değerin parentını bulup parentt a atıyoruz
                    parent.Left.Parent = parentt.Value;      //parentt değerini nodun Parent kısmına ekliyoruz  
                     
                    TreeNode<T> Min = FindMin(root.Left);  //rootun sol tarafındaki en küçük değerini bulur
                    root.MinValue = Min.Value;            //bulunan değeri root nodunun enkucuk kısmına eklenir
                 
                }
                else
                {
                    parent.Right = new TreeNode<T>(val);
                    TreeNode<T> parentt = FindParent(val);
                    parent.Right.Parent = parentt.Value;

                    TreeNode<T> Max= FindMax(root.Right);
                    root.MaxValue = Max.Value;
                  
                }
            }

        }

        public void Delete(T val)
        {
            if (!Search(val))
                Console.WriteLine("Silinecek eleman yok...");
            else
            {
                TreeNode<T> iterator = root;
                TreeNode<T> parent = root;
                bool isLeftChild = true;
                while (iterator.Value.CompareTo(val) != 0)
                {
                    parent = iterator;
                    if (iterator.Value.CompareTo(val) == 1)
                    {
                        iterator = iterator.Left;
                        isLeftChild = true;
                    }
                    else
                    {
                        iterator = iterator.Right;
                        isLeftChild = false;
                    }
                }
                if (iterator.Left == null && iterator.Right == null)//No child
                {
                    if (iterator == root)
                        root = null;
                    else if (isLeftChild)
                    {

                        parent.Left = null;
                        if (root.Left == null)       //eğer root un solundaki çocuğu olmayan en kucuk elemanı silersek rootun değeri en küçük değere eklenir
                        {

                            root.MinValue = root.Value;
                        }
                        else
                        {
                            TreeNode<T> Min = FindMin(root.Left);    //if koşuluna uymazsa rootun sol tarafına bakılır ve en küçük değer bulunur
                            root.MinValue = Min.Value;
                        }

                    }
                    else
                    {

                        parent.Right = null;
                        if (root.Right == null)
                        {
                            root.MaxValue = root.Value;
                           
                        }
                        else
                        {
                            TreeNode<T> Max = FindMax(root.Right);
                            root.MaxValue =Max.Value;
 
                        }

                    }
                }
                else if (iterator.Right == null)
                {
                    if (iterator == root)
                        root = iterator.Left;
                    else if (isLeftChild)
                    {

                        parent.Left = iterator.Left;
                        
                        TreeNode<T> Min = FindMin(root.Left);
                        root.MinValue = Min.Value;
                        TreeNode<T> parentt = FindParent(parent.Left.Value);
                        parent.Left.Parent = parentt.Value;
                        

                    }
                    else
                    {
                        parent.Right = iterator.Left;

                        TreeNode<T> Max = FindMax(root.Right);
                        root.MaxValue = Max.Value;
                        TreeNode<T> parentt = FindParent(parent.Right.Value);
                        parent.Right.Parent = parentt.Value;
                        

                    }
                }
                else if (iterator.Left == null)
                {
                    if (iterator == root)
                    {
                        root = iterator.Right;
                    }
                    else if (isLeftChild)
                    {

                        parent.Left = iterator.Right;

                        TreeNode<T> Min = FindMin(root.Left);
                        root.MinValue = Min.Value;
                        TreeNode<T> parentt = FindParent(parent.Left.Value);
                        parent.Left.Parent = parentt.Value;

                    }
                    else
                    {
                        parent.Right = iterator.Right;
                        TreeNode<T> Max = FindMax(root.Right);
                        root.MaxValue = Max.Value;
                        TreeNode<T> parentt = FindParent(parent.Right.Value);
                        parent.Right.Parent = parentt.Value;

                    }
                }
                else
                {
                    TreeNode<T> successor = FindSuccessor(iterator);
                    T successorVal = successor.Value;
                    if (iterator == root)         //eğer root silinirse rootun sağı ve solundaki değerlerin parentlarına successorVal değeri eklenir
                    {
                        root.Left.Parent = successorVal;
                        root.Right.Parent = successorVal;

                    }
                   
                    Delete(successorVal);
                    iterator.Value = successorVal;
                    
                   
                }
            }
        }

        public bool Search(T val)
        {
            TreeNode<T> iterator = root;
            while (iterator != null)
            {
                if (iterator.Value.CompareTo(val) == 1)
                    iterator = iterator.Left;
                else if (iterator.Value.CompareTo(val) == -1)
                    iterator = iterator.Right;
                else
                    return true;

            }
            return false;
        }


        public TreeNode<T> FindSuccessor(TreeNode<T> tempNode)
        {
            if (tempNode.Right != null)
            {
                return FindMin(tempNode.Right);
            }
            else
            {
                TreeNode<T> child = tempNode;
                TreeNode<T> parent = FindParent(child.Value);
                while (child == parent.Right && parent != null)
                {
                    child = parent;
                    parent = FindParent(parent.Value);
                }
                return parent;

            }
        }


        public TreeNode<T> FindParent(T val)
        {
            if (root == null || root.Value.CompareTo(val) == 0)
                return null;
            else
            {
                TreeNode<T> iterator = root;
                TreeNode<T> parent = root;
                while (iterator.Value.CompareTo(val) != 0)
                {
                    parent = iterator;
                    if (iterator.Value.CompareTo(val) == 1)
                        iterator = iterator.Left;
                    else
                        iterator = iterator.Right;
                }
                return parent;
            }
        }

        public TreeNode<T> FindMin(TreeNode<T> tempRoot)
        {
            if (tempRoot.Left != null)
                return FindMin(tempRoot.Left);
            
              
            return tempRoot;

        }

        public TreeNode<T> FindMax(TreeNode<T> tempRoot)
        {
            if (tempRoot.Right != null)
                return FindMax(tempRoot.Right);
            return tempRoot;

        }
        public void Inorder()
        {
            Inorder(root);
            Console.WriteLine();
        }
        void Inorder(TreeNode<T> tempRoot)
        {
            if (tempRoot != null)
            {
               
                Inorder(tempRoot.Left);
                Console.WriteLine(tempRoot.Value);
                Console.WriteLine("Parent="+tempRoot.Parent);
                Console.WriteLine("En Küçük Değer: "+tempRoot.MinValue+"  En Büyük Değer: "+tempRoot.MaxValue);
                Inorder(tempRoot.Right);
            }
        }

        public void Preorder()
        {
            Preorder(root);
            Console.WriteLine();
        }
        void Preorder(TreeNode<T> tempRoot)
        {
            if (tempRoot != null)
            {
                Console.WriteLine(tempRoot.Value);
                Preorder(tempRoot.Left);
                Preorder(tempRoot.Right);
            }
        }

        public void Postorder()
        {
            Postorder(root);
            Console.WriteLine();
        }
        void Postorder(TreeNode<T> tempRoot)
        {
            if (tempRoot != null)
            {
                Postorder(tempRoot.Left);
                Postorder(tempRoot.Right);
                Console.WriteLine(tempRoot.Value);
            }
        }



    }
}
