using System;
using Microsoft.VisualBasic;

public class GetTimeFunction
{

    // ------------------------------------------------------------------------------------------------
    // 日付取得
    // ------------------------------------------------------------------------------------------------
    // 第一引数はSplitするワードを指定
    public string GetDate(string SplitWord)
    {
        string TodayValue = DateTime.Now.ToString("yyyyMMdd");

        return DateEdit(TodayValue, SplitWord);
    }

    // ------------------------------------------------------------------------------------------------
    // 時間取得
    // ------------------------------------------------------------------------------------------------
    // 第一引数はSplitするワードを指定
    public string GetTime(string SplitWord)
    {
        string TimeValue = DateTime.Now.ToString("HHmmss");

        return TimeEdit(ref TimeValue, SplitWord);
    }

    // ------------------------------------------------------------------------------------------------
    // 日付編集
    // ------------------------------------------------------------------------------------------------
    public string DateEdit(string Date_Value, string SplitWord)
    {
        if (Date_Value == null)
            return "";

        // 空白文字カット
        Date_Value = Date_Value.Trim();

        if (Date_Value.Length == 0)
            return "";

        // ymd設定
        string YMD_DateEdit = "";

        // 一文字ずつヌルチェックしてYMDに入れていく
        for (int i = 0; i <= Date_Value.Length - 1; i++)
        {
            string c = Date_Value.Substring(i, 1);
            double d;

            if (double.TryParse(c, out d))
                YMD_DateEdit += c;
        }

        // 分割文字がないときはそのままリターン
        if (SplitWord == "")
            return YMD_DateEdit;

        // 8文字超えたら引数そのままリターン
        if (YMD_DateEdit.Length == 8)
            return Date_Value;

        // SplitWordを落とし込む
        string EditResult = YMD_DateEdit.Substring(0, 4) + SplitWord + YMD_DateEdit.Substring(4, 2) + SplitWord + YMD_DateEdit.Substring(6, 2);

        return EditResult;
    }

    // ------------------------------------------------------------------------------------------------
    // 時刻編集
    // ------------------------------------------------------------------------------------------------
    public string TimeEdit(ref string Time_Value, string SplitWord)
    {
        if (Time_Value == "")
            return "";

        string H_TimeEdit = Time_Value.Substring(0, 2);
        string M_TimeEdit = Time_Value.Substring(2, 2);
        string S_TimeEdit = Time_Value.Substring(4, 2);

        string EditResult = H_TimeEdit + SplitWord + M_TimeEdit + SplitWord + S_TimeEdit;

        return EditResult;
    }
}
