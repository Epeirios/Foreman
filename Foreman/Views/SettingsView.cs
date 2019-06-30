﻿using System;
using System.Windows.Forms;
using Foreman.Views.Controls;
using Foreman.Views.UserControls;

namespace Foreman.Views
{
    public partial class SettingsView : UserControl, ISettingsView
    {
        public SettingsView()
        {
            InitializeComponent();
        }

        public event EventHandler SaveAndApplyButtonPressed;
        public event EventHandler CancelButtonPressed;

        public void SetCancelButtonText(string text)
        {
            buttonCancel.Text = text;
        }

        public void SetSaveAndApplyButtonText(string text)
        {
            buttonSaveAndApply.Text = text;
        }

        public void SetSettingsControls(ISettingsUserControl[] settingsControls)
        {
            tableLayoutPanelSettingsControls.Controls.Clear();

            int row = 0;
                        
            foreach (Control control in settingsControls)
            {                
                tableLayoutPanelSettingsControls.RowStyles.Insert(row , new RowStyle(SizeType.AutoSize));
                tableLayoutPanelSettingsControls.Controls.Add(control, 0, row);

                control.Dock = DockStyle.Fill;
                ((UserControl)control).AutoSize = true;
                ((UserControl)control).AutoSizeMode = AutoSizeMode.GrowAndShrink;

                row += 1;
            }
        }

        public void SetSettingsLabel(string text)
        {
            labelSettingsLabel.Text = text;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            CancelButtonPressed(this, new EventArgs());
        }

        private void buttonSaveAndApply_Click(object sender, EventArgs e)
        {
            SaveAndApplyButtonPressed(this, new EventArgs());
        }
    }
}