using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2021.Day_2
{
    class Day2
    {
        private readonly string inputString;
        private readonly List<String> splittedInput;

        public Day2()
        {
            inputString = File.ReadAllText(@"C:\Users\Gebruiker\Documents\Vrije Tijd\DEVELOPMENT\AdventOfCode\2021\Day-2\input.txt");
            splittedInput = inputString.Split("\n").ToList();
        }

        // Answer: 1962940
        public void Puzzle_1()
        {
            int depth = 0;
            int horizontal = 0;

            foreach (string line in splittedInput)
            {
                int lastCharValue = Int32.Parse(line.Split(" ")[1]);
                if (line.StartsWith("forward")) horizontal += lastCharValue;
                if (line.StartsWith("up")) depth -= lastCharValue; // Depth gets smaller the higher you go to the surface
                if (line.StartsWith("down")) depth += lastCharValue; // Depth gets bigger the lower you go from the surface
            }

            Console.WriteLine($"Depth: {depth} - Horizontal: {horizontal} - Total: {depth * horizontal}");
        }

        // Answer: 1813664422
        public void Puzzle_2()
        {
            int depth = 0;
            int horizontal = 0;
            int aim = 0;

            // Aim * current Horizontal value = Depth

            foreach (string line in splittedInput)
            {
                int lastCharValue = Int32.Parse(line.Split(" ")[1]);
                if (line.StartsWith("forward"))
                {
                    horizontal += lastCharValue;
                    depth += lastCharValue * aim;
                }
                if (line.StartsWith("up")) aim -= lastCharValue;
                if (line.StartsWith("down")) aim += lastCharValue; 
            }

            Console.WriteLine($"Depth: {depth} - Horizontal: {horizontal} - Total: {depth * horizontal}");
        }
    }
}
