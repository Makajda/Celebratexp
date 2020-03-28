// Copyright (c) Makajda. All rights reserved. See LICENSE.md file in the solution root for full license information.
using Celebratexp.Common;
using Celebratexp.Models;
using Celebratexp.Repositories;
using Celebratexp.Services;
using Prism.Commands;
using Prism.Navigation;
using System;

namespace Celebratexp.ViewModels {
    public class DayPageViewModel : ViewModelBase {
        private DaysRepository daysRepository;
        private Day originalDay;

        public DayPageViewModel(INavigationService navigationService, DaysRepository daysRepository)
            : base(navigationService) {
            this.daysRepository = daysRepository;
            CancelCommand = new DelegateCommand(async () => await NavigationService.GoBackAsync());
            SaveCommand = new DelegateCommand(Save);
            RemoveCommand = new DelegateCommand(Remove);
        }

        private Day day;
        public Day Day {
            get { return day; }
            set { SetProperty(ref day, value); }
        }

        private bool isEdit;
        public bool IsEdit {
            get { return isEdit; }
            set { SetProperty(ref isEdit, value); }
        }

        public DelegateCommand CancelCommand { get; private set; }
        public DelegateCommand SaveCommand { get; private set; }
        public DelegateCommand RemoveCommand { get; private set; }

        public override void OnNavigatedTo(INavigationParameters parameters) {
            base.OnNavigatedTo(parameters);
            if (parameters.TryGetValue<Resultable>(Given.DayParameterName, out Resultable resultable)) {
                Day = resultable.Day.Clone();
                originalDay = Day.Clone();
                Title = LocaresExtension.GetString("EditDay");
                IsEdit = true;
            }
            else {
                Day = new Day() { Date = DateTime.Today };
                Title = LocaresExtension.GetString("AddDay");
                IsEdit = false;
            }
        }

        private async void Remove() {
            await daysRepository.RemoveDay(originalDay);
            await NavigationService.GoBackAsync((Given.NeedRecalcParameterName, true));
        }

        private async void Save() {
            if (IsEdit) {
                await daysRepository.EditDay(originalDay, Day);
            }
            else {
                await daysRepository.AddDay(Day);
            }

            await NavigationService.GoBackAsync((Given.NeedRecalcParameterName, true));
        }
    }
}
