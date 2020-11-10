using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PassWordManager
{
    internal class LogFunction : LogBase
    {
        private const int RetryLimit = 10; // リトライ回数
        private const int SleepTime = 100; // Sleep時間(ミリ秒)

        private const int LogMode = 0;

        // 初期設定
        internal LogFunction() : base()
        {

        }


        // ------------------------------------------------------------------------------------------------
        // ログを出力する(他クラスで使用する時はこの関数を使う)
        // ------------------------------------------------------------------------------------------------
        // 引数:アプリケーションがわかるもの、例外エラーメッセージ、その他
        public void PutLog(string AppMsg, string AddMsg, string SysMsg)
        {
            LogMessage_Base = "";

            // 第一引数が何か記載されている場合
            if (AppMsg != null)
            {
                LogMessage_Base = LogMessage_Base + AppMsg;

                // 第二引数でTrimしても消えなかった場合
                if (AddMsg.Trim() != "")
                    LogMessage_Base = LogMessage_Base + Environment.NewLine + AddMsg;

                // 第三引数でTrimしても消えなかった場合
                if (SysMsg.Trim() != "")
                    LogMessage_Base = LogMessage_Base + Environment.NewLine + SysMsg;
            }
            else
                // 第一引数が何もなかったら、改行だけ出力
                LogMessage_Base = null;

            string LogParts = Environment.NewLine + ">                   :";
            LogMessage_Base = LogMessage_Base.Replace(Environment.NewLine, LogParts);

            // ログを出力する
            PutLogThread();
        }

        // ------------------------------------------------------------------------------------------------
        // ログを出力する(Baseの関数を使用する関数。この関数はPutLogで使っているため、他クラスで使わない)
        // ------------------------------------------------------------------------------------------------
        public void PutLogThread()
        {
            int RetryCount = 0;
            bool RetryJudge = true;

            while (RetryJudge)
            {
                try
                {
                    OpenLog_Base();
                    PutLog_Base(LogMessage_Base);
                    CloseLog_Base();

                    RetryJudge = false;
                }
                catch (System.IO.IOException ex)
                {
                    CloseLog_Base();

                    // リトライ
                    RetryCount = RetryCount + 1;

                    if (RetryCount == RetryLimit)
                        throw ex;

                    // 待機
                    System.Threading.Thread.Sleep(SleepTime);
                }

                catch (Exception ex)
                {
                    CloseLog_Base();
                    throw ex;
                }
            }
        }
    }




}


