namespace AdventOfCode
{
    public class Day02 : BaseDay
    {
        private readonly List<int[]> _input;

        public Day02()
        {
            _input = File.ReadAllLines(InputFilePath)
                .Select(line => line.Split(' ').Select(int.Parse).ToArray())
                .ToList();
        }

        public override ValueTask<string> Solve_1()
        {
            int safeReportCount = _input.Count(IsSafeReport);

            return new ValueTask<string>($"Total safe reports: {safeReportCount}");
        }

        public override ValueTask<string> Solve_2()
        {
            int safeReportCount = _input.Count(report => IsSafeReport(report) || CanBeMadeSafeByRemovingOne(report));
            
            return new ValueTask<string>($"Total safe reports (Problem Dampener enabled): {safeReportCount}");
        }

        private bool IsSafeReport(int[] levels)
        {
            if (levels.Length < 2) return false;

            bool isIncreasing = true;
            bool isDecreasing = true;

            for (int i = 0; i < levels.Length - 1; i++)
            {
                int difference = levels[i + 1] - levels[i];

                if (Math.Abs(difference) < 1 || Math.Abs(difference) > 3)
                {
                    return false;
                }

                if (difference < 0)
                {
                    isIncreasing = false;
                }
                else if (difference > 0)
                {
                    isDecreasing = false;
                }
            }

            return isIncreasing || isDecreasing;
        }

        private bool CanBeMadeSafeByRemovingOne(int[] levels)
        {
            for (int i = 0; i < levels.Length; i++)
            {
                var modifiedLevels = levels.Where((_, index) => index != i).ToArray();
                if (IsSafeReport(modifiedLevels))
                {
                    return true;
                }
            }

            return false;
        }
    }
}