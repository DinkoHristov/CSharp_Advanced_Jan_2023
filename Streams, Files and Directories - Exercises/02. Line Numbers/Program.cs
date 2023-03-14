namespace LineNumbers
{
    using System;
    using System.IO;
    using System.Linq;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"../../../text.txt";
            string outputFilePath = @"../../../output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    string line = string.Empty;

                    int lineCount = 0;
                    while (!reader.EndOfStream)
                    {
                        line = reader.ReadLine();
                        int letters = LettersCount(line);
                        int punctuationalCount = PunctuationalMarksCount(line);

                        writer.WriteLine($"Line {++lineCount}: {line} ({letters}) ({punctuationalCount})");
                    }
                } 
            }
        }

        private static int LettersCount(string line)
        {
            int lettersCount = 0;

            foreach (char currChar in line)
            {
                if (char.IsLetter(currChar))
                {
                    lettersCount++;
                }    
            }

            return lettersCount;
        }

        private static int PunctuationalMarksCount(string line)
        {
            int punctuationalMarksCount = 0;
            char[] marks = { '_', '-', ',', '\'', '!', '.', '?'};

           foreach (char currChar in line)
           {
               if (marks.Contains(currChar))
               {
                   punctuationalMarksCount++;
               }
           }
            
            return punctuationalMarksCount;
        }
    }
}
