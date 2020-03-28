// Copyright (c) Makajda. All rights reserved. See LICENSE.md file in the solution root for full license information.
using Prism.Mvvm;
using Prism.Navigation;

namespace Celebratexp.ViewModels {
    public class ViewModelBase : BindableBase, IInitialize, INavigationAware, IDestructible {
        protected INavigationService NavigationService { get; private set; }

        private string _title;
        public string Title {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ViewModelBase(INavigationService navigationService) {
            NavigationService = navigationService;
        }

        public virtual void Initialize(INavigationParameters parameters) {

        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters) {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters) {

        }

        public virtual void Destroy() {

        }
    }
}
