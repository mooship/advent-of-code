namespace AdventOfCode
{
    public class Day01 : BaseDay
    {
        private readonly string[] _input;

        public Day01()
        {
            _input = File.ReadAllLines(InputFilePath);
        }

        public override ValueTask<string> Solve_1()
        {
            var (leftList, rightList) = ParseInput();

            leftList.Sort();
            rightList.Sort();

            int totalDistance = leftList.Zip(rightList, (left, right) => Math.Abs(left - right)).Sum();

            return new ValueTask<string>($"Total distance between lists: {totalDistance}");
        }

        public override ValueTask<string> Solve_2()
        {
            var (leftNumbers, rightNumbers) = ParseInput();

            var rightNumberCounts = rightNumbers
                .GroupBy(x => x)
                .ToDictionary(g => g.Key, g => g.Count());

            long similarityScore = leftNumbers
                .Where(leftNum => rightNumberCounts.ContainsKey(leftNum))
                .Sum(leftNum => (long)leftNum * rightNumberCounts[leftNum]);

            return new ValueTask<string>($"Similarity score: {similarityScore}");
        }

        private (List<int> leftList, List<int> rightList) ParseInput()
        {
            var leftList = new List<int>();
            var rightList = new List<int>();

            foreach (var line in _input)
            {
                var numbers = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (numbers.Length == 2)
                {
                    leftList.Add(int.Parse(numbers[0]));
                    rightList.Add(int.Parse(numbers[1]));
                }
            }

            return (leftList, rightList);
        }
    }
}