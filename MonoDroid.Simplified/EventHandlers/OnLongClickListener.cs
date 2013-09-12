using System;
using Android.Views;
using Object = Java.Lang.Object;

namespace MonoDroid.Simplified.EventHandlers
{
    public class OnLongClickListener : Object, View.IOnLongClickListener
    {
        public Func<View, bool> OnLongClick { get; set; }

        bool View.IOnLongClickListener.OnLongClick(View v)
        {
            return (OnLongClick != null) && OnLongClick(v);
        }
    }
}