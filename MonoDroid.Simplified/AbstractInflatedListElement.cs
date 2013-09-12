using Android.Content;
using Android.Views;

namespace MonoDroid.Simplified
{
    public abstract class AbstractInflatedListElement: AbstractListElement
    {
        public override View CreateView(Context context, ViewGroup parent)
        {
            return LayoutInflater.FromContext(context).Inflate(ResourceId, parent, false);
        }

        protected abstract int ResourceId { get; set; }
    }
}