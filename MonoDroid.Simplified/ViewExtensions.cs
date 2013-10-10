using System;
using Android.Support.V4.View;
using Android.Text;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using Java.Lang;
using MonoDroid.Simplified.EventHandlers;

namespace MonoDroid.Simplified
{
    public static class ViewExtensions
    {
        /*****************************************************************
         * Traversal
         ****************************************************************/

        public static View FindParentById(this View view, int id)
        {
            var p = view.Parent as View;
            while (p != null)
            {
                if (p.Id == id)
                {
                    return p;
                }
                p = p.Parent as View;
            }
            return null;
        }

        /*****************************************************************
         * General events
         ****************************************************************/

        public static TView OnKey<TView>(this TView view, Func<View, Keycode, KeyEvent, bool> onKey) where TView : View
        {
            view.SetOnKeyListener(new OnKeyListener {OnKey = onKey});
            return view;
        }

        public static TView OnKey<TView>(this TView view, Action<View, Keycode, KeyEvent> keyAction) where TView : View
        {
            view.SetOnKeyListener(new OnKeyListener
                                      {
                                          OnKey = (v, c, e) =>
                                                      {
                                                          keyAction(v, c, e);
                                                          return true;
                                                      }
                                      });
            return view;
        }

        public static TView OnClick<TView>(this TView view, Action<View> onClick) where TView : View
        {
            view.SetOnClickListener(new OnClickListener {OnClick = onClick});
            return view;
        }

        public static TView OnLongClick<TView>(this TView view, Func<View, bool> onLongClick) where TView : View
        {
            view.SetOnLongClickListener(new OnLongClickListener {OnLongClick = onLongClick});
            return view;
        }

        public static TView OnLongClick<TView>(this TView view, Action<View> onLongClick) where TView : View
        {
            view.SetOnLongClickListener(new OnLongClickListener
                                            {
                                                OnLongClick = v =>
                                                                  {
                                                                      onLongClick(v);
                                                                      return true;
                                                                  }
                                            });
            return view;
        }

        public static TView OnFocus<TView>(this TView view, Action<View, bool> onFocusChange) where TView: View
        {
            view.OnFocusChangeListener = new OnFocusChangeListener(){OnFocusChange = onFocusChange};
            return view;
        }

        public static TView OnCreateContextMenu<TView>(this TView view, Action<IContextMenu, View, IContextMenuContextMenuInfo> onCreateContextMenu) where TView : View
        {
            view.SetOnCreateContextMenuListener(new OnCreateContextMenuListener { OnCreateContextMenu = onCreateContextMenu });
            return view;
        }

        /*****************************************************************
         * AdapterView
         ****************************************************************/

        public static TView OnItemClick<TView>(this TView view, Action<int, View> onItemClick) where TView : AdapterView
        {
            view.OnItemClickListener = new OnItemClickListener
                                           {
                                               OnItemClick = (i, v, e) => onItemClick(i, v)
                                           };
            return view;
        }

        public static TView OnLongItemClick<TView>(this TView view, Action<int, View> onItemLongClick)
            where TView : AdapterView
        {
            view.OnItemLongClickListener = new OnItemLongClickListener
                                               {
                                                   OnItemLongClick = (i, v, e) =>
                                                                         {
                                                                             onItemLongClick(i, v);
                                                                             return true;
                                                                         }
                                               };
            return view;
        }

        public static TView OnLongItemClick<TView>(this TView view, Func<int, View, bool> onItemLongClick)
            where TView : AdapterView
        {
            view.OnItemLongClickListener = new OnItemLongClickListener
                                               {
                                                   OnItemLongClick = (i, v, e) => onItemLongClick(i, v)
                                               };
            return view;
        }

        public static TView OnItemSelected<TView>(this TView view, Action<int, View> onItemSelected,
                                                  Action onNothingSelected) where TView : AdapterView
        {
            view.OnItemSelectedListener = new OnItemSelectedListener
                                              {
                                                  OnItemSelected = (i, v, e) => onItemSelected(i, v),
                                                  OnNothingSelected = onNothingSelected
                                              };
            return view;
        }

        public static IElement SelectedElement<TView>(this TView view) where TView : AdapterView
        {
            var holder = view.SelectedItem as ListElementAdapter.ListElementHolder;
            return holder == null ? null : holder.Element;
        }

        /*****************************************************************
         * TextView
         ****************************************************************/

        public static TView OnTextChanged<TView>(this TView view,
            Action<TextChangedEventArgs> onTextChanged,
            Action<ICharSequence, int, int, int> onBeforeTextChanged = null,
            Action<IEditable> onAfterTextChanged = null)
            where TView : TextView
        {
            view.AddTextChangedListener(new TextWatcher
            {
                BeforeTextChanged = onBeforeTextChanged,
                OnTextChanged = onTextChanged,
                AfterTextChanged = onAfterTextChanged
            });
            return view;
        }


        /*****************************************************************
         * CompoundButton
         ****************************************************************/

        public static TView OnCheckedChange<TView>(this TView view, Action<CompoundButton, bool> onCheckedChange)
            where TView : CompoundButton
        {
            view.SetOnCheckedChangeListener(new OnCheckedChangeListenerForCompoundButton
                                                {
                                                    OnCheckedChange = onCheckedChange
                                                });
            return view;
        }

        /*****************************************************************
         * RadioGroup
         ****************************************************************/

        public static TView OnRadioCheckedChange<TView>(this TView view, Action<RadioGroup, int> onCheckedChange)
            where TView : RadioGroup
        {
            view.SetOnCheckedChangeListener(new OnCheckedChangeListenerForRadioGroup
                                                {
                                                    OnCheckedChanged = onCheckedChange
                                                });
            return view;
        }

        /*****************************************************************
         * ViewPager
         ****************************************************************/

        public static TView OnPageChange<TView>(this TView view, Action<int> onPageSelected) where TView : ViewPager
        {
            view.SetOnPageChangeListener(new OnPageChangeListener
                                             {
                                                 OnPageSelected = onPageSelected
                                             });
            return view;
        }

        /*****************************************************************
         * WebView
         ****************************************************************/

        public static TView LoadMarkup<TView>(this TView view, string markup) where TView : WebView
        {
            view.LoadDataWithBaseURL(null,
                                     markup,
                                     "text/html",
                                     "utf-8",
                                     null);
            return view;
        }
    }
}