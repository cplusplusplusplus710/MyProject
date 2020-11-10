using UnityEngine;
using System.Collections;
using System.Xml.Linq;
using System.Linq;
using UnityEngine.UI;
using System.Collections.Generic;

//攻撃ボタンを押す
public class Command_Attack_OnClick : MonoBehaviour
{
    GameObject AttackButton_Image;
    bool CanAttack;

    void Start()
    {
        BulletCheck_TurnStart();
    }

    void OnTriggerEnter(Collider col)
    {
        //コリジョン判定かつエンターキーが押された場合
        if (Input.GetKey(KeyCode.Return))
        {
            if (CanAttack == false)
            {
                return;
            }

            //コマンドウィンドウを閉じてメインウインドウを表示する
            VisibleUIManage.CloseCommand_OpenMain();

            GameManager.CommandFlg = "Attack";

            Battle battle = new Battle();
            battle.TurnStart();
        }
    }

    /// <summary>
    /// ターン開始時に残弾数をチェック
    /// </summary>
    private void BulletCheck_TurnStart()
    {
        CanAttack = true;

        var Query_BulletCheck = (from x in GameManager.xdoc_PlayerData.Descendants("Player")
                                 select x).Single();
        string BulletCount = Query_BulletCheck.Element("PlayerBullet").Value;

        if (BulletCount == "0")
        {
            AttackButton_Image.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 0.25f);
            CanAttack = false;
        }
        else
        {
            AttackButton_Image.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            CanAttack = true;
        }
    }

}