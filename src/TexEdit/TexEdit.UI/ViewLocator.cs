/*
 *   Copyright (c) 2023 Jack Bennett
 *   All rights reserved.
 *
 *   Please see the LICENCE file for more information.
 */

using Avalonia.Controls;
using Avalonia.Controls.Templates;

using TexEdit.UI.ViewModels;

namespace TexEdit.UI {
    /// <summary>
    /// Class to connect view models to views
    /// </summary>
    public class ViewLocator : IDataTemplate {
        /// <summary>
        /// Build a view class from the given view model data
        /// </summary>
        /// <param name="data">View model object</param>
        /// <returns>Instance of the associated view type (if it is found)</returns>
        public IControl Build(object data) {
            string viewName = data.GetType().FullName!.Replace("ViewModel", "View");
            Type? viewType = Type.GetType(viewName);

            // view type is found
            if (viewType != null) {
                return (Control) Activator.CreateInstance(viewType)!;
            }

            return new TextBlock { Text = "Not found: " + viewName };
        }

        /// <summary>
        /// Return true if the given object is a view model
        /// </summary>
        /// <param name="data">Object to test for view-model-ness</param>
        /// <returns>True if `data` is a view model object</returns>
        public bool Match(object data) {
            return data is ViewModelBase;
        }
    }
}
