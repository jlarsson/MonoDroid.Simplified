using Android.Views;

namespace MonoDroid.Simplified
{
    public interface IListElement: IElement
    {
        string TypeTag { get; }
        bool IsReusable { get; }
        bool Enabled { get; }
        void UpdateView(View view);
    }
}