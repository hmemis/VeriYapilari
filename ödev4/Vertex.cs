using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _13253039HW4
{
    class Vertex
    {
        string vertexId;

        public string VertexId
        {
            get { return vertexId; }
            set { vertexId = value; }
        }
        Edge edgeLink;

        internal Edge EdgeLink
        {
            get { return edgeLink; }
            set { edgeLink = value; }
        }
        Vertex next;

        internal Vertex Next
        {
            get { return next; }
            set { next = value; }
        }
        public Vertex(string vertexId)
        {
            VertexId = vertexId;
        }
    }
}
