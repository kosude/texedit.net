/*
 *   Copyright (c) 2023 Jack Bennett
 *   All rights reserved.
 *
 *   Please see the LICENCE file for more information.
 */

using System.Reactive;

using Avalonia.Controls;
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

            this.WhenActivated(d => {
                d(ViewModel!.ShowAboutDialogue.RegisterHandler(_DoShowDialogueAsync<AboutDialogueWindow, AboutDialogueViewModel>));
            });
        }

        /// <summary>
        /// Create and show the specified dialogue object
        /// </summary>
        /// <param name="interaction">Interaction context containing the about dialogue view model</param>
        /// <typeparam name="V">Dialogue object view type</typeparam>
        /// <typeparam name="VM">Dialogue object view model type</typeparam>
        private async Task _DoShowDialogueAsync<V, VM>(InteractionContext<VM, Unit> interaction)
            where V : Window, new()
            where VM : ViewModelBase
        {
            V dialogue = new V();
            dialogue.DataContext = interaction.Input;

            Unit result = await dialogue.ShowDialog<Unit>(this);
            interaction.SetOutput(result);
        }
    }
}
