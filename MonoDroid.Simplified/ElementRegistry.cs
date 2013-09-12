using System;
using System.Collections.Generic;
using Android.Content;
using Android.Gestures;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Webkit;
using Android.Widget;

namespace MonoDroid.Simplified
{
    public static class ElementRegistry
    {
        private static readonly Dictionary<Type, Func<Context, object>> ViewConstructors =
            new Dictionary<Type, Func<Context, object>>();

        private static readonly Dictionary<Type, Func<int, int, ViewGroup.LayoutParams>> LayoutParamsConstructors =
            new Dictionary<Type, Func<int, int, ViewGroup.LayoutParams>>();

        public static void RegisterViewType<TView>(Func<Context, TView> factory) where TView : View
        {
            ViewConstructors[typeof (TView)] = factory;
        }

        public static void RegisterLayoutType<TViewGroup>(Func<int, int, ViewGroup.LayoutParams> factory)
            where TViewGroup : ViewGroup
        {
            LayoutParamsConstructors[typeof (TViewGroup)] = factory;
        }

        static ElementRegistry()
        {
            RegisterStandardViewTypes();
            RegisterStandardLayoutTypes();
        }

        private static void RegisterStandardLayoutTypes()
        {
            // Support.v4
            RegisterLayoutType<DrawerLayout>((w, h) => new DrawerLayout.LayoutParams(w, h));
            RegisterLayoutType<SlidingPaneLayout>((w, h) => new SlidingPaneLayout.LayoutParams(w, h));

            // Images and media
            RegisterLayoutType<Gallery>((w, h) => new Gallery.LayoutParams(w, h));
            RegisterLayoutType<MediaController>((w, h) => new FrameLayout.LayoutParams(w, h));

            // Layouts
            RegisterLayoutType<FrameLayout>((w, h) => new FrameLayout.LayoutParams(w, h));
            RegisterLayoutType<LinearLayout>((w, h) => new LinearLayout.LayoutParams(w, h));
            RegisterLayoutType<RelativeLayout>((w, h) => new RelativeLayout.LayoutParams(w, h));
            RegisterLayoutType<TableLayout>((w, h) => new TableLayout.LayoutParams(w, h));
            RegisterLayoutType<TableRow>((w, h) => new TableRow.LayoutParams(w, h));

            //Composite
            RegisterLayoutType<ExpandableListView>((w, h) => new AbsListView.LayoutParams(w, h));
            RegisterLayoutType<GridView>((w, h) => new AbsListView.LayoutParams(w, h));
            RegisterLayoutType<HorizontalScrollView>((w, h) => new FrameLayout.LayoutParams(w, h));
            RegisterLayoutType<ListView>((w, h) => new AbsListView.LayoutParams(w, h));
            RegisterLayoutType<ScrollView>((w, h) => new FrameLayout.LayoutParams(w, h));
            RegisterLayoutType<SlidingDrawer>((w, h) => new ViewGroup.LayoutParams(w, h));
            RegisterLayoutType<TabHost>((w, h) => new FrameLayout.LayoutParams(w, h));
            RegisterLayoutType<TabWidget>((w, h) => new LinearLayout.LayoutParams(w, h));
            RegisterLayoutType<WebView>((w, h) => new AbsoluteLayout.LayoutParams(w, h, 0, 0));

            // Advanced
            RegisterLayoutType<DialerFilter>((w, h) => new RelativeLayout.LayoutParams(w, h));
            RegisterLayoutType<GestureOverlayView>((w, h) => new FrameLayout.LayoutParams(w, h));
            RegisterLayoutType<TwoLineListItem>((w, h) => new RelativeLayout.LayoutParams(w, h));
            RegisterLayoutType<ZoomControls>((w, h) => new LinearLayout.LayoutParams(w, h));

            // Form widgets
            RegisterLayoutType<RadioGroup>((w, h) => new RadioGroup.LayoutParams(w, h));
            RegisterLayoutType<Spinner>((w, h) => new ViewGroup.LayoutParams(w, h));

            // Time & Date
            RegisterLayoutType<DatePicker>((w, h) => new FrameLayout.LayoutParams(w, h));
            RegisterLayoutType<TimePicker>((w, h) => new FrameLayout.LayoutParams(w, h));

            // Other layouts
            RegisterLayoutType<AbsoluteLayout>((w, h) => new AbsoluteLayout.LayoutParams(w, h, 0, 0)); // NOTE: Obsolete
            RegisterLayoutType<ImageSwitcher>((w, h) => new FrameLayout.LayoutParams(w, h));
            RegisterLayoutType<TextSwitcher>((w, h) => new FrameLayout.LayoutParams(w, h));
            RegisterLayoutType<ViewAnimator>((w, h) => new FrameLayout.LayoutParams(w, h));
            RegisterLayoutType<ViewFlipper>((w, h) => new FrameLayout.LayoutParams(w, h));
            RegisterLayoutType<ViewSwitcher>((w, h) => new FrameLayout.LayoutParams(w, h));
        }

