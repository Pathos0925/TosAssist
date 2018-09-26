namespace TosAssist
{
    partial class AddClaimantForm
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
            this.claimantList = new System.Windows.Forms.ListBox();
            this.addButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // claimantList
            // 
            this.claimantList.FormattingEnabled = true;
            this.claimantList.Location = new System.Drawing.Point(12, 12);
            this.claimantList.Name = "claimantList";
            this.claimantList.Size = new System.Drawing.Size(120, 173);
            this.claimantList.TabIndex = 0;
            this.claimantList.SelectedIndexChanged += new System.EventHandler(this.claimantList_SelectedIndexChanged);
            this.claimantList.DoubleClick += new System.EventHandler(this.claimantList_DoubleClick);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(12, 191);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // AddClaimantForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(147, 226);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.claimantList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddClaimantForm";
            this.Text = "Add Claimant";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox claimantList;
        private System.Windows.Forms.Button addButton;
    }
}