using System;
using System.Collections.Generic;
using System.Text;

namespace _07.Tuple
{
    public class CustomTuple<T1, T2>
    {
        private T1 item1;
        private T2 item2;

        public CustomTuple(T1 item1, T2 item2)
        {
            this.item1 = item1;
            this.item2 = item2;
        }

        public override string ToString()
        {
            return $"{this.item1} -> {this.item2}";
        }
    }
}
