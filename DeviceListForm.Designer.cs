namespace TosAssist
{
    partial class DeviceListForm
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
            this.deviceList = new System.Windows.Forms.ListBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.UseTCPButton = new System.Windows.Forms.Button();
            this.RememberDeviceCheckbox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ViewTCPButton = new System.Windows.Forms.Button();
            this.ViewWinpcapButton = new System.Windows.Forms.Button();
            this.ConnectionOptionTab = new System.Windows.Forms.TabControl();
            this.WinPcapTab = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.TCPTab = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.ConnectionOptionTab.SuspendLayout();
            this.WinPcapTab.SuspendLayout();
            this.TCPTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // deviceList
            // 
            this.deviceList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.deviceList.FormattingEnabled = true;
            this.deviceList.Location = new System.Drawing.Point(6, 78);
            this.deviceList.Name = "deviceList";
            this.deviceList.Size = new System.Drawing.Size(379, 264);
            this.deviceList.TabIndex = 0;
            this.deviceList.SelectedIndexChanged += new System.EventHandler(this.deviceList_SelectedIndexChanged);
            this.deviceList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.deviceList_MouseDoubleClick);
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(6, 348);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(88, 30);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(100, 348);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(77, 30);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // UseTCPButton
            // 
            this.UseTCPButton.Location = new System.Drawing.Point(9, 348);
            this.UseTCPButton.Name = "UseTCPButton";
            this.UseTCPButton.Size = new System.Drawing.Size(123, 30);
            this.UseTCPButton.TabIndex = 3;
            this.UseTCPButton.Text = "Start";
            this.UseTCPButton.UseVisualStyleBackColor = true;
            this.UseTCPButton.Click += new System.EventHandler(this.UseTCPButton_Click);
            // 
            // RememberDeviceCheckbox
            // 
            this.RememberDeviceCheckbox.AutoSize = true;
            this.RememberDeviceCheckbox.Location = new System.Drawing.Point(12, 488);
            this.RememberDeviceCheckbox.Name = "RememberDeviceCheckbox";
            this.RememberDeviceCheckbox.Size = new System.Drawing.Size(77, 17);
            this.RememberDeviceCheckbox.TabIndex = 4;
            this.RememberDeviceCheckbox.Text = "Remember";
            this.RememberDeviceCheckbox.UseVisualStyleBackColor = true;
            this.RememberDeviceCheckbox.CheckedChanged += new System.EventHandler(this.RememberDeviceCheckbox_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ViewTCPButton);
            this.groupBox1.Controls.Add(this.ViewWinpcapButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(389, 58);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection Type";
            // 
            // ViewTCPButton
            // 
            this.ViewTCPButton.Location = new System.Drawing.Point(141, 19);
            this.ViewTCPButton.Name = "ViewTCPButton";
            this.ViewTCPButton.Size = new System.Drawing.Size(122, 33);
            this.ViewTCPButton.TabIndex = 1;
            this.ViewTCPButton.Text = "TCP";
            this.ViewTCPButton.UseVisualStyleBackColor = true;
            this.ViewTCPButton.Click += new System.EventHandler(this.ViewTCPButton_Click);
            // 
            // ViewWinpcapButton
            // 
            this.ViewWinpcapButton.Location = new System.Drawing.Point(13, 19);
            this.ViewWinpcapButton.Name = "ViewWinpcapButton";
            this.ViewWinpcapButton.Size = new System.Drawing.Size(122, 33);
            this.ViewWinpcapButton.TabIndex = 0;
            this.ViewWinpcapButton.Text = "WinPcap\r";
            this.ViewWinpcapButton.UseVisualStyleBackColor = true;
            this.ViewWinpcapButton.Click += new System.EventHandler(this.ViewWinpcapButton_Click);
            // 
            // ConnectionOptionTab
            // 
            this.ConnectionOptionTab.Controls.Add(this.WinPcapTab);
            this.ConnectionOptionTab.Controls.Add(this.TCPTab);
            this.ConnectionOptionTab.Location = new System.Drawing.Point(12, 76);
            this.ConnectionOptionTab.Name = "ConnectionOptionTab";
            this.ConnectionOptionTab.SelectedIndex = 0;
            this.ConnectionOptionTab.Size = new System.Drawing.Size(403, 410);
            this.ConnectionOptionTab.TabIndex = 6;
            // 
            // WinPcapTab
            // 
            this.WinPcapTab.Controls.Add(this.label1);
            this.WinPcapTab.Controls.Add(this.deviceList);
            this.WinPcapTab.Controls.Add(this.buttonOk);
            this.WinPcapTab.Controls.Add(this.buttonCancel);
            this.WinPcapTab.Location = new System.Drawing.Point(4, 22);
            this.WinPcapTab.Name = "WinPcapTab";
            this.WinPcapTab.Padding = new System.Windows.Forms.Padding(3);
            this.WinPcapTab.Size = new System.Drawing.Size(395, 384);
            this.WinPcapTab.TabIndex = 0;
            this.WinPcapTab.Text = "WinPCap";
            this.WinPcapTab.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 26);
            this.label1.TabIndex = 5;
            this.label1.Text = "-Requires WinPcap to use\r\n-Cannot send data. Only Receive.\r\n";
            // 
            // TCPTab
            // 
            this.TCPTab.Controls.Add(this.label2);
            this.TCPTab.Controls.Add(this.UseTCPButton);
            this.TCPTab.Location = new System.Drawing.Point(4, 22);
            this.TCPTab.Name = "TCPTab";
            this.TCPTab.Padding = new System.Windows.Forms.Padding(3);
            this.TCPTab.Size = new System.Drawing.Size(395, 384);
            this.TCPTab.TabIndex = 1;
            this.TCPTab.Text = "TCP";
            this.TCPTab.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(357, 52);
            this.label2.TabIndex = 4;
            this.label2.Text = "- Requires administrative privileges (Right click, select run as Administrator)\r\n" +
    "- Modifies Hosts file to intercept TCP traffic.\r\n\r\nPress Start, then run ToS as " +
    "you would normally.\r\n";
            // 
            // DeviceListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 507);
            this.Controls.Add(this.ConnectionOptionTab);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.RememberDeviceCheckbox);
            this.Name = "DeviceListForm";
            this.Text = "Select device";
            this.Load += new System.EventHandler(this.DeviceListForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.ConnectionOptionTab.ResumeLayout(false);
            this.WinPcapTab.ResumeLayout(false);
            this.WinPcapTab.PerformLayout();
            this.TCPTab.ResumeLayout(false);
            this.TCPTab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ListBox deviceList;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button UseTCPButton;
        private System.Windows.Forms.CheckBox RememberDeviceCheckbox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ViewWinpcapButton;
        private System.Windows.Forms.Button ViewTCPButton;
        private System.Windows.Forms.TabControl ConnectionOptionTab;
        private System.Windows.Forms.TabPage WinPcapTab;
        private System.Windows.Forms.TabPage TCPTab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

