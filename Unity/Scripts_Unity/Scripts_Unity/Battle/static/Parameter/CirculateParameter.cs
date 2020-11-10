using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// 様々な計算をするクラス
/// </summary>
static class CirculateParameter
{
    //Staticクラスはこのフォルダにいれる
    //参考→https://unitygeek.hatenablog.com/entry/2013/01/09/133319

    /// <summary>
    /// ダメージを計算する
    /// </summary>
    /// <param name="AttackValue"></param>
    /// <param name="DiffenceValue"></param>
    public static int DamageCirculate(int AttackValue,int DiffenceValue)
    {
        int result;

        var i = (AttackValue - DiffenceValue) * 1.5;

        result = (int)i;
        result = result + UnityEngine.Random.Range(0, 3);

        if(result < 0)
        {
            result = 1;
        }

        return result;

    }
}

