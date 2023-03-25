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
    }
}
