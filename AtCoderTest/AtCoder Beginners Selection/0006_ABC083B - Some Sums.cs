using System;
using System.Collections.Generic;
using System.Text;

namespace AtCoderTest.解いたやつ
{
    class _0006_ABC083B___Some_Sums
    {
        static void Atcoder1()
        {
            var input = Console.ReadLine().Replace(" ", ",").Split(",");
            List<int> intlist = new List<int>();
            foreach (var item in input)
            {
                intlist.Add(int.Parse(item));
            }

            var N = intlist[0];
            var A = intlist[1];
            var B = intlist[2];
            var SumValue = 0;

            for (int i = 1; i <= N; i++)
            {
                var result = digitSum(i, A, B);

                if (result > 0)
                {
                    SumValue = SumValue + result;
                }
            }

            Console.WriteLine(SumValue);
        }

        static int digitSum(int value, int A, int B)
        {
            var s = Convert.ToString(value);
            var digitSum = 0;

            for (int i = 0; i <= s.Length - 1; i++)
            {
                digitSum = digitSum + int.Parse(s[i].ToString());
            }

            if (digitSum >= A && digitSum <= B)
                return value;

            return 0;

        }

    }
}
