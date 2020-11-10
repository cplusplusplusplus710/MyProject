using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleTimer
{
    public partial class Form1 : Form
    {
        DateTime dt = DateTime.Now;
        
        int i = 0;
        //int j = 0;

        bool ONFlg = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            label1_Date.Text = dt.ToString("yyyy/MM/dd (ddd) HH:mm:ss");

            StartTimer2();

        }

        //スタートボタン
        private void button1_start_Click(object sender, EventArgs e)
        {
            label1_MainTimer.Text = "";
            timer1.Enabled = true;
        }

        //タイマーイベント
        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;
            if (0 == i)
            {
                timer1.Enabled = false;
                this.Activate();
            }
            viewtime();
        }

        private void viewtime()
        {
            label1_MainTimer.Text = "" + i / 36000 % 10 + i / 3600 % 10 +
                                    ":" + i / 600 % 6 + i / 60 % 10 +
                                    ":" + i / 10 % 6 + i % 10;
        }

        private void StartTimer2()
        {
            timer2.Enabled = true;
        }

        private void button2_stop_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            DateTime dt2 = DateTime.Now;

            /*label1_Date.Text = Convert.ToString(j);
            j++*/
            label1_Date.Text = dt2.ToString("yyyy/MM/dd (ddd) HH:mm:ss");
        }

        private void button1_Reset_Click(object sender, EventArgs e)
        {
            if(timer1.Enabled == true)
            {
                return;
            }
            else
            {
                label1_MainTimer.Text = "00:00:00";
                i = 0;
            }
        }

        private void button1_HOUR_Click(object sender, EventArgs e)
        {
            var ButtonText = ((Button)sender).Text;

            switch(ButtonText)
            {
                case "HOUR":
                    i = i + 3600;
                    if(ONFlg == true)
                    {
                        while(true)
                        {
                            button1_HOUR.PerformClick();
                        }
                    }
                    break;

                case "MIN":
                    i = i + 60;
                    break;

                case "SEC":
                    i = i + 10;
                    break;

                case "ON":
                    if(ONFlg == false)
                    {
                        ONFlg = true;
                        return;
                    }
                    else
                    {
                        ONFlg = false;
                        return;
                    }
            }
        }
    }
}
