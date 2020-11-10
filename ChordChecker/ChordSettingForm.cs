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

namespace ChordChecker
{
    public partial class ChordSettingForm : Form
    {
        public ChordSettingForm()
        {
            InitializeComponent();
        }

        //フィールド
        private CreateXML createConfigXML = new CreateXML();
        private XDocument XmlDoc;
        private Point mousePoint;

        private string PositionValue1;
        private string PositionValue2;
        private string PositionValue3;
        private string PositionValue4;
        private string BarreFlg;
        private string Barre;
        private int High;

        //------------------------------------------------------------------------------------------------
        //ボタンの色初期化
        //------------------------------------------------------------------------------------------------
        private void InitButtonColor()
        {
            button_00.BackColor = SystemColors.Control;
            button_01.BackColor = SystemColors.Control;
            button_02.BackColor = SystemColors.Control;
            button_03.BackColor = SystemColors.Control;
            button_04.BackColor = SystemColors.Control;
            button_05.BackColor = SystemColors.Control;

            button_10.BackColor = SystemColors.Control;
            button_11.BackColor = SystemColors.Control;
            button_12.BackColor = SystemColors.Control;
            button_13.BackColor = SystemColors.Control;
            button_14.BackColor = SystemColors.Control;
            button_15.BackColor = SystemColors.Control;

            button_20.BackColor = SystemColors.Control;
            button_21.BackColor = SystemColors.Control;
            button_22.BackColor = SystemColors.Control;
            button_23.BackColor = SystemColors.Control;
            button_24.BackColor = SystemColors.Control;
            button_25.BackColor = SystemColors.Control;

            button_30.BackColor = SystemColors.Control;
            button_31.BackColor = SystemColors.Control;
            button_32.BackColor = SystemColors.Control;
            button_33.BackColor = SystemColors.Control;
            button_34.BackColor = SystemColors.Control;
            button_35.BackColor = SystemColors.Control;

            button_40.BackColor = SystemColors.Control;
            button_41.BackColor = SystemColors.Control;
            button_42.BackColor = SystemColors.Control;
            button_43.BackColor = SystemColors.Control;
            button_44.BackColor = SystemColors.Control;
            button_45.BackColor = SystemColors.Control;

            button_50.BackColor = SystemColors.Control;
            button_51.BackColor = SystemColors.Control;
            button_52.BackColor = SystemColors.Control;
            button_53.BackColor = SystemColors.Control;
            button_54.BackColor = SystemColors.Control;
            button_55.BackColor = SystemColors.Control;

        }

