using System;
using Android.Views;
using Object = Java.Lang.Object;

namespace MonoDroid.Simplified.EventHandlers
{
    public class OnMenuItemClickListener : Object, IMenuItemOnMenuItemClickListener
    {
        public Func<IMenuItem, bool> OnMenuItemClick { get; set; }

        bool IMenuItemOnMenuItemClickListener.OnMenuItemClick(IMenuItem item)
        {
            return (OnMenuItemClick != null) && OnMenuItemClick(item);
        }
    }
}