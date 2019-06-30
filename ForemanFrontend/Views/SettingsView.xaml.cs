using Foreman.Views;
using Foreman.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ForemanFrontend.Views.Usercontrols
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
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
            throw new NotImplementedException();
        }

        public void SetSaveAndApplyButtonText(string text)
        {
            throw new NotImplementedException();
        }

        public void SetSettingsControls(ISettingsUserControl[] settingsControls)
        {
            SettingUserControlGrid.Children.Clear();

            int row = 0;

            foreach (Control control in settingsControls)
            {
                RowDefinition rowDef = new RowDefinition();
                rowDef.Height = new GridLength(0, GridUnitType.Auto);

                SettingUserControlGrid.RowDefinitions.Add(rowDef);
                SettingUserControlGrid.Children.Add(control);
                Grid.SetRow(control, row);

                control.HorizontalAlignment = HorizontalAlignment.Stretch;
                control.VerticalAlignment = VerticalAlignment.Stretch;

                row += 1;
            }
        }

        public void SetSettingsLabel(string text)
        {
            throw new NotImplementedException();
        }
    }
}