        //------------------------------------------------------------------------------------------------
        //ポジションナンバーを取得してボタンの色を変える(引数3個)
        //------------------------------------------------------------------------------------------------
        private void ChangeButtonColor(string Position1,string Position2,string Position3)
        {
            string ButtonName1 = "button_" + Position1;
            string ButtonName2 = "button_" + Position2;
            string ButtonName3 = "button_" + Position3;

            //第一引数
            switch (ButtonName1)
            {
                case "button_00":
                    button_00.BackColor = Color.Black;
                    break;

                case "button_01":
                    button_01.BackColor = Color.Black;
                    break;

                case "button_02":
                    button_02.BackColor = Color.Black;
                    break;

                case "button_03":
                    button_03.BackColor = Color.Black;
                    break;

                case "button_04":
                    button_04.BackColor = Color.Black;
                    break;

                case "button_05":
                    button_05.BackColor = Color.Black;
                    break;

                case "button_10":
                    button_10.BackColor = Color.Black;
                    break;

                case "button_11":
                    button_11.BackColor = Color.Black;
                    break;

                case "button_12":
                    button_12.BackColor = Color.Black;
                    break;

                case "button_13":
                    button_13.BackColor = Color.Black;
                    break;

                case "button_14":
                    button_14.BackColor = Color.Black;
                    break;

                case "button_15":
                    button_15.BackColor = Color.Black;
                    break;

                case "button_20":
                    button_20.BackColor = Color.Black;
                    break;

                case "button_21":
                    button_21.BackColor = Color.Black;
                    break;

                case "button_22":
                    button_22.BackColor = Color.Black;
                    break;

                case "button_23":
                    button_23.BackColor = Color.Black;
                    break;

                case "button_24":
                    button_24.BackColor = Color.Black;
                    break;

                case "button_25":
                    button_25.BackColor = Color.Black;
                    break;

                case "button_30":
                    button_30.BackColor = Color.Black;
                    break;

                case "button_31":
                    button_31.BackColor = Color.Black;
                    break;

                case "button_32":
                    button_32.BackColor = Color.Black;
                    break;

                case "button_33":
                    button_33.BackColor = Color.Black;
                    break;

                case "button_34":
                    button_34.BackColor = Color.Black;
                    break;

                case "button_35":
                    button_35.BackColor = Color.Black;
                    break;

                case "button_40":
                    button_40.BackColor = Color.Black;
                    break;

                case "button_41":
                    button_41.BackColor = Color.Black;
                    break;

                case "button_42":
                    button_42.BackColor = Color.Black;
                    break;

                case "button_43":
                    button_43.BackColor = Color.Black;
                    break;

                case "button_44":
                    button_44.BackColor = Color.Black;
                    break;

                case "button_45":
                    button_45.BackColor = Color.Black;
                    break;

                case "button_50":
                    button_50.BackColor = Color.Black;
                    break;

                case "button_51":
                    button_51.BackColor = Color.Black;
                    break;

                case "button_52":
                    button_52.BackColor = Color.Black;
                    break;

                case "button_53":
                    button_53.BackColor = Color.Black;
                    break;

                case "button_54":
                    button_54.BackColor = Color.Black;
                    break;

                case "button_55":
                    button_55.BackColor = Color.Black;
                    break;

            }

            //第二引数
            switch (ButtonName2)
            {
                case "button_00":
                    button_00.BackColor = Color.Black;
                    break;

                case "button_01":
                    button_01.BackColor = Color.Black;
                    break;

                case "button_02":
                    button_02.BackColor = Color.Black;
                    break;

                case "button_03":
                    button_03.BackColor = Color.Black;
                    break;

                case "button_04":
                    button_04.BackColor = Color.Black;
                    break;

                case "button_05":
                    button_05.BackColor = Color.Black;
                    break;

                case "button_10":
                    button_10.BackColor = Color.Black;
                    break;

                case "button_11":
                    button_11.BackColor = Color.Black;
                    break;

                case "button_12":
                    button_12.BackColor = Color.Black;
                    break;

                case "button_13":
                    button_13.BackColor = Color.Black;
                    break;

                case "button_14":
                    button_14.BackColor = Color.Black;
                    break;

                case "button_15":
                    button_15.BackColor = Color.Black;
                    break;

                case "button_20":
                    button_20.BackColor = Color.Black;
                    break;

                case "button_21":
                    button_21.BackColor = Color.Black;
                    break;

                case "button_22":
                    button_22.BackColor = Color.Black;
                    break;

                case "button_23":
                    button_23.BackColor = Color.Black;
                    break;

                case "button_24":
                    button_24.BackColor = Color.Black;
                    break;

                case "button_25":
                    button_25.BackColor = Color.Black;
                    break;

                case "button_30":
                    button_30.BackColor = Color.Black;
                    break;

                case "button_31":
                    button_31.BackColor = Color.Black;
                    break;

                case "button_32":
                    button_32.BackColor = Color.Black;
                    break;

                case "button_33":
                    button_33.BackColor = Color.Black;
                    break;

                case "button_34":
                    button_34.BackColor = Color.Black;
                    break;

                case "button_35":
                    button_35.BackColor = Color.Black;
                    break;

                case "button_40":
                    button_40.BackColor = Color.Black;
                    break;

                case "button_41":
                    button_41.BackColor = Color.Black;
                    break;

                case "button_42":
                    button_42.BackColor = Color.Black;
                    break;

                case "button_43":
                    button_43.BackColor = Color.Black;
                    break;

                case "button_44":
                    button_44.BackColor = Color.Black;
                    break;

                case "button_45":
                    button_45.BackColor = Color.Black;
                    break;

                case "button_50":
                    button_50.BackColor = Color.Black;
                    break;

                case "button_51":
                    button_51.BackColor = Color.Black;
                    break;

                case "button_52":
                    button_52.BackColor = Color.Black;
                    break;

                case "button_53":
                    button_53.BackColor = Color.Black;
                    break;

                case "button_54":
                    button_54.BackColor = Color.Black;
                    break;

                case "button_55":
                    button_55.BackColor = Color.Black;
                    break;
            }

            //第三引数
            switch (ButtonName3)
            {
                case "button_00":
                    button_00.BackColor = Color.Black;
                    break;

                case "button_01":
                    button_01.BackColor = Color.Black;
                    break;

                case "button_02":
                    button_02.BackColor = Color.Black;
                    break;

                case "button_03":
                    button_03.BackColor = Color.Black;
                    break;

                case "button_04":
                    button_04.BackColor = Color.Black;
                    break;

                case "button_05":
                    button_05.BackColor = Color.Black;
                    break;

                case "button_10":
                    button_10.BackColor = Color.Black;
                    break;

                case "button_11":
                    button_11.BackColor = Color.Black;
                    break;

                case "button_12":
                    button_12.BackColor = Color.Black;
                    break;

                case "button_13":
                    button_13.BackColor = Color.Black;
                    break;

                case "button_14":
                    button_14.BackColor = Color.Black;
                    break;

                case "button_15":
                    button_15.BackColor = Color.Black;
                    break;

                case "button_20":
                    button_20.BackColor = Color.Black;
                    break;

                case "button_21":
                    button_21.BackColor = Color.Black;
                    break;

                case "button_22":
                    button_22.BackColor = Color.Black;
                    break;

                case "button_23":
                    button_23.BackColor = Color.Black;
                    break;

                case "button_24":
                    button_24.BackColor = Color.Black;
                    break;

                case "button_25":
                    button_25.BackColor = Color.Black;
                    break;

                case "button_30":
                    button_30.BackColor = Color.Black;
                    break;

                case "button_31":
                    button_31.BackColor = Color.Black;
                    break;

                case "button_32":
                    button_32.BackColor = Color.Black;
                    break;

                case "button_33":
                    button_33.BackColor = Color.Black;
                    break;

                case "button_34":
                    button_34.BackColor = Color.Black;
                    break;

                case "button_35":
                    button_35.BackColor = Color.Black;
                    break;

                case "button_40":
                    button_40.BackColor = Color.Black;
                    break;

                case "button_41":
                    button_41.BackColor = Color.Black;
                    break;

                case "button_42":
                    button_42.BackColor = Color.Black;
                    break;

                case "button_43":
                    button_43.BackColor = Color.Black;
                    break;

                case "button_44":
                    button_44.BackColor = Color.Black;
                    break;

                case "button_45":
                    button_45.BackColor = Color.Black;
                    break;

                case "button_50":
                    button_50.BackColor = Color.Black;
                    break;

                case "button_51":
                    button_51.BackColor = Color.Black;
                    break;

                case "button_52":
                    button_52.BackColor = Color.Black;
                    break;

                case "button_53":
                    button_53.BackColor = Color.Black;
                    break;

                case "button_54":
                    button_54.BackColor = Color.Black;
                    break;

                case "button_55":
                    button_55.BackColor = Color.Black;
                    break;
            }
            
        }

