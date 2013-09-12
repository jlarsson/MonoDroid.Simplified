using Android.Views;
using Android.Widget;

namespace MonoDroid.Simplified
{
    public class LinearStyle : Style
    {
        public GravityFlags? Gravity { get; set; }
        public float? Weight { get; set; }

        public override void Apply(View view, ViewGroup.LayoutParams layoutParams)
        {
            var lp = layoutParams as LinearLayout.LayoutParams;
            if (lp != null)
            {
                if (Gravity.HasValue) lp.Gravity = Gravity.Value;
                if (Weight.HasValue) lp.Weight = Weight.Value;
            }
        }
    }
}