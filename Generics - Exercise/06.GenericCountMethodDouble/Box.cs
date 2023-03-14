using System;
using System.Collections.Generic;
using System.Text;

namespace _06.GenericCountMethodDouble
{
    public class Box<T> where T : IComparable<T>
    {
        private List<T> boxes;

        public Box()
        {
            this.boxes = new List<T>();
        }

        public void Add(T item)
        {
            this.boxes.Add(item);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            foreach (var box in boxes)
            {
                result.AppendLine($"{typeof(T)}: {box}");
            }

            return result.ToString().TrimEnd();
        }

        public void SwapBoxes(int boxOneIndex, int boxTwoIndex)
        {
            T temp = this.boxes[boxOneIndex];
            this.boxes[boxOneIndex] = this.boxes[boxTwoIndex];
            this.boxes[boxTwoIndex] = temp;
        }

        public int Count(T itemToCompare)
        {
            int count = 0;

            foreach (T box in this.boxes)
            {
                if (box.CompareTo(itemToCompare) > 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
