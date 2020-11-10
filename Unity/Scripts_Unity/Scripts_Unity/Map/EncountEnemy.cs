using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

class EncountEnemy : MonoBehaviour
{
    public static int intAreaLevel;

    void UpDate()
    {
        intAreaLevel = GetAreaLevel();
    }

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            Scene BattleScene = SceneManager.GetSceneByName("BattleScene");
            DontDestroyOnLoad(BattleScene);
        }
    }

    /// <summary>
    /// シーン名からエリアレベルを取得する。1桁代の時は「01」のように名づけること。
    /// </summary>
    /// <returns></returns>
    private int GetAreaLevel()
    {
        string AreaName = "";
        string strAreaLevel = "";
        int result;

        //シーン名からエリアレベルを取得する
        AreaName = SceneManager.GetActiveScene().name;
        int i;
        for (i = 0; i<AreaName.Length -1; i++)
        {
            if(i == AreaName.Length -2)
            {
                strAreaLevel = Convert.ToString(AreaName[i]);
            }
            else if(i == AreaName.Length -1)
            {
                strAreaLevel = strAreaLevel + AreaName[i];
            }
        }

        result = int.Parse(strAreaLevel);

        return result;
    }
}

