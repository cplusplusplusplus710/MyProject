using System;
using System.Collections.Generic;
using System.Text;

namespace AtCoderTest.解いたやつ
{
    class _0002_ABC086A___Product
    {
        static void Atcoder1()
        {
            int a = 0;
            int b = 0;
            int c = 0;

            var array = Console.ReadLine().Split(' ');
            a = int.Parse(array[0]);
            b = int.Parse(array[1]);
            c = a * b;

            int roopvalue = 0;


            roopvalue = c % 2;

            if (roopvalue == 1)
            {
                Console.Write("Odd");
            }
            else if (roopvalue == 0)
            {
                Console.Write("Even");
            }

        }

    }
}
