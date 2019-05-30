using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Foreman.Models;

namespace Foreman
{
	public partial class InstallationChooserForm: Form
	{
        private List<GameInstallation> installations;
		public String SelectedPath;

		public InstallationChooserForm(List<GameInstallation> installations)
		{
            this.installations = installations;
			SelectedPath = null;
			InitializeComponent();

            foreach (GameInstallation i in installations)
            {
                this.comboBox1.Items.Add(i.DirPath + " v" + i.Version);
            }
		}

		private void OKButton_Click(object sender, EventArgs e)
		{
            DialogResult = DialogResult.OK;
            Close();
		}

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedPath = this.installations[this.comboBox1.SelectedIndex].DirPath;
        }
    }
}
