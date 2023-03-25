/*
 *   Copyright (c) 2023 Jack Bennett
 *   All rights reserved.
 *
 *   Please see the LICENCE file for more information.
 */

using Avalonia.Controls;

namespace TexEdit.UI.Views {
    /// <summary>
    /// A class to represent about-texedit dialogue windows
    /// </summary>
    public partial class AboutDialogueWindow : Window {
        /// <summary>
        /// Initialise the about dialogue UI
        /// </summary>
        public AboutDialogueWindow() {
            InitializeComponent();

            ClientSize = new Avalonia.Size(280, 360);
            CanResize = false;
        }
    }
}
