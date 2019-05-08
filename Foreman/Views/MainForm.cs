using System;
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
        private Control loadingView;

        public MainForm(Control loadingView)
        {
            InitializeComponent();

            this.loadingView = loadingView;
        }

        public void ShowLoadingView()
        {
            tableLayoutPanelMainForm.Controls.Clear();
            tableLayoutPanelMainForm.Controls.Add(loadingView);
            tableLayoutPanelMainForm.Controls[0].Dock = DockStyle.Fill;
        }
    }
}
