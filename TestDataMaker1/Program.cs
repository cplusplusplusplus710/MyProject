using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDataMaker1
{
    class Program
    {
        static void Main(string[] args)
        {
            //CreateCSV();
            TestRandom();
        }

        public static void CreateCSV()
        {
            string ID = "";
            int IDStart = 1;
            string Name = "";
            int Price = 0;
            int Ship = 0;
            int Quantity = 0;
            string SerialNo = "";
            string Genre = "";
            string Origin = "";

            string DataPath = @"C:\Work\_kohira\Excel\TestDataAdd.csv";
            int MaxRoop = 10000;

            List<string> NameList = new List<string>(){ "みかん","ぶどう","りんご","豚肉","メロン",
                                                     "砂糖","そうめん","小麦粉","白菜","小松菜","白菜",
                                                     "鮭","わかめ","鶏肉","マグロ","ホタテ"};
            List<string> OriginList = new List<string>() { "和歌山県","三重県","青森県","東京都","秋田県","大阪府",
                                                     "アメリカ合衆国","島根県","福岡県","愛媛県"};
            List<string> GenreList = new List<string>() { "果物", "食肉", "調味料", "麺類", "原料", "野菜", "魚介類" };
            List<int> PriceList = new List<int>() { 100, 250, 120, 108, 580, 320, 200, 600, 128, 100, 350, 23, 49, 780, 2500 };
            List<int> ShipList = new List<int>() { 108, 210, 540, 1080 };

            Console.WriteLine("データを生成します。");
            FileStream fs = System.IO.File.Create(DataPath);
            fs.Close();

            List<double> list = new List<double>() { 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9, 1.0 };
            List<int> PercentValueList = new List<int>();
            int listCount = 0;
            while (true)
            {
                PercentValueList.Add(Convert.ToInt32(MaxRoop * list[listCount]));

                if (listCount == 9)
                {
                    break;
                }

                listCount++;
            }

            Random QuantityRandom = new Random();
            Random SerialNoRandom = new Random();
            Random OriginRandom = new Random();

            using (StreamWriter sw = new StreamWriter(DataPath))
            {
                int RoopCount = 0;
                int Seed = Environment.TickCount;

                while (true)
                {
                    Random SeedRoopCountRondom1 = new Random();
                    int SeedRoopCount1 = SeedRoopCountRondom1.Next(50);
                    for (int i = 0; i < 50; i++)
                    {
                        QuantityRandom = new Random(Seed++);
                        if (i == SeedRoopCount1)
                        {
                            break;
                        }
                    }

                    Random SeedRoopCountRondom2 = new Random();
                    int SeedRoopCount2 = SeedRoopCountRondom1.Next(100);
                    for (int i = 0; i < 100; i++)
                    {
                        SerialNoRandom = new Random(Seed++);
                        if (i == SeedRoopCount2)
                        {
                            break;
                        }
                    }

                    Random SeedRoopCountRondom3 = new Random();
                    int SeedRoopCount3 = SeedRoopCountRondom1.Next(150);
                    for (int i = 0; i < 150; i++)
                    {
                        OriginRandom = new Random(Seed++);
                        if (i == SeedRoopCount3)
                        {
                            break;
                        }
                    }


                    ID = IDStart.ToString("D8");
                    IDStart++;

                    System.Threading.Thread.Sleep(25);
                    Random NameRandom = new Random();
                    int n = NameRandom.Next(14);
                    Name = NameList[n];

                    switch (Name)
                    {
                        case "みかん":
                            Price = PriceList[0];
                            Ship = ShipList[1];
                            Quantity = QuantityRandom.Next(1, 100000);
                            SerialNo = "E" + SerialNoRandom.Next(1, 9999999).ToString("D7");
                            Genre = GenreList[0];
                            Origin = OriginList[OriginRandom.Next(9)];
                            break;

                        case "ぶどう":
                            Price = PriceList[1];
                            Ship = ShipList[1];
                            Quantity = QuantityRandom.Next(1, 100000);
                            SerialNo = "E" + SerialNoRandom.Next(1, 9999999).ToString("D7");
                            Genre = GenreList[0];
                            Origin = OriginList[OriginRandom.Next(9)];
                            break;

                        case "りんご":
                            Price = PriceList[2];
                            Ship = ShipList[1];
                            Quantity = QuantityRandom.Next(1, 100000);
                            SerialNo = "E" + SerialNoRandom.Next(1, 9999999).ToString("D7");
                            Genre = GenreList[0];
                            Origin = OriginList[OriginRandom.Next(9)];
                            break;

                        case "豚肉":
                            Price = PriceList[3];
                            Ship = ShipList[2];
                            Quantity = QuantityRandom.Next(1, 100000);
                            SerialNo = "E" + SerialNoRandom.Next(1, 9999999).ToString("D7");
                            Genre = GenreList[1];
                            Origin = OriginList[OriginRandom.Next(9)];
                            break;

                        case "メロン":
                            Price = PriceList[4];
                            Ship = ShipList[3];
                            Quantity = QuantityRandom.Next(1, 100000);
                            SerialNo = "E" + SerialNoRandom.Next(1, 9999999).ToString("D7");
                            Genre = GenreList[0];
                            Origin = OriginList[OriginRandom.Next(9)];
                            break;

                        case "砂糖":
                            Price = PriceList[5];
                            Ship = ShipList[3];
                            Quantity = QuantityRandom.Next(1, 100000);
                            SerialNo = "E" + SerialNoRandom.Next(1, 9999999).ToString("D7");
                            Genre = "調味料";
                            Origin = OriginList[OriginRandom.Next(9)];
                            break;

                        case "そうめん":
                            Price = PriceList[6];
                            Ship = ShipList[2];
                            Quantity = QuantityRandom.Next(1, 100000);
                            SerialNo = "E" + SerialNoRandom.Next(1, 9999999).ToString("D7");
                            Genre = "麺類";
                            Origin = OriginList[OriginRandom.Next(9)];
                            break;

                        case "小麦粉":
                            Price = PriceList[7];
                            Ship = ShipList[3];
                            Quantity = QuantityRandom.Next(1, 100000);
                            SerialNo = "E" + SerialNoRandom.Next(1, 9999999).ToString("D7");
                            Genre = "原料";
                            Origin = OriginList[OriginRandom.Next(9)];
                            break;

                        case "白菜":
                            Price = PriceList[8];
                            Ship = ShipList[0];
                            Quantity = QuantityRandom.Next(1, 100000);
                            SerialNo = "E" + SerialNoRandom.Next(1, 9999999).ToString("D7");
                            Genre = "野菜";
                            Origin = OriginList[OriginRandom.Next(9)];
                            break;

                        case "小松菜":
                            Price = PriceList[9];
                            Ship = ShipList[1];
                            Quantity = QuantityRandom.Next(1, 100000);
                            SerialNo = "E" + SerialNoRandom.Next(1, 9999999).ToString("D7");
                            Genre = "野菜";
                            Origin = OriginList[OriginRandom.Next(9)];
                            break;

                        case "鮭":
                            Price = PriceList[10];
                            Ship = ShipList[2];
                            Quantity = QuantityRandom.Next(1, 100000);
                            SerialNo = "E" + SerialNoRandom.Next(1, 9999999).ToString("D7");
                            Genre = "魚介類";
                            Origin = OriginList[OriginRandom.Next(9)];
                            break;

                        case "わかめ":
                            Price = PriceList[11];
                            Ship = ShipList[0];
                            Quantity = QuantityRandom.Next(1, 100000);
                            SerialNo = "E" + SerialNoRandom.Next(1, 9999999).ToString("D7");
                            Genre = "魚介類";
                            Origin = OriginList[OriginRandom.Next(9)];
                            break;

                        case "鶏肉":
                            Price = PriceList[12];
                            Ship = ShipList[0];
                            Quantity = QuantityRandom.Next(1, 100000);
                            SerialNo = "E" + SerialNoRandom.Next(1, 9999999).ToString("D7");
                            Genre = "食肉";
                            Origin = OriginList[OriginRandom.Next(9)];
                            break;

                        case "マグロ":
                            Price = PriceList[13];
                            Ship = ShipList[3];
                            Quantity = QuantityRandom.Next(1, 100000);
                            SerialNo = "E" + SerialNoRandom.Next(1, 9999999).ToString("D7");
                            Genre = "魚介類";
                            Origin = OriginList[OriginRandom.Next(9)];

                            break;

                        case "ホタテ":
                            Price = PriceList[14];
                            Ship = ShipList[2];
                            Quantity = QuantityRandom.Next(1, 100000);
                            SerialNo = "E" + SerialNoRandom.Next(1, 9999999).ToString("D7");
                            Genre = "魚介類";
                            Origin = OriginList[OriginRandom.Next(9)];
                            break;
                    }

                    sw.WriteLine(ID + "," + Name + "," + Price + "," + Ship + ","
                                    + Quantity + "," + SerialNo + "," + Genre + ","
                                    + Origin);

                    for (int j = 0; j < 9; j++)
                    {
                        if (RoopCount == PercentValueList[j])
                        {
                            switch (j)
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


                    if (RoopCount == MaxRoop)
                    {
                        Console.WriteLine("100%");
                        break;
                    }

                    Console.WriteLine(RoopCount);
                    RoopCount++;

                };

            }

            Console.WriteLine("データ出力完了");
            Console.ReadKey();

        }

        //めっちゃばらけた乱数が生成できる
        public static void TestRandom()
        {
            string DataPath = @"C:\Work\_kohira\Excel\RandomData.csv";

            Console.WriteLine("データを生成します。");
            FileStream fs = System.IO.File.Create(DataPath);
            fs.Close();

            using (StreamWriter sw = new StreamWriter(DataPath))
            {
                int RoopCount = 0;
                int Seed = Environment.TickCount;
                Random rnddd = new Random();
                int MaxRoop = 100;


                while (true)
                {
                    Random SeedRoopCountRondom1 = new Random();
                    int SeedRoopCount1 = SeedRoopCountRondom1.Next(200);
                    for (int i = 0; i < 200; i++)
                    {
                        rnddd = new Random(Seed++);
                        if (i == SeedRoopCount1)
                        {
                            break;
                        }
                    }

                    int value = rnddd.Next(1, 100000);
                    System.Threading.Thread.Sleep(51);
                    sw.WriteLine(value);

                    if (RoopCount == MaxRoop)
                    {
                        break;
                    }

                    RoopCount++;

                }

                Console.WriteLine("データ出力完了");
                Console.ReadKey();


            }
        }
    }
}
