using System;
using System.Collections.Generic;
using System.Text;

namespace AtCoderTest._01_GoTo水色
{
    //https://atcoder.jp/contests/s8pc-6/tasks/s8pc_6_b

    class _008_B___AtCoder_Market
    {
        static void solve()
        {
            //買い物客数
            int N = int.Parse(Console.ReadLine());
            //マスA  買い物客数だけ要素数設定
            int[] A = new int[N];
            //マスB  買い物客数だけ要素数設定
            int[] B = new int[N];

            for(var i = 0; i < N; i++)
            {
                string[] str2 = Console.ReadLine().Split();
                A[i] = int.Parse(str2[0]);
                B[i] = int.Parse(str2[1]);
            }

            Array.Sort(A);
            Array.Sort(B);

            int a1 = 0;
            int a2 = 0;

            if(N % 2 == 1)
            {
                a1 = A[N / 2];
                a2 = B[N / 2];
            }
            else
            {
                a1 = A[N / 2];
                a2 = B[N / 2];
            }

            long ans = 0;

            for(var i = 0; i < N; i++)
            {
                ans += Math.Abs(A[i] - a1);
                ans += Math.Abs(B[i] - A[i]);
                ans += Math.Abs(a2 - B[i]);
            }

            Console.WriteLine(ans);
        }
    }
}
