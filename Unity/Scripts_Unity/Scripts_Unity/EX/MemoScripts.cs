using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Scripts_Unity
{
    class MemoScripts
    {
        //----------------------------------------------------------------------------
        //CharaMove_NotUse用フィールド

        //移動時の加算用変数
        float vx = 0;
        float vy = 0;

        //移動スピード
        public float speed = 30;

        //----------------------------------------------------------------------------

        void Update()
        {
            //----------------------------------------------------------------------------
            //CharaMove_NotUse用

            //毎フレーム数値を初期化
            vx = 0;
            vy = 0;

            //----------------------------------------------------------------------------


        }


        //***********************************************************
        //作ったけどもう使わないメソッド
        //***********************************************************

        //キャラを移動させる
        private void CharaMove_NotUse()
        {
            //横移動
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                //x軸に移動スピード減算
                vx = -speed;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                //x軸に移動スピード加算
                vx = speed;
            }

            //縦移動
            if (Input.GetKey(KeyCode.UpArrow))
            {
                //y軸に移動スピード減算
                vy = -speed;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                //y軸に移動スピード加算
                vy = speed;
            }

            //移動実行
            this.transform.Translate(vx / 50, vy / 50, 0);

        }


    }



}
