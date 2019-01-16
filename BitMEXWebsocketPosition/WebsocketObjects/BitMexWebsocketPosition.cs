using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitMEXWebsocketPosition.WebsocketObjects
{
	public class BitMexWebsocketPosition
	{

		//The information relative to the Trade is self-explanatory
		public string Symbol { get; set; }
		public bool? IsOpen { get; set; }
		public int? CurrentQty { get; set; }
		public double? AvgEntryPrice { get; set; }
		public double? LiquidationPrice { get; set; }
		public double? MarkPrice { get; set; }
		public double? Leverage { get; set; }
		public bool? CrossMargin { get; set; }
		public string Side { get; set; }

		//Update the position with the updated information
		public void UpdateFromWebsocket(object source, BitMexWebsocketPosition pos)
		{
			if (pos.CurrentQty != null && pos.CurrentQty != this.CurrentQty)
				this.CurrentQty = pos.CurrentQty;
			if (pos.Symbol != null && pos.Symbol != this.Symbol)
				this.Symbol = pos.Symbol;
			if (pos.IsOpen != null && pos.IsOpen != this.IsOpen)
				this.IsOpen = pos.IsOpen;
			if (pos.AvgEntryPrice != null && pos.AvgEntryPrice != this.AvgEntryPrice)
				this.AvgEntryPrice = pos.AvgEntryPrice;
			if (pos.LiquidationPrice != null && pos.LiquidationPrice != this.LiquidationPrice)
				this.LiquidationPrice = pos.LiquidationPrice;
			if (pos.LiquidationPrice == null || pos.LiquidationPrice == 0)
				this.LiquidationPrice = 0;
			if (pos.MarkPrice != null && pos.MarkPrice != this.MarkPrice)
				this.MarkPrice = pos.MarkPrice;
			if (pos.CrossMargin != null)
			{
				this.CrossMargin = pos.CrossMargin;
			}
			if (pos.Leverage != null & pos.Leverage != this.Leverage)
			{
				this.Leverage = pos.Leverage;
			}
			if (this.CurrentQty > 0)
				this.Side = "Long";
			if (this.CurrentQty < 0)
				this.Side = "Short";
			if (this.CurrentQty == 0 || this.CurrentQty == null)
			{
				this.AvgEntryPrice = 0;
				this.Side = "Closed";
			}
		}

	}
}
