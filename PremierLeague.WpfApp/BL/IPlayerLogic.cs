// <copyright file="IPlayerLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PremierLeague.WpfApp.BL
{
    using System.Collections.Generic;
    using PremierLeague.WpfApp.Data;

    /// <summary>
    /// An interface containing the CRUD operations.
    /// </summary>
    public interface IPlayerLogic
    {
        /// <summary>
        /// Adds a player to the list and the database.
        /// </summary>
        /// <param name="list">The list the players going to get added to.</param>
        void AddPlayer(IList<Player> list);

        /// <summary>
        /// Modifies the given player.
        /// </summary>
        /// <param name="playerToModify">The player to be modified.</param>
        void ModPlayer(Player playerToModify);

        /// <summary>
        /// Deletes the given player from the list and the database.
        /// </summary>
        /// <param name="list">The list from where the players going to get deleted.</param>
        /// <param name="player">The player to be deleted.</param>
        void DelPlayer(IList<Player> list, Player player);

        /// <summary>
        /// Gets all players from the database.
        /// </summary>
        /// <returns>Returns all players from the database.</returns>
        IList<Player> GetAllPlayers();
    }
}
