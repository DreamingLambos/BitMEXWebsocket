using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitMEXWebsocketQuote.WebsocketObjects
{
	public class BitMexWebsocketQuote
	{

		//The information relative to the Quote is self-explanatory
		//As a reminder, the quote is formed by the highest bid and the lowest ask existing in the orderbook for a specific instrument
		//This is actually the actual price the instrument is trading
		public DateTime Timestamp { get; set; }
		public string Symbol { get; set; }
		public long BidSize { get; set; }
		public double BidPrice { get; set; }
		public long AskSize { get; set; }
		public double AskPrice { get; set; }

		//This method updates the Quote with the latest values received through the websocket
		public void UpdateFromWebsocket(object o, BitMexWebsocketQuote quote)
		{
			Timestamp = quote.Timestamp;
			Symbol = quote.Symbol;
			BidPrice = quote.BidPrice;
			BidSize = quote.BidSize;
			AskPrice = quote.AskPrice;
			AskSize = quote.AskSize;
		}
	}
}
