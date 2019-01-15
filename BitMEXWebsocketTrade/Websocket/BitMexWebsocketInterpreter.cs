using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitMEXWebsocketTrade.WebsocketObjects;
using BitMEXWebsocketTrade.Util;
using Newtonsoft.Json;

namespace BitMEXWebsocketTrade.Websocket
{
    class BitMexWebsocketInterpreter
    {

		//The BitMexWebsocketInterpreter is an additional layer that we use to interpret the messages received via Websocket and pass to the correct Object

		//We created event handlers so we can trigger other functions in other objects
		public delegate void InterpreterProcessedTradeEventHandler(object source, List<BitMexWebsocketTrade> e);

		public event InterpreterProcessedTradeEventHandler InterpreterProcessedTrade;

		//ProcessMessage is called every time a message is received from the Websocket, here the message is interpreted and directed to the correct function
		public void ProcessMessage(object source, string message)
        {

			//The Websocket message contains an update regarding the TRADE subscription
			//We get rid of the unnecessary part of the string and deserialise the remaining to obtain an object of BitMexWebsocketTrade type
			//In this case we deserialize to a list of BitMexWebsocketTrade bacause usually we are interested in more the last trade
			if (message.Contains("\"table\":\"trade\""))
			{
				try
				{
					string search = "\"data\":";
					int i = message.IndexOf(search);
					string json = message.Substring(i + search.Length);
					json = json.Remove(json.Length - 1);
					List<BitMexWebsocketTrade> trades = JsonConvert.DeserializeObject<List<BitMexWebsocketTrade>>(json);
					OnInterpreterProcessedTrade(trades);
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

		protected virtual void OnInterpreterProcessedTrade(List<BitMexWebsocketTrade> c)
		{
			if (InterpreterProcessedTrade != null)
			{
				InterpreterProcessedTrade(this, c);
			}
		}

	}
}
