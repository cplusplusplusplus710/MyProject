using System;
using System.Collections.Generic;
using System.Text;

namespace AtCoderTest.解いたやつ
{
    class _0009_ABC085C___Otoshidama
    {
        static void Atcoder1()
        {
            var input = Console.ReadLine().Replace(" ", ",").Split(",");
            var N = int.Parse(input[0]);
            var Y = int.Parse(input[1]);

            for (int i = 0; i <= N; i++)
            {
                for (int j = 0; j <= N - i; j++)
                {
                    var k = N - i - j;

                    if (10000 * i + 5000 * j + 1000 * k == Y)
                    {
                        Console.WriteLine(i + " " + j + " " + k);
                        return;
                    }
                }
            }

            Console.WriteLine(-1 + " " + -1 + " " + -1);
        }

    }
}
