// ログ基底クラス
using System;
using System.Collections.Generic;
using System.IO;

namespace ChordChecker
{
    class LogBase
    {
        //フィールド
        public GetTimeFunction GTS;

        public int LogOpenFlg_Base;           //ログオープンフラグ
        public string LogFolderPath_Base;　　 //ログ出力パス(フォルダ)
        public string LogFilePath_Base;　　　 //ログ出力パス(ファイル)

        public System.IO.FileStream FS;
        public System.IO.StreamWriter SW;

        public string LogMessage_Base;

        //初期設定
        public LogBase()
        {
            //変数を初期化する
            LogOpenFlg_Base = 0;

            //ログのディレクトリパスの文字列を生成する
            GTS = new GetTimeFunction();
            LogFolderPath_Base = System.AppDomain.CurrentDomain.BaseDirectory + @"SYSTEM\Log";

            LogFilePath_Base = LogFolderPath_Base + @"\" + GTS.GetDate("") + ".log";

            LogMessage_Base = "";

        }

        // ------------------------------------------------------------------------------------------------
        // ログファイルオープン
        // ------------------------------------------------------------------------------------------------
        // 出力ディレクトリが存在しなければ生成する
        // 出力ファイルが存在しなければ、生成する
        // 出力ファイルが存在すれば、追加出力を行う
        // ログファイル名は、 タスク名称_ログ日付.LOG で出力する
        // ログオープンフラグ を 1 にする
        public void OpenLog_Base()
        {

            if (LogOpenFlg_Base == 1)
                return;

            try
            {
                FS = null;
                SW = null;

                //ログのディレクトリが存在しない場合
                if (System.IO.Directory.Exists(LogFolderPath_Base) == false)
                {
                    //ログディレクトリフォルダ生成
                    System.IO.Directory.CreateDirectory(LogFolderPath_Base);
                }

                //ファイルが存在しない時
                if (System.IO.File.Exists(LogFilePath_Base) == false)
                {
                    //ファイル書き込み用のオブジェクト作成
                    //この時点で空のログデータができあがる
                    System.IO.StreamWriter SWF = System.IO.File.CreateText(LogFilePath_Base);
                    SWF.Close();

                }

                //ログデータをOpenする
                FS = System.IO.File.OpenWrite(LogFilePath_Base);
                // FileStreamとStreamWriterをいっぺんにNEWする
                SW = new System.IO.StreamWriter(FS);
                //ログデータの末尾にSeekする
                SW.BaseStream.Seek(0, System.IO.SeekOrigin.End);

                LogOpenFlg_Base = 1;

            }

            catch (Exception ex)
            {
                CloseLog_Base();
                throw ex;
            }
        }

        // ------------------------------------------------------------------------------------------------
        // ログファイルクローズ
        // ------------------------------------------------------------------------------------------------
        public void CloseLog_Base()
        {
            if (LogOpenFlg_Base == 0)
                return;

            if ((SW == null) == false)
                SW.Close();


            if ((FS == null) == false)
                FS.Close();

            LogOpenFlg_Base = 0;

        }

        // ------------------------------------------------------------------------------------------------
        // ログファイルにデータを出力する
        // ------------------------------------------------------------------------------------------------
        public void PutLog_Base(string value)
        {
            LogMessage_Base = value;

            if (LogOpenFlg_Base == 0)
                throw new Exception();

            //ログを出力する
            string WriteLogMessage = "";

            if ((value == null) == false)
            {
                string WriteDate = GTS.GetDate("/");
                string WriteTime = GTS.GetTime(":");

                WriteLogMessage = WriteDate + " " + WriteTime + " " + value;
            }

            // ログデータに書き込み
            SW.WriteLine(WriteLogMessage);

            // 書き込み内容はバッファリングされているのでフラッシュさせる
            SW.Flush();

        }


    }



}
