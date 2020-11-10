using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UnityEngine;
using UnityEditor;

class BattleSceneStartup : MonoBehaviour
{
    void Start()
    {
        LoadEnemyStatus les = new LoadEnemyStatus();
        les.LoadEnemy();
        StartUP();
        VisibleUIManage.CloseMain_OpenCommand();
    }

    /// <summary>
    /// 戦闘開始処理
    /// </summary>
    private void StartUP()
    {
        Texture2D texture_Enemy;

        //敵の情報を取得
        XDocument xdoc = XDocument.Load(GetXMLPath.GetXMLPath_EnemyData());

        var query = (from x in xdoc.Descendants("Enemy")
                    select x).Single();

        string EnemyName = query.Element("EnemyName").Value;

        //味方側の処理
        XDocument xdoc2 = XDocument.Load(GetXmlTextAsset.PlayerDataTextAsset().text);

        var query2 = (from x in xdoc2.Descendants("Player")
                      select x).Single();

        //味方戦闘用パラメータをセット
        query2.Element("PlayerAttackValue_OnBattle").Value = query2.Element("PlayerAttackValue").Value;
        query2.Element("PlayerDiffenceValue_OnBattle").Value = query2.Element("PlayerDiffenceValue").Value;
        query2.Element("PlayerSpeedValue_OnBattle").Value = query2.Element("PlayerSpeedValue").Value;
        xdoc2.Save(GetXMLPath.GetXMLPath_PlayerData());

        //各種ウィンドウに値反映
        GameManager.CharaName_StatusWindow.text = query2.Element("PlayerName").Value;
        GameManager.HPValue_StatusWindow.text = query2.Element("PlayerNowHP").Value;
        GameManager.ENValue_StatusWindow.text = query2.Element("PlayerNowEN").Value;

        //味方の画像を入れる
        Texture2D texture_Player_BattleImage1 = Resources.Load("Player_BattleImage") as Texture2D;
        GameManager.CharaImage_StatusWindow.sprite = Sprite.Create(texture_Player_BattleImage1,
                                                 new Rect(0, 0, texture_Player_BattleImage1.width, texture_Player_BattleImage1.height),
                                                 Vector2.zero);

        //Bulletを描写
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
        GameManager.Bullet4.sprite = Sprite.Create(texture_BulletIcon_NoImage,
                                       new Rect(0, 0, texture_BulletIcon.width, texture_BulletIcon.height),
                                       Vector2.zero);
        GameManager.Bullet5.sprite = Sprite.Create(texture_BulletIcon_NoImage,
                                       new Rect(0, 0, texture_BulletIcon.width, texture_BulletIcon.height),
                                       Vector2.zero);

        //敵を描写
        texture_Enemy = Resources.Load(EnemyName) as Texture2D;
        GameManager.EnemyImage.sprite = Sprite.Create(texture_Enemy,
                                            new Rect(0, 0, texture_Enemy.width, texture_Enemy.height),
                                            Vector2.zero);
        GameManager.Text_MainWindow.text = EnemyName + GetEncountText.EncountText(EnemyName);

        StartCoroutine(GameManager.WaitTime_2());
        GameManager.Text_MainWindow.text = "";
    }
}

