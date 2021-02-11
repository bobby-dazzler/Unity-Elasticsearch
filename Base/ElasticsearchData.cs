using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Nest;

namespace UnityElasticsearch {
    [CreateAssetMenu(menuName="Elastic/Connection Data")]
    public class ElasticsearchData : ScriptableObject {

        public string connectionString;
        
        public void SendToElasticsearch<T> (string indexName, T logData) where T : class {
            try {
                var settings = new ConnectionSettings(new Uri(connectionString)
                    ).DefaultIndex(indexName);
                var client = new ElasticClient(settings);
                
                var indexResponse = client.IndexDocument(logData);
                if (!indexResponse.IsValid) {
                    Debug.Log("Index Invalid");
                    Debug.Log(indexResponse.DebugInformation);
                }
            } catch (Exception ex) {
                Debug.Log(ex);
            }
        }
    }
}
