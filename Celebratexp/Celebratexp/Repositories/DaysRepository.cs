// Copyright (c) Makajda. All rights reserved. See LICENSE.md file in the solution root for full license information.
using Celebratexp.Common;
using Celebratexp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Celebratexp.Repositories {
    public class DaysRepository {
        private const string filename = "days.txt";
        private const string dateFormat = "yyyyMMdd";

        public async Task<List<Day>> GetDays() {
            List<Day> days = null;

            try {
                days = await ReadDays();
            }
            catch (Exception e) {
                LogHelper.Logger.Error(e);
            }

            if (days == null) {
                days = new List<Day>()
                {
                    new Day() { Date = new DateTime(1928, 11, 18), Name = "Birthday of Mickey Mouse" }
                    //new Day() { Date = DateTime.Today, Name = "Today" }
                };
            }

            return days;
        }

        public async Task AddDay(Day day) {
            var days = await GetDays();
            days.Add(day);
            await WriteDays(days);
        }

        public async Task EditDay(Day originalDay, Day day) {
            var days = await GetDays();
            var findingDay = days.FirstOrDefault(n => n.Equals(originalDay));
            if (findingDay != null) {
                day.CopyTo(findingDay);
                await WriteDays(days);
            }
        }

        public async Task RemoveDay(Day originalDay) {
            var days = await GetDays();
            var findingDay = days.FirstOrDefault(n => n.Equals(originalDay));
            if (findingDay != null) {
                days.Remove(findingDay);
                await WriteDays(days);
            }
        }

        private async Task<List<Day>> ReadDays() {
            var r = await FileHelper.ReadTextAsync(filename);
            var s = r.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var days = new List<Day>();
            foreach (var d in s) {
                var day = GetDay(d);
                if (day != null) {
                    days.Add(day);
                }
            }

            return days;
        }

        private Day GetDay(string line) {
            var day = new Day();

            if (line.Length > 0) {
                DateTime date;
                if (DateTime.TryParseExact(
                    line.Substring(0, 8),
                    dateFormat,
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.AssumeUniversal,
                    out date)) {
                    day.Date = date;
                }

                if (line.Length > 8) {
                    day.Name = line.Substring(8).Trim();
                }
            }

            return day;
        }

        private async Task WriteDays(IEnumerable<Day> days) {
            try {
                var r = string.Join(Environment.NewLine, days.Select((day) => $"{day.Date.ToString(dateFormat)} {day.Name}"));
                await FileHelper.WriteTextAsync(filename, r);
            }
            catch (Exception e) {
                LogHelper.Logger.Error(e);
            }
        }
    }
}
