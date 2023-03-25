/*
 *   Copyright (c) 2023 Jack Bennett
 *   All rights reserved.
 *
 *   Please see the LICENCE file for more information.
 */

using System.Reactive;
using System.Reactive.Linq;

using ReactiveUI;

using TexEdit.Utils;

namespace TexEdit.UI.ViewModels {
    /// <summary>
    /// View model for an editor window
    /// /// </summary>
    public class EditorWindowViewModel : ViewModelBase {
        // Menu item commands for bindings
        //
        public ReactiveCommand<Unit, Unit> FileQuitCommand { get; }                 // Quit the application

        public ReactiveCommand<Unit, bool> HelpGitRepositoryCommand { get; }        // Open the GH repo
        public ReactiveCommand<Unit, Unit> HelpAboutCommand { get; }                // Show about-texedit dialogue

        /// <summary>
        /// Interaction to show the about dialogue window
        /// </summary>
        public Interaction<AboutDialogueViewModel, Unit> ShowAboutDialogue { get; }

        /// <summary>
        /// Construct and initialise the editor view model
        /// </summary>
        public EditorWindowViewModel() {
            // about-dialogue interaction
            ShowAboutDialogue = new Interaction<AboutDialogueViewModel, Unit>();

            // set up menu bar commands...

            FileQuitCommand = ReactiveCommand.Create(() => UIApplication.Quit());

            HelpGitRepositoryCommand = ReactiveCommand.Create(() => Browser.OpenGitRepositoryWebPage());
            HelpAboutCommand = ReactiveCommand.CreateFromTask(async () => {
                AboutDialogueViewModel aboutDialogue = new AboutDialogueViewModel();
                Unit result = await ShowAboutDialogue.Handle(aboutDialogue);
            });
        }
    }
}
