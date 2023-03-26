/*
 *   Copyright (c) 2023 Jack Bennett
 *   All rights reserved.
 *
 *   Please see the LICENCE file for more information.
 */

using Avalonia.Controls;
using Avalonia.Interactivity;

using TexEdit.Utils;

namespace TexEdit.UI.Views {
    /// <summary>
    /// A class to represent licence dialogue windows
    /// </summary>
    public partial class LicenceDialogueWindow : Window {
        /// <summary>
        /// Initialise the licence dialogue UI
        /// </summary>
        public LicenceDialogueWindow() {
            InitializeComponent();
        }

        public void Button_ViewOnline(object sender, RoutedEventArgs e) => Browser.OpenLicenceWebPage();
    }
}
