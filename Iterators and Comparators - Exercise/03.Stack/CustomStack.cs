using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private int initialCapacity = 4;
        private T[] items;

        public CustomStack()
        {
            this.items = new T[initialCapacity];
        }

        public int Count { get; private set; }

        public void Push(T item)
        {
            if (Count == this.items.Length)
            {
                Resize();
            }

            this.items[Count] = item;

            this.Count++;
        }

        public T Pop()
        {
            if (this.Count <= 0)
            {
                throw new IndexOutOfRangeException("No elements");
            }

            T removedItem = this.items[this.Count - 1];

            this.Count--;

            return removedItem;
        }

        private void Resize()
        {
            T[] copy = new T[this.items.Length * 2];

            for (int i = 0; i < this.Count; i++)
            {
                copy[i] = this.items[Count];
            }

            this.items = copy;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
