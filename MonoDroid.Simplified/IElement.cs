using Android.Content;
using Android.Views;

namespace MonoDroid.Simplified
{
    public interface IElement
    {
        View CreateView(Context context, ViewGroup parent);
    }

    public interface IElement<TView>: IElement where TView: View
    {
    }
}