using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderTest._01_GoTo水色
{
    //https://atcoder.jp/contests/pakencamp-2019-day3/tasks/pakencamp_2019_day3_c

    class _004_C___カラオケ
    {
       static void solve()
        {
            //入力パラメーターなし(引数なし)のデリゲート
            //標準入力を読みとり、Splitしてint型の配列に代入する
            Func<int[]> read = () => Console.ReadLine().Split().Select(int.Parse).ToArray();

            //デリゲートを実行し、結果を変数に代入
            //この読み取りでは1ライン目(NとMの値)を読み取る
            var h = read();

            //N(生徒数)とM(選べる曲数)を変数に代入
            int n = h[0], m = h[1];

            //2行目以降を読み取り
            //長さがNの配列を用意し、すべてのコレクションに対し、デリゲートのメソッドを実行する
            var a = new int[n].Select(_ => read()).ToArray();

            //Long型で0を代入する
            var M = 0L;

            //曲数だけループ
            for(int j = 0; j < m; j++)
            {
                //現在の曲+1(次の曲)から曲数だけループ
                for (int k = j + 1; k < m; k++)
                {
                    //0からn(生徒数)までの配列の範囲で、曲の得点をそれぞれ比較し、一番大きい得点を算出
                    //各生徒の最大得点が出揃ったところでSumで合計する。出てきた値はMに代入
                    //i = Rangeのループ数　j = 曲1　k = 曲2
                    M = Math.Max(M, Enumerable.Range(0, n).Sum(i => (long)Math.Max(a[i][j], a[i][k])));
                }
            }
        }
        
        //static void solve()
        //{
        //    var input_NM = Console.ReadLine().Split(" ");
        //    List<int> list = new List<int>();
            
        //    var N = int.Parse(input_NM[0]); //生徒総数
        //    var M = int.Parse(input_NM[1]); //総曲数

        //    while(true)
        //    {
        //        var input_Songs = Console.ReadLine().Split(" ");

        //        if (input_Songs[0] == "" || input_Songs == null)
        //            break;

        //        foreach(var item in input_Songs)
        //        {
        //            list.Add(int.Parse(item));
        //        }
        //    }

        //    //得点リストを作成
        //    //key = 生徒番号_〇曲目
        //    //value = 得点
        //    var GetScoreList = new Dictionary<Tuple<int,int>, int>();
        //    for(int g = 0; g <= N - 1; g++)
        //    {
        //        for(int h = 0; h <= M - 1; h++)
        //        {
        //            GetScoreList.Add(new Tuple<int, int>(g,h), 0);
        //        }
        //    }

        //    //出力用
        //    var resltList = new List<int>();

        //    for(int i = 0; i <= N - 1; i++)
        //    {
        //        for(int j = 0; j <= M - 1; j++)
        //        {
        //            if(j == M - 1)
        //            {
        //                while(true)
        //                {
        //                    GetScoreList[new Tuple<int,int>(i,j)] = list[i * (M-1)];　//??
        //                }
        //            }
        //        }
        //    }
        //}
    }
}
