// Copyright (c) Makajda. All rights reserved. See LICENSE.md file in the solution root for full license information.
using Prism.Mvvm;
using System;
using System.Collections.Generic;

namespace Celebratexp.Models {
    public class Day : BindableBase {
        private DateTime date;
        private string name;

        public DateTime Date {
            get { return date; }
            set { SetProperty(ref date, value); }
        }

        public string Name {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        public Day Clone() {
            return new Day() { Date = this.Date, Name = this.Name };
        }

        public void CopyTo(Day result) {
            result.Date = this.Date;
            result.Name = this.Name;
        }

        // Time does not compare
        public override bool Equals(object obj) {
            return obj is Day day &&
                   Date.Date == day.Date.Date &&
                   Name == day.Name;
        }

        public override int GetHashCode() {
            var hashCode = 1150885479;
            hashCode = hashCode * -1521134295 + Date.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            return hashCode;
        }

        public override string ToString() {
            return $"{base.ToString()}: {Date.ToShortDateString()}, {Name}";
        }
    }
}
