using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitMEXWebsocketConnected.WebsocketObjects
{

    public class BitMexWebsocketConnected
    {
        public string users { get; set; }
        public string bots { get; set; }

		public void UpdateFromWebsocket(object source, BitMexWebsocketConnected c)
		{
			users = c.users.ToString();
			bots = c.bots.ToString();
		}
    }
}
