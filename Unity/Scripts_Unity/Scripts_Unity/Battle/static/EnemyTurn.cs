using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

static class EnemyTurn
{
    public static void StartEnemyTurn()
    {
        string EnemyFirst_BattleNo = "";
        string EnemySecond_BattleNo = "";
        string EnemyThird_BattleNo = "";
        int EnemySpeedValue1 = 0;
        int EnemySpeedValue2 = 0;
        int EnemySpeedValue3 = 0;

        //行動順を決める
        var query_CreateList = from x in BattleStaticValiable.xdoc2.Descendants("Enemy")
                               where x.Element("EnemyName").Value != ""
                               select x;
        List<string> CountList = new List<string>();
        SortedDictionary<int,string> dic = new SortedDictionary<int,string>();

        foreach (var item in query_CreateList)
        {
            CountList.Add(item.Element("EnemyName").Value);

            if(EnemySpeedValue1 == 0)
            {
                dic.Add(int.Parse(item.Element("EnemySpeedValue").Value), "EnemySpeedValue1");
                continue;
            }
            else if(EnemySpeedValue2 == 0)
            {
                dic.Add(int.Parse(item.Element("EnemySpeedValue").Value), "EnemySpeedValue2");
                continue;
            }
            else if(EnemySpeedValue3 == 0)
            {
                dic.Add(int.Parse(item.Element("EnemySpeedValue").Value), "EnemySpeedValue3");
            }
        }

        int RoopCount = 1;
        foreach(var item in CreateReversed(dic))
        {
            switch(RoopCount)
            {
                case 1:
                    EnemyFirst_BattleNo = ConvertBattleNo(item.Value);
                    break;
                case 2:
                    EnemySecond_BattleNo = ConvertBattleNo(item.Value);
                    break;
                case 3:
                    EnemyThird_BattleNo = ConvertBattleNo(item.Value);
                    break;
            }
            RoopCount++;
        }

        //順番に行動
        EnemyAttack(EnemyFirst_BattleNo);
        if(EnemySecond_BattleNo != "")
        {
            EnemyAttack(EnemySecond_BattleNo);
        }
        if(EnemyThird_BattleNo != "")
        {
            EnemyAttack(EnemyThird_BattleNo);
        }
    }

    private static void EnemyAttack(string BattleNo)
    {
        MonoBehaviour mono = new MonoBehaviour();

        var query_Enemy = (from x in BattleStaticValiable.xdoc2.Descendants("Enemy")
                           where x.Element("BattleNo").Value == BattleNo
                           select x).Single();
        var query_Player = (from x in BattleStaticValiable.xdoc.Descendants("Player")
                            select x).Single();

        int PutternNumber = UnityEngine.Random.Range(1, 100);

        //通常攻撃
        //デバッグ用---------------------------------------------------------↓
        int EnemyAttackValue = int.Parse(query_Enemy.Element("EnemyAttackValue").Value);
        int PlayerDeffenceValue = int.Parse(query_Player.Element("PlayerDiffenceValue_OnBattle").Value);

        GameManager.Text_MainWindow.text = query_Enemy.Element("EnemyName").Value + "の攻撃!";

        mono.StartCoroutine(GameManager.WaitTime_1());

        int Damage = CirculateParameter.DamageCirculate(EnemyAttackValue, PlayerDeffenceValue);

        GameManager.Text_MainWindow.text = GameManager.Text_MainWindow.text + "\n" + query_Player.Element("PlayerName").Value + "に" + Damage + "のダメージ！";

        mono.StartCoroutine(GameManager.WaitTime_1());

        if (ComparerParameter.JudgeDamageResult_Single_Enemy(Damage) == true)
        {
            ManageBattle.DeadPlayer();
            //ゲームオーバー処理
            mono.StartCoroutine(GameManager.WaitTime_5());

            SceneManager.UnloadSceneAsync("BattleScene");
        }
        //デバッグ用---------------------------------------------------------↑

        ////敵の行動を制御
        //if(1 <= PutternNumber && PutternNumber <= 10)
        //{
        //    //スキル1攻撃            
        //}
        //else if(11 <= PutternNumber && PutternNumber <= 20)
        //{
        //    //スキル2攻撃
        //}
        //else if(21 <= PutternNumber && PutternNumber <= 30)
        //{
        //    //スキル3攻撃
        //}
        //else if(31 <= PutternNumber && PutternNumber <= 100)
        //{
        //    //固有行動があれば書く
        //    switch (query_Enemy.Element("EnamyName").Value)
        //    {
        //        case "マメドローン":
        //            break;
        //        default:
        //            break;
        //    }

        //    //通常攻撃
        //    int EnemyAttackValue = int.Parse(query_Enemy.Element("EnemyAttackValue").Value);
        //    int PlayerDeffenceValue = int.Parse(query_Player.Element("PlayerDiffenceValue_OnBattle").Value);

        //    GameManager.Text_MainWindow.text = query_Enemy.Element("EnemyName").Value + "の攻撃!";

        //    int Damage = CirculateParameter.DamageCirculate(EnemyAttackValue, PlayerDeffenceValue);

        //    GameManager.Text_MainWindow.text = GameManager.Text_MainWindow.text + "\n" + query_Player.Element("PlayerName").Value + "に" + Damage + "のダメージ！";

        //    StartCoroutine(GameManager.WaitTime_1());

        //    if (ComparerParameter.JudgeDamageResult_Single_Enemy(Damage) == true)
        //    {
        //        ManageBattle.DeadPlayer();
        //    }
        //}
    }

    private static string ConvertBattleNo(string s)
    {
        string result = "";

        switch(s)
        {
            case "EnemySpeedValue1":
                result = "1";
                break;
            case "EnemySpeedValue2":
                result = "2";
                break;
            case "EnemySpeedValue3":
                result = "3";
                break;
        }

        return result;
    }

    static SortedDictionary<TKey, TValue> CreateReversed<TKey, TValue>(SortedDictionary<TKey, TValue> source)
    {
        // コレクションの内容はsourceと同じもの、並べ替え順序はsource.Comparerで
        // 定義されているものとは逆となるようなインスタンスを返す
        return new SortedDictionary<TKey, TValue>(source, new ReverseComparer<TKey>(source.Comparer));
    }
}

class ReverseComparer<T> : IComparer<T>
{
    private IComparer<T> comparer;

    public ReverseComparer(IComparer<T> comparer)
    {
        this.comparer = comparer;
    }

    public int Compare(T x, T y)
    {
        // 指定する引数の順序を逆にすることで、元になったIComparer<T>とは逆の結果を返す
        return comparer.Compare(y, x);
    }
}

