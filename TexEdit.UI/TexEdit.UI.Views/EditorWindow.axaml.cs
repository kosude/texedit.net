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
    /// A class to provide an interface to editor windows, which serve as the 'main window' for the application.
    /// </summary>
    public partial class EditorWindow : Window {
        /// <summary>
        /// Initialise the editor window UI
        /// </summary>
        public EditorWindow() {
            InitializeComponent();
        }

        public void MenuItem_File_Quit(object sender, RoutedEventArgs e) => UIApplication.Quit();

        public void MenuItem_Help_GitRepository(object sender, RoutedEventArgs e) => Browser.OpenGitRepositoryWebPage();
        public void MenuItem_Help_ViewLicence(object sender, RoutedEventArgs e) => UIApplication.ShowLicenceDialogue();
        public void MenuItem_Help_AboutTexEdit(object sender, RoutedEventArgs e) => UIApplication.ShowAboutDialogue();
    }
}
