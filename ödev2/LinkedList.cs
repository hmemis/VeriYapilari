using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VY13253039Odev2
{
    class LinkedList<T>
    {
        Node<Member> mHead;

        public void LessonList(string temp)  //Bölümü verilen kişinin ders listesini bulmak için kullanılır.
        {

            Node<Member> iterator = mHead;

            while (iterator != null)
            {
                if (iterator.Value.Section == temp)
                {
                    Console.WriteLine("Bölümü Verilen Kişinin Ders Listesi");

                    while (iterator.Lesson != null)
                    {
                        Console.WriteLine(iterator.Lesson.Value.LessonName);
                        iterator.Lesson = iterator.Lesson.Lesson;

                    }
                }

                iterator = iterator.Next;
            }

        }

        public void List(string temp)         //ismi verilen kişinin aldığı dersleri ve not ortalamasını bulmak için kullanılır.
        {
            Node<Member> iterator1 = mHead;
            while (iterator1 != null)
            {
                if (iterator1.Value.Name == temp)
                {
                    double size = 0;
                    double toplam = 0;
                    double sonuc = 0;
                    Console.WriteLine("İsmi Verilen Kişinin Aldığı Dersler");
                    while (iterator1.Lesson != null)
                    {

                        Console.WriteLine(iterator1.Lesson.Value.LessonName);
                        toplam += iterator1.Lesson.Value.Vize + iterator1.Lesson.Value.Final;    //kişinin vize ve final değeri toplam değerine atılır.
                        size = size + 2;                    //her kişide vize ve final olduğu iç,n sayaç her zaman 2 artar.
                        iterator1.Lesson = iterator1.Lesson.Lesson;

                    }
                    
                    Console.WriteLine("İsmi Verilen Kişinin Not Ortalaması");
                    sonuc = toplam / size;
                    Console.WriteLine(sonuc);

                }
                iterator1 = iterator1.Next;
            }
        }


       

        public void List2(string bilgi)      //ismi verilen dersin ortalamasını verir.
        {
            Node<Member> iterator = mHead;
            float toplam = 0;
            int size = 0;
            float sonuc = 0;

            while (iterator != null)
            {
                while (iterator.Lesson != null)
                {
                    Console.WriteLine("İsmi Verilen Dersin Ortalaması");
                    if (iterator.Lesson.Value.LessonName.CompareTo(bilgi) == 0)
                    {
                        toplam += iterator.Lesson.Value.Vize + iterator.Lesson.Value.Final;
                        size = size + 2;
                    }
                    iterator.Lesson = iterator.Lesson.Lesson;
                }
                iterator = iterator.Next;
            }
            sonuc = toplam / size;
            Console.WriteLine(sonuc);

        }

        public void List3(string temp)       //ismi verilen ders için ortalaması en yüksek olan öğrencinin bilgilerini verir.
        {

            int enbuyuk = 0;
            int sonuc = 0;
            int sonuc1 = 0;
            Node<Member> iterator = mHead;
            while (iterator != null)
            {
                while (iterator.Lesson != null)
                {
                    if (iterator.Lesson.Value.LessonName.CompareTo(temp) == 0)
                    {
                        sonuc = (iterator.Lesson.Value.Vize + iterator.Lesson.Value.Final) / 2;
                        if (sonuc.CompareTo(enbuyuk) == 1)
                        {
                            enbuyuk = sonuc;
                        }
                    }
                    iterator.Lesson = iterator.Lesson.Lesson;
                }
                iterator = iterator.Next;
            }

            Node<Member> iterator1 = mHead;
            while (iterator1 != null)
            {

                while (iterator1.Lesson != null)
                {
                    if (iterator1.Lesson.Value.LessonName.CompareTo(temp) == 0)
                    {
                        Console.WriteLine("İsmi Verilen Ders İçin En Yüksek Not Ortalaması Olan Öğrencinin Bilgileri");
                        sonuc1 = (iterator.Lesson.Value.Vize + iterator.Lesson.Value.Final) / 2;
                        if (enbuyuk.CompareTo(sonuc1) == 0)
                        {
                            Console.WriteLine(iterator1.Value.Name);
                            Console.WriteLine(iterator1.Value.Surname);
                            Console.WriteLine(iterator1.Value.Section);

                            Console.WriteLine(iterator1.Lesson.Value.LessonName);
                            Console.WriteLine(iterator1.Lesson.Value.Vize);
                            Console.WriteLine(iterator1.Lesson.Value.Final);
                            break;
                        }
                    }

                    iterator1.Lesson = iterator1.Lesson.Lesson;

                }
                iterator1 = iterator1.Next;

            }

        }


        public void memberlessonekle(Member m, Lesson l)
        {
            Node<Member> yenikişi = new Node<Member>(m);
            Node<Lesson> yeniders = new Node<Lesson>(l);
            if (Search(m))
            {
                Node<Member> iterator = mHead;
                while (iterator != null)
                {
                   

                    if (iterator.Value.Name.CompareTo(yenikişi.Value.Name) == 0 && iterator.Value.Surname.CompareTo(yenikişi.Value.Surname) == 0 && iterator.Value.Section.CompareTo(yenikişi.Value.Section) == 0)
                    {

                        Node<Lesson> NewNode = iterator.Lesson;

                        while (NewNode.Lesson != null)
                        {
                            NewNode = NewNode.Lesson;
                        }
                        NewNode.Lesson = yeniders;
                    }
                    iterator = iterator.Next;
                }

            }
            else
            {
                if (mHead == null)
                {
                    mHead = yenikişi;
                    yenikişi.Lesson = yeniders;

                }
                else
                {
                    Node<Member> iterator = mHead;
                    while (iterator.Next != null)
                    {
                        iterator = iterator.Next;

                    }
                    iterator.Next = yenikişi;
                    yenikişi.Lesson = yeniders;
                }
            }

        }

        public bool Search(Member m)
        {
            Node<Member> iterator = mHead;
            while (iterator != null)
            {
                if (iterator.Value.Name.CompareTo(m.Name) == 0 && iterator.Value.Surname.CompareTo(m.Surname) == 0 && iterator.Value.Section.CompareTo(m.Section) == 0)
                {
                    return true;
                }
                iterator = iterator.Next;
            }

            return false;
        }


        public bool ControlName(string temp)
        {
            Node<Member> iterator = mHead;

            while (iterator != null)
            {
                if (iterator.Value.Name.CompareTo(temp) == 0)
                {
                    return true;
                }
                iterator = iterator.Next;

            }
            return false;

        }

        public bool ControlSection(string temp)
        {
            Node<Member> iterator = mHead;

            while (iterator != null)
            {
                if (iterator.Value.Section == temp)
                {
                    return true;
                }
                iterator = iterator.Next;

            }
            return false;

        }


        public bool ControlLessonName(string temp)
        {
            Node<Member> iterator = mHead;

            while (iterator != null)
            {
                while (iterator.Lesson != null)
                {
                    if (iterator.Lesson.Value.LessonName == temp)
                    {
                        return true;
                    }
                    iterator.Lesson = iterator.Lesson.Lesson;
                }
                iterator = iterator.Next;

            }
            return false;

        }


        public void display()
        {
            Node<Member> iterator = mHead;

            while (iterator != null)
            {

                Console.WriteLine(iterator.Value.Name);
                Console.WriteLine(iterator.Value.Surname);
                Console.WriteLine(iterator.Value.Section);

                while (iterator.Lesson != null)
                {

                    Console.WriteLine(iterator.Lesson.Value.LessonName);
                    Console.WriteLine(iterator.Lesson.Value.Vize);
                    Console.WriteLine(iterator.Lesson.Value.Final);

                    iterator.Lesson = iterator.Lesson.Lesson;
                } iterator = iterator.Next;
            }
        }







    }
}
