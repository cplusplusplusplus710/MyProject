using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace test.txt_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("test.txtを生成します。何かキーを押してください。");
            Console.ReadKey();

            FileStream fsm = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) 
                + @"\test.txt",FileMode.Create);
            StreamWriter stw = new StreamWriter(fsm, Encoding.GetEncoding(932));

            int i = 0;

            while (i != 99999)
            {
                stw.WriteLine("No." + i + ":テストです。");
                i++;
            }

            stw.Close();
            Console.WriteLine("デスクトップにtest.txtが生成できました。何かキーを押してください。終了します。");
            Console.ReadKey();



        }
    }
}
