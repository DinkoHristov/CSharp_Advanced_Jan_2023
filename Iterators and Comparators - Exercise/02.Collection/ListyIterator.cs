using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _02.Collection
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private int index = 0;
        private List<T> items;

        public ListyIterator(List<T> items)
        {
            this.items = items;
        }

        public bool Move()
        {
            if (this.index < this.items.Count - 1)
            {
                this.index++;

                return true;
            }

            return false;
        }

        public bool HasNext()
        {
            if (this.index < this.items.Count - 1)
            {
                return true;
            }

            return false;
        }

        public void Print()
        {
            if (this.items.Count <= 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(this.items[this.index]);
        }

        public void PrintAll()
        {
            if (this.items.Count <= 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(string.Join(" ", this.items));
        }

        public IEnumerator<T> GetEnumerator()
        {
           foreach (T item in this.items)
           {
                yield return item;
           }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
