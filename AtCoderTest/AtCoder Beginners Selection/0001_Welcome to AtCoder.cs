using System;
using System.Collections.Generic;
using System.Text;

namespace AtCoderTest
{
    class WelcometoAtCoder
    {
        static void Atcoder1()
        {
            int a = 0;
            int b = 0;
            int c = 0;
            string s = "";

            a = int.Parse(Console.ReadLine());
            var b_array = Console.ReadLine().Split(' ');
            b = int.Parse(b_array[0]);
            c = int.Parse(b_array[1]);
            s = Console.ReadLine();

            var resultabc = a + b + c;

            Console.Write(resultabc);
            Console.Write(" ");
            Console.Write(s);
        }

    }
}
