namespace BitMEXWebsocketPosition
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
			this.btnSubscribePosition = new System.Windows.Forms.Button();
			this.btnUnsubscribePosition = new System.Windows.Forms.Button();
			this.dgdTrades = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.dgdTrades)).BeginInit();
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
			// btnSubscribePosition
			// 
			this.btnSubscribePosition.Location = new System.Drawing.Point(15, 155);
			this.btnSubscribePosition.Name = "btnSubscribePosition";
			this.btnSubscribePosition.Size = new System.Drawing.Size(161, 23);
			this.btnSubscribePosition.TabIndex = 11;
			this.btnSubscribePosition.Text = "Subscribe to Position";
			this.btnSubscribePosition.UseVisualStyleBackColor = true;
			this.btnSubscribePosition.Click += new System.EventHandler(this.btnSubscribePosition_Click);
			// 
			// btnUnsubscribePosition
			// 
			this.btnUnsubscribePosition.Location = new System.Drawing.Point(182, 155);
			this.btnUnsubscribePosition.Name = "btnUnsubscribePosition";
			this.btnUnsubscribePosition.Size = new System.Drawing.Size(161, 23);
			this.btnUnsubscribePosition.TabIndex = 12;
			this.btnUnsubscribePosition.Text = "Unsubscribe to Position";
			this.btnUnsubscribePosition.UseVisualStyleBackColor = true;
			this.btnUnsubscribePosition.Click += new System.EventHandler(this.btnUnsubscribePosition_Click);
			// 
			// dgdTrades
			// 
			this.dgdTrades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgdTrades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgdTrades.Location = new System.Drawing.Point(15, 184);
			this.dgdTrades.Name = "dgdTrades";
			this.dgdTrades.Size = new System.Drawing.Size(801, 80);
			this.dgdTrades.TabIndex = 13;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(828, 289);
			this.Controls.Add(this.dgdTrades);
			this.Controls.Add(this.btnUnsubscribePosition);
			this.Controls.Add(this.btnSubscribePosition);
			this.Controls.Add(this.txtAPISecret);
			this.Controls.Add(this.txtAPIKey);
			this.Controls.Add(this.lblAPISecret);
			this.Controls.Add(this.lblAPIKey);
			this.Controls.Add(this.chkAuthenticate);
			this.Controls.Add(this.cboWebsocketURL);
			this.Controls.Add(this.btnConnect);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "Form1";
			this.Text = "DreamingLambos.com - Websocket XBTUSD Position";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgdTrades)).EndInit();
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
		private System.Windows.Forms.Button btnSubscribePosition;
		private System.Windows.Forms.Button btnUnsubscribePosition;
		private System.Windows.Forms.DataGridView dgdTrades;
	}
}

