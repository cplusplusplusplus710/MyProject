using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Threading;
using System.ComponentModel;
using System.Drawing;

namespace PassWordManager
{
    public partial class MainForm : Form
    {
        //フィールド
        private CreateXML createConfigXML = new CreateXML();
        private LogFunction LF;
        private XDocument XmlDoc;
        private bool MaskFlg = false;
        private bool DataSetFlg = false;
        private bool ConpactFlg = false;
        //マウスのクリック位置を記憶
        private Point mousePoint;

        public MainForm()
        {
            InitializeComponent();
            //Config.xmlを作成、既にあれば処理をしない
            createConfigXML.CreateConfigXML();

            //XMLファイルの復号
            AESCryption aes = new AESCryption();
            aes.DecAES();
            SortXml();
            InitDataSet();
        }
        //------------------------------------------------------------------------------------------------
        //Xml内のデータを整理する(すっからかんのデータを消す)
        //------------------------------------------------------------------------------------------------
        public void SortXml()
        {
            XmlDoc = new XDocument();
            XmlDoc = XDocument.Load(createConfigXML.CurrentPath(), LoadOptions.PreserveWhitespace);

            var query = from y in XmlDoc.Descendants("Data")
                        select y;
            int itemCount = 1;

            foreach (XElement item in query.ToList())
            {
                //すっからかんのデータは消す
                try
                {
                    if (item.Element("ServiceName").Value == "" &&
                       item.Element("ID").Value == "" &&
                       item.Element("PassWord").Value == "")
                    {
                        item.Remove();
                        XmlDoc.Save(createConfigXML.CurrentPath());
                    }

                }
                catch (Exception ex)
                {
                    LF = new LogFunction();
                    LF.PutLog("DataCheck", ex.ToString(), "");
                }
            }

            //IDの値を並べなおし
            try
            {
                foreach (XElement item in query.ToList())
                {
                    item.Attribute("ID").Value = Convert.ToString(itemCount);
                    XmlDoc.Save(createConfigXML.CurrentPath());
                    itemCount++;
                }
            }
            catch (Exception ex)
            {
                LF = new LogFunction();
                LF.PutLog("SortXml", ex.ToString(), "");
            }
        }

        //------------------------------------------------------------------------------------------------
        //DataGridviewにXmlデータを反映する(起動時)
        //------------------------------------------------------------------------------------------------
        public void InitDataSet()
        {
            XElement query;
            XmlDoc = new XDocument();
            XmlDoc = XDocument.Load(createConfigXML.CurrentPath(), LoadOptions.PreserveWhitespace);


            //Xmlファイル内を検索
            for (int i = 0; i < XmlDoc.Descendants("Data").Count(); i++)
            {
                //ServiceNameをチェック
                try
                {
                    query = (from y in XmlDoc.Descendants("Data")
                             where y.Attribute("ID").Value == Convert.ToString(i + 1)
                             select y).Single();

                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = query.Element("ServiceName").Value;
                    dataGridView1.Rows[i].Cells[1].Value = query.Element("ID").Value;
                    dataGridView1.Rows[i].Cells[2].Value = query.Element("PassWord").Value;


                }
                catch (Exception ex)
                {
                    LF = new LogFunction();
                    LF.PutLog("InitDataSet", ex.ToString(), "");
                }
            }
        }

        //------------------------------------------------------------------------------------------------
        //データグリッドビューの無駄な行を削除する
        //------------------------------------------------------------------------------------------------
        public void RowDelete()
        {
            int CountVal = dataGridView1.Rows.Count - 1;

            for (int j = 0; j < CountVal; j++)
            {
                if (dataGridView1.Rows[j].Cells[0].Value == null &&
                    dataGridView1.Rows[j].Cells[1].Value == null &&
                    dataGridView1.Rows[j].Cells[2].Value == null)
                {
                    dataGridView1.Rows.RemoveAt(j);
                    CountVal = CountVal - 1;
                }
            }
        }

