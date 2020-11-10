using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

/// <summary>
/// 高頻度で使う変数やメソッドをstatic化し、まとめたクラス
/// </summary>
static class BattleStaticValiable
{
    /// <summary>
    /// PlayerDataへのアクセス
    /// </summary>
    public static XDocument xdoc = XDocument.Load(GetXmlPath.PlayerDataPath());

    /// <summary>
    /// BattleSheetへのアクセス
    /// </summary>
    public static XDocument xdoc2 = XDocument.Load(GetXmlPath.BattleEnemyDataSheetPath());



}

