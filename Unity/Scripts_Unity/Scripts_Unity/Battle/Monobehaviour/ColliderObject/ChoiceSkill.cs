using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

/// <summary>
/// Skill〇CursorObject_SkillChooseWindowにアタッチする
/// </summary>
class ChoiceSkill : MonoBehaviour
{
    private GameObject objChoiceSkill;
    bool CanUseSkill = true;

    void OnTriggerEnter(Collider col)
    {
        //コリジョン判定かつエンターキーが押された場合
        if (Input.GetKey(KeyCode.Return))
        {
            //どのスキルオブジェクトか？
            var name = this.objChoiceSkill.name;
            switch (name)
            {
                case "Skill1CursorObject_SkillChooseWindow":
                    GameManager.SkillNoFlg = "1";
                    GameManager.CommandFlg = "パワーショット";
                    break;
                case "Skill2CursorObject_SkillChooseWindow":
                    GameManager.SkillNoFlg = "2";
                    GameManager.CommandFlg = "チャージショット";
                    break;
                case "Skill3CursorObject_SkillChooseWindow":
                    GameManager.SkillNoFlg = "3";
                    GameManager.CommandFlg = "ジャックポット";
                    break;
                case "Skill4CursorObject_SkillChooseWindow":
                    GameManager.SkillNoFlg = "4";
                    GameManager.CommandFlg = "リロード";
                    break;
                case "Skill5CursorObject_SkillChooseWindow":
                    GameManager.SkillNoFlg = "5";
                    GameManager.CommandFlg = "プラズマキャノン";
                    break;
                case "Skill6CursorObject_SkillChooseWindow":
                    GameManager.SkillNoFlg = "6";
                    GameManager.CommandFlg = "向日葵システム";
                    break;
                case "Skill7CursorObject_SkillChooseWindow":
                    GameManager.SkillNoFlg = "7";
                    GameManager.CommandFlg = "自己再生";
                    break;
                case "Skill8CursorObject_SkillChooseWindow":
                    GameManager.SkillNoFlg = "8";
                    GameManager.CommandFlg = "ユグドラシルバスター";
                    break;
            }

            //残弾数チェックで半透明になっていたらリターン
            switch(GameManager.CommandFlg)
            {
                case "1":
                    if (GameManager.TextSkill1_SkillChooseWindow.color.a == 0.25f)
                    {
                        return;
                    }
                    break;
                case "2":
                    if (GameManager.TextSkill2_SkillChooseWindow.color.a == 0.25f)
                    {
                        return;
                    }
                    break;
                case "3":
                    if (GameManager.TextSkill3_SkillChooseWindow.color.a == 0.25f)
                    {
                        return;
                    }
                    break;
                default:
                    break;
            }

            //スキルの攻撃範囲を取得し、行動パターンを分岐する
            switch (OperatePlayerSkill.GetPlayerSkillData(GetXMLQueryKey_PlayerSkill.PlayerSkill_TargetFlg(int.Parse(GameManager.SkillNoFlg)),
                                                    int.Parse(GameManager.SkillNoFlg)))
            {
                //Singleの時単体攻撃
                case "Single":
                    VisibleUIManage.ManageStart_AfterSkillCommandClick();
                    break;

                //Multipleの時全体攻撃
                case "Multiple":
                    switch (GameManager.CommandFlg)
                    {
                        case "ジャックポット":
                            if (ComparerParameter.SpeedComparer() == true)
                            {
                                //自分のターン
                                MyTurn_Juckpot();

                                //敵のターン
                                EnemyTurn.StartEnemyTurn();
                            }
                            else
                            {
                                //敵のターン
                                EnemyTurn.StartEnemyTurn();

                                MyTurn_Juckpot();
                            }
                            break;

                        default:
                            break;
                    }
                    break;

                //その他補助技など
                default:
                    switch(GameManager.CommandFlg)
                    {
                        case "リロード":
                            VisibleUIManage.ManageStart_AfterSkillClick_NonTarget();

                            if (ComparerParameter.SpeedComparer() == true)
                            {
                                //自分のターン
                                MyTurn_Reload();

                                //敵のターン
                                EnemyTurn.StartEnemyTurn();
                            }
                            else
                            {
                                //敵のターン
                                EnemyTurn.StartEnemyTurn();

                                MyTurn_Reload();
                            }
                            break;
                    }
                    break;
            }

            GameManager.Text_MainWindow.text = "";
            CheckTurnEnd.Setting();
        }
        else if (Input.GetKey(KeyCode.Escape))
        {
            VisibleUIManage.ManageStart_AfterSkillCommandClick();
        }
    }

    /// <summary>
    /// スキル「ジャックポット」使用時
    /// </summary>
    private void MyTurn_Juckpot()
    {

    }

    /// <summary>
    /// スキル「リロード」使用時
    /// </summary>
    private void MyTurn_Reload()
    {
        OperatePlayerData.SetPlayerData("5", GetXMLQueryKey_PlayerData.PlayerBullet());

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

        GameManager.Text_MainWindow.text = OperatePlayerData.GetPlayerData(GetXMLQueryKey_PlayerData.PlayerName()) + "はリロードした!\n残弾数が回復した！";

        StartCoroutine(GameManager.WaitTime_1());
    }



}

