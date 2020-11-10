using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

class DisplayExplain : MonoBehaviour
{
    private GameObject objChoiceSkill;

    void OnTriggerEnter(Collider col)
    {
        //どのスキルオブジェクトか？
        var name = this.objChoiceSkill.name;
        switch (name)
        {
            case "Skill1CursorObject_SkillChooseWindow":
                GameManager.SkillNoFlg = "1";
                break;
            case "Skill2CursorObject_SkillChooseWindow":
                GameManager.SkillNoFlg = "2";
                break;
            case "Skill3CursorObject_SkillChooseWindow":
                GameManager.SkillNoFlg = "3";
                break;
            case "Skill4CursorObject_SkillChooseWindow":
                GameManager.SkillNoFlg = "4";
                break;
            case "Skill5CursorObject_SkillChooseWindow":
                GameManager.SkillNoFlg = "5";
                break;
            case "Skill6CursorObject_SkillChooseWindow":
                GameManager.SkillNoFlg = "6";
                break;
            case "Skill7CursorObject_SkillChooseWindow":
                GameManager.SkillNoFlg = "7";
                break;
            case "Skill8CursorObject_SkillChooseWindow":
                GameManager.SkillNoFlg = "8";
                break;
        }

        GameManager.Text_ExplainWindow.text = OperatePlayerSkill.GetPlayerSkillData(GetXMLQueryKey_PlayerSkill.PlayerSkill_Explanation(int.Parse(GameManager.SkillNoFlg)),
                                                                               int.Parse(GameManager.SkillNoFlg));
    }
}
