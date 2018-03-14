using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class AppLauncher
    {
        static void Main1(string[] args)
        {
            //LC.Run();
            CTCI.Run();
            Console.ReadLine();
        }


        static void Main(string[] args)
        {
            IsUnique();
        }

        static void IsUnique()
        {
            string str = "quick brown fx jmps ve the lazy dog";

            int checker = 0;

            foreach (var c in str.ToCharArray())
            {
                int value = c - 'a';
                if ((checker & (1 << value)) > 0)
                {
                    Console.WriteLine("Not unique");
                    return;
                }

                checker |= (1 << value);
            }

            Console.WriteLine("Unique");
        }

       
    }
}
