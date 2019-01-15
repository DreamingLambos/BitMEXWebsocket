using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitMEXWebsocketTrade.WebsocketObjects
{
	public class BitMexWebsocketTrade
	{

		//The information relative to the Trade is self-explanatory
		public DateTime Timestamp { get; set; }
		public string Symbol { get; set; }
		public string Side { get; set; }
		public long Size { get; set; }
		public double Price { get; set; }

	}
}
