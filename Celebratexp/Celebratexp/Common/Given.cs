// Copyright (c) Makajda. All rights reserved. See LICENSE.md file in the solution root for full license information.
using System.Reflection;

namespace Celebratexp.Common {
    public static class Given {
        static Given() {
            var appType = App.Current.GetType();
            Namespace = appType.Namespace;
            Assembly = appType.Assembly;
        }

        public static string Namespace { get; private set; }
        public static Assembly Assembly { get; private set; }
        public const string DayPageName = "DayPage";
        public const string DayParameterName = "Day";
        public const string NeedRecalcParameterName = "NeedRecalc";
    }
}
