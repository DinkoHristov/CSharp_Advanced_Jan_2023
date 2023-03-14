using System;
using System.Collections.Generic;
using System.Text;

namespace _04.GenericSwapMethodInteger
{
    public class Box<T>
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
    }
}
