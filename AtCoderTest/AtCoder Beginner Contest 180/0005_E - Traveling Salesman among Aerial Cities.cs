using System;
using System.Collections.Generic;
using System.Text;

namespace AtCoderTest.AtCoder_Beginner_Contest_180
{
    class _0005_E___Traveling_Salesman_among_Aerial_Cities
    {
        /// <summary>
        /// 天才のプログラム　理解することを諦めた
        /// </summary>
        static void Atcoder1()
        {
            int N = int.Parse(Console.ReadLine());
            //多次元配列の宣言
            int[,] A = new int[N, 3];

            //都市の数だけループ
            for (var i = 0; i < N; i++)
            {
                string[] str = Console.ReadLine().Split();

                //i番目の都市のデータを入力していく
                A[i, 0] = int.Parse(str[0]);
                A[i, 1] = int.Parse(str[1]);
                A[i, 2] = int.Parse(str[2]);
            }

            //ワーシャルフロイド法を使用する

            //2をN(都市の数)乗した値をDSに入力
            //なんで？？？？
            int DS = (int)Math.Pow(2, N);
            //二次元配列DPを作り、そこにコストを格納していく

            int[,] DP = new int[N, DS];

            for (var i = 0; i < N; i++)
            {
                for (var j = 0; j < DS; j++)
                {
                    //配列Dの要素すべてに初期値999999999を入力
                    DP[i, j] = 999999999;
                }
            }

            //0,0の要素は0を入れる
            DP[0, 0] = 0;

            //多次元配列Eを宣言して0番目の要素を1にする
            //最大要素数はN(都市数)
            int[] E = new int[N];
            E[0] = 1;

            for (var i = 1; i < N; i++)
            {
                //1番目のインデックスからスタート
                //E[i]番目(都市を順番に走査)には前のインデックスの値*2を入力
                //ex)i = 1のとき、E[0] = 1なので1 * 2 = 2となる
                //ex)i = 2のとき、E[1] = 2なので2 * 2 = 4となる
                E[i] = E[i - 1] * 2;
            }

            //HachSetクラスを宣言
            //HashSet:何らかの要素(オブジェクト)の重複を省いて一覧として保持したい時に使うクラス
            //例えば"A","B","C","A"と要素を入力すれば重複している"A"が省略され、"A","B","C"と出力される
            var list = new HashSet<int>();
            list.Add(0);

            //HashSetのリストの要素数が0以上の時はループ
            while (list.Count > 0)
            {
                //HashSetリストをもう一つ作り、最初に作ったリストを退避させる
                var list2 = new HashSet<int>(list);
                //最初に作ったHashSetは中身をクリアーする
                list.Clear();

                //退避した値を順番にとりだし
                foreach (var t in list2)
                {
                    //取り出した値をaとcの変数にそれぞれ、
                    //DS(2を都市数で累乗したもの)で割った値、割った余りの値を入力する
                    int a = t / DS;
                    int c = t % DS;

                    for (var i = 0; i < N; i++)
                    {
                        //cの値とE[i]で割った値は偶数であるかどうか？
                        //偶数ならメソッド実行
                        if (c / E[i] % 2 == 0)
                        {
                            //cとE[i」を足した変数を作る
                            int c2 = c + E[i];
                            //都市への移動コストを算出する
                            int nd = DP[a, c] + Math.Abs(A[a, 0] - A[i, 0]) +
                                               Math.Abs(A[a, 1] - A[i, 1]) +
                                               Math.Max(0, A[a, 2] - A[i, 2]);
                            if (DP[i, c2] > nd)
                            {
                                DP[i, c2] = nd;
                                list.Add(i * DS + c2);
                            }
                        }
                    }
                }
            }

            Console.WriteLine(DP[0, DS - 1]);

        }

