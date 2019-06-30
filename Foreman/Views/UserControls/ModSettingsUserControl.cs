﻿using Foreman.Models.ControlModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Foreman.Views.UserControls
{
    public partial class ModSettingsUserControl : UserControl, IModSettingsUserControl
    {
        public ModSettingsUserControl()
        {
            InitializeComponent();
        }

        public event EventHandler DirectoryButtonPressed;
        public event EventHandler DirectoryChanged;
        public event EventHandler RadioButtonChanged;
        public event EventHandler SelectedModChanged;
        public event EventHandler CheckedModsChanged;

        public string InfoLabel
        {
            set => labelInfo.Text = value;
        }

        public string InfoValue
        {
            set => labelInfoValue.Text = value;
        }

        public string DirectoryLabel
        {
            set => labelDirectory.Text = value;
        }

        public string SelectedDirectory
        {
            get
            {
                return comboBoxSelectDirectory.Text;
            }
            set
            {
                comboBoxSelectDirectory.Text = value;
            }
        }

        public string[] Directories
        {
            set
            {
                comboBoxSelectDirectory.Items.Clear();
                comboBoxSelectDirectory.Items.AddRange(value);
            }
        }

        public bool RadioUseModListSelected
        {
            get
            {
                return radioButtonModList.Checked;
            }
            set
            {
                if (value)
                {
                    radioButtonModList.Checked = value;
                }
                else
                {
                    radioButtonCustom.Checked = value;
                }
            }
        }

        public CheckedModListBoxItem[] ModList
        {
            get
            {
                List<CheckedModListBoxItem> modItems = new List<CheckedModListBoxItem>();

                foreach (CheckedModListBoxItem item in checkedListBoxSelectedMods.Items)
                {
                    modItems.Add(item);
                }

                return modItems.ToArray();
            }
            set
            {
                checkedListBoxSelectedMods.Items.Clear();
                checkedListBoxSelectedMods.Items.AddRange(value);
                checkedListBoxSelectedMods.DisplayMember = "Label";

                for (int i = 0; i < checkedListBoxSelectedMods.Items.Count; i++)
                {
                    if (((CheckedModListBoxItem)checkedListBoxSelectedMods.Items[i]).Enabled)
                    {
                        checkedListBoxSelectedMods.SetItemChecked(i, true);
                    }
                }
            }
        }

        public string SelectedMod
        {
            get
            {
                if ((CheckedModListBoxItem)checkedListBoxSelectedMods.SelectedItem != null)
                {
                    return ((CheckedModListBoxItem)checkedListBoxSelectedMods.SelectedItem).ModName;
                }
                else if (checkedListBoxSelectedMods.Items.Count >= 0)
                {
                    return ((CheckedModListBoxItem)checkedListBoxSelectedMods.Items[0]).ModName;
                }

                return string.Empty;
            }
            set
            {
                for (int i = 0; i < checkedListBoxSelectedMods.Items.Count; i++)
                {
                    if (((CheckedModListBoxItem)checkedListBoxSelectedMods.Items[i]).ModName == value)
                    {
                        checkedListBoxSelectedMods.SelectedIndex = i;
                    }
                }
            }
        }

        public TreeNode[] ModInfoProperties
        {
            set
            {
                treeViewModProperties.Nodes.Clear();
                treeViewModProperties.Nodes.AddRange(value);
                treeViewModProperties.ExpandAll();
            }
        }

        public bool CustomModSelectionEnabled
        {
            set
            {
                checkedListBoxSelectedMods.Enabled = value;
                treeViewModProperties.Enabled = value;
            }
        }

        public string RadioModListLabel
        {
            set
            {
                radioButtonModList.Text = value;
            }
        }

        public string RadioCustomListLabel
        {
            set
            {
                radioButtonCustom.Text = value;
            }
        }

        private void buttonSelectDirectory_Click(object sender, EventArgs e)
        {
            DirectoryButtonPressed(this, new EventArgs());
        }

        private void comboBoxSelectDirectory_TextChanged(object sender, EventArgs e)
        {
            DirectoryChanged(this, new EventArgs());
        }

        private void radioButtonModList_CheckedChanged(object sender, EventArgs e)
        {
            RadioButtonChanged(this, new EventArgs());
        }

        private void checkedListBoxSelectedMods_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedModChanged(this, new EventArgs());
        }

        private void checkedListBoxSelectedMods_SelectedValueChanged(object sender, EventArgs e)
        {
            CheckedModsChanged(this, new EventArgs());
        }
    }
}
