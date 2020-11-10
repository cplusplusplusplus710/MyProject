using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

class Command_Skill_OnClick : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        //コリジョン判定かつエンターキーが押された場合
        if (Input.GetKey(KeyCode.Return))
        {
            //コマンドウィンドウを閉じてターゲットウィンドウを表示する
            VisibleUIManage.ManageStart_BeforeCommandClick();

            GameManager.CommandFlg = "Skill";
        }
    }

}