        /// <summary>
        /// わかりやすそうなやつ
        /// </summary>
        static void Atcoder2()
        {
            //標準入力取込みと、x,y,zを入れる配列の作成
            int N = int.Parse(Console.ReadLine());
            int[] X = new int[N];
            int[] Y = new int[N];
            int[] Z = new int[N];

            //都市の数だけループ
            for (int i = 0; i < N; i++)
            {
                //X,Y,Zを取込み
                string[] input = Console.ReadLine().Split(' ');
                X[i] = int.Parse(input[0]);
                Y[i] = int.Parse(input[1]);
                Z[i] = int.Parse(input[2]);
            }

            //ワーシャルフロイド法

            //DPを作成
            //二次元目は1をNビット左シフト(計算量は2^Nのため)
            //ex)1 << 4の場合、0001→0100 = 4
            int[,] dp = new int[N, 1 << N];

            //都市の数だけループ
            for (int i = 0; i < N; i++)
            {
                //1 << Nだけループ
                //動的計画法　考えられる組み合わせはそれぞれの「都市」に対し「通るor通らない」時のコスト値
                //2~Nが基本形だが1 << Nでも同じことができる。たぶん。
                for (int j = 0; j < 1 << N; j++)
                {
                    //DPの要素すべてに初期値としてint型の最大値を与える
                    dp[i, j] = int.MaxValue;
                }
            }

            //同じ頂点への距離は0にする
            dp[0, 0] = 0;

            //1 << Nだけループ
            for (int s = 0; s < 1 << N; s++)
            {
                //都市の数だけループ
                for (int i = 0; i < N; i++)
                {
                    //始点と終点ではない時
                    //問題文は「行って帰ってくる」なので最終的に地点はdp[0,0]になる
                    if ((s & (1 << i)) != 0)
                    {
                        //都市の数だけループ
                        for (int j = 0; j < N; j++)
                        {
                            //コストを計算
                            //dp[都市N(順番に),
                            int cost = dp[j, s - (1 << i)] +
                                       Cost(X[i], Y[i], Z[i], X[j], Y[j], Z[j]);
                            if (cost > 0)
                            {
                                dp[i, s] = Math.Min(dp[i, s], cost);
                            }
                        }
                    }
                }
            }

            Console.WriteLine(dp[0, (1 << N) - 1]);

        }

        /// <summary>
        /// わかりやすそうなやつ　改良版
        /// </summary>
        static void Atcoder3()
        {
            //標準入力取込みと、x,y,zを入れる配列の作成
            int N = int.Parse(Console.ReadLine());
            int[] X = new int[N];
            int[] Y = new int[N];
            int[] Z = new int[N];

            //都市の数だけループ
            for (int i = 0; i < N; i++)
            {
                //X,Y,Zを取込み
                string[] input = Console.ReadLine().Split(' ');
                X[i] = int.Parse(input[0]);
                Y[i] = int.Parse(input[1]);
                Z[i] = int.Parse(input[2]);
            }

            //ワーシャルフロイド法

            //DPを作成
            int[,] dp = new int[N, 2^N];

            //都市の数だけループ
            for (int i = 0; i < N; i++)
            {
                //全パターンループ
                //動的計画法　考えられる組み合わせはそれぞれの「都市」に対し「通るor通らない」時のコスト値
                //基本的には2^Nが全パターンループの計算量
                for (int j = 0; j < dp.GetLength(1) - 1; j++)
                {
                    //DPの要素すべてに初期値としてint型の最大値を与える
                    dp[i, j] = int.MaxValue;
                }
            }

            //同じ頂点への距離は0にする
            dp[0, 0] = 0;

            //全パターンループ
            for (int s = 0; s < dp.GetLength(1) - 1; s++)
            {
                //都市の数だけループ
                for (int i = 0; i < N; i++)
                {
                    //始点と終点ではない時
                    //問題文は「行って帰ってくる」なので最終的にポイントはdp[0,0]になる
                    if ((s & dp.GetLength(1) - 1) != 0)
                    {
                        //都市の数だけループ
                        for (int j = 0; j < N; j++)
                        {
                            //コストを計算
                            //dp[都市N(順番に),全パターンループ - 最大値] + コスト(別メソッドで計算)
                            int cost = dp[j, s - dp.GetLength(1) - 1] +
                                       Cost(X[i], Y[i], Z[i], X[j], Y[j], Z[j]);
                            //コストが0以上のとき
                            if (cost > 0)
                            {
                                //コストを比較し、小さいほうを反映
                                //初期値999999999が入ってるときは無条件で反映
                                dp[i, s] = Math.Min(dp[i, s], cost);
                            }
                        }
                    }
                }
            }

            Console.WriteLine(dp[0, dp.GetLength(1) - 1]);

        }

        static int Cost(int a, int b, int c, int p, int q, int r)
        {
            int x = Math.Abs(p - a);
            int y = Math.Abs(q - b);
            int z = Math.Max(r - c, 0);
            return x + y + z;
        }

    }
}
