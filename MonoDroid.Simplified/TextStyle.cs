using Android.Graphics;
using Android.Views;
using Android.Widget;

namespace MonoDroid.Simplified
{
    public class TextStyle : Style
    {
        public Color? Color { get; set; }
        public bool? Small { get; set; }
        public bool? Medium { get; set; }
        public bool? Large { get; set; }
        public bool? SmallInverse { get; set; }
        public bool? MediumInverse { get; set; }
        public bool? LargeInverse { get; set; }

        private bool Test(bool? b)
        {
            return b.HasValue && b.Value;
        }

        public override void Apply(View view, ViewGroup.LayoutParams layoutParams)
        {
            var tv = view as TextView;
            if (tv != null)
            {
                if (Test(Small)) tv.SetTextAppearance(tv.Context, Android.Resource.Style.TextAppearanceSmall);
                if (Test(Medium)) tv.SetTextAppearance(tv.Context, Android.Resource.Style.TextAppearanceMedium);
                if (Test(Large)) tv.SetTextAppearance(tv.Context, Android.Resource.Style.TextAppearanceLarge);
                if (Test(SmallInverse)) tv.SetTextAppearance(tv.Context, Android.Resource.Style.TextAppearanceSmallInverse);
                if (Test(MediumInverse)) tv.SetTextAppearance(tv.Context, Android.Resource.Style.TextAppearanceMediumInverse);
                if (Test(LargeInverse)) tv.SetTextAppearance(tv.Context, Android.Resource.Style.TextAppearanceLargeInverse);
                if (Color.HasValue) tv.SetTextColor(Color.Value);
            }
        }
    }
}