using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 戦闘中のパラメーターを比較する
/// </summary>
static class ComparerParameter
{
    /// <summary>
    /// 素早さ比較(主人公と敵)　プレイヤーが勝てばtrue
    /// </summary>
    /// <returns></returns>
    public static bool SpeedComparer()
    {
        bool result = true;

        var query = (from x in BattleStaticValiable.xdoc.Descendants("Player")
                     select x).Single();

        var EnemySpeedMaxValue = BattleStaticValiable.xdoc2.Descendants("Enemy").Elements("EnemySpeedValue")
                                                           .Select(e => int.Parse(e.Value))
                                                           .Max()
                                                           .ToString();

        if(query.Element("PlayerSpeedValue").Value == EnemySpeedMaxValue)
        {
            result = false;
        }
        else if (int.Parse(query.Element("PlayerSpeedValue").Value) > int.Parse(EnemySpeedMaxValue))
        {
            result = true;
        }
        else if (int.Parse(query.Element("PlayerSpeedValue").Value) <= int.Parse(EnemySpeedMaxValue))
        {
            result = false;
        }

        return result;
    }

    /// <summary>
    /// プレイヤー→敵の単体攻撃の結果を判定。倒したかどうか。trueで倒す。
    /// </summary>
    /// <param name="Damage"></param>
    /// <returns></returns>
    public static bool JudgeDamageResult_Single_Player(int Damage)
    {
        bool result = false;

        var query_Enemy = (from x in BattleStaticValiable.xdoc2.Descendants("Enemy")
                           where x.Element("BattleNo").Value == GameManager.TargetFlg
                           select x).Single();

        int EnemyHP = int.Parse(query_Enemy.Element("EnemyHP").Value);

        if(Damage == EnemyHP)
        {
            query_Enemy.Element("EnemyHP").Value = "0";
            BattleStaticValiable.xdoc2.Save(GetXmlPath.BattleEnemyDataSheetPath());
            result = true;
        }
        else if(Damage > EnemyHP)
        {
            query_Enemy.Element("EnemyHP").Value = "0";
            BattleStaticValiable.xdoc2.Save(GetXmlPath.BattleEnemyDataSheetPath());
            result = true;

        }
        else if(Damage < EnemyHP)
        {
            query_Enemy.Element("EnemyHP").Value = Convert.ToString(EnemyHP - Damage);
            BattleStaticValiable.xdoc2.Save(GetXmlPath.BattleEnemyDataSheetPath());
            result = false;
        }

        return result;

    }

    /// <summary>
    /// 敵→プレイヤーの単体攻撃の結果を判定。倒したかどうか。trueで負ける。
    /// </summary>
    /// <param name="Damage"></param>
    /// <returns></returns>
    public static bool JudgeDamageResult_Single_Enemy(int Damage)
    {
        bool result = false;

        int PlayerNowHP = int.Parse(OperatePlayerData.GetPlayerData(GetXMLQueryKey_PlayerData.PlayerNowHP()));

        if (Damage == PlayerNowHP)
        {
            OperatePlayerData.SetPlayerData("0", GetXMLQueryKey_PlayerData.PlayerNowHP());
            GameManager.HPValue_StatusWindow.text = "0";
            result = true;
        }
        else if (Damage > PlayerNowHP)
        {
            OperatePlayerData.SetPlayerData("0", GetXMLQueryKey_PlayerData.PlayerNowHP());
            GameManager.HPValue_StatusWindow.text = "0";
            result = true;

        }
        else if (Damage < PlayerNowHP)
        {
            OperatePlayerData.SetPlayerData(Convert.ToString(PlayerNowHP - Damage), GetXMLQueryKey_PlayerData.PlayerNowHP());
            GameManager.HPValue_StatusWindow.text = Convert.ToString(PlayerNowHP - Damage);
            result = false;
        }

        return result;

    }
}

