using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foreman.Views.Controls
{
    public enum RadioButtonStatesEnum
    {
        foundDirectories,
        manualDirectory
    }

    public class RadioButtonEventArgs : EventArgs
    {
        public RadioButtonStatesEnum RadioButtonStatesEnum { get; set; }
    }
}
