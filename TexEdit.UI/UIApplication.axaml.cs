/*
 *   Copyright (c) 2023 Jack Bennett
 *   All rights reserved.
 *
 *   Please see the LICENCE file for more information.
 */

using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

using TexEdit.UI.Views;
using TexEdit.UI.ViewModels;

namespace TexEdit.UI {
    /// <summary>
    /// TexEdit implementation of the Avalonia application class
    /// </summary>
    public class UIApplication : Application {
        /// <summary>
        /// Initialise the UI context
        /// </summary>
        public override void Initialize() {
            AvaloniaXamlLoader.Load(this);
        }

        /// <summary>
        /// After initialisation of Avalonia
        /// </summary>
        public override void OnFrameworkInitializationCompleted() {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop) {
                // create an editor window as the application's main window
                desktop.MainWindow = new EditorWindow();
                desktop.MainWindow.DataContext = new EditorWindowViewModel();
            }

            base.OnFrameworkInitializationCompleted();
        }

        /// <summary>
        /// Quit the entire process
        /// </summary>
        public static void Quit() {
            if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop) {
                desktop.MainWindow.Close();
                return;
            }

            // if for whatever reason the main window couldnt be accessed from the application lifetime then we just exit the process
            // this is less graceful but it is better than nothing.
            Environment.Exit(0);
        }

        /// <summary>
        /// Show about TexEdit dialogue
        /// </summary>
        public static void ShowAboutDialogue() {
            AboutDialogueWindow v = new AboutDialogueWindow();

            if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop) {
                v.ShowDialog(desktop.MainWindow);
            }
        }

        /// <summary>
        /// Show licence dialogue
        /// </summary>
        public static void ShowLicenceDialogue() {
            LicenceDialogueWindow v = new LicenceDialogueWindow();
            v.DataContext = new LicenceDialogueWindowViewModel();

            if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop) {
                v.ShowDialog(desktop.MainWindow);
            }
        }
    }
}
