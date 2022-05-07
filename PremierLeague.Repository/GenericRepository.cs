// <copyright file="GenericRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PremierLeague.Repository
{
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The generic repository class for the CRUD operations.
    /// </summary>
    /// <typeparam name="T">Generic T type element.</typeparam>
    public abstract class GenericRepository<T> : IRepository<T>
        where T : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GenericRepository{T}"/> class.
        /// </summary>
        /// <param name="ctx">The context of the database.</param>
        protected GenericRepository(DbContext ctx)
        {
            this.Ctx = ctx;
        }

        /// <summary>
        /// Gets or sets the context of the database.
        /// </summary>
        protected DbContext Ctx { get; set; }

        /// <inheritdoc/>
        public abstract void Add(T t);

        /// <inheritdoc/>
        public abstract void Delete(int id);

        /// <inheritdoc/>
        public IQueryable<T> GetAll()
        {
            return this.Ctx.Set<T>();
        }

        /// <inheritdoc/>
        public abstract T GetOne(int id);
    }
}
