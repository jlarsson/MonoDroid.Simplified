using System;
using Android.Widget;
using Object = Java.Lang.Object;

namespace MonoDroid.Simplified.EventHandlers
{
    public class OnCheckedChangeListenerForCompoundButton : Object, CompoundButton.IOnCheckedChangeListener
    {
        public Action<CompoundButton, bool> OnCheckedChange { get; set; }

        void CompoundButton.IOnCheckedChangeListener.OnCheckedChanged(CompoundButton buttonView, bool isChecked)
        {
            if (OnCheckedChange != null)
            {
                OnCheckedChange(buttonView, isChecked);
            }
        }
    }
}