// Copyright (c) Makajda. All rights reserved. See LICENSE.md file in the solution root for full license information.
using NLog;
using NLog.Config;
using System;
using System.Diagnostics;
using System.Xml;

namespace Celebratexp.Common {
    public static class LogHelper {
        public static ILogger Logger {
            get {
                return LogManager.GetCurrentClassLogger();
            }
        }

        public static void ConfigureLogger(string configFileName = "NLog.config") {
            try {
                var embeddedResourceName = $"{Given.Namespace}.{configFileName}";
                var stream = Given.Assembly.GetManifestResourceStream(embeddedResourceName);
                var xmlReader = XmlReader.Create(stream);
                LogManager.Configuration = new XmlLoggingConfiguration(xmlReader, configFileName);
            }
            catch (Exception e) {
                Debug.WriteLine(e.Message);
            }
        }
    }
}
