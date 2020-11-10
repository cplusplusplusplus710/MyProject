using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AtCoderTest._01_GoTo水色
{
    class _007_最古の遺跡
    {
        //https://www.ioi-jp.org/joi/2006/2007-ho-prob_and_sol/2007-ho.pdf#page=5
        //参考URL?:https://kabukimining.hateblo.jp/entry/joi2007ho_c
        //もういっこ:https://eiya5498513.hatenablog.jp/entry/2017/10/08/205752

        static void solve()
        {
            //遺跡から見つかった柱の数
            long N = long.Parse(Console.ReadLine());

            //x座標とy座標の値を入れる変数
            long[] x = new long[N];
            long[] y = new long[N];

            //座標をbool型で作成
            bool[,] pos = new bool[5000, 5000];

            for (int i = 0; i < N; i++)
            {
                //標準入力の柱の座標を取得
                string[] tmp = Console.ReadLine().Split(' ');
                x[i] = long.Parse(tmp[0]);
                y[i] = long.Parse(tmp[1]);

                //bool型にも値を反映(trueにする)
                pos[x[i], y[i]] = true;
            }

            long difx, dify, cx, cy, dx, dy;
            //面積値
            long maxarea = 0;

            for (int i = 0; i < N - 1; i++)
            {
                for (int j = i + 1; j < N; j++)
                {
                    //地点iの座標とその次の座標の差分を算出
                    difx = x[j] - x[i];
                    dify = y[j] - y[i];

                    //正方形になるであろうC点とD点について調べる

                    //C点の算出
                    //現在のx座標 - yの差分
                    cx = x[i] - dify;
                    //現在のy座標 - xの差分
                    cy = y[i] + difx;

                    //D点の算出
                    //次のx座標 - yの差分
                    dx = x[j] - dify;
                    //次のy座標 - xの差分
                    dy = y[j] + difx;


                    if (0 <= cx &&    //cxが0以上
                        cx < 5000 &&  //cxが5000以内
                        0 <= cy &&　　//cyが0以上
                        cy < 5000 &&　//cyが5000以内
                        0 <= dx &&　　//dxが0以上
                        dx < 5000 &&  //dxが5000以内
                        0 <= dy &&　　//dyが0以上
                        dy < 5000)　　//dyが5000以内
                    {
                        //座標がtrueになっている時
                        if (pos[cx, cy] && pos[dx, dy])
                        {
                            //面積の値を更新
                            maxarea = Math.Max(maxarea, difx * difx + dify * dify);
                        }
                    }
                }
            }

            Console.WriteLine(maxarea);
        }

        static void solve_copy()
        {
            long N = long.Parse(Console.ReadLine());
            long[] X = new long[N];
            long[] Y = new long[N];
            bool[,] pos = new bool[5000, 5000];

            for(int i = 0; i< N; i++)
            {
                string[] tmp = Console.ReadLine().Split(' ');
                X[i] = long.Parse(tmp[0]);
                Y[i] = long.Parse(tmp[1]);

                pos[X[i], Y[i]] = true;
            }

            long difx, dify, cx, cy, dx, dy;

            long maxarea = 0;

            for(int i = 0; i < N - 1; i++)
            {
                for(int j = i + 1; j < N; j++)
                {
                    difx = X[j] - X[i];
                    dify = Y[j] - Y[i];

                    cx = X[i] - dify;
                    cy = Y[i] - difx;

                    dx = X[j] - dify;
                    dy = Y[j] - difx;

                    if(0 <= cx &&
                       cx < 5000 &&
                       0 <= cy &&
                       cy < 5000 &&
                       0 <= dx &&
                       dx < 5000 &&
                       0 <= dy &&
                       dy < 5000)
                    {
                        if(pos[cx,cy] && pos[dx,dy])
                        {
                            maxarea = Math.Max(maxarea, difx * difx + dify * dify);
                        }
                    }
                }
            }
        }
    }
}
