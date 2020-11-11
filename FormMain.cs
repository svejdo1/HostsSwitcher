using System;
using System.Globalization;
using System.Windows.Forms;
using Barbar.HostsSwitcher.Provider;
using System.Xml;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Drawing.Text;

namespace Barbar.HostsSwitcher 
{
    public partial class FormMain : Form
    {
        private readonly IHostProvider m_HostsProvider;

        public HostsProfile currentHosts;
        public HostsProfile selectedProfile;

        public List<HostsProfile> profiles = new List<HostsProfile>();

        public string appSettingsDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        public string appSettingsFilePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\HostsSwitcherProfiles.xml";


        private TextBox textBoxAddress;
        private TextBox textBoxRedir;
        private CheckBox isWWW;
        private CheckBox isLocalHost;
        private Control[] Editors;

        public FormMain()
        {
            InitializeComponent();

            m_HostsProvider = new HostProvider();
            quickSwitchToolStripMenuItem.DropDownItemClicked += new ToolStripItemClickedEventHandler(quickSwitchToolStripMenuItem_DropDownItemClicked);

            Text = string.Format("Hosts Switcher - v.{0}", typeof(FormMain).Assembly.GetName().Version);

            listLocked = true;
            if (File.Exists(appSettingsFilePath))
            {
                profiles = HostsProfile.readFromXML(appSettingsFilePath);
                currentHosts = HostsProfile.getCurrentProfile(profiles);
            }
            else
            {

                List<HostsProfile> profiles = new List<HostsProfile>();
                currentHosts = new HostsProfile();
                profiles.Add(currentHosts);
                HostsProfile.writeToSettingsXML(profiles);
            }
            initializeListView();

            selectedProfile = currentHosts;
            customizeHosts(selectedProfile);
            updateListBox();
            listView1.ItemChecked += new ItemCheckedEventHandler(listView_CheckedChanged);




            listView1.CheckBoxes = true;
            listView1.SubItemClicked += new ListViewEx.SubItemEventHandler(listView1_SubItemClicked);
            listView1.SubItemEndEditing += new ListViewEx.SubItemEndEditingEventHandler(listView1_SubItemEndEditing);
            listView1.DoubleClickActivation = false;



        }

        volatile bool listLocked = false;

        private void customizeHosts(HostsProfile hp)
        {
            listLocked = true;
            listView1.Items.Clear();
            int i = 1;

            foreach (Domain d in hp.domains)
            {
                ListViewItem a = new ListViewItem(new string[] { i.ToString(), d.useLocalhost.ToString(), d.alsoWWW.ToString(), d.redirectedAddress, d.domainToRedirect });
                if (d.isEnabled)
                {
                    a.BackColor = Color.PaleGreen;
                    a.ForeColor = Color.DarkGreen;
                    a.Checked = true;
                }
                else
                {
                    a.BackColor = Color.White;
                    a.ForeColor = Color.DarkGray;
                    a.Checked = false;
                }
                listView1.Items.Add(a);
                i++;
            }
            listLocked = false;
        }
        private void initializeListView()
        {
            listLocked = true;
            isLocalHost = new CheckBox();
            isLocalHost.Name = "isLocalHost";
            isLocalHost.Visible = false;
            isLocalHost.Location = new System.Drawing.Point(32, 152);
            isLocalHost.Size = new System.Drawing.Size(20, 20);
            isLocalHost.CheckedChanged += new EventHandler(control_CheckedChanged);




            isWWW = new CheckBox();
            isWWW.Name = "isWWW";
            isWWW.Visible = false;
            isWWW.Location = new System.Drawing.Point(32, 152);
            isWWW.Size = new System.Drawing.Size(20, 20);
            isWWW.CheckedChanged += new EventHandler(control_CheckedChanged);


            textBoxRedir = new TextBox();
            textBoxRedir.Location = new Point(-100, -100);

            textBoxAddress = new TextBox();
            textBoxAddress.Location = new Point(-100, -100);

            //this.Controls.Add(this.numericTrial);
            this.Controls.Add(this.isLocalHost);
            this.Controls.Add(this.isWWW);
            this.Controls.Add(this.textBoxRedir);
            this.Controls.Add(this.textBoxAddress);
            //this.Controls.Add(this.comboBoxMazeTo);

            //arrowBox = new Button();
            //arrowBox.BackgroundImage = Properties.Resources.LoadToIcon;
            //arrowBox.Enabled = false;





            Editors = new Control[] {null,
                                    isLocalHost,			// for column 3
                                    isWWW, //for Column 4
									textBoxRedir,		// for column 5
									textBoxAddress,	// for column 6
									};

            //ImageList listViewBG = new ImageList();
            //listViewBG.Images.Add(Properties.Resources.LoadToIcon);

            listView1.Items.Clear();
            //listView1.LargeImageList = listViewBG;
            //listView1.SmallImageList = listViewBG;

            listView1.Columns.Add("Enabled");
            listView1.Columns.Add("Local");
            listView1.Columns.Add("www");
            listView1.Columns.Add("Redirected");
            listView1.Columns.Add("Address");
            //listView1.Columns.Add("");
            listView1.Columns[0].Width = 60;
            listView1.Columns[1].Width = 55;
            listView1.Columns[2].Width = 45;
            listView1.Columns[3].Width = 125;
            //listView1.Columns[3].ImageIndex = 0;

            listView1.Columns[4].Width = 200;

            //listView1.Columns[6].Width = 5;
            listView1.View = View.Details;
            listLocked = false;
        }

