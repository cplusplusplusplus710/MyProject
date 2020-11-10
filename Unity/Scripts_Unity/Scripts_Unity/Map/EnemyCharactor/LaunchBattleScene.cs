using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//衝突時のイベント
public class LaunchBattleScene : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    //衝突時のイベント
    //バトルシーンを呼び出す
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("接触しました。イベント開始。");
        UnityEngine.SceneManagement.SceneManager.LoadScene("BattleScene");
    }
}

