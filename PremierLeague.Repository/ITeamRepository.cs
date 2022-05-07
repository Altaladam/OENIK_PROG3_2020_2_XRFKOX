// <copyright file="ITeamRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PremierLeague.Repository
{
    using PremierLeague.Data;

    /// <summary>
    /// Provides functionality for the CRUD operations of the teams.
    /// </summary>
    public interface ITeamRepository : IRepository<Team>
    {
        /// <summary>
        /// Changes the name of the team.
        /// </summary>
        /// <param name="id">The ID of the team thats name's to be changed.</param>
        /// <param name="newName">The new name of the team.</param>
        void ChangeName(int id, string newName);

        /// <summary>
        /// Changes the city of the team.
        /// </summary>
        /// <param name="id">The ID of the team thats city's to be changed.</param>
        /// <param name="newCity">The new city of the team.</param>
        void ChangeCity(int id, string newCity);

        /// <summary>
        /// Changes the year the team was founded.
        /// </summary>
        /// <param name="id">The ID of the team thats foundations year's to be changed.</param>
        /// <param name="newFoundationYear">The new foundation year of the team.</param>
        void ChangeFoundationYear(int id, int newFoundationYear);

        /// <summary>
        /// Changes the value of the team.
        /// </summary>
        /// <param name="id">The ID of the team thats value's to be changed.</param>
        /// <param name="newValue">The new value of the team.</param>
        void ChangeValue(int id, int newValue);

        /// <summary>
        /// Changes the name of the teams stadium.
        /// </summary>
        /// <param name="id">The ID of the team thats stadiums name's to be changed.</param>
        /// <param name="newStadium">The new name of the stadium of the team.</param>
        void ChangeStadium(int id, string newStadium);
    }
}
