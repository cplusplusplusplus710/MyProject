using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// スキル選択画面にアタッチ。呼び出し時初期設定。
/// </summary>
class SetupSkillWindow : MonoBehaviour
{
    void Start()
    {
        var query_Player = (from x in BattleStaticValiable.xdoc.Descendants("Player")
                            select x).Single();

        //使用可能スキルを表示
        GameManager.TextSkill1_SkillChooseWindow.text = query_Player.Element("PlayerUseSkill1").Value;
        GameManager.TextSkill2_SkillChooseWindow.text = query_Player.Element("PlayerUseSkill2").Value;
        GameManager.TextSkill3_SkillChooseWindow.text = query_Player.Element("PlayerUseSkill3").Value;
        GameManager.TextSkill4_SkillChooseWindow.text = query_Player.Element("PlayerUseSkill4").Value;
        GameManager.TextSkill5_SkillChooseWindow.text = query_Player.Element("PlayerUseSkill5").Value;
        GameManager.TextSkill6_SkillChooseWindow.text = query_Player.Element("PlayerUseSkill6").Value;
        GameManager.TextSkill7_SkillChooseWindow.text = query_Player.Element("PlayerUseSkill7").Value;
        GameManager.TextSkill8_SkillChooseWindow.text = query_PlayeAr.Element("PlayerUseSkill8").Value;

        //覚えてないスキルはオブジェクトのアクティブをfalseにする
        if (query_Player.Element("PlayerUseSkill1").Value == "")
        {
            GameManager.Skill1CursorObject_SkillChooseWindow.gameObject.SetActive(false);
            BulletCheck_UseSkill(1);
        }
        else
        {
            GameManager.Skill1CursorObject_SkillChooseWindow.gameObject.SetActive(true);
        }

        if (query_Player.Element("PlayerUseSkill2").Value == "")
        {
            GameManager.Skill2CursorObject_SkillChooseWindow.gameObject.SetActive(false);
            BulletCheck_UseSkill(2);

        }
        else
        {
            GameManager.Skill2CursorObject_SkillChooseWindow.gameObject.SetActive(true);
        }

        if (query_Player.Element("PlayerUseSkill3").Value == "")
        {
            GameManager.Skill3CursorObject_SkillChooseWindow.gameObject.SetActive(false);
            BulletCheck_UseSkill(3);

        }
        else
        {
            GameManager.Skill3CursorObject_SkillChooseWindow.gameObject.SetActive(true);
        }

        if (query_Player.Element("PlayerUseSkill4").Value == "")
        {
            GameManager.Skill4CursorObject_SkillChooseWindow.gameObject.SetActive(false);
        }
        else
        {
            GameManager.Skill4CursorObject_SkillChooseWindow.gameObject.SetActive(true);
        }

        if (query_Player.Element("PlayerUseSkill5").Value == "")
        {
            GameManager.Skill5CursorObject_SkillChooseWindow.gameObject.SetActive(false);
        }
        else
        {
            GameManager.Skill5CursorObject_SkillChooseWindow.gameObject.SetActive(true);
        }

        if (query_Player.Element("PlayerUseSkill6").Value == "")
        {
            GameManager.Skill6CursorObject_SkillChooseWindow.gameObject.SetActive(false);
        }
        else
        {
            GameManager.Skill6CursorObject_SkillChooseWindow.gameObject.SetActive(true);
        }

        if (query_Player.Element("PlayerUseSkill7").Value == "")
        {
            GameManager.Skill7CursorObject_SkillChooseWindow.gameObject.SetActive(false);
        }
        else
        {
            GameManager.Skill7CursorObject_SkillChooseWindow.gameObject.SetActive(true);
        }

        if (query_Player.Element("PlayerUseSkill8").Value == "")
        {
            GameManager.Skill8CursorObject_SkillChooseWindow.gameObject.SetActive(false);
        }
        else
        {
            GameManager.Skill8CursorObject_SkillChooseWindow.gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// 残弾数チェック
    /// </summary>
    private void BulletCheck_UseSkill(int SkillNo)
    {
        var Query_BulletCheck = (from x in BattleStaticValiable.xdoc.Descendants("Player")
                                    select x).Single();
        string BulletCount = Query_BulletCheck.Element("PlayerBullet").Value;

        //残弾数 < 消費弾数
        if (int.Parse(BulletCount) < int.Parse(OperatePlayerSkill.GetPlayerSkillData(GetXMLQueryKey_PlayerSkill
                                                .PlayerSkill_ConsumeBullet(SkillNo),
                                        int.Parse(GameManager.SkillNoFlg))))
        {
            if(SkillNo == 1)
            {
                GameManager.TextSkill1_SkillChooseWindow.color= new Color(1.0f, 1.0f, 1.0f, 0.25f);
            }
            if(SkillNo == 2)
            {
                GameManager.TextSkill2_SkillChooseWindow.color = new Color(1.0f, 1.0f, 1.0f, 0.25f);
            }
            if(SkillNo == 3)
            {
                GameManager.TextSkill3_SkillChooseWindow.color = new Color(1.0f, 1.0f, 1.0f, 0.25f);
            }
        }
        else
        {
            if (SkillNo == 1)
            {
                GameManager.TextSkill1_SkillChooseWindow.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            }
            if (SkillNo == 2)
            {
                GameManager.TextSkill2_SkillChooseWindow.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            }
            if (SkillNo == 3)
            {
                GameManager.TextSkill3_SkillChooseWindow.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            }
        }
    }

    
}

