// <copyright file="IManagerRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PremierLeague.Repository
{
    using System;
    using PremierLeague.Data;

    /// <summary>
    /// Provides functionality for the CRUD operations of the managers.
    /// </summary>
    public interface IManagerRepository : IRepository<Manager>
    {
        /// <summary>
        /// Changes the name of the manager.
        /// </summary>
        /// <param name="id">The ID of the manager whose name's to be changed.</param>
        /// <param name="newName">The new name of the manager.</param>
        void ChangeName(int id, string newName);

        /// <summary>
        /// Changes the birthday of the manager.
        /// </summary>
        /// <param name="id">The ID of the manager whose birthday's to be changed.</param>
        /// <param name="newBirthday">The new birthday of the manager.</param>
        void ChangeBirthday(int id, DateTime newBirthday);

        /// <summary>
        /// Changes the nationality of the manager.
        /// </summary>
        /// <param name="id">The ID of the manager whose nationality's to be changed.</param>
        /// <param name="newNationality">The new nationality of the manager.</param>
        void ChangeNationality(int id, string newNationality);

        /// <summary>
        /// Changes the start of the contract of the manager.
        /// </summary>
        /// <param name="id">The ID of the manager whose contracts start is to be changed.</param>
        /// <param name="newContractStart">The new start of the contract of the manager.</param>
        void ChangeContractStart(int id, DateTime newContractStart);

        /// <summary>
        /// Changes the preferred formation of the manager.
        /// </summary>
        /// <param name="id">The ID of the manager whose preferred formation's to be changed.</param>
        /// <param name="newPreferredFormation">The new preferred formation of the manager.</param>
        void ChangePreferredFormation(int id, string newPreferredFormation);
    }
}
