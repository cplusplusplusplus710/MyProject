using System;
using System.Collections.Generic;
using System.Text;

namespace AtCoderTest.AtCoder_Beginner_Contest_180
{
    class _0001_A___box
    {
        static void Atcoder1()
        {
            var input = Console.ReadLine().Replace(" ", ",").Split(",");
            var BallValue = int.Parse(input[0]);
            var Ball_out = int.Parse(input[1]);
            var Ball_in = int.Parse(input[2]);

            var result = BallValue - Ball_out + Ball_in;

            Console.WriteLine(result);
        }
    }
}
