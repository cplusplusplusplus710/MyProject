using System.Xml.Linq;

namespace ChordChecker
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
            if (System.IO.Directory.Exists(CurrentPath) == false)
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
                                        new XElement("CurrentPath", CurrentPath + "Config.xml"),
                                        new XComment("ギターコードパラメータ"),
                                        new XElement("GuitarChord",
                                            new XElement("Chord",new XAttribute("ID",1),
                                            new XElement("Root","C"),
                                            new XElement("Degree", "Major"),
                                            new XElement("Position1",24),
                                            new XElement("Position2",13),
                                            new XElement("Position3", "01"),
                                            new XElement("Position4", ""),
                                            new XElement("BarreFlg",0),
                                            new XElement("Barre", 0),
                                            new XElement("High", 0)),

                                            new XElement("Chord", new XAttribute("ID", 2),
                                            new XElement("Root", "C"),
                                            new XElement("Degree", "6"),
                                            new XElement("Position1", 24),
                                            new XElement("Position2", 13),
                                            new XElement("Position3", "12"),
                                            new XElement("Position4", "01"),
                                            new XElement("BarreFlg", 0),
                                            new XElement("Barre", 0),
                                            new XElement("High", 0)))));

                ConfigFile.Save(CurrentPath + "Config.xml");
            }
        }

        //------------------------------------------------------------------------------------------------
        //database.Xmlファイル生成
        //------------------------------------------------------------------------------------------------
        public void CreatedatabaseXML()
        {
            string CurrentPath; //カレントパス

            CurrentPath = System.AppDomain.CurrentDomain.BaseDirectory + @"SYSTEM\XML\";

            //ディレクトリが存在しない場合
            if (System.IO.Directory.Exists(CurrentPath) == false)
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
            if (System.IO.File.Exists(CurrentPath + "database.xml") == false)
            {
                var ConfigFile = new XDocument(new XDeclaration("1.0,", "shift_jis", "yes"),
                                                    new XElement("database",
                                                        new XComment("database.xml カレントパス"),
                                                        new XElement("CurrentPath", CurrentPath + "database.xml")));

                ConfigFile.Save(CurrentPath + "database.xml");
            }
        }

        //------------------------------------------------------------------------------------------------
        //カレントパス生成 config.xml
        //------------------------------------------------------------------------------------------------
        public string CurrentPath()
        {
            return System.AppDomain.CurrentDomain.BaseDirectory + @"SYSTEM\XML\Config.xml";
        }

        //------------------------------------------------------------------------------------------------
        //カレントパス生成 database.xml
        //------------------------------------------------------------------------------------------------
        public string CurrentPath_database()
        {
            return System.AppDomain.CurrentDomain.BaseDirectory + @"SYSTEM\XML\database.xml";
        }


    }
}
