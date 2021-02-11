using System;

namespace UnityElasticsearch {
    public class LogData_GrowableExample : ILogToElasticsearch {

        public LogData_GrowableExample (DateTime dateTime, int currentDay, int currentHour, int currentMinute) {
            logTimeStamp = dateTime;
            gameTimeDayCount = currentDay;
            gameTimeHour = currentHour;
            gameTimeinute = currentMinute;
        }

        public DateTime logTimeStamp;
        public int gameTimeDayCount;
        public int gameTimeHour;
        public int gameTimeinute;

        public void Send(ElasticsearchData esData) {
            string esIndexName = "growable";
            esData.SendToElasticsearch(esIndexName, this);
        }
    }
}