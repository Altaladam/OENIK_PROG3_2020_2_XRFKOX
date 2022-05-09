// <copyright file="IPlayerRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PremierLeague.Repository
{
    using System;
    using PremierLeague.Data;

    /// <summary>
    /// Provides functionality for the CRUD operations of the players.
    /// </summary>
    public interface IPlayerRepository : IRepository<Player>
    {
        /// <summary>
        /// Changes the name of the player.
        /// </summary>
        /// <param name="id">The ID of the player whose name's to be changed.</param>
        /// <param name="newName">The new name of the player.</param>
        void ChangeName(int id, string newName);

        /// <summary>
        /// Changes the birthday of the player.
        /// </summary>
        /// <param name="id">The ID of the player whose birthday's to be changed.</param>
        /// <param name="newBirthday">The new birthday of the player.</param>
        void ChangeBirthday(int id, DateTime newBirthday);

        /// <summary>
        /// Changes the nationality of the player.
        /// </summary>
        /// <param name="id">The ID of the player whose nationality's to be changed.</param>
        /// <param name="newNationality">The new nationality of the player.</param>
        void ChangeNationality(int id, string newNationality);

        /// <summary>
        /// Changes the position of the player.
        /// </summary>
        /// <param name="id">The ID of the player whose position's to be changed.</param>
        /// <param name="newPosition">The new position of the player.</param>
        void ChangePosition(int id, string newPosition);

        /// <summary>
        /// Changes the value of the player.
        /// </summary>
        /// <param name="id">The ID of the player whose value's to be changed.</param>
        /// <param name="newValue">The new value of the player.</param>
        void ChangeValue(int id, int newValue);

        void ChangePlayerTeam(int playerId, int teamId);
    }
}
