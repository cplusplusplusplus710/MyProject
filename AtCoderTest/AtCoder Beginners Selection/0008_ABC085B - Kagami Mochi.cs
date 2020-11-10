using System;
using System.Collections.Generic;
using System.Text;

namespace AtCoderTest.解いたやつ
{
    class _0008_ABC085B___Kagami_Mochi
    {
        static void Atcoder1()
        {
            var ans = 0;
            var N = int.Parse(Console.ReadLine());
            List<int> IntList = new List<int>();
            while (true)
            {
                var line = Console.ReadLine();
                if (line == null)
                {
                    break;
                }

                IntList.Add(int.Parse(line));
            }

            //モチを降順ソートする
            for (int i = 0; i <= N - 1; i++)
            {
                for (int j = 0; j <= IntList.Count - 1; j++)
                {
                    for (int k = j + 1; k <= IntList.Count - 1; k++)
                    {
                        if (IntList[j] < IntList[k])
                        {
                            var Evacuation = IntList[j];
                            IntList[j] = IntList[k];
                            IntList[k] = Evacuation;
                        }
                    }
                }
            }

            //順番に積み重ねる
            for (int l = 0; l <= N - 1; l++)
            {
                if (l == 0)
                    ans++;
                else
                {
                    if (IntList[l] != IntList[l - 1])
                    {
                        ans++;
                    }
                }
            }

            Console.WriteLine(ans);
        }

    }
}
