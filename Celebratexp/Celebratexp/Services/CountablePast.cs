// Copyright (c) Makajda. All rights reserved. See LICENSE.md file in the solution root for full license information.
using Celebratexp.Models;
using System;

namespace Celebratexp.Services {
    public class CountablePast : Countable {
        public CountablePast(Day day, Pitstop pitstop, DateTime today)
            : base(day, pitstop, today) {
            RecreateCutoff(0);
            while (!IsStoped && Date.Date >= today.Date) {
                RecreateCutoff(1d);
            }
        }

        protected override void RecreateCutoff(double delta) {
            try {
                double newValue;
                DateTime newDate;

                if (Date.Date > Day.Date.Date) {
                    newValue = Pitstop.Lessing(Value - delta);
                    newDate = Pitstop.Add(Day.Date.Date, newValue);
                }
                else {
                    newValue = Pitstop.Moreing(Value + delta);
                    newDate = Pitstop.Add(Day.Date.Date, -newValue);
                }

                Date = newDate;
                Value = newValue;
            }
            catch (ArgumentOutOfRangeException) {
                IsStoped = true;
            }
        }
    }
}
