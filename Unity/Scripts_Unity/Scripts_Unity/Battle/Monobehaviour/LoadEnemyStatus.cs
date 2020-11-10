using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;

/// <summary>
/// 戦闘開始時、EnemyDataの値をBattleSheetに書き込み。
/// 雑魚戦用。
/// </summary>
public class LoadEnemyStatus : MonoBehaviour
{
    //フィールド
    private int Level;

    /// <summary>
    /// 雑魚敵のデータを戦闘開始時にロードする
    /// </summary>
    public void LoadEnemy(int AreaLevel)
    {
        Level = AreaLevel;  //どうにかしてエリアのレベルを取得する
        //Level = 1; //デバッグ用で1を設定

        //エリアレベルをもとに敵のNoを選出したリストを作成する
        //その後、ランダム(重複あり)に抽出し、配列にする
        List<int> EnemyChoiceList = new List<int>(ConvertEnemyNoFromAreaLavel(AreaLevel));
        int[] NoRadomChoice = new int[EnemyChoiceList.Count];

        for (int i = 0; i <= EnemyChoiceList.Count - 1; i++)
        {
            NoRadomChoice[i] = EnemyChoiceList[UnityEngine.Random.Range(0, EnemyChoiceList.Count - 1)];
        }

        //乱数で敵の出現数を設定
        int EnemyCount = UnityEngine.Random.Range(1, 3);

        //エリアレベル1の時は1体だけ
        if(Level == 1)
        {
            EnemyCount = 1;
        }

        string EnemyCountToString = Convert.ToString(EnemyCount);
        XDocument XmlDoc = XDocument.Load(GetXmlPath.EnemyDataPath());
        XDocument xmlDoc2 = XDocument.Load(GetXmlPath.BattleEnemyDataSheetPath());

        //バトルシート値リセット
        ResetXML.ResetBattleSheet();

        //乱数をもとにクエリ生成し、バトルシートに転写
        for (int i = 0; i <= EnemyCount - 1; i++)
        {
            //EnemyData
            var query = from x in XmlDoc.Descendants("Enemy")
                        where x.Attribute("No").Value == NoRadomChoice[i].ToString()
                        select new
                        {
                            EnemyNo = x.Attribute("No").Value,
                            EnemyName = x.Element("EnemyName").Value,
                            EnemyHP = x.Element("EnemyHP").Value,
                            EnemyAttackValue = x.Element("EnemyAttackValue").Value,
                            EnemyDiffenceValue = x.Element("EnemyDiffenceValue").Value,
                            EnemySpeedValue = x.Element("EnemySpeedValue").Value,
                            EnemyExperience = x.Element("EnemyExperience").Value,

                            EnemySkill_Name_No1 = x.Element("EnemySkill_Name_No1").Value,
                            EnemySkill_StringValue1_No1 = x.Element("EnemySkill_StringValue1_No1").Value,
                            EnemySkill_StringValue2_No1 = x.Element("EnemySkill_StringValue2_No1").Value,
                            EnemySkill_StringValue3_No1 = x.Element("EnemySkill_StringValue3_No1").Value,
                            EnemySkill_IntValue1_No1 = x.Element("EnemySkill_IntValue1_No1").Value,
                            EnemySkill_IntValue2_No1 = x.Element("EnemySkill_IntValue2_No1").Value,
                            EnemySkill_IntValue3_No1 = x.Element("EnemySkill_IntValue3_No1").Value,

                            EnemySkill_Name_No2 = x.Element("EnemySkill_Name_No2").Value,
                            EnemySkill_StringValue1_No2 = x.Element("EnemySkill_StringValue1_No2").Value,
                            EnemySkill_StringValue2_No2 = x.Element("EnemySkill_StringValue2_No2").Value,
                            EnemySkill_StringValue3_No2 = x.Element("EnemySkill_StringValue3_No2").Value,
                            EnemySkill_IntValue1_No2 = x.Element("EnemySkill_IntValue1_No2").Value,
                            EnemySkill_IntValue2_No2 = x.Element("EnemySkill_IntValue2_No2").Value,
                            EnemySkill_IntValue3_No2 = x.Element("EnemySkill_IntValue3_No2").Value,

                            EnemySkill_Name_No3 = x.Element("EnemySkill_Name_No3").Value,
                            EnemySkill_StringValue1_No3 = x.Element("EnemySkill_StringValue1_No3").Value,
                            EnemySkill_StringValue2_No3 = x.Element("EnemySkill_StringValue2_No3").Value,
                            EnemySkill_StringValue3_No3 = x.Element("EnemySkill_StringValue3_No3").Value,
                            EnemySkill_IntValue1_No3 = x.Element("EnemySkill_IntValue1_No3").Value,
                            EnemySkill_IntValue2_No3 = x.Element("EnemySkill_IntValue2_No3").Value,
                            EnemySkill_IntValue3_No3 = x.Element("EnemySkill_IntValue3_No3").Value,

                            EnemyResistance_Name_No1 = x.Element("EnemyResistance_Name_No1").Value,
                            EnemyResistance_StringValue1_No1 = x.Element("EnemyResistance_StringValue1_No1").Value,
                            EnemyResistance_StringValue2_No1 = x.Element("EnemyResistance_StringValue2_No1").Value,
                            EnemyResistance_StringValue3_No1 = x.Element("EnemyResistance_StringValue3_No1").Value,
                            EnemyResistance_IntValue1_No1 = x.Element("EnemyResistance_IntValue1_No1").Value,
                            EnemyResistance_IntValue2_No1 = x.Element("EnemyResistance_IntValue2_No1").Value,
                            EnemyResistance_IntValue3_No1 = x.Element("EnemyResistance_IntValue3_No1").Value,

                            DropItem = x.Element("DropItem").Value,
                            DropItemID = x.Element("DropItemID").Value,
                            DropPercent = x.Element("DropPercent").Value,
                        };

            //BattleEnemyDataSheet
            var query2 = (from y in xmlDoc2.Root.Descendants("Enemy")
                          where y.Element("BattleNo").Value == Convert.ToString(i + 1)
                          select y).Single();

            foreach (var item in query)
            {
                query2.Attribute("No").Value = item.EnemyNo;
                query2.Element("EnemyName").Value = item.EnemyName;
                query2.Element("EnemyHP").Value = item.EnemyHP;
                query2.Element("EnemyAttackValue").Value = item.EnemyAttackValue;
                query2.Element("EnemyDiffenceValue").Value = item.EnemyDiffenceValue;
                query2.Element("EnemySpeedValue").Value = item.EnemySpeedValue;
                query2.Element("EnemyExperience").Value = item.EnemyExperience;

                query2.Element("EnemySkill_Name_No1").Value = item.EnemySkill_Name_No1;
                query2.Element("EnemySkill_StringValue1_No1").Value = item.EnemySkill_StringValue1_No1;
                query2.Element("EnemySkill_StringValue2_No1").Value = item.EnemySkill_StringValue2_No1;
                query2.Element("EnemySkill_StringValue3_No1").Value = item.EnemySkill_StringValue3_No1;
                query2.Element("EnemySkill_IntValue1_No1").Value = item.EnemySkill_IntValue1_No1;
                query2.Element("EnemySkill_IntValue2_No1").Value = item.EnemySkill_IntValue2_No1;
                query2.Element("EnemySkill_IntValue3_No1").Value = item.EnemySkill_IntValue3_No1;

                query2.Element("EnemySkill_Name_No2").Value = item.EnemySkill_Name_No2;
                query2.Element("EnemySkill_StringValue1_No2").Value = item.EnemySkill_StringValue1_No2;
                query2.Element("EnemySkill_StringValue2_No2").Value = item.EnemySkill_StringValue2_No2;
                query2.Element("EnemySkill_StringValue3_No2").Value = item.EnemySkill_StringValue3_No2;
                query2.Element("EnemySkill_IntValue1_No2").Value = item.EnemySkill_IntValue1_No2;
                query2.Element("EnemySkill_IntValue2_No2").Value = item.EnemySkill_IntValue2_No2;
                query2.Element("EnemySkill_IntValue3_No2").Value = item.EnemySkill_IntValue3_No2;

                query2.Element("EnemySkill_Name_No3").Value = item.EnemySkill_Name_No3;
                query2.Element("EnemySkill_StringValue1_No3").Value = item.EnemySkill_StringValue1_No3;
                query2.Element("EnemySkill_StringValue2_No3").Value = item.EnemySkill_StringValue2_No3;
                query2.Element("EnemySkill_StringValue3_No3").Value = item.EnemySkill_StringValue3_No3;
                query2.Element("EnemySkill_IntValue1_No3").Value = item.EnemySkill_IntValue1_No3;
                query2.Element("EnemySkill_IntValue2_No3").Value = item.EnemySkill_IntValue2_No3;
                query2.Element("EnemySkill_IntValue3_No3").Value = item.EnemySkill_IntValue3_No3;

                query2.Element("EnemyResistance_Name_No1").Value = item.EnemyResistance_Name_No1;
                query2.Element("EnemyResistance_StringValue1_No1").Value = item.EnemyResistance_StringValue1_No1;
                query2.Element("EnemyResistance_StringValue2_No1").Value = item.EnemyResistance_StringValue2_No1;
                query2.Element("EnemyResistance_StringValue3_No1").Value = item.EnemyResistance_StringValue3_No1;
                query2.Element("EnemyResistance_IntValue1_No1").Value = item.EnemyResistance_IntValue1_No1;
                query2.Element("EnemyResistance_IntValue2_No1").Value = item.EnemyResistance_IntValue2_No1;
                query2.Element("EnemyResistance_IntValue3_No1").Value = item.EnemyResistance_IntValue3_No1;

                query2.Element("DropItem").Value = item.DropItem;
                query2.Element("DropItemID").Value = item.DropItem;
                query2.Element("DropPercent").Value = item.DropPercent;

                xmlDoc2.Save(GetXmlPath.BattleEnemyDataSheetPath());
            }
        }
    }

    /// <summary>
    /// エリアレベルから敵のナンバーを選択して返す 
    /// </summary>
    /// <param name="AreaLevel"></param>
    /// <returns></returns>
    private List<int> ConvertEnemyNoFromAreaLavel(int AreaLevel)
    {
        List<int> list = new List<int>();

        switch (AreaLevel) //エリアレベルごとに値を設定して返す
        {
            case 1:
                list.Add(1);
                break;

            case 2:
                for (int i = 1; i < 2; i++)
                {
                    list.Add(i);
                }
                break;

            case 3:
                for (int i = 1; i < 3; i++)
                {
                    list.Add(i);
                }
                break;


            default:
                break;
        }

        return list;
    }
}
