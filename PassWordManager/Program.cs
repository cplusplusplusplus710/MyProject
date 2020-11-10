using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PassWordManager
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                string mutexName = "Global\\Test1";
                bool createdNew = false;
                Mutex mutex = new Mutex(true, mutexName, out createdNew);
                if (createdNew)
                {
                    try
                    {
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new MainForm());
                    }
                    catch
                    {
                    }
                    finally
                    {
                        mutex.ReleaseMutex();
                        mutex.Close();
                    }
                }
                else
                {
                    MessageBox.Show("既に起動しています。");
                    mutex.Close();
                }
            }
            catch
            {
                MessageBox.Show("既に起動しています。");
                return;
            }
        }
    }
    
}
