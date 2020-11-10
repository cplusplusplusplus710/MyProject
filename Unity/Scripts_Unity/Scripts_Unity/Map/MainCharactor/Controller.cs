using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//キャラの操作を制御するスクリプト
//ななめ移動対応
public class Controller : MonoBehaviour
{
    //***********************************************************
    //フィールド
    //***********************************************************

    //移動時の加算用変数
    float vx = 0;
    float vy = 0;

    //移動スピード
    public float speed = 30;

    //入力キー保持用のリスト
    private List<KeyCode> PushedArrowKeyList = new List<KeyCode>();

    //***********************************************************
    //イベントメソッド
    //***********************************************************

    void Start()
    {

    }

    //毎フレーム
    void Update()
    {
        //毎フレーム数値を初期化
        vx = 0;
        vy = 0;

        //キャラの移動
        CharaMove();
    }

    //***********************************************************
    //メソッド
    //***********************************************************

    //キーのリスト入れ替え関数
    //押されている時だけ配列に格納され、離されたら配列から消す
    private void KeyAddRemove(KeyCode keycode)
    {
        //キーが入力されてきた時
        if (Input.GetKey(keycode))
        {
            // Linqの機能：リストに指定した物がなければリストに加える
            if (!(PushedArrowKeyList.Contains(keycode)))
            {
                // なければ追加
                PushedArrowKeyList.Add(keycode);
            }
        }
        else
        {
            // Linqの機能：リストに指定した物があればリストから外す
            if (PushedArrowKeyList.Contains(keycode))
            {
                // あれば削除
                PushedArrowKeyList.Remove(keycode);
            }
        }
    }

    //キーチェック関数
    private void KeyCheck()
    {
        KeyAddRemove(KeyCode.LeftArrow);
        KeyAddRemove(KeyCode.RightArrow);
        KeyAddRemove(KeyCode.UpArrow);
        KeyAddRemove(KeyCode.DownArrow);
    }

    //キャラ移動
    private void CharaMove()
    {
        //キーチェックする
        //入力されてきたキーの値をもとに、Listの操作をする
        KeyCheck();

        //プレイヤーを動かす
        PlayerMove();

    }

    //プレイヤーを動かす
    private void PlayerMove()
    {
        //キーのリストに何か入っている時
        if(PushedArrowKeyList.Count > 0)
        {
            //最初に押されているキーの方向へ移動
            //if分岐は斜め移動の処理
            switch(PushedArrowKeyList[0]) //0番目の要素→一番最初
            {
                //---------------------------
                case KeyCode.LeftArrow:
                    vx = -speed;

                    //キー配列が2つ以上リストに格納されている場合
                    if(PushedArrowKeyList.Count >= 2)
                    {
                        if (PushedArrowKeyList[1] == KeyCode.UpArrow)
                        {//↑キーが同時に押されている場合
                            vy = speed;
                        }
                        else if (PushedArrowKeyList[1] == KeyCode.DownArrow) //↓キーが同時に押されている場合
                        {
                            vy = -speed;
                        }
                    }

                    break;
                //---------------------------
                case KeyCode.RightArrow:
                    vx = speed;

                    // キー配列が2つ以上リストに格納されている場合
                    if (PushedArrowKeyList.Count >= 2)
                    {
                        if (PushedArrowKeyList[1] == KeyCode.UpArrow)
                        {
                            vy = speed;
                        }
                        else if (PushedArrowKeyList[1] == KeyCode.DownArrow)
                        {
                            vy = -speed;
                        }
                    }

                    break;
                //---------------------------
                case KeyCode.UpArrow:
                    vy = speed;

                    // キー配列が2つ以上リストに格納されている場合
                    if (PushedArrowKeyList.Count >= 2)
                    {
                        if (PushedArrowKeyList[1] == KeyCode.LeftArrow)
                        {
                            vx = -speed;
                        }
                        else if (PushedArrowKeyList[1] == KeyCode.RightArrow)
                        {
                            vx = speed;
                        }
                    }

                    break;
                //---------------------------
                case KeyCode.DownArrow:
                    vy = -speed;

                    // キー配列が2つ以上リストに格納されている場合
                    if (PushedArrowKeyList.Count >= 2)
                    {
                        if (PushedArrowKeyList[1] == KeyCode.LeftArrow)
                        {
                            vx = -speed;
                        }
                        else if (PushedArrowKeyList[1] == KeyCode.RightArrow)
                        {
                            vx = speed;
                        }
                    }

                    break;
                //---------------------------
                default:
                    break;

            }

            //移動実行
            this.transform.Translate(vx / 50, vy / 50, 0);

        }
    }


}
