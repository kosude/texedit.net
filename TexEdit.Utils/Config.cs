/*
 *   Copyright (c) 2023 Jack Bennett
 *   All rights reserved.
 *
 *   Please see the LICENCE file for more information.
 */

//
// TODO: it would be much better for us to store configuration where it's actually supposed to be stored, i.e.:
//       on Linux + macOS: ~/.config/texedit/
//       on Windows: C:\Users\...\Appdata\Roaming\TexEdit\
// In the future it might be worth rolling my own configuration manager, but the current method works fine for now.
// (JSYK: it currently stores user config in the same folder as the executable, idiotic but this is Microsoft so that makes sense)
//

using System.Configuration;

namespace TexEdit.Utils {
    /// <summary>
    /// Config file read and write functions
    /// </summary>
    public class Config {
        /// <summary>
        /// Set key value in user configuration file
        /// </summary>
        /// <param name="key">Key to update</param>
        /// <param name="value">Value to set the key to</param>
        public static void SetKeyValue(string key, string value) {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            KeyValueConfigurationCollection keyValues = config.AppSettings.Settings;

            if (keyValues[key] == null) {
                keyValues.Add(key, value);
            } else {
                keyValues[key].Value = value;
            }

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);

            Debug.Log($"Wrote (\"{key}\" = \"{value}\") to config file at: {config.FilePath}");
        }

        /// <summary>
        /// Get the value of a key from the user's TexEdit configuration
        /// </summary>
        /// <param name="key">Name of the key to query</param>
        /// <returns>Value at `key`</returns>
        public static string GetKeyValue(string key) {
            string? r = ConfigurationManager.AppSettings[key];

            if (r == null) {
                throw new KeyNotFoundException($"No TexEdit config setting had key {key}");
            }

            return r;
        }
    }
}
