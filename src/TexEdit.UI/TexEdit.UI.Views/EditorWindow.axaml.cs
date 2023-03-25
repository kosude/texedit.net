/*
 *   Copyright (c) 2023 Jack Bennett
 *   All rights reserved.
 *
 *   Please see the LICENCE file for more information.
 */

using Avalonia.Controls;

namespace TexEdit.UI.Views {
    /// <summary>
    /// A class to provide an interface to editor windows, which serve as the 'main window' for the application.
    /// </summary>
    public partial class EditorWindow : Window {
        public EditorWindow() {
            InitializeComponent();

            // default window size
            // TODO: get from config that is saved on window close (so that size persists)
            ClientSize = new Avalonia.Size(1280, 720);
        }
    }
}
