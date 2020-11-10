using Sgml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WebScrapingTest
{
    class SampleScraping
    {
        //---------------------------------------------------------------------------------------
        //----------HTMlの取得
        public string GetHtml(string url)
        {
            // 指定されたURLに対してのRequestを作成します。
            var req = (HttpWebRequest)WebRequest.Create(url);

            //html取得文字列
            string html = "";

            //指定したURLに対してリクエストを投げて、レスポンスを取得する
            using (var res = (HttpWebResponse)req.GetResponse())
            using (var resSt = res.GetResponseStream())
            //取得した文字列をUTF8でエンコード
            //using (var sr = new StreamReader(resSt, Encoding.GetEncoding("shift-jis")))
            using (var sr = new StreamReader(resSt, Encoding.UTF8))
            {
                //HTMLを取得
                html = sr.ReadToEnd();
            }

            return html;
        }

        //---------------------------------------------------------------------------------------
        //----------タイトルの取得
        public string GetTitle(string html)
        {
            // 正規化表現
            // 大文字小文字区別なし       : RegexOptions.IgnoreCase
            // 「.」を改行にも適応する設定: RegexOptions.Singleline
            var reg = new Regex(@"<title>(?<title>.*?)</title>",
                          RegexOptions.IgnoreCase | RegexOptions.Singleline);
            
            //html文字列内から条件にマッチしたデータを抜き取る
            var m = reg.Match(html);

            //条件にマッチした文字列内からKey("title部分")にマッチした値を抜きとる
            return m.Groups["title"].Value;
        }

        //---------------------------------------------------------------------------------------
        //----------タイトルの取得
        public string GetTitle_test(string html)
        {
            // 正規化表現
            // 大文字小文字区別なし       : RegexOptions.IgnoreCase
            // 「.」を改行にも適応する設定: RegexOptions.Singleline
            var reg = new Regex(@"<div class=" + "\"newsFeed_item_title\"" + ">.*</div>",
                          RegexOptions.IgnoreCase | RegexOptions.Singleline);

            //<div class=\"content\">.*?<\/div>

            //html文字列内から条件にマッチしたデータを抜き取る
            var m = reg.Match(html);

            //条件にマッチした文字列内からKey("title部分")にマッチした値を抜きとる
            return m.Groups[@"div class=" + "\"newsFeed_item_title\""].Value;
        }

        public XDocument ConvertToXML(MemoryStream stream)
        {
            try
            {
                StreamReader sr = new StreamReader(stream,Encoding.UTF8);

                XDocument xml = null;

                using (SgmlReader sgml = new SgmlReader())
                {
                    sgml.IgnoreDtd = true;
                    sgml.DocType = "HTML";
                    sgml.InputStream = sr;
                    xml = XDocument.Load(sgml);
                }

                sr.Close();

                return xml;

            }
            catch(Exception ex)
            {
                throw;
            }
        }


    }
}
