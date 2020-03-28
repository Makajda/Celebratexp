// Copyright (c) Makajda. All rights reserved. See LICENSE.md file in the solution root for full license information.
using System;
using Xamarin.Forms;

namespace Celebratexp.Models {
    public class Pitstop {
        public string Name { get; set; }
        public string Title { get; set; }
        public bool IsAllowZero { get; set; }
        public ImageSource ImageSource { get; set; }
        public Func<DateTime, double, DateTime> Add { get; set; }
        public Func<DateTime, DateTime, double> Total { get; set; }

        public virtual double Moreing(double value) {
            return value;
        }

        public virtual double Lessing(double value) {
            return value;
        }
    }
}
