using System;
using System.Collections;
using System.Collections.Generic;
using Android.App;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Text;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using Java.Lang;
using MonoDroid.Simplified.Elements;
using MonoDroid.Simplified.EventHandlers;
using Object = Java.Lang.Object;
using R = Android.Resource;

namespace MonoDroid.Simplified
{
    public static class ElementExtensions
    {
        /*****************************************************************
         * Creation
         ****************************************************************/
        public static View CreateView(this IElement element, Activity activity)
        {
            return element.CreateView(activity, null);
        }

        /*****************************************************************
         * Initialization
         ****************************************************************/

        public static IElement<TView> Setup<TView>(this IElement<TView> element, Action<TView> setup) where TView: View
        {
            return new SetupElement<TView>(element, setup);
        }

        public static IElement<TView> SetupChild<TView,TChildView>(this IElement<TView> element, int childId, Action<TChildView> setupChild) where TView : View where TChildView : View
        {
            return element.Setup(v => setupChild(v.FindViewById<TChildView>(childId)));
        }

        /*****************************************************************
         * Style, layout and appearance
         ****************************************************************/

        public static IElement<TView> Style<TView>(this IElement<TView> element, params IStyle[] styles)
            where TView : View
        {
            return new StyleElement<TView>(element, styles);
        }

        /*****************************************************************
         * General
         ****************************************************************/

        public static IElement<TView> Id<TView>(this IElement<TView> element, int id) where TView : View
        {
            return element.Setup(v => v.Id = id);
        }

        public static IElement<TView> BackgroundColor<TView>(this IElement<TView> element, Color color) where TView : View
        {
            return element.Setup(v => v.SetBackgroundColor(color));
        }
        public static IElement<TView> BackgroundDrawable<TView>(this IElement<TView> element, Drawable d) where TView : View
        {
            return element.Setup(v => v.SetBackgroundDrawable(d));
        }
        public static IElement<TView> BackgroundResource<TView>(this IElement<TView> element, int resid) where TView : View
        {
            return element.Setup(v => v.SetBackgroundResource(resid));
        }

        public static IElement<TView> OnClick<TView>(this IElement<TView> element, Action<View> onClick)
            where TView : View
        {
            return element.Setup(v => v.SetOnClickListener(new OnClickListener { OnClick = onClick }));
        }

        public static IElement<TView> OnLongClick<TView>(this IElement<TView> element, Func<View, bool> onLongClick)
            where TView : View
        {
            return element.Setup(v => v.SetOnLongClickListener(new OnLongClickListener { OnLongClick = onLongClick }));
        }

        public static IElement<TView> OnLongClick<TView>(this IElement<TView> element, Action<View> onLongClick)
            where TView : View
        {
            return element.OnLongClick(v =>
                                           {
                                               if (onLongClick != null)
                                               {
                                                   onLongClick(v);
                                                   return true;
                                               }
                                               return false;
                                           });
        }

        public static IElement<TView> Tag<TView>(this IElement<TView> element, Object tag) where TView : View
        {
            return element.Setup(v => v.Tag = tag);
        }

        public static IElement<TView> Tag<TView>(this IElement<TView> element, int key, Object tag) where TView : View
        {
            return element.Setup(v => v.SetTag(key, tag));
        }

        public static IElement<TView> Visibility<TView>(this IElement<TView> element, ViewStates visibility)
            where TView : View
        {
            return element.Setup(v => v.Visibility = visibility);
        }
        public static IElement<TView> VisibilityGone<TView>(this IElement<TView> element, ViewStates visibility)
            where TView : View
        {
            return element.Visibility(ViewStates.Gone);
        }
        public static IElement<TView> VisibilityInvisible<TView>(this IElement<TView> element, ViewStates visibility)
            where TView : View
        {
            return element.Visibility(ViewStates.Invisible);
        }
        public static IElement<TView> VisibilityVisible<TView>(this IElement<TView> element, ViewStates visibility)
            where TView : View
        {
            return element.Visibility(ViewStates.Visible);
        }

        public static IElement<TView> OnCreateContextMenu<TView>(this IElement<TView> element,
                                                                 Action<IContextMenu, View, IContextMenuContextMenuInfo>
                                                                     onCreateContextMenu) where TView : View
        {
            return
                element.Setup(
                    v =>
                    v.SetOnCreateContextMenuListener(new OnCreateContextMenuListener { OnCreateContextMenu = onCreateContextMenu }));
        }

        /*****************************************************************
        * CompoundButton
        ****************************************************************/

        public static IElement<TView> OnCheckedChanged<TView>(this IElement<TView> element,
                                                              Action<CompoundButton, bool> onCheckedChange)
            where TView : CompoundButton
        {
            return element.Setup(v => v.SetOnCheckedChangeListener(
                new OnCheckedChangeListenerForCompoundButton
                    {
                        OnCheckedChange = onCheckedChange
                    }));
        }

