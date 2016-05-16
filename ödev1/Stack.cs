using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C13253039HW1
{
    class Stack<T>
    {
        T[] values;
        int top;
        public Stack(int size)
        {
            values = new T[size];
            top = -1;
        }
        public bool IsFull()
        {
            return top == values.Length - 1;
        }
        public bool IsEmpty()
        {
            return top == -1;
        }
        public void Push(T val)
        {
            if (!IsFull())
                values[++top] = val;
        }
        public T Pop()
        {
            if (!IsEmpty())
            {
                T temp = values[top--];

                return temp;
            }
            else
                return default(T);
        }

    }
}
