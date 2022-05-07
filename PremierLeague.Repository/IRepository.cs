// <copyright file="IRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PremierLeague.Repository
{
    using System.Linq;

    /// <summary>
    /// Provides functionality for the CRUD operations.
    /// </summary>
    /// <typeparam name="T">Generic type.</typeparam>
    public interface IRepository<T>
       where T : class
    {
        /// <summary>
        /// Gets one element.
        /// </summary>
        /// <param name="id">The ID of the element.</param>
        /// <returns>A generic T type element.</returns>
        T GetOne(int id);

        /// <summary>
        /// Gets all elements.
        /// </summary>
        /// <returns>A generic T type IQueryable collection.</returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Adds one element.
        /// </summary>
        /// <param name="t">A generic T type element.</param>
        void Add(T t);

        /// <summary>
        /// Deletes one element.
        /// </summary>
        /// <param name="id">The ID of the element to be deleted.</param>
        void Delete(int id);
    }
}
