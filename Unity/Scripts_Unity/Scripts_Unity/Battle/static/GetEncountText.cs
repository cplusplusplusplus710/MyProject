using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// 敵とエンカウントした時に取得するテキスト。単体限定。
/// </summary>
static class GetEncountText
{
    /// <summary>
    /// 引数に敵の名前を入れる。
    /// </summary>
    /// <param name="EnemyName"></param>
    /// <returns></returns>
    public static string EncountText(string EnemyName)
    {
        string result;

        switch(EnemyName)
        {
            case "マメドローン":
                result = "に\n見つかってしまった！";
                break;
            case "あるくカメラ":
                result = "に\nゆくてをふさがれた！";
                break;
            case "スライム":
                result = "が\nにじり寄ってきた！";
                break;
            case "ガーディアン":
                result = "が\n立ちふさがった！";
                break;
            default:
                result = "が\n襲いかかってきた！";
                break;
        }

        return result;
    }
}

