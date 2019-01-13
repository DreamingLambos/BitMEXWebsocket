using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitMEXWebsocketConnected.WebsocketObjects;
using BitMEXWebsocketConnected.Util;
using Newtonsoft.Json;

namespace BitMEXWebsocketConnected.Websocket
{
    class BitMexWebsocketInterpreter
    {


        public delegate void InterpreterProcessedConnectedEventHandler(object source, BitMexWebsocketConnected e);

        public event InterpreterProcessedConnectedEventHandler InterpreterProcessedConnected;


        public void ProcessMessage(object source, string message)
        {

            if (message.Contains("\"table\":\"connected\""))
            {
				try
				{
					string search = "\"data\":";
					int i = message.IndexOf(search);
					string json = message.Substring(i + search.Length);
					json = json.Remove(json.Length - 1);
					BitMexWebsocketConnected connected = JsonConvert.DeserializeObject<List<BitMexWebsocketConnected>>(json).First();
					OnInterpreterProcessedConnected(connected);
					return;
				}
				catch (Exception e)
				{
					ActivityLog.Error("WEBSOCKET INTERPRETER", e.Message);
				}
            }

            if (message.Contains("error") && !message.Contains("authKey"))
            {
                ActivityLog.Error("WEBSOCKET INTERPRETER", message);
                return;
            }

            if (message.Contains("error") && message.Contains("authKey"))
            {
                ActivityLog.Error("WEBSOCKET INTERPRETER", "Authentication Failed, Please Check API Keys");
                return;
            }

        }

        protected virtual void OnInterpreterProcessedConnected(BitMexWebsocketConnected c)
        {
            if (InterpreterProcessedConnected != null)
            {
                InterpreterProcessedConnected(this, c);
            }
        }

    }
}
