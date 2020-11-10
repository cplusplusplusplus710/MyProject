using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using UnityEditor;
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
    public static GameObject Background;

    /// <summary>
    /// MainWindowオブジェクトを取得
    /// </summary>
    public static Transform MainWindow;

    /// <summary>
    /// CommandWindowオブジェクトを取得
    /// </summary>
    public static Transform CommandWindow;

    /// <summary>
    /// SkillChooseWindowオブジェクトを取得
    /// </summary>
    public static Transform SkillChooseWindow;

    /// <summary>
    /// Skill1CursorObject_SkillChooseWindowオブジェクトを取得
    /// </summary>
    public static Transform Skill1CursorObject_SkillChooseWindow;

    /// <summary>
    /// Skill2CursorObject_SkillChooseWindowオブジェクトを取得
    /// </summary>
    public static Transform Skill2CursorObject_SkillChooseWindow;

    /// <summary>
    /// Skill3CursorObject_SkillChooseWindowオブジェクトを取得
    /// </summary>
    public static Transform Skill3CursorObject_SkillChooseWindow;

    /// <summary>
    /// Skill4CursorObject_SkillChooseWindowオブジェクトを取得
    /// </summary>
    public static Transform Skill4CursorObject_SkillChooseWindow;

    /// <summary>
    /// Skill5CursorObject_SkillChooseWindowオブジェクトを取得
    /// </summary>
    public static Transform Skill5CursorObject_SkillChooseWindow;

    /// <summary>
    /// Skill6CursorObject_SkillChooseWindowオブジェクトを取得
    /// </summary>
    public static Transform Skill6CursorObject_SkillChooseWindow;

    /// <summary>
    /// Skill7CursorObject_SkillChooseWindowオブジェクトを取得
    /// </summary>
    public static Transform Skill7CursorObject_SkillChooseWindow;

    /// <summary>
    /// Skill8CursorObject_SkillChooseWindowオブジェクトを取得
    /// </summary>
    public static Transform Skill8CursorObject_SkillChooseWindow;

    /// <summary>
    /// ExplainWindowオブジェクトを取得
    /// </summary>
    public static Transform ExplainWindow;

    /// <summary>
    /// Text_MainWindowオブジェクトのテキストコンポーネントを取得
    /// </summary>
    public static Text Text_MainWindow;

    /// <summary>
    /// CharaName_StatusWindowオブジェクトのテキストコンポーネントを取得
    /// </summary>
    public static Text CharaName_StatusWindow;

    /// <summary>
    /// HpValueオブジェクトのテキストコンポーネントを取得
    /// </summary>
    public static Text HPValue_StatusWindow;

    /// <summary>
    /// ENValue_StatusWindowオブジェクトのテキストコンポーネントを取得
    /// </summary>
    public static Text ENValue_StatusWindow;

    /// <summary>
    /// TextSkill1_SkillChooseWindowオブジェクトのテキストコンポーネントを取得
    /// </summary>
    public static Text TextSkill1_SkillChooseWindow;

    /// <summary>
    /// TextSkill2_SkillChooseWindowオブジェクトのテキストコンポーネントを取得
    /// </summary>
    public static Text TextSkill2_SkillChooseWindow;

    /// <summary>
    /// TextSkill3_SkillChooseWindowオブジェクトのテキストコンポーネントを取得
    /// </summary>
    public static Text TextSkill3_SkillChooseWindow;

    /// <summary>
    /// TextSkill4_SkillChooseWindowオブジェクトのテキストコンポーネントを取得
    /// </summary>
    public static Text TextSkill4_SkillChooseWindow;

    /// <summary>
    /// TextSkill5_SkillChooseWindowオブジェクトのテキストコンポーネントを取得
    /// </summary>
    public static Text TextSkill5_SkillChooseWindow;

    /// <summary>
    /// TextSkill6_SkillChooseWindowオブジェクトのテキストコンポーネントを取得
    /// </summary>
    public static Text TextSkill6_SkillChooseWindow;

    /// <summary>
    /// TextSkill7_SkillChooseWindowオブジェクトのテキストコンポーネントを取得
    /// </summary>
    public static Text TextSkill7_SkillChooseWindow;

    /// <summary>
    /// TextSkill8_SkillChooseWindowオブジェクトのテキストコンポーネントを取得
    /// </summary>
    public static Text TextSkill8_SkillChooseWindow;

    /// <summary>
    /// Text_ExplainWindowオブジェクトのテキストコンポーネントを取得
    /// </summary>
    public static Text Text_ExplainWindow;

    /// <summary>
    /// CharaImage_StatusWindowオブジェクトのイメージコンポーネントを取得
    /// </summary>
    public static Image CharaImage_StatusWindow;

    /// <summary>
    /// EnemyImageオブジェクトのイメージコンポーネントを取得
    /// </summary>
    public static Image EnemyImage;

    /// <summary>
    /// Bullet1オブジェクトのイメージコンポーネントを取得
    /// </summary>
    public static Image Bullet1;

    /// <summary>
    /// Bullet2オブジェクトのイメージコンポーネントを取得
    /// </summary>
    public static Image Bullet2;

    /// <summary>
    /// Bullet3オブジェクトのイメージコンポーネントを取得
    /// </summary>
    public static Image Bullet3;

    /// <summary>
    /// Bullet4オブジェクトのイメージコンポーネントを取得
    /// </summary>
    public static Image Bullet4;

    /// <summary>
    /// Bullet5オブジェクトのイメージコンポーネントを取得
    /// </summary>
    public static Image Bullet5;

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

    /// <summary>
    /// EnemyDataのXMLオブジェクト
    /// </summary>
    public static XDocument xdoc_EnemyData;

    /// <summary>
    /// BattleSheetのXMLオブジェクト
    /// </summary>
    public static XDocument xdoc_BattleSheet;

    /// <summary>
    /// PlayerDataのXMLオブジェクト
    /// </summary>
    public static XDocument xdoc_PlayerData;

    #endregion

    /// <summary>
    /// コンストラクタ
    /// </summary>
    private GameManager()
    {
        Background = GameObject.Find("Background");
        MainWindow = Background.transform.Find("MainWindow");
        CommandWindow = Background.transform.Find("CommandWindow");
        SkillChooseWindow = Background.transform.Find("SkillChooseWindow");
        Skill1CursorObject_SkillChooseWindow = Background.transform.Find("Skill1CursorObject_SkillChooseWindow");
        Skill2CursorObject_SkillChooseWindow = Background.transform.Find("Skill2CursorObject_SkillChooseWindow");
        Skill3CursorObject_SkillChooseWindow = Background.transform.Find("Skill3CursorObject_SkillChooseWindow");
        Skill4CursorObject_SkillChooseWindow = Background.transform.Find("Skill4CursorObject_SkillChooseWindow");
        Skill5CursorObject_SkillChooseWindow = Background.transform.Find("Skill5CursorObject_SkillChooseWindow");
        Skill6CursorObject_SkillChooseWindow = Background.transform.Find("Skill6CursorObject_SkillChooseWindow");
        Skill7CursorObject_SkillChooseWindow = Background.transform.Find("Skill7CursorObject_SkillChooseWindow");
        Skill8CursorObject_SkillChooseWindow = Background.transform.Find("Skill8CursorObject_SkillChooseWindow");
        ExplainWindow = Background.transform.Find("ExplainWindow");
        Text_MainWindow = GameObject.Find("Text_MainWindow").GetComponent<Text>();
        CharaName_StatusWindow = GameObject.Find("CharaName_StatusWindow").GetComponent<Text>();
        HPValue_StatusWindow = GameObject.Find("HPValue_StatusWindow").GetComponent<Text>();
        ENValue_StatusWindow = GameObject.Find("ENValue_StatusWindow").GetComponent<Text>();
        TextSkill1_SkillChooseWindow = GameObject.Find("TextSkill1_SkillChooseWindow").GetComponent<Text>();
        TextSkill2_SkillChooseWindow = GameObject.Find("TextSkill2_SkillChooseWindow").GetComponent<Text>();
        TextSkill3_SkillChooseWindow = GameObject.Find("TextSkill3_SkillChooseWindow").GetComponent<Text>();
        TextSkill4_SkillChooseWindow = GameObject.Find("TextSkill4_SkillChooseWindow").GetComponent<Text>();
        TextSkill5_SkillChooseWindow = GameObject.Find("TextSkill5_SkillChooseWindow").GetComponent<Text>();
        TextSkill6_SkillChooseWindow = GameObject.Find("TextSkill6_SkillChooseWindow").GetComponent<Text>();
        TextSkill7_SkillChooseWindow = GameObject.Find("TextSkill7_SkillChooseWindow").GetComponent<Text>();
        TextSkill8_SkillChooseWindow = GameObject.Find("TextSkill8_SkillChooseWindow").GetComponent<Text>();
        Text_ExplainWindow = GameObject.Find("Text_ExplainWindow").GetComponent<Text>();
        CharaImage_StatusWindow = GameObject.Find("CharaImage_StatusWindow").GetComponent<Image>();
        EnemyImage = GameObject.Find("EnemyImage1").GetComponent<Image>();
        Bullet1 = GameObject.Find("Bullet1").GetComponent<Image>();
        Bullet2 = GameObject.Find("Bullet2").GetComponent<Image>();
        Bullet3 = GameObject.Find("Bullet3").GetComponent<Image>();
        Bullet4 = GameObject.Find("Bullet4").GetComponent<Image>();
        Bullet5 = GameObject.Find("Bullet5").GetComponent<Image>();

        xdoc_EnemyData = XDocument.Load(GetXMLPath.GetXMLPath_EnemyData());
        xdoc_BattleSheet = XDocument.Load(GetXMLPath.GetXMLPath_BattleEnemyDataSheet());
        xdoc_PlayerData = XDocument.Load(GetXMLPath.GetXMLPath_PlayerData());
    }

}