        //------------------------------------------------------------------------------------------------
        //Xmlデータを初期化する
        //------------------------------------------------------------------------------------------------
        public void XmlAllDelete()
        {
            XmlDoc = new XDocument();
            XmlDoc = XDocument.Load(createConfigXML.CurrentPath(), LoadOptions.PreserveWhitespace);

            //Xmlファイル内を検索
            //ぜんぶけす
            try
            {
                var query = from y in XmlDoc.Descendants("Data")
                            select y;

                foreach (XElement item in query.ToList())
                {
                    item.Remove();
                    XmlDoc.Save(createConfigXML.CurrentPath());
                }
            }
            catch (Exception ex)
            {
                LF = new LogFunction();
                LF.PutLog("DataCheck", ex.ToString(), "");
            }

            MessageBox.Show("更新が完了しました。",
                            "Infomation", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

        }

        //------------------------------------------------------------------------------------------------
        //DataGridviewのデータをXmlに書き込む
        //------------------------------------------------------------------------------------------------
        public void WriteXml()
        {
            int RowCount = dataGridView1.RowCount;
            var ServiceNameCheck = "";
            var IDCheck = "";
            var PassWordCheck = "";
            XElement query;

            XmlDoc = new XDocument();
            XmlDoc = XDocument.Load(createConfigXML.CurrentPath(), LoadOptions.PreserveWhitespace);

            //Xmlファイルに書き込み
            for (int i = 0; i < RowCount; i++)
            {
                ServiceNameCheck = Convert.ToString(dataGridView1.Rows[i].Cells[0].Value);
                IDCheck = Convert.ToString(dataGridView1.Rows[i].Cells[1].Value);
                PassWordCheck = Convert.ToString(dataGridView1.Rows[i].Cells[2].Value);

                try
                {
                    var writeXml = new XElement("Data",
                    new XAttribute("ID", i + 1),
                    new XElement("ServiceName", ServiceNameCheck),
                    new XElement("ID", ""),
                    new XElement("PassWord", ""));

                    XmlDoc.Elements().First().Add(writeXml);
                    XmlDoc.Save(createConfigXML.CurrentPath());

                    //データグリッドビューの値をXmlに書き込み
                    query = (from y in XmlDoc.Descendants("Data")
                             where y.Attribute("ID").Value == Convert.ToString(i + 1)
                             select y).Single();
                    query.Element("ServiceName").Value = Convert.ToString(dataGridView1.Rows[i].Cells[0].Value);
                    query.Element("ID").Value = Convert.ToString(dataGridView1.Rows[i].Cells[1].Value);
                    query.Element("PassWord").Value = Convert.ToString(dataGridView1.Rows[i].Cells[2].Value);
                    XmlDoc.Save(createConfigXML.CurrentPath());

                }
                catch (Exception ex)
                {
                    LF = new LogFunction();
                    LF.PutLog("WriteXml", ex.ToString(), "");
                }
            }
        }

        //------------------------------------------------------------------------------------------------
        //新規登録フォームのデータをXmlに書き込む
        //------------------------------------------------------------------------------------------------
        public void NewDataAdd()
        {
            var ServiceNameTextBox = "";
            var IDTextBox = "";
            var PassWordTextBox = "";

            XmlDoc = new XDocument();
            XmlDoc = XDocument.Load(createConfigXML.CurrentPath());

            //Xmlファイルに書き込み
            ServiceNameTextBox = textBox1_ServiceName.Text;
            IDTextBox = textBox2_ID.Text;
            PassWordTextBox = textBox3_PassWord.Text;

            try
            {

                var query = (from y in XmlDoc.Descendants("Data")
                             select y);

                int Count = query.Elements("Data").Count();

                var writeXml = new XElement("Data",
                new XAttribute("ID", Count + 1),
                new XElement("ServiceName", ServiceNameTextBox),
                new XElement("ID", IDTextBox),
                new XElement("PassWord", PassWordTextBox));

                XmlDoc.Elements().First().Add(writeXml);
                XmlDoc.Save(createConfigXML.CurrentPath());
            }
            catch (Exception ex)
            {
                LF = new LogFunction();
                LF.PutLog("WriteXml", ex.ToString(), "");
            }
        }

        //------------------------------------------------------------------------------------------------
        //選択されているデータをXmlから消去する。
        //------------------------------------------------------------------------------------------------
        public void ChoiceDelete()
        {
            XmlDoc = new XDocument();
            XmlDoc = XDocument.Load(createConfigXML.CurrentPath(), LoadOptions.PreserveWhitespace);

            int idxRows;

            foreach (DataGridViewCell c in dataGridView1.SelectedCells)
            {
                try
                {
                    idxRows = c.RowIndex;

                    var query = (from y in XmlDoc.Descendants("Data")
                                 where y.Attribute("ID").Value == Convert.ToString(idxRows + 1)
                                 select y).Single();

                    switch (c.ColumnIndex)
                    {
                        case 0:
                            query.Element("ServiceName").Value = "";
                            XmlDoc.Save(createConfigXML.CurrentPath());
                            break;

                        case 1:
                            query.Element("ID").Value = "";
                            XmlDoc.Save(createConfigXML.CurrentPath());
                            break;

                        case 2:
                            query.Element("PassWord").Value = "";
                            XmlDoc.Save(createConfigXML.CurrentPath());
                            break;
                    }
                }
                catch (Exception ex)
                {
                    LF = new LogFunction();
                    LF.PutLog("WriteXml", ex.ToString(), "");
                }
            }
        }

        //------------------------------------------------------------------------------------------------
        //データグリッドビューのマスク
        //------------------------------------------------------------------------------------------------
        public void DataMask()
        {
            if(DataSetFlg == true && MaskFlg == true)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Cells[1].Value = "******";
                    dataGridView1.Rows[i].Cells[2].Value = "******";
                }
                DataSetFlg = false;
                return;
            }
            else if(DataSetFlg == true && MaskFlg == false)
            {
                DataSetFlg = false;
                return;
            }
            else
            {
                //なにもしない
            }

