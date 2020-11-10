using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtCoderTest._01_GoTo水色
{
    //https://atcoder.jp/contests/abc122/tasks/abc122_b

    class _003_B___ATCoder
    {
        static void solve()
        {
            var S = Console.ReadLine();
            List<string> ACGT = new List<string> { "A", "C", "G", "T" };

            bool[] b = new bool[S.Length];
            var ans = 0;

            for (int i = 1; i <= S.Length; i++)
            {
                //退避
                var _b = b;

                foreach (var item in ACGT)
                {
                    if (Convert.ToString(S[i - 1]) == item)
                    {
                        _b[i - 1] = true;
                        b = _b;
                        break;
                    }
                }

                //ACGT以外の文字だったら
                if (_b[i - 1] == false)
                {
                    ans = Math.Max(ans, _b.Count(p => p));
                    b = new bool[S.Length];
                }
            }

            ans = Math.Max(ans, b.Count(p => p));
            Console.WriteLine(ans);

        }

    }
}
