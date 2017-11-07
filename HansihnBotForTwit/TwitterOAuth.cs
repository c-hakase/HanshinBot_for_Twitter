using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CoreTweet.OAuth;
using CoreTweet;
using CoreTweet.Streaming;
using System.Text.RegularExpressions;


namespace HansihnBotForTwit
{
    class TwitterOAuth
    {

        /// <summary>
        /// セッション
        /// </summary>
        public OAuthSession session;


        /// <summary>
        /// Twitterから取得したトークン
        /// </summary>
        private Tokens token;

        /// <summary>
        /// ID,Passの一時保管
        /// </summary>
        public static string twid, twps;


        /// <summary>
        /// APIKey,APISERCRET(たぶんあとでJsonで開けるようにする
        /// </summary>
        private static string APIKEY = "";
        private static string APISECRET = "";



        /// <summary>
        /// 認証用URLを取得
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public string OAuthPage(string id , string pass)
        {
            string url;
            
            twid = id;
            twps = pass;
            session = Authorize(APIKEY, APISECRET);
            url = session.AuthorizeUri.AbsoluteUri;
            return url;
        }
        


        /// <summary>
        /// アクセストークンの取得
        /// </summary>
        /// <param name="_pin"></param>
        /// <returns></returns>
        public Tokens GTokens(string _pin)
        {   
            token = OAuth.GetTokens(session, _pin);
            return token;
        }
        
    }
}
