using System;
using Android.Content;
using Android.Views;

namespace MonoDroid.Simplified
{
    public class Element<TView>: IElement<TView> where TView : View
    {
        private readonly int _width;
        private readonly int _height;

        public Element(Style.WidthHeight widthHeight)
        {
            if (widthHeight == null) throw new ArgumentNullException("widthHeight");
            _width = widthHeight.Width;
            _height = widthHeight.Height;
        }

        public Element(int width, int height)
        {
            _width = width;
            _height = height;
        }

        public virtual View CreateView(Context context, ViewGroup parent)
        {
            return ElementRegistry.CreateView(typeof (TView), context, parent, _width, _height);
        }
    }
}