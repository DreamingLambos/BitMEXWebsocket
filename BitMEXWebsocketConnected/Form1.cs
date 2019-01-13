using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BitMEXWebsocketConnected.Util;
using BitMEXWebsocketConnected.Websocket;
using BitMEXWebsocketConnected.WebsocketObjects;

namespace BitMEXWebsocketConnected
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		BitMexWebsocketClient websocketClient;
		BitMexWebsocketClientManager websocketClientManager;
		BitMexWebsocketInterpreter websocketInterpreter;
		BitMexWebsocketConnected connected;

		private void Form1_Load(object sender, EventArgs e)
		{
			ActivityLog.Info("FORM", "Program Started");
		}

		private void DelegateManagement()
		{
			websocketClient.WebsocketMessageReceived += OnWebsocketMessageReceived;
			websocketClient.WebsocketMessageReceived += websocketInterpreter.ProcessMessage;
			websocketClient.WebsocketMessageSent += OnWebsocketMessageSent;
			websocketClient.Connected += OnConnected;
			websocketClient.Disconnected += OnDisconnected;
			websocketClient.Authenticated += websocketClientManager.OnAuthenticated;
			websocketInterpreter.InterpreterProcessedConnected += connected.UpdateFromWebsocket;
			websocketInterpreter.InterpreterProcessedConnected += UpdateConnectedValues;
		}

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

		public void OnWebsocketMessageSent(object source, string e)
		{
			if (e.Contains("authKey"))
			{
				ActivityLog.Sent("WEBSOCKET", "Authentication Sent");
				return;
			}
			ActivityLog.Sent("WEBSOCKET", e);
		}

		private void btnSubscribeConnected_Click(object sender, EventArgs e)
		{
			string Message = "{\"op\": \"subscribe\", \"args\": [\"connected\"]}";
			websocketClient.Send(Message);
		}

		private void btnUnsubscribeConnected_Click(object sender, EventArgs e)
		{
			string Message = "{\"op\": \"unsubscribe\", \"args\": [\"connected\"]}";
			websocketClient.Send(Message);
		}

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
						websocketClientManager = new BitMexWebsocketClientManager(websocketClient);
						websocketInterpreter = new BitMexWebsocketInterpreter();
						connected = new BitMexWebsocketConnected();
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

		public void OnConnected(object source, EventArgs e)
		{
			btnConnect.Text = "Disconnect";

		}

		public void OnDisconnected(object source, EventArgs e)
		{
			btnConnect.Text = "Connect";
		}
		
		public void UpdateConnectedValues(object source, BitMexWebsocketConnected c)
		{
			txtConnectedBots.Text = connected.bots;
			txtConnectedUsers.Text = connected.users;
		}
	}
}
