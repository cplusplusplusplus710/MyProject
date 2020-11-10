using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// staticに使うフラグやオブジェクト関連変数をまとめたクラス
/// </summary>
class GameManager : MonoBehaviour
{
    #region staticフィールド

    /// <summary>
    /// 敵ターゲットフラグ
    /// </summary>
    public static string TargetFlg;

    /// <summary>
    /// 戦闘コマンドフラグ
    /// </summary>
    public static string CommandFlg;

    /// <summary>
    /// 使用スキルNoフラグ
    /// </summary>
    public static string SkillNoFlg;

    /// <summary>
    /// Backgoroundオブジェクトを取得
    /// </summary>
    public static GameObject Background = GameObject.Find("Background");

    /// <summary>
    /// MainWindowオブジェクトを取得
    /// </summary>
    public static Transform MainWindow = Background.transform.Find("MainWindow");

    /// <summary>
    /// CommandWindowオブジェクトを取得
    /// </summary>
    public static Transform CommandWindow = Background.transform.Find("CommandWindow");

    /// <summary>
    /// EnemyTargetWindowオブジェクトを取得
    /// </summary>
    public static Transform EnemyTargetWindow = Background.transform.Find("EnemyTargetWindow");

    /// <summary>
    /// Target1CursorObject_EnemyTargetWindowオブジェクトを取得
    /// </summary>
    public static Transform Target1CursorObject_EnemyTargetWindow = Background.transform.Find("Target1CursorObject_EnemyTargetWindow");

    /// <summary>
    /// Target2CursorObject_EnemyTargetWindowオブジェクトを取得
    /// </summary>
    public static Transform Target2CursorObject_EnemyTargetWindow = Background.transform.Find("Target2CursorObject_EnemyTargetWindow");

    /// <summary>
    /// Target3CursorObject_EnemyTargetWindowオブジェクトを取得
    /// </summary>
    public static Transform Target3CursorObject_EnemyTargetWindow = Background.transform.Find("Target3CursorObject_EnemyTargetWindow");

    /// <summary>
    /// SkillChooseWindowオブジェクトを取得
    /// </summary>
    public static Transform SkillChooseWindow = Background.transform.Find("SkillChooseWindow");

    /// <summary>
    /// Skill1CursorObject_SkillChooseWindowオブジェクトを取得
    /// </summary>
    public static Transform Skill1CursorObject_SkillChooseWindow = Background.transform.Find("Skill1CursorObject_SkillChooseWindow");

    /// <summary>
    /// Skill2CursorObject_SkillChooseWindowオブジェクトを取得
    /// </summary>
    public static Transform Skill2CursorObject_SkillChooseWindow = Background.transform.Find("Skill2CursorObject_SkillChooseWindow");

    /// <summary>
    /// Skill3CursorObject_SkillChooseWindowオブジェクトを取得
    /// </summary>
    public static Transform Skill3CursorObject_SkillChooseWindow = Background.transform.Find("Skill3CursorObject_SkillChooseWindow");

    /// <summary>
    /// Skill4CursorObject_SkillChooseWindowオブジェクトを取得
    /// </summary>
    public static Transform Skill4CursorObject_SkillChooseWindow = Background.transform.Find("Skill4CursorObject_SkillChooseWindow");

    /// <summary>
    /// Skill5CursorObject_SkillChooseWindowオブジェクトを取得
    /// </summary>
    public static Transform Skill5CursorObject_SkillChooseWindow = Background.transform.Find("Skill5CursorObject_SkillChooseWindow");

    /// <summary>
    /// Skill6CursorObject_SkillChooseWindowオブジェクトを取得
    /// </summary>
    public static Transform Skill6CursorObject_SkillChooseWindow = Background.transform.Find("Skill6CursorObject_SkillChooseWindow");

    /// <summary>
    /// Skill7CursorObject_SkillChooseWindowオブジェクトを取得
    /// </summary>
    public static Transform Skill7CursorObject_SkillChooseWindow = Background.transform.Find("Skill7CursorObject_SkillChooseWindow");

    /// <summary>
    /// Skill8CursorObject_SkillChooseWindowオブジェクトを取得
    /// </summary>
    public static Transform Skill8CursorObject_SkillChooseWindow = Background.transform.Find("Skill8CursorObject_SkillChooseWindow");

    /// <summary>
    /// ExplainWindowオブジェクトを取得
    /// </summary>
    public static Transform ExplainWindow = Background.transform.Find("ExplainWindow");

