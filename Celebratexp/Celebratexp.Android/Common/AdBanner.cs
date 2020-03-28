// Copyright (c) Makajda. All rights reserved. See LICENSE.md file in the solution root for full license information.
using Android.Content;
using Android.Gms.Ads;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using PclAdBanner = Celebratexp.Common.AdBanner;

[assembly: ExportRenderer(typeof(PclAdBanner), typeof(Celebratexp.Droid.Common.AdBanner))]

namespace Celebratexp.Droid.Common {
    public class AdBanner : ViewRenderer<PclAdBanner, AdView> {
        public AdBanner(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<PclAdBanner> e) {
            base.OnElementChanged(e);
            if (e.OldElement == null) {
                var adView = new AdView(Context) { AdUnitId = PclAdBanner.UnitId, AdSize = AdSize.Banner };
                var adParams = new LinearLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent);
                adView.LayoutParameters = adParams;
                var requestbuilder = new AdRequest.Builder();
                adView.LoadAd(requestbuilder.Build());
                SetNativeControl(adView);
            }
        }
    }
}