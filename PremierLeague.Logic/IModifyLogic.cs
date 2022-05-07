// <copyright file="IModifyLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PremierLeague.Logic
{
    using System;
    using PremierLeague.Data;

    /// <summary>
    /// Provides functionality for the CRUD operations that modify the database (add, change, delete).
    /// </summary>
    public interface IModifyLogic
    {
        /// <summary>
        /// Adds a manager into the database.
        /// </summary>
        /// <param name="manager">The manager to be added.</param>
        void AddManager(Manager manager);

        /// <summary>
        /// Deletes a manager.
        /// </summary>
        /// <param name="id">The id of the manager to be deleted.</param>
        void DeleteManager(int id);

        /// <summary>
        /// Changes the name of the manager.
        /// </summary>
        /// <param name="id">The id of the manager whose name's to be changed.</param>
        /// <param name="newName">The new name of the manager.</param>
        void ChangeManagerName(int id, string newName);

        /// <summary>
        /// Changes the birthday of the manager.
        /// </summary>
        /// <param name="id">The id of the manager whose birthday's to be changed.</param>
        /// <param name="newBirthday">The new birthday of the manager.</param>
        void ChangeManagerBirthday(int id, DateTime newBirthday);

        /// <summary>
        /// Changes the nationality of the manager.
        /// </summary>
        /// <param name="id">The id of the manager whose nationality's to be changed.</param>
        /// <param name="newNationality">The new nationality of the manager.</param>
        void ChangeManagerNationality(int id, string newNationality);

        /// <summary>
        /// Changes the preferred formation of the manager.
        /// </summary>
        /// <param name="id">The id of the manager whose preferred formation's to be changed.</param>
        /// <param name="newPreferredFormation">The new preferred formation of the manager.</param>
        void ChangeManagerPreferredFormation(int id, string newPreferredFormation);

        /// <summary>
        /// Changes the start of the contract of the manager.
        /// </summary>
        /// <param name="id">The id of the manager whose contracts start's to be changed.</param>
        /// <param name="newContractStart">The new start of the contract of the manager.</param>
        void ChangeManagerContractStart(int id, DateTime newContractStart);

        /// <summary>
        /// Adds a player into the database.
        /// </summary>
        /// <param name="player">The player to be added.</param>
        void AddPlayer(Player player);

        /// <summary>
        /// Deletes a player.
        /// </summary>
        /// <param name="id">The id of the player to be deleted.</param>
        void DeletePlayer(int id);

        /// <summary>
        /// Changes the name of the player.
        /// </summary>
        /// <param name="id">The id of the player whose name's to be changed.</param>
        /// <param name="newName">The new name of the player.</param>
        void ChangePlayerName(int id, string newName);

        /// <summary>
        /// Changes the birthday of the player.
        /// </summary>
        /// <param name="id">The id of the player whose birthday's to be changed.</param>
        /// <param name="newBirthday">The new birthday of the player.</param>
        void ChangePlayerBirthday(int id, DateTime newBirthday);

        /// <summary>
        /// Changes the nationality of the player.
        /// </summary>
        /// <param name="id">The id of the player whose nationality's to be changed.</param>
        /// <param name="newNationality">The new nationality of the player.</param>
        void ChangePlayerNationality(int id, string newNationality);

        /// <summary>
        /// Changes the position of the player.
        /// </summary>
        /// <param name="id">The id of the player whose position's to be changed.</param>
        /// <param name="newPosition">The new position of the player.</param>
        void ChangePlayerPosition(int id, string newPosition);

        /// <summary>
        /// Changes the value of the player.
        /// </summary>
        /// <param name="id">The id of the player whose value's to be changed.</param>
        /// <param name="newValue">The new value of the player.</param>
        void ChangePlayerValue(int id, int newValue);

        void ChangePlayerTeam(int playerId, int teamId);

        /// <summary>
        /// Adds a team into the database.
        /// </summary>
        /// <param name="team">The team to be added.</param>
        void AddTeam(Team team);

        /// <summary>
        /// Deletes a team.
        /// </summary>
        /// <param name="id">The id of the team to be deleted.</param>
        void DeleteTeam(int id);

        /// <summary>
        /// Changes the name of the team.
        /// </summary>
        /// <param name="id">The id of the team thats name's to be changed.</param>
        /// <param name="newName">The new name of the team.</param>
        void ChangeTeamName(int id, string newName);

        /// <summary>
        /// Changes the city of the team.
        /// </summary>
        /// <param name="id">The id of the team thats city's to be changed.</param>
        /// <param name="newCity">The new city of the team.</param>
        void ChangeTeamCity(int id, string newCity);

        /// <summary>
        /// Changes the year the team was founded.
        /// </summary>
        /// <param name="id">The id of the team thats year of foundation's to be changed.</param>
        /// <param name="newFoundationYear">The new year of foundation of the team.</param>
        void ChangeTeamFoundationYear(int id, int newFoundationYear);

        /// <summary>
        /// Changes the value of the team.
        /// </summary>
        /// <param name="id">The id of the team thats value's to be changed.</param>
        /// <param name="newValue">The new value of the team.</param>
        void ChangeTeamValue(int id, int newValue);

        /// <summary>
        /// Changes the name of the stadium of the team.
        /// </summary>
        /// <param name="id">The id of the team thats stadiums name's to be changed.</param>
        /// <param name="newStadium">The new name of the stadium of the team.</param>
        void ChangeTeamStadium(int id, string newStadium);
    }
}
