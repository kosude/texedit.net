/*
 *   Copyright (c) 2023 Jack Bennett
 *   All rights reserved.
 *
 *   Please see the LICENCE file for more information.
 */

using System.Reactive;

using Avalonia.Controls;

using ReactiveUI;

namespace TexEdit.UI.ViewModels {
    /// <summary>
    /// View model for an editor window
    /// /// </summary>
    public class EditorWindowViewModel : ViewModelBase {
        // Menu item commands for bindings
        //
        public ReactiveCommand<Window, Unit> FileQuitCommand { get; }

        /// <summary>
        /// Construct and initialise the editor view model
        /// </summary>
        public EditorWindowViewModel() {
            // set up menu bar

            FileQuitCommand = ReactiveCommand.Create<Window>((window) => window?.Close());
        }
    }
}
