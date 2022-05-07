// <copyright file="TeamRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PremierLeague.Repository
{
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using PremierLeague.Data;

    /// <summary>
    /// Implements the CRUD operations of the teams.
    /// </summary>
    public class TeamRepository : GenericRepository<Team>, ITeamRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TeamRepository"/> class.
        /// </summary>
        /// <param name="ctx">The context of the database.</param>
        public TeamRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <inheritdoc/>
        public override void Add(Team t)
        {
            this.Ctx.Add(t);
            this.Ctx.SaveChanges();
        }

        /// <inheritdoc/>
        public void ChangeCity(int id, string newCity)
        {
            var team = this.GetOne(id);
            team.City = newCity;
            this.Ctx.SaveChanges();
        }

        /// <inheritdoc/>
        public void ChangeFoundationYear(int id, int newFoundationYear)
        {
            var team = this.GetOne(id);
            team.FoundationYear = newFoundationYear;
            this.Ctx.SaveChanges();
        }

        /// <inheritdoc/>
        public void ChangeName(int id, string newName)
        {
            var team = this.GetOne(id);
            team.Name = newName;
            this.Ctx.SaveChanges();
        }

        /// <inheritdoc/>
        public void ChangeStadium(int id, string newStadium)
        {
            var team = this.GetOne(id);
            team.Stadium = newStadium;
            this.Ctx.SaveChanges();
        }

        /// <inheritdoc/>
        public void ChangeValue(int id, int newValue)
        {
            var team = this.GetOne(id);
            team.TotalValue = newValue;
            this.Ctx.SaveChanges();
        }

        /// <inheritdoc/>
        public override void Delete(int id)
        {
            var team = this.GetOne(id);
            this.Ctx.Remove(team);
            this.Ctx.SaveChanges();
        }

        /// <inheritdoc/>
        public override Team GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.TeamID == id);
        }
    }
}
