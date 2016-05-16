//Hilal MEMİŞ
//13253039
//HW4


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace _13253039HW4
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph myGraph = new Graph();
            StreamReader reader = new StreamReader(@"C:\graph.txt");
            string[] lines = reader.ReadToEnd().Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);//Dosyanin tamamini okuyup satirlara bolme
            //Gorulmeyen karakterler olan \n \r ye gore parcalanip bos satirlar cikarilir.

            int numberOfVertex = 0;
            int.TryParse(lines[0], out numberOfVertex);//İlk satirda sayi yoksa numberofVertex 0 kalacagi icin vertex ekleme yapmaz.

            for (int i = 0; i < numberOfVertex; i++)//Ilk satirdaki deger kadar vertex ekleme
                myGraph.AddVertex(i.ToString());


            for (int i = 1; i < lines.Length; i++)// Satirlar (Ilk satir haric)
            {
                string sourceVertexId = lines[i].Substring(0, lines[i].IndexOf(" "));//ilk boşluğa kadar olan kisim
                string[] edges = lines[i].Substring(lines[i].IndexOf(" ") + 1).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);//ilk boşluktan sonraki kisimlari bosluga gore parcalar, bos elemanlari cikarir
                //1     2 gibi arada birden cok bosluk olursa edges[j] "" olabilir. Bu komut onlari cikarmaktadir.
                for (int j = 0; j < edges.Length; j++)
                {
                    myGraph.AddEdge(sourceVertexId, edges[j]);
                   
                }

            }
            myGraph.buildAdjMatrix(Int32.Parse(lines[0]));
          myGraph.TopolojicalSorting(Int32.Parse(lines[0]));

            for (int i = 1; i < lines.Length; i++)
            {
                string sourceVertexId = lines[i].Substring(0, lines[i].IndexOf(" "));
                string[] edges = lines[i].Substring(lines[i].IndexOf(" ") + 1).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
               
                for (int j = 0; j < edges.Length; j++)
                {
                    myGraph.AddEdge(sourceVertexId, edges[j]);

                }
            }
            myGraph.TopolojicalSorting2(Int32.Parse(lines[0]));

        }
        
        }
 
}
