using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class CTCI
    {
        internal static void Run()
        {
            var ctci = new CTCI();
            //ctci.IsUniqueChars();
            ctci.PermutationOfPalindrome();
        }

        private void IsUniqueChars()
        {
            string s = "the quick brown jumps over the lazy dog";

            int checker = 0;
            int value = 0;
            for (int i = 0; i < s.Length; i++)
            {
                value = Char.ToLower(s[i]) - 'a';

                if ((checker & (1 << value)) > 0)
                {
                    Console.WriteLine("not unique {0}", s[i]);
                    break;
                }

                checker |= (1 << value);
            }

            Console.WriteLine("unique");
        }

        private void PermutationOfPalindrome()
        {
            string phrase = "god dog";

            int[] table = new int['z' - 'a'];
            int count = 0;
            for (int i = 0; i < phrase.Length; i++)
            {
                int x = phrase[i];

                if (Char.IsLetter(phrase[i]))
                {
                    table[x]++;

                    if (table[x] % 2 == 1)
                        count++;
                    else
                        count--;
                }
            }

            Console.WriteLine("Result : {0}", (count <= 1));
        }
    }
}