        //------------------------------------------------------------------------------------------------
        //ポジションナンバーを取得してボタンの色を変える(引数4個)
        //------------------------------------------------------------------------------------------------
        private void ChangeButtonColor(string Position1, string Position2, string Position3,string Position4)
        {
            string ButtonName1 = "button_" + Position1;
            string ButtonName2 = "button_" + Position2;
            string ButtonName3 = "button_" + Position3;
            string ButtonName4 = "button_" + Position4;

            //第一引数
            switch (ButtonName1)
            {
                case "button_00":
                    button_00.BackColor = Color.Black;
                    break;

                case "button_01":
                    button_01.BackColor = Color.Black;
                    break;

                case "button_02":
                    button_02.BackColor = Color.Black;
                    break;

                case "button_03":
                    button_03.BackColor = Color.Black;
                    break;

                case "button_04":
                    button_04.BackColor = Color.Black;
                    break;

                case "button_05":
                    button_05.BackColor = Color.Black;
                    break;

                case "button_10":
                    button_10.BackColor = Color.Black;
                    break;

                case "button_11":
                    button_11.BackColor = Color.Black;
                    break;

                case "button_12":
                    button_12.BackColor = Color.Black;
                    break;

                case "button_13":
                    button_13.BackColor = Color.Black;
                    break;

                case "button_14":
                    button_14.BackColor = Color.Black;
                    break;

                case "button_15":
                    button_15.BackColor = Color.Black;
                    break;

                case "button_20":
                    button_20.BackColor = Color.Black;
                    break;

                case "button_21":
                    button_21.BackColor = Color.Black;
                    break;

                case "button_22":
                    button_22.BackColor = Color.Black;
                    break;

                case "button_23":
                    button_23.BackColor = Color.Black;
                    break;

                case "button_24":
                    button_24.BackColor = Color.Black;
                    break;

                case "button_25":
                    button_25.BackColor = Color.Black;
                    break;

                case "button_30":
                    button_30.BackColor = Color.Black;
                    break;

                case "button_31":
                    button_31.BackColor = Color.Black;
                    break;

                case "button_32":
                    button_32.BackColor = Color.Black;
                    break;

                case "button_33":
                    button_33.BackColor = Color.Black;
                    break;

                case "button_34":
                    button_34.BackColor = Color.Black;
                    break;

                case "button_35":
                    button_35.BackColor = Color.Black;
                    break;

                case "button_40":
                    button_40.BackColor = Color.Black;
                    break;

                case "button_41":
                    button_41.BackColor = Color.Black;
                    break;

                case "button_42":
                    button_42.BackColor = Color.Black;
                    break;

                case "button_43":
                    button_43.BackColor = Color.Black;
                    break;

                case "button_44":
                    button_44.BackColor = Color.Black;
                    break;

                case "button_45":
                    button_45.BackColor = Color.Black;
                    break;

                case "button_50":
                    button_50.BackColor = Color.Black;
                    break;

                case "button_51":
                    button_51.BackColor = Color.Black;
                    break;

                case "button_52":
                    button_52.BackColor = Color.Black;
                    break;

                case "button_53":
                    button_53.BackColor = Color.Black;
                    break;

                case "button_54":
                    button_54.BackColor = Color.Black;
                    break;

                case "button_55":
                    button_55.BackColor = Color.Black;
                    break;

            }

            //第二引数
            switch (ButtonName2)
            {
                case "button_00":
                    button_00.BackColor = Color.Black;
                    break;

                case "button_01":
                    button_01.BackColor = Color.Black;
                    break;

                case "button_02":
                    button_02.BackColor = Color.Black;
                    break;

                case "button_03":
                    button_03.BackColor = Color.Black;
                    break;

                case "button_04":
                    button_04.BackColor = Color.Black;
                    break;

                case "button_05":
                    button_05.BackColor = Color.Black;
                    break;

                case "button_10":
                    button_10.BackColor = Color.Black;
                    break;

                case "button_11":
                    button_11.BackColor = Color.Black;
                    break;

                case "button_12":
                    button_12.BackColor = Color.Black;
                    break;

                case "button_13":
                    button_13.BackColor = Color.Black;
                    break;

                case "button_14":
                    button_14.BackColor = Color.Black;
                    break;

                case "button_15":
                    button_15.BackColor = Color.Black;
                    break;

                case "button_20":
                    button_20.BackColor = Color.Black;
                    break;

                case "button_21":
                    button_21.BackColor = Color.Black;
                    break;

                case "button_22":
                    button_22.BackColor = Color.Black;
                    break;

                case "button_23":
                    button_23.BackColor = Color.Black;
                    break;

                case "button_24":
                    button_24.BackColor = Color.Black;
                    break;

                case "button_25":
                    button_25.BackColor = Color.Black;
                    break;

                case "button_30":
                    button_30.BackColor = Color.Black;
                    break;

                case "button_31":
                    button_31.BackColor = Color.Black;
                    break;

                case "button_32":
                    button_32.BackColor = Color.Black;
                    break;

                case "button_33":
                    button_33.BackColor = Color.Black;
                    break;

                case "button_34":
                    button_34.BackColor = Color.Black;
                    break;

                case "button_35":
                    button_35.BackColor = Color.Black;
                    break;

                case "button_40":
                    button_40.BackColor = Color.Black;
                    break;

                case "button_41":
                    button_41.BackColor = Color.Black;
                    break;

                case "button_42":
                    button_42.BackColor = Color.Black;
                    break;

                case "button_43":
                    button_43.BackColor = Color.Black;
                    break;

                case "button_44":
                    button_44.BackColor = Color.Black;
                    break;

                case "button_45":
                    button_45.BackColor = Color.Black;
                    break;

                case "button_50":
                    button_50.BackColor = Color.Black;
                    break;

                case "button_51":
                    button_51.BackColor = Color.Black;
                    break;

                case "button_52":
                    button_52.BackColor = Color.Black;
                    break;

                case "button_53":
                    button_53.BackColor = Color.Black;
                    break;

                case "button_54":
                    button_54.BackColor = Color.Black;
                    break;

                case "button_55":
                    button_55.BackColor = Color.Black;
                    break;
            }

            //第三引数
            switch (ButtonName3)
            {
                case "button_00":
                    button_00.BackColor = Color.Black;
                    break;

                case "button_01":
                    button_01.BackColor = Color.Black;
                    break;

                case "button_02":
                    button_02.BackColor = Color.Black;
                    break;

                case "button_03":
                    button_03.BackColor = Color.Black;
                    break;

                case "button_04":
                    button_04.BackColor = Color.Black;
                    break;

                case "button_05":
                    button_05.BackColor = Color.Black;
                    break;

                case "button_10":
                    button_10.BackColor = Color.Black;
                    break;

                case "button_11":
                    button_11.BackColor = Color.Black;
                    break;

                case "button_12":
                    button_12.BackColor = Color.Black;
                    break;

                case "button_13":
                    button_13.BackColor = Color.Black;
                    break;

                case "button_14":
                    button_14.BackColor = Color.Black;
                    break;

                case "button_15":
                    button_15.BackColor = Color.Black;
                    break;

                case "button_20":
                    button_20.BackColor = Color.Black;
                    break;

                case "button_21":
                    button_21.BackColor = Color.Black;
                    break;

                case "button_22":
                    button_22.BackColor = Color.Black;
                    break;

                case "button_23":
                    button_23.BackColor = Color.Black;
                    break;

                case "button_24":
                    button_24.BackColor = Color.Black;
                    break;

                case "button_25":
                    button_25.BackColor = Color.Black;
                    break;

                case "button_30":
                    button_30.BackColor = Color.Black;
                    break;

                case "button_31":
                    button_31.BackColor = Color.Black;
                    break;

                case "button_32":
                    button_32.BackColor = Color.Black;
                    break;

                case "button_33":
                    button_33.BackColor = Color.Black;
                    break;

                case "button_34":
                    button_34.BackColor = Color.Black;
                    break;

                case "button_35":
                    button_35.BackColor = Color.Black;
                    break;

                case "button_40":
                    button_40.BackColor = Color.Black;
                    break;

                case "button_41":
                    button_41.BackColor = Color.Black;
                    break;

                case "button_42":
                    button_42.BackColor = Color.Black;
                    break;

                case "button_43":
                    button_43.BackColor = Color.Black;
                    break;

                case "button_44":
                    button_44.BackColor = Color.Black;
                    break;

                case "button_45":
                    button_45.BackColor = Color.Black;
                    break;

                case "button_50":
                    button_50.BackColor = Color.Black;
                    break;

                case "button_51":
                    button_51.BackColor = Color.Black;
                    break;

                case "button_52":
                    button_52.BackColor = Color.Black;
                    break;

                case "button_53":
                    button_53.BackColor = Color.Black;
                    break;

                case "button_54":
                    button_54.BackColor = Color.Black;
                    break;

                case "button_55":
                    button_55.BackColor = Color.Black;
                    break;
            }

            //第四引数
            switch (ButtonName4)
            {
                case "button_00":
                    button_00.BackColor = Color.Black;
                    break;

                case "button_01":
                    button_01.BackColor = Color.Black;
                    break;

                case "button_02":
                    button_02.BackColor = Color.Black;
                    break;

                case "button_03":
                    button_03.BackColor = Color.Black;
                    break;

                case "button_04":
                    button_04.BackColor = Color.Black;
                    break;

                case "button_05":
                    button_05.BackColor = Color.Black;
                    break;

                case "button_10":
                    button_10.BackColor = Color.Black;
                    break;

                case "button_11":
                    button_11.BackColor = Color.Black;
                    break;

                case "button_12":
                    button_12.BackColor = Color.Black;
                    break;

                case "button_13":
                    button_13.BackColor = Color.Black;
                    break;

                case "button_14":
                    button_14.BackColor = Color.Black;
                    break;

                case "button_15":
                    button_15.BackColor = Color.Black;
                    break;

                case "button_20":
                    button_20.BackColor = Color.Black;
                    break;

                case "button_21":
                    button_21.BackColor = Color.Black;
                    break;

                case "button_22":
                    button_22.BackColor = Color.Black;
                    break;

                case "button_23":
                    button_23.BackColor = Color.Black;
                    break;

                case "button_24":
                    button_24.BackColor = Color.Black;
                    break;

                case "button_25":
                    button_25.BackColor = Color.Black;
                    break;

                case "button_30":
                    button_30.BackColor = Color.Black;
                    break;

                case "button_31":
                    button_31.BackColor = Color.Black;
                    break;

                case "button_32":
                    button_32.BackColor = Color.Black;
                    break;

                case "button_33":
                    button_33.BackColor = Color.Black;
                    break;

                case "button_34":
                    button_34.BackColor = Color.Black;
                    break;

                case "button_35":
                    button_35.BackColor = Color.Black;
                    break;

                case "button_40":
                    button_40.BackColor = Color.Black;
                    break;

                case "button_41":
                    button_41.BackColor = Color.Black;
                    break;

                case "button_42":
                    button_42.BackColor = Color.Black;
                    break;

                case "button_43":
                    button_43.BackColor = Color.Black;
                    break;

                case "button_44":
                    button_44.BackColor = Color.Black;
                    break;

                case "button_45":
                    button_45.BackColor = Color.Black;
                    break;

                case "button_50":
                    button_50.BackColor = Color.Black;
                    break;

                case "button_51":
                    button_51.BackColor = Color.Black;
                    break;

                case "button_52":
                    button_52.BackColor = Color.Black;
                    break;

                case "button_53":
                    button_53.BackColor = Color.Black;
                    break;

                case "button_54":
                    button_54.BackColor = Color.Black;
                    break;

                case "button_55":
                    button_55.BackColor = Color.Black;
                    break;

            }

        }

