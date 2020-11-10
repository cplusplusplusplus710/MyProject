using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO.Compression;

namespace WebScrapingTest
{
    public partial class Form1 : Form
    {
        XDocument XmlDoc = new XDocument();
        System.Xml.XmlDocument XmlDoc2 = new System.Xml.XmlDocument();
        SampleScraping scr = new SampleScraping();
        public static HttpClient client = new HttpClient();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_start_Click(object sender, EventArgs e)
        {
            // 処理中に「取得中」とラベル表示します。
            // 予めURLのテキストボックス下に無記名のラベルを作成しておきます。
            // (Name)をlblViewにしておいてください。
            lblView.Visible = true;         // 可視化
            lblView.Text = "取得中";       // 「取得中」の文字列を表示することで処理中であることを明記します。
            lblView.BringToFront();         // Objectを最善面に移動します。
            lblView.Update();               // 表示を更新します。

            // 画面上からHTMLを取得するサイトのURLを取得します。
            string url = textBox1_URL.Text;

            // htmlを取得するメソッドを実行し、画面描画します。
            string html = scr.GetHtml(url);
            textBox1_html.Text = html;

            // 取得したHTML内からタイトルを取得します。
            string title = scr.GetTitle(html);
            textBox1_Title.Text = title;

            /*switch(comboBox1.Text)
            {
                case "テスト用メニュー":
                    break;

                //ヤフーニュース
                case "記事タイトル取得":
                    // コンストラクタ ( System.Uri 型を使用 )
                    HtmlConverter converter = new HtmlConverter(new Uri(textBox1_URL.Text));
                    // 生成された XmlDocument を取得
                    XmlDoc2 = converter.ToXmlDocument();
                    XmlDoc2.Save(System.AppDomain.CurrentDomain.BaseDirectory + "HTMLconvert.xml");
                    break;
            }*/

            // 「取得中」の文言を不可視にします。
            lblView.Visible = false;

        }

        public void GetMemoryStream(string text)
        {
            MemoryStream memoryStream;
            StringReader sr = new StringReader(text);
            byte[] byteArray = new byte[0];
            int i = 0;

            try
            {
                while(true)
                {
                    string val = sr.ReadLine();

                    if(val == null)
                    {
                        break;
                    }

                    //https://codezine.jp/article/detail/448?p=2
                    byteArray = System.Text.Encoding.GetEncoding("shift_jis").GetBytes(val);
                    memoryStream = new MemoryStream(byteArray);

                    XmlDoc = scr.ConvertToXML(memoryStream);
                    XmlDoc.Save(System.AppDomain.CurrentDomain.BaseDirectory + "Config.xml");

                    i++;
                }



            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void button1_teststart_Click(object sender, EventArgs e)
        {
            lblView.Visible = true;         // 可視化
            lblView.Text = "取得中";       // 「取得中」の文字列を表示することで処理中であることを明記します。
            lblView.BringToFront();         // Objectを最善面に移動します。
            lblView.Update();               // 表示を更新します。


            switch (comboBox1.Text)
            {
                case "テスト用メニュー":
                    break;

                //ヤフーニュース
                case "記事タイトル取得":
                    var filename = System.AppDomain.CurrentDomain.BaseDirectory + "test"; // 本当は全体パスにしています
                                                    // ファイルがなければダウンロードします
                    if (!File.Exists(filename))
                    {
                        // ダウンロードが終わるまで待ち合わせます
                        GetDownloadFile().GetAwaiter().GetResult();
                    }
                    break;
            }

            // 「取得中」の文言を不可視にします。
            lblView.Visible = false;

        }

        public async Task GetDownloadFile()
        {

            try
            {
                // まずは、スクレイピングするデータを取得します
                var response = await client.GetAsync(@"https://www.google.com/").ConfigureAwait(false);
                var sorce = await response.Content.ReadAsStringAsync();

                // パースします
                var doc = default(IHtmlDocument);
                var parser = new HtmlParser();
                doc = await parser.ParseDocumentAsync(sorce);    // ここが変わっています!!

                // 取得したいURLデータを探します
                // 今回取得したいデータは、同一のselectorの最後のデータでしたので、
                // .Last()で取得しています
                // .Select()とかで取得したほうがいいこともあると思います
                var url = @"https://www.google.com/" + doc.QuerySelectorAll(@"#hplogo").First().GetAttribute("src");

                // ファイルをダウンロードします
                // 今回取得したURLはhttps://xxx から始まるURLなのでそのまま使用しています
                WebClient webClient = new WebClient();
                webClient.DownloadFile(url, System.AppDomain.CurrentDomain.BaseDirectory + "test.jpg");

                // ZIPファイルを解凍します
                //ZipFile.ExtractToDirectory(System.AppDomain.CurrentDomain.BaseDirectory + "test.zip", System.AppDomain.CurrentDomain.BaseDirectory);
            }
            catch (Exception e)
            {
                // エラー処理
            }
        }
    }
}
