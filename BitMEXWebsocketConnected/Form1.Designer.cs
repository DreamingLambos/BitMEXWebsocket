namespace BitMEXWebsocketConnected
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
			this.lblConnectedUsers = new System.Windows.Forms.Label();
			this.lblConnectedBots = new System.Windows.Forms.Label();
			this.txtConnectedUsers = new System.Windows.Forms.TextBox();
			this.txtConnectedBots = new System.Windows.Forms.TextBox();
			this.btnSubscribeConnected = new System.Windows.Forms.Button();
			this.btnUnsubscribeConnected = new System.Windows.Forms.Button();
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
			// lblConnectedUsers
			// 
			this.lblConnectedUsers.AutoSize = true;
			this.lblConnectedUsers.Location = new System.Drawing.Point(12, 240);
			this.lblConnectedUsers.Name = "lblConnectedUsers";
			this.lblConnectedUsers.Size = new System.Drawing.Size(95, 13);
			this.lblConnectedUsers.TabIndex = 7;
			this.lblConnectedUsers.Text = "Connected Users :";
			// 
			// lblConnectedBots
			// 
			this.lblConnectedBots.AutoSize = true;
			this.lblConnectedBots.Location = new System.Drawing.Point(12, 211);
			this.lblConnectedBots.Name = "lblConnectedBots";
			this.lblConnectedBots.Size = new System.Drawing.Size(89, 13);
			this.lblConnectedBots.TabIndex = 8;
			this.lblConnectedBots.Text = "Connected Bots :";
			// 
			// txtConnectedUsers
			// 
			this.txtConnectedUsers.Location = new System.Drawing.Point(124, 237);
			this.txtConnectedUsers.Name = "txtConnectedUsers";
			this.txtConnectedUsers.ReadOnly = true;
			this.txtConnectedUsers.Size = new System.Drawing.Size(128, 20);
			this.txtConnectedUsers.TabIndex = 9;
			this.txtConnectedUsers.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtConnectedBots
			// 
			this.txtConnectedBots.Location = new System.Drawing.Point(124, 208);
			this.txtConnectedBots.Name = "txtConnectedBots";
			this.txtConnectedBots.ReadOnly = true;
			this.txtConnectedBots.Size = new System.Drawing.Size(128, 20);
			this.txtConnectedBots.TabIndex = 10;
			this.txtConnectedBots.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// btnSubscribeConnected
			// 
			this.btnSubscribeConnected.Location = new System.Drawing.Point(15, 155);
			this.btnSubscribeConnected.Name = "btnSubscribeConnected";
			this.btnSubscribeConnected.Size = new System.Drawing.Size(161, 23);
			this.btnSubscribeConnected.TabIndex = 11;
			this.btnSubscribeConnected.Text = "Subscribe to Connected";
			this.btnSubscribeConnected.UseVisualStyleBackColor = true;
			this.btnSubscribeConnected.Click += new System.EventHandler(this.btnSubscribeConnected_Click);
			// 
			// btnUnsubscribeConnected
			// 
			this.btnUnsubscribeConnected.Location = new System.Drawing.Point(182, 155);
			this.btnUnsubscribeConnected.Name = "btnUnsubscribeConnected";
			this.btnUnsubscribeConnected.Size = new System.Drawing.Size(161, 23);
			this.btnUnsubscribeConnected.TabIndex = 12;
			this.btnUnsubscribeConnected.Text = "Unsubscribe to Connected";
			this.btnUnsubscribeConnected.UseVisualStyleBackColor = true;
			this.btnUnsubscribeConnected.Click += new System.EventHandler(this.btnUnsubscribeConnected_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(449, 281);
			this.Controls.Add(this.btnUnsubscribeConnected);
			this.Controls.Add(this.btnSubscribeConnected);
			this.Controls.Add(this.txtConnectedBots);
			this.Controls.Add(this.txtConnectedUsers);
			this.Controls.Add(this.lblConnectedBots);
			this.Controls.Add(this.lblConnectedUsers);
			this.Controls.Add(this.txtAPISecret);
			this.Controls.Add(this.txtAPIKey);
			this.Controls.Add(this.lblAPISecret);
			this.Controls.Add(this.lblAPIKey);
			this.Controls.Add(this.chkAuthenticate);
			this.Controls.Add(this.cboWebsocketURL);
			this.Controls.Add(this.btnConnect);
			this.Name = "Form1";
			this.Text = "DreamingLambos.com - Websocket Connected";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;

		}

		#endregion

		private System.Windows.Forms.Button btnConnect;
		private System.Windows.Forms.ComboBox cboWebsocketURL;
		private System.Windows.Forms.CheckBox chkAuthenticate;
		private System.Windows.Forms.Label lblAPIKey;
		private System.Windows.Forms.Label lblAPISecret;
		private System.Windows.Forms.TextBox txtAPIKey;
		private System.Windows.Forms.TextBox txtAPISecret;
		private System.Windows.Forms.Label lblConnectedUsers;
		private System.Windows.Forms.Label lblConnectedBots;
		private System.Windows.Forms.TextBox txtConnectedUsers;
		private System.Windows.Forms.TextBox txtConnectedBots;
		private System.Windows.Forms.Button btnSubscribeConnected;
		private System.Windows.Forms.Button btnUnsubscribeConnected;
	}
}

