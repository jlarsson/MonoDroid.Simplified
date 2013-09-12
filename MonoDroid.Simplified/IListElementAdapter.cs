using System.Collections.Generic;
using Android.Widget;

namespace MonoDroid.Simplified
{
    public interface IListElementAdapter : IListAdapter, ISpinnerAdapter
    {
        IList<IListElement> Elements { get; set; }
        void Invalidate();
    }
}