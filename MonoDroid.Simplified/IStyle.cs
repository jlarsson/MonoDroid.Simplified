using Android.Views;

namespace MonoDroid.Simplified
{
    public interface IStyle
    {
        void Apply(View view, ViewGroup.LayoutParams layoutParams);        
    }
}