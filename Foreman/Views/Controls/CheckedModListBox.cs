using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using Foreman.Models.ControlModels;

namespace Foreman.Views.Controls
{
    public class CheckedModListBox : CheckedListBox
    {
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            CheckedModListBoxItem item = (CheckedModListBoxItem)Items[e.Index];

            Color foreColor = e.ForeColor;
            DrawItemState state = e.State;

            if (item.Error)
            {
                foreColor = Color.Red;
            }

            if (item.ForcedEnabled)
            {
                state = DrawItemState.Disabled;
            }

            // Copy the original event args, just tweaking the fore color.
            var tweakedEventArgs = new DrawItemEventArgs(
                e.Graphics,
                e.Font,
                e.Bounds,
                e.Index,
                e.State,
                foreColor,
                e.BackColor);

            // Call the original OnDrawItem, but supply the tweaked color.
            base.OnDrawItem(tweakedEventArgs);
        }
    }
}
