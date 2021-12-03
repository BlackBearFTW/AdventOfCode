using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2021.Day_3
{
    class Day3
    {
        private readonly string inputString;
        private readonly List<String> splittedInput;

        public Day3()
        {
            inputString = File.ReadAllText(@"C:\Users\Gebruiker\Documents\Vrije Tijd\DEVELOPMENT\AdventOfCode\2021\Day-3\input.txt");
            splittedInput = inputString.Split("\n").ToList();
        }

        // 2498354
        public void Puzzle_1()
        {
            string gammaRateBinary = "";
            string epsilonRateBinary = "";

            for (int i = 0; i < (splittedInput.ElementAt(0).Length - 1); i++)
            {

                string currentColumnString = "";

                foreach (string line in splittedInput)
                {
                    currentColumnString += line.ElementAt(i);
                }

                char mostCommonCharacter = currentColumnString.GroupBy(x => x).OrderByDescending(x => x.Count()).First().Key;

                gammaRateBinary += mostCommonCharacter;

            }

            foreach (char bit in gammaRateBinary) epsilonRateBinary += bit == '0' ? "1" : "0";

            int gammaRate = Convert.ToInt32(gammaRateBinary, 2);
            int epsilonRate = Convert.ToInt32(epsilonRateBinary, 2);

            Console.WriteLine($"Gamma Rate: {gammaRate} ({gammaRateBinary})");
            Console.WriteLine($"Epsilon Rate: {epsilonRate} ({epsilonRateBinary})");
            Console.WriteLine($"{gammaRate} X {epsilonRate} = {gammaRate * epsilonRate}");
        }

        public void Puzzle_2()
        {

        }
    }
}
