// <copyright file="PLContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PremierLeague.Data
{
    using System;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Handles the context of the database.
    /// </summary>
    public class PLContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PLContext"/> class.
        /// </summary>
        public PLContext()
        {
            this.Database.EnsureCreated();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PLContext"/> class.
        /// </summary>
        /// <param name="options"> The options to be used by PLcontext.</param>
        public PLContext(DbContextOptions<PLContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets all teams.
        /// </summary>
        public virtual DbSet<Team> Teams { get; set; }

        /// <summary>
        /// Gets or sets all players.
        /// </summary>
        public virtual DbSet<Player> Players { get; set; }

        /// <summary>
        /// Gets or sets all managers.
        /// </summary>
        public virtual DbSet<Manager> Managers { get; set; }

        /// <summary>
        /// Configures the database to be used for this context.
        /// </summary>
        /// <param name="optionsBuilder">Provides a simple API surface for configuring DbContextOptions.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder != null && !optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\PremierLeagueDatabase.mdf;Integrated Security=True");
            }
        }

        /// <summary>
        /// Further modifies the model of the database.
        /// </summary>
        /// <param name="modelBuilder">Used to construct a model for the context.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Team t0 = new Team() { TeamID = 1, Name = "Arsenal", City = "London", FoundationYear = 1886, Stadium = "Emirates", TotalValue = 631950000 };
            Team t1 = new Team() { TeamID = 2, Name = "Liverpool", City = "Liverpool", FoundationYear = 1892, Stadium = "Anfield Road", TotalValue = 1100000000 };
            Team t2 = new Team() { TeamID = 3, Name = "Manchester United", City = "Manchester", FoundationYear = 1878, Stadium = "Old Trafford", TotalValue = 799850000 };
            Team t3 = new Team() { TeamID = 4, Name = "Manchester City", City = "Manchester", FoundationYear = 1894, Stadium = "Etihad", TotalValue = 1080000000 };
            Team t4 = new Team() { TeamID = 5, Name = "Chelsea", City = "London", FoundationYear = 1905, Stadium = "Stamford Bridge", TotalValue = 838900000 };
            Team t5 = new Team() { TeamID = 6, Name = "Leicester City", City = "Leicester", FoundationYear = 1884, Stadium = "King Power Stadium", TotalValue = 477200000 };

            // ---------------------------------------------------------------------------------------------------------------------------------------------------
            Player p0 = new Player() { PlayerID = 1, Name = "Bernd Leno", Birthday = new DateTime(1992, 3, 4), Nationality = "German", Position = "Goalkeeper", Value = 32000000 };
            Player p1 = new Player() { PlayerID = 2, Name = "Dani Ceballos", Birthday = new DateTime(1996, 8, 7), Nationality = "Spanish", Position = "Midfielder", Value = 32000000 };
            Player p2 = new Player() { PlayerID = 3, Name = "Pierre-Emerick Aubameyang", Birthday = new DateTime(1989, 6, 18), Nationality = "Gabonese", Position = "Forward", Value = 50000000 };
            Player p3 = new Player() { PlayerID = 4, Name = "Trent Alexander-Arnold", Birthday = new DateTime(1998, 10, 7), Nationality = "English", Position = "Defender", Value = 110000000 };
            Player p4 = new Player() { PlayerID = 5, Name = "Thiago Alcántara", Birthday = new DateTime(1991, 4, 11), Nationality = "Spanish", Position = "Midfielder", Value = 48000000 };
            Player p5 = new Player() { PlayerID = 6, Name = "Mohamed Salah", Birthday = new DateTime(1992, 6, 15), Nationality = "Egyptian", Position = "Forward", Value = 120000000 };
            Player p6 = new Player() { PlayerID = 7, Name = "Harry Maguire", Birthday = new DateTime(1993, 3, 5), Nationality = "English", Position = "Defender", Value = 50000000 };
            Player p7 = new Player() { PlayerID = 8, Name = "Paul Pogba", Birthday = new DateTime(1993, 3, 15), Nationality = "French", Position = "Midfielder", Value = 80000000 };
            Player p8 = new Player() { PlayerID = 9, Name = "Mason Greenwood", Birthday = new DateTime(2001, 10, 1), Nationality = "English", Position = "Forward", Value = 50000000 };
            Player p9 = new Player() { PlayerID = 10, Name = "Aymeric Laporte", Birthday = new DateTime(1994, 3, 27), Nationality = "French", Position = "Defender", Value = 60000000 };
            Player p10 = new Player() { PlayerID = 11, Name = "Kevin De Bruyne", Birthday = new DateTime(1991, 6, 28), Nationality = "Belgian", Position = "Midfielder", Value = 120000000 };
            Player p11 = new Player() { PlayerID = 12, Name = "Raheem Sterling", Birthday = new DateTime(1994, 12, 8), Nationality = "English", Position = "Forward", Value = 128000000 };
            Player p12 = new Player() { PlayerID = 13, Name = "Ben Chilwell", Birthday = new DateTime(1996, 12, 21), Nationality = "English", Position = "Defender", Value = 50000000 };
            Player p13 = new Player() { PlayerID = 14, Name = "César Azpilicueta", Birthday = new DateTime(1989, 8, 28), Nationality = "Spanish", Position = "Defender", Value = 20000000 };
            Player p14 = new Player() { PlayerID = 15, Name = "Christian Pulisic", Birthday = new DateTime(1998, 9, 18), Nationality = "American", Position = "Forward", Value = 60000000 };
            Player p15 = new Player() { PlayerID = 16, Name = "James Maddison", Birthday = new DateTime(1999, 11, 23), Nationality = "English", Position = "Midfielder", Value = 55000000 };
            Player p16 = new Player() { PlayerID = 17, Name = "Jamie Vardy", Birthday = new DateTime(1987, 1, 11), Nationality = "English", Position = "Forward", Value = 16000000 };
            Player p17 = new Player() { PlayerID = 18, Name = "Cengiz Ünder", Birthday = new DateTime(1997, 7, 14), Nationality = "Turkish", Position = "Forward", Value = 23000000 };

            // ---------------------------------------------------------------------------------------------------------------------------------------------------
            Manager m0 = new Manager() { ManagerID = 1, Name = "Mikel Arteta", Birthday = new DateTime(1982, 3, 26), Nationality = "Spanish", PreferredFormation = "3-4-3", ContractStart = new DateTime(2019, 11, 22) };
            Manager m1 = new Manager() { ManagerID = 2, Name = "Jürgen Klopp", Birthday = new DateTime(1967, 6, 16), Nationality = "German", PreferredFormation = "4-3-3", ContractStart = new DateTime(2015, 10, 8) };
            Manager m2 = new Manager() { ManagerID = 3, Name = "Ole Gunnar Solskjaer", Birthday = new DateTime(1973, 2, 26), Nationality = "Norwegian", PreferredFormation = "4-2-3-1", ContractStart = new DateTime(2019, 3, 28) };
            Manager m3 = new Manager() { ManagerID = 4, Name = "Josep Guardiola", Birthday = new DateTime(1971, 1, 18), Nationality = "Spanish", PreferredFormation = "4-3-3", ContractStart = new DateTime(2016, 7, 1) };
            Manager m4 = new Manager() { ManagerID = 5, Name = "Frank Lampard", Birthday = new DateTime(1978, 6, 20), Nationality = "English", PreferredFormation = "4-2-3-1", ContractStart = new DateTime(2019, 7, 4) };
            Manager m5 = new Manager() { ManagerID = 6, Name = "Brendan Rodgers", Birthday = new DateTime(1973, 1, 26), Nationality = "Northern Irish", PreferredFormation = "4-1-4-1", ContractStart = new DateTime(2019, 2, 27) };

            // ---------------------------------------------------------------------------------------------------------------------------------------------------
            p0.TeamID = t0.TeamID;
            p1.TeamID = t0.TeamID;
            p2.TeamID = t0.TeamID;
            p3.TeamID = t1.TeamID;
            p4.TeamID = t1.TeamID;
            p5.TeamID = t1.TeamID;
            p6.TeamID = t2.TeamID;
            p7.TeamID = t2.TeamID;
            p8.TeamID = t2.TeamID;
            p9.TeamID = t3.TeamID;
            p10.TeamID = t3.TeamID;
            p11.TeamID = t3.TeamID;
            p12.TeamID = t4.TeamID;
            p13.TeamID = t4.TeamID;
            p14.TeamID = t4.TeamID;
            p15.TeamID = t5.TeamID;
            p16.TeamID = t5.TeamID;
            p17.TeamID = t5.TeamID;

            // ---------------------------------------------------------------------------------------------------------------------------------------------------
            m0.TeamID = t0.TeamID;
            m1.TeamID = t1.TeamID;
            m2.TeamID = t2.TeamID;
            m3.TeamID = t3.TeamID;
            m4.TeamID = t4.TeamID;
            m5.TeamID = t5.TeamID;

            // ---------------------------------------------------------------------------------------------------------------------------------------------------
            if (modelBuilder != null)
            {
                modelBuilder.Entity<Player>(entity =>
                {
                    entity.HasOne(player => player.Team)
                    .WithMany(team => team.Players)
                    .HasForeignKey(player => player.TeamID)
                    .OnDelete(DeleteBehavior.SetNull);
                });
                modelBuilder.Entity<Manager>(entity =>
                {
                    entity.HasOne(manager => manager.Team)
                    .WithMany(team => team.Manager)
                    .HasForeignKey(manager => manager.TeamID)
                    .OnDelete(DeleteBehavior.SetNull);
                });
                modelBuilder.Entity<Team>().HasData(t0, t1, t2, t3, t4, t5);
                modelBuilder.Entity<Player>().HasData(p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17);
                modelBuilder.Entity<Manager>().HasData(m0, m1, m2, m3, m4, m5);
            }
        }
    }
}
