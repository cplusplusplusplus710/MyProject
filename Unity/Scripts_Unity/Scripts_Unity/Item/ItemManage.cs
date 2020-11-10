using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using UnityEngine;

/// <summary>
/// アイテムを管理する
/// </summary>
class ItemManage : MonoBehaviour
{
    XDocument xdoc = XDocument.Load(GetXmlPath.ItemManagerPath());

    void Start()
    {

    }

    void UpDate()
    {

    }

    /// <summary>
    /// 所持アイテムをチェックしメンテナンスする。
    /// </summary>
    private void CheckItemManagerXML()
    {
        //何を持っているかをチェック
        var query = (from x in xdoc.Descendants("HaveManage")
                     select x).Single();

        if (int.Parse(query.Attribute("Have").Value) == 0)
        {
            //何も持っていないなら終了
            ResetXML.ResetItemManage();
            return;
        }

        //持ってるもののIDを取得
        var query2 = from y in xdoc.Descendants("HaveID")
                     select y;

        //配列をつくる
        //ItemDicには(持っているアイテムID(key),個数(Value))を入れる
        Dictionary<int, int> ItemDic = new Dictionary<int, int>();
        int RoopCount = 0;
        string CheckValue = "";
        foreach (var item in query2)
        {
            if ((int)item.Attribute("No") >= 1)
            {
                //重複チェックして、重複があれば個数を合算
                bool NextRoopFlg = false;
                CheckValue = item.Value;

                if (RoopCount >= 1)
                {
                    foreach (var item2 in ItemDic)
                    {
                        if (item2.Key == int.Parse(CheckValue))
                        {
                            ItemDic[item2.Key] = ItemDic[item2.Key] + int.Parse(item.Attribute("Have").Value);
                            NextRoopFlg = true;
                            break;
                        }
                    }
                }

                RoopCount++;

                if (NextRoopFlg == true)
                {
                    continue;
                }

                //個数が0になったらDictionaryに登録しない
                if(int.Parse(item.Attribute("Have").Value) == 0)
                {
                    continue;
                }

                ItemDic.Add(int.Parse(item.Value), //アイテムID
                            int.Parse(item.Attribute("Have").Value));//個数

            }
        }

        //Key(アイテムIDでソート)
        var ItemDicSorted = ItemDic.OrderBy(x => x.Key);

        //Keyだけを抜き出したリストを作る
        List<int> IntList = new List<int>();
        foreach (var item in ItemDicSorted)
        {
            IntList.Add(item.Key);
        }

        //ItemManageを初期化する
        ResetXML.ResetItemManage();

        //ソートした配列をもとに再書き込みする
        int i = 1;
        int j = 0;
        while (true)
        {

            XDocument xdoc3 = XDocument.Load(GetXmlPath.ItemManagerPath());

            var WriteXml = new XElement("HaveID", "",
                            new XAttribute("No", Convert.ToString(i)),
                            new XAttribute("Have", ""));
            xdoc3.Root.Element("HaveManage").Add(WriteXml);
            xdoc3.Save(GetXmlPath.ItemManagerPath());

            var query3 = from x in xdoc3.Descendants("HaveID")
                         where x.Attribute("No").Value == Convert.ToString(i)
                         select x;

            foreach (var item in query3)
            {
                if(ItemDic[IntList[j]] >= 99)
                {
                    item.Attribute("Have").Value = Convert.ToString(99);
                }
                else
                {
                    item.Attribute("Have").Value = Convert.ToString(ItemDic[IntList[j]]);
                }
                item.Value = Convert.ToString(IntList[j]);
                xdoc3.Save(GetXmlPath.ItemManagerPath());
            }

            var queryHaveManage = (from x in xdoc3.Descendants("HaveManage")
                                   select x).Single();

            queryHaveManage.Attribute("Have").Value = Convert.ToString(i);
            xdoc3.Save(GetXmlPath.ItemManagerPath());

            if (j == IntList.Count - 1)
            {
                break;
            }

            i++;
            j++;
        }

        //書き込んだ内容をもとにインベントリを生成する
        int k = 1;
        int l = 0;

        while (true)
        {
            XDocument xdoc4 = XDocument.Load(GetXmlPath.ItemManagerPath());

            var WriteXml = new XElement("Inventory",
                            new XAttribute("ID", Convert.ToString(k)),
                           new XElement("Name", ""),
                           new XElement("Message", ""),
                           new XElement("RecoveryPoint", ""),
                           new XElement("PowerUPPercent", ""),
                           new XElement("EXInt", ""),
                           new XElement("UseInField", ""),
                           new XElement("UseInBattle", ""),
                           new XElement("CanTrush", ""));
            xdoc4.Root.Add(WriteXml);
            xdoc4.Save(GetXmlPath.ItemManagerPath());

            var query4 = (from x in xdoc4.Descendants("Inventory")
                          where x.Attribute("ID").Value == Convert.ToString(k)
                          select x).Single();

            query4.Element("Name").Value = OperateItemData.GetItemData("Name", IntList[l]);
            query4.Element("Message").Value = OperateItemData.GetItemData("Message", IntList[l]);
            query4.Element("RecoveryPoint").Value = OperateItemData.GetItemData("RecoveryPoint", IntList[l]);
            query4.Element("PowerUPPercent").Value = OperateItemData.GetItemData("PowerUPPercent", IntList[l]);
            query4.Element("EXInt").Value = OperateItemData.GetItemData("EXInt", IntList[l]);
            query4.Element("UseInField").Value = OperateItemData.GetItemData("UseInField", IntList[l]);
            query4.Element("UseInBattle").Value = OperateItemData.GetItemData("UseInBattle", IntList[l]);
            query4.Element("CanTrush").Value = OperateItemData.GetItemData("CanTrush", IntList[l]);
            xdoc4.Save(GetXmlPath.ItemManagerPath());

            if (l == IntList.Count - 1)
            {
                break;
            }

            k++;
            l++;
        }

    }

