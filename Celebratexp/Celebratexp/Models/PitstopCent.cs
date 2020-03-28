// Copyright (c) Makajda. All rights reserved. See LICENSE.md file in the solution root for full license information.
using System;

namespace Celebratexp.Models {
    public class PitstopCent : Pitstop {
        public double Cent { get; set; }

        public override double Moreing(double value) {
            double cent = GetCent(value);
            double t = value / cent;

            // only integer
            // double res1 = Math.Ceiling(t) * cent;
            // return Math.Ceiling(t) * cent;

            // integer - 0,5
            double res1, res05;
            res1 = Math.Ceiling(t);
            res05 = res1 - 0.5d;
            if (res05 > t) {
                res1 = res05;
            }

            res1 *= cent;

            // single-digit
            int q = (int)t;
            double res2 = GetEq(q, cent);
            if (res2 < value) {
                if (q == 9) {
                    res2 = GetEq(1, cent * 10d);
                }
                else {
                    res2 = GetEq(q + 1, cent);
                }
            }

            return Math.Min(res1, res2);
        }

        public override double Lessing(double value) {
            double cent = GetCent(value);
            double t = value / cent;

            // only integer
            // double res1 = Math.Floor(t) * cent;
            // return Math.Floor(t) * cent;

            // integer + 0,5
            double res1, res05;
            res1 = Math.Floor(t);
            res05 = res1 + 0.5d;
            if (res05 < t) {
                res1 = res05;
            }

            res1 *= cent;

            // single-digit
            int q = (int)t;
            double res2 = GetEq(q, cent);
            if (res2 > value) {
                if (q == 1) {
                    res2 = GetEq(9, cent / 10d);
                }
                else {
                    res2 = GetEq(q - 1, cent);
                }
            }

            return Math.Max(res1, res2);
        }

        private double GetCent(double value) {
            double cent = Cent;
            do {
                cent *= 10d;
            } while (value > cent);
            return cent / 10d;
        }

        private double GetEq(int d, double cent) {
            double n = d;
            while (cent > 3) {
                n += d * cent;
                cent /= 10d;
            }

            return n;
        }
    }
}
