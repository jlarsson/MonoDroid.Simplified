using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Android.Content;
using Android.Views;

namespace MonoDroid.Simplified
{
    public class Group<TViewGroup>: Element<TViewGroup>, IEnumerable where TViewGroup : ViewGroup
    {
        private readonly List<IElement> _children = new List<IElement>();

        public Group(Style.WidthHeight wh) : base(wh)
        {
        }

        public Group(int width, int height) : base(width, height)
        {
        }

        public override View CreateView(Context context, ViewGroup parent)
        {
            var view = (TViewGroup)base.CreateView(context, parent);
            foreach (var childView in _children.Where(c => c != null).Select(child => child.CreateView(context, view)).Where(v => v != null))
            {
                view.AddView(childView, childView.LayoutParameters);
            }
            return view;
        }

        public IEnumerator GetEnumerator()
        {
            return _children.GetEnumerator();
        }

        public void Add(IElement child)
        {
            _children.Add(child);
        }
        public void Add(IEnumerable<IElement> children)
        {
            _children.AddRange(children);
        }
    }
}