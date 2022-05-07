// <copyright file="IReadLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PremierLeague.Logic
{
    using System.Collections.Generic;
    using PremierLeague.Data;

    /// <summary>
    /// Provides functionality for the 'read' CRUD operations and the non-CRUD operations.
    /// </summary>
    public interface IReadLogic
    {
        /// <summary>
        /// Gets the manager with the given id.
        /// </summary>
        /// <param name="id">The id of the manager.</param>
        /// <returns>Returns the manager with the given id.</returns>
        Manager GetManagerByID(int id);

        /// <summary>
        /// Gets all managers.
        /// </summary>
        /// <returns>A list of all managers.</returns>
        IList<Manager> GetAllManagers();

        /// <summary>
        /// Gets the player with the given id.
        /// </summary>
        /// <param name="id">The id of the player.</param>
        /// <returns>Returns the player with the given id.</returns>
        Player GetPlayerByID(int id);

        /// <summary>
        /// Gets all players.
        /// </summary>
        /// <returns>A list of all players.</returns>
        IList<Player> GetAllPlayers();
        Team GetTeamByName(string name);

        /// <summary>
        /// Gets the team with the given id.
        /// </summary>
        /// <param name="id">The id of the team.</param>
        /// <returns>Returns the team with the given id.</returns>
        Team GetTeamByID(int id);

        /// <summary>
        /// Gets all teams.
        /// </summary>
        /// <returns>A list of all teams.</returns>
        IList<Team> GetAllTeams();
    }
}
