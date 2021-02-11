using System;

namespace UnityElasticsearch {
    public class LogData_SubSystem : ILogToElasticsearch {

        public LogData_SubSystem (int subSystemIndex, string name, int agentsCount, DateTime dateTime, int currentDay, int currentHour, int currentMinute) {
            id = subSystemIndex;
            logTimeStamp = dateTime;
            subSystemName = name;
            agentCount = agentsCount;
            gameTimeDayCount = currentDay;
            gameTimeHour = currentHour;
            gameTimeinute = currentMinute;
        }

        public int id;
        public DateTime logTimeStamp;
        public string subSystemName;
        public int agentCount;
        public int gameTimeDayCount;
        public int gameTimeHour;
        public int gameTimeinute;

        public void Send(ElasticsearchData esData) {
            string esIndexName = "subssystemdata";
            esData.SendToElasticsearch(esIndexName, this);
        }
    }
}