        //------------------------------------------------------------------------------------------------
        //comboBoxの値をもとにポジション描写
        //------------------------------------------------------------------------------------------------
        private void DisplayPosition()
        {
            XmlDoc = new XDocument();
            XmlDoc = XDocument.Load(createConfigXML.CurrentPath(), LoadOptions.PreserveWhitespace);

            PositionValue1 = "";
            PositionValue2 = "";
            PositionValue3 = "";
            PositionValue4 = "";
            BarreFlg = "";
            Barre = "";
            High = 0;

            var query = from y in XmlDoc.Descendants("Chord")
                        where y.Element("Root").Value == comboBox1.Text &
                              y.Element("Degree").Value == comboBox2.Text
                        select y;

            foreach (XElement item in query)
            {
                PositionValue1 = item.Element("Position1").Value;
                PositionValue2 = item.Element("Position2").Value;
                PositionValue3 = item.Element("Position3").Value;
                BarreFlg = item.Element("BarreFlg").Value;
                Barre = item.Element("Barre").Value;
                High = int.Parse(item.Element("High").Value);

                if (item.Element("Position4").Value != "")
                {
                    PositionValue4 = item.Element("Position4").Value;
                }
            }

            if(High >= 4)
            {
                label2.Text = Convert.ToString(High);
                label3.Text = Convert.ToString(High + 1);
                label4.Text = Convert.ToString(High + 2);
                label5.Text = Convert.ToString(High + 3);
                label6.Text = Convert.ToString(High + 4);
                label7.Text = Convert.ToString(High + 5);
            }
            else if(High == 0)
            {
                High = High + 1;
                label2.Text = Convert.ToString(High);
                label3.Text = Convert.ToString(High + 1);
                label4.Text = Convert.ToString(High + 2);
                label5.Text = Convert.ToString(High + 3);
                label6.Text = Convert.ToString(High + 4);
                label7.Text = Convert.ToString(High + 5);
            }

            if (BarreFlg ==Convert.ToString(1))
            {
                if (PositionValue4 != "")
                {
                    ChangeButtonColor(PositionValue1, PositionValue2, PositionValue3, PositionValue4);
                    BarrePosition(Barre);
                }
                else
                {
                    ChangeButtonColor(PositionValue1, PositionValue2, PositionValue3);
                    BarrePosition(Barre);
                }

            }
            else
            {
                if(PositionValue4 != "")
                {
                    ChangeButtonColor(PositionValue1, PositionValue2, PositionValue3,PositionValue4);
                }
                else
                {
                    ChangeButtonColor(PositionValue1, PositionValue2, PositionValue3);
                }
            }


        }

