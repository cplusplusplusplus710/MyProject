using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderTest._00_アルゴリズムサンプル
{
    //動的計画法
    //対象となる問題を複数の部分問題に分割し、部分問題の計算結果を記録しながら解いていく手法を総称したもの

    class DP___動的計画法
    {
        /// <summary>
        /// ボトムアップ方式。フィボナッチ数列。
        /// 計算は 0 →　1 →　2　→　... →　nといった順番で行われる。
        /// 計算量はO(n)。
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static long Fibonacci_BottomUP(long n)
        {
            long[] dp = new long[n + 1];
            dp[0] = 0;
            dp[1] = 1;

            for(int i = 2; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }

            return dp[n];
        }

        /// <summary>
        /// N 問の問題があるコンテストがあり、i 問目の問題の配点は pi 点である。
        /// コンテストは、この問題の中から何問か解き、解いた問題の配点の合計が得点となる。
        /// このコンテストの得点は何通り考えられるか。
        /// </summary>
        /// <param name="N">問題数</param>
        /// <param name="P_1">得点1</param>
        /// <param name="P_2">得点2</param>
        /// <param name="P_3">得点3</param>
        public void Typical_DP_Contest(int N_input, int P_1, int P_2, int P_3)
        {
            //https://webbibouroku.com/Blog/Article/typical-dp-contest-a

            //すべての組み合わせ→正解or不正解の2パターン×問題数
            //つまり「2^N(2のN乗)」パターン存在する
            //→Nの値が大きくなると手が付けられなくなるくらい計算量が増える!!

            var N = N_input;
            var P = new int[]{ P_1, P_2, P_3 }; 

            //初期値として0点のパターンのみtrueとする
            var dp = new bool[100 * 100 + 1]; //MAX1000点。点数を配列の要素数として考える。
            dp[0] = true;

            //N問分ループ
            for(int i = 0; i < N; i++)
            {
                //i問目終了時の状態
                //新しい配列を作って現在の状態を退避
                var nextDP = new bool[dp.Length]; 

                //全得点パターンループ
                for(int j = 0; j < dp.Length; j++)　//MAX10000点だったら10001ループ
                {
                    //j点のパターンがありえる場合
                    //ループ1発目はdp[0] = trueなのでこの分岐に入る
                    //以降はループのたびにチェックが入り、trueになっていればその結果をここで利用する
                    if(dp[j] == true)
                    {
                        //i問目が不正解の場合
                        //退避させた値がdpと比べ、falthになってる場合はtrueにそろえてあげる
                        nextDP[j] = true;

                        //全パターンループの値+得点の値がMAX点(10001)より低い時
                        if(j + P[i] < dp.Length)
                        {
                            //退避の値をtrueに更新
                            nextDP[j + P[i]] = true;
                        }
                    }
                }

                //退避の値をdpに戻す
                dp = nextDP;

            }

            //true(ありえるパターン)を数えて出力
            var ans = dp.Count(p => p);
            Console.WriteLine(ans);

        }
    }

    /// <summary>
    /// トップダウン方式、フィボナッチ数列
    /// </summary>
    class Fibonacci
    {
        /// <summary>
        /// メモするフィールド
        /// </summary>
        private long[] _dp = null;

        public long Get(long n)
        {
            //初回インスタンス化
            if(_dp == null)
            {
                //引数+1の要素を持った変数のインスタンスを生成
                //ex)引数100 →　0～100の要素数を持つ(実質101要素)
                _dp = new long[n + 1];
            }

            if(n <= 0)
            {
                return 0;
            }

            if(n <= 2)
            {
                return 1;
            }

            //計算したことある値だったら再利用
            if(_dp[n] != 0)
            {
                return _dp[n];
            }

            _dp[n] = Get(n - 1) + Get(n - 2);

            //使い終わったメモは削除
            if (n == _dp.Length)
            {
                _dp = null;
            }

            return _dp[n];

        }
    }


}
