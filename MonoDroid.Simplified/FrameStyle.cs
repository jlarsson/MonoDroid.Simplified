using Android.Views;
using Android.Widget;

namespace MonoDroid.Simplified
{
    public class FrameStyle : Style
    {
        public GravityFlags? Gravity { get; set; }

        public override void Apply(View view, ViewGroup.LayoutParams layoutParams)
        {
            var lp = layoutParams as FrameLayout.LayoutParams;
            if (lp != null)
            {
                if (Gravity.HasValue) lp.Gravity = Gravity.Value;
            }
        }
    }
}