        /*****************************************************************
         * ImageView
         ****************************************************************/

        public static IElement<TView> ImageResource<TView>(this IElement<TView> element, int resid)
            where TView : ImageView
        {
            return element.Setup(v => v.SetImageResource(resid));
        }

        /*****************************************************************
         * LinearLayout
         ****************************************************************/

        public static IElement<TView> Orientation<TView>(this IElement<TView> element, Orientation orientation)
            where TView : LinearLayout
        {
            return element.Setup(v => v.Orientation = orientation);
        }

        public static IElement<TView> Horizontal<TView>(this IElement<TView> element) where TView : LinearLayout
        {
            return element.Setup(v => v.Orientation = Android.Widget.Orientation.Horizontal);
        }

        public static IElement<TView> Vertical<TView>(this IElement<TView> element) where TView : LinearLayout
        {
            return element.Setup(v => v.Orientation = Android.Widget.Orientation.Vertical);
        }

        /*****************************************************************
         * TextView
         ****************************************************************/

        public static IElement<TView> Gravity<TView>(this IElement<TView> element, GravityFlags gravity)
            where TView : TextView
        {
            return element.Setup(v => v.Gravity = gravity);
        }

        public static IElement<TView> Email<TView>(this IElement<TView> element) where TView : EditText
        {
            return element.Setup(v => v.InputType = InputTypes.ClassText | InputTypes.TextVariationEmailAddress);
        }

        public static IElement<TView> Password<TView>(this IElement<TView> element) where TView : EditText
        {
            return element.Setup(v => v.InputType = InputTypes.ClassText | InputTypes.TextVariationPassword);
        }

        public static IElement<TView> SingleLine<TView>(this IElement<TView> element) where TView : EditText
        {
            return element.Setup(v => v.SetSingleLine(true));
        }

        public static IElement<TView> MultiLine<TView>(this IElement<TView> element) where TView : TextView
        {
            return element.Setup(tv => tv.SetSingleLine(false));
        }

        public static IElement<TView> InputType<TView>(this IElement<TView> element, InputTypes inputType)
            where TView : EditText
        {
            return element.Setup(v => v.InputType = inputType);
        }

        public static IElement<TView> Lines<TView>(this IElement<TView> element, int n) where TView : TextView
        {
            return element.Setup(v => v.SetLines(n));
        }

        public static IElement<TView> MinLines<TView>(this IElement<TView> element, int n) where TView : TextView
        {
            return element.Setup(v => v.SetMinLines(n));
        }

        public static IElement<TView> MaxLines<TView>(this IElement<TView> element, int n) where TView : TextView
        {
            return element.Setup(v => v.SetMaxLines(n));
        }

        public static IElement<TView> Text<TView>(this IElement<TView> element, string text) where TView : TextView
        {
            return element.Setup(v => v.Text = text);
        }

        public static IElement<TView> Text<TView>(this IElement<TView> element, int resid) where TView : TextView
        {
            return element.Setup(v => v.SetText(resid));
        }

        public static IElement<TView> Hint<TView>(this IElement<TView> element, string hint) where TView : TextView
        {
            return element.Setup(v => v.Hint = hint);
        }

        public static IElement<TView> Hint<TView>(this IElement<TView> element, int resid) where TView : TextView
        {
            return element.Setup(v => v.SetHint(resid));
        }

        public static IElement<TView> TextAppearanceLarge<TView>(this IElement<TView> element) where TView : TextView
        {
            return element.Setup(v => v.SetTextAppearance(v.Context, R.Style.TextAppearanceLarge));
        }

        public static IElement<TView> TextAppearanceLargeInverse<TView>(this IElement<TView> element)
            where TView : TextView
        {
            return element.Setup(v => v.SetTextAppearance(v.Context, R.Style.TextAppearanceLargeInverse));
        }

        public static IElement<TView> TextAppearanceMedium<TView>(this IElement<TView> element) where TView : TextView
        {
            return element.Setup(v => v.SetTextAppearance(v.Context, R.Style.TextAppearanceMedium));
        }

        public static IElement<TView> TextAppearanceMediumInverse<TView>(this IElement<TView> element)
            where TView : TextView
        {
            return element.Setup(v => v.SetTextAppearance(v.Context, R.Style.TextAppearanceMediumInverse));
        }

        public static IElement<TView> TextAppearanceSmall<TView>(this IElement<TView> element) where TView : TextView
        {
            return element.Setup(v => v.SetTextAppearance(v.Context, R.Style.TextAppearanceSmall));
        }

