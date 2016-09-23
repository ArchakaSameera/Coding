using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevengeOfThePancakes
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Solve();
        }

        public void Solve()
        {
            // read input from a file
            byte counter = 0;
            string line;
            byte T = 0;
            List<string> inputList = new List<string>();

            string fileName = @"D:\Sameer\Sameer\CodeJam\RevengeOfThePancakes\B-large.in";
            System.IO.StreamReader file = new System.IO.StreamReader(fileName);
            while ((line = file.ReadLine()) != null)
            {
                if (counter == 0)
                {
                    T = byte.Parse(line);
                }
                else
                {
                    inputList.Add(line);
                }
                counter++;
            }

            file.Close();

            List<string> outputList = new List<string>();

            // call function to solve on each input
            for (byte i = 1; i <= T; i++)
            {
                outputList.Add("Case #" + i + ": " + FindNumberOfFlippings(inputList[i - 1]));
            }

            string outputFile = @"D:\Sameer\Sameer\CodeJam\RevengeOfThePancakes\Output.txt";
            using (System.IO.StreamWriter ofile = new System.IO.StreamWriter(outputFile, true))
            {
                foreach (string s in outputList)
                {
                    ofile.WriteLine(s);
                }
            }
        }

        private byte FindNumberOfFlippings(string S)
        {
            byte count = 0;
            int length = S.Length;

            if (length == 1)
            {
                if (S[0].Equals('-'))
                {
                    count = 1;
                }
            }
            else
            {
                for (byte i = 1; i < length; i++)
                {
                    if (i == length - 1)
                    {
                        if (S[i].Equals('-'))
                        {
                            count++;
                        }
                    }
                    if (!S[i].Equals(S[i - 1]))
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
