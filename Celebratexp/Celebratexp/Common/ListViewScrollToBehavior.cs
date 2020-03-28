// Copyright (c) Makajda. All rights reserved. See LICENSE.md file in the solution root for full license information.
using Prism.Behaviors;
using Xamarin.Forms;

namespace Celebratexp.Common {
    public class ListViewScrollToBehavior : BehaviorBase<ListView> {
        public static readonly BindableProperty ItemProperty =
                    BindableProperty.Create(nameof(Item), typeof(object), typeof(ListViewScrollToBehavior), propertyChanged: OnItemChanged);

        private static void OnItemChanged(BindableObject bindable, object oldValue, object newValue) {
            (bindable as ListViewScrollToBehavior).AssociatedObject.ScrollTo(newValue, ScrollToPosition.MakeVisible, false);
        }

        public object Item {
            get { return (object)GetValue(ItemProperty); }
            set { SetValue(ItemProperty, value); }
        }
    }
}
