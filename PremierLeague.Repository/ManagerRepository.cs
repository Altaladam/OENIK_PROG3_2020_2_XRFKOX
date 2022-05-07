// <copyright file="ManagerRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PremierLeague.Repository
{
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using PremierLeague.Data;

    /// <summary>
    /// Implements the CRUD operations of the managers.
    /// </summary>
    public class ManagerRepository : GenericRepository<Manager>, IManagerRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ManagerRepository"/> class.
        /// </summary>
        /// <param name="ctx">The context of the database.</param>
        public ManagerRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <inheritdoc/>
        public override void Add(Manager t)
        {
            this.Ctx.Add(t);
            this.Ctx.SaveChanges();
        }

        /// <inheritdoc/>
        public void ChangeBirthday(int id, DateTime newBirthday)
        {
            var manager = this.GetOne(id);
            manager.Birthday = newBirthday;
            this.Ctx.SaveChanges();
        }

        /// <inheritdoc/>
        public void ChangeContractStart(int id, DateTime newContractStart)
        {
            var manager = this.GetOne(id);
            manager.ContractStart = newContractStart;
            this.Ctx.SaveChanges();
        }

        /// <inheritdoc/>
        public void ChangeName(int id, string newName)
        {
            var manager = this.GetOne(id);
            manager.Name = newName;
            this.Ctx.SaveChanges();
        }

        /// <inheritdoc/>
        public void ChangeNationality(int id, string newNationality)
        {
            var manager = this.GetOne(id);
            manager.Nationality = newNationality;
            this.Ctx.SaveChanges();
        }

        /// <inheritdoc/>
        public void ChangePreferredFormation(int id, string newPreferredFormation)
        {
            var manager = this.GetOne(id);
            manager.PreferredFormation = newPreferredFormation;
            this.Ctx.SaveChanges();
        }

        /// <inheritdoc/>
        public override void Delete(int id)
        {
            var manager = this.GetOne(id);
            this.Ctx.Remove(manager);
            this.Ctx.SaveChanges();
        }

        /// <inheritdoc/>
        public override Manager GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.ManagerID == id);
        }
    }
}
