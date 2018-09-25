using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TosAssist
{
    public partial class UserControl1 : UserControl
    {
        public int index = -1;

        public int roleId = -1;
        public string roleName = "role name";

        //people who have claimed this is their role, could be several
        public List<string> claimants = new List<string>();

        //if this role is random, it could be any role in this list
        public List<string> confirmedRolesList = new List<string>();
        

        public delegate void OnAddClaimantDelegate(int index);
        public event OnAddClaimantDelegate OnAddClaimant;

        public delegate void RemoveClaimantDelegate(int index);
        public event RemoveClaimantDelegate OnRemoveClaimant;
        
        public delegate void DeadDelegate(bool dead);
        public event DeadDelegate OnDead;

        public delegate void ConfirmedDelegate(bool confirmed);
        public event ConfirmedDelegate OnConfirmed;

        //all 15 player  names
        public List<string> playerNames = new List<string>();

        public bool isDead;
        public bool isConfirmed;


        public UserControl1()
        {
            InitializeComponent();
        }

        public UserControl1(int Index, int RoleID, string RoleName, List<string> PlayerNames)
        {
            InitializeComponent();
            index = Index;
            roleId = RoleID;
            roleName = RoleName;
            playerNames = PlayerNames;

            SetRoleName(roleName);

            
            claimantsListbox1.Items.Clear();

            if (ToSRoleList.instance.m_bucketToListMap[roleId] != null)
            {
                var roleListIndices = ToSRoleList.instance.m_bucketToListMap[roleId];

                for (int i = 0; i < roleListIndices.Length; i++)
                {
                    confirmedRolesList.Add(ToSRoleList.instance.m_roleIdToNameMap[roleListIndices[i]]);
                }
                for (int i = 0; i < confirmedRolesList.Count; i++)
                {
                    ConfirmedRoleCombo.Items.Add(confirmedRolesList[i]);
                }
            }
            else
            {
                confirmedRolesList.Add(ToSRoleList.instance.m_roleIdToNameMap[roleId]);
                ConfirmedRoleCombo.Items.Add(ToSRoleList.instance.m_roleIdToNameMap[roleId]);
                ConfirmedRoleCombo.SelectedIndex = 0;
            }
            
        }

        private void addClaimantButton1_Click(object sender, EventArgs e)
        {

        }

        public void AddClaimant(string name)
        {
            if (!claimants.Contains(name))
            {
                claimants.Add(name);
                claimantsListbox1.Items.Add(name);
            }
        }

        private void deadCheckbox1_CheckedChanged(object sender, EventArgs e)
        {
            isDead = deadCheckbox1.Checked;

            OnDead(isDead);

            if (isDead)
            {
                panel1.BackColor = Color.RosyBrown;
            }
            else
            {
                panel1.BackColor = Control.DefaultBackColor;
            }
        }

        private void confirmedCheckbox1_CheckedChanged(object sender, EventArgs e)
        {
            isConfirmed = confirmedCheckbox1.Checked;

            OnConfirmed(isConfirmed);

            if (isConfirmed)
            {
                panel1.BackColor = Color.SeaGreen;
            }
            else
            {
                panel1.BackColor = Control.DefaultBackColor;
            }
        }

        private void SetRoleName(string name)
        {
            roleNameText1.Text = "";
            var namesSplit = name.Split(' ');
            for (int i = 0; i < namesSplit.Length; i++)
            {
                roleNameText1.AppendText(namesSplit[i], GetColorFromRole(namesSplit[i]));
                roleNameText1.AppendText(" ");
            }
            //roleNameText1.Text = name;
        }


        public void ExternalSetDead(bool dead)
        {
            isDead = dead;
            if (isDead)
            {
                panel1.BackColor = Color.LightGray;
            }
            else
            {
                panel1.BackColor = Color.WhiteSmoke;
            }
        }
        public void ExternalSetConfirmed(bool confirmed)
        {
            isConfirmed = confirmed;
            if (isConfirmed)
            {
                panel1.BackColor = Color.SeaGreen;
            }
            else
            {
                panel1.BackColor = Color.WhiteSmoke;
            }
        }
        public void ExternalAddClaimant(int index)
        {
            claimantsListbox1.Items.Add(playerNames[index]);
        }
        public void ExternalRemoveClaimant(int index)
        {
            claimantsListbox1.Items.Remove(playerNames[index]);
        }

        private Color GetColorFromRole(string role)
        {
            try
            {
                if (role.ToLower() == "town")
                {
                    return System.Drawing.ColorTranslator.FromHtml(ToSRoleList.COLOR_Town);
                }
                else if (role.ToLower() == "mafia")
                {
                    return System.Drawing.ColorTranslator.FromHtml(ToSRoleList.COLOR_Mafia);
                }
                else if (role.ToLower() == "random" || role.ToLower() == "investigative" || role.ToLower() == "protective" || role.ToLower() == "support" || role.ToLower() == "evil" || role.ToLower() == "killing")
                {
                    return System.Drawing.ColorTranslator.FromHtml(ToSRoleList.COLOR_Random);
                }

                int pos = Array.IndexOf(ToSRoleList.instance.m_roleIdToNameMap, role);
                if (pos > -1)
                {
                    var roleColor = ToSRoleList.instance.m_roleIdToColorMap[pos];
                    return System.Drawing.ColorTranslator.FromHtml(roleColor);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
           

            return Color.Black;
        }
    }

}
