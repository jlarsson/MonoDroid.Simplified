using Android.Content;
using Android.Views;

namespace MonoDroid.Simplified
{
    public class InflatedElement: IElement
    {
        private readonly int _resourceId;

        public InflatedElement(int resourceId)
        {
            _resourceId = resourceId;
        }

        public View CreateView(Context context, ViewGroup parent)
        {
            return LayoutInflater.FromContext(context).Inflate(_resourceId, parent, false);
        }
    }
}
