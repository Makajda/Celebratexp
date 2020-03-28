// Copyright (c) Makajda. All rights reserved. See LICENSE.md file in the solution root for full license information.
using System;
using System.Globalization;
using Xamarin.Forms;

namespace Celebratexp.Common {
    public sealed class DateToColorConverter : IValueConverter {
        private static Color colorFuture = Color.FromRgb(0x90, 0xCE, 0xF6);
        private static Color colorPast = Color.FromRgb(0xF6, 0xE4, 0x90);
        private static Color colorToday = Color.FromRgb(0xF7, 0xE2, 0xF7);

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            var today = DateTime.Today;
            var date = (DateTime)value;

            if (date < today) return colorPast;
            if (date > today) return colorFuture;
            return colorToday;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
