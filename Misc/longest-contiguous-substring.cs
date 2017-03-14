using System;
using System.Linq;
using System.IO;

namespace CodeEval
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = File.OpenText(args[0]))
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (null == line)
                        continue;
                    // do something with line
                    string[] inputs = line.Split(';');
                    Console.WriteLine(findMaxSubstringLength(inputs[0], inputs[1]));
                }


            
        }

        public static string findMaxSubstringLength(string str1, string str2)
        {
            if (str1.Length == 0 || str2.Length == 0)
                return "";

            int maxLength = 0;
            int currLength = 0;
            int startingCharPosition = 0; // store location where longest substring starts
            // don't need to explicitly convert these to charArray in C# (we can compare str1[i] == str2[j]), 
            // but doing so will make it easier when I convert this to java
            char[] firstWord = str1.ToArray();
            char[] secondWord = str2.ToArray();

            for (int i = 0; i < firstWord.Length; i++)
            {
                for (int j = 0; j < secondWord.Length; j++)
                {
                    if (firstWord[i] == secondWord[j])
                    {
                        while (i + currLength < firstWord.Length && j + currLength < secondWord.Length && // stay inside the bounds of the array
                            firstWord[i + currLength] == secondWord[j + currLength]) // find maximum length of diagonal 
                        {
                            currLength++;
                            if (currLength > maxLength)
                            {
                                maxLength = currLength;
                                // added: we don't want to return maxLength, we only care about its position
                                startingCharPosition = i; // only change position when new maxLength is set
                            }
                        }
                    }
                }
            }

            return new string(firstWord.Skip(startingCharPosition).Take(maxLength).ToArray());
        }
    }
}
