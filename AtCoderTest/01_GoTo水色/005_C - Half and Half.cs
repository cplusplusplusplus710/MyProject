using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderTest._01_GoTo水色
{
    //https://atcoder.jp/contests/abc095/tasks/arc096_a

    class _005_C___Half_and_Half
    {
        /// <summary>
        /// 最短解
        /// </summary>
        static void solve()
        {
            // 標準入力を配列に代入
            var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Console.WriteLine(Enumerable.Range(0, Math.Max(a[3], a[4]) + 1)    //AピザとBピザの必要枚数のうち、大きいほう+1の範囲で全探索(Cピザを購入できる可能性の最大値)
                                        .Min(i => Math.Max(a[3] - i, 0) * a[0] //(Aピザの必要枚数 - Cピザの枚数) * Aピザの値段
                                        + Math.Max(a[4] - i, 0) * a[1]         //(Bピザの必要枚数 - Cピザの枚数) * Bピザの値段
                                        + 2 * i * a[2]));                      //2 * Cピザの枚数 * Cピザの値段
        }

        /// <summary>
        /// 別解
        /// </summary>
        static void solve_another()
        {
            int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            int A = input[0];
            int B = input[1];
            int C = input[2];
            int X = input[3];
            int Y = input[4];

            //Cピザ(ハーフ＆ハーフ)を組み合わせない最小の価格
            int min_price = A * X + B * Y;

            //枚数が多いほうのピザの分、どれだけCピザに回せばいいかを考える
            for(var i = 0; i <= Math.Max(X,Y); i++)
            {
                //i(Cピザの枚数、0枚からスタート) * 2(AピザとBピザを1枚ずつ発生させるには2枚購入する必要がある) * Cピザの価格
                //XからCピザの枚数抜いた値にAピザの価格をかける
                //YからCピザの枚数抜いた値にBピザの価格をかける
                //上記3点を合算する
                int price = i * 2 * C + Math.Max(X - i, 0) * A + Math.Max(Y - i, 0) * B;
                //最小価格と比較し、下回っていれば値を更新
                min_price = Math.Min(min_price, price);
            }

            Console.WriteLine(min_price);
        }

    }
}
