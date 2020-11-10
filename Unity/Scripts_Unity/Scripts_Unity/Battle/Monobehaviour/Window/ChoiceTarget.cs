using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Target〇EnemyTargetWindowにアタッチする
/// </summary>
class ChoiceTarget : MonoBehaviour
{
    private GameObject TargetEnemy;

    void OnTriggerEnter(Collider col)
    {
        //コリジョン判定かつエンターキーが押された場合
        if (Input.GetKey(KeyCode.Return))
        {
            //ターゲットを確定する
            var name = this.TargetEnemy.name;
            switch(name)
            {
                case "Target1CursorObject_EnemyTargetWindow":
                    GameManager.TargetFlg = "1";
                    break;
                case "Target2CursorObject_EnemyTargetWindow":
                    GameManager.TargetFlg = "2";
                    break;
                case "Target3CursorObject_EnemyTargetWindow":
                    GameManager.TargetFlg = "3";
                    break;
            }

            VisibleUIManage.ManageStart_BeforeCommandClick();

            switch (GameManager.CommandFlg)
            {
                case "Attack":
                    if (ComparerParameter.SpeedComparer() == true)
                    {
                        //自分のターン
                        MyTurn_NormalAttack();

                        //敵のターン
                        EnemyTurn.StartEnemyTurn();
                    }
                    else
                    {
                        //敵のターン
                        EnemyTurn.StartEnemyTurn();

                        //自分のターン
                        MyTurn_NormalAttack();
                    }
                    break;

                case "パワーショット":
                    if (ComparerParameter.SpeedComparer() == true)
                    {
                        //自分のターン
                        MyTurn_PowerShot();

                        //敵のターン
                        EnemyTurn.StartEnemyTurn();
                    }
                    else
                    {
                        //敵のターン
                        EnemyTurn.StartEnemyTurn();

                        //自分のターン
                        MyTurn_PowerShot();
                    }
                    break;
            }

            GameManager.Text_MainWindow.text = "";
            CheckTurnEnd.Setting();
        }
        else if(Input.GetKey(KeyCode.Escape))
        {
            //敵選択を閉じる
            VisibleUIManage.ManageStart_AfterCommandClick();
        }
    }

    /// <summary>
    /// 自分のターン 通常攻撃
    /// </summary>
    private void MyTurn_NormalAttack()
    {
        int intBullet = int.Parse(OperatePlayerData.GetPlayerData(GetXMLQueryKey_PlayerData.PlayerBullet()));
        string strBullet = Convert.ToString(intBullet -1);
        OperatePlayerData.SetPlayerData(strBullet, GetXMLQueryKey_PlayerData.PlayerBullet());

        var query_Player = (from x in BattleStaticValiable.xdoc.Descendants("Player")
                            select x).Single();
        var query_Enemy = (from x in BattleStaticValiable.xdoc2.Descendants("Enemy")
                           where x.Element("BattleNo").Value == GameManager.TargetFlg
                           select x).Single();
        int PlayerAttackValue = int.Parse(query_Player.Element("PlayerAttackValue_OnBattle").Value);
        int EnemyDiffenceValue = int.Parse(query_Enemy.Element("EnemyDiffenceValue").Value);

        GameManager.Text_MainWindow.text = OperatePlayerData.GetPlayerData(GetXMLQueryKey_PlayerData.PlayerName()) + "の攻撃!";

        StartCoroutine(GameManager.WaitTime_1());

        int Damage = CirculateParameter.DamageCirculate(PlayerAttackValue, EnemyDiffenceValue);
        GameManager.Text_MainWindow.text = GameManager.Text_MainWindow.text + "\n" + query_Enemy.Element("EnemyName").Value + "に" + Damage + "のダメージ！";

        StartCoroutine(GameManager.WaitTime_1());

        //攻撃結果ジャッジ
        if (ComparerParameter.JudgeDamageResult_Single_Player(Damage) == true)
        {
            ManageBattle.DeadEnemy_Single(GameManager.TargetFlg);
        }
    }

    /// <summary>
    /// 自分のターン パワーショット
    /// </summary>
    private void MyTurn_PowerShot()
    {
        int intBullet = int.Parse(OperatePlayerData.GetPlayerData(GetXMLQueryKey_PlayerData.PlayerBullet()));
        string strBullet = Convert.ToString(intBullet - 2);
        OperatePlayerData.SetPlayerData(strBullet, GetXMLQueryKey_PlayerData.PlayerBullet());

        var query_Player = (from x in BattleStaticValiable.xdoc.Descendants("Player")
                            select x).Single();
        var query_Enemy = (from x in BattleStaticValiable.xdoc2.Descendants("Enemy")
                           where x.Element("BattleNo").Value == GameManager.TargetFlg
                           select x).Single();

        int PlayerAttackValue = int.Parse(query_Player.Element("PlayerAttackValue_OnBattle").Value) *
                                int.Parse(OperatePlayerSkill.GetPlayerSkillData(GetXMLQueryKey_PlayerSkill.PlayerSkill_DamagePercent(int.Parse(GameManager.SkillNoFlg)), int.Parse(GameManager.SkillNoFlg)));
        int EnemyDiffenceValue = int.Parse(query_Enemy.Element("EnemyDiffenceValue").Value);

        GameManager.Text_MainWindow.text = OperatePlayerData.GetPlayerData(GetXMLQueryKey_PlayerData.PlayerName()) + "はパワーショットを放った!";

        int Damage = CirculateParameter.DamageCirculate(PlayerAttackValue, EnemyDiffenceValue);
        GameManager.Text_MainWindow.text = GameManager.Text_MainWindow.text + "\n" + query_Enemy.Element("EnemyName").Value + "に" + Damage + "のダメージ！";

        StartCoroutine(GameManager.WaitTime_1());

        //攻撃結果ジャッジ
        if (ComparerParameter.JudgeDamageResult_Single_Player(Damage) == true)
        {
            ManageBattle.DeadEnemy_Single(GameManager.TargetFlg);
        }
    }


}
