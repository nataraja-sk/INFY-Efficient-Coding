using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace consoleApps
{
    class CoinChangeProblem
    {
        private static int[] input = { 1, 3, 5, 6 };
        private static int amount = int.MaxValue;

        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(Environment.NewLine, GetChanges()?.Select(x => $"Coin of {x.Key} * {x.Value} = {x.Key * x.Value}")));
        }

        static Dictionary<int, int> GetChanges()
        {
            input = input.OrderByDescending(x => x).ToArray();

            Dictionary<int, int> result = new Dictionary<int, int>();
            var index = 0;
            while (amount > 0)
            {
                if (amount - input[index] >= 0)
                {
                    if (!result.ContainsKey(input[index]))
                    {
                        result.Add(input[index], 1);
                        amount -= input[index];
                    }
                    while (amount - input[index] >= 0)
                    {
                        result[input[index]] = result[input[index]] + 1;
                        amount -= input[index];
                    }
                }
                if (++index == input.Length)
                    break;
            }
            return result;
        }
    }
}
