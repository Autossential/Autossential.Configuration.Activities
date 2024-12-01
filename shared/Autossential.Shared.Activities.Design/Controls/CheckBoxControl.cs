using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace Autossential.Shared.Activities.Design.Controls
{
    public class CheckBoxControl : CheckBox
    {
        private static readonly Dictionary<int, bool?> _states = new Dictionary<int, bool?>
        {
            { 0, null },
            { 1, true },
            { 2, false }
        };

        protected override void OnToggle()
        {
            var index = _states.First(p => p.Value == IsChecked).Key;
            if (++index >= _states.Count)
                index = 0;

            IsChecked = _states[index];
        }
    }
}