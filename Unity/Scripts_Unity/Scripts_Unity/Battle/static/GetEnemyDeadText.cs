using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// 敵とエンカウントした時に取得するテキスト。単体限定。
/// </summary>
static class GetEnemyDeadText
{
    /// <summary>
    /// 引数に敵の名前を入れる。
    /// </summary>
    /// <param name="EnemyName"></param>
    /// <returns></returns>
    public static string EnemyDeadText(string EnemyName)
    {
        string result　= "";

        switch (EnemyName)
        {
            case "マメドローン":
                result = "は\n壊れて動かなくなった！";
                break;
            case "あるくカメラ":
                result = "は\n機能を停止した！";
                break;
            case "スライム":
                result = "は\n溶けてしまった！";
                break;
            case "ガーディアン":
                result = "は\n大きな音を立てて崩れ落ちた！";
                break;
            default:
                break;
        }

        return result;
    }
}

