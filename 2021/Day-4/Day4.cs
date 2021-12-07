using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2021.Day_4
{
    class Day4
    {
        private readonly string inputString;
        private readonly List<String> splittedInput;

        public Day4()
        {
            inputString = File.ReadAllText(@"C:\Users\Gebruiker\Documents\Vrije Tijd\DEVELOPMENT\AdventOfCode\2021\Day-4\input.txt");
            splittedInput = inputString.Split("\n").ToList();
        }

        public void Puzzle_1()
        {
            List<String> rawBoards = inputString.Split(
                    new String[] { "\r\n\r\n" },
                    StringSplitOptions.RemoveEmptyEntries
                ).ToList();
            
            // Remove first board since that is the checklist
            List<String> moves = new(rawBoards.First().Split(",").ToList());
            rawBoards.RemoveAt(0);

            Board board = new(rawBoards.First());

            board.MarkDigit(22);

            board.ToList().ForEach(x => Console.WriteLine(x));

            // Step 1: Figure if board has any bingo
            // 



            // Step 2: Figure out how many turns it took to get bingo on board
            // Step 3: Get board with least amounts of required tuns 
            // Step 4: Count non-marked fields and sum 

        }

        public void Puzzle_2()
        {


        }
    }
}
