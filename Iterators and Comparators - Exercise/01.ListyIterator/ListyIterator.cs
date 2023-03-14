using System;
using System.Collections.Generic;
using System.Text;

namespace _01.ListyIterator
{
    public class ListyIterator<T>
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
    }
}
