// <copyright file="PlayerRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PremierLeague.Repository
{
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using PremierLeague.Data;

    /// <summary>
    /// Implements the CRUD operations of the players.
    /// </summary>
    public class PlayerRepository : GenericRepository<Player>, IPlayerRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerRepository"/> class.
        /// </summary>
        /// <param name="ctx">The context of the database.</param>
        public PlayerRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <inheritdoc/>
        public override void Add(Player t)
        {
            this.Ctx.Add(t);
            this.Ctx.SaveChanges();
        }

        /// <inheritdoc/>
        public void ChangeBirthday(int id, DateTime newBirthday)
        {
            var player = this.GetOne(id);
            player.Birthday = newBirthday;
            this.Ctx.SaveChanges();
        }

        /// <inheritdoc/>
        public void ChangeName(int id, string newName)
        {
            var player = this.GetOne(id);
            player.Name = newName;
            this.Ctx.SaveChanges();
        }

        /// <inheritdoc/>
        public void ChangeNationality(int id, string newNationality)
        {
            var player = this.GetOne(id);
            player.Nationality = newNationality;
            this.Ctx.SaveChanges();
        }

        /// <inheritdoc/>
        public void ChangePosition(int id, string newPosition)
        {
            var player = this.GetOne(id);
            player.Position = newPosition;
            this.Ctx.SaveChanges();
        }

        /// <inheritdoc/>
        public void ChangeValue(int id, int newValue)
        {
            var player = this.GetOne(id);
            player.Value = newValue;
            this.Ctx.SaveChanges();
        }

        /// <inheritdoc/>
        public override void Delete(int id)
        {
            var player = this.GetOne(id);
            this.Ctx.Remove(player);
            this.Ctx.SaveChanges();
        }

        /// <inheritdoc/>
        public override Player GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.PlayerID == id);
        }
    }
}
