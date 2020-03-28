// Copyright (c) Makajda. All rights reserved. See LICENSE.md file in the solution root for full license information.
using Celebratexp.Localize;
using System;
using System.Globalization;
using System.Resources;
using System.Threading;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Celebratexp.Common {
    [ContentProperty("Text")]
    public class LocaresExtension : IMarkupExtension {
        static readonly string embeddedResourceName;
        static readonly Lazy<ResourceManager> resourceManager;

        static LocaresExtension() {
            embeddedResourceName = $"{Given.Namespace}.Localize.Locares";
            resourceManager = new Lazy<ResourceManager>(() => new ResourceManager(embeddedResourceName, Given.Assembly));
        }

        //It does not for MarkupExtension
        public static void SetCulture() {
            try {
                Locares.Culture = new CultureInfo(Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName);
            }
            catch (Exception) {
                Locares.Culture = new CultureInfo("en");
            }
        }

        public static string GetString(string name) {
            var translation = resourceManager.Value.GetString(name, Locares.Culture);
            if (translation == null) {
#if DEBUG
                throw new ArgumentException(
                    string.Format("Key '{0}' was not found in resources '{1}' for culture '{2}'.",
                    name, embeddedResourceName, Locares.Culture.Name), "Text");
#else
                translation = name; // HACK: returns the key, which GETS DISPLAYED TO THE USER
#endif
            }

            return translation;
        }

        //MarkupExtension
        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider) {
            if (Text == null)
                return string.Empty;
            else
                return GetString(Text);
        }
    }
}
