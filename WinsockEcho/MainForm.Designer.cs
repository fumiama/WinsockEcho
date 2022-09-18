
namespace WinsockEcho
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBoxLocalProp = new System.Windows.Forms.GroupBox();
            this.buttonLocalReceive = new System.Windows.Forms.Button();
            this.textBoxLocalListen = new System.Windows.Forms.TextBox();
            this.buttonLocalBind = new System.Windows.Forms.Button();
            this.labelLocalSocket = new System.Windows.Forms.Label();
            this.textBoxLocalSocket = new System.Windows.Forms.TextBox();
            this.textBoxLocalPort = new System.Windows.Forms.TextBox();
            this.labelLocalPort = new System.Windows.Forms.Label();
            this.labelLocalIP = new System.Windows.Forms.Label();
            this.textBoxLocalIP = new System.Windows.Forms.TextBox();
            this.groupBoxRemoteProp = new System.Windows.Forms.GroupBox();
            this.chartRemoteDelay = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ButtonRemotePing = new System.Windows.Forms.Button();
            this.labelRemoteSocket = new System.Windows.Forms.Label();
            this.textBoxRemoteDelay = new System.Windows.Forms.TextBox();
            this.textBoxRemotePort = new System.Windows.Forms.TextBox();
            this.labelRemotePort = new System.Windows.Forms.Label();
            this.labelRemoteIP = new System.Windows.Forms.Label();
            this.textBoxRemoteIP = new System.Windows.Forms.TextBox();
            this.groupBoxLocalProp.SuspendLayout();
            this.groupBoxRemoteProp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartRemoteDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxLocalProp
            // 
            this.groupBoxLocalProp.AutoSize = true;
            this.groupBoxLocalProp.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxLocalProp.Controls.Add(this.buttonLocalReceive);
            this.groupBoxLocalProp.Controls.Add(this.textBoxLocalListen);
            this.groupBoxLocalProp.Controls.Add(this.buttonLocalBind);
            this.groupBoxLocalProp.Controls.Add(this.labelLocalSocket);
            this.groupBoxLocalProp.Controls.Add(this.textBoxLocalSocket);
            this.groupBoxLocalProp.Controls.Add(this.textBoxLocalPort);
            this.groupBoxLocalProp.Controls.Add(this.labelLocalPort);
            this.groupBoxLocalProp.Controls.Add(this.labelLocalIP);
            this.groupBoxLocalProp.Controls.Add(this.textBoxLocalIP);
            this.groupBoxLocalProp.Font = new System.Drawing.Font("Meiryo UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxLocalProp.Location = new System.Drawing.Point(19, 19);
            this.groupBoxLocalProp.Name = "groupBoxLocalProp";
            this.groupBoxLocalProp.Size = new System.Drawing.Size(661, 372);
            this.groupBoxLocalProp.TabIndex = 0;
            this.groupBoxLocalProp.TabStop = false;
            this.groupBoxLocalProp.Text = "Local Properties";
            // 
            // buttonLocalReceive
            // 
            this.buttonLocalReceive.Location = new System.Drawing.Point(493, 230);
            this.buttonLocalReceive.Name = "buttonLocalReceive";
            this.buttonLocalReceive.Size = new System.Drawing.Size(145, 60);
            this.buttonLocalReceive.TabIndex = 8;
            this.buttonLocalReceive.Text = "receive";
            this.buttonLocalReceive.UseVisualStyleBackColor = true;
            this.buttonLocalReceive.Click += new System.EventHandler(this.ButtonLocalReceive_Click);
            // 
            // textBoxLocalListen
            // 
            this.textBoxLocalListen.AcceptsReturn = true;
            this.textBoxLocalListen.Font = new System.Drawing.Font("Meiryo UI", 6.375F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxLocalListen.Location = new System.Drawing.Point(29, 191);
            this.textBoxLocalListen.Multiline = true;
            this.textBoxLocalListen.Name = "textBoxLocalListen";
            this.textBoxLocalListen.ReadOnly = true;
            this.textBoxLocalListen.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLocalListen.Size = new System.Drawing.Size(440, 139);
            this.textBoxLocalListen.TabIndex = 7;
            // 
            // buttonLocalBind
            // 
            this.buttonLocalBind.Location = new System.Drawing.Point(339, 125);
            this.buttonLocalBind.Name = "buttonLocalBind";
            this.buttonLocalBind.Size = new System.Drawing.Size(296, 60);
            this.buttonLocalBind.TabIndex = 6;
            this.buttonLocalBind.Text = "bind";
            this.buttonLocalBind.UseVisualStyleBackColor = true;
            this.buttonLocalBind.Click += new System.EventHandler(this.ButtonLocalBind_Click);
            // 
            // labelLocalSocket
            // 
            this.labelLocalSocket.AutoSize = true;
            this.labelLocalSocket.Location = new System.Drawing.Point(23, 130);
            this.labelLocalSocket.Name = "labelLocalSocket";
            this.labelLocalSocket.Size = new System.Drawing.Size(126, 36);
            this.labelLocalSocket.TabIndex = 5;
            this.labelLocalSocket.Text = "SOCKET";
            // 
            // textBoxLocalSocket
            // 
            this.textBoxLocalSocket.Location = new System.Drawing.Point(155, 127);
            this.textBoxLocalSocket.Name = "textBoxLocalSocket";
            this.textBoxLocalSocket.ReadOnly = true;
            this.textBoxLocalSocket.Size = new System.Drawing.Size(148, 43);
            this.textBoxLocalSocket.TabIndex = 4;
            // 
            // textBoxLocalPort
            // 
            this.textBoxLocalPort.Location = new System.Drawing.Point(469, 59);
            this.textBoxLocalPort.Name = "textBoxLocalPort";
            this.textBoxLocalPort.Size = new System.Drawing.Size(166, 43);
            this.textBoxLocalPort.TabIndex = 3;
            // 
            // labelLocalPort
            // 
            this.labelLocalPort.AutoSize = true;
            this.labelLocalPort.Location = new System.Drawing.Point(391, 62);
            this.labelLocalPort.Name = "labelLocalPort";
            this.labelLocalPort.Size = new System.Drawing.Size(72, 36);
            this.labelLocalPort.TabIndex = 2;
            this.labelLocalPort.Text = "port";
            // 
            // labelLocalIP
            // 
            this.labelLocalIP.AutoSize = true;
            this.labelLocalIP.Location = new System.Drawing.Point(23, 62);
            this.labelLocalIP.Name = "labelLocalIP";
            this.labelLocalIP.Size = new System.Drawing.Size(43, 36);
            this.labelLocalIP.TabIndex = 1;
            this.labelLocalIP.Text = "IP";
            // 
            // textBoxLocalIP
            // 
            this.textBoxLocalIP.Location = new System.Drawing.Point(84, 59);
            this.textBoxLocalIP.Name = "textBoxLocalIP";
            this.textBoxLocalIP.Size = new System.Drawing.Size(293, 43);
            this.textBoxLocalIP.TabIndex = 0;
            // 
            // groupBoxRemoteProp
            // 
            this.groupBoxRemoteProp.AutoSize = true;
            this.groupBoxRemoteProp.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxRemoteProp.Controls.Add(this.chartRemoteDelay);
            this.groupBoxRemoteProp.Controls.Add(this.ButtonRemotePing);
            this.groupBoxRemoteProp.Controls.Add(this.labelRemoteSocket);
            this.groupBoxRemoteProp.Controls.Add(this.textBoxRemoteDelay);
            this.groupBoxRemoteProp.Controls.Add(this.textBoxRemotePort);
            this.groupBoxRemoteProp.Controls.Add(this.labelRemotePort);
            this.groupBoxRemoteProp.Controls.Add(this.labelRemoteIP);
            this.groupBoxRemoteProp.Controls.Add(this.textBoxRemoteIP);
            this.groupBoxRemoteProp.Font = new System.Drawing.Font("Meiryo UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxRemoteProp.Location = new System.Drawing.Point(19, 419);
            this.groupBoxRemoteProp.Name = "groupBoxRemoteProp";
            this.groupBoxRemoteProp.Size = new System.Drawing.Size(661, 585);
            this.groupBoxRemoteProp.TabIndex = 9;
            this.groupBoxRemoteProp.TabStop = false;
            this.groupBoxRemoteProp.Text = "Remote Properties";
            // 
            // chartRemoteDelay
            // 
            chartArea2.Name = "ChartArea1";
            this.chartRemoteDelay.ChartAreas.Add(chartArea2);
            legend2.DockedToChartArea = "ChartArea1";
            legend2.Enabled = false;
            legend2.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Column;
            legend2.Name = "Legend1";
            this.chartRemoteDelay.Legends.Add(legend2);
            this.chartRemoteDelay.Location = new System.Drawing.Point(29, 188);
            this.chartRemoteDelay.Name = "chartRemoteDelay";
            series2.ChartArea = "ChartArea1";
            series2.IsVisibleInLegend = false;
            series2.Label = "#VAL";
            series2.Legend = "Legend1";
            series2.Name = "Delay(ms)";
            this.chartRemoteDelay.Series.Add(series2);
            this.chartRemoteDelay.Size = new System.Drawing.Size(606, 355);
            this.chartRemoteDelay.TabIndex = 9;
            this.chartRemoteDelay.Text = "delay";
            // 
            // ButtonRemotePing
            // 
            this.ButtonRemotePing.Location = new System.Drawing.Point(339, 122);
            this.ButtonRemotePing.Name = "ButtonRemotePing";
            this.ButtonRemotePing.Size = new System.Drawing.Size(299, 60);
            this.ButtonRemotePing.TabIndex = 8;
            this.ButtonRemotePing.Text = "ping";
            this.ButtonRemotePing.UseVisualStyleBackColor = true;
            this.ButtonRemotePing.Click += new System.EventHandler(this.ButtonRemotePing_Click);
            // 
            // labelRemoteSocket
            // 
            this.labelRemoteSocket.AutoSize = true;
            this.labelRemoteSocket.Location = new System.Drawing.Point(23, 130);
            this.labelRemoteSocket.Name = "labelRemoteSocket";
            this.labelRemoteSocket.Size = new System.Drawing.Size(152, 36);
            this.labelRemoteSocket.TabIndex = 5;
            this.labelRemoteSocket.Text = "delay(ms)";
            // 
            // textBoxRemoteDelay
            // 
            this.textBoxRemoteDelay.Location = new System.Drawing.Point(181, 127);
            this.textBoxRemoteDelay.Name = "textBoxRemoteDelay";
            this.textBoxRemoteDelay.ReadOnly = true;
            this.textBoxRemoteDelay.Size = new System.Drawing.Size(122, 43);
            this.textBoxRemoteDelay.TabIndex = 4;
            // 
            // textBoxRemotePort
            // 
            this.textBoxRemotePort.Location = new System.Drawing.Point(469, 59);
            this.textBoxRemotePort.Name = "textBoxRemotePort";
            this.textBoxRemotePort.Size = new System.Drawing.Size(166, 43);
            this.textBoxRemotePort.TabIndex = 3;
            // 
            // labelRemotePort
            // 
            this.labelRemotePort.AutoSize = true;
            this.labelRemotePort.Location = new System.Drawing.Point(391, 62);
            this.labelRemotePort.Name = "labelRemotePort";
            this.labelRemotePort.Size = new System.Drawing.Size(72, 36);
            this.labelRemotePort.TabIndex = 2;
            this.labelRemotePort.Text = "port";
            // 
            // labelRemoteIP
            // 
            this.labelRemoteIP.AutoSize = true;
            this.labelRemoteIP.Location = new System.Drawing.Point(23, 62);
            this.labelRemoteIP.Name = "labelRemoteIP";
            this.labelRemoteIP.Size = new System.Drawing.Size(43, 36);
            this.labelRemoteIP.TabIndex = 1;
            this.labelRemoteIP.Text = "IP";
            // 
            // textBoxRemoteIP
            // 
            this.textBoxRemoteIP.Location = new System.Drawing.Point(84, 59);
            this.textBoxRemoteIP.Name = "textBoxRemoteIP";
            this.textBoxRemoteIP.Size = new System.Drawing.Size(293, 43);
            this.textBoxRemoteIP.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = global::WinsockEcho.Properties.Resources.meguru;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1367, 1023);
            this.Controls.Add(this.groupBoxRemoteProp);
            this.Controls.Add(this.groupBoxLocalProp);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = global::WinsockEcho.Properties.Resources.splash_flower;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(16);
            this.Text = "WinsockEcho";
            this.groupBoxLocalProp.ResumeLayout(false);
            this.groupBoxLocalProp.PerformLayout();
            this.groupBoxRemoteProp.ResumeLayout(false);
            this.groupBoxRemoteProp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartRemoteDelay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxLocalProp;
        private System.Windows.Forms.TextBox textBoxLocalIP;
        private System.Windows.Forms.Label labelLocalIP;
        private System.Windows.Forms.Label labelLocalPort;
        private System.Windows.Forms.TextBox textBoxLocalPort;
        private System.Windows.Forms.Label labelLocalSocket;
        private System.Windows.Forms.TextBox textBoxLocalSocket;
        private System.Windows.Forms.Button buttonLocalBind;
        private System.Windows.Forms.Button buttonLocalReceive;
        private System.Windows.Forms.TextBox textBoxLocalListen;
        private System.Windows.Forms.GroupBox groupBoxRemoteProp;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRemoteDelay;
        private System.Windows.Forms.Button ButtonRemotePing;
        private System.Windows.Forms.Label labelRemoteSocket;
        private System.Windows.Forms.TextBox textBoxRemoteDelay;
        private System.Windows.Forms.TextBox textBoxRemotePort;
        private System.Windows.Forms.Label labelRemotePort;
        private System.Windows.Forms.Label labelRemoteIP;
        private System.Windows.Forms.TextBox textBoxRemoteIP;
    }
}

