using System;
using Android.Views;

namespace MonoDroid.Simplified
{
    public abstract class Style : IStyle
    {
        public static IStyle For<TLayout>(Action<View, TLayout> init) where TLayout : ViewGroup.LayoutParams
        {
            return new LambdaStyle<TLayout>(init);
        }

        public class WidthHeight
        {
            public int Width { get; set; }
            public int Height { get; set; }
        }

        public const int FillParent = ViewGroup.LayoutParams.FillParent;
        public const int MatchParent = ViewGroup.LayoutParams.MatchParent;
        public const int WrapContent = ViewGroup.LayoutParams.WrapContent;
        public static readonly WidthHeight FillFill = new WidthHeight { Width = FillParent, Height = FillParent };
        public static readonly WidthHeight FillWrap = new WidthHeight { Width = FillParent, Height = WrapContent };
        public static readonly WidthHeight WrapWrap = new WidthHeight { Width = WrapContent, Height = WrapContent };
        public static readonly WidthHeight WrapFill = new WidthHeight { Width = WrapContent, Height = FillParent };
        public static readonly WidthHeight MatchMatch = new WidthHeight { Width = MatchParent, Height = MatchParent };
        public abstract void Apply(View view, ViewGroup.LayoutParams layoutParams);
    }
}