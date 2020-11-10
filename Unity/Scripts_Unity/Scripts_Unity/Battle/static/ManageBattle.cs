using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// バトルを管理するクラス
/// </summary>
static class ManageBattle
{
    //敵がターゲット可能かどうかチェック(単体攻撃用)
    public static void CheckCanTargetEnemy_Single()
    {
        var query_Enemy = from x in BattleStaticValiable.xdoc2.Descendants("Enemy")
                          where x.Element("EnemyHP").Value == "0"
                          select x;

        foreach(var item in query_Enemy)
        {
            string BattleNo = "";
            BattleNo = item.Element("BattleNo").Value;

            Transform TargetCursorObject_EnemyTargetWindow = GameManager.Background.transform
                                                              .Find("Target" + BattleNo + "CursorObject_EnemyTargetWindow");

            TargetCursorObject_EnemyTargetWindow.gameObject.SetActive(false);
        }

    }

    /// <summary>
    /// 単体攻撃で敵を倒した時の処理
    /// </summary>
    /// <param name="TargetFlg"></param>
    public static void DeadEnemy_Single(string TargetFlg)
    {
        //バトルシートからデータを消す
        //HPは0のままにしとく
        //Experienceは残しておく
        var query_Enemy = (from x in BattleStaticValiable.xdoc2.Descendants("Enemy")
                           where x.Element("BattleNo").Value == GameManager.TargetFlg
                           select x).Single();

        GameManager.Text_MainWindow.text = query_Enemy.Element("EnemyName").Value + GetEnemyDeadText.EnemyDeadText(query_Enemy.Element("EnemyName").Value);

        MonoBehaviour mono = new MonoBehaviour();
        mono.StartCoroutine(GameManager.WaitTime_1());

        query_Enemy.Attribute("No").Value = "";
        query_Enemy.Element("EnemyName").Value = "";
        query_Enemy.Element("EnemyHP").Value = "0";
        query_Enemy.Element("EnemyAttackValue").Value = "";
        query_Enemy.Element("EnemyDiffenceValue").Value = "";
        query_Enemy.Element("EnemySpeedValue").Value = "";

        query_Enemy.Element("EnemySkill_Name_No1").Value = "";
        query_Enemy.Element("EnemySkill_StringValue1_No1").Value = "";
        query_Enemy.Element("EnemySkill_StringValue2_No1").Value = "";
        query_Enemy.Element("EnemySkill_StringValue3_No1").Value = "";
        query_Enemy.Element("EnemySkill_IntValue1_No1").Value = "";
        query_Enemy.Element("EnemySkill_IntValue2_No1").Value = "";
        query_Enemy.Element("EnemySkill_IntValue3_No1").Value = "";

        query_Enemy.Element("EnemySkill_Name_No2").Value = "";
        query_Enemy.Element("EnemySkill_StringValue1_No2").Value = "";
        query_Enemy.Element("EnemySkill_StringValue2_No2").Value = "";
        query_Enemy.Element("EnemySkill_StringValue3_No2").Value = "";
        query_Enemy.Element("EnemySkill_IntValue1_No2").Value = "";
        query_Enemy.Element("EnemySkill_IntValue2_No2").Value = "";
        query_Enemy.Element("EnemySkill_IntValue3_No2").Value = "";

        query_Enemy.Element("EnemySkill_Name_No3").Value = "";
        query_Enemy.Element("EnemySkill_StringValue1_No3").Value = "";
        query_Enemy.Element("EnemySkill_StringValue2_No3").Value = "";
        query_Enemy.Element("EnemySkill_StringValue3_No3").Value = "";
        query_Enemy.Element("EnemySkill_IntValue1_No3").Value = "";
        query_Enemy.Element("EnemySkill_IntValue2_No3").Value = "";
        query_Enemy.Element("EnemySkill_IntValue3_No3").Value = "";

        query_Enemy.Element("EnemyResistance_Name_No1").Value = "";
        query_Enemy.Element("EnemyResistance_StringValue1_No1").Value = "";
        query_Enemy.Element("EnemyResistance_StringValue2_No1").Value = "";
        query_Enemy.Element("EnemyResistance_StringValue3_No1").Value = "";
        query_Enemy.Element("EnemyResistance_IntValue1_No1").Value = "";
        query_Enemy.Element("EnemyResistance_IntValue2_No1").Value = "";
        query_Enemy.Element("EnemyResistance_IntValue3_No1").Value = "";

        BattleStaticValiable.xdoc2.Save(GetXmlPath.BattleEnemyDataSheetPath());

        //死んだ敵の画像を消す
        Image EnemyImage = GameObject.Find("EnemyImage" + GameManager.TargetFlg).GetComponent<Image>();
        Texture2D texture_Enemy = Resources.Load("NoImage") as Texture2D;
        EnemyImage.sprite = Sprite.Create(texture_Enemy,
                                          new Rect(0, 0, texture_Enemy.width, texture_Enemy.height),
                                          Vector2.zero);
    }

