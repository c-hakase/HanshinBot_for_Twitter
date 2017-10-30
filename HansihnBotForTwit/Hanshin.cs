using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HansihnBotForTwit
{
    class Hanshin
    {

        private static DB hdb { get; set; }

        /// <summary>
        /// 33-4達成者リスト
        /// </summary>
        public Dictionary<string, Tuple<int, DateTime>> GetAchievers => hdb.achievers;


        public int AddAchiever(string user, DateTime dateTime)
        {
            if(hdb.achievers.ContainsKey(user))
            {
                var times = hdb.achievers[user].Item1;
                times++;
                hdb.achievers[user] = new Tuple<int, DateTime>(times, dateTime);
                return times;
            }
            else
            {
                hdb.achievers.Add(user, new Tuple<int, DateTime>(1, dateTime));
                return 1;
            }
        }
    }
}
