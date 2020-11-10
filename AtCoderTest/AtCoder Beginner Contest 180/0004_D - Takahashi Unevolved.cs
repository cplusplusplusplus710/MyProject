using System;
using System.Collections.Generic;
using System.Text;

namespace AtCoderTest.AtCoder_Beginner_Contest_180
{
    class _0004_D___Takahashi_Unevolved
    {
        static void Atcoder2()
        {
            string[] str = Console.ReadLine().Split();
            long X = long.Parse(str[0]);
            long Y = long.Parse(str[1]);
            long A = long.Parse(str[2]);
            long B = long.Parse(str[3]);

            long ans = 0;

            while (true)
            {
                //加算値より強さが大きい時
                //倍化しつくした残りの値で、まだ加算の余地がある場合にここにくる
                if (X >= B)
                {
                    //経験値に加算　(進化レベル - 1 - 強さ(値を反映させた現在の強さ)) / 加算値
                    //-1しないと進化レベルぴったりになるので避ける
                    ans += (Y - 1 - X) / B;
                    break;
                }

                //強さを倍化させた値が進化レベルに届いていない時
                if (X * A < Y)
                {
                    //経験値に1を加算
                    ans += 1;
                    //倍化させた値を強さに反映
                    X = X * A;
                }
                //進化レベルに届いてしまったら倍化した値を反映させず、加算値を残り全清算
                else
                {
                    //経験値に加算　(進化レベル - 1 - 強さ) / 加算値
                    ans += (Y - 1 - X) / B;
                    break;
                }
            }

            Console.WriteLine(ans);

        }

        /// <summary>
        /// 自分で書いたコード
        /// </summary>
        static void Atcoder1()
        {
            var input = Console.ReadLine().Split(" ");
            var X_Power = long.Parse(input[0]);
            var Y_EvolLevel = long.Parse(input[1]);
            var A_doublePower = long.Parse(input[2]);
            var B_addPower = long.Parse(input[3]);
            long Experience = 0;
            List<long> list = new List<long>();

            for (int i = 1; i <= Y_EvolLevel; i++)
            {
                //基礎パワーを退避
                var x = X_Power;

                //ループの数だけパワーを倍増
                x = x * (A_doublePower * i);
                Experience++;
                //値チェック
                if (x > Y_EvolLevel)
                {
                    Experience--;
                    list.Add(Experience);
                    break;
                }

                //ループの数だけパワーを倍増
                for (int j = 1; j <= Y_EvolLevel; i++)
                {
                    if (x + B_addPower * j < Y_EvolLevel)
                    {
                        Experience++;
                        x += B_addPower * j;
                    }
                    else if (x + B_addPower * j == Y_EvolLevel)
                    {
                        Experience++;
                        break;
                    }
                    else
                    {
                        break;
                    }
                }

                list.Add(Experience);
                Experience = 0;
            }

            list.Sort();
            var count = list.Count;
            Console.WriteLine(list[count - 1]);
        }

        /// <summary>
        /// 書き直したコード
        /// </summary>
        static void Atcoder3()
        {
            var input = Console.ReadLine().Split(" ");
            var X = int.Parse(input[0]);
            var Y = int.Parse(input[1]);
            var A = int.Parse(input[2]);
            var B = int.Parse(input[3]);
            var Experience = 0;

            while (true)
            {
                if (X >= B)
                {
                    Experience += (Y - X - 1) / B;
                    break;
                }

                if (X * A < Y)
                {
                    Experience++;
                    X = X * A;
                }
                else
                {
                    Experience += (Y - X - 1) / B;
                    break;
                }
            }

            Console.WriteLine(Experience);


        }

    }
}
