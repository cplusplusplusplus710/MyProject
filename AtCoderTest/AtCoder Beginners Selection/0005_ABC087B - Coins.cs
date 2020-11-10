using System;
using System.Collections.Generic;
using System.Text;

namespace AtCoderTest
{
    class _0005_ABC087B___Coins
    {
        static void Atcoder1()
        {
            var A = int.Parse(Console.ReadLine());
            var B = int.Parse(Console.ReadLine());
            var C = int.Parse(Console.ReadLine());
            var X = int.Parse(Console.ReadLine());
            var ans = 0;

            for (int i = 0; i <= A; i++)
                for (int j = 0; j <= B; j++)
                    for (int k = 0; k <= C; k++)
                        if (500 * i + 100 * j + 50 * k == X)
                            ans++;

            Console.WriteLine(ans);
        }
    }
}
