// Copyright (c) Makajda. All rights reserved. See LICENSE.md file in the solution root for full license information.
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Celebratexp.Common {
    [ContentProperty("ImageName")]
    public class ImageresExtension : IMarkupExtension {
        public static ImageSource GetImageSource(string imageName) {
            var embeddedResourceName = $"{Given.Namespace}.Images.{imageName}";
            var imageSource = ImageSource.FromResource(embeddedResourceName);
            return imageSource;
        }

        public string ImageName { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider) {
            return GetImageSource(ImageName);
        }
    }
}
