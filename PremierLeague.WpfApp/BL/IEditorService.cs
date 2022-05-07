// <copyright file="IEditorService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PremierLeague.WpfApp.BL
{
    using PremierLeague.WpfApp.Data;

    /// <summary>
    /// Services the editor.
    /// </summary>
    public interface IEditorService
    {
        /// <summary>
        /// True if the user clicked the ok on the edit screen, else false.
        /// </summary>
        /// <param name="p">The selected player.</param>
        /// <returns>Returns a bool.</returns>
        bool EditPlayer(Player p);
    }
}
