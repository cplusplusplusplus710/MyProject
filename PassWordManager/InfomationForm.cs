using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PassWordManager
{
    public partial class InfomationForm : Form
    {
        public InfomationForm()
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------
        //フォームロード
        //------------------------------------------------------------------------------------------------
        private void InfomationForm_Load(object sender, EventArgs e)
        {
            //フォームサイズ変更不可
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //フォームが最大化されないようにする
            this.MaximizeBox = false;
            //フォームが最小化されないようにする
            this.MinimizeBox = false;
            //選択解除
            this.textBox1.SelectionStart = 0;

        }

    }
}
