using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foreman.Views
{
    public partial class LoadingView : UserControl, ILoadingView
    {
        public LoadingView()
        {
            InitializeComponent();
        }

        public void SetLoadingText(string text)
        {
            labelLoadingText.Text = text;
        }

        public void SetProgress(int progressValue)
        {
            progressBar.Value = progressValue;
        }
    }
}
