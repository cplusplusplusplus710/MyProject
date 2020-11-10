using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ターンエンド処理
/// </summary>
static class CheckTurnEnd
{
    public static void Setting()
    {
        Texture2D texture_BulletIcon = Resources.Load("BulletIcon") as Texture2D;
        Texture2D texture_BulletIcon_NoImage = Resources.Load("NoImage") as Texture2D;

        //バレットアイコン初期化
        GameManager.Bullet1.sprite = Sprite.Create(texture_BulletIcon_NoImage,
                                       new Rect(0, 0, texture_BulletIcon.width, texture_BulletIcon.height),
                                       Vector2.zero);
        GameManager.Bullet2.sprite = Sprite.Create(texture_BulletIcon_NoImage,
                                       new Rect(0, 0, texture_BulletIcon.width, texture_BulletIcon.height),
                                       Vector2.zero);
        GameManager.Bullet3.sprite = Sprite.Create(texture_BulletIcon_NoImage,
                                       new Rect(0, 0, texture_BulletIcon.width, texture_BulletIcon.height),
                                       Vector2.zero);
        GameManager.Bullet4.sprite = Sprite.Create(texture_BulletIcon_NoImage,
                                       new Rect(0, 0, texture_BulletIcon.width, texture_BulletIcon.height),
                                       Vector2.zero);
        GameManager.Bullet5.sprite = Sprite.Create(texture_BulletIcon_NoImage,
                                       new Rect(0, 0, texture_BulletIcon.width, texture_BulletIcon.height),
                                       Vector2.zero);

        //残り弾数を問い合わせて、値によって処理変更
        switch(int.Parse(OperatePlayerData.GetPlayerData(GetXMLQueryKey_PlayerData.PlayerBullet())))
        {
            case 0:
                OperatePlayerData.SetPlayerData("1", GetXMLQueryKey_PlayerData.PlayerBullet());
                GameManager.Bullet1.sprite = Sprite.Create(texture_BulletIcon,
                                                           new Rect(0, 0, texture_BulletIcon.width, texture_BulletIcon.height),
                                                           Vector2.zero);
                break;
            case 1:
                OperatePlayerData.SetPlayerData("2", GetXMLQueryKey_PlayerData.PlayerBullet());
                GameManager.Bullet1.sprite = Sprite.Create(texture_BulletIcon,
                                                           new Rect(0, 0, texture_BulletIcon.width, texture_BulletIcon.height),
                                                           Vector2.zero);
                GameManager.Bullet2.sprite = Sprite.Create(texture_BulletIcon,
                                                           new Rect(0, 0, texture_BulletIcon.width, texture_BulletIcon.height),
                                                           Vector2.zero);
                break;
            case 2:
                OperatePlayerData.SetPlayerData("3", GetXMLQueryKey_PlayerData.PlayerBullet());
                GameManager.Bullet1.sprite = Sprite.Create(texture_BulletIcon,
                                                           new Rect(0, 0, texture_BulletIcon.width, texture_BulletIcon.height),
                                                           Vector2.zero);
                GameManager.Bullet2.sprite = Sprite.Create(texture_BulletIcon,
                                                           new Rect(0, 0, texture_BulletIcon.width, texture_BulletIcon.height),
                                                           Vector2.zero);
                GameManager.Bullet3.sprite = Sprite.Create(texture_BulletIcon,
                                                           new Rect(0, 0, texture_BulletIcon.width, texture_BulletIcon.height),
                                                           Vector2.zero);
                break;
            case 3:
                OperatePlayerData.SetPlayerData("4", GetXMLQueryKey_PlayerData.PlayerBullet());
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
                break;
            case 4:
                OperatePlayerData.SetPlayerData("5", GetXMLQueryKey_PlayerData.PlayerBullet());
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
                GameManager.Bullet5.sprite = Sprite.Create(texture_BulletIcon_NoImage,
                                                           new Rect(0, 0, texture_BulletIcon.width, texture_BulletIcon.height),
                                                           Vector2.zero);
                break;
            case 5:
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
                GameManager.Bullet5.sprite = Sprite.Create(texture_BulletIcon_NoImage,
                                                           new Rect(0, 0, texture_BulletIcon.width, texture_BulletIcon.height),
                                                           Vector2.zero);
                break;
        }

        GameManager.Text_MainWindow.text = "";
        VisibleUIManage.ManageStart_EndBattleStartClass();
    }
}

