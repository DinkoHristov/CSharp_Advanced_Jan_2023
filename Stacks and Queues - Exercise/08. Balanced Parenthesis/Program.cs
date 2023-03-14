using System;
using System.Collections.Generic;

namespace _08._Balanced_Parenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string parenthesis = Console.ReadLine();

            Stack<char> stack = new Stack<char>();

            bool isEqual = true;
            foreach (char currBracket in parenthesis)
            {
                switch (currBracket)
                {
                    case '(':
                    case '[':
                    case '{':
                        stack.Push(currBracket);
                        break;

                    case ')':
                        if (stack.Count == 0 || stack.Pop() != '(')
                        {
                            isEqual = false;
                        }
                        break;


                    case ']':
                        if (stack.Count == 0 || stack.Pop() != '[')
                        {
                            isEqual = false;
                        }
                        break;


                    case '}':
                        if (stack.Count == 0 || stack.Pop() != '{')
                        {
                            isEqual = false;
                        }
                        break;
                }
            }

            if (isEqual)
            {
                if (stack.Count <= 0)
                {
                    Console.WriteLine("YES");
                }
                else
                {
                    Console.WriteLine("NO");
                }
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
