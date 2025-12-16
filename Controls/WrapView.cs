using System;
using System.Collections;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Layouts;

namespace FirstResponseMAUI.Controls
{
    public class WrapView : ContentView
    {
        private readonly FlexLayout _flexLayout;

        public WrapView()
        {
            _flexLayout = new FlexLayout
            {
                Wrap = FlexWrap.Wrap,
                AlignContent = FlexAlignContent.Start,
                AlignItems = FlexAlignItems.Start,
                JustifyContent = FlexJustify.Start
            };
            Content = _flexLayout;
            UpdateOrientation();
        }

        public static readonly BindableProperty OrientationProperty =
            BindableProperty.Create(nameof(Orientation), typeof(StackOrientation), typeof(WrapView), StackOrientation.Vertical,
                BindingMode.TwoWay, propertyChanged: OnOrientationChanged);

        public StackOrientation Orientation
        {
            get { return (StackOrientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }

        public static readonly BindableProperty SpacingProperty =
            BindableProperty.Create(nameof(Spacing), typeof(double), typeof(WrapView), 0d,
                BindingMode.TwoWay, propertyChanged: OnSpacingChanged);

        public double Spacing
        {
            get { return (double)GetValue(SpacingProperty); }
            set { SetValue(SpacingProperty, value); }
        }

        public static readonly BindableProperty ItemTemplateProperty =
            BindableProperty.Create(nameof(ItemTemplate), typeof(DataTemplate), typeof(WrapView), null,
                BindingMode.TwoWay, propertyChanged: OnItemTemplateChanged);

        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }

        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable), typeof(WrapView), default(IEnumerable),
                BindingMode.TwoWay, propertyChanged: OnSourceChanged);

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly BindableProperty ItemClickCommandProperty =
            BindableProperty.Create(nameof(ItemClickCommand), typeof(ICommand), typeof(WrapView), default(ICommand));

        public ICommand ItemClickCommand
        {
            get { return (ICommand)GetValue(ItemClickCommandProperty); }
            set { SetValue(ItemClickCommandProperty, value); }
        }

        private static void OnOrientationChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((WrapView)bindable).UpdateOrientation();
        }

        private void UpdateOrientation()
        {
            // Original WrapView:
            // Vertical -> Fill columns (Height constrained, wraps to next column)
            // Horizontal -> Fill rows (Width constrained, wraps to next row)
            
            // FlexLayout:
            // Column -> Items stacked vertically. Wrap -> wraps to next column.
            // Row -> Items stacked horizontally. Wrap -> wraps to next row.

            _flexLayout.Direction = Orientation == StackOrientation.Vertical 
                ? FlexDirection.Column 
                : FlexDirection.Row;
        }

        private static void OnSpacingChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((WrapView)bindable).UpdateSpacing();
        }

        private void UpdateSpacing()
        {
            foreach (View child in _flexLayout.Children)
            {
                UpdateChildMargin(child);
            }
        }

        private void UpdateChildMargin(View view)
        {
            // Apply margin to simulate spacing
            // Note: This applies margin to all sides or specific sides depending on desired behavior.
            // Simple approach: Apply Right and Bottom margin
            view.Margin = new Thickness(0, 0, Spacing, Spacing);
        }

        private static void OnItemTemplateChanged(BindableObject bindable, object oldValue, object newValue)
        {
            // Re-create items if template changes
            var wrapView = (WrapView)bindable;
            if (wrapView.ItemsSource != null)
            {
                wrapView._flexLayout.Children.Clear();
                wrapView.AddItems(wrapView.ItemsSource);
            }
        }

        private static void OnSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var wrapView = (WrapView)bindable;

            if (oldValue != null)
            {
                var observableCollection = oldValue as INotifyCollectionChanged;
                if (observableCollection != null)
                    observableCollection.CollectionChanged -= wrapView.OnCollectionChanged;
            }

            if (newValue != null)
            {
                var observableCollection = newValue as INotifyCollectionChanged;
                if (observableCollection != null)
                    observableCollection.CollectionChanged += wrapView.OnCollectionChanged;

                wrapView._flexLayout.Children.Clear();
                wrapView.AddItems((IEnumerable)newValue);
            }
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            switch (args.Action)
            {
                case NotifyCollectionChangedAction.Reset:
                    _flexLayout.Children.Clear();
                    break;

                case NotifyCollectionChangedAction.Add:
                    AddItems(args.NewItems);
                    break;

                case NotifyCollectionChangedAction.Remove:
                    RemoveItems(args.OldItems);
                    break;
            }
        }

        private void RemoveItems(IEnumerable items)
        {
            foreach (object item in items)
            {
                var child = _flexLayout.Children.FirstOrDefault(c => (c as View)?.BindingContext == item);
                if (child != null)
                    _flexLayout.Children.Remove(child);
            }
        }

        private void AddItems(IEnumerable items)
        {
            foreach (object item in items)
            {
                var child = CreateViewFor(item);
                if (child == null)
                    continue;

                child.BindingContext = item;
                UpdateChildMargin(child);
                _flexLayout.Children.Add(child);
            }
        }

        protected virtual View CreateViewFor(object item)
        {
            if (ItemTemplate == null)
                return new Label { Text = item.ToString() };

            var content = ItemTemplate.CreateContent();

            if (!(content is View) && !(content is ViewCell))
                return null;

            var view = (content is View) ? content as View : ((ViewCell)content).View;
            
            // Add tap gesture if command is present
            var tapGesture = new TapGestureRecognizer();
            tapGesture.Tapped += (s, e) => 
            {
                if (ItemClickCommand != null && ItemClickCommand.CanExecute(item))
                    ItemClickCommand.Execute(item);
            };
            view.GestureRecognizers.Add(tapGesture);

            return view;
        }
    }
}
