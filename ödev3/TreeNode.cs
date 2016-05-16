using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication5
{
    class TreeNode<T>
    {
        T value;

        public T Value
        {
            get { return value; }
            set { this.value = value; }
        }
        TreeNode<T> left;

        internal TreeNode<T> Left
        {
            get { return left; }
            set { left = value; }
        }
        TreeNode<T> right;

        internal TreeNode<T> Right
        {
            get { return right; }
            set { right = value; }
        }
        T maxValue;

        public T MaxValue
        {
            get { return maxValue; }
            set { maxValue = value; }
        }
        T minValue;

        public T MinValue
        {
            get { return minValue; }
            set { minValue = value; }
        }
        T parent;

        public T Parent
        {
            get { return parent; }
            set { parent = value; }
        }


        public TreeNode(T val)
        {
            Value = val;
            
        }

    }
}
