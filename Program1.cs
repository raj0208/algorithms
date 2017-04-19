using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace Rnd
{
    class Program1
    {
        static void Main1(string[] args)
        {
            int i = 0;
            PrintMenu();

            while ((i = int.Parse(Console.ReadLine())) != -1)
            {
                Console.WriteLine("\n");
                Algo(i);
                Console.WriteLine("\nAlgo# ");
            }
        }

        private enum AlgoType
        {
            MultiplyByNumber,
            SumOfTwo,
            DigitalRoot,
            TwoSum,
            ReverseWords,
            Strstr,
            DSForTwoSum,
        }

        private static void PrintMenu()
        {
            Console.Clear();

            Console.WriteLine("1. MultiplyByNumber");
            Console.WriteLine("2. SumOfTwo");
            Console.WriteLine("3. DigitalRoot");
            Console.WriteLine("4. TwoSum");
            Console.WriteLine("5. ReverseWords");
            Console.WriteLine("6. Strstr");
            Console.WriteLine("7. DS for TwoSum");
        }

        private static void Algo(int i)
        {
            Console.WriteLine((AlgoType)i);

            switch (i)
            {
                case 0: PrintMenu(); break;
                case 1: MultiplyByNumber(4, 5); break;
                case 2: SumOfTwo(new int[] { 1, 2, 5, 0, 3 }, 5); break;
                case 3: DigitalRoot(1099320897510); break;
                case 4: TwoSum(new int[] { 1, 2, 3, 4, 5 }, 5); break;
                case 5: ReverseWords("Rajesh Sharma".ToCharArray()); break;
                case 6: Console.WriteLine(StrStr("Palindrome", "rom")); break;
                case 7: DSForTwoSum();break;
            }
        }

        #region Algos

        private static void DSForTwoSum()
        {
            TwoSumClass ts = new TwoSumClass();
            ts.Add(1);
            ts.Add(3);
            ts.Add(5);
            Console.WriteLine("4 : {0}",ts.Find(4));
            Console.WriteLine("7 : {0}", ts.Find(7)); 
        }

        private static void MultiplyByNumber(int num, int multiple)
        {
            int shift = 0;
            int factor = 1;
            switch (multiple)
            {
                case 1:
                    shift = 1;
                    factor *= -1;
                    break;
                case 3:
                    shift = 2;
                    break;
                case 5:
                    factor *= -1;
                    shift = 2;
                    break;
                case 7:
                    shift = 3;
                    break;
                case 9:
                    shift = 3;
                    factor *= -1;
                    break;
                case 11:
                    shift = 4;
                    break;
            }

            Console.WriteLine((num << shift) - (num * factor));

            //var n = (num << 3);
            //Console.WriteLine(n- num);
        }

        private static void DigitalRoot(long num)
        {
            Console.WriteLine("{0}", 1 + ((num - 1) % 9));
        }

        private static void SumOfTwo(int[] numbers, int target)
        {
            var map = new Dictionary<int, int>();
            bool flag = false;
            for (int i = 0; i < numbers.Count(); i++)
            {
                int x = numbers[i];
                if (flag = map.ContainsKey(target - x))
                {
                    Console.WriteLine("{0}, {1}", map[target - x] + 1, i + 1);
                }
                map[x] = i;
            }

            if (!flag)
                Console.WriteLine("Not found");
        }

        public static void TwoSum(int[] numbers, int target)
        {
            bool flag = false;
            // Assume input is already sorted.
            for (int i = 0; i < numbers.Length; i++)
            {
                int j = bsearch(numbers, target - numbers[i], i + 1);
                if (j != -1)
                {
                    flag = true;
                    Console.WriteLine("{0}, {1}", i + 1, j + 1);
                }
            }
            if (!flag)
                Console.WriteLine("No two sum solution");
        }
        private static int bsearch(int[] A, int key, int start)
        {
            int L = start, R = A.Length - 1;
            while (L < R)
            {
                int M = (L + R) / 2;
                if (A[M] < key)
                {
                    L = M + 1;
                }
                else
                {
                    R = M;
                }
            }
            return (L == R && A[L] == key) ? L : -1;
        }

        private static int StrStr(String haystack, String needle)
        {
            for (int i = 0; ; i++)
            {
                for (int j = 0; ; j++)
                {
                    if (j == needle.Length) return i;
                    if (i + j == haystack.Length) return -1;
                    if (needle[j] != haystack[i + j]) break;
                }
            }
        }

        private static void ReverseWords(char[] s)
        {
            Reverse(s, 0, s.Length);
            for (int i = 0, j = 0; j <= s.Length; j++)
            {
                if (j == s.Length || s[j] == ' ')
                {
                    Reverse(s, i, j);
                    i = j + 1;
                }
            }

            Console.WriteLine(s);
        }

        private static void Reverse(char[] s, int begin, int end)
        {
            for (int i = 0; i < (end - begin) / 2; i++)
            {
                char temp = s[begin + i];
                s[begin + i] = s[end - i - 1];
                s[end - i - 1] = temp;
            }
        }

        private static char GetKey(Dictionary<char, char> map, char target)
        {
            return ' ';
        }


        #endregion
    }
    
    public class TwoSumClass {
        private Dictionary<int, int> table = new Dictionary<int, int>(); 

        public void Add(int input) {
            int count = table.ContainsKey(input) ? table[input] : 0;
            table[input] = count + 1;
        }

        public bool Find(int val) {
        foreach (var entry in  table)
        {
            int num = entry.Key;
            int y = val - num;
            if (y == num) {
                // For duplicates, ensure there are at least two individual numbers.
                if (entry.Value >= 2) return true;
                } else if (table.ContainsKey(y)) {
                    return true;
                }
            }

            return false;
        }
    }
}
