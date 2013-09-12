using Android.Views;
using Android.Widget;

namespace MonoDroid.Simplified
{
    public class RelativeStyle : Style
    {
        public int? AlignBaseline { get; set; }
        public int? AlignBottom { get; set; }
        public int? AlignLeft { get; set; }
        public int? AlignRight { get; set; }
        public int? AlignTop { get; set; }

        public bool? AlignParentTop { get; set; }
        public bool? AlignParentLeft { get; set; }
        public bool? AlignParentRight { get; set; }
        public bool? AlignParentBottom { get; set; }
        public bool? CenterHorizontal { get; set; }
        public bool? CenterInParent { get; set; }
        public bool? CenterVertical { get; set; }

        public int? ToLeftOf { get; set; }
        public int? ToRightOf { get; set; }
        public int? Above { get; set; }
        public int? Below { get; set; }

        private void TestAndAddRule(RelativeLayout.LayoutParams lp, int? anchor, LayoutRules layoutRule)
        {
            if (anchor.HasValue) lp.AddRule(layoutRule, anchor.Value);
        }

        private void TestAndAddRule(RelativeLayout.LayoutParams lp, bool? value, LayoutRules layoutRule)
        {
            if (value.HasValue && value.Value) lp.AddRule(layoutRule);
        }

        public override void Apply(View view, ViewGroup.LayoutParams layoutParams)
        {
            var lp = layoutParams as RelativeLayout.LayoutParams;
            if (lp != null)
            {
                TestAndAddRule(lp, AlignBaseline, LayoutRules.AlignBaseline);
                TestAndAddRule(lp, AlignBottom, LayoutRules.AlignBottom);
                TestAndAddRule(lp, AlignLeft, LayoutRules.AlignLeft);
                TestAndAddRule(lp, AlignRight, LayoutRules.AlignRight);
                TestAndAddRule(lp, AlignTop, LayoutRules.AlignTop);
                TestAndAddRule(lp, AlignParentTop, LayoutRules.AlignParentTop);
                TestAndAddRule(lp, AlignParentLeft, LayoutRules.AlignParentLeft);
                TestAndAddRule(lp, AlignParentRight, LayoutRules.AlignParentRight);
                TestAndAddRule(lp, AlignParentBottom, LayoutRules.AlignParentBottom);
                TestAndAddRule(lp, CenterHorizontal, LayoutRules.CenterHorizontal);
                TestAndAddRule(lp, CenterInParent, LayoutRules.CenterInParent);
                TestAndAddRule(lp, CenterVertical, LayoutRules.CenterVertical);
                TestAndAddRule(lp, ToLeftOf, LayoutRules.LeftOf);
                TestAndAddRule(lp, ToRightOf, LayoutRules.RightOf);
                TestAndAddRule(lp, Above, LayoutRules.Above);
                TestAndAddRule(lp, Below, LayoutRules.Below);
            }
        }
    }
}