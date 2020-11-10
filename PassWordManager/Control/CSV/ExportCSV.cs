using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;
using System.Windows.Forms;

namespace PassWordManager
{
    class ExportCSV
    {
        //フィールド
        LogFunction LF;
        private CreateXML createConfigXML = new CreateXML();
        private XDocument XmlDoc;

        private const string FileName = "PassWordManager_ExportCSV.csv";

        string ExportPath;
        FileStream FS;
        StreamWriter SW;

        public void CreateCSVFile(string Path)
        {
            if(Path == "")
            {
                MessageBox.Show("エクスポートを実行するディレクトリパスを設定してください。",
                "Infomation", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
                return;
            }

            ExportPath = Path;

            try
            {
                //既にcsvが存在していたら上書きするので消す
                if(System.IO.File.Exists(ExportPath + @"\" + FileName))
                {
                    System.IO.File.Delete(ExportPath + @"\" + FileName);
                }

                //File作成
                StreamWriter CSVCreate = System.IO.File.CreateText(ExportPath + @"\" + FileName);
                CSVCreate.Close();

                //書き込みオブジェクト
                FS = File.OpenWrite(ExportPath + @"\" + FileName);
                SW = new StreamWriter(FS, Encoding.GetEncoding("shift-jis"));

                //カーソルを最後に
                SW.BaseStream.Seek(0, SeekOrigin.End);

                PutCSVData();

            }
            catch(Exception ex)
            {
                MessageBox.Show("エクスポートを実行するディレクトリパスが不正です。"　+
                                "\r\nディレクトリパスをお確かめください。",
                "Infomation", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);

                LF = new LogFunction();
                LF.PutLog("CreateCSVFile", ex.ToString(), "");

                return;
            }
        }

        private void PutCSVData()
        {
            string ServiceName;
            string ID;
            string PassWord;
            XmlDoc = XDocument.Load(createConfigXML.CurrentPath(), LoadOptions.PreserveWhitespace);

            try
            {
                var query = from y in XmlDoc.Descendants("Data")
                            select y;

                foreach(XElement item in query)
                {
                    ServiceName = item.Element("ServiceName").Value;
                    ID = item.Element("ID").Value;
                    PassWord = item.Element("PassWord").Value;

                    SW.WriteLine(ServiceName + "," + ID + "," + PassWord);
                }
                                
                SW.Close();

                MessageBox.Show("csvファイルのエクスポートが完了しました。" ,
                "Infomation", MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                LF = new LogFunction();
                LF.PutLog("WriteXml", ex.ToString(), "");
            }
        }

    }
}
