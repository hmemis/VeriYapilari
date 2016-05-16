using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace VY13253039Odev2
{
    class Test
    {
        static void Main(string[] args)
        {
            LinkedList<string> objj = new LinkedList<string>();

            StreamReader FileRead;

            FileRead = File.OpenText(@"C:\ogrenci.txt");
            string array1;
            string[] array;
            char[] sembol = new char[] { ' ' };

            while ((array1 = FileRead.ReadLine()) != null)
            {
                array = array1.Split(sembol, StringSplitOptions.RemoveEmptyEntries);
                if (array1 != "")
                {
                    Member m = new Member(array[0], array[1], array[2]);
                    Lesson l = new Lesson(array[3], Int32.Parse(array[4]), Int32.Parse(array[5]));
                    objj.memberlessonekle(m, l);
                }
            }



            StreamReader FileReadd;
            FileReadd = File.OpenText(@"C:\islem.txt");
            string array2;
            string[] arrayy;
            char[] sembol2 = new char[] { ' ' };

            while ((array2 = FileReadd.ReadLine()) != null)    //değerleri satır satır parçalıyoruz
            {
                arrayy = array2.Split(sembol2, StringSplitOptions.RemoveEmptyEntries);  //daha sonra boşluklara göre parçalıyoruz.
                if (array2 != "")        //okunan değer boşluk ise o satır atlanıyor
                {

                    if (objj.ControlName(arrayy[0]))
                    {
                        objj.List(arrayy[0]);
                        Console.WriteLine();
                        Console.WriteLine();

                    }
                    else if (objj.ControlSection(arrayy[0]))
                    {
                        objj.LessonList(arrayy[0]);
                        Console.WriteLine();
                        Console.WriteLine();
                    }
                    else if (objj.ControlLessonName(arrayy[0]))
                    {
                        objj.List2(arrayy[0]);
                        objj.List3(arrayy[0]);
                        Console.WriteLine();
                        Console.WriteLine();

                    }
                }
            }

        }

    }
}

        
  
