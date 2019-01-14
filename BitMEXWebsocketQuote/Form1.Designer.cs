namespace BitMEXWebsocketQuote
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnConnect = new System.Windows.Forms.Button();
			this.cboWebsocketURL = new System.Windows.Forms.ComboBox();
			this.chkAuthenticate = new System.Windows.Forms.CheckBox();
			this.lblAPIKey = new System.Windows.Forms.Label();
			this.lblAPISecret = new System.Windows.Forms.Label();
			this.txtAPIKey = new System.Windows.Forms.TextBox();
			this.txtAPISecret = new System.Windows.Forms.TextBox();
			this.lblBid = new System.Windows.Forms.Label();
			this.lblAsk = new System.Windows.Forms.Label();
			this.txtBid = new System.Windows.Forms.TextBox();
			this.txtAsk = new System.Windows.Forms.TextBox();
			this.btnSubscribeQuotes = new System.Windows.Forms.Button();
			this.btnUnsubscribeQuotes = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnConnect
			// 
			this.btnConnect.Location = new System.Drawing.Point(12, 12);
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.Size = new System.Drawing.Size(75, 23);
			this.btnConnect.TabIndex = 0;
			this.btnConnect.Text = "Connect";
			this.btnConnect.UseVisualStyleBackColor = true;
			this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
			// 
			// cboWebsocketURL
			// 
			this.cboWebsocketURL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboWebsocketURL.FormattingEnabled = true;
			this.cboWebsocketURL.Items.AddRange(new object[] {
            "wss://testnet.bitmex.com/realtime",
            "wss://www.bitmex.com/realtime"});
			this.cboWebsocketURL.Location = new System.Drawing.Point(93, 13);
			this.cboWebsocketURL.Name = "cboWebsocketURL";
			this.cboWebsocketURL.Size = new System.Drawing.Size(338, 21);
			this.cboWebsocketURL.TabIndex = 1;
			// 
			// chkAuthenticate
			// 
			this.chkAuthenticate.AutoSize = true;
			this.chkAuthenticate.Checked = true;
			this.chkAuthenticate.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkAuthenticate.Location = new System.Drawing.Point(15, 54);
			this.chkAuthenticate.Name = "chkAuthenticate";
			this.chkAuthenticate.Size = new System.Drawing.Size(86, 17);
			this.chkAuthenticate.TabIndex = 2;
			this.chkAuthenticate.Text = "Authenticate";
			this.chkAuthenticate.UseVisualStyleBackColor = true;
			// 
			// lblAPIKey
			// 
			this.lblAPIKey.AutoSize = true;
			this.lblAPIKey.Location = new System.Drawing.Point(12, 80);
			this.lblAPIKey.Name = "lblAPIKey";
			this.lblAPIKey.Size = new System.Drawing.Size(48, 13);
			this.lblAPIKey.TabIndex = 3;
			this.lblAPIKey.Text = "API KEY";
			// 
			// lblAPISecret
			// 
			this.lblAPISecret.AutoSize = true;
			this.lblAPISecret.Location = new System.Drawing.Point(12, 106);
			this.lblAPISecret.Name = "lblAPISecret";
			this.lblAPISecret.Size = new System.Drawing.Size(70, 13);
			this.lblAPISecret.TabIndex = 4;
			this.lblAPISecret.Text = "API SECRET";
			// 
			// txtAPIKey
			// 
			this.txtAPIKey.Location = new System.Drawing.Point(93, 77);
			this.txtAPIKey.Name = "txtAPIKey";
			this.txtAPIKey.Size = new System.Drawing.Size(338, 20);
			this.txtAPIKey.TabIndex = 5;
			this.txtAPIKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtAPIKey.UseSystemPasswordChar = true;
			// 
			// txtAPISecret
			// 
			this.txtAPISecret.Location = new System.Drawing.Point(93, 103);
			this.txtAPISecret.Name = "txtAPISecret";
			this.txtAPISecret.Size = new System.Drawing.Size(338, 20);
			this.txtAPISecret.TabIndex = 6;
			this.txtAPISecret.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtAPISecret.UseSystemPasswordChar = true;
			// 
			// lblBid
			// 
			this.lblBid.AutoSize = true;
			this.lblBid.Location = new System.Drawing.Point(12, 240);
			this.lblBid.Name = "lblBid";
			this.lblBid.Size = new System.Drawing.Size(75, 13);
			this.lblBid.TabIndex = 7;
			this.lblBid.Text = "XBTUSD Bid :";
			// 
			// lblAsk
			// 
			this.lblAsk.AutoSize = true;
			this.lblAsk.Location = new System.Drawing.Point(12, 211);
			this.lblAsk.Name = "lblAsk";
			this.lblAsk.Size = new System.Drawing.Size(78, 13);
			this.lblAsk.TabIndex = 8;
			this.lblAsk.Text = "XBTUSD Ask :";
			// 
			// txtBid
			// 
			this.txtBid.Location = new System.Drawing.Point(124, 237);
			this.txtBid.Name = "txtBid";
			this.txtBid.ReadOnly = true;
			this.txtBid.Size = new System.Drawing.Size(128, 20);
			this.txtBid.TabIndex = 9;
			this.txtBid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtAsk
			// 
			this.txtAsk.Location = new System.Drawing.Point(124, 208);
			this.txtAsk.Name = "txtAsk";
			this.txtAsk.ReadOnly = true;
			this.txtAsk.Size = new System.Drawing.Size(128, 20);
			this.txtAsk.TabIndex = 10;
			this.txtAsk.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// btnSubscribeQuotes
			// 
			this.btnSubscribeQuotes.Location = new System.Drawing.Point(15, 155);
			this.btnSubscribeQuotes.Name = "btnSubscribeQuotes";
			this.btnSubscribeQuotes.Size = new System.Drawing.Size(161, 23);
			this.btnSubscribeQuotes.TabIndex = 11;
			this.btnSubscribeQuotes.Text = "Subscribe to Quotes";
			this.btnSubscribeQuotes.UseVisualStyleBackColor = true;
			this.btnSubscribeQuotes.Click += new System.EventHandler(this.btnSubscribeQuotes_Click);
			// 
			// btnUnsubscribeQuotes
			// 
			this.btnUnsubscribeQuotes.Location = new System.Drawing.Point(182, 155);
			this.btnUnsubscribeQuotes.Name = "btnUnsubscribeQuotes";
			this.btnUnsubscribeQuotes.Size = new System.Drawing.Size(161, 23);
			this.btnUnsubscribeQuotes.TabIndex = 12;
			this.btnUnsubscribeQuotes.Text = "Unsubscribe to Quotes";
			this.btnUnsubscribeQuotes.UseVisualStyleBackColor = true;
			this.btnUnsubscribeQuotes.Click += new System.EventHandler(this.btnUnsubscribeQuotes_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(449, 281);
			this.Controls.Add(this.btnUnsubscribeQuotes);
			this.Controls.Add(this.btnSubscribeQuotes);
			this.Controls.Add(this.txtAsk);
			this.Controls.Add(this.txtBid);
			this.Controls.Add(this.lblAsk);
			this.Controls.Add(this.lblBid);
			this.Controls.Add(this.txtAPISecret);
			this.Controls.Add(this.txtAPIKey);
			this.Controls.Add(this.lblAPISecret);
			this.Controls.Add(this.lblAPIKey);
			this.Controls.Add(this.chkAuthenticate);
			this.Controls.Add(this.cboWebsocketURL);
			this.Controls.Add(this.btnConnect);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "Form1";
			this.Text = "DreamingLambos.com - Websocket XBTUSD Quotes";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnConnect;
		private System.Windows.Forms.ComboBox cboWebsocketURL;
		private System.Windows.Forms.CheckBox chkAuthenticate;
		private System.Windows.Forms.Label lblAPIKey;
		private System.Windows.Forms.Label lblAPISecret;
		private System.Windows.Forms.TextBox txtAPIKey;
		private System.Windows.Forms.TextBox txtAPISecret;
		private System.Windows.Forms.Label lblBid;
		private System.Windows.Forms.Label lblAsk;
		private System.Windows.Forms.TextBox txtBid;
		private System.Windows.Forms.TextBox txtAsk;
		private System.Windows.Forms.Button btnSubscribeQuotes;
		private System.Windows.Forms.Button btnUnsubscribeQuotes;
	}
}