    /// <summary>
    /// Text_MainWindowオブジェクトのテキストコンポーネントを取得
    /// </summary>
    public static Text Text_MainWindow = GameObject.Find("Text_MainWindow").GetComponent<Text>();

    /// <summary>
    /// CharaName_StatusWindowオブジェクトのテキストコンポーネントを取得
    /// </summary>
    public static Text CharaName_StatusWindow = GameObject.Find("CharaName_StatusWindow").GetComponent<Text>();

    /// <summary>
    /// HpValueオブジェクトのテキストコンポーネントを取得
    /// </summary>
    public static Text HPValue_StatusWindow = GameObject.Find("HPValue_StatusWindow").GetComponent<Text>();

    /// <summary>
    /// ENValue_StatusWindowオブジェクトのテキストコンポーネントを取得
    /// </summary>
    public static Text ENValue_StatusWindow = GameObject.Find("ENValue_StatusWindow").GetComponent<Text>();

    /// <summary>
    /// TextTarget1_EnemyTargetWindowオブジェクトのテキストコンポーネントを取得
    /// </summary>
    public static Text TextTarget1_EnemyTargetWindow = GameObject.Find("TextTarget1_EnemyTargetWindow").GetComponent<Text>();

    /// <summary>
    /// TextTarget2_EnemyTargetWindowオブジェクトのテキストコンポーネントを取得
    /// </summary>
    public static Text TextTarget2_EnemyTargetWindow = GameObject.Find("TextTarget2_EnemyTargetWindow").GetComponent<Text>();

    /// <summary>
    /// TextTarget3_EnemyTargetWindowオブジェクトのテキストコンポーネントを取得
    /// </summary>
    public static Text TextTarget3_EnemyTargetWindow = GameObject.Find("TextTarget3_EnemyTargetWindow").GetComponent<Text>();

    /// <summary>
    /// TextSkill1_SkillChooseWindowオブジェクトのテキストコンポーネントを取得
    /// </summary>
    public static Text TextSkill1_SkillChooseWindow = GameObject.Find("TextSkill1_SkillChooseWindow").GetComponent<Text>();

    /// <summary>
    /// TextSkill2_SkillChooseWindowオブジェクトのテキストコンポーネントを取得
    /// </summary>
    public static Text TextSkill2_SkillChooseWindow = GameObject.Find("TextSkill2_SkillChooseWindow").GetComponent<Text>();

    /// <summary>
    /// TextSkill3_SkillChooseWindowオブジェクトのテキストコンポーネントを取得
    /// </summary>
    public static Text TextSkill3_SkillChooseWindow = GameObject.Find("TextSkill3_SkillChooseWindow").GetComponent<Text>();

    /// <summary>
    /// TextSkill4_SkillChooseWindowオブジェクトのテキストコンポーネントを取得
    /// </summary>
    public static Text TextSkill4_SkillChooseWindow = GameObject.Find("TextSkill4_SkillChooseWindow").GetComponent<Text>();

    /// <summary>
    /// TextSkill5_SkillChooseWindowオブジェクトのテキストコンポーネントを取得
    /// </summary>
    public static Text TextSkill5_SkillChooseWindow = GameObject.Find("TextSkill5_SkillChooseWindow").GetComponent<Text>();

    /// <summary>
    /// TextSkill6_SkillChooseWindowオブジェクトのテキストコンポーネントを取得
    /// </summary>
    public static Text TextSkill6_SkillChooseWindow = GameObject.Find("TextSkill6_SkillChooseWindow").GetComponent<Text>();

    /// <summary>
    /// TextSkill7_SkillChooseWindowオブジェクトのテキストコンポーネントを取得
    /// </summary>
    public static Text TextSkill7_SkillChooseWindow = GameObject.Find("TextSkill7_SkillChooseWindow").GetComponent<Text>();

    /// <summary>
    /// TextSkill8_SkillChooseWindowオブジェクトのテキストコンポーネントを取得
    /// </summary>
    public static Text TextSkill8_SkillChooseWindow = GameObject.Find("TextSkill8_SkillChooseWindow").GetComponent<Text>();

    /// <summary>
    /// Text_ExplainWindowオブジェクトのテキストコンポーネントを取得
    /// </summary>
    public static Text Text_ExplainWindow = GameObject.Find("Text_ExplainWindow").GetComponent<Text>();

    /// <summary>
    /// CharaImage_StatusWindowオブジェクトのイメージコンポーネントを取得
    /// </summary>
    public static Image CharaImage_StatusWindow = GameObject.Find("CharaImage_StatusWindow").GetComponent<Image>();

