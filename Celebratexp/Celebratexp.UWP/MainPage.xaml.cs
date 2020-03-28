// Copyright (c) Makajda. All rights reserved. See LICENSE.md file in the solution root for full license information.
using Prism;
using Prism.Ioc;

namespace Celebratexp.UWP {
    public sealed partial class MainPage {
        public MainPage() {
            this.InitializeComponent();

            LoadApplication(new Celebratexp.App(new UwpInitializer()));
        }
    }

    public class UwpInitializer : IPlatformInitializer {
        public void RegisterTypes(IContainerRegistry containerRegistry) {
            // Register any platform specific implementations
        }
    }
}
