using System;
using System.Collections.Generic;
using System.Text;

namespace AtCoderTest.解いたやつ
{
    class _0011_ABC086C___Traveling
    {
        static void Atcoder1()
        {
            var N = int.Parse(Console.ReadLine());

            var t = new int[N + 1];
            var x = new int[N + 1];
            var y = new int[N + 1];

            t[0] = 0;
            x[0] = 0;
            y[0] = 0;

            for (int i = 0; i <= N; i++)
            {
                var input = Console.ReadLine();

                if (input == null || input == "")
                {
                    break;
                }

                var input_split = input.Replace(" ", ",").Split(",");

                t[i] = int.Parse(input_split[0]);
                x[i] = int.Parse(input_split[1]);
                y[i] = int.Parse(input_split[2]);
            }

            var flg = true;

            for (int j = 0; j < N; j++)
            {
                var MoveValue = Math.Abs(t[j + 1] - t[j]);
                var DistanceValue = Math.Abs(x[j + 1] - x[j]) + Math.Abs(y[j + 1] - y[j]);

                if (MoveValue < DistanceValue)
                {
                    flg = false;
                    break;
                }

                if (Math.Abs(MoveValue - DistanceValue) % 2 != 0)
                {
                    flg = false;
                    break;
                }
            }

            if (flg)
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");

        }

        ////解説
        //static void Atcoder1()
        //{
        //    var N = int.Parse(Console.ReadLine());

        //    //初期状態をt[0],x[0],y[0]とする
        //    //Nはステップ数　Nをそのまま入れると配列に問題が出てくるので、初期状態の配列[0]を作るため、N+1とする
        //    var t = new int[N + 1];
        //    var x = new int[N + 1];
        //    var y = new int[N + 1];

        //    t[0] = x[0] = y[0] = 0;

        //    //値を配列に入れていく
        //    for (int i = 1; i <= N; i++)
        //    {
        //        var strInput = Console.ReadLine();
        //        var arrInput = strInput.Replace(" ", ",").Split(",");

        //        t[i] = int.Parse(arrInput[0]);
        //        x[i] = int.Parse(arrInput[1]);
        //        y[i] = int.Parse(arrInput[2]);
        //    }

        //    var flg = true;

        //    for (int i = 0; i < N; i++)
        //    {
        //        //移動時間算出(移動してもよい回数) tの値を変数に格納
        //        var time = t[i + 1] - t[i];
        //        //Abs(絶対値の算出)を使って次のステップから現在のステップの値を引いたxとyの距離を求める
        //        var dist = Math.Abs(x[i + i] - x[i]) + Math.Abs(y[i + 1] - y[i]);

        //        //移動時間より距離の値が多ければfalseを返す(この移動回数では目的地にたどり着けない)
        //        if (time < dist)
        //            flg = false;
        //        //移動時間から距離を引いて、2で割る。あまりが0ではなかったらたどり着く見込みがないのでfalse
        //        if (Math.Abs(time - dist) % 2 != 0)
        //            flg = false;
        //    }

        //    if (flg)
        //        Console.WriteLine("Yes");
        //    else
        //        Console.WriteLine("No");
        //}


    }
}
