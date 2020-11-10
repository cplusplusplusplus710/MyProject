using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

static class VisibleUIManage
{
    /// <summary>
    /// BattleStartクラスの処理が終わったあとに実施。ターンエンド時も使用。
    /// </summary>
    public static void ManageStart_EndBattleStartClass()
    {
        GameManager.MainWindow.gameObject.SetActive(false);
        GameManager.CommandWindow.gameObject.SetActive(true);
    }

    /// <summary>
    /// コマンドを選択する前 コマンドウィンドウを閉じてターゲットウインドウを表示させる
    /// </summary>
    public static void ManageStart_BeforeCommandClick()
    {
        //各種オブジェクト取得
        GameManager.CommandWindow.gameObject.SetActive(false);
        GameManager.EnemyTargetWindow.gameObject.SetActive(true);
    }

    /// <summary>
    /// コマンドを選択した後　ターゲットウィンドウを閉じてメインウィンドウを表示させる
    /// </summary>
    public static void ManageStart_AfterCommandClick()
    {
        GameManager.EnemyTargetWindow.gameObject.SetActive(false);
        GameManager.MainWindow.gameObject.SetActive(true);
    }

    /// <summary>
    /// スキルを選択したあと　ターゲット選択をしないタイプのスキル　スキルウインドウと説明ウインドウを閉じてメインウインドウを表示させる
    /// </summary>
    public static void ManageStart_AfterSkillClick_NonTarget()
    {
        GameManager.SkillChooseWindow.gameObject.SetActive(false);
        GameManager.ExplainWindow.gameObject.SetActive(false);
        GameManager.MainWindow.gameObject.SetActive(true);
    }

    /// <summary>
    /// スキル選択をキャンセル　スキルウィンドウと説明ウインドウを閉じてコマンドウィンドウを表示させる
    /// </summary>
    public static void ManageStart_ChoiceSkillCancel()
    {
        GameManager.CommandWindow.gameObject.SetActive(true);
        GameManager.SkillChooseWindow.gameObject.SetActive(false);
        GameManager.ExplainWindow.gameObject.SetActive(false);
        GameManager.SkillNoFlg = "";
    }

    /// <summary>
    /// スキルコマンドを押した時　コマンドウィンドウを閉じてスキルウインドウと説明ウインドウを表示させる
    /// </summary>
    public static void ManageStart_BeforeSkillCommandClick()
    {
        //各種オブジェクト取得
        GameManager.CommandWindow.gameObject.SetActive(false);
        GameManager.SkillChooseWindow.gameObject.SetActive(true);
        GameManager.ExplainWindow.gameObject.SetActive(true);
    }

    /// <summary>
    /// スキルを押した時　スキルウィンドウと説明ウインドウを閉じてターゲットウインドウを表示させる
    /// </summary>
    public static void ManageStart_AfterSkillCommandClick()
    {
        //各種オブジェクト取得
        GameManager.SkillChooseWindow.gameObject.SetActive(false);
        GameManager.ExplainWindow.gameObject.SetActive(false);
        GameManager.EnemyTargetWindow.gameObject.SetActive(true);
    }

    public static void ManageStart_ChoiseTargetEnemy_1()
    {
        //位置調整する

        GameManager.Target1CursorObject_EnemyTargetWindow.gameObject.SetActive(true);
    }

    public static void ManageStart_ChoiseTargetEnemy_2()
    {
        //位置調整する

        GameManager.Target1CursorObject_EnemyTargetWindow.gameObject.SetActive(true);
        GameManager.Target2CursorObject_EnemyTargetWindow.gameObject.SetActive(true);
    }

    public static void ManageStart_ChoiseTargetEnemy_3()
    {
        //位置調整する

        GameManager.Target1CursorObject_EnemyTargetWindow.gameObject.SetActive(true);
        GameManager.Target2CursorObject_EnemyTargetWindow.gameObject.SetActive(true);
        GameManager.Target3CursorObject_EnemyTargetWindow.gameObject.SetActive(true);
    }

    public static void ManageStart_ReturnTargetEnemy_1()
    {
        //位置調整する

        GameManager.Target1CursorObject_EnemyTargetWindow.gameObject.SetActive(false);
    }

    public static void ManageStart_ReturnTargetEnemy_2()
    {
        //位置調整する

        GameManager.Target1CursorObject_EnemyTargetWindow.gameObject.SetActive(false);
        GameManager.Target2CursorObject_EnemyTargetWindow.gameObject.SetActive(false);
    }

    public static void ManageStart_ReturnTargetEnemy_3()
    {
        //位置調整する

        GameManager.Target1CursorObject_EnemyTargetWindow.gameObject.SetActive(false);
        GameManager.Target2CursorObject_EnemyTargetWindow.gameObject.SetActive(false);
        GameManager.Target3CursorObject_EnemyTargetWindow.gameObject.SetActive(false);
    }
}
