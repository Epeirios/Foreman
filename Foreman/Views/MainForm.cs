﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foreman.Views
{
    public partial class MainForm : Form, IMainForm
    {
        private readonly ILoadingView loadingView;
        private readonly ISettingsView settingsView;

        public MainForm(ILoadingView loadingView, ISettingsView settingsView)
        {
            InitializeComponent();

            this.loadingView = loadingView;
            this.settingsView = settingsView;
        }

        public event EventHandler MainFormLoaded
        {
            add { this.Load += value; }
            remove { this.Load -= value; }
        }

        public void ShowLoadingView()
        {
            SetMainFormView((Control)loadingView);
        }

        public void ShowSettingsView()
        {
            SetMainFormView((Control)settingsView);
        }

        private void SetMainFormView(Control view)
        {
            tableLayoutPanelMainForm.Controls.Clear();
            tableLayoutPanelMainForm.Controls.Add(view);
            tableLayoutPanelMainForm.Controls[0].Dock = DockStyle.Fill;
        }
    }
}
