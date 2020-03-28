// Copyright (c) Makajda. All rights reserved. See LICENSE.md file in the solution root for full license information.
using Android.App;
using Android.Content.PM;
using Android.Gms.Ads;
using Android.OS;
using Prism;
using Prism.Ioc;

namespace Celebratexp.Droid {
    [Activity(Label = "Celebratexp", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity {
        public static MainActivity Instance { get; private set; }

        protected override void OnCreate(Bundle bundle) {
            Instance = this;
            MobileAds.Initialize(this);
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App(new AndroidInitializer()));
        }
    }

    public class AndroidInitializer : IPlatformInitializer {
        public void RegisterTypes(IContainerRegistry containerRegistry) {
            // Register any platform specific implementations
        }
    }
}

