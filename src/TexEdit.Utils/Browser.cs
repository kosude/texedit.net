/*
 *   Copyright (c) 2023 Jack Bennett
 *   All rights reserved.
 *
 *   Please see the LICENCE file for more information.
 */

using System.Diagnostics;

namespace TexEdit.Utils {
    /// <summary>
    /// TexEdit browser utils
    /// </summary>
    public class Browser {
        /// <summary>
        /// Open a web page in the user's default web browser
        /// </summary>
        /// <returns>False if there was an error</returns>
        public static bool OpenWebPage(string url) {
            Process proc = new Process();

            Debug.Log($"Attempting to open webpage at {url}");

            try {
                proc.StartInfo.UseShellExecute = true;
                proc.StartInfo.FileName = url;
                proc.Start();
            } catch (Exception e) {
                Debug.Error(e.Message);
                return false;
            }

            return true;
        }

        /// <summary>
        /// URL to the online web-page of the TexEdit git repository (on github)
        /// </summary>
        public const string GitRepositoryURL = "https://github.com/kosude/texedit";

        /// <summary>
        /// Open the online web-page of the TexEdit git repository (on github) in the user's default web browser
        /// </summary>
        /// <returns>False if there was an error</returns>
        public static bool OpenGitRepositoryWebPage() {
            return OpenWebPage(GitRepositoryURL);
        }

        /// <summary>
        /// Open the online web-page of the TexEdit git repository (on github) into the LICENCE file.
        /// </summary>
        /// <returns>False if there was an error</returns>
        public static bool OpenLicenceWebPage() {
            return OpenWebPage($"{GitRepositoryURL}/blob/master/LICENCE");
        }
    }
}
