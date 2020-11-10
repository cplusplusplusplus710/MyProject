using System;
using System.Collections.Generic;
using System.Text;

namespace AtCoderTest._01_GoTo水色
{
    //https://atcoder.jp/contests/abc106/tasks/abc106_b

    class _002_B___105
    {
        static void solve()
        {
            var N = int.Parse(Console.ReadLine());
            var ansCount = 0;
            List<long> divisorlist = new List<long>();

            for (int i = 1; i <= N; i++)
            {
                //奇数かチェック
                if (i % 2 == 0)
                    continue;

                //約数の数を計算
                for(int j = 1; j*j <= i; j++)
                {
                    if(i % j == 0)
                    {
                        divisorlist.Add(j);

                        if(j != N / j)
                        {
                            divisorlist.Add(N / j);
                        }
                    }
                }

                if(divisorlist.Count == 8)
                {
                    ansCount++;
                }
                else
                {
                    divisorlist.Clear();
                }
            }

            Console.WriteLine(ansCount);
            
        }

    }
}
