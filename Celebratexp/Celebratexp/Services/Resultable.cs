// Copyright (c) Makajda. All rights reserved. See LICENSE.md file in the solution root for full license information.
using Celebratexp.Models;
using System;

namespace Celebratexp.Services {
    public class Resultable {
        public Resultable(Countable countable) {
            Day = countable.Day;
            Pitstop = countable.Pitstop;
            Date = countable.Date;
            Value = countable.Value;
        }

        public Day Day { get; private set; }
        public Pitstop Pitstop { get; private set; }
        public DateTime Date { get; private set; }
        public double Value { get; private set; }
    }
}
