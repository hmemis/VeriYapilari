using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C13253039HW1
{
    class StringOp
    {
        public string[] seperate(string exp)
        {
            char[] semboller = new char[] { '<' };
            string[] array = exp.Split(semboller, StringSplitOptions.RemoveEmptyEntries);
            int size = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].StartsWith("!DOCTYPE html") || array[i].StartsWith("img") || array[i].StartsWith("br") || array[i].StartsWith("br/"))
                {
                    size++;            
                }
            }

            string[] tagarray = new string[array.Length - size];     //tempstackte bulunması istenmeyen dizileri çıkarıp kalan boyut kadar yeni bir tagarray oluşturulur.
            int count = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].StartsWith("!DOCTYPE html") || array[i].StartsWith("img") || array[i].StartsWith("br") || array[i].StartsWith("br/"))
                { }
                else if (array[i].StartsWith("/a") || array[i].StartsWith("/p") || array[i].StartsWith("/b"))
                {
                    array[i] = array[i].Substring(0, 2);   
                    array[i] = array[i].Substring(1);     
                    tagarray[count++] = array[i];
                }

                else if (array[i].StartsWith("/"))
                {
                    array[i] = array[i].Substring(0, 3);
                    array[i] = array[i].Substring(1);      // elemanın başında "/ " olduğu için 1. indexten  başlayarak yazılır.
                    tagarray[count++] = array[i];
                }

                else if (array[i].StartsWith("a") || array[i].StartsWith("p") || array[i].StartsWith("b"))
                {
                    array[i] = array[i].Substring(0, 1);
                    tagarray[count++] = array[i];
                }

                else
                {
                    array[i] = array[i].Substring(0, 2);
                    tagarray[count++] = array[i];
                }
            }

            return tagarray;
        }
    }
}

