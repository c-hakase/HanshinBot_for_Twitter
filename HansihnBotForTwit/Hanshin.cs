using System;
using System.Collections.Generic;


namespace HansihnBotForTwit
{
    class Hanshin
    {
        /// <summary>
        /// Hanshin DB
        /// </summary>
        private static DB Hdb { get; set; }



        //private string Filename { get; set; }

        /// <summary>
        /// 33-4達成者リスト
        /// </summary>
        public Dictionary<string, Tuple<int, DateTime>> GetAchievers => Hdb.Achievers;


        public int AddAchiever(string user, DateTime dateTime)
        {
            if(Hdb.Achievers.ContainsKey(user))
            {
                var times = Hdb.Achievers[user].Item1;
                times++;
                Hdb.Achievers[user] = new Tuple<int, DateTime>(times, dateTime);
                return times;
            }
            else
            {
                Hdb.Achievers.Add(user, new Tuple<int, DateTime>(1, dateTime));
                return 1;
            }
        }
    }
}
