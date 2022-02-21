using System;
using System.Linq;

namespace ConsoleApp1
{
    class RepeatingNumbers
    {
        
        static void Main1(string[] args)
        {
            int[] array = new int[] { 1, 1, 5, 4, 3,3, 3, 5, 6, 7, 2, 7, 6, 2 };
            Console.WriteLine(string.Join(",", GetRepeatingNumbers(array,1)));
            
        }
        public static int[] GetRepeatingNumbers(int[] array, int times)
        {
            int[] response = array.Where(x => array.Count(y => y == x) == times).Distinct().ToArray();
            return response;
        }
    }
}
