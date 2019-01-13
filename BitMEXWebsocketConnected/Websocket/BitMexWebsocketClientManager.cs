using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitMEXWebsocketConnected.Util;

namespace BitMEXWebsocketConnected.Websocket
{
    class BitMexWebsocketClientManager
    {

        private DateTime _lastMessageReceivedTime;
        private DateTime _lastPongReceived;
        private DateTime _lastConnectionTime;

        private BitMexWebsocketClient _client;
        
        public BitMexWebsocketClientManager(BitMexWebsocketClient c)
        {
            _client = c;
        }

        public void Reconnect()
        {

        }

        private void Subscribe(string topic)
        {
            StringBuilder s = new StringBuilder();
            s.Append("{ \"op\": \"subscribe\", \"args\": [\"");
            s.Append(topic);
            s.Append("\"]}");
            string subscriptionMessage = s.ToString();
            _client.Send(subscriptionMessage);
        }

        private void Unsubscribe(string topic)
        {
            StringBuilder s = new StringBuilder();
            s.Append("{ \"op\": \"unsubscribe\", \"args\": [\"");
            s.Append(topic);
            s.Append("\"]}");
            string unsubscriptionMessage = s.ToString();
            _client.Send(unsubscriptionMessage);
        }

        public void SubscribeConnected()
        {
            Subscribe("connected");
        }

        public void UnsubscribeConnected()
        {
            Unsubscribe("connected");
        }

        public void SubscribeOrderBookL2()
        {
            Subscribe("orderBookL2:XBTUSD");
        }

        public void UnsubscribeOrderBookL2()
        {
            Unsubscribe("orderBookL2:XBTUSD");
        }

        public void SubscribeOrderBook10()
        {
            Subscribe("orderBook10:XBTUSD");
        }

        public void UnsubscribeOrderBook10()
        {
            Unsubscribe("orderBook10:XBTUSD");
        }

        public void SubscribeOrder()
        {
            Subscribe("order:XBTUSD");
        }

        public void UnsubscribeOrder()
        {
            Unsubscribe("order:XBTUSD");
        }

        public void SubscribePosition()
        {
            Subscribe("position:XBTUSD");
        }

        public void UnsubscribePosition()
        {
            Unsubscribe("position:XBTUSD");
        }



        public void SubscribeAll()
        {
            SubscribeConnected();
            //SubscribeOrderBookL2();
            //SubscribeOrderBook10();
            //SubscribePosition();
            //SubscribeOrder();
        }

        public void UnsubscribeAll()
        {
            UnsubscribeConnected();
            UnsubscribeOrderBookL2();
        }

        public void OnAuthenticated(object source, EventArgs e)
        {
            //ActivityLog.Debug("WEBSOCKET", "SUBSCRIBING");
            SubscribeAll();
        }

    }
}
