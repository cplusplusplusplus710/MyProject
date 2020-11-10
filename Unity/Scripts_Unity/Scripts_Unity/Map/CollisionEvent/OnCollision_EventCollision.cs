using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//衝突時のイベント
public class OnCollision_EventCollision : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    //衝突時のイベント
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("接触しました。イベント開始。");
    }
}