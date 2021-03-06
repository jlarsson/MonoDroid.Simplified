﻿using System;
using Android.Content;
using Android.Views;

namespace MonoDroid.Simplified.Elements
{
    public class SetupElement : IElement
    {
        private readonly IElement _inner;
        private readonly Action<View> _setup;

        public SetupElement(IElement inner, Action<View> setup)
        {
            _inner = inner;
            _setup = setup;
        }

        public View CreateView(Context context, ViewGroup parent)
        {
            var view = _inner.CreateView(context, parent);
            _setup(view);
            return view;
        }
    }

    public class SetupElement<TView>: IElement<TView> where TView : View
    {
        private readonly IElement<TView> _inner;
        private readonly Action<TView> _setup;

        public SetupElement(IElement<TView> inner, Action<TView> setup)
        {
            _inner = inner;
            _setup = setup;
        }

        public View CreateView(Context context, ViewGroup parent)
        {
            var view = (TView)_inner.CreateView(context, parent);
            _setup(view);
            return view;
        }
    }
}