        private void listView_CheckedChanged(object sender, System.EventArgs e)
        {
            if (!listLocked)
            {

                listView1.EndEditing(true);
                listView1_updateItems();
            }

        }

        private void control_CheckedChanged(object sender, System.EventArgs e)
        {
            CheckBox checkControl = (CheckBox)sender;
            if (!listLocked)
            {
                checkControl.Text = checkControl.Checked.ToString();
                listView1.EndEditing(true);
                listView1_updateItems();
            }

        }




        private string cleanURL(string inputUrl)
        {
            string cleaned = inputUrl.Replace(" ", "");
            return cleaned;
        }

        private void listView1_updateItems()
        {
            listLocked = true;
            int i = 0;
            //HostsProfile hp = getProfileByIndex(listBox_hosts.SelectedIndex);

            foreach (ListViewItem lvItem in listView1.Items)
            {
                if (lvItem != null)
                {
                    Domain d = new Domain(cleanURL(lvItem.SubItems[3].Text), cleanURL(lvItem.SubItems[4].Text));
                    d.isEnabled = lvItem.Checked;
                    d.useLocalhost = bool.Parse(lvItem.SubItems[1].Text);
                    d.alsoWWW = bool.Parse(lvItem.SubItems[2].Text);
                    selectedProfile.domains[i] = d;


                    if (lvItem.Checked)
                    {
                        lvItem.BackColor = Color.PaleGreen;
                        lvItem.ForeColor = Color.DarkGreen;
                    }
                    else
                    {
                        lvItem.BackColor = Color.White;
                        lvItem.ForeColor = Color.DarkGray;
                    }
                }

                i++;
            }
            profiles[listBox_hosts.SelectedIndex] = selectedProfile;
            listLocked = false;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView1.EndEditing(true);
            listView1_updateItems();
        }



        private void listView1_SubItemClicked(object sender, ListViewEx.SubItemEventArgs e)
        {

            listView1.StartEditing(Editors[e.SubItem], e.Item, e.SubItem);
        }

        private void listView1_SubItemEndEditing(object sender, ListViewEx.SubItemEndEditingEventArgs e)
        {
            listView1_updateItems();
        }

        private void updateListBox()
        {
            listBox_hosts.Items.Clear();
            quickSwitchToolStripMenuItem.DropDownItems.Clear();
            quickSwitchToolStripMenuItem.CheckOnClick = true;

            int i = 0;
            foreach (HostsProfile hp in profiles)
            {
                if (hp.isCurrent)
                {
                    listBox_hosts.Items.Add(hp.profileName + " (Current)");
                    quickSwitchToolStripMenuItem.DropDownItems.Add(hp.profileName);
                    quickSwitchToolStripMenuItem.DropDownItems[i].Enabled = false;
                    listBox_hosts.SelectedIndex = i;
                    quickSwitchToolStripMenuItem.DropDownItems[i].Name = i.ToString();
                }
                else
                {
                    listBox_hosts.Items.Add(hp.profileName);
                    quickSwitchToolStripMenuItem.DropDownItems.Add(hp.profileName);
                    quickSwitchToolStripMenuItem.DropDownItems[i].Enabled = true;
                    quickSwitchToolStripMenuItem.DropDownItems[i].Name = i.ToString();
                }
                i++;
            }


        }


