using System;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace HansihnBotForTwit
{
    public class DB
    {
        /// <summary>
        /// 33-4達成者
        /// </summary>
        [JsonProperty("achievers")]
        public Dictionary<string,Tuple<int,DateTime>> achievers { get; set; }

    }
}
