using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HosuChecker
{
    public partial class Form1 : Form
    {
        bool ErrorFlg = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            init();
        }

        /// <summary>
        /// 初期化
        /// </summary>
        private void init()
        {
            ErrorFlg = true;
            textBox1_value.Text = "";
            textBox3_shift_value.Text = "";
            comboBox1_shift_direction.Text = "";
            label3_before.Text = "";
            label3_aftershift.Text = "";
            label6_complement.Text = "";
            label9_complement_decimal.Text = "";
        }

        private void button1_start_Click(object sender, EventArgs e)
        {
            //入力値チェック
            ErrorFlg = Functions.InputNumberCheck(textBox1_value.Text);
            if (ErrorFlg == false)
                return;

            ErrorFlg = Functions.InputShiftNumberCheck(textBox3_shift_value.Text);
            if (ErrorFlg == false)
                return;

            ErrorFlg = Functions.InputShiftDirectionCheck(comboBox1_shift_direction.Text);
            if (ErrorFlg == false)
                return;

            if (textBox3_shift_value.Text != "" && comboBox1_shift_direction.Text == "")
            {
                System.Windows.Forms.MessageBox.Show("「シフト方向」を入力してください。",
                                     "エラー",
                                     System.Windows.Forms.MessageBoxButtons.OK,
                                     System.Windows.Forms.MessageBoxIcon.Exclamation);
                return;
            }

            if (textBox3_shift_value.Text == "" && comboBox1_shift_direction.Text != "")
            {
                System.Windows.Forms.MessageBox.Show("「シフト数」を入力してください。",
                     "エラー",
                     System.Windows.Forms.MessageBoxButtons.OK,
                     System.Windows.Forms.MessageBoxIcon.Exclamation);

                return;
            }

            if (textBox3_shift_value.Text == "0" && comboBox1_shift_direction.Text != "")
            {
                System.Windows.Forms.MessageBox.Show("「シフト数」に不正な値が入力されています。",
                     "エラー",
                     System.Windows.Forms.MessageBoxButtons.OK,
                     System.Windows.Forms.MessageBoxIcon.Exclamation);

                return;
            }

            //計算前の2進数
            var result = int.Parse(textBox1_value.Text);
            label3_before.Text = Convert.ToString(result,2);

            //シフト後の2進数
            switch(textBox3_shift_value.Text)
            {
                case "0":
                    break;
                case "":
                    break;
                default:
                    if(comboBox1_shift_direction.Text == "右")
                    {
                        result = result >> int.Parse(textBox3_shift_value.Text);
                        label3_aftershift.Text = Convert.ToString(result, 2);
                    }
                    else
                    {
                        result = result << int.Parse(textBox3_shift_value.Text);
                        label3_aftershift.Text = Convert.ToString(result, 2);
                    }
                    break;
            }

            //補数
            if(label3_aftershift.Text != "")
            {
                result = ~result;
                var str = Convert.ToString(result, 2);
                str = str.Substring(str.Length - label3_aftershift.Text.Length - 1);
                label6_complement.Text = str;
            }
            else
            {
                result = ~result;
                var str = Convert.ToString(result, 2);
                str = str.Substring(str.Length - label3_before.Text.Length -1);
                label6_complement.Text = str;
            }


            //補数の10進数
            label9_complement_decimal.Text = Convert.ToString(result, 10);
        }

        private void button2_clear_Click(object sender, EventArgs e)
        {
            init();
        }
    }
}
