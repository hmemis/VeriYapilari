using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VY13253039Odev2
{
    class Node<T>
    {
        T value;
        Node<T> next;
        Node<Lesson> lesson;

        public Node<Lesson> Lesson
        {
            get { return lesson; }
            set { lesson = value; }
        }

        public Node<T> Next
        {
            get { return next; }
            set { next = value; }
        }


        public T Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
        public Node(T val)
        {
            Value = val;
            Next = null;
            Lesson = null;


        }
    }
}
