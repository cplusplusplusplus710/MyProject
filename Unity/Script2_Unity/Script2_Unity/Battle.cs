using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// バトルを実行する
/// </summary>
class Battle : MonoBehaviour
{
    private GameObject TargetEnemy;

    public void TurnStart()
    {
        EnemyTurn et = new EnemyTurn();

        switch (GameManager.CommandFlg)
        {
            case "Attack":
                if (ComparerParameter.SpeedComparer() == true)
                {
                    //自分のターン
                    MyTurn_NormalAttack();

                    //敵のターン
                    et.StartEnemyTurn();
                }
                else
                {
                    //敵のターン
                    et.StartEnemyTurn();

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
                    et.StartEnemyTurn();
                }
                else
                {
                    //敵のターン
                    et.StartEnemyTurn();

                    //自分のターン
                    MyTurn_PowerShot();
                }
                break;

            case "リロード":
                if (ComparerParameter.SpeedComparer() == true)
                {
                    //自分のターン
                    MyTurn_Reload();

                    //敵のターン
                    et.StartEnemyTurn();
                }
                else
                {
                    //敵のターン
                    et.StartEnemyTurn();

                    //自分のターン
                    MyTurn_Reload();
                }
                break;

        }

        GameManager.Text_MainWindow.text = "";
        CheckTurnEnd.Setting();
        
    }

    /// <summary>
    /// 自分のターン 通常攻撃
    /// </summary>
    private void MyTurn_NormalAttack()
    {
        int intBullet = int.Parse(OperatePlayerData.GetPlayerData("PlayerBullet"));
        string strBullet = Convert.ToString(intBullet - 1);
        OperatePlayerData.SetPlayerData(strBullet, "PlayerBullet");

        var query_Player = (from x in GameManager.xdoc_PlayerData.Descendants("Player")
                            select x).Single();
        var query_Enemy = (from x in GameManager.xdoc_BattleSheet.Descendants("Enemy")
                           where x.Element("BattleNo").Value == GameManager.TargetFlg
                           select x).Single();
        int PlayerAttackValue = int.Parse(query_Player.Element("PlayerAttackValue_OnBattle").Value);
        int EnemyDiffenceValue = int.Parse(query_Enemy.Element("EnemyDiffenceValue").Value);

        GameManager.Text_MainWindow.text = OperatePlayerData.GetPlayerData("PlayerName") + "の攻撃!";

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
        int intBullet = int.Parse(OperatePlayerData.GetPlayerData("PlayerBullet"));
        string strBullet = Convert.ToString(intBullet - 2);
        OperatePlayerData.SetPlayerData(strBullet, "PlayerBullet");

        var query_Player = (from x in GameManager.xdoc_PlayerData.Descendants("Player")
                            select x).Single();
        var query_Enemy = (from x in GameManager.xdoc_BattleSheet.Descendants("Enemy")
                           where x.Element("BattleNo").Value == GameManager.TargetFlg
                           select x).Single();

        int PlayerAttackValue = int.Parse(query_Player.Element("PlayerAttackValue_OnBattle").Value) *
                                int.Parse(OperatePlayerSkill.GetPlayerSkillData(GetXMLQueryKey_PlayerSkill.PlayerSkill_DamagePercent(int.Parse(GameManager.SkillNoFlg)), int.Parse(GameManager.SkillNoFlg)));
        int EnemyDiffenceValue = int.Parse(query_Enemy.Element("EnemyDiffenceValue").Value);

        GameManager.Text_MainWindow.text = OperatePlayerData.GetPlayerData("PlayerName") + "はパワーショットを放った!";

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
    /// スキル「リロード」使用時
    /// </summary>
    private void MyTurn_Reload()
    {
        OperatePlayerData.SetPlayerData("5", "PlayerBullet");

        Texture2D texture_BulletIcon = Resources.Load("BulletIcon") as Texture2D;
        Texture2D texture_BulletIcon_NoImage = Resources.Load("NoImage") as Texture2D;

        GameManager.Bullet1.sprite = Sprite.Create(texture_BulletIcon,
                                           new Rect(0, 0, texture_BulletIcon.width, texture_BulletIcon.height),
                                           Vector2.zero);
        GameManager.Bullet2.sprite = Sprite.Create(texture_BulletIcon,
                                                   new Rect(0, 0, texture_BulletIcon.width, texture_BulletIcon.height),
                                                   Vector2.zero);
        GameManager.Bullet3.sprite = Sprite.Create(texture_BulletIcon,
                                                   new Rect(0, 0, texture_BulletIcon.width, texture_BulletIcon.height),
                                                   Vector2.zero);
        GameManager.Bullet4.sprite = Sprite.Create(texture_BulletIcon,
                                                   new Rect(0, 0, texture_BulletIcon.width, texture_BulletIcon.height),
                                                   Vector2.zero);
        GameManager.Bullet5.sprite = Sprite.Create(texture_BulletIcon,
                                                   new Rect(0, 0, texture_BulletIcon.width, texture_BulletIcon.height),
                                                   Vector2.zero);

        GameManager.Text_MainWindow.text = OperatePlayerData.GetPlayerData("PlayerName") + "はリロードした!\n残弾数が回復した！";

        StartCoroutine(GameManager.WaitTime_1());
    }

}
