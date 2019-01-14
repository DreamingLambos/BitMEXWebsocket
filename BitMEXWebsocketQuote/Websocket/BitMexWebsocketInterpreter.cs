using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitMEXWebsocketQuote.WebsocketObjects;
using BitMEXWebsocketQuote.Util;
using Newtonsoft.Json;

namespace BitMEXWebsocketQuote.Websocket
{
    class BitMexWebsocketInterpreter
    {

		//The BitMexWebsocketInterpreter is an additional layer that we use to interpret the messages received via Websocket and pass to the correct Object

		//We created event handlers so we can trigger other functions in other objects
		public delegate void InterpreterProcessedQuoteEventHandler(object source, BitMexWebsocketQuote e);

		public event InterpreterProcessedQuoteEventHandler InterpreterProcessedQuote;

		//ProcessMessage is called every time a message is received from the Websocket, here the message is interpreted and directed to the correct function
		public void ProcessMessage(object source, string message)
        {

			//The Websocket message contains an update regarding the QUOTE subscription
			//We get rid of the unnecessary part of the string and deserialise the remaining to obtain an object of BitMexWebsocketQuote type
			//We then pass the call another event to update the object through a Delegate
			//Note that the websocket message can contain several quotes at the same time so what we do is deserialize to a list and only keep the last
			//because the last is the most recent
			if (message.Contains("\"table\":\"quote\""))
			{
				try
				{
					string search = "\"data\":";
					int i = message.IndexOf(search);
					string json = message.Substring(i + search.Length);
					json = json.Remove(json.Length - 1);
					BitMexWebsocketQuote quote = JsonConvert.DeserializeObject<List<BitMexWebsocketQuote>>(json).Last();
					OnInterpreterProcessedQuote(quote);
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

		protected virtual void OnInterpreterProcessedQuote(BitMexWebsocketQuote c)
		{
			if (InterpreterProcessedQuote != null)
			{
				InterpreterProcessedQuote(this, c);
			}
		}

	}
}