    /// <summary>
    /// EnemyImage1オブジェクトのイメージコンポーネントを取得
    /// </summary>
    public static Image EnemyImage1 = GameObject.Find("EnemyImage1").GetComponent<Image>();

    /// <summary>
    /// EnemyImage2オブジェクトのイメージコンポーネントを取得
    /// </summary>
    public static Image EnemyImage2 = GameObject.Find("EnemyImage2").GetComponent<Image>();

    /// <summary>
    /// EnemyImage3オブジェクトのイメージコンポーネントを取得
    /// </summary>
    public static Image EnemyImage3 = GameObject.Find("EnemyImage3").GetComponent<Image>();

    /// <summary>
    /// Bullet1オブジェクトのイメージコンポーネントを取得
    /// </summary>
    public static Image Bullet1 = GameObject.Find("Bullet1").GetComponent<Image>();

    /// <summary>
    /// Bullet2オブジェクトのイメージコンポーネントを取得
    /// </summary>
    public static Image Bullet2 = GameObject.Find("Bullet2").GetComponent<Image>();

    /// <summary>
    /// Bullet3オブジェクトのイメージコンポーネントを取得
    /// </summary>
    public static Image Bullet3 = GameObject.Find("Bullet3").GetComponent<Image>();

    /// <summary>
    /// Bullet4オブジェクトのイメージコンポーネントを取得
    /// </summary>
    public static Image Bullet4 = GameObject.Find("Bullet4").GetComponent<Image>();

    /// <summary>
    /// Bullet5オブジェクトのイメージコンポーネントを取得
    /// </summary>
    public static Image Bullet5 = GameObject.Find("Bullet5").GetComponent<Image>();

    /// <summary>
    /// コルーチン　5秒待つ
    /// </summary>
    /// <returns></returns>
    public static IEnumerator WaitTime_5()
    {
        yield return new WaitForSeconds(5);
    }

    /// <summary>
    /// コルーチン　2秒待つ
    /// </summary>
    /// <returns></returns>
    public static IEnumerator WaitTime_2()
    {
        yield return new WaitForSeconds(2);
    }

    /// <summary>
    /// コルーチン　1秒待つ
    /// </summary>
    /// <returns></returns>
    public static IEnumerator WaitTime_1()
    {
        yield return new WaitForSeconds(1);
    }

    #endregion

    /// <summary>
    /// GameManager起動時、初期設定実行
    /// </summary>
    void Start()
    {
        LoadEnemyStatus les = new LoadEnemyStatus();
        les.LoadEnemy(EncountEnemy.intAreaLevel);
        StartUP();
        VisibleUIManage.ManageStart_EndBattleStartClass();
    }

