namespace TosAssist
{
    partial class UserControl1
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.ConfirmedRoleCombo = new System.Windows.Forms.ComboBox();
            this.confirmedCheckbox1 = new System.Windows.Forms.CheckBox();
            this.deadCheckbox1 = new System.Windows.Forms.CheckBox();
            this.addClaimantButton1 = new System.Windows.Forms.Button();
            this.removeClaimantButton1 = new System.Windows.Forms.Button();
            this.roleNameText1 = new System.Windows.Forms.RichTextBox();
            this.claimantsListbox1 = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ConfirmedRoleCombo);
            this.panel1.Controls.Add(this.confirmedCheckbox1);
            this.panel1.Controls.Add(this.deadCheckbox1);
            this.panel1.Controls.Add(this.addClaimantButton1);
            this.panel1.Controls.Add(this.removeClaimantButton1);
            this.panel1.Controls.Add(this.roleNameText1);
            this.panel1.Controls.Add(this.claimantsListbox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(385, 42);
            this.panel1.TabIndex = 2;
            // 
            // ConfirmedRoleCombo
            // 
            this.ConfirmedRoleCombo.FormattingEnabled = true;
            this.ConfirmedRoleCombo.Location = new System.Drawing.Point(228, 3);
            this.ConfirmedRoleCombo.Name = "ConfirmedRoleCombo";
            this.ConfirmedRoleCombo.Size = new System.Drawing.Size(82, 21);
            this.ConfirmedRoleCombo.TabIndex = 8;
            // 
            // confirmedCheckbox1
            // 
            this.confirmedCheckbox1.AutoSize = true;
            this.confirmedCheckbox1.Location = new System.Drawing.Point(316, 22);
            this.confirmedCheckbox1.Name = "confirmedCheckbox1";
            this.confirmedCheckbox1.Size = new System.Drawing.Size(73, 17);
            this.confirmedCheckbox1.TabIndex = 7;
            this.confirmedCheckbox1.Text = "Confirmed";
            this.confirmedCheckbox1.UseVisualStyleBackColor = true;
            this.confirmedCheckbox1.CheckedChanged += new System.EventHandler(this.confirmedCheckbox1_CheckedChanged);
            // 
            // deadCheckbox1
            // 
            this.deadCheckbox1.AutoSize = true;
            this.deadCheckbox1.Location = new System.Drawing.Point(316, 2);
            this.deadCheckbox1.Name = "deadCheckbox1";
            this.deadCheckbox1.Size = new System.Drawing.Size(52, 17);
            this.deadCheckbox1.TabIndex = 6;
            this.deadCheckbox1.Text = "Dead";
            this.deadCheckbox1.UseVisualStyleBackColor = true;
            this.deadCheckbox1.CheckedChanged += new System.EventHandler(this.deadCheckbox1_CheckedChanged);
            // 
            // addClaimantButton1
            // 
            this.addClaimantButton1.Location = new System.Drawing.Point(204, 0);
            this.addClaimantButton1.Margin = new System.Windows.Forms.Padding(1);
            this.addClaimantButton1.Name = "addClaimantButton1";
            this.addClaimantButton1.Size = new System.Drawing.Size(20, 20);
            this.addClaimantButton1.TabIndex = 4;
            this.addClaimantButton1.Text = "+";
            this.addClaimantButton1.UseVisualStyleBackColor = true;
            this.addClaimantButton1.Click += new System.EventHandler(this.addClaimantButton1_Click);
            // 
            // removeClaimantButton1
            // 
            this.removeClaimantButton1.Location = new System.Drawing.Point(204, 19);
            this.removeClaimantButton1.Margin = new System.Windows.Forms.Padding(1);
            this.removeClaimantButton1.Name = "removeClaimantButton1";
            this.removeClaimantButton1.Size = new System.Drawing.Size(20, 20);
            this.removeClaimantButton1.TabIndex = 5;
            this.removeClaimantButton1.Text = "-";
            this.removeClaimantButton1.UseVisualStyleBackColor = true;
            // 
            // roleNameText1
            // 
            this.roleNameText1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roleNameText1.Location = new System.Drawing.Point(3, 3);
            this.roleNameText1.Name = "roleNameText1";
            this.roleNameText1.ReadOnly = true;
            this.roleNameText1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.roleNameText1.Size = new System.Drawing.Size(100, 34);
            this.roleNameText1.TabIndex = 2;
            this.roleNameText1.Text = "Town Investigative";
            this.roleNameText1.WordWrap = false;
            // 
            // claimantsListbox1
            // 
            this.claimantsListbox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.claimantsListbox1.FormattingEnabled = true;
            this.claimantsListbox1.ItemHeight = 12;
            this.claimantsListbox1.Items.AddRange(new object[] {
            "Claimant 1",
            "Claimant 2",
            "Claimant 3"});
            this.claimantsListbox1.Location = new System.Drawing.Point(107, -1);
            this.claimantsListbox1.Margin = new System.Windows.Forms.Padding(1);
            this.claimantsListbox1.Name = "claimantsListbox1";
            this.claimantsListbox1.Size = new System.Drawing.Size(95, 40);
            this.claimantsListbox1.TabIndex = 3;
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(385, 42);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox ConfirmedRoleCombo;
        private System.Windows.Forms.CheckBox confirmedCheckbox1;
        private System.Windows.Forms.CheckBox deadCheckbox1;
        private System.Windows.Forms.Button addClaimantButton1;
        private System.Windows.Forms.Button removeClaimantButton1;
        private System.Windows.Forms.RichTextBox roleNameText1;
        private System.Windows.Forms.ListBox claimantsListbox1;
    }
}
