// Copyright (c) Makajda. All rights reserved. See LICENSE.md file in the solution root for full license information.
using Celebratexp.Common;
using Celebratexp.Models;
using System;
using System.Collections.Generic;

namespace Celebratexp.Repositories {
    public static class PitstopsRepository {
        public static List<Pitstop> GetAll() {
            var retval = new List<Pitstop>();

            // ***************************************************
            retval.Add(new Pitstop() {
                Name = "Year",
                IsAllowZero = true,
                Add = (d, n) => d.AddYears((int)n),
                Total = (d, t) => {
                    var c = new DateTime(t.Year, d.Month, d.Day);
                    double tValue = Math.Abs(t.Year - d.Year);
                    if (t.Date >= d.Date) {
                        if (c.Date > t.Date) {
                            tValue -= 1d;
                        }
                    }
                    else {
                        if (c.Date < t.Date) {
                            tValue -= 1d;
                        }
                    }

                    return tValue;
                }
            });

            // ***************************************************
            const double SiderealPeriodVenus = 224.70069d;
            retval.Add(new Pitstop() {
                Name = "Venus",
                Add = (d, n) => d.AddDays(n * SiderealPeriodVenus),
                Total = (d, t) => (t - d).TotalDays / SiderealPeriodVenus
            });

            // ***************************************************
            const double SiderealPeriodMars = 686.971d;
            retval.Add(new Pitstop() {
                Name = "Mars",
                Add = (d, n) => d.AddDays(n * SiderealPeriodMars),
                Total = (d, t) => (t - d).TotalDays / SiderealPeriodMars
            });

            // ***************************************************
            const double SiderealPeriodJupiter = 4331.572d;
            retval.Add(new Pitstop() {
                Name = "Jupiter",
                Add = (d, n) => d.AddDays(n * SiderealPeriodJupiter),
                Total = (d, t) => (t - d).TotalDays / SiderealPeriodJupiter
            });

            // ***************************************************
            const double SiderealPeriodSaturn = 10832.327d;
            retval.Add(new Pitstop() {
                Name = "Saturn",
                Add = (d, n) => d.AddDays(n * SiderealPeriodSaturn),
                Total = (d, t) => (t - d).TotalDays / SiderealPeriodSaturn
            });

            // ***************************************************
            const double DistanceMoon = 384401d;
            const double SpeedMoon = 5d;
            retval.Add(new Pitstop() {
                Name = "Moon",
                Add = (d, n) => d.AddHours(n * DistanceMoon / SpeedMoon),
                Total = (d, t) => (t - d).TotalHours * SpeedMoon / DistanceMoon
            });

            // ***************************************************
            retval.Add(new PitstopCent() {
                Name = "Month",
                Cent = 100d,
                Add = (d, n) => d.AddMonths((int)n),
                Total = (d, t) => {
                    double todayValue = Math.Abs(((t.Year - d.Year) * 12) + t.Month - d.Month);
                    if (t.Date >= d.Date) {
                        if (t.Day < d.Day) {
                            todayValue -= 1d;
                        }
                    }
                    else {
                        if (d.Day < t.Day) {
                            todayValue -= 1d;
                        }
                    }

                    return todayValue;
                }
            });

            // ***************************************************
            retval.Add(new PitstopCent() {
                Name = "Week",
                Cent = 100d,
                Add = (d, n) => d.AddDays(n * 7),
                Total = (d, t) => (t - d).TotalDays / 7
            });

            // ***************************************************
            retval.Add(new PitstopCent() {
                Name = "Day",
                Cent = 1_000d,
                Add = (d, n) => d.AddDays(n),
                Total = (d, t) => (t - d).TotalDays
            });

            // ***************************************************
            retval.Add(new PitstopCent() {
                Name = "Hour",
                Cent = 100_000d,
                Add = (d, n) => d.AddHours(n),
                Total = (d, t) => (t - d).TotalHours
            });

            // ***************************************************
            retval.Add(new PitstopCent() {
                Name = "Minute",
                Cent = 1_000_000d,
                Add = (d, n) => d.AddMinutes(n),
                Total = (d, t) => (t - d).TotalMinutes
            });

            // ***************************************************
            retval.Add(new PitstopCent() {
                Name = "Second",
                Cent = 100_000_000d,
                Add = (d, n) => d.AddSeconds(n),
                Total = (d, t) => (t - d).TotalSeconds
            });

            foreach (var pitstop in retval) {
                pitstop.Title = LocaresExtension.GetString($"Ps{pitstop.Name}Title");
                pitstop.ImageSource = ImageresExtension.GetImageSource($"{pitstop.Name}.png");
            }

            return retval;
        }
    }
}
