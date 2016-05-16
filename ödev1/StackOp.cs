using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace C13253039HW1
{
    class StackOp<T> where T :IComparable
    {
        public void HTMLcontrol(string fileName)
        {
            StreamReader FileRead;
            string tempp;
            string test = "";
            FileRead = File.OpenText(fileName);
            while ((tempp = FileRead.ReadLine()) != null)
            {
                test += tempp;           
            }

            StringOp obj = new StringOp();
            string[] result = obj.seperate(test);                     //seperate metodunu çağırılıp okunan dosya istenen değişkene kadar parçalanır.
            Stack<string> tempstack = new Stack<string>(result.Length);
          

            for (int i = 0; i < result.Length; i++)
            {
                if (tempstack.IsEmpty())                      //tempstack boş iken iki eleman tempstack e atılır.
                {
                    tempstack.Push(result[i]);
                    tempstack.Push(result[i + 1]);
                }
                else
                {                                                 //tempstack boş değilken iki eleman pop edilir.
                    string temp = tempstack.Pop();
                    string temp2 = tempstack.Pop();
                    if (temp.CompareTo(temp2) != 0)                //alınan iki eleman eşit değil ise
                    {
                        tempstack.Push(temp2);                     //tempstack e geri eklenir.
                        tempstack.Push(temp);
                    }
                    if (tempstack.IsEmpty())                       //tempstack boş kaldığı zaman ekrana GEÇERLİ yazılır
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("-------GEÇERLİ-------");
                        Console.WriteLine();
                        Console.WriteLine();
                        break;
                    }
                    if (i + 1 != result.Length)                   
                    {
                        tempstack.Push(result[i + 1]);             //eşitlik sağlandığı sürece (i+1). eleman tempstack e eklenir.
                    }

                }
            }
            if (!tempstack.IsEmpty())                             //döngü bittiğinde tempstack boş değil ise ekrana GEÇERSİZ yazılır.
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("--------GEÇERSİZ---------");
                Console.WriteLine();
                Console.WriteLine();
            }
        }

    }
}
