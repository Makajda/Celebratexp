// Copyright (c) Makajda. All rights reserved. See LICENSE.md file in the solution root for full license information.
using Celebratexp.Common;
using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(Celebratexp.Droid.Common.FileHelper))]

namespace Celebratexp.Droid.Common {
    public class FileHelper : IFileHelper {
        public async Task WriteTextAsync(string filename, string text) {
            var folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var file = Path.Combine(folder, filename);
            await File.WriteAllTextAsync(file, text);
        }

        public async Task<string> ReadTextAsync(string filename) {
            var folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var file = Path.Combine(folder, filename);
            var text = await File.ReadAllTextAsync(file);
            return text;
        }
    }
}