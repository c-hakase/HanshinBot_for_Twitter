using System;
using System.Collections.Generic;
using CoreTweet;
using CoreTweet.Streaming;
using System.Text.RegularExpressions;


namespace HansihnBotForTwit
{
    class Tweet
    {
        //Form1 frm = new Form1();
        Hanshin hanshin = new Hanshin();        
        /// <summary>
        /// ツイート内容
        /// </summary>
        private static string[] dice = { "⚂", "⚃" }; // デバッグ用
        private static string[] Maindice = { "⚀", "⚁", "⚂", "⚃", "⚄", "⚅" };
        private static string hansin = "なんでや！阪神関係ないやろ！";
        private string resp = "";


        private string filename { get; set; }
        private static DB hdb { get; set; }




        public string Tweet_Main(string _filename, Tokens tokens)
        {

            filename = _filename;
            if (System.IO.File.Exists(filename))
            {
                hdb = JsonManager<DB>.Load(filename);
            }
            else
            {
                hdb = new DB();
                
                JsonManager<DB>.Write(hdb, filename);
            }

            try
            {
                var stream = tokens.Streaming.StartStream(StreamingType.User, new StreamingParameters(replies => "all"));


                tokens.Statuses.Update(new { status = "起動したよ" + "(" + DateTime.Now + ")" });

                foreach (var message in stream)
                {
                    if (message is StatusMessage)
                    {
                        var status = (message as StatusMessage).Status;
                        string str = status.Text;
                        string tweet;
                        bool flag = false;
                        var r = new Random();
                        var _rep = "";

                        /*ここなんでか知らんけど普通に動いちゃった*/
                        //diceに反応してサイコロ返す
                        while (str.Contains("dice"))
                        {

                            int i = str.IndexOf("dice");
                            str = str.Remove(i, 4);
                            str = str.Insert(i, dice[r.Next(dice.Length)]);
                            flag = true;

                        }

                        
                        tweet = "@" + status.User.ScreenName + " " + "\n";
                        if (flag)
                        {
                            tweetText(tweet, str, tokens, status);
                            flag = false;
                        }


                        //33-4達成者が出たとき
                        if (str == "⚂⚂-⚃")
                        {
                            var times = hanshin.AddAchiever(status.User.ScreenName, DateTime.Now);
                            if(times == 1)
                            {
                                resp = $"なんでや！阪神関係ないやろ！\nおめでとうございます！あなたは{hanshin.GetAchievers.Count}人目の33-4達成者です！";
                            }
                            else
                            {
                                resp = $"なんでや！阪神関係ないやろ！\nおめでとうございます！あなたは{times}回目の33-4達成です！";
                            }
                            _rep = tweet + resp;
                            tweetText(tweet, resp, tokens, status);

                        }

                        //TLの33-4に反応
                        if (Regex.IsMatch(status.Text, "33-4"))
                        {
                            tweetText(tweet, hansin, tokens, status);
                        }
                        if (Regex.IsMatch(status.Text, "334"))
                        {
                            tweetText(tweet, hansin, tokens, status);
                        }

                        //TLのachieverに対して達成者を報告
                        if(Regex.IsMatch(status.Text,"@" + status.User.ScreenName + "achiever"))
                        {
                            var command = status.Text.Split();
                            switch(command[1])
                            {
                                case "achiever":
                                    if(command.Length == 2)
                                    {
                                        if(hanshin.GetAchievers.ContainsKey(command[2]))
                                        {
                                            var achiever = hanshin.GetAchievers[command[2]];
                                            resp = $"{command[2]}さんの33-4記録\n回数:{achiever.Item1}回\n最後に33-4した日時:{achiever.Item2.ToString()}\n";
                                        }
                                        else
                                        {
                                            resp = "まだ33-4を達成していない人のようです.";
                                        }
                                        tweetText(tweet, resp, tokens, status);
                                    }
                                    else if(command.Length == 1)
                                    {
                                        Tuple<int, DateTime> lastest = null;
                                        var lastest_user = "";
                                        foreach(var a in hanshin.GetAchievers)
                                        {
                                            if(lastest == null || lastest.Item2< a.Value.Item2)
                                            {
                                                lastest = a.Value;
                                                lastest_user = a.Key;
                                            }

                                            if(lastest_user == null)
                                            {
                                                resp = "これまでに33-4を達成した人はいません.";
                                            }
                                            else
                                            {
                                                resp = $"これまでの33-4達成者\n人数:{hanshin.GetAchievers.Count}人\n最後に達成した人:{lastest_user}さん\n回数{lastest.Item1}回 日時: {lastest.Item2.ToString()}\n";
                                            }

                                            tweetText(tweet, resp, tokens, status);
                                        }
                                    }
                                    break;
                                default:
                                    resp = "設定されたコマンド以外にはリアクションしません。にゃーん。";
                                    tweetText(tweet, resp, tokens, status);
                                    break;
                            }
                        }
                    }
                }
                return "Tweet success";
            }
            catch (Exception ex)
            {
                return "Error : " + ex.Message;
            }

        }

        public void tweetText(string _username , string tweet, Tokens tokens, Status status)
        {
            tokens.Statuses.Update(new { status = tweet, in_reply_to_status_id = status.Id });
        }

    }
}
