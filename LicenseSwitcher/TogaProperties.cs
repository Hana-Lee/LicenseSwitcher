﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.IO;
using System.Linq;

namespace LicenseSwitcher
{
    public static class TogaProperties
    {
        public static Dictionary<string, string> Properties;

        static TogaProperties(){}

        private static void Load_Properties()
        {
            const string homeDrive = "%HOMEDRIVE%";
            const string homePath = "%HOMEPATH%";
            var userHome = Environment.ExpandEnvironmentVariables(homeDrive + homePath) + "\\";
            var togaHome = userHome + ".kona\\";
            const string togaPropertiesFileName = "KONA.properties";

            Properties = File.ReadAllLines(togaHome + togaPropertiesFileName)
                .Where(row => !string.IsNullOrEmpty(row) && !row.StartsWith("#"))
                .ToDictionary(
                    row => row.Split('=')[0],
                    row => string.Join("=", row.Split('=').Skip(1).ToArray())
                );
        }

        public static string Get(string key)
        {
            Load_Properties();

            return Properties[key];
        }
    }
}