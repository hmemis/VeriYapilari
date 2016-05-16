using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _13253039HW4
{
    class Edge
    {
        string vertexId;

        public string VertexId
        {
            get { return vertexId; }
            set { vertexId = value; }
        }
        Edge next;

        internal Edge Next
        {
            get { return next; }
            set { next = value; }
        }
        public Edge(string vertexId)
        {
            VertexId = vertexId;
        }


    }
}

