using System;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using BitMEXWebsocketTrade.Util;

namespace BitMEXWebsocketTrade.Websocket
{
    class BitMexWebsocketClient
    {

        private ClientWebSocket _ws;
        private Uri _wsUri;
        private string _apiKey;
        private string _apiSecret;
        private DateTime _connectionStartTime;
        private DateTime _lastMessageReceivedTime;
        private bool _isConnected;
        private bool _isAuthenticated;
        private bool _isAuthenticating;

		//We created event handlers so we can trigger other functions in other objects
        public delegate void WebsocketMessageReceivedEventHandler(object source, string e);
        public delegate void WebsocketMessageSentEventHandler(object source, string e);
        public delegate void ConnectedEventHandler(object source, EventArgs e);
        public delegate void DisconnectedEventHandler(object source, EventArgs e);
        public delegate void AuthenticatedEventHandler(object source, EventArgs e);

        public event WebsocketMessageReceivedEventHandler WebsocketMessageReceived;
        public event WebsocketMessageSentEventHandler WebsocketMessageSent;
        public event ConnectedEventHandler Connected;
        public event DisconnectedEventHandler Disconnected;
        public event AuthenticatedEventHandler Authenticated;

        public bool GetIsConnected()
        {
            return (_isConnected == true) ? true : false;
        }

        public bool GetIsAuthenticated()
        {
            return (_isAuthenticated == true) ? true : false;
        }

        public DateTime GetConnectionStartTime()
        {
            return _connectionStartTime;
        }

        public DateTime GetLastMessageReceivedTime()
        {
            return _lastMessageReceivedTime;
        }

		//Constructor if there is no authentication
        public BitMexWebsocketClient(Uri uri)
        {
            _wsUri = uri;
            _isAuthenticated = false;
            _isAuthenticating = false;
            _isConnected = false;
            _lastMessageReceivedTime = default(DateTime);
            _connectionStartTime = default(DateTime);
        }

		//Constructor if authentication is required
        public BitMexWebsocketClient(Uri uri, string apiKey = null, string apiSecret = null) : this(uri)
        {
            _apiKey = apiKey;
            _apiSecret = apiSecret;
        }

		//Connection to the Websocket endpoint
        public async Task Connect()
        {
            try
            {
                if (_ws != null)
                {
                    Disconnect();
                }
                _ws = new ClientWebSocket();
                await _ws.ConnectAsync(_wsUri, CancellationToken.None);
                if (_ws.State == WebSocketState.Open)
                {
                    _isConnected = true;
                    _connectionStartTime = DateTime.UtcNow;
                    Receive(_ws);
                    KeepAlive(this);
                    if(this._apiKey.Length>0 && this._apiSecret.Length>0)
                    {
                        this.Authenticate();
                    }
                    OnConnected();
                }
            }
            catch(Exception e)
            {
                ActivityLog.Error("WEBSOCKET", e.Message);
            }
        }

		//Disconnection from Websocket
        public void Disconnect()
        {
            try
            {
                if (_ws != null)
                {
                    _ws.Abort();
                    _ws.Dispose();
                    _ws = null;
                }
                _isConnected = false;
                OnDisconnected();
            }

            catch(Exception e)
            {
                ActivityLog.Error("WEBSOCKET", e.Message);
            }
        }

		//Send a message to the Websocket endpoint
        public async Task Send(string message)
        {
            try
            {
                var requestAsBytes = Encoding.UTF8.GetBytes(message);
                var messageSegment = new ArraySegment<byte>(requestAsBytes);
                await _ws.SendAsync(messageSegment, WebSocketMessageType.Text, true, CancellationToken.None);
                OnWebsocketMessageSent(message);
            }
            catch(Exception e)
            {
                ActivityLog.Error("WEBSOCKET", e.Message);
            }
        }

		//Receive a message from the Websocket
        public async Task Receive(object websocketClient)
        {
            try
            {
                ClientWebSocket ws = (ClientWebSocket)websocketClient;
                while (ws.State == WebSocketState.Open)
                {
                    WebSocketReceiveResult result = null;
                    var buffer = new byte[1024];
                    var message = new ArraySegment<byte>(buffer);
                    var resultMessage = new StringBuilder();
                    do
                    {
                        result = await ws.ReceiveAsync(message, CancellationToken.None);
                        var receivedMessage = Encoding.UTF8.GetString(buffer, 0, result.Count);
                        resultMessage.Append(receivedMessage);
                        if (result.MessageType != WebSocketMessageType.Text)
                            break;
                    } while (!result.EndOfMessage);
                    _lastMessageReceivedTime = DateTime.UtcNow;
                    OnWebsocketMessageReceived(resultMessage.ToString());
                    if (_isAuthenticating && resultMessage.ToString().Contains("authKey"))
                    {
                        ConfirmAuthentication(resultMessage.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                ActivityLog.Error("WEBSOCKET", e.Message);
            }
        }

		//Keep alive sends a PING message to the Websocket in case no messages have been received
		//This is necessary because otherwise the Websocket would close the connection after a number of seconds of inactivity
        private async Task KeepAlive(BitMexWebsocketClient client)
        {
            while (client.GetIsConnected())
            {
                await Task.Delay(2500);
                var sinceLastMessage = DateTime.UtcNow - client.GetLastMessageReceivedTime();
                if(_ws.State == WebSocketState.Open)
                {
                    if (sinceLastMessage.Seconds > 20)
                    {
                        client.Disconnect();
                        return;
                    }
                    if (sinceLastMessage.Seconds > 10)
                    {
                        client.Send("ping");
                    }
                }
            }

        }

		//Send an authentication message to the Websocket, necessary when you want to subscribe to some streams
        private void Authenticate()
        {
            try
            {
                if (this._isConnected)
                {
                    long nonce = BitMexUtil.GetNonce();
                    string signature = BitMexUtil.GetSignature(this._apiSecret, nonce);
                    string authRequest = "{ \"op\": \"authKey\", \"args\": [\""+ _apiKey.ToString()+"\", "+nonce.ToString()+", \""+signature+"\"] }";
                    this.Send(authRequest);
                    _isAuthenticating = true;
                }
            }
            catch (Exception e)
            {
                ActivityLog.Error("WEBSOCKET", e.Message);
            }
        }

        private async Task ConfirmAuthentication(string message)
        {
            if (message.Contains("success"))
            {
                _isAuthenticated = true;
                _isAuthenticating = false;
                OnAuthenticated();
            }
            if (message.Contains("error"))
            {
                _isAuthenticated = false;
                _isAuthenticating = false;
                Disconnect();
            }
        }

		//To trigger the Delegate when a message is received
        protected virtual void OnWebsocketMessageReceived(string message)
        {
            if (WebsocketMessageReceived != null)
            {
                WebsocketMessageReceived(this, message);
            }
        }

		//To trigger the Delegate when a message is sent
		protected virtual void OnWebsocketMessageSent(string message)
        {
            if (WebsocketMessageSent != null)
            {
                WebsocketMessageSent(this, message);
            }
        }

		//To trigger the Delegate when the Websocket is connected
		protected virtual void OnConnected()
        {
            if (Connected != null)
            {
                Connected(this, EventArgs.Empty);
            }
        }

		//To trigger the Delegate when the Websocket is disconnected
		protected virtual void OnDisconnected()
        {
            if (Disconnected != null)
            {
                Disconnected(this, EventArgs.Empty);
            }
        }

		//To trigger the Delegate when the Websocket is authenticated
		protected virtual void OnAuthenticated()
        {
            if (Authenticated != null)
            {
                Authenticated(this, EventArgs.Empty);
            }
        }
    }
}


