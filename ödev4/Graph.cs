using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _13253039HW4
{
    class Graph
    {
        Vertex vertexHead;
        public void AddVertex(string vertexId)
        {
            if (!Search(vertexId))
            {
                if (vertexHead == null)
                    vertexHead = new Vertex(vertexId);
                else
                {
                    Vertex iterator = vertexHead;
                    while (iterator.Next != null)
                        iterator = iterator.Next;
                    iterator.Next = new Vertex(vertexId);
                }
            }
        }


        public void AddEdge(string sourceId, string destId)
        {
            Vertex sourceVertex = Find(sourceId);
            if (sourceVertex != null && Search(destId))
            {
                if (sourceVertex.EdgeLink == null)
                    sourceVertex.EdgeLink = new Edge(destId);
                else
                {
                    Edge iterator = sourceVertex.EdgeLink;
                    while (iterator.Next != null)
                        iterator = iterator.Next;
                    iterator.Next = new Edge(destId);
                }
            }
            else
            {
                Console.WriteLine("Hata!!! Source veya destination yok.");
            }

        }


        public bool Search(string vertexId)
        {
            Vertex iterator = vertexHead;
            while (iterator != null)
            {
                if (iterator.VertexId == vertexId)
                    return true;
                iterator = iterator.Next;
            }
            return false;
        }

        public Vertex Find(string vertexId)
        {
            Vertex iterator = vertexHead;
            while (iterator != null)
            {
                if (iterator.VertexId == vertexId)
                    return iterator;
                iterator = iterator.Next;
            }
            return null;

        }

        public void display()
        {

            Console.WriteLine("Graph:");
            Vertex vertexIterator = vertexHead;
            while (vertexIterator != null)
            {
                Console.Write(vertexIterator.VertexId + ":");
                Edge edgeIterator = vertexIterator.EdgeLink;
                while (edgeIterator != null)
                {
                    Console.Write(edgeIterator.VertexId + "-");
                    edgeIterator = edgeIterator.Next;
                }

                Console.WriteLine();
                vertexIterator = vertexIterator.Next;
            }
            Console.WriteLine();
        }


        public void buildAdjMatrix(int vertexsayısı)  //matris oluşumu ve gösterimi
        {
            int[,] adjMatrix = new int[vertexsayısı, vertexsayısı];
            Vertex iterator = vertexHead;
            int a = 0;
            while (iterator != null)
            {

                Edge edgeİterator = iterator.EdgeLink;
                while (edgeİterator != null)
                {

                    adjMatrix[a, Int32.Parse(edgeİterator.VertexId)] = 1;   //vertexId nin edgelerinin olduğu kısımlara 1 atandı.    

                    edgeİterator = edgeİterator.Next;
                }
                a++;
                iterator = iterator.Next;
            }
            Console.WriteLine();
            Console.Write("       ");
            for (int i = 0; i < vertexsayısı; i++)
            {
                Console.Write("{0}  ", (0 + i));

            }

            Console.WriteLine();

            for (int i = 0; i < vertexsayısı; i++)
            {
                Console.Write("{0}   [ ", (0 + i));

                for (int j = 0; j < vertexsayısı; j++)
                {
                    Console.Write(" {0} ", adjMatrix[i, j]);         //adjmatrisin 1 atanan yerleri 1 diğer taraflara 0 oldu
                }
                Console.Write(" ]\r\n");
            }
            Console.Write("\r\n");
        }



        public int countIndegree(string vertexId)       //graph kullanılarak 
        {
            Vertex vertexIterator = vertexHead;
            Edge edgeIterator;
            int count = 0;

            while (vertexIterator != null)
            {
                edgeIterator = vertexIterator.EdgeLink;
                while (edgeIterator != null)
                {
                    if (edgeIterator.VertexId == vertexId)
                        count++;
                    edgeIterator = edgeIterator.Next;
                }
                vertexIterator = vertexIterator.Next;
            }

            return count;

        }




        private int countIndegree2(string vertexId, int vertexsayısı)    //matris kullanılarak
        {

            int[,] adjMatrix = new int[vertexsayısı, vertexsayısı];
            Vertex iterator = vertexHead;
            int a = 0;
            while (iterator != null)
            {

                Edge edgeİterator = iterator.EdgeLink;
                while (edgeİterator != null)
                {

                    adjMatrix[a, Int32.Parse(edgeİterator.VertexId)] = 1;

                    edgeİterator = edgeİterator.Next;

                }
                a++;
                iterator = iterator.Next;
            }
            Vertex vertexIterator = vertexHead;
            Edge edgeIterator;

            int count2 = 0;
            for (int i = 0; i < vertexsayısı; i++)         //
            {
                int count = 0;                               //matriste 1 olan verlerin vertexIdleri bulundu
                for (int j = 0; j < vertexsayısı; j++)
                {
                    if (adjMatrix[i, j] == 0)
                    {
                        count++;

                    }                                       //
                    else if (adjMatrix[i, j] == 1)
                    {
                        adjMatrix[i, j] = count;

                        count++;

                    }
                }

            }
            while (vertexIterator != null)          //indegreesi bulunuyor
            {
                edgeIterator = vertexIterator.EdgeLink;
                while (edgeIterator != null)
                {
                    if (adjMatrix[Int32.Parse(vertexIterator.VertexId), Int32.Parse(edgeIterator.VertexId)] == Int32.Parse(vertexId))
                    {

                        count2++;
                    }


                    edgeIterator = edgeIterator.Next;
                }

                vertexIterator = vertexIterator.Next;
            }
            return count2;

        }

        public void TopolojicalSorting(int vertexsayısı)    //graph kullanılarak
        {
            Console.WriteLine("Graph Kullanılarak Yapılan Topolojical Sorting:");
            Vertex iterator = vertexHead;
            int[] dizi = new int[vertexsayısı];          //indegresi 0 olanların ekleneceği bir dizi oluşturuldu
            int j = 0;
            for (int i = 0; i < vertexsayısı; i++)
            {
                while (iterator != null)
                {
                    if (countIndegree(iterator.VertexId) == 0)
                    {
                        if (i == 0)
                        {

                            dizi[j] = Int32.Parse(iterator.VertexId);        //ilk olarak indegresi 0 olan eklendi
                            j++;

                        }
                        else
                        {
                            if (j == vertexsayısı)
                            {
                                break;
                            }
                            else
                            {
                                if (Array.IndexOf(dizi, Int32.Parse(iterator.VertexId)) == -1)       //ikinci döngüde eğer eklenen eleman dizinin içinde yok ise diziye ekleniyor
                                {
                                    dizi[j] = Int32.Parse(iterator.VertexId);
                                    j++;
                                }
                            }
                        }

                        if (iterator.EdgeLink != null)        //eklenen vertexId nin edgelink 0 olur
                            iterator.EdgeLink = null;
                    }

                    iterator = iterator.Next;
                }
                iterator = vertexHead;
            }

            for (int k = 0; k < vertexsayısı; k++)          //dizi görüntülenir
                Console.WriteLine(dizi[k]);
        }





        public void TopolojicalSorting2(int vertexsayısı)  //matris kullanılarak 
        {
            Console.WriteLine("Adjacency Matris Kullanılarak Yapılan Topoloji Sorting:");
            Vertex iterator = vertexHead;
            int[] dizi = new int[vertexsayısı];
            int j = 0;
            for (int i = 0; i < vertexsayısı; i++)
            {
                while (iterator != null)
                {
                    if (countIndegree2(iterator.VertexId, vertexsayısı) == 0)
                    {
                        if (i == 0)
                        {

                            dizi[j] = Int32.Parse(iterator.VertexId);
                            j++;

                        }
                        else
                        {
                            if (j == vertexsayısı)
                            {
                                break;
                            }
                            else
                            {
                                if (Array.IndexOf(dizi, Int32.Parse(iterator.VertexId)) == -1)
                                {
                                    dizi[j] = Int32.Parse(iterator.VertexId);
                                    j++;
                                }
                            }
                        }

                        if (iterator.EdgeLink != null)
                            iterator.EdgeLink = null;
                    }

                    iterator = iterator.Next;
                }
                iterator = vertexHead;
            }

            for (int k = 0; k < vertexsayısı; k++)
                Console.WriteLine(dizi[k]);
        }

    }
}
