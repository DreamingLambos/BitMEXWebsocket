using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BitMEXWebsocketPosition.Util;
using BitMEXWebsocketPosition.Websocket;
using BitMEXWebsocketPosition.WebsocketObjects;

namespace BitMEXWebsocketPosition
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		//Creating the necessary basic objects
		BitMexWebsocketClient websocketClient;
		BitMexWebsocketInterpreter websocketInterpreter;
		BitMexWebsocketPosition position;

		private void Form1_Load(object sender, EventArgs e)
		{
			ActivityLog.Info("FORM", "Program Started");
		}

		//With this function we associate the Delegates with the necessary functions and methods, this is called after the objects are instantiated
		private void DelegateManagement()
		{
			websocketClient.WebsocketMessageReceived += OnWebsocketMessageReceived;
			websocketClient.WebsocketMessageReceived += websocketInterpreter.ProcessMessage;
			websocketClient.WebsocketMessageSent += OnWebsocketMessageSent;
			websocketClient.Connected += OnConnected;
			websocketClient.Disconnected += OnDisconnected;
			websocketInterpreter.InterpreterProcessedPosition += position.UpdateFromWebsocket;
			websocketInterpreter.InterpreterProcessedPosition += UpdatePositionGrid;
		}

		//When we receive a websocket message we also do this other than process it in the websocketInterpreter
		public void OnWebsocketMessageReceived(object source, string e)
		{
			if (e.Contains("authKey"))
			{
				if (e.Contains("error") || e.Contains("401") || e.Contains("Error"))
				{
					ActivityLog.Received("WEBSOCKET", "Authentication ERROR, Please Check Your APIs");
				}
				if (e.Contains("success"))
				{
					ActivityLog.Received("WEBSOCKET", "Authentication Succeeded");
				}
				return;
			}
			ActivityLog.Received("WEBSOCKET", e);
		}

		//When we send a message to the websocket we do this
		public void OnWebsocketMessageSent(object source, string e)
		{
			if (e.Contains("authKey"))
			{
				ActivityLog.Sent("WEBSOCKET", "Authentication Sent");
				return;
			}
			ActivityLog.Sent("WEBSOCKET", e);
		}

		//We create the subscription string and send to the websocket
		private void btnSubscribePosition_Click(object sender, EventArgs e)
		{
			string Message = "{\"op\": \"subscribe\", \"args\": [\"position:XBTUSD\"]}";
			websocketClient.Send(Message);
		}

		//We create the unsubscription string and send to the websocket
		private void btnUnsubscribePosition_Click(object sender, EventArgs e)
		{
			string Message = "{\"op\": \"unsubscribe\", \"args\": [\"position:XBTUSD\"]}";
			websocketClient.Send(Message);
		}

		//When we try to connect to the websocket the objects are instantiated
		private void btnConnect_Click(object sender, EventArgs e)
		{
			try
			{
				if (btnConnect.Text == "Connect")
				{
					if (cboWebsocketURL.SelectedIndex != 1 && cboWebsocketURL.SelectedIndex != 0) return;
					string apiKey = "";
					string apiSecret = "";
					if (websocketClient == null || !websocketClient.GetIsConnected())
					{
						if (chkAuthenticate.Checked)
						{
							apiKey = txtAPIKey.Text;
							apiSecret = txtAPISecret.Text;
						}
						websocketClient = new BitMexWebsocketClient(new Uri(cboWebsocketURL.Text), apiKey, apiSecret);
						websocketInterpreter = new BitMexWebsocketInterpreter();
						position = new BitMexWebsocketPosition();
						DelegateManagement();
					}
					websocketClient.Connect();
				}
				if (btnConnect.Text == "Disconnect")
				{
					websocketClient.Disconnect();
					websocketClient = null;
				}
			}
			catch (Exception ex)
			{
				ActivityLog.Error("FORM", ex.Message);
			}
		}

		//Change the text on the button when the connection happens
		public void OnConnected(object source, EventArgs e)
		{
			btnConnect.Text = "Disconnect";

		}

		//Change the text on the button when the disconnection happens
		public void OnDisconnected(object source, EventArgs e)
		{
			btnConnect.Text = "Connect";
		}

		//Update the values of the grid when the object is updated
		public void UpdatePositionGrid(object source, BitMexWebsocketPosition p)
		{
			BindingList<BitMexWebsocketPosition> positions = new BindingList<BitMexWebsocketPosition>();
			positions.Add(position);
			dgdTrades.DataSource = positions.Select(pos => new { Symbol = pos.Symbol, Leverage = pos.Leverage, Side = pos.Side, Size = pos.CurrentQty, AvgEntryPrice = pos.AvgEntryPrice, LiqPrice = pos.LiquidationPrice }).ToList();
		}
	}
}
