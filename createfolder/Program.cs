﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace createfolder
{
    class Program
    {
        static string BasePath = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\ManyFolder\";

        static void Main(string[] args)
        {
            Console.WriteLine("フォルダーを作成します。");
            Console.WriteLine("作成先：「" + BasePath + "」");
            Console.WriteLine("フォルダーを作成しています。");

            double MaxFolder = 5500; //実際のフォルダ数はMaxFolder設定値+1となる。
            
            List<double> list = new List<double>() { 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9, 1.0 };
            List<int> PercentValueList = new List<int>();
            int listCount = 0;

            while(true)
            {
                PercentValueList.Add(Convert.ToInt32(MaxFolder * list[listCount]));

                if(listCount == 9)
                {
                    break;
                }

                listCount++;
            }

            int i = 0;
            while(true)
            {
                if(i == 0)
                {
                    Directory.CreateDirectory(BasePath + "新しいフォルダー");
                    //作成日時の設定（現在の時間にする）
                    System.IO.Directory.SetCreationTime(BasePath + "新しいフォルダー", DateTime.Now);
                    //更新日時の設定
                    System.IO.Directory.SetLastWriteTime(BasePath + "新しいフォルダー", DateTime.Now);
                    //アクセス日時の設定
                    System.IO.Directory.SetLastAccessTime(BasePath + "新しいフォルダー", DateTime.Now);
                }
                else if(i >= 1)
                {
                    Directory.CreateDirectory(BasePath + "新しいフォルダー(" + i + ")");
                    //作成日時の設定（現在の時間にする）
                    System.IO.Directory.SetCreationTime(BasePath + "新しいフォルダー(" + i + ")", DateTime.Now);
                    //更新日時の設定
                    System.IO.Directory.SetLastWriteTime(BasePath + "新しいフォルダー(" + i + ")", DateTime.Now);
                    //アクセス日時の設定
                    System.IO.Directory.SetLastAccessTime(BasePath + "新しいフォルダー(" + i + ")", DateTime.Now);
                }

                for(int j = 0; j < 9; j++)
                {
                    if(i == PercentValueList[j])
                    {
                        switch(j)
                        {
                            case 0:
                                Console.WriteLine("10%");
                                break;
                            case 1:
                                Console.WriteLine("20%");
                                break;
                            case 2:
                                Console.WriteLine("30%");
                                break;
                            case 3:
                                Console.WriteLine("40%");
                                break;
                            case 4:
                                Console.WriteLine("50%");
                                break;
                            case 5:
                                Console.WriteLine("60%");
                                break;
                            case 6:
                                Console.WriteLine("70%");
                                break;
                            case 7:
                                Console.WriteLine("80%");
                                break;
                            case 8:
                                Console.WriteLine("90%");
                                break;
                            case 9:
                                Console.WriteLine("100%");
                                break;
                        }
                    }
                }

                if(i == MaxFolder)
                {
                    break;
                }

                i++;

            }

            Console.WriteLine("100%");
            Console.WriteLine("フォルダーを作成しました。何かキーを押して終了してください。");
            Console.ReadKey();
        }
    }
}
