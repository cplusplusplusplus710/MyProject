using System;
using System.Collections.Generic;
using System.Text;

namespace AtCoderTest._00_アルゴリズムサンプル
{
    class ワーシャルフロイド法
    {
        static void Program_Main()
        {
            Solve(0, 4); // 3
            Solve(0, 3); // 2
            Solve(1, 2); // 2
            Solve(1, 3); // 1
            Solve(1, 4); // 2
        }

        /// <summary>
        /// アルゴリズム本体
        /// </summary>
        /// <param name="start">始点のパラメータ</param>
        /// <param name="goal">終点のパラメータ</param>
        static void Solve(int start, int goal)
        {
            //各辺の入力データ

            //データ保存用のEdge構造体のインスタンスを入れられる、ジェネリッククラスを生成
            var edges = new List<Edge>();

            //値(地点)を入力していく
            edges.Add(new Edge(0, 1, 2)); //始点0、終点1、コスト2
            edges.Add(new Edge(0, 2, 1));
            edges.Add(new Edge(1, 3, 1));
            edges.Add(new Edge(1, 2, 2));
            edges.Add(new Edge(2, 3, 1));
            edges.Add(new Edge(2, 4, 3));
            edges.Add(new Edge(3, 4, 1));

            // 頂点iからjへの最短距離を格納するDP
            // 初期値は大きな値(INF)を入れておく
            // 同じ頂点への距離は0にする

            //DP:動的計画表(Dynamic Programming)。アルゴリズムの一種。対象となる問題を複数の部分問題に分割し、
            //部分問題の計算結果を記録しながら解いていく手法を総称してこう呼ぶ。

            var INF = 999999999;

            //コストを格納する二次元配列。5,5を設定する。
            var DP = new int[5, 5];

            for(int i = 0; i < 5; i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    //すべてのコストに初期値999999999を設定しておく
                    DP[i, j] = INF;
                }

                //同じ頂点への距離は0にする
                DP[i, i] = 0;
            }

            //1つの辺で直接つながる時の距離
            foreach(var e in edges)
            {
                //DP[始点,終点] = コスト(距離)
                DP[e.From, e.To] = e.Cost;
            }

            //頂点iからjへの距離と、i → k → jと、kを経由する距離を比べる
            for(int k = 0; k < 5; k++)
            {
                for(int i = 0; i < 5; i++)
                {
                    for(int j = 0; j < 5; j++)
                    {
                        //i,jのコストとi,k + k,jのコストを比較し、小さいほうを格納する
                        DP[i, j] = Math.Min(DP[i, j], DP[i, k] + DP[k, j]);
                    }
                }
            }

            //dp の中に頂点間の距離が格納されている
            //先にコストをすべて計算した上で、最後に引数の値で答え合わせをするイメージ
            //INFの場合は点を結ぶ辺が存在しない、到達できない
            var ans = DP[start, goal];
            Console.WriteLine(ans);
        }


        /// <summary>
        /// 各辺のデータ(始点、終点、コスト)を格納するクラス
        /// </summary>
        struct Edge
        {
            public int From { get; set; }
            public int To { get; set; }
            public int Cost { get; set; }
            public Edge(int f,int t,int c)
            {
                this.From = f;
                this.To = t;
                this.Cost = c;
            }
        }
    }
}
