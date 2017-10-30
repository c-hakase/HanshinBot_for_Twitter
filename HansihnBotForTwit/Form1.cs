using System;
using System.Windows.Forms;
using CoreTweet;
using System.Text.RegularExpressions;
using static CoreTweet.OAuth;

namespace HansihnBotForTwit
{
 
    public partial class Form1 : Form
    {

        TwitterOAuth TOAuth = new TwitterOAuth();

        Tweet Tweet = new Tweet();
        private static string twid, twps;
        //private int c = 0;



        /// <summary>
        /// Twitterから取得したトークン
        /// </summary>
        private Tokens tokens;


        /// <summary>
        /// 認証ページから取得したピンコード
        /// </summary>
        public string PINCode;



        /// <summary>
        /// 認証ページへのURL
        /// </summary>
        private static string pin_URL;
        //private string output;
        
        
        /// <summary>
        /// 認証ページがログイン画面かPINコード表示画面かのフラグ
        /// </summary>
        private bool i = false;



        /// <summary>
        /// ステータスに表示するテキスト
        /// </summary>
        private string statusText;


        /// <summary>
        /// 認証ページを開く
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void submit_Click(object sender, EventArgs e)
        {
            twid = idText.Text;
            twps = passText.Text;
            pin_URL = TOAuth.OAuthPage(idText.Text, passText.Text);
            Browser.Navigate(pin_URL);
        }



        /// <summary>
        /// ブラウザで認証ページの読み込みが完了したら自動でログインしてサブミットしてくれる
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            
            if (i == false)
            {

                //テキストボックスにIDを設定
                HtmlElement id_forms = Browser.Document.GetElementById("username_or_email");
                id_forms.SetAttribute("value", twid);
                //同じくパスを設定
                HtmlElement pass_forms = Browser.Document.GetElementById("password");
                pass_forms.SetAttribute("value", twps);


                //フォームのサブミット
                HtmlElement sub_forms = Browser.Document.GetElementById("oauth_form");
                sub_forms.InvokeMember("submit");

                i = true;
                
                
            }
            else if (i == true)
            {

                    //PINの取得
                HtmlElement _pin = Browser.Document.GetElementById("oauth_pin");
                MatchCollection mc = Regex.Matches(_pin.InnerHtml.ToString(), @"<code>(.*?)</code>");
                foreach (Match m in mc)
                {
                    PINCode = m.Groups[1].Value;
                }

                i = false;

                tokens = TOAuth.GTokens(PINCode);

                if (tokens != null) statuslabel.Text = "Successful acquisition of token!";

                statusText = Tweet.Tweet_Main("Hanshin.json", tokens);

                Appstatus.Text = statusText;
                
            }
            
        }



        public Form1()
        {
            InitializeComponent();   
        }


    }
}
