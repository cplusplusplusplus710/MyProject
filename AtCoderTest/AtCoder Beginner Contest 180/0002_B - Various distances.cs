using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderTest.AtCoder_Beginner_Contest_180
{
    class _0002_B___Various_distances
    {
        static void Atcoder1()
        {
            var N = int.Parse(Console.ReadLine());
            var X = Console.ReadLine().Split(' ').Select(e => long.Parse(e));

            long mh = 0; long yu = 0; long ch = 0;

            foreach (var item in X)
            {
                var i = Math.Abs(item);

                mh += i;
                yu += i * i;
                ch = Math.Max(ch, i);
            }

            Console.WriteLine(mh);
            Console.WriteLine(Math.Sqrt(yu));
            Console.WriteLine(ch);

        }

        ////解説
        //static void Atcoder1()
        //{
        //    //原点0からxまでの距離を算出するプログラム

        //    var n = int.Parse(Console.ReadLine());
        //    //splitし、Linqでlong型のIEnumarableクラスを作成する
        //    var x = Console.ReadLine().Split(' ').Select(long.Parse);

        //    //マンハッタン距離
        //    long mh = 0;
        //    //ユークリッド距離
        //    long yu = 0;
        //    //チェビシェフ距離
        //    long ch = 0;

        //    //IEnumarableクラスにおさめた標準入力を取り出し
        //    foreach (var item in x)
        //    {
        //        //絶対値を取り出す
        //        var i2 = Math.Abs(item);

        //        //マンハッタン距離：A地点からB地点まで、碁盤の目に沿って算出する距離。カクカクしてる
        //        //計算方法：点A + 点B + 点n...という風にどんどん後ろに値を加算していく
        //        mh += i2;
        //        //ユークリッド距離：A地点からB地点まで、直線の最短距離を算出。
        //        //計算方法：点A~2 + 点B^2 + 点n^2...という風に各点の値を2乗して後ろに加算していき、最後に平方根を計算
        //        yu += i2 * i2;
        //        //チェビシェフ距離：別名チェス盤距離。チェスや将棋のようにマス目移動することで算出される距離。
        //        //計算方法：入力された引数の中で最大値を返すMath.Max()で算出する
        //        ch = Math.Max(ch, i2);
        //    }

        //    Console.WriteLine(mh);　//マンハッタン距離

        //    Console.WriteLine("{0:f10}", Math.Sqrt(yu));　//ユークリッド距離　Math.Sqrtで平方根を計算 小数点以下10桁まで

        //    Console.WriteLine(ch);　//チェビシェフ距離
        //}

    }
}