            if (MaskFlg == false)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Cells[1].Value = "******";
                    dataGridView1.Rows[i].Cells[2].Value = "******";
                }
                MaskFlg = true;
                return;
            }

            if (MaskFlg == true)
            {
                dataGridView1.Rows.Clear();
                SortXml();
                InitDataSet();
                RowDelete();
                MaskFlg = false;
                return;
            }

            DataSetFlg = false;

        }

        //------------------------------------------------------------------------------------------------
        //英数字チェック(一文字ずつ入れてね)　半角英数字以外は削除
        //------------------------------------------------------------------------------------------------
        public static string IsAlphanumeric(string target)
        {
            bool RG = new Regex("^[0-9a-zA-Z]+$").IsMatch(target);

            if (RG == true)
            {
                return target;
            }
            else
            {
                target = "";
                return target;
            }
        }

        //------------------------------------------------------------------------------------------------
        //プログラム終了時の処理
        //------------------------------------------------------------------------------------------------
        private void AppExit(object sender, EventArgs e)
        {
            MessageBox.Show("プログラムの終了処理を実行します。");
            AESCryption aes = new AESCryption();
            aes.SetAES();
            Dispose();
        }

        //------------------------------------------------------------------------------------------------
        //クリップボードへコピーした際、お知らせフォームを表示する
        //------------------------------------------------------------------------------------------------
        public void CopyInformation()
        {
            InfomationForm informationform = new InfomationForm();
            informationform.FormBorderStyle = FormBorderStyle.None;
            informationform.ControlBox = false;
            informationform.Text = "";
            informationform.Show();
            System.Threading.Thread.Sleep(500);            
        }

        //------------------------------------------------------------------------------------------------
        //----------------------------以下イベントハンドラ------------------------------------------------
        //------------------------------------------------------------------------------------------------

        //------------------------------------------------------------------------------------------------
        //更新ボタン
        //------------------------------------------------------------------------------------------------
        private void 更新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool MaskReleaseFlg = false;
            if (MaskFlg == true)
            {
                DataMask();
                MaskReleaseFlg = true;
            }

            DataSetFlg = true;
            XmlAllDelete();
            WriteXml();
            dataGridView1.Rows.Clear();
            SortXml();
            InitDataSet();
            RowDelete();

            if (MaskReleaseFlg == true)
            {
                MaskFlg = true;
                DataMask();
            }

            MaskReleaseFlg = false;
            dataGridView1.ClearSelection();
        }

        //------------------------------------------------------------------------------------------------
        //フォームロード
        //------------------------------------------------------------------------------------------------
        private void MainForm_Load(object sender, EventArgs e)
        {
            //フォームサイズ変更不可
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //DataGridView1のセルを読み取り専用にする
            dataGridView1.ReadOnly = true;
            //DataGridView1の列の幅をユーザーが変更できないようにする
            dataGridView1.AllowUserToResizeColumns = false;
            //TextBoxに入力された文字がすべて*で表示されるようにする
            textBox3_PassWord.PasswordChar = '*';
            //フォームが最大化されないようにする
            this.MaximizeBox = false;
            //フォームが最小化されないようにする
            this.MinimizeBox = false;
            //テキストボックスの入力制限
            textBox2_ID.ImeMode = ImeMode.Disable;
            textBox3_PassWord.ImeMode = ImeMode.Disable;
            //データグリッドビューのデータ並び替えができないようにする
            foreach (DataGridViewColumn c in dataGridView1.Columns)
            {
                c.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            //アプリケーションの終了を検知するイベントハンドラを生成
            Application.ApplicationExit += new EventHandler(AppExit);
        }

        //------------------------------------------------------------------------------------------------
        //目玉ボタン押しっぱなし
        //------------------------------------------------------------------------------------------------
        private void pictureBox1_PasswordEye_MouseDown(object sender, MouseEventArgs e)
        {
            //パスワードマスク解除
            textBox3_PassWord.PasswordChar = (char)0;
        }

        //------------------------------------------------------------------------------------------------
        //目玉ボタンクリック放す
        //------------------------------------------------------------------------------------------------
        private void pictureBox1_PassWordEye_MouseUp(object sender, MouseEventArgs e)
        {
            //再マスク
            textBox3_PassWord.PasswordChar = '*';
        }

        //------------------------------------------------------------------------------------------------
        //メニューストリップ選択を消去ボタン
        //------------------------------------------------------------------------------------------------
        private void 選択を消去DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("選択した箇所を削除しますか？",
                "Infomation", MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                DataSetFlg = true;
                ChoiceDelete();
                dataGridView1.Rows.Clear();
                SortXml();
                InitDataSet();
                RowDelete();
                DataMask();
                dataGridView1.ClearSelection();
            }
        }

        //------------------------------------------------------------------------------------------------
        //新規登録ボタン
        //------------------------------------------------------------------------------------------------
        private void button1_DataAdd_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("データを新しく登録しますか？",
               "Infomation", MessageBoxButtons.YesNo,
               MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                if (textBox1_ServiceName.Text == "") //何もはいってないとき
                {
                    MessageBox.Show("サービス名の入力は必須です。",
                    "Infomation", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
                else
                {
                    DataSetFlg = true;
                    NewDataAdd();
                    dataGridView1.Rows.Clear();
                    SortXml();
                    InitDataSet();
                    RowDelete();
                    DataMask();

                    MessageBox.Show("新規登録が完了しました。",
                    "Infomation", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                    textBox1_ServiceName.Text = "";
                    textBox2_ID.Text = "";
                    textBox3_PassWord.Text = "";
                    dataGridView1.ClearSelection();
                }
            }
        }

        //------------------------------------------------------------------------------------------------
        //IDのテキストボックスの文字入力制限
        //------------------------------------------------------------------------------------------------
        private void textBox2_ID_TextChanged(object sender, EventArgs e)
        {
            string moji = this.textBox2_ID.Text;

            //文字の列挙オブジェクト
            TextElementEnumerator charEnum = StringInfo.GetTextElementEnumerator(moji);

            //解析済の文字を入れるオブジェクト
            StringBuilder AnalyzedMoji = new StringBuilder();

            while (true)
            {
                // 取得する文字がない
                if (charEnum.MoveNext() == false)
                {
                    break;
                }

                //一文字ずつ正規表現で処理
                //半角英数字でなければ削除される
                AnalyzedMoji.Append(IsAlphanumeric(Convert.ToString(charEnum.Current)));
            }

            textBox2_ID.Text = AnalyzedMoji.ToString();

        }

        //------------------------------------------------------------------------------------------------
        //PassWordのテキストボックスの文字入力制限
        //------------------------------------------------------------------------------------------------
        private void textBox3_PassWord_TextChanged(object sender, EventArgs e)
        {
            string moji = this.textBox3_PassWord.Text;

            //文字の列挙オブジェクト
            TextElementEnumerator charEnum = StringInfo.GetTextElementEnumerator(moji);

            //解析済の文字を入れるオブジェクト
            StringBuilder AnalyzedMoji = new StringBuilder();

            while (true)
            {
                // 取得する文字がない
                if (charEnum.MoveNext() == false)
                {
                    break;
                }

                //一文字ずつ正規表現で処理
                //半角英数字でなければ削除される
                AnalyzedMoji.Append(IsAlphanumeric(Convert.ToString(charEnum.Current)));

            }

            textBox3_PassWord.Text = AnalyzedMoji.ToString();

        }

        //------------------------------------------------------------------------------------------------
        //インポートのファイル選択ボタン
        //------------------------------------------------------------------------------------------------
        private void button2_Click(object sender, EventArgs e)
        {
            //OpenFileDialogクラスのインスタンスを作成
            OpenFileDialog ofd = new OpenFileDialog();

            //はじめのファイル名を指定する
            //はじめに「ファイル名」で表示される文字列を指定する
            ofd.FileName = "";
            //はじめに表示されるフォルダを指定する
            //指定しない（空の文字列）の時は、現在のディレクトリが表示される
            ofd.InitialDirectory = "";
            //[ファイルの種類]に表示される選択肢を指定する
            //指定しないとすべてのファイルが表示される
            ofd.Filter = "CSVファイル(*.csv;)|*.csv;";
            //[ファイルの種類]ではじめに選択されるものを指定する
            //2番目の「すべてのファイル」が選択されているようにする
            ofd.FilterIndex = 2;
            //タイトルを設定する
            ofd.Title = "csvファイルを選択";
            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            ofd.RestoreDirectory = true;
            //存在しないファイルの名前が指定されたとき警告を表示する
            //デフォルトでTrueなので指定する必要はない
            ofd.CheckFileExists = true;
            //存在しないパスが指定されたとき警告を表示する
            //デフォルトでTrueなので指定する必要はない
            ofd.CheckPathExists = true;

            //ダイアログを表示する
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //OKボタンがクリックされたとき、選択されたファイル名を表示する
                textBox1_Import.Text = ofd.FileName;
            }
        }

        //------------------------------------------------------------------------------------------------
        //エクスポートのフォルダ選択ボタン
        //------------------------------------------------------------------------------------------------
        private void button3_Click(object sender, EventArgs e)
        {
            var dlg = new FolderSelectDialog();
            dlg.Path = textBox2_Export.Text;
            if (dlg.ShowDialog() == DialogResult.OK)
                textBox2_Export.Text = dlg.Path;
        }

        //------------------------------------------------------------------------------------------------
        //インポートボタン
        //------------------------------------------------------------------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("csvファイルのインポートを実行しますか？" +
                                                  "\r\nインポートされたデータは現在のデータに追加されます。",
            "Infomation", MessageBoxButtons.YesNo,
            MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                DataSetFlg = true;
                ImportCSV ICSV = new ImportCSV();
                ICSV.ImportCSVGetBin(textBox1_Import.Text);
                dataGridView1.Rows.Clear();
                SortXml();
                InitDataSet();
                RowDelete();
                DataMask();
            }
        }

        //------------------------------------------------------------------------------------------------
        //マスクボタン
        //------------------------------------------------------------------------------------------------
        private void マスクMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataMask();
        }

        //------------------------------------------------------------------------------------------------
        //エクスポートボタン
        //------------------------------------------------------------------------------------------------
        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("csvファイルのエクスポートを実行しますか？" ,
            "Infomation", MessageBoxButtons.YesNo,
            MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                ExportCSV exportCsv = new ExportCSV();
                exportCsv.CreateCSVFile(textBox2_Export.Text);              
            }
        }

        //------------------------------------------------------------------------------------------------
        //セルがクリックされた時
        //------------------------------------------------------------------------------------------------
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //選択されたセルをクリップボードにコピーする
            int idxRows;
            int idxColumn;
            XmlDoc = new XDocument();
            XmlDoc = XDocument.Load(createConfigXML.CurrentPath(), LoadOptions.PreserveWhitespace);
            foreach (DataGridViewCell c in dataGridView1.SelectedCells)
            {
                idxRows = c.RowIndex;
                idxColumn = c.ColumnIndex;
                string CopyWord = "";

                try
                {
                    var query = (from y in XmlDoc.Descendants("Data")
                                 where y.Attribute("ID").Value == Convert.ToString(idxRows + 1)
                                 select y).Single();

                    switch (c.ColumnIndex)
                    {
                        case 0:
                            CopyWord = query.Element("ServiceName").Value;
                            break;

                        case 1:
                            CopyWord = query.Element("ID").Value;
                            break;

                        case 2:
                            CopyWord = query.Element("PassWord").Value;
                            break;
                    }

                    Clipboard.SetText(CopyWord);
                    Thread thread = new Thread(new ThreadStart(CopyInformation));
                    thread.Start();
                    thread.Join();

                }
                catch (Exception ex)
                {
                    LF = new LogFunction();
                    LF.PutLog("dataGridView1_CellClick", ex.ToString(), "");
                }

            }

        }

        //------------------------------------------------------------------------------------------------
        //メニューストリップ昇順ボタン
        //------------------------------------------------------------------------------------------------
        private void 昇順AToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //昇順で並び替えを行う
            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
        }

        //------------------------------------------------------------------------------------------------
        //メニューストリップ降順ボタン
        //------------------------------------------------------------------------------------------------
        private void 降順DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //降順で並び替えを行う
            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Descending);

        }

        //------------------------------------------------------------------------------------------------
        //メニューストリップコンパクトモードボタン
        //------------------------------------------------------------------------------------------------
        private void コンパクトモードCToolStripMenuItem_Click(object sender, EventArgs e)
        {           
            if(ConpactFlg == false)
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.dataGridView1.Size = new System.Drawing.Size(780, 60);
                this.Size = new System.Drawing.Size(817, 84);
                ConpactFlg = true;
                return;
            }
            if(ConpactFlg == true)
            {
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                this.dataGridView1.Size = new System.Drawing.Size(780, 220);
                this.Size = new System.Drawing.Size(817, 466);
                ConpactFlg = false;
                return;
            }

        }

        //------------------------------------------------------------------------------------------------
        //フォームマウスダウン
        //------------------------------------------------------------------------------------------------
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                //位置を記憶する
                mousePoint = new Point(e.X, e.Y);
            }
        }

        //------------------------------------------------------------------------------------------------
        //フォームマウスムーブ
        //------------------------------------------------------------------------------------------------
        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                this.Left += e.X - mousePoint.X;
                this.Top += e.Y - mousePoint.Y;
            }
        }

        //------------------------------------------------------------------------------------------------
        //メニューストリップマウスムーブ
        //------------------------------------------------------------------------------------------------
        private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                //位置を記憶する
                mousePoint = new Point(e.X, e.Y);
            }

        }
        //------------------------------------------------------------------------------------------------
        //メニューストリップマウスムーブ
        //------------------------------------------------------------------------------------------------
        private void menuStrip1_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                this.Left += e.X - mousePoint.X;
                this.Top += e.Y - mousePoint.Y;
            }

        }
    }
}