    /// <summary>
    /// 戦闘開始処理
    /// </summary>
    private void StartUP()
    {
        Texture2D texture_Enemy1;
        Texture2D texture_Enemy2;
        Texture2D texture_Enemy3;

        //敵の情報を取得
        XDocument xdoc = XDocument.Load(GetXmlPath.BattleEnemyDataSheetPath());

        var query = from x in xdoc.Descendants("Enemy")
                    where x.Element("EnemyName").Value != ""
                    select x;
        List<string> CountList = new List<string>();

        foreach (var item in query)
        {
            CountList.Add(item.Element("EnemyName").Value);
        }

        string EnemyName1;
        string EnemyName2;
        string EnemyName3;

        switch (CountList.Count)
        {
            case 1:
                EnemyName1 = CountList[0];
                break;
            case 2:
                EnemyName1 = CountList[0];
                EnemyName2 = CountList[1];
                break;
            case 3:
                EnemyName1 = CountList[0];
                EnemyName2 = CountList[1];
                EnemyName3 = CountList[2];
                break;
            default:
                break;
        }

        //味方側の処理
        XDocument xdoc2 = XDocument.Load(GetXmlPath.PlayerDataPath());

        var query2 = (from x in xdoc2.Descendants("Player")
                      select x).Single();

        //戦闘用パラメータをセット
        query2.Element("PlayerAttackValue_OnBattle").Value = query2.Element("PlayerAttackValue").Value;
        query2.Element("PlayerDiffenceValue_OnBattle").Value = query2.Element("PlayerDiffenceValue").Value;
        query2.Element("PlayerSpeedValue_OnBattle").Value = query2.Element("PlayerSpeedValue").Value;
        xdoc2.Save(GetXmlPath.PlayerDataPath());

        //各種ウィンドウに値反映
        CharaName_StatusWindow.text = query2.Element("PlayerName").Value;
        HPValue_StatusWindow.text = query2.Element("PlayerNowHP").Value;
        ENValue_StatusWindow.text = query2.Element("PlayerNowEN").Value;

        //味方の画像を入れる
        Texture2D texture_Player_BattleImage1 = Resources.Load("Player_BattleImage1") as Texture2D;
        CharaImage_StatusWindow.sprite = Sprite.Create(texture_Player_BattleImage1,
                                                 new Rect(0, 0, texture_Player_BattleImage1.width, texture_Player_BattleImage1.height),
                                                 Vector2.zero);

        //Bulletを描写
        Texture2D texture_BulletIcon = Resources.Load("BulletIcon") as Texture2D;
        Texture2D texture_BulletIcon_NoImage = Resources.Load("NoImage") as Texture2D;
        Bullet1.sprite = Sprite.Create(texture_BulletIcon,
                                       new Rect(0, 0, texture_BulletIcon.width, texture_BulletIcon.height),
                                       Vector2.zero);
        Bullet2.sprite = Sprite.Create(texture_BulletIcon,
                                       new Rect(0, 0, texture_BulletIcon.width, texture_BulletIcon.height),
                                       Vector2.zero);
        Bullet3.sprite = Sprite.Create(texture_BulletIcon,
                                       new Rect(0, 0, texture_BulletIcon.width, texture_BulletIcon.height),
                                       Vector2.zero);
        Bullet4.sprite = Sprite.Create(texture_BulletIcon_NoImage,
                                       new Rect(0, 0, texture_BulletIcon.width, texture_BulletIcon.height),
                                       Vector2.zero);
        Bullet5.sprite = Sprite.Create(texture_BulletIcon_NoImage,
                                       new Rect(0, 0, texture_BulletIcon.width, texture_BulletIcon.height),
                                       Vector2.zero);

        //敵を描写
        switch (CountList.Count)
        {
            case 1:
                texture_Enemy1 = Resources.Load(CountList[0]) as Texture2D;
                EnemyImage1.sprite = Sprite.Create(texture_Enemy1,
                                                   new Rect(0, 0, texture_Enemy1.width, texture_Enemy1.height),
                                                   Vector2.zero);
                Text_MainWindow.text = CountList[0] + GetEncountText.EncountText(CountList[0]);  //敵単体時のみ特別メッセージ
                break;
            case 2: //位置調整必須　widthとheightを変更
                texture_Enemy1 = Resources.Load(CountList[0]) as Texture2D;
                EnemyImage1.sprite = Sprite.Create(texture_Enemy1,
                                                   new Rect(0, 0, texture_Enemy1.width, texture_Enemy1.height),
                                                   Vector2.zero);
                texture_Enemy2 = Resources.Load(CountList[1]) as Texture2D;
                EnemyImage2.sprite = Sprite.Create(texture_Enemy2,
                                                   new Rect(0, 0, texture_Enemy2.width, texture_Enemy2.height),
                                                   Vector2.zero);
                Text_MainWindow.text = CountList[0] + "たちが\n襲いかかってきた！";
                break;
            case 3:
                texture_Enemy1 = Resources.Load(CountList[0]) as Texture2D;
                EnemyImage1.sprite = Sprite.Create(texture_Enemy1,
                                                   new Rect(0, 0, texture_Enemy1.width, texture_Enemy1.height),
                                                   Vector2.zero);
                texture_Enemy2 = Resources.Load(CountList[1]) as Texture2D;
                EnemyImage2.sprite = Sprite.Create(texture_Enemy2,
                                                   new Rect(0, 0, texture_Enemy2.width, texture_Enemy2.height),
                                                   Vector2.zero);
                texture_Enemy3 = Resources.Load(CountList[2]) as Texture2D;
                EnemyImage2.sprite = Sprite.Create(texture_Enemy2,
                                                   new Rect(0, 0, texture_Enemy3.width, texture_Enemy3.height),
                                                   Vector2.zero);
                Text_MainWindow.text = CountList[0] + "たちが\n襲いかかってきた！";
                break;
            default:
                break;
        }

        StartCoroutine(WaitTime_2());
        Text_MainWindow.text = "";
    }

    /// <summary>
    /// 戦闘後には変数たちを成仏させる
    /// </summary>
    //public void DestroyStatic()
    //{
    //    Destroy(GameManager)
    //}
}

