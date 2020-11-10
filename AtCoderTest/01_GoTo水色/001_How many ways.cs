using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderTest._01_GoTo水色
{
    //http://judge.u-aizu.ac.jp/onlinejudge/description.jsp?id=ITP1_7_B&lang=ja

    class _001_How_many_ways
    {
        static void solve()
        {
            List<int> list = new List<int>();

            while (true)
            {
                var s = Console.ReadLine().Split(' ');

                if (s[0] == "" || s[0] == null)
                    break;
                else if (s[1] == "" || s[1] == null)
                    break;

                foreach (var item in s)
                {
                    list.Add(int.Parse(item));
                }
            }

            var ansCount = 0;

            //listのループ
            //list[i] = n(1～n)　list[i + 1] = X(合計)
            for (int i = 0; i <= list.Count - 1; i += 2)
            {
                for (int j = 1; j <= list[i]; j++)
                {
                    for (int k = j + 1; k <= list[i]; k++)
                    {
                        if (k != j)
                        {
                            for (int l = k + 1; l <= list[i]; l++)
                            {
                                if (l != k && l != j)
                                {
                                    var _x = j + k + l;

                                    if (_x == list[i + 1])
                                        ansCount++;
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine(ansCount);
            Console.ReadKey();
        }
    }
}
