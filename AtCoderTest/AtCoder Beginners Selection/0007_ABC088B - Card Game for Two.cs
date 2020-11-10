using System;
using System.Collections.Generic;
using System.Text;

namespace AtCoderTest.解いたやつ
{
    class _0007_ABC088B___Card_Game_for_Two
    {
        static void Atcoder1()
        {
            var N = int.Parse(Console.ReadLine());
            var Card = Console.ReadLine().Replace(" ", ",").Split(",");
            var Alice = 0;
            var Bob = 0;

            //ソート
            for (int j = 0; j <= Card.Length - 1; j++)
            {
                for (int k = j + 1; k <= Card.Length - 1; k++)
                {
                    if (int.Parse(Card[j]) < int.Parse(Card[k]))
                    {
                        var Evacuation = Card[j];
                        Card[j] = Card[k];
                        Card[k] = Evacuation;
                    }
                }
            }

            for (int i = 1; i <= N; i++)
            {
                var CardNumber = int.Parse(Card[i - 1]);

                if (i % 2 == 0)
                {
                    Bob = Bob + CardNumber;
                }
                else
                {
                    Alice = Alice + CardNumber;
                }
            }

            var result = Alice - Bob;

            Console.WriteLine(result);

        }

    }
}
