using Android.Content;
using Android.Views;

namespace MonoDroid.Simplified.Elements
{
    public class StyleElement : IElement
    {
        private readonly IElement _inner;
        private readonly IStyle[] _styles;

        public StyleElement(IElement inner, IStyle[] styles)
        {
            _inner = inner;
            _styles = styles;
        }

        public View CreateView(Context context, ViewGroup parent)
        {
            var view = _inner.CreateView(context, parent);
            foreach (var style in _styles)
            {
                style.Apply(view,view.LayoutParameters);
            }
            return view;
        }
    }

    public class StyleElement<TView>: StyleElement, IElement<TView> where TView : View
    {
        public StyleElement(IElement<TView> inner, IStyle[] styles) : base(inner, styles)
        {
        }
    }
}