        public static IElement<TView> TextAppearanceSmallInverse<TView>(this IElement<TView> element)
            where TView : TextView
        {
            return element.Setup(v => v.SetTextAppearance(v.Context, R.Style.TextAppearanceSmallInverse));
        }

        public static IElement<TView> TextColor<TView>(this IElement<TView> element, Color color) where TView : TextView
        {
            return element.Setup(v => v.SetTextColor(color));
        }

        public static IElement<TView> OnTextChanged<TView>(this IElement<TView> element,
                                                           Action<TextChangedEventArgs> onTextChanged,
                                                           Action<ICharSequence, int, int, int> onBeforeTextChanged =
                                                               null,
                                                           Action<IEditable> onAfterTextChanged = null)
            where TView : TextView
        {
            return element.Setup(v => v.AddTextChangedListener(new TextWatcher
                                                                  {
                                                                      BeforeTextChanged = onBeforeTextChanged,
                                                                      OnTextChanged = onTextChanged,
                                                                      AfterTextChanged = onAfterTextChanged
                                                                  }));
        }

        /*****************************************************************
         * WebView
         ****************************************************************/

        public static IElement<TView> Markup<TView>(this IElement<TView> element, string markup) where TView : WebView
        {
            return element.Setup(v => v.LoadDataWithBaseURL(null,
                                                           markup,
                                                           "text/html",
                                                           "utf-8",
                                                           null));
        }

        /*****************************************************************
         * AdapterView
         ****************************************************************/

        public static IElement<TView> OnItemClick<TView>(this IElement<TView> element,
                                                         Action<int, View, IListElement> onItemClick)
            where TView : AdapterView
        {
            return element.Setup(v => v.OnItemClickListener = new OnItemClickListener
                                                                 {
                                                                     OnItemClick = onItemClick,
                                                                 });
        }

        public static IElement<TView> OnLongItemClick<TView>(this IElement<TView> element,
                                                             Func<int, View, IListElement, bool> onItemLongClick)
            where TView : AdapterView
        {
            return
                element.Setup(
                    v => v.OnItemLongClickListener = new OnItemLongClickListener { OnItemLongClick = onItemLongClick });
        }

        public static IElement<TView> OnLongItemClick<TView>(this IElement<TView> element,
                                                             Action<int, View, IListElement> onItemLongClick)
            where TView : AdapterView
        {
            return element.OnLongItemClick(onItemLongClick == null
                                               ? null
                                               : (Func<int, View, IListElement, bool>)((p, v, e) =>
                                                                                           {
                                                                                               onItemLongClick(p, v,
                                                                                                               e);
                                                                                               return true;
                                                                                           }));
        }

        public static IElement<TView> OnItemSelected<TView>(this IElement<TView> element,
                                                            Action<int, View, IListElement> onItemSelected,
                                                            Action onNothingSelected = null) where TView : AdapterView
        {
            return element.Setup(v => v.OnItemSelectedListener = new OnItemSelectedListener
                                                                    {
                                                                        OnItemSelected = onItemSelected,
                                                                        OnNothingSelected = onNothingSelected
                                                                    });
        }

        /*****************************************************************
         * ListView
         ****************************************************************/

        public static IElement<TView> Adapter<TView>(this IElement<TView> element, IListAdapter adapter)
            where TView : AbsListView
        {
            return element.Setup(v => v.Adapter = adapter);
        }

        public static IElement<TView> Adapter<TView>(this IElement<TView> element, IEnumerable<IListElement> elements)
            where TView : AbsListView
        {
            return element.Adapter(new ListElementAdapter(elements));
        }

        public static IElement<TView> Adapter<TView>(this IElement<TView> element, params IListElement[] elements)
            where TView : AbsListView
        {
            return element.Adapter(new ListElementAdapter(elements));
        }

        public static IElement<TView> OnScroll<TView>(this IElement<TView> element,
                                                      Action<AbsListView, int, int, int> onScroll,
                                                      Action<AbsListView, ScrollState> onScrollStateChanged = null)
            where TView : AbsListView
        {
            return element.Setup(v => v.SetOnScrollListener(new OnScrollListener
                                                               {
                                                                   OnScroll = onScroll,
                                                                   OnScrollStateChanged = onScrollStateChanged
                                                               }));
        }

        /*****************************************************************
         * Spinner
         ****************************************************************/

        public static IElement<TView> Adapter<TView>(this IElement<TView> element, IList values)
            where TView : AbsSpinner
        {
            return element.Setup(v =>
                                    {
                                        var adapter = new ArrayAdapter(v.Context, R.Layout.SimpleSpinnerItem, values);
                                        adapter.SetDropDownViewResource(R.Layout.SimpleSpinnerDropDownItem);
                                        v.Adapter = adapter;
                                    });
        }
    }
}