    /// <summary>
    /// 持っているアイテムの種類を増やす。引数に追加したいアイテムのIDと個数を入れる。
    /// 増やしたあとは必ずチェックを実行する。
    /// </summary>
    /// <param name="ItemID"></param>
    /// <param name="Have"></param>
    private void SetItemData_GetItem(string ItemID, int Have)
    {
        var query = from x in xdoc.Descendants("HaveID")
                    select x;

        int MaxValue = 0;
        foreach (var item in query)
        {
            MaxValue = int.Parse(item.Attribute("No").Value);
        }

        var WriteXml = new XElement("HaveID", ItemID,
                        new XAttribute("No", Convert.ToString(MaxValue + 1)),
                        new XAttribute("Have", Have));
        xdoc.Root.Element("HaveManage").Add(WriteXml);
        xdoc.Save(GetXmlPath.ItemManagerPath());
    }

    /// <summary>
    /// アイテムを使用して個数を減らす。引数にアイテムの名前を入れる。
    /// </summary>
    /// <param name="ItemName"></param>
    private void SetItemData_UseItem(string ItemName)
    {
        XDocument xdoc2 = XDocument.Load(GetXmlPath.ItemDataPath());

        var query = (from x in xdoc2.Descendants("Item")
                    where x.Element(GetXMLQueryKey_ItemData.Name()).Value == ItemName
                    select x).Single();

        var GetID = query.Attribute("ID").Value;

        var query2 = (from x in xdoc.Descendants("HaveManage")
                      where x.Element("HaveID").Value == GetID
                      select x).Single();

        var i = int.Parse(query2.Element("HaveID").Attribute("Have").Value);
        query2.Element("HaveID").Attribute("Have").Value = Convert.ToString(i - 1);
        xdoc.Save(GetXmlPath.ItemManagerPath());
    }

}

