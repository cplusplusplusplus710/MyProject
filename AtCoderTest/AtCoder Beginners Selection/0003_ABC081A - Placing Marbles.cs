using System;
using System.Collections.Generic;
using System.Text;

namespace AtCoderTest.解いたやつ
{
    class _0003_ABC081A___Placing_Marbles
    {
        static void Atcoder1()
        {
            var input = Console.ReadLine();
            List<string> inputList = new List<string>();
            foreach (var item in input)
            {
                inputList.Add(item.ToString());
            }

            int count = 0;

            foreach (var item in inputList)
            {
                if (item == "1")
                {
                    count++;
                }
            }

            Console.WriteLine(count);



        }

    }
}