        private void quickSwitchToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var clicked = e.ClickedItem.Text;
            if (!string.IsNullOrEmpty(clicked))
            {
                updateListBox();
                setCurrentByIndex(Int32.Parse(e.ClickedItem.Name));
                WriteHosts();
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Visible = false;
            }
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                WindowState = FormWindowState.Normal;
                this.Visible = true;
                this.Focus();
            }
        }

        private void LogInfo(string format, params object[] args)
        {
            txtLog.Text += string.Format(CultureInfo.InvariantCulture, format, args);
            txtLog.SelectionStart = txtLog.Text.Length;
            txtLog.ScrollToCaret();
        }


        private void WriteHosts()
        {
            m_HostsProvider.WriteHosts(currentHosts.toHosts());
            //lblHosts.Text = selectedItem;
            LogInfo("Written {0} to hosts\r\n", currentHosts.profileName);
        }

        private void menuStripExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuStripShow_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            this.Visible = true;
            this.Focus();
        }

        //private void listHosts_DoubleClick(object sender, EventArgs e) {
        //  if (listHosts.SelectedItem != null) {
        //    m_HostsProvider.ReplaceHosts((string)listHosts.SelectedItem);
        //    lblHosts.Text = (string)listHosts.SelectedItem;
        //    LogInfo("Copied {0} to hosts\r\n", listHosts.SelectedItem);
        //  }
        //}

  

        private void button_use_as_hosts_Click(object sender, EventArgs e)
        {
            setCurrentByIndex(listBox_hosts.SelectedIndex);
            HostsProfile.writeToSettingsXML(profiles);
            WriteHosts();
        }

        private HostsProfile getProfileByIndex(int index)
        {
            int i = 0;
            foreach (HostsProfile hp in profiles)
            {
                if (i == index)
                {
                    return hp;
                }
                i++;
            }
            return null;

        }

        private void button_copy_Click(object sender, EventArgs e)
        {
            HostsProfile hp = getProfileByIndex(listBox_hosts.SelectedIndex);
            var formCopy = new FormCopy(string.Format("Copy {0} to which file ?", hp.profileName),hp.profileName+"_Copy");
            var result = formCopy.ShowDialog(this);
            if (result == DialogResult.OK && !string.IsNullOrEmpty(formCopy.FileName))
            {
                if (checkForDuplicates(formCopy.FileName))
                {
                    MessageBox.Show("Error: '" + formCopy.FileName + "' is already an existing profile name");
                }
                else
                {

                    HostsProfile newHp = new HostsProfile();

                    foreach (Domain d in hp.domains)
                    {
                        newHp.domains.Add(d);
                    }

                    newHp.profileName = formCopy.FileName;
                    newHp.isCurrent = false;
                    profiles.Add(newHp);
                    updateListBox();
                        //m_HostsProvider.CopyHosts((string)listHosts.SelectedItem, formCopy.FileName);
                        //LogInfo("Copied {0} to {1}\r\n", listHosts.SelectedItem, formCopy.FileName);
                        //RefreshList();
                }
            }
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            HostsProfile hp = getProfileByIndex(listBox_hosts.SelectedIndex);
            //if (e.ClickedItem == btnDelete && listHosts.SelectedItem != null)
            //{
            if (hp.profileName != "Default" && MessageBox.Show(string.Format("Really delete {0} ?", hp.profileName), string.Empty, MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                if (hp.isCurrent)
                    setCurrentByIndex(0);
                profiles.RemoveAt(listBox_hosts.SelectedIndex);
                listBox_hosts.SelectedIndex = 0;

                //m_HostsProvider.DeleteHosts((string)listHosts.SelectedItem);
                //LogInfo("Deleted {0}\r\n", listHosts.SelectedItem);
                //RefreshList();
                updateListBox();
            }
            //}
        }

      
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void button_new_Click(object sender, EventArgs e)
        {
            var formCopy = new FormCopy("Enter new profile name");
            var result = formCopy.ShowDialog(this);
            if (result == DialogResult.OK && !string.IsNullOrEmpty(formCopy.FileName))
            {
                if(checkForDuplicates(formCopy.FileName))
                {
                    MessageBox.Show("Error: '"+formCopy.FileName+"' is already an existing profile name");
                }
                else
                {
                    HostsProfile newHp = new HostsProfile();
                    newHp.profileName = formCopy.FileName;
                    newHp.isCurrent = false;
                    profiles.Add(newHp);
                    //m_HostsProvider.CopyHosts((string)listHosts.SelectedItem, formCopy.FileName);
                    //LogInfo("Copied {0} to {1}\r\n", listHosts.SelectedItem, formCopy.FileName);
                    updateListBox();
                }
                
            }
        }

        private bool checkForDuplicates(string namecheck)
        {
            int i = 0;
            foreach (HostsProfile hp in profiles)
            {
                if (hp.profileName==namecheck)
                {
                    return true;
                }
                
                i++;
            }

            return false;
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button_copy_Click(null, e);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button_delete_Click(null, e);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HostsProfile.writeToSettingsXML(profiles);

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button_new_Click(sender, e);

        }

        private void setCurrentByIndex(int curID)
        {
            int i = 0;
            foreach (HostsProfile hp in profiles)
            {
                if (i == curID)
                {
                    hp.isCurrent = true;
                    currentHosts = hp;
                }
                else
                    hp.isCurrent = false;
                i++;
            }

            updateListBox();
        }



        private void listBox_hosts_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedProfile = getProfileByIndex(listBox_hosts.SelectedIndex);
            customizeHosts(selectedProfile);
        }

        private void button_add_domain_Click(object sender, EventArgs e)
        {
            //HostsProfile hp = getProfileByIndex(listBox_hosts.SelectedIndex);
            if (selectedProfile.profileName != "Default")
            {
                selectedProfile.domains.Add(new Domain("localhost", "theaddress.com"));
                customizeHosts(selectedProfile);
            }
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            HostsProfile.writeToSettingsXML(profiles);
        }

        private void button_removeDomain_Click(object sender, EventArgs e)
        {
            //HostsProfile hp = getProfileByIndex(listBox_hosts.SelectedIndex);
            if (selectedProfile.profileName != "Default")
            {
                int len = selectedProfile.domains.Count;

                for (int i = listView1.SelectedIndices.Count - 1; i >= 0; i--)
                {
                    selectedProfile.domains.RemoveAt(listView1.SelectedIndices[i]);
                }
                customizeHosts(selectedProfile);
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button_add_domain_Click(sender, e);
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button_removeDomain_Click(sender, e);
        }

        private void viewCurrentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_HostsProvider.LaunchEditor((string)"hosts");
        }

        private void openFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_HostsProvider.OpenFolder();
        }

    

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog a = new SaveFileDialog();
            a.Filter = "Exported Hosts Profiles (*.xml)|*.*";
            a.FilterIndex = 1;
            a.DefaultExt = ".xml";
            a.RestoreDirectory = true;


            if (a.ShowDialog() == DialogResult.OK)
            {
                HostsProfile.writeToSettingsXML(profiles, a.FileName);
            }
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog a = new OpenFileDialog();
            a.Filter = "Exported Hosts Profiles (*.xml)|*.*";
            a.FilterIndex = 1;
            a.RestoreDirectory = true;
            if (a.ShowDialog() == DialogResult.OK)
            {
                profiles = HostsProfile.readFromXML(a.FileName);
                currentHosts = HostsProfile.getCurrentProfile(profiles);

                selectedProfile = currentHosts;
                customizeHosts(selectedProfile);
                updateListBox();
            }
        }

        private void button_add_multiple_Click(object sender, EventArgs e)
        {
            TextBox inputHosts = new TextBox();
            inputHosts.Dock = DockStyle.Fill;
            inputHosts.BorderStyle = BorderStyle.None;
            inputHosts.Multiline = true;
            //inputHosts.Size.Y = 600;

            Button okButt = new Button();
            okButt.Text = "Import";
            okButt.DialogResult = DialogResult.OK;
            okButt.Dock = DockStyle.Bottom;

            Button canButt = new Button();
            canButt.Text = "Cancel";
            canButt.DialogResult = DialogResult.Cancel;
            canButt.Dock = DockStyle.Bottom;

            Form InputMessageBox = new Form();
            InputMessageBox.Text = "Import Hosts";
            InputMessageBox.StartPosition = FormStartPosition.CenterScreen;

            InputMessageBox.Controls.Add(inputHosts);
            InputMessageBox.Controls.Add(okButt);
            InputMessageBox.Controls.Add(canButt);
            if (InputMessageBox.ShowDialog() == DialogResult.OK)
            {
                importHOSTS(inputHosts.Text);
            }

        }

        private void importHOSTS(string text)
        {
            if (selectedProfile.profileName != "Default")
            {
                using (StringReader reader = new StringReader(text))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        
                        String[] preCommentParts = line.Split('#');
                        line = preCommentParts[0];
                        line.Replace(" ", "\t");
                        String[] parts = line.Split('\t');
                        if(parts.Length>1&&parts[0].Length>1&&parts[1].Length>1)
                            selectedProfile.domains.Add(new Domain(parts[0], parts[1]));// Do something with the line
                        else if(parts.Length>0&&parts[0].Length>1)
                            selectedProfile.domains.Add(new Domain("localhost", parts[0]));// Do something with the line
                    }
                    customizeHosts(selectedProfile);
                }
                //
            }
        }
    }
}
