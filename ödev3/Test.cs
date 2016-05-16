
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace ConsoleApplication5
{
    class Test
    {
        static void Main(string[] args)
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
           
            StreamReader FileRead;
            FileRead = File.OpenText(@"C:\Odev3.txt");
            string array1;

            char[] sembol = new char[] { ' ' };

            while ((array1 = FileRead.ReadLine()) != null)
            {
                char[] semboller = new char[] { ',' };
                string[] array = array1.Split(semboller, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < array.Length; i++)
                {
                    if (!bst.Search(Int32.Parse(array[i])))
                        bst.Insert(Int32.Parse(array[i]));
                    else
                        bst.Delete(Int32.Parse(array[i]));

                }
                if(array1!="")
                {
                
                bst.Inorder();
                bst.Preorder();
                bst.Postorder();
                }
               
            }
            
                        

                        
                 
                      
        }
    }
}
