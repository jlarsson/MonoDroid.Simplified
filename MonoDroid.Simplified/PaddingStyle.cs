using Android.Views;

namespace MonoDroid.Simplified
{
    public class PaddingStyle : Style
    {
        public int? All { get; set; }
        public int? Bottom { get; set; }
        public int? Left { get; set; }
        public int? Right { get; set; }
        public int? Top { get; set; }

        public override void Apply(View view, ViewGroup.LayoutParams layoutParams)
        {
            view.SetPadding(
                Left.HasValue ? Left.Value : All.HasValue ? All.Value : view.PaddingLeft,
                Top.HasValue ? Top.Value : All.HasValue ? All.Value : view.PaddingTop,
                Right.HasValue ? Right.Value : All.HasValue ? All.Value : view.PaddingRight,
                Bottom.HasValue ? Bottom.Value : All.HasValue ? All.Value : view.PaddingBottom
                );
        }
    }
}