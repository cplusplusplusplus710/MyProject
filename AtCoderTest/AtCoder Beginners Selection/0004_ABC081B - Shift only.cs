using System;
using System.Collections.Generic;
using System.Text;

namespace AtCoderTest.解いたやつ
{
    class _0004_ABC081B___Shift_only
    {
        static bool checkvalue = true;

        static void Atcoder1()
        {
            int inputA = 0;
            List<int> Inputlist = new List<int>();
            int result = 0;

            inputA = int.Parse(Console.ReadLine());
            var splitinput = Console.ReadLine().Split(" ");
            foreach (var item in splitinput)
            {
                Inputlist.Add(int.Parse(item));
            }

            foreach (var item in Inputlist)
            {
                checkvalue = CheckValue(item);
            }

            if (checkvalue == false)
            {
                Console.Write(result);
                return;
            }

            result++;

            while (true)
            {
                for (int i = 0; i < inputA - 1; i++)
                {
                    Inputlist[i] = Inputlist[i] / 2;
                }
                foreach (var item in Inputlist)
                {
                    checkvalue = CheckValue(item);
                }

                if (checkvalue == false)
                {
                    Console.Write(result);
                    break;
                }
                else
                {
                    result++;
                }

            }


        }

        static bool CheckValue(int value)
        {
            if (checkvalue == false)
            {
                return false;
            }

            var c = value % 2;
            if (c == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
