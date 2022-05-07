// <copyright file="EditorServiceViaWindow.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PremierLeague.WpfApp.UI
{
    using PremierLeague.WpfApp.BL;
    using PremierLeague.WpfApp.Data;

    /// <summary>
    /// An editorservice via window.
    /// </summary>
    public class EditorServiceViaWindow : IEditorService
    {
        /// <summary>
        /// True if the player is to be edited.
        /// </summary>
        /// <param name="p">The selected player.</param>
        /// <returns>Returns true if the player is to be edited.</returns>
        public bool EditPlayer(Player p)
        {
            EditorWindow win = new EditorWindow(p);
            return win.ShowDialog() ?? false;
        }
    }
}