        private static void RegisterStandardViewTypes()
        {
            // Support.v4
            RegisterViewType(c => new DrawerLayout(c));
            RegisterViewType(c => new SlidingPaneLayout(c));

            // Images and media
            RegisterViewType(c => new Gallery(c));
            RegisterViewType(c => new ImageButton(c));
            RegisterViewType(c => new ImageView(c));
            RegisterViewType(c => new MediaController(c));
            RegisterViewType(c => new VideoView(c));

            // Layouts
            RegisterViewType(c => new FrameLayout(c));
            RegisterViewType(c => new LinearLayout(c));
            RegisterViewType(c => new RelativeLayout(c));
            RegisterViewType(c => new TableLayout(c));
            RegisterViewType(c => new TableRow(c));

            //Composite
            RegisterViewType(c => new ExpandableListView(c));
            RegisterViewType(c => new GridView(c));
            RegisterViewType(c => new HorizontalScrollView(c));
            RegisterViewType(c => new ListView(c));
            RegisterViewType(c => new ScrollView(c));
            //RegisterViewType(c => new SlidingDrawer(c));
            RegisterViewType(c => new TabHost(c));
            RegisterViewType(c => new TabWidget(c));
            RegisterViewType(c => new WebView(c));

            // Advanced
            RegisterViewType(c => new DialerFilter(c));
            RegisterViewType(c => new GestureOverlayView(c));
            RegisterViewType(c => new SurfaceView(c));
            RegisterViewType(c => new TwoLineListItem(c));
            RegisterViewType(c => new View(c));
            RegisterViewType(c => new ViewStub(c));
            RegisterViewType(c => new ZoomButton(c));
            RegisterViewType(c => new ZoomControls(c));

            // Form widgets
            RegisterViewType(c => new AutoCompleteTextView(c));
            RegisterViewType(c => new Button(c));
            RegisterViewType(c => new CheckBox(c));
            RegisterViewType(c => new CheckedTextView(c));
            RegisterViewType(c => new EditText(c));
            RegisterViewType(c => new MultiAutoCompleteTextView(c));
            RegisterViewType(c => new ProgressBar(c));
            RegisterViewType(c => new QuickContactBadge(c));
            RegisterViewType(c => new RadioButton(c));
            RegisterViewType(c => new RadioGroup(c));
            RegisterViewType(c => new RatingBar(c));
            RegisterViewType(c => new SeekBar(c));
            RegisterViewType(c => new Spinner(c));
            RegisterViewType(c => new TextView(c));
            RegisterViewType(c => new ToggleButton(c));

            // Time & Date
            RegisterViewType(c => new AnalogClock(c));
            RegisterViewType(c => new Chronometer(c));
            RegisterViewType(c => new DatePicker(c));
            RegisterViewType(c => new DigitalClock(c));
            RegisterViewType(c => new TimePicker(c));

            // Other layouts
            //RegisterViewType(c => new AbsoluteLayout(c)); // NOTE: Obsolete
            RegisterViewType(c => new ImageSwitcher(c));
            RegisterViewType(c => new TextSwitcher(c));
            RegisterViewType(c => new ViewAnimator(c));
            RegisterViewType(c => new ViewFlipper(c));
            RegisterViewType(c => new ViewSwitcher(c));
        }

        public static View CreateView(Type type, Context context, ViewGroup parent, int width, int height)
        {
            var view = CreateView(type, context);
            var effectiveParent = parent ?? view as ViewGroup;
            if (effectiveParent == null)
            {
                throw new ElementException(
                    string.Format(
                        "Invalid null parent specified when creating view of type {0} (which isn't itself a ViewGroup)",
                        type));
            }
            view.LayoutParameters = CreateLayoutParametersForContainer(effectiveParent, width, height);
            return view;
        }

        public static View CreateView(Type type, Context context)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            Func<Context, object> factory;
            if (!ViewConstructors.TryGetValue(type, out factory))
            {
                throw new ElementException(
                    string.Format(
                        "No constructor found for {0}. Please register the view type with\r\nElementRegistry.RegisterViewType(c => new {0}(c));",
                        type));
            }
            var view = factory(context) as View;
            return view;
        }

        public static ViewGroup.LayoutParams CreateLayoutParametersForContainer(View container, int width, int height)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            var containerType = container.GetType();
            Func<int, int, ViewGroup.LayoutParams> factory;
            if (!LayoutParamsConstructors.TryGetValue(containerType, out factory))
            {
                throw new ElementException(
                    string.Format(
                        "No nested LayoutParams class found for {0}. Please register the layout type with\r\nRegisterLayoutType<{0}>((w, h) => new {0}.LayoutParams(w, h))",
                        containerType));
            }
            return factory(width, height);
        }
    }
}