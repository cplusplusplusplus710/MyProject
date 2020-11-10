using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//衝突継続時のイベント
public class OnCollisionStay_EventCollision : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    //衝突継続時のイベント
    private void OnCollisionStay(Collision2D other)
    {
        Debug.Log("接触継続中。イベント開始。");
    }
}