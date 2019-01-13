using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitMEXWebsocketConnected.WebsocketObjects
{

	//This is the basic class for the CONNECTED subscription, connected only shows the number of users and bots currently connected to the website/server
    public class BitMexWebsocketConnected
    {
        public string Users { get; set; }
        public string Bots { get; set; }

		//With this method we take the deserialised string from the websocket and updated the values of the Properties
		public void UpdateFromWebsocket(object source, BitMexWebsocketConnected c)
		{
			Users = c.Users.ToString();
			Bots = c.Bots.ToString();
		}
    }
}