        //------------------------------------------------------------------------------------------------
        //バレーコードポジション反映
        //------------------------------------------------------------------------------------------------
        private void BarrePosition(string BarrePos)
        {
            switch(Barre)
            {
                case "1":
                    button_00.BackColor = Color.Black;
                    button_01.BackColor = Color.Black;
                    button_02.BackColor = Color.Black;
                    button_03.BackColor = Color.Black;
                    button_04.BackColor = Color.Black;
                    button_05.BackColor = Color.Black;
                    break;

                case "2":
                    button_10.BackColor = Color.Black;
                    button_11.BackColor = Color.Black;
                    button_12.BackColor = Color.Black;
                    button_13.BackColor = Color.Black;
                    button_14.BackColor = Color.Black;
                    button_15.BackColor = Color.Black;
                    break;

                case "3":
                    button_20.BackColor = Color.Black;
                    button_21.BackColor = Color.Black;
                    button_22.BackColor = Color.Black;
                    button_23.BackColor = Color.Black;
                    button_24.BackColor = Color.Black;
                    button_25.BackColor = Color.Black;
                    break;

                case "4":
                    button_30.BackColor = Color.Black;
                    button_31.BackColor = Color.Black;
                    button_32.BackColor = Color.Black;
                    button_33.BackColor = Color.Black;
                    button_34.BackColor = Color.Black;
                    button_35.BackColor = Color.Black;
                    break;

                case "5":
                    button_40.BackColor = Color.Black;
                    button_41.BackColor = Color.Black;
                    button_42.BackColor = Color.Black;
                    button_43.BackColor = Color.Black;
                    button_44.BackColor = Color.Black;
                    button_45.BackColor = Color.Black;
                    break;

            }
        }

