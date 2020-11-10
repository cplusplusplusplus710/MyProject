using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

//カメラにアタッチするプログラム
//参考:http://dlod.hatenablog.com/entry/2018/07/31/214437
class CameraController : MonoBehaviour
{
    //offsetはカメラの位置をずらす変数
    //ずれてたら値を代入してい調整
    public float offsetX;
    public float offsetY;
    public Transform targetTrans;

    void Start()
    {
        if(targetTrans == null)
        {
            //Transform変数が空の時、プレイヤーの位置情報を取得する
            //プレイヤーオブジェクトの名前を代入する(仮に"Player"とする)
            targetTrans = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

            if(targetTrans == null)
            {
                //見つからんかったらプログラム終了
                return;
            }
        }
    }

    //UpDate関数がすべて終わったあとに実行される
    void LateUpdate()
    {
        this.transform.position = new Vector3(targetTrans.position.x + offsetX,
                                              targetTrans.position.y + offsetY,
                                              -10);
    }
        
}

