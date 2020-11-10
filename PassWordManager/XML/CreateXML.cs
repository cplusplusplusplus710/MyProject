using System.Xml.Linq;

namespace PassWordManager
{
    class CreateXML
    {
        //------------------------------------------------------------------------------------------------
        //Config.Xmlファイル生成
        //------------------------------------------------------------------------------------------------
        public void CreateConfigXML()
        {
            string CurrentPath; //カレントパス

            CurrentPath = System.AppDomain.CurrentDomain.BaseDirectory + @"SYSTEM\XML\";

            //ディレクトリが存在しない場合
            if(System.IO.Directory.Exists(CurrentPath) == false) 
            {
                //ディレクトリフォルダ作成
                System.IO.Directory.CreateDirectory(CurrentPath);
            }

            //バックアップ用ディレクトリが存在しない場合
            if (System.IO.Directory.Exists(CurrentPath + @"BACKUP\") == false)
            {
                //バックアップ用ディレクトリフォルダ作成
                System.IO.Directory.CreateDirectory(CurrentPath + @"BACKUP\");
            }

            //Config.xmlが存在しない場合
            if (System.IO.File.Exists(CurrentPath + "Config.xml") == false)
            {
                var ConfigFile = new XDocument(new XDeclaration("1.0,", "shift_jis", "yes"),
                                    new XElement("Config",
                                        new XComment("Config.xml カレントパス"),
                                        new XElement("CurrentPath",CurrentPath + "Config.xml")));

                ConfigFile.Save(CurrentPath + "Config.xml");
            }

            //バックアップの作成
            GetTimeFunction GTS = new GetTimeFunction();
            int FileNoCount = 1;

            while(true)
            {
                if (System.IO.File.Exists(CurrentPath + @"BACKUP\" + "Config" + "_" + GTS.GetDate("") + "_" + FileNoCount.ToString() + ".xml"))
                {
                    FileNoCount++;
                }
                else
                {
                    break;
                }
            }

            string BackupPath = CurrentPath + @"BACKUP\" + "Config" + "_" + GTS.GetDate("") + "_" + FileNoCount.ToString() + ".xml";

            //XMLファイルを適当に生成し、Configファイルの中身をコピーしてくる
            if (System.IO.File.Exists(BackupPath) == false)
            {
                var ConfigFile = new XDocument(new XDeclaration("1.0,", "shift_jis", "yes"),
                                    new XElement("Config",
                                        new XComment("Config.xml カレントパス"),
                                        new XElement("CurrentPath", CurrentPath + "Config.xml")));

                ConfigFile.Save(BackupPath);

                System.IO.File.Copy(CurrentPath + "Config.xml",
                                    BackupPath,
                                    true);
            }
        }

        //------------------------------------------------------------------------------------------------
        //カレントパス生成
        //------------------------------------------------------------------------------------------------
        public string CurrentPath()
        {
            return System.AppDomain.CurrentDomain.BaseDirectory + @"SYSTEM\XML\Config.xml";
        }

    }
}
