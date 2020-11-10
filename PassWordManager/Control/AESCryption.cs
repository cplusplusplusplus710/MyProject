using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PassWordManager
{
    class AESCryption
    {
        private const string AES_IV = @"pf69DL6GrWFyZcMK";
        private const string AES_Key = @"9Fix4L4HB4PKeKWY";

        //フィールド
        LogFunction LF;
        private CreateXML createConfigXML = new CreateXML();
        private XDocument XmlDoc;

        //------------------------------------------------------------------------------------------------
        //AESのセット
        //------------------------------------------------------------------------------------------------
        public void SetAES()
        {
            XElement query;

            XmlDoc = new XDocument();
            XmlDoc = XDocument.Load(createConfigXML.CurrentPath(), LoadOptions.PreserveWhitespace);

            //Xmlファイルに書き込み
            for (int i = 0; i < XmlDoc.Descendants("Data").Count(); i++)
            {
                query = (from y in XmlDoc.Descendants("Data")
                         where y.Attribute("ID").Value == Convert.ToString(i + 1)
                         select y).Single();
                try
                {
                    query.Element("ServiceName").Value = Encrypt(query.Element("ServiceName").Value,AES_IV,AES_Key);
                    query.Element("ID").Value = Encrypt(query.Element("ID").Value, AES_IV, AES_Key);
                    query.Element("PassWord").Value = Encrypt(query.Element("PassWord").Value, AES_IV, AES_Key);
                    XmlDoc.Save(createConfigXML.CurrentPath());
                }
                catch(Exception ex)
                {
                    LF = new LogFunction();
                    LF.PutLog("SetAES", ex.ToString(), "");
                }
            }
        }

        //------------------------------------------------------------------------------------------------
        //AESの復号
        //------------------------------------------------------------------------------------------------
        public void DecAES()
        {
            XElement query;

            XmlDoc = new XDocument();
            XmlDoc = XDocument.Load(createConfigXML.CurrentPath(), LoadOptions.PreserveWhitespace);

            //Xmlファイルに書き込み
            for (int i = 0; i < XmlDoc.Descendants("Data").Count(); i++)
            {
                query = (from y in XmlDoc.Descendants("Data")
                         where y.Attribute("ID").Value == Convert.ToString(i + 1)
                         select y).Single();

                try
                {
                    query.Element("ServiceName").Value =Decrypt(query.Element("ServiceName").Value, AES_IV, AES_Key);
                    query.Element("ID").Value = Decrypt(query.Element("ID").Value, AES_IV, AES_Key);
                    query.Element("PassWord").Value = Decrypt(query.Element("PassWord").Value, AES_IV, AES_Key);
                    XmlDoc.Save(createConfigXML.CurrentPath());
                }
                catch (Exception ex)
                {
                    LF = new LogFunction();
                    LF.PutLog("DecAES", ex.ToString(), "");
                }
            }
        }
    

        //------------------------------------------------------------------------------------------------
        //暗号化メソッド
        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// 対称鍵暗号を使って文字列を暗号化する
        /// </summary>
        /// <param name="text">暗号化する文字列</param>
        /// <param name="iv">対称アルゴリズムの初期ベクター</param>
        /// <param name="key">対称アルゴリズムの共有鍵</param>
        /// <returns>暗号化された文字列</returns>
        public string Encrypt(string text, string iv, string key)
        {
            using (RijndaelManaged rijndael = new RijndaelManaged())
            {
                //共通鍵クラスの設定
                rijndael.BlockSize = 128;
                rijndael.KeySize = 128;
                rijndael.Mode = CipherMode.CBC;
                rijndael.Padding = PaddingMode.PKCS7;

                rijndael.IV = Encoding.UTF8.GetBytes(iv);
                rijndael.Key = Encoding.UTF8.GetBytes(key);

                //暗号化を実施するオブジェクトを生成
                ICryptoTransform encryptor = rijndael.CreateEncryptor(rijndael.Key, rijndael.IV);

                //バイト型の配列を設定
                byte[] encrypted;

                //メモリストリーム(メモリに読み書きする)クラスを設定
                using (MemoryStream mStream = new MemoryStream())
                {
                    //暗号化アルゴリズムのクラス(引数 = メモリストリーム、暗号化実施オブジェクト、モードを「書き込み」に設定)
                    using (CryptoStream ctStream = new CryptoStream(mStream, encryptor, CryptoStreamMode.Write))
                    {
                        //streamwriterでctStreamを読み込み
                        using (StreamWriter sw = new StreamWriter(ctStream))
                        {
                            //読み込んだ内容をもとにテキストを暗号化
                            sw.Write(text);
                        }

                        //配列に追加
                        encrypted = mStream.ToArray();
                    }
                }

                //値をリターン
                return (System.Convert.ToBase64String(encrypted));
            }
        }

        //------------------------------------------------------------------------------------------------
        //AES復号メソッド
        //------------------------------------------------------------------------------------------------
        /// <summary>
        /// 対称鍵暗号を使って暗号文を復号する
        /// </summary>
        /// <param name="cipher">暗号化された文字列</param>
        /// <param name="iv">対称アルゴリズムの初期ベクター</param>
        /// <param name="key">対称アルゴリズムの共有鍵</param>
        /// <returns>復号された文字列</returns>
        public static string Decrypt(string cipher, string iv, string key)
        {
            using (RijndaelManaged rijndael = new RijndaelManaged())
            {
                //共通鍵セッティング
                rijndael.BlockSize = 128;
                rijndael.KeySize = 128;
                rijndael.Mode = CipherMode.CBC;
                rijndael.Padding = PaddingMode.PKCS7;

                rijndael.IV = Encoding.UTF8.GetBytes(iv);
                rijndael.Key = Encoding.UTF8.GetBytes(key);

                //暗号化用オブジェクト
                ICryptoTransform decryptor = rijndael.CreateDecryptor(rijndael.Key, rijndael.IV);

                //空の文字列生成
                string plain = string.Empty;

                //メモリストリームクラス　読み込んだ文字列をバイナリデータで読み込み
                using (MemoryStream mStream = new MemoryStream(System.Convert.FromBase64String(cipher)))
                {
                    //読み込みモードでメモリストリームのデータを解析
                    using (CryptoStream ctStream = new CryptoStream(mStream, decryptor, CryptoStreamMode.Read))
                    {
                        //StreamReaderで解析したデータを読み込み
                        using (StreamReader sr = new StreamReader(ctStream))
                        {
                            //空文字列に代入
                            plain = sr.ReadLine();
                        }
                    }
                }

                //値を返す
                return plain;

            }
        }
    }
}
