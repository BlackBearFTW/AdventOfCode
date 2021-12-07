using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2021.Day_4
{
    class Board
    {
        readonly List<int?> board;
        public Board(string rawBoard)
        {
           List<String> temp = rawBoard.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
           board = new(temp.Select(x => (int?)Int32.Parse(x)));
        }

        public void MarkDigit(int value) => board.Select(x => x = x.Equals(value) ? null : x);
        public List<int?> ToList() => board;
        public bool Contains(int value) => board.Contains(value);
        public int? ElementAt(int value) => board.ElementAt(value);
        public int IndexOf(int value) => board.IndexOf(value);
    }
}
