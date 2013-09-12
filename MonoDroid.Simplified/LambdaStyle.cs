using System;
using Android.Views;

namespace MonoDroid.Simplified
{
    public class LambdaStyle<T> : IStyle where T : ViewGroup.LayoutParams
    {
        private readonly Action<View, T> _init;

        public LambdaStyle(Action<View, T> init)
        {
            _init = init;
        }

        public void Apply(View view, ViewGroup.LayoutParams layoutParams)
        {
            var lp = layoutParams as T;
            if (lp != null)
            {
                _init(view, lp);
            }
        }
    }
}