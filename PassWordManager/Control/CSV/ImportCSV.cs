using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PassWordManager
{
    class ImportCSV
    {
        //フィールド
        LogFunction LF;
        private CreateXML createConfigXML = new CreateXML();
        string ImportPath;
        byte[] GetBinData;
        private XDocument XmlDoc;
        List<byte[]> ByteList;
        List<string> ConvertToStringByteList;

        //------------------------------------------------------------------------------------------------
        //CSVファイルをバイナリデータで取り込みしてリスト化
        //------------------------------------------------------------------------------------------------
        public void ImportCSVGetBin(string path)
        {
            ImportPath = path;

            GetBinData = null;
            System.IO.FileStream FileStream = null;
            System.IO.BinaryReader BinaryReader = null;

            try
            {
                if (Path.GetExtension(ImportPath) == ".CSV")
                {

                }
                else if (Path.GetExtension(ImportPath) != ".csv")
                {
                    MessageBox.Show("csvファイルが選択されていません。\r\ncsvファイルを選択してください。",
                    "Infomation", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                    return;

                }
            }
            catch
            {
                MessageBox.Show("ファイルが正しくありません。\r\nパスを再度お確かめください。",
                "Infomation", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                // フォルダパスのファイルを開くオブジェクト
                FileStream = new System.IO.FileStream(ImportPath, System.IO.FileMode.Open);
                // FileStreamの内容をバイナリーデータで読み取るオブジェクト
                BinaryReader = new System.IO.BinaryReader(FileStream);

                // ファイルの最後までをinteger型で取り込む
                int Length = System.Convert.ToInt32(FileStream.Length);

                // ファイルの最後までをバイナリ型で読み込み、変数にいれる
                GetBinData = BinaryReader.ReadBytes(Length);
                FileStream.Close();
            }
            catch (Exception ex)
            {
                LF = new LogFunction();
                LF.PutLog("ImportCSVGetBin", ex.ToString(), "");
            }

            int StartPoint = 0;
            int EndPoint = 0;
            int LengthValue = 0;
            ByteList = new List<byte[]>();

            while (EndPoint >= 0)
            {
                EndPoint = SearchCRLF(StartPoint);

                if (EndPoint < 0)
                {
                    LengthValue = GetBinData.Length - StartPoint;

                    if (LengthValue <= 0)
                        break;
                }
                else
                // CRLF分減らす
                LengthValue = EndPoint - StartPoint + 1 - 2;

                // 行データ取得
                byte[] LineVal = GetByteFromByte(GetBinData, StartPoint, LengthValue);

                ByteList.Add(LineVal);

                StartPoint = EndPoint + 1;
            }

            //不正データチェック
            int count2 = 0;
            foreach (byte[] item2 in ByteList)
            {
                string d = System.Text.Encoding.Default.GetString(ByteList[count2]);
                count2++;

                string[] Values2 = d.Split(',');
                ConvertToStringByteList = new List<string>();
                ConvertToStringByteList.AddRange(Values2);

                //不正なCSVデータが混ざっていた場合、メッセージを出す
                if (ConvertToStringByteList.Count != 3)
                {
                    MessageBox.Show("不正なデータが存在しています。\r\ncsvファイルを確認してください。" +
                                    "\r\n場所:" + count2 + "行目",
                    "Infomation", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                    return;
                }
            }

            //XMLへ書き込み
            int count = 0;
            foreach(byte[] item in ByteList)
            {
                string s = System.Text.Encoding.Default.GetString(ByteList[count]);
                count++;

                string[] Values = s.Split(',');
                ConvertToStringByteList = new List<string>();
                ConvertToStringByteList.AddRange(Values);

                XmlDoc = new XDocument();
                XmlDoc = XDocument.Load(createConfigXML.CurrentPath());

                //Xmlファイルに書き込み
                var ServiceNameSplit = ConvertToStringByteList[0];
                var IDSplit = ConvertToStringByteList[1];
                var PassWordSplit = ConvertToStringByteList[2];

                try
                {
                    var query = (from y in XmlDoc.Descendants("Data")
                                 select y);

                    int Count = query.Elements("Data").Count();

                    var writeXml = new XElement("Data",
                    new XAttribute("ID", Count + 1),
                    new XElement("ServiceName", ServiceNameSplit),
                    new XElement("ID", IDSplit),
                    new XElement("PassWord", PassWordSplit));

                    XmlDoc.Elements().First().Add(writeXml);
                    XmlDoc.Save(createConfigXML.CurrentPath());
                }
                catch (Exception ex)
                {
                    LF = new LogFunction();
                    LF.PutLog("WriteXml", ex.ToString(), "");
                }
            }

            MessageBox.Show("csvファイルのインポートが完了しました。",
            "Infomation", MessageBoxButtons.OK,
            MessageBoxIcon.Information);

        }

        // ------------------------------------------------------------------------------------------------
        // CRLF探索  読み込みデータからのCRLFの位置を返す
        // ------------------------------------------------------------------------------------------------
        protected int SearchCRLF(int StartPoint)
        {
            int ResultCRLF = -1;

            // -2なのは-1の位置は空の行になるから？
            for (int i = StartPoint; i <= GetBinData.Length - 2; i++)
            {
                // &HD:13　キャリッジリターン　&HA:10  ラインフィード
                if (GetBinData[i] == 0xD & GetBinData[i + 1] == 0xA)
                {
                    ResultCRLF = i + 1;
                    break;
                }
            }

            return ResultCRLF;
        }

        // ------------------------------------------------------------------------------------------------
        // Byte配列から位置、長さでByteを取得する
        // ------------------------------------------------------------------------------------------------
        protected byte[] GetByteFromByte(byte[] InByte, int StartPoint, int LengthValue)
        {
            byte[] OutByte;

            if (LengthValue == 0)
                LengthValue = InByte.Length - StartPoint;

            if (LengthValue < 1)
            {
                OutByte = new byte[0] { };
                return OutByte;
            }

            OutByte = new byte[LengthValue - 1 + 1];

            for (int i = 0; i <= LengthValue - 1; i++)
            {
                if (StartPoint + i < InByte.Length)
                    OutByte[i] = InByte[StartPoint + i];
            }

            return OutByte;

        }

    }
}