        //------------------------------------------------------------------------------------------------
        //ポジションボタンクリック処理
        //------------------------------------------------------------------------------------------------
        private void ButtonColorChange(int flg,object sender)
        {
            if(flg == 1)
            {
                ((Button)sender).BackColor = Color.Black;
            }
            else if(flg == 2)
            {
                ((Button)sender).BackColor = SystemColors.Control;
            }
        }

        //------------------------------------------------------------------------------------------------
        //ポジションナンバー初期化
        //------------------------------------------------------------------------------------------------
        public void InitFletNo()
        {
            int SettingHigh = 0;

            label2.Text = "";
            label3.Text = "";
            label4.Text = "";
            label5.Text = "";
            label6.Text = "";
            label7.Text = "";

            XmlDoc = new XDocument();
            XmlDoc = XDocument.Load(createConfigXML.CurrentPath_database());

            var query = from y in XmlDoc.Descendants("Chord")
                        where y.Element("Root").Value == comboBox1.Text &
                              y.Element("Degree").Value == comboBox2.Text
                        select y;

            try
            {
                foreach (XElement item in query)
                {
                    SettingHigh = int.Parse(item.Element("High").Value);

                    if (SettingHigh <= 4)
                    {
                        label2.Text = "1";
                        label3.Text = "2";
                        label4.Text = "3";
                        label5.Text = "4";
                        label6.Text = "5";
                        label7.Text = "6";
                    }
                    else if (SettingHigh >= 4)
                    {
                        label2.Text = Convert.ToString(SettingHigh);
                        label3.Text = Convert.ToString(SettingHigh + 1);
                        label4.Text = Convert.ToString(SettingHigh + 2);
                        label5.Text = Convert.ToString(SettingHigh + 3);
                        label6.Text = Convert.ToString(SettingHigh + 4);
                        label7.Text = Convert.ToString(SettingHigh + 5);
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }

        //☆★☆★☆★☆★☆★☆★☆★☆★                    ☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★ 
        //☆★☆★☆★☆★☆★☆★☆★☆★以下イベントハンドラ☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★ 
        //☆★☆★☆★☆★☆★☆★☆★☆★                    ☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★ 

        //------------------------------------------------------------------------------------------------
        //フォームロード
        //------------------------------------------------------------------------------------------------
        private void ChordSettingForm_Load(object sender, EventArgs e)
        {
            createConfigXML.CreateConfigXML();

            //タイトルバーを消す
            this.ControlBox = false;
            this.Text = "";
            //フォームサイズ変更不可
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            comboBox1.Items.Add(ChordStruct.Key_C);
            comboBox1.Items.Add(ChordStruct.Key_Csharp);
            comboBox1.Items.Add(ChordStruct.Key_D);
            comboBox1.Items.Add(ChordStruct.Key_Dsharp);
            comboBox1.Items.Add(ChordStruct.Key_Dflat);
            comboBox1.Items.Add(ChordStruct.Key_E);
            comboBox1.Items.Add(ChordStruct.Key_Eflat);
            comboBox1.Items.Add(ChordStruct.Key_F);
            comboBox1.Items.Add(ChordStruct.Key_Fsharp);
            comboBox1.Items.Add(ChordStruct.Key_G);
            comboBox1.Items.Add(ChordStruct.Key_Gsharp);
            comboBox1.Items.Add(ChordStruct.Key_Gflat);
            comboBox1.Items.Add(ChordStruct.Key_A);
            comboBox1.Items.Add(ChordStruct.Key_Asharp);
            comboBox1.Items.Add(ChordStruct.Key_Aflat);
            comboBox1.Items.Add(ChordStruct.Key_B);
            comboBox1.Items.Add(ChordStruct.Key_Bflat);

            comboBox2.Items.Add(ChordStruct.Key_6);
            comboBox2.Items.Add(ChordStruct.Key_7flat5);
            comboBox2.Items.Add(ChordStruct.Key_7flat9);
            comboBox2.Items.Add(ChordStruct.Key_7);
            comboBox2.Items.Add(ChordStruct.Key_7sharp5);
            comboBox2.Items.Add(ChordStruct.Key_7sharp9);
            comboBox2.Items.Add(ChordStruct.Key_7sus4);
            comboBox2.Items.Add(ChordStruct.Key_9);
            comboBox2.Items.Add(ChordStruct.Key_7nineth);
            comboBox2.Items.Add(ChordStruct.Key_6nineth);
            comboBox2.Items.Add(ChordStruct.Key_Major);
            comboBox2.Items.Add(ChordStruct.Key_add9);
            comboBox2.Items.Add(ChordStruct.Key_aug);
            comboBox2.Items.Add(ChordStruct.Key_aug7);
            comboBox2.Items.Add(ChordStruct.Key_dim);
            comboBox2.Items.Add(ChordStruct.Key_m6);
            comboBox2.Items.Add(ChordStruct.Key_m7flat5);
            comboBox2.Items.Add(ChordStruct.Key_m7flat9);
            comboBox2.Items.Add(ChordStruct.Key_m7);
            comboBox2.Items.Add(ChordStruct.Key_m9);
            comboBox2.Items.Add(ChordStruct.Key_m7nineth);
            comboBox2.Items.Add(ChordStruct.Key_m6nineth);
            comboBox2.Items.Add(ChordStruct.Key_Minor);
            comboBox2.Items.Add(ChordStruct.Key_M7);
            comboBox2.Items.Add(ChordStruct.Key_M9);
            comboBox2.Items.Add(ChordStruct.Key_M7nineth);
            comboBox2.Items.Add(ChordStruct.Key_mM7);
            comboBox2.Items.Add(ChordStruct.Key_sus4);
            comboBox2.Items.Add(ChordStruct.Key_11);

            comboBox1.Text = ChordStruct.Key_C;
            comboBox2.Text = ChordStruct.Key_Major;

            InitButtonColor();
            DisplayPosition();
            InitFletNo();

        }

        //------------------------------------------------------------------------------------------------
        //コンボボックスの値が変更された時
        //------------------------------------------------------------------------------------------------
        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            InitButtonColor();
            DisplayPosition();
            InitFletNo();
        }

        //------------------------------------------------------------------------------------------------
        //ポジションのボタンがクリックされた時
        //------------------------------------------------------------------------------------------------
        private void button_00_Click(object sender, EventArgs e)
        {
            /*if (((Button)sender).BackColor == SystemColors.Control)
            {
                ButtonColorChange(1,sender);
            }
            else
            {
                ButtonColorChange(2, sender);
            }*/
        }

        //------------------------------------------------------------------------------------------------
        //閉じるボタン
        //------------------------------------------------------------------------------------------------
        private void button38_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //------------------------------------------------------------------------------------------------
        //フォームマウスムーブ
        //------------------------------------------------------------------------------------------------
        private void ChordSettingForm_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                this.Left += e.X - mousePoint.X;
                this.Top += e.Y - mousePoint.Y;
            }
        }

        //------------------------------------------------------------------------------------------------
        //フォームマウスダウン
        //------------------------------------------------------------------------------------------------
        private void ChordSettingForm_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                //位置を記憶する
                mousePoint = new Point(e.X, e.Y);
            }
        }
    }
}
