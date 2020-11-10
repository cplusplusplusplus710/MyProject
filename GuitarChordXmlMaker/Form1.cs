using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GuitarChordXmlMaker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //フィールド
        private CreateXML createConfigXML = new CreateXML();
        private System.Xml.Linq.XDocument XmlDoc;

        //------------------------------------------------------------------------------------------------
        //Xml内のデータを整理する(すっからかんのデータを消す)
        //------------------------------------------------------------------------------------------------
        public void SortXml()
        {
            XmlDoc = new XDocument();
            XmlDoc = XDocument.Load(createConfigXML.CurrentPath_database(), LoadOptions.PreserveWhitespace);

            var query = from y in XmlDoc.Descendants("Chord")
                        select y;
            int itemCount = 1;

            foreach (XElement item in query.ToList())
            {
                //すっからかんのデータは消す
                try
                {
                    if (item.Element("Root").Value == "" &&
                        item.Element("Degree").Value == "" &&
                        item.Element("Position1").Value == "" &&
                        item.Element("Position2").Value == "" &&
                        item.Element("Position3").Value == "" &&
                        item.Element("Position4").Value == "" &&
                        item.Element("BarreFlg").Value == "" &&
                        item.Element("Barre").Value == "" &&
                        item.Element("High").Value == "")
                    {
                        item.Remove();
                        XmlDoc.Save(createConfigXML.CurrentPath_database());
                    }

                }
                catch (Exception ex)
                {
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
            for (int i = 0; i < XmlDoc.Descendants("Chord").Count(); i++)
            {
                //ServiceNameをチェック
                try
                {

                    query = (from y in XmlDoc.Descendants("Chord")
                             where y.Attribute("ID").Value == Convert.ToString(i + 1)
                             select y).Single();

                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = query.Attribute("ID").Value;
                    dataGridView1.Rows[i].Cells[1].Value = query.Element("Root").Value;
                    dataGridView1.Rows[i].Cells[2].Value = query.Element("Degree").Value;
                    dataGridView1.Rows[i].Cells[3].Value = query.Element("Position1").Value;
                    dataGridView1.Rows[i].Cells[4].Value = query.Element("Position2").Value;
                    dataGridView1.Rows[i].Cells[5].Value = query.Element("Position3").Value;
                    dataGridView1.Rows[i].Cells[6].Value = query.Element("Position4").Value;
                    dataGridView1.Rows[i].Cells[7].Value = query.Element("BarreFlg").Value;
                    dataGridView1.Rows[i].Cells[8].Value = query.Element("Barre").Value;
                    dataGridView1.Rows[i].Cells[9].Value = query.Element("High").Value;


                }
                catch (Exception ex)
                {
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
                if (dataGridView1.Rows[j].Cells[1].Value == null &&
                    dataGridView1.Rows[j].Cells[2].Value == null &&
                    dataGridView1.Rows[j].Cells[3].Value == null &&
                    dataGridView1.Rows[j].Cells[4].Value == null &&
                    dataGridView1.Rows[j].Cells[5].Value == null &&
                    dataGridView1.Rows[j].Cells[6].Value == null &&
                    dataGridView1.Rows[j].Cells[7].Value == null &&
                    dataGridView1.Rows[j].Cells[8].Value == null &&
                    dataGridView1.Rows[j].Cells[9].Value == null)
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
                var query = from y in XmlDoc.Descendants("Chord")
                            select y;

                foreach (XElement item in query.ToList())
                {
                    item.Remove();
                    XmlDoc.Save(createConfigXML.CurrentPath_database());
                }
            }
            catch (Exception ex)
            {
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
            var Root = "";
            var Degree = "";
            var Position1 = "";
            var Position2 = "";
            var Position3 = "";
            var Position4 = "";
            var BarreFlg = "";
            var Barre = "";
            var High = "";

            XElement query;

            XmlDoc = new XDocument();
            XmlDoc = XDocument.Load(createConfigXML.CurrentPath_database(), LoadOptions.PreserveWhitespace);

            //Xmlファイルに書き込み
            for (int i = 0; i < RowCount; i++)
            {
                Root = Convert.ToString(dataGridView1.Rows[i].Cells[1].Value);
                Degree = Convert.ToString(dataGridView1.Rows[i].Cells[2].Value);
                Position1 = Convert.ToString(dataGridView1.Rows[i].Cells[3].Value);
                Position2 = Convert.ToString(dataGridView1.Rows[i].Cells[4].Value);
                Position3 = Convert.ToString(dataGridView1.Rows[i].Cells[5].Value);
                Position4 = Convert.ToString(dataGridView1.Rows[i].Cells[6].Value);
                BarreFlg = Convert.ToString(dataGridView1.Rows[i].Cells[7].Value);
                Barre = Convert.ToString(dataGridView1.Rows[i].Cells[8].Value);
                High = Convert.ToString(dataGridView1.Rows[i].Cells[9].Value);

                try
                {
                    var writeXml = new XElement("Data",
                    new XAttribute("ID", i + 1),
                    new XElement("Root", ""),
                    new XElement("Degree", ""),
                    new XElement("Position1", ""),
                    new XElement("Position2", ""),
                    new XElement("Position3", ""),
                    new XElement("Position4", ""),
                    new XElement("BarreFlg", ""),
                    new XElement("Barre", ""),
                    new XElement("High", ""));

                    XmlDoc.Elements().First().Add(writeXml);
                    XmlDoc.Save(createConfigXML.CurrentPath_database());

                    //データグリッドビューの値をXmlに書き込み
                    query = (from y in XmlDoc.Descendants("Chord")
                             where y.Attribute("ID").Value == Convert.ToString(i + 1)
                             select y).Single();

                    query.Element("Root").Value = Convert.ToString(dataGridView1.Rows[i].Cells[1].Value);
                    query.Element("Degree").Value = Convert.ToString(dataGridView1.Rows[i].Cells[2].Value);
                    query.Element("Position1").Value = Convert.ToString(dataGridView1.Rows[i].Cells[3].Value);
                    query.Element("Position2").Value = Convert.ToString(dataGridView1.Rows[i].Cells[4].Value);
                    query.Element("Position3").Value = Convert.ToString(dataGridView1.Rows[i].Cells[5].Value);
                    query.Element("Position4").Value = Convert.ToString(dataGridView1.Rows[i].Cells[6].Value);
                    query.Element("BarreFlg").Value = Convert.ToString(dataGridView1.Rows[i].Cells[7].Value);
                    query.Element("Barre").Value = Convert.ToString(dataGridView1.Rows[i].Cells[8].Value);
                    query.Element("High").Value = Convert.ToString(dataGridView1.Rows[i].Cells[9].Value);



                    XmlDoc.Save(createConfigXML.CurrentPath_database());

                }
                catch (Exception ex)
                {
                }
            }
        }

        //------------------------------------------------------------------------------------------------
        //新規登録フォームのデータをXmlに書き込む
        //------------------------------------------------------------------------------------------------
        public void NewDataAdd()
        {
            var Root = "";
            var Degree = "";
            var Position1 = "";
            var Position2 = "";
            var Position3 = "";
            var Position4 = "";
            var BarreFlg = "";
            var Barre = "";
            var High = "";

            XmlDoc = new XDocument();
            XmlDoc = XDocument.Load(createConfigXML.CurrentPath_database());

            //Xmlファイルに書き込み
            Root = textBox1_Root.Text;
            Degree = textBox1_degree.Text; ;
            Position1 = textBox_position1.Text;
            Position2 = textBox3_position2.Text;
            Position3 = textBox2_position3.Text;
            Position4 = textBox5_position4.Text;
            BarreFlg = textBox6_barreflg.Text;
            Barre = textBox7_barre.Text;
            High = textBox8_high.Text;

            try
            {

                var query = (from y in XmlDoc.Descendants("Chord")
                             select y);

                int Count = query.Elements("Chord").Count();

                var writeXml = new XElement("Chord",
                               new XAttribute("ID", Count + 1),
                               new XElement("Root", Root),
                               new XElement("Degree", Degree),
                               new XElement("Position1", Position1),
                               new XElement("Position2", Position2),
                               new XElement("Position3", Position3),
                               new XElement("Position4", Position4),
                               new XElement("BarreFlg", BarreFlg),
                               new XElement("Barre", Barre),
                               new XElement("High", High));

                XmlDoc.Elements().First().Add(writeXml);
                XmlDoc.Save(createConfigXML.CurrentPath_database());
            }
            catch (Exception ex)
            {
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

                    var query = (from y in XmlDoc.Descendants("Chord")
                                 where y.Attribute("ID").Value == Convert.ToString(idxRows + 1)
                                 select y).Single();

                    switch (c.ColumnIndex)
                    {
                        case 1:
                            query.Element("Root").Value = "";
                            XmlDoc.Save(createConfigXML.CurrentPath_database());
                            break;

                        case 2:
                            query.Element("Degree").Value = "";
                            XmlDoc.Save(createConfigXML.CurrentPath_database());
                            break;

                        case 3:
                            query.Element("Position1").Value = "";
                            XmlDoc.Save(createConfigXML.CurrentPath_database());
                            break;

                        case 4:
                            query.Element("Position2").Value = "";
                            XmlDoc.Save(createConfigXML.CurrentPath_database());
                            break;


                        case 5:
                            query.Element("Position3").Value = "";
                            XmlDoc.Save(createConfigXML.CurrentPath_database());
                            break;

                        case 6:
                            query.Element("Position4").Value = "";
                            XmlDoc.Save(createConfigXML.CurrentPath_database());
                            break;


                        case 7:
                            query.Element("BarreFlg").Value = "";
                            XmlDoc.Save(createConfigXML.CurrentPath_database());
                            break;

                        case 8:
                            query.Element("Barre").Value = "";
                            XmlDoc.Save(createConfigXML.CurrentPath_database());
                            break;

                        case 9:
                            query.Element("High").Value = "";
                            XmlDoc.Save(createConfigXML.CurrentPath_database());
                            break;

                    }
                }
                catch (Exception ex)
                {
                }
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            createConfigXML.CreatedatabaseXML();

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

            SortXml();
            InitDataSet();


        }

        private void button1_Add_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("データを新しく登録しますか？",
            "Infomation", MessageBoxButtons.YesNo,
            MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                NewDataAdd();
                dataGridView1.Rows.Clear();
                SortXml();
                InitDataSet();
                RowDelete();

                MessageBox.Show("新規登録が完了しました。",
                "Infomation", MessageBoxButtons.OK,
                MessageBoxIcon.Information);

                dataGridView1.ClearSelection();
            }

        }

        private void button1_Renew_Click(object sender, EventArgs e)
        {

            XmlAllDelete();
            WriteXml();
            dataGridView1.Rows.Clear();
            SortXml();
            InitDataSet();
            RowDelete();
            dataGridView1.ClearSelection();

        }

        private void button1_delete_Click(object sender, EventArgs e)
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
    }
}
