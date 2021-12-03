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

        // 3277956
        public void Puzzle_2()
        {
            string OxygenRatingBinary = filterForCommon(splittedInput,1, 'M');
            string Co2ScrubberRatingBinary = filterForCommon(splittedInput,0, 'L');

            Console.WriteLine($"Oxygen: {Convert.ToInt32(OxygenRatingBinary, 2)} ({OxygenRatingBinary})");
            Console.WriteLine($"CO2 Scrubbing: {Convert.ToInt32(Co2ScrubberRatingBinary, 2)} ({Co2ScrubberRatingBinary})");
            Console.WriteLine($"{Convert.ToInt32(OxygenRatingBinary, 2)} X {Convert.ToInt32(Co2ScrubberRatingBinary, 2)} = {Convert.ToInt32(Co2ScrubberRatingBinary, 2) * Convert.ToInt32(OxygenRatingBinary, 2)}");

            string filterForCommon(List<string> list, int prefer, char MostOrLeastCommon)
            {
                List<string> filteredList = new List<string>(list);

                for (int i = 0; i < (filteredList.First().Trim().Length); i++)
                {
                    int zeroCount = 0;
                    int oneCount = 0;

                    foreach (string line in filteredList)
                    {
                        int firstNumber = Int32.Parse(line.ElementAt(i).ToString().TrimEnd());

                        if (firstNumber == 1)
                        {
                            oneCount++;
                            continue;
                        }

                        zeroCount++;
                    }

                    if (MostOrLeastCommon == 'M')
                    {
                        if (oneCount > zeroCount) filteredList.RemoveAll(x => x.ElementAt(i) == '0'); // More 1's 
                        if (zeroCount > oneCount) filteredList.RemoveAll(x => x.ElementAt(i) == '1'); // More 0's 
                    } 
                    else if (MostOrLeastCommon == 'L')
                    {
                        if (oneCount < zeroCount) filteredList.RemoveAll(x => x.ElementAt(i) == '0'); // More 0's  
                        if (zeroCount < oneCount) filteredList.RemoveAll(x => x.ElementAt(i) == '1'); // More 1's 
                    }



                    char filterFor = (prefer == 1) ? '0' : '1';
                    if (zeroCount == oneCount) filteredList.RemoveAll(x => x.ElementAt(i) == filterFor); // More 0's 
                    if (filteredList.Count() == 1) break;
                }

                return filteredList.First().Trim();
            }

        } // PZ2
    }
}
