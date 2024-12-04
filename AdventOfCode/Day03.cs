namespace AdventOfCode
{
    public class Day03 : BaseDay
    {
        private readonly string _input;

        public Day03()
        {
            _input = File.ReadAllText(InputFilePath);
        }

        public override ValueTask<string> Solve_1()
        {
            // Regular expression to match valid mul(X,Y) instructions
            var regex = new Regex(@"mul\((\d{1,3}),(\d{1,3})\)");
            var matches = regex.Matches(_input);

            int totalSum = 0;

            foreach (Match match in matches)
            {
                if (match.Success)
                {
                    int x = int.Parse(match.Groups[1].Value);
                    int y = int.Parse(match.Groups[2].Value);

                    totalSum += x * y;
                }
            }

            return new($"Total of all multiplication results: {totalSum}");
        }

        public override ValueTask<string> Solve_2()
        {
            // Regular expression to match do(), don't(), and mul(X,Y) instructions
            var regex = new Regex(@"do\(\)|don't\(\)|mul\((\d{1,3}),(\d{1,3})\)");
            var matches = regex.Matches(_input);

            bool isEnabled = true;
            int totalSum = 0;

            foreach (Match match in matches)
            {
                switch (match.Value)
                {
                    case "do()":
                        isEnabled = true;
                        break;
                    case "don't()":
                        isEnabled = false;
                        break;
                    default:
                        if (match.Groups.Count == 3 && isEnabled)
                        {
                            int x = int.Parse(match.Groups[1].Value);
                            int y = int.Parse(match.Groups[2].Value);
                            totalSum += x * y;
                        }
                        break;
                }
            }

            return new ValueTask<string>($"Total after enabled multiplications: {totalSum}");
        }
    }
}