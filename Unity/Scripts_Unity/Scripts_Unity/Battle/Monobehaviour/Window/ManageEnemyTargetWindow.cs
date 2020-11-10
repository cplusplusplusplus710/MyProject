using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ターゲットウィンドウの管理
/// </summary>
class ManageEnemyTargetWindow : MonoBehaviour
{
    /// <summary>
    /// 読み込み時
    /// </summary>
    void Start()
    {
        //全ターゲット判定用オブジェクトを起動
        VisibleUIManage.ManageStart_ChoiseTargetEnemy_1();
        VisibleUIManage.ManageStart_ChoiseTargetEnemy_2();
        VisibleUIManage.ManageStart_ChoiseTargetEnemy_3();

        ManageBattle.CheckCanTargetEnemy_Single();

        var query_Enemy = from x in BattleStaticValiable.xdoc2.Descendants("Enemy")
                          select x;

        //No順にテキストに敵の名前を入れる
        foreach(var item in query_Enemy)
        {
            switch(item.Element("BattleNo").Value)
            {
                case "1":
                    GameManager.TextTarget1_EnemyTargetWindow.text = item.Element("EnemyName").Value;
                    break;
                case "2":
                    GameManager.TextTarget2_EnemyTargetWindow.text = item.Element("EnemyName").Value;
                    break;
                case "3":
                    GameManager.TextTarget3_EnemyTargetWindow.text = item.Element("EnemyName").Value;
                    break;
            }
        }

        //名前が空なら判定を消去する
        string s1 = OperateBattleSheetData.GetBatteSheetData(GetXMLQueryKey_EnemyData.EnemyName(), 1);
        string s2 = OperateBattleSheetData.GetBatteSheetData(GetXMLQueryKey_EnemyData.EnemyName(), 2);
        string s3 = OperateBattleSheetData.GetBatteSheetData(GetXMLQueryKey_EnemyData.EnemyName(), 3);
        if (s1 == "")
        {
            VisibleUIManage.ManageStart_ReturnTargetEnemy_1();
        }
        if (s2 == "")
        {
            VisibleUIManage.ManageStart_ReturnTargetEnemy_2();
        }
        if (s3 == "")
        {
            VisibleUIManage.ManageStart_ReturnTargetEnemy_3();
        }
    }
}

