using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counting_Sheep
{
    class Program
    {       
        // Counting Sheep
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Solve();
        }

        public void Solve()
        {
            // read input from a file
            int counter = 0;
            string line;
            byte T = 0;
            List<int> inputList = new List<int>();

            string fileName = @"D:\Sameer\Sameer\CodeJam\A-large.in";
            System.IO.StreamReader file = new System.IO.StreamReader(fileName);
            while ((line = file.ReadLine()) != null)
            {
                if (counter == 0)
                {
                    T = byte.Parse(line);
                }
                else
                {
                    inputList.Add(int.Parse(line));
                }
                counter++;
            }

            file.Close();

            List<string> outputList = new List<string>(); 

            // call function to solve on each input
            for (byte i = 1; i <= T; i++)
            {
                outputList.Add("Case #" + i +": " + FindLastNumber(inputList[i - 1]));
            }

            string outputFile = @"D:\Sameer\Sameer\CodeJam\Output.txt";
            using (System.IO.StreamWriter ofile = new System.IO.StreamWriter(outputFile, true))
            {
                foreach (string s in outputList)
                {
                    ofile.WriteLine(s);
                }
            }
        }

        private string FindLastNumber(int N)
        {
            if(N == 0)
            {
                return "INSOMNIA";
            }

            string output = string.Empty;
            int i = 1, num;
            Dictionary<byte, bool> digitsDic = new Dictionary<byte, bool>();
            AddDictionaryItems(ref digitsDic);

            for(;;)
            {
                num = N * i;
                UpdateDictionary(num, ref digitsDic);
                if(!digitsDic.ContainsValue(false))
                {
                    output = num.ToString();
                    break;
                }
                i++;
            }
            return output;
        }

        private void UpdateDictionary(int Num, ref Dictionary<byte, bool> DigitsDic)
        {
            int num = Num, temp;
            while(num >= 1)
            {
                temp = num % 10;
                DigitsDic[DigitsDic.ElementAt(temp).Key] = true;
                num = num / 10;
            }
        }

        private void AddDictionaryItems(ref Dictionary<byte, bool> DigitsDic)
        {
            DigitsDic.Add(0, false);
            DigitsDic.Add(1, false);
            DigitsDic.Add(2, false);
            DigitsDic.Add(3, false);
            DigitsDic.Add(4, false);
            DigitsDic.Add(5, false);
            DigitsDic.Add(6, false);
            DigitsDic.Add(7, false);
            DigitsDic.Add(8, false);
            DigitsDic.Add(9, false);
        }

    }
}


/*

        Bleatrix Trotter the sheep has devised a strategy that helps her fall asleep faster. First, she picks a number N. Then she starts naming N, 2 × N, 3 × N, and so on. Whenever she names a number, she thinks about all of the digits in that number. She keeps track of which digits (0, 1, 2, 3, 4, 5, 6, 7, 8, and 9) she has seen at least once so far as part of any number she has named. Once she has seen each of the ten digits at least once, she will fall asleep.

Bleatrix must start with N and must always name (i + 1) × N directly after i × N. For example, suppose that Bleatrix picks N = 1692. She would count as follows:

N = 1692. Now she has seen the digits 1, 2, 6, and 9.
2N = 3384. Now she has seen the digits 1, 2, 3, 4, 6, 8, and 9.
3N = 5076. Now she has seen all ten digits, and falls asleep.
What is the last number that she will name before falling asleep? If she will count forever, print INSOMNIA instead.

Input

The first line of the input gives the number of test cases, T. T test cases follow. Each consists of one line with a single integer N, the number Bleatrix has chosen.

Output

For each test case, output one line containing Case #x: y, where x is the test case number (starting from 1) and y is the last number that Bleatrix will name before falling asleep, according to the rules described in the statement.

Limits

1 ≤ T ≤ 100.
Small dataset

0 ≤ N ≤ 200.
Large dataset

0 ≤ N ≤ 106


        */
