using Foreman.Views.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foreman.Views
{
    public interface ISettingsView
    {
        IFactorioGameDirectoryControl FactorioGameDirectoryControl { get; }
        IFactorioModDirectoryControl FactorioModDirectoryControl { get; }

        event EventHandler SaveButtonPressed;
    }
}
