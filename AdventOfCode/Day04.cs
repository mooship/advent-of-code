namespace AdventOfCode
{
    public class Day04 : BaseDay
    {
        private readonly string[] _input;

        public Day04()
        {
            _input = File.ReadAllLines(InputFilePath);
        }

        public override ValueTask<string> Solve_1()
        {
            int count = CountOccurrencesOfXmas(_input);
            return new ValueTask<string>($"XMAS appears: {count} times");
        }

        private int CountOccurrencesOfXmas(string[] grid)
        {
            int totalOccurrences = 0;
            int rows = grid.Length;
            int cols = grid[0].Length;

            // Define directions as (rowDelta, colDelta)
            var directions = new (int, int)[]
            {
                (0, 1),  // Horizontal right
                (0, -1), // Horizontal left
                (1, 0),  // Vertical down
                (-1, 0), // Vertical up
                (1, 1),  // Diagonal down-right
                (1, -1), // Diagonal down-left
                (-1, 1), // Diagonal up-right
                (-1, -1) // Diagonal up-left
            };

            foreach (var direction in directions)
            {
                totalOccurrences += CountInDirection(grid, direction.Item1, direction.Item2);
            }

            return totalOccurrences;
        }

        private int CountInDirection(string[] grid, int rowDelta, int colDelta)
        {
            int count = 0;
            int rows = grid.Length;
            int cols = grid[0].Length;
            string target = "XMAS";

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (IsWordAtPosition(grid, row, col, rowDelta, colDelta, target))
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        private bool IsWordAtPosition(string[] grid, int startRow, int startCol, int rowDelta, int colDelta, string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                int newRow = startRow + i * rowDelta;
                int newCol = startCol + i * colDelta;

                if (newRow < 0 || newRow >= grid.Length || newCol < 0 || newCol >= grid[0].Length || grid[newRow][newCol] != word[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override ValueTask<string> Solve_2() => throw new NotImplementedException();
    }
}