using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2021.Day_1
{
    class Day1
    {
        private readonly string inputString;
        private readonly List<String> splittedInput;

        public Day1()
        {
            inputString = File.ReadAllText(@"C:\Users\Gebruiker\Documents\Vrije Tijd\DEVELOPMENT\AdventOfCode\2021\Day-1\input.txt");
            splittedInput = inputString.Split("\n").ToList();
        }

        // Answer: 1548
        public void Puzzle_1()
        {
            int counter = 0;
            for (int i = 0; i < splittedInput.Count; i++)
            {
                if (i == 0) continue;
                if (Int32.Parse(splittedInput.ElementAt(i)) > Int32.Parse(splittedInput.ElementAt(i - 1))) counter++;
            }

            Console.WriteLine(counter);
        }

        // Answer: 1589
        public void Puzzle_2() 
        {
            int counter = 0;
            int previousSum = 0;
            for (int i = 0; i < splittedInput.Count; i++)
            {
                if (i > 1997) continue; // Out of reach otherwise
                Int32.TryParse(splittedInput.ElementAt(i), out int num1);
                Int32.TryParse(splittedInput.ElementAt(i + 1), out int  num2);
                Int32.TryParse(splittedInput.ElementAt(i + 2), out int num3);

                int sum = num1 + num2 + num3;

                if (previousSum != 0 && sum > previousSum) counter++;

                previousSum = sum;
            }

            Console.WriteLine(counter);
        }
    }
}
