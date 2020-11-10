using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//キャラの向き状態を変更するコントローラー
//BlenderTreeを使用すること
//参考:https://qiita.com/RyotaMurohoshi/items/86d7bc3e65da6b18d8e7

public class AnimationStateController : MonoBehaviour
{
    //***********************************************************
    //フィールド
    //***********************************************************

    //Animatorクラスのインスタンス
    Animator animator;

    //***********************************************************
    //イベントメソッド
    //***********************************************************

    void Start()
    {
        //初期化
        //コントローラーをセットしたオブジェクトに紐づいている
        //Animatorを取得する
        this.animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            //Vectorに値を入力
            Vector2? action = this.actionKeyDown();

            //キー入力があればAnimatorにStateをセット
            if (action.HasValue)
            {
                setStateToAnimator(vector: action.Value);
                return;
            }
        }

        //入力からVector2インスタンスを作成
        Vector2 vector = new Vector2((int)Input.GetAxis("Horizontal"),
                                     (int)Input.GetAxis("Vertical"));

        //キー入力が続いている場合は入力から作成したVector2を渡す
        //なければnull
        setStateToAnimator(vector: vector != Vector2.zero ?
                           vector : (Vector2?)null);
    }

    //***********************************************************
    //メソッド
    //***********************************************************

    //AnimatorにStateをセットする
    private void setStateToAnimator(Vector2? vector)
    {
        //Vectorの値がなければアニメーションをストップ
        if (!vector.HasValue)
        {
            this.animator.speed = 0.0f;

            return;
        }

        Debug.Log(vector.Value);

        //アニメーションを1フレームで再生
        this.animator.speed = 1.0f;

        //BlenderTreeのxとyにVector2の値を渡す
        this.animator.SetFloat("x", vector.Value.x);
        this.animator.SetFloat("y", vector.Value.y);

    }

    //特定のキーの入力があればキーに合わせたVector2インスタンスを返す。
    //なければNullを返す
    private Vector2? actionKeyDown()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            return Vector2.up;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            return Vector2.left;  //Unity5で追加されている
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            return Vector2.down;　//Unity5で追加されている
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            return Vector2.right;
        }

        return null;

    }

}
