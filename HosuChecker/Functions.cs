using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HosuChecker
{
    static class Functions
    {
        /// <summary>
        /// 入力する数字の値を精査
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool InputNumberCheck(string value)
        {
            bool InputNumberCheck_Judge;

            try
            {
                if (int.Parse(value) >= 0)
                {
                    InputNumberCheck_Judge = true;
                    return InputNumberCheck_Judge;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch(Exception)
            {
                System.Windows.Forms.MessageBox.Show("「数字」に不正な値が入力されています。",
                                                     "エラー",
                                                     System.Windows.Forms.MessageBoxButtons.OK,
                                                     System.Windows.Forms.MessageBoxIcon.Exclamation);
                InputNumberCheck_Judge = false;
                return InputNumberCheck_Judge;
            }
        }

        /// <summary>
        /// 入力するシフト数の値を精査
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool InputShiftNumberCheck(string value)
        {
            bool InputShiftNumberCheck_Judge;

            try
            {
                switch(value)
                {
                    case "0":
                        InputShiftNumberCheck_Judge = true;
                        return InputShiftNumberCheck_Judge;
                    case "":
                        InputShiftNumberCheck_Judge = true;
                        return InputShiftNumberCheck_Judge;
                    default:
                        break;
                }

                if (int.Parse(value) >= 0)
                {
                    InputShiftNumberCheck_Judge = true;
                    return InputShiftNumberCheck_Judge;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch(Exception)
            {
                System.Windows.Forms.MessageBox.Show("「シフト数」に不正な値が入力されています。",
                                                     "エラー",
                                                     System.Windows.Forms.MessageBoxButtons.OK,
                                                     System.Windows.Forms.MessageBoxIcon.Exclamation);
                InputShiftNumberCheck_Judge = false;
                return InputShiftNumberCheck_Judge;
            }
        }

        /// <summary>
        /// 入力するシフト方向の値を精査
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool InputShiftDirectionCheck(string value)
        {
            bool InputShiftDirectionCheck_Judge;

            try
            {
                switch(value)
                {
                    case "右":
                        InputShiftDirectionCheck_Judge = true;
                        break;
                    case "左":
                        InputShiftDirectionCheck_Judge = true;
                        break;
                    case "":
                        InputShiftDirectionCheck_Judge = true;
                        break;
                    default:
                        InputShiftDirectionCheck_Judge = false;
                        break;
                }

                return InputShiftDirectionCheck_Judge;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("「シフト方向」に不正な値が入力されています。",
                                                     "エラー",
                                                     System.Windows.Forms.MessageBoxButtons.OK,
                                                     System.Windows.Forms.MessageBoxIcon.Exclamation);
                InputShiftDirectionCheck_Judge = true;
                return InputShiftDirectionCheck_Judge;
            }
        }
    }
}
