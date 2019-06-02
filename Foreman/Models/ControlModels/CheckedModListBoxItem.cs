using System;

namespace Foreman.Models.ControlModels
{
    public class CheckedModListBoxItem
    {
        public CheckedModListBoxItem(string modName, string label, bool error, bool enabled, bool forceEnabled = false)
        {
            ModName = modName;
            Label = label;
            Error = error;
            Enabled = enabled;
            ForcedEnabled = forceEnabled;
        }

        public string ModName { get; private set; }
        public string Label { get; private set; }
        public bool Error { get; private set; }
        public bool Enabled { get; private set; }
        public bool ForcedEnabled { get; private set; }
    }
}
