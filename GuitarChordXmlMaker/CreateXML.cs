using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GuitarChordXmlMaker
{
    class CreateXML
    {
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
        //カレントパス生成 database.xml
        //------------------------------------------------------------------------------------------------
        public string CurrentPath_database()
        {
            return System.AppDomain.CurrentDomain.BaseDirectory + @"SYSTEM\XML\database.xml";
        }


    }
}
