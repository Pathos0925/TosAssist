using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TosAssist
{
    public partial class AddClaimantForm : Form
    {
        List<string> players = new List<string>();


        public delegate void CaimantSelectedDelegate(int index);
        public event CaimantSelectedDelegate OnSelected;

        public AddClaimantForm()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (claimantList.SelectedIndex > -1)
            {
                try
                {
                    OnSelected(claimantList.SelectedIndex);
                    this.Hide();
                }
                catch(Exception er)
                {

                }
            }
        }

        public void AddPlayers(List<string> Players)
        {
            players = Players;
            claimantList.Items.Clear();
            foreach (string player in players)
            {
                claimantList.Items.Add(player);
            }
        }

        private void claimantList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void claimantList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                OnSelected(claimantList.SelectedIndex);
                this.Hide();
            }
            catch (Exception er)
            {

            }
        }
    }
}
