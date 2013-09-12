using Android.Views;

namespace MonoDroid.Simplified
{
    public class MarginStyle : Style
    {
        public int? All { get; set; }
        public int? Bottom { get; set; }
        public int? Left { get; set; }
        public int? Right { get; set; }
        public int? Top { get; set; }

        public override void Apply(View view, ViewGroup.LayoutParams layoutParams)
        {
            var lp = layoutParams as ViewGroup.MarginLayoutParams;
            if (lp != null)
            {
                if (All.HasValue)
                {
                    lp.BottomMargin = lp.LeftMargin = lp.RightMargin = lp.TopMargin = All.Value;
                }
                if (Bottom.HasValue) lp.BottomMargin = Bottom.Value;
                if (Left.HasValue) lp.LeftMargin = Left.Value;
                if (Right.HasValue) lp.RightMargin = Right.Value;
                if (Top.HasValue) lp.TopMargin = Top.Value;
            }
        }
    }
}