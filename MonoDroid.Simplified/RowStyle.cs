using Android.Views;
using Android.Widget;

namespace MonoDroid.Simplified
{
    public class RowStyle : Style
    {
        public int? Column { get; set; }
        public int? Span { get; set; }

        public override void Apply(View view, ViewGroup.LayoutParams layoutParams)
        {
            var lp = layoutParams as TableRow.LayoutParams;
            if (lp != null)
            {
                if (Column.HasValue) lp.Column = Column.Value;
                if (Span.HasValue) lp.Span = Span.Value;
            }
        }
    }
}