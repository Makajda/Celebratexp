// Copyright (c) Makajda. All rights reserved. See LICENSE.md file in the solution root for full license information.
using Celebratexp.Common;
using Celebratexp.Services;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Celebratexp.ViewModels {
    public class MainPageViewModel : ViewModelBase {
        public MainPageViewModel(INavigationService navigationService, Calc calc)
            : base(navigationService) {
            Title = "Celebratexp";
            Calc = calc;
            AddDayCommand = new DelegateCommand(async () => await NavigationService.NavigateAsync(Given.DayPageName));
            EditDayCommand = new DelegateCommand<object>(async (n) =>
                await NavigationService.NavigateAsync(Given.DayPageName, (Given.DayParameterName, n)));
        }

        public Calc Calc { get; private set; }
        public DelegateCommand AddDayCommand { get; private set; }
        public DelegateCommand<object> EditDayCommand { get; private set; }

        private IEnumerable<Resultable> resultables;
        public IEnumerable<Resultable> Resultables {
            get { return resultables; }
            private set { SetProperty(ref resultables, value); }
        }

        private Resultable startToday;
        public Resultable StartToday {
            get { return startToday; }
            private set { SetProperty(ref startToday, value); }
        }

        public override async void OnNavigatedTo(INavigationParameters parameters) {
            base.OnNavigatedTo(parameters);
            var navigationMode = parameters.GetNavigationMode();
            if (navigationMode != NavigationMode.Back || parameters.TryGetValue<bool>(Given.NeedRecalcParameterName, out bool _)) {
                var (resultables, startToday) = await Calc.Recalc();
                await Device.InvokeOnMainThreadAsync(() => { Resultables = resultables; StartToday = startToday; });
            }
        }
    }
}
