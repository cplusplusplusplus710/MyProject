using System;
using System.IO;
using System.Text;

namespace TextMergePG
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("フォルダを読み込み、フォルダ内のテキストデータをマージします。");
            Console.WriteLine("読み込みたいフォルダパスを入力して何かキーを押して下さい。");
            string DesktopFolderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + @"\MergedText";
            string FolderPath = "";

            try
            {
                FolderPath = Console.ReadLine();
            }
            catch
            {
                Console.WriteLine("フォルダパスの値が不正です。プログラムを終了します。何かキーを押して下さい。");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("フォルダの読み込みを開始します。");
            Console.WriteLine("フォルダ内のテキストデータをマージしています。");

            string[] files = System.IO.Directory.GetFiles(FolderPath, "*", System.IO.SearchOption.AllDirectories);
            System.IO.Directory.CreateDirectory(DesktopFolderPath);

            foreach(var item in files)
            {
                using (StreamWriter sw = new StreamWriter(DesktopFolderPath + @"\MergedText.txt", true,Encoding.GetEncoding("utf-8")))
                {
                    using (StreamReader sr = new StreamReader(item))
                    {
                        string s = sr.ReadToEnd().Trim();
                        sw.WriteLine(s);
                    }
                }
            }

            Console.WriteLine("テキストデータのマージが完了しました。何かキーを押して終了して下さい。");
            Console.ReadKey();
            return;
        }
    }
}
