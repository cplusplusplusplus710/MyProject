using System;
using System.Collections.Generic;
using System.Text;

namespace AtCoderTest.AtCoder_Beginner_Contest_180
{
    class _0003_C___Cream_puff
    {
        static void Atcoder1()
        {
            var N = long.Parse(Console.ReadLine());
            List<long> ans = new List<long>();

            for (long i = 1; i * i <= N; i++)
            {
                if (N % i == 0)
                {
                    ans.Add(i);

                    if (i != N / i)
                    {
                        ans.Add(N / i);
                    }
                }
            }

            ans.Sort();

            Console.WriteLine(string.Join("\n", ans));
        }

        ////解説
        //static void Atcoder1()
        //{
        //    //でかい数字にも対応できるようlong型でとりこむ
        //    long N = long.Parse(Console.ReadLine().Trim());
        //    List<long> LongList = new List<long>();

        //    //約数列挙という手法をつかう
        //    //通常の全値走査だと計算量が膨大になり、タイムアウトを起こす

        //    //iが割り切れたらiの2乗も割り切れるので、Forループの条件はi*iで加算していくように設定する
        //    for (long i = 1; i * i <= N; i++)
        //    {
        //        //Nがiで割り切れる時
        //        if (N % i == 0)
        //        {
        //            //約数なのでリストに追加
        //            LongList.Add(i);

        //            //iと(N/i)が同じ値でない時
        //            //ex:N=720のとき、i=1,N/i=720
        //            //昇順と降順で一気に走査してるのでいずれぶつかる
        //            if (i != N / i)
        //            {
        //                //これも約数
        //                LongList.Add(N / i);
        //            }
        //        }
        //    }

        //    //昇順にならべかえ
        //    LongList.Sort();

        //    //コレクションの要素を\n(改行)で連結し、出力
        //    Console.WriteLine(string.Join("\n", LongList));
        //}

        //static void Atcoder2()
        //{
        //    var N = int.Parse(Console.ReadLine());

        //    for (int i = 1; i <= N; ++i)
        //    {
        //        if (N % i == 0)
        //            Console.WriteLine(i);
        //    }
        //}
    }
}
