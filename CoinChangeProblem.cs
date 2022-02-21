using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace consoleApps
{
    class CoinChangeProblem
    {
        private static int[] input = { 1, 3, 5, 6 };
        private static int amount = 1;

        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(Environment.NewLine, GetChanges()?.Select(x => $"Coin of {x.Key} - {x.Value}")));
        }

        static Dictionary<int, int> GetChanges()
        {
            input = input.OrderByDescending(x => x).ToArray();

            Dictionary<int, int> result = new Dictionary<int, int>();
            Func<KeyValuePair<int, int>, int> total = x => x.Key * x.Value;
            var index = 0;
            while (result.Sum(total) < amount)
            {
                if ((input[index] + result.Sum(total)) <= amount)
                {
                    if (!result.ContainsKey(input[index]))
                        result.Add(input[index], 1);
                    while ((input[index] + result.Sum(total)) <= amount)
                    {
                        result[input[index]] = result[input[index]] + 1;
                    }
                }
                if (++index == input.Length)
                    break;
            }
            return result;
        }
    }
}
