using PassWordManager;
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
using System.Xml.Linq;

namespace ChordChecker
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        //フィールド
        private CreateXML createConfigXML = new CreateXML();
        private XDocument XmlDoc;
        private LogFunction LF;

        //------------------------------------------------------------------------------------------------
        //Xml内のデータを整理する(すっからかんのデータを消す)
        //------------------------------------------------------------------------------------------------
        public void SortXml()
        {
            XmlDoc = new XDocument();
            XmlDoc = XDocument.Load(createConfigXML.CurrentPath_database(), LoadOptions.PreserveWhitespace);

            var query = from y in XmlDoc.Descendants("Data")
                        select y;
            int itemCount = 1;

            foreach (XElement item in query.ToList())
            {
                //すっからかんのデータは消す
                try
                {
                    if (item.Element("SiteName").Value == "" &&
                       item.Element("URL").Value == "")
                    {
                        item.Remove();
                        XmlDoc.Save(createConfigXML.CurrentPath_database());
                    }

                }
                catch (Exception ex)
                {
                    LF = new LogFunction();
                    LF.PutLog("SortXml", ex.ToString(), "");
                }
            }

            //IDの値を並べなおし
            try
            {
                foreach (XElement item in query.ToList())
                {
                    item.Attribute("ID").Value = Convert.ToString(itemCount);
                    XmlDoc.Save(createConfigXML.CurrentPath_database());
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
            XmlDoc = XDocument.Load(createConfigXML.CurrentPath_database(), LoadOptions.PreserveWhitespace);


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
                    dataGridView1.Rows[i].Cells[0].Value = query.Element("SiteName").Value;
                    dataGridView1.Rows[i].Cells[1].Value = query.Element("URL").Value;

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
                    dataGridView1.Rows[j].Cells[1].Value == null)
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
            XmlDoc = XDocument.Load(createConfigXML.CurrentPath_database(), LoadOptions.PreserveWhitespace);

            //Xmlファイル内を検索
            //ぜんぶけす
            try
            {
                var query = from y in XmlDoc.Descendants("Data")
                            select y;

                foreach (XElement item in query.ToList())
                {
                    item.Remove();
                    XmlDoc.Save(createConfigXML.CurrentPath_database());
                }
            }
            catch (Exception ex)
            {
                LF = new LogFunction();
                LF.PutLog("XmlAllDelete", ex.ToString(), "");
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
            var SiteNameCheck = "";
            var URLCheck = "";
            XElement query;

            XmlDoc = new XDocument();
            XmlDoc = XDocument.Load(createConfigXML.CurrentPath_database(), LoadOptions.PreserveWhitespace);

            //Xmlファイルに書き込み
            for (int i = 0; i < RowCount; i++)
            {
                SiteNameCheck = Convert.ToString(dataGridView1.Rows[i].Cells[0].Value);
                URLCheck = Convert.ToString(dataGridView1.Rows[i].Cells[1].Value);

                try
                {
                    var writeXml = new XElement("Data",
                    new XAttribute("ID", i + 1),
                    new XElement("SiteName", SiteNameCheck),
                    new XElement("URL", ""));

                    XmlDoc.Elements().First().Add(writeXml);
                    XmlDoc.Save(createConfigXML.CurrentPath_database());

                    //データグリッドビューの値をXmlに書き込み
                    query = (from y in XmlDoc.Descendants("Data")
                             where y.Attribute("ID").Value == Convert.ToString(i + 1)
                             select y).Single();
                    query.Element("SiteName").Value = Convert.ToString(dataGridView1.Rows[i].Cells[0].Value);
                    query.Element("URL").Value = Convert.ToString(dataGridView1.Rows[i].Cells[1].Value);
                    XmlDoc.Save(createConfigXML.CurrentPath_database());

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
            var SiteName = "";
            var URL = "";

            XmlDoc = new XDocument();
            XmlDoc = XDocument.Load(createConfigXML.CurrentPath_database());

            //Xmlファイルに書き込み
            SiteName = textBox1.Text;
            URL = textBox2.Text;

            try
            {

                var query = (from y in XmlDoc.Descendants("Data")
                             select y);

                int Count = query.Elements("Data").Count();

                var writeXml = new XElement("Data",
                               new XAttribute("ID", Count + 1),
                               new XElement("SiteName", SiteName),
                               new XElement("URL", URL));

                XmlDoc.Elements().First().Add(writeXml);
                XmlDoc.Save(createConfigXML.CurrentPath_database());
            }
            catch (Exception ex)
            {
                LF = new LogFunction();
                LF.PutLog("NewDataAdd", ex.ToString(), "");
            }
        }

        //------------------------------------------------------------------------------------------------
        //選択されているデータをXmlから消去する。
        //------------------------------------------------------------------------------------------------
        public void ChoiceDelete()
        {
            XmlDoc = new XDocument();
            XmlDoc = XDocument.Load(createConfigXML.CurrentPath_database(), LoadOptions.PreserveWhitespace);

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
                            query.Element("SiteName").Value = "";
                            XmlDoc.Save(createConfigXML.CurrentPath_database());
                            break;

                        case 1:
                            query.Element("URL").Value = "";
                            XmlDoc.Save(createConfigXML.CurrentPath_database());
                            break;
                    }
                }
                catch (Exception ex)
                {
                    LF = new LogFunction();
                    LF.PutLog("ChoiceDelete", ex.ToString(), "");
                }
            }
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

        //☆★☆★☆★☆★☆★☆★☆★☆★                    ☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★ 
        //☆★☆★☆★☆★☆★☆★☆★☆★以下イベントハンドラ☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★ 
        //☆★☆★☆★☆★☆★☆★☆★☆★                    ☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★ 

        //------------------------------------------------------------------------------------------------
        //ギターコードボタン
        //------------------------------------------------------------------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            ChordSettingForm settingform = new ChordSettingForm();
            
            settingform.Show();
        }

        //------------------------------------------------------------------------------------------------
        //フォームロード
        //------------------------------------------------------------------------------------------------
        private void MainForm_Load(object sender, EventArgs e)
        {
            createConfigXML.CreatedatabaseXML();
            SortXml();
            InitDataSet();

            //フォームサイズ変更不可
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //DataGridView1のセルを読み取り専用にする
            dataGridView1.ReadOnly = true;
            //DataGridView1の列の幅をユーザーが変更できないようにする
            dataGridView1.AllowUserToResizeColumns = false;
            //フォームが最大化されないようにする
            this.MaximizeBox = false;
            //フォームが最小化されないようにする
            this.MinimizeBox = false;
            //データグリッドビューのデータ並び替えができないようにする
            foreach (DataGridViewColumn c in dataGridView1.Columns)
            {
                c.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

        }

        //------------------------------------------------------------------------------------------------
        //選択を消去ボタン
        //------------------------------------------------------------------------------------------------
        private void button2_Delete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("選択した箇所を削除しますか？",
            "Infomation", MessageBoxButtons.YesNo,
            MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                ChoiceDelete();
                dataGridView1.Rows.Clear();
                SortXml();
                InitDataSet();
                RowDelete();
                dataGridView1.ClearSelection();
            }

        }

        //------------------------------------------------------------------------------------------------
        //新規登録ボタン
        //------------------------------------------------------------------------------------------------
        private void button2_Add_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("データを新しく登録しますか？",
            "Infomation", MessageBoxButtons.YesNo,
            MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                if (textBox1.Text == "") //何もはいってないとき
                {
                    MessageBox.Show("Nameの入力は必須です。",
                    "Infomation", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                }
                else
                {
                    NewDataAdd();
                    dataGridView1.Rows.Clear();
                    SortXml();
                    InitDataSet();
                    RowDelete();

                    MessageBox.Show("新規登録が完了しました。",
                    "Infomation", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                    textBox1.Text = "";
                    textBox2.Text = "";
                    dataGridView1.ClearSelection();
                }
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
            XmlDoc = XDocument.Load(createConfigXML.CurrentPath_database(), LoadOptions.PreserveWhitespace);
            foreach (DataGridViewCell c in dataGridView1.SelectedCells)
            {
                idxRows = c.RowIndex;
                idxColumn = c.ColumnIndex;
                string CopyWord = "";

                if(c.ColumnIndex == 1)
                {
                    try
                    {
                        CopyWord = (string)dataGridView1.CurrentRow.Cells[1].Value;
                        System.Diagnostics.Process.Start(CopyWord);
                        return;
                    }
                    catch
                    {
                        MessageBox.Show("URLが正しくありません。",
                        "Infomation", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                try
                {
                    var query = (from y in XmlDoc.Descendants("Data")
                                 where y.Attribute("ID").Value == Convert.ToString(idxRows + 1)
                                 select y).Single();

                    switch (c.ColumnIndex)
                    {
                        case 0:
                            CopyWord = query.Element("SiteName").Value;
                            break;

                        case 1:
                            CopyWord = query.Element("URL").Value;
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
    }
}
