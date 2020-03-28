// Copyright (c) Makajda. All rights reserved. See LICENSE.md file in the solution root for full license information.
using Celebratexp.Common;
using System;
using System.Threading.Tasks;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(Celebratexp.UWP.Common.FileHelper))]

namespace Celebratexp.UWP.Common {
    public class FileHelper : IFileHelper {
        public async Task WriteTextAsync(string filename, string text) {
            var folder = ApplicationData.Current.RoamingFolder;
            var file = await folder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(file, text);
        }

        public async Task<string> ReadTextAsync(string filename) {
            var folder = ApplicationData.Current.RoamingFolder;
            var file = await folder.GetFileAsync(filename);
            return await FileIO.ReadTextAsync(file);
        }
    }
}
