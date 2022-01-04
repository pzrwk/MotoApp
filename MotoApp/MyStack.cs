using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoApp
{
    internal class MyStack<T>
    {
        private readonly T[] _items;
        private int currentIndex = -1;
        public MyStack() => _items = new T[5];
        public int count => currentIndex + 1;

        public void Push(T item) => _items[++currentIndex] = item;
        public T Pop() => _items[currentIndex--];
    }
}
