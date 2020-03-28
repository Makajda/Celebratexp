// Copyright (c) Makajda. All rights reserved. See LICENSE.md file in the solution root for full license information.
using Celebratexp.Models;
using System;

namespace Celebratexp.Services {
    public abstract class Countable {
        public Countable(Day day, Pitstop pitstop, DateTime today) {
            Day = day;
            Pitstop = pitstop;
            var newValue = (long)Math.Abs(Pitstop.Total(Day.Date.Date, today.Date));
            Date = today;
            Value = newValue;
        }

        public Day Day { get; private set; }
        public Pitstop Pitstop { get; private set; }
        public DateTime Date { get; protected set; }
        public double Value { get; protected set; }
        public bool IsStoped { get; protected set; }

        public void CalcNext() {
            RecreateCutoff(1d);
        }

        protected abstract void RecreateCutoff(double delta);
    }
}
