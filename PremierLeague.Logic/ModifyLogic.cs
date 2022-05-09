// <copyright file="ModifyLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PremierLeague.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PremierLeague.Data;
    using PremierLeague.Repository;

    /// <summary>
    /// Passes on the modifying operations.
    /// </summary>
    public class ModifyLogic : IModifyLogic
    {
        private readonly IManagerRepository managerRepo;
        private readonly IPlayerRepository playerRepo;
        private readonly ITeamRepository teamRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModifyLogic"/> class.
        /// </summary>
        /// <param name="managerRepo">The repository for the CRUD operations of the managers.</param>
        /// <param name="playerRepo">The repository for the CRUD operations of the players.</param>
        /// <param name="teamRepo">The repository for the CRUD operations of the teams.</param>
        public ModifyLogic(IManagerRepository managerRepo, IPlayerRepository playerRepo, ITeamRepository teamRepo)
        {
            this.managerRepo = managerRepo;
            this.playerRepo = playerRepo;
            this.teamRepo = teamRepo;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModifyLogic"/> class.
        /// </summary>
        /// <param name="managerRepo">The repository for the CRUD operations of the managers.</param>
        /// <param name="teamRepo">The repository for the CRUD operations of the teams.</param>
        public ModifyLogic(IManagerRepository managerRepo, ITeamRepository teamRepo)
        {
            this.managerRepo = managerRepo;
            this.teamRepo = teamRepo;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModifyLogic"/> class.
        /// </summary>
        /// <param name="teamRepo">The repository for the CRUD operations of the teams.</param>
        public ModifyLogic(ITeamRepository teamRepo)
        {
            this.teamRepo = teamRepo;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModifyLogic"/> class.
        /// </summary>
        /// <param name="playerRepo">The repository for the CRUD operations of the players.</param>
        public ModifyLogic(IPlayerRepository playerRepo)
        {
            this.playerRepo = playerRepo;
        }

        /// <inheritdoc/>
        public void AddManager(Manager manager)
        {
            this.teamRepo.GetOne((int)manager.TeamID).Manager.Add(manager);
            this.managerRepo.Add(manager);
        }

        /// <inheritdoc/>
        public void ChangeManagerBirthday(int id, DateTime newBirthday)
        {
            this.managerRepo.ChangeBirthday(id, newBirthday);
        }

        /// <inheritdoc/>
        public void ChangeManagerContractStart(int id, DateTime newContractStart)
        {
            this.managerRepo.ChangeContractStart(id, newContractStart);
        }

        /// <inheritdoc/>
        public void ChangeManagerName(int id, string newName)
        {
            this.managerRepo.ChangeName(id, newName);
        }

        /// <inheritdoc/>
        public void ChangeManagerNationality(int id, string newNationality)
        {
            this.managerRepo.ChangeNationality(id, newNationality);
        }

        /// <inheritdoc/>
        public void ChangeManagerPreferredFormation(int id, string newPreferredFormation)
        {
            this.managerRepo.ChangePreferredFormation(id, newPreferredFormation);
        }

        /// <inheritdoc/>
        public void DeleteManager(int id)
        {
            this.managerRepo.Delete(id);
        }

        /// <inheritdoc/>
        public void AddPlayer(Player player)
        {
            this.teamRepo.GetOne((int)player.TeamID).Players.Add(player);
            this.playerRepo.Add(player);
        }

        /// <inheritdoc/>
        public void ChangePlayerBirthday(int id, DateTime newBirthday)
        {
            this.playerRepo.ChangeBirthday(id, newBirthday);
        }

        /// <inheritdoc/>
        public void ChangePlayerName(int id, string newName)
        {
            this.playerRepo.ChangeName(id, newName);
        }

        /// <inheritdoc/>
        public void ChangePlayerNationality(int id, string newNationality)
        {
            this.playerRepo.ChangeNationality(id, newNationality);
        }

        /// <inheritdoc/>
        public void ChangePlayerPosition(int id, string newPosition)
        {
            this.playerRepo.ChangePosition(id, newPosition);
        }

        /// <inheritdoc/>
        public void ChangePlayerValue(int id, int newValue)
        {
            this.playerRepo.ChangeValue(id, newValue);
        }

        public void ChangePlayerTeam(int playerId, int teamId)
        {
            this.playerRepo.ChangePlayerTeam(playerId, teamId);
        }

        /// <summary>
        /// Changes the given property of the Player.
        /// </summary>
        /// <param name="id"> The id of the Player.</param>
        /// <param name="player">The modified Player.</param>
        public void ChangePlayer(int id, Player player)
        {
            this.playerRepo.ChangeName(id, player.Name);

            this.playerRepo.ChangeNationality(id, player.Nationality);

            this.playerRepo.ChangeBirthday(id, player.Birthday);

            this.playerRepo.ChangePosition(id, player.Position);

            this.playerRepo.ChangeValue(id, player.Value);
        }

        /// <inheritdoc/>
        public void DeletePlayer(int id)
        {
            this.playerRepo.Delete(id);
        }

        /// <inheritdoc/>
        public void ChangeTeamCity(int id, string newCity)
        {
            this.teamRepo.ChangeCity(id, newCity);
        }

        /// <inheritdoc/>
        public void ChangeTeamFoundationYear(int id, int newFoundationYear)
        {
            this.teamRepo.ChangeFoundationYear(id, newFoundationYear);
        }

        /// <inheritdoc/>
        public void ChangeTeamName(int id, string newName)
        {
            this.teamRepo.ChangeName(id, newName);
        }

        /// <inheritdoc/>
        public void ChangeTeamStadium(int id, string newStadium)
        {
            this.teamRepo.ChangeStadium(id, newStadium);
        }

        /// <inheritdoc/>
        public void ChangeTeamValue(int id, int newValue)
        {
            this.teamRepo.ChangeValue(id, newValue);
        }

        /// <inheritdoc/>
        public void AddTeam(Team team)
        {
            this.teamRepo.Add(team);
        }

        /// <inheritdoc/>
        public void DeleteTeam(int id)
        {
            this.teamRepo.Delete(id);
        }
    }
}