    /// <summary>
    /// 勝利判定
    /// </summary>
    public static void CheckWin()
    {
        var query_win = from x in BattleStaticValiable.xdoc2.Descendants("Enemy")
                        select x;

        int EnemyHPSUM = 0;
        foreach(var item in query_win)
        {
            EnemyHPSUM = EnemyHPSUM + int.Parse(item.Element("EnemyHP").Value);
        }

        //結果がゼロの時、勝利処理
        if(EnemyHPSUM == 0)
        {
            GameManager.Text_MainWindow.text = OperatePlayerData.GetPlayerData("PlayerName") + "は戦いに勝利した！";

            MonoBehaviour mono = new MonoBehaviour();
            mono.StartCoroutine(GameManager.WaitTime_1());

            //経験値の計算
            int Experience = 0;
            foreach(var item in query_win)
            {
                Experience = Experience + int.Parse(item.Element("EnemyExperience").Value);
            }

            GameManager.Text_MainWindow.text = OperatePlayerData.GetPlayerData("PlayerName") + "は" + Experience + "の経験値を手に入れた。";

            //経験値を合算して反映
            int ExperienceSUM = int.Parse(OperatePlayerData.GetPlayerData(GetXMLQueryKey_PlayerData.PlayerExperience()) + Experience);
            OperatePlayerData.SetPlayerData(Convert.ToString(ExperienceSUM), OperatePlayerData.GetPlayerData(GetXMLQueryKey_PlayerData.PlayerExperience()));

            //経験値量によってレベルアップさせる
            switch(Experience)
            {
                case 20:
                    OperatePlayerData.SetPlayerData("2", OperatePlayerData.GetPlayerData(GetXMLQueryKey_PlayerData.PlayerLevel()));
                    LevelUp();

                    GameManager.Text_MainWindow.text = OperatePlayerData.GetPlayerData("PlayerName") + "はレベルアップした！";
                    mono.StartCoroutine(GameManager.WaitTime_1());

                    SceneManager.LoadScene("現在のマップ");
                    break;

                case 70:
                    OperatePlayerData.SetPlayerData("3", OperatePlayerData.GetPlayerData(GetXMLQueryKey_PlayerData.PlayerLevel()));

                    GameManager.Text_MainWindow.text = OperatePlayerData.GetPlayerData("PlayerName") + "はレベルアップした！";
                    mono.StartCoroutine(GameManager.WaitTime_1());

                    SceneManager.LoadScene("現在のマップ");

                    break;
            }
        }
        else
        {
            //そうじゃないときはなにもしない
        }
    }

    /// <summary>
    /// プレイヤーが死んだ時の処理
    /// </summary>
    public static void DeadPlayer()
    {
        GameManager.Text_MainWindow.text = OperatePlayerData.GetPlayerData(GetXMLQueryKey_PlayerData.PlayerName()) + "は全滅した…";
    }

    /// <summary>
    /// レベルアップ時のパラメータ変動
    /// </summary>
    public static void LevelUp()
    {
        var AttackPlus = UnityEngine.Random.Range(2, 5);
        string SetAttackPoint = Convert.ToString(int.Parse(OperatePlayerData.GetPlayerData(GetXMLQueryKey_PlayerData.PlayerAttackValue()) + AttackPlus));
        OperatePlayerData.SetPlayerData(SetAttackPoint, OperatePlayerData.GetPlayerData(GetXMLQueryKey_PlayerData.PlayerAttackValue()));

        var DiffencePlus = UnityEngine.Random.Range(2, 5);
        string SetDiffencePoint = Convert.ToString(int.Parse(OperatePlayerData.GetPlayerData(GetXMLQueryKey_PlayerData.PlayerDiffenceValue()) + DiffencePlus));
        OperatePlayerData.SetPlayerData(SetDiffencePoint, OperatePlayerData.GetPlayerData(GetXMLQueryKey_PlayerData.PlayerDiffenceValue()));

        var SpeedPlus = UnityEngine.Random.Range(1, 5);
        string SetSpeedPoint = Convert.ToString(int.Parse(OperatePlayerData.GetPlayerData(GetXMLQueryKey_PlayerData.PlayerSpeedValue()) + SpeedPlus));
        OperatePlayerData.SetPlayerData(SetSpeedPoint, OperatePlayerData.GetPlayerData(GetXMLQueryKey_PlayerData.PlayerSpeedValue()));

        var HPPlus = UnityEngine.Random.Range(3, 7);
        string SetHPPoint = Convert.ToString(int.Parse(OperatePlayerData.GetPlayerData(GetXMLQueryKey_PlayerData.PlayerMaxHP()) + HPPlus));
        OperatePlayerData.SetPlayerData(SetHPPoint, OperatePlayerData.GetPlayerData(GetXMLQueryKey_PlayerData.PlayerMaxHP()));
    }
}

