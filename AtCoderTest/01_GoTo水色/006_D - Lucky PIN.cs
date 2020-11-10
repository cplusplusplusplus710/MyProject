using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderTest._01_GoTo水色
{
    //https://atcoder.jp/contests/sumitrust2019/tasks/sumitb2019_d

    class _006_D___Lucky_PIN
    {
        static void solve()
        {
            //半角数字からなる文字列Sから3文字取り出してその順番に並べたもの
            //000から999までの1000パターンを全探索する

            var n = int.Parse(Console.ReadLine());
            var s = Console.ReadLine();
            int i;　//退避用

            //すべての要素に3ケタ10進数の処理を施す
            Console.WriteLine(Enumerable.Range(0, 1000).Select(x => $"{x:D3}")
                                        //p = Rangeで回しているパターン値
                                        .Count(p => (i = s.IndexOf(p[0])) > -1 　　　//文字列sの左から一文字目がp[0]と一致する　戻り値の1はiに利用する
                                               && (i = s.IndexOf(p[1], i + 1)) > -1  //かつ二文字目がp[1]と一致する
                                               && s.IndexOf(p[2], i + 1) > -1));　　 //かつ三文字目がp[2]と一致する
        }
    }
}
