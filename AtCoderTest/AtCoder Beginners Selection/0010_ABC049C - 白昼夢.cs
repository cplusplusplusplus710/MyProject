using System;
using System.Collections.Generic;
using System.Text;

namespace AtCoderTest.解いたやつ
{
    class _0010_ABC049C___白昼夢
    {
        static void Atcoder1()
        {
            var S = Console.ReadLine();
            List<string> T_List = new List<string> { "dream",
                                                    "dreamer",
                                                    "erase",
                                                    "eraser"};
            var CheckWord_S = "";
            var T = "";

            for (int i = S.Length - 1; i >= 0; i--)
            {
                CheckWord_S = S[i] + CheckWord_S;

                foreach (var item in T_List)
                {
                    if (CheckWord_S == item)
                    {
                        T = CheckWord_S + T;
                        CheckWord_S = "";
                    }
                }
            }

            if (S == T)
            {
                Console.Write("YES");
            }
            else
            {
                Console.Write("NO");
            }


        }

    }
}
