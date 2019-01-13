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

		//The BitMexWebsocketInterpreter is an additional layer that we use to interpret the messages received via Websocket and pass to the correct Object

		//We created event handlers so we can trigger other functions in other objects
		public delegate void InterpreterProcessedConnectedEventHandler(object source, BitMexWebsocketConnected e);

        public event InterpreterProcessedConnectedEventHandler InterpreterProcessedConnected;

		//ProcessMessage is called every time a message is received from the Websocket, here the message is interpreted and directed to the correct function
        public void ProcessMessage(object source, string message)
        {

			//The Websocket message contains an update regarding the CONNECTED subscription
			//We get rid of the unnecessary part of the string and deserialise the remaining to obtain an object of BitMexWebsocketConnected type
			//We then pass the call another event to update the object through a Delegate
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

			//We add this check so that we do not log API Keys in plain text in the log file
            if (message.Contains("error") && !message.Contains("authKey"))
            {
                ActivityLog.Error("WEBSOCKET INTERPRETER", message);
                return;
            }

			//We add this check so that we do not log API Keys in plain text in the log file
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
