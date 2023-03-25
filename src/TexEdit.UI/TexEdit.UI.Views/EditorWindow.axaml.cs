/*
 *   Copyright (c) 2023 Jack Bennett
 *   All rights reserved.
 *
 *   Please see the LICENCE file for more information.
 */

using System.Reactive;

using Avalonia.ReactiveUI;

using ReactiveUI;

using TexEdit.UI.ViewModels;

namespace TexEdit.UI.Views {
    /// <summary>
    /// A class to provide an interface to editor windows, which serve as the 'main window' for the application.
    /// </summary>
    public partial class EditorWindow : ReactiveWindow<EditorWindowViewModel> {
        /// <summary>
        /// Initialise the editor window UI
        /// </summary>
        public EditorWindow() {
            InitializeComponent();

            // default window size
            // TODO: get from config that is saved on window close (so that size persists)
            ClientSize = new Avalonia.Size(1280, 720);

            this.WhenActivated(d => d(ViewModel!.ShowAboutDialogue.RegisterHandler(_DoShowAboutDialogueAsync)));
        }

        /// <summary>
        /// Create and show the about-texedit dialogue
        /// </summary>
        /// <param name="interaction">Interaction context containing the about dialogue view model</param>
        private async Task _DoShowAboutDialogueAsync(InteractionContext<AboutDialogueViewModel, Unit> interaction) {
            AboutDialogueWindow dialogue = new AboutDialogueWindow();
            dialogue.DataContext = interaction.Input;

            Unit result = await dialogue.ShowDialog<Unit>(this);
            interaction.SetOutput(result);
        }
    }
}
