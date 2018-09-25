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
            this.SuspendLayout();
            // 
            // deviceList
            // 
            this.deviceList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deviceList.FormattingEnabled = true;
            this.deviceList.Location = new System.Drawing.Point(12, 13);
            this.deviceList.Name = "deviceList";
            this.deviceList.Size = new System.Drawing.Size(458, 212);
            this.deviceList.TabIndex = 0;
            this.deviceList.SelectedIndexChanged += new System.EventHandler(this.deviceList_SelectedIndexChanged);
            this.deviceList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.deviceList_MouseDoubleClick);
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(12, 248);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(88, 30);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(106, 248);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(77, 30);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // UseTCPButton
            // 
            this.UseTCPButton.Location = new System.Drawing.Point(347, 248);
            this.UseTCPButton.Name = "UseTCPButton";
            this.UseTCPButton.Size = new System.Drawing.Size(123, 30);
            this.UseTCPButton.TabIndex = 3;
            this.UseTCPButton.Text = "Use TCP Instead";
            this.UseTCPButton.UseVisualStyleBackColor = true;
            this.UseTCPButton.Click += new System.EventHandler(this.UseTCPButton_Click);
            // 
            // RememberDeviceCheckbox
            // 
            this.RememberDeviceCheckbox.AutoSize = true;
            this.RememberDeviceCheckbox.Location = new System.Drawing.Point(189, 256);
            this.RememberDeviceCheckbox.Name = "RememberDeviceCheckbox";
            this.RememberDeviceCheckbox.Size = new System.Drawing.Size(77, 17);
            this.RememberDeviceCheckbox.TabIndex = 4;
            this.RememberDeviceCheckbox.Text = "Remember";
            this.RememberDeviceCheckbox.UseVisualStyleBackColor = true;
            this.RememberDeviceCheckbox.CheckedChanged += new System.EventHandler(this.RememberDeviceCheckbox_CheckedChanged);
            // 
            // DeviceListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 290);
            this.Controls.Add(this.RememberDeviceCheckbox);
            this.Controls.Add(this.UseTCPButton);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.deviceList);
            this.Name = "DeviceListForm";
            this.Text = "Select device";
            this.Load += new System.EventHandler(this.DeviceListForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ListBox deviceList;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button UseTCPButton;
        private System.Windows.Forms.CheckBox RememberDeviceCheckbox;
    }
}

