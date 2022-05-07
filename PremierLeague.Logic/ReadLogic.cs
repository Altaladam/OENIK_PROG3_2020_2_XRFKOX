// <copyright file="ReadLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PremierLeague.Logic
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using PremierLeague.Data;
    using PremierLeague.Repository;

    /// <summary>
    /// Passes on the read and non-CRUD operations.
    /// </summary>
    public class ReadLogic : IReadLogic
    {
        private readonly IManagerRepository managerRepo;
        private readonly IPlayerRepository playerRepo;
        private readonly ITeamRepository teamRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReadLogic"/> class.
        /// </summary>
        /// <param name="managerRepo">The repository for the CRUD operations of the managers.</param>
        /// <param name="playerRepo">The repository for the CRUD operations of the players.</param>
        /// <param name="teamRepo">The repository for the CRUD operations of the teams.</param>
        public ReadLogic(IManagerRepository managerRepo, IPlayerRepository playerRepo, ITeamRepository teamRepo)
        {
            this.managerRepo = managerRepo;
            this.playerRepo = playerRepo;
            this.teamRepo = teamRepo;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReadLogic"/> class.
        /// </summary>
        /// <param name="playerRepo">The repository for the CRUD operations of the players.</param>
        /// <param name="teamRepo">The repository for the CRUD operations of the teams.</param>
        public ReadLogic(IPlayerRepository playerRepo, ITeamRepository teamRepo)
        {
            this.playerRepo = playerRepo;
            this.teamRepo = teamRepo;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReadLogic"/> class.
        /// </summary>
        /// <param name="playerRepo">The repository for the CRUD operations of the players.</param>
        public ReadLogic(IPlayerRepository playerRepo)
        {
            this.playerRepo = playerRepo;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReadLogic"/> class.
        /// </summary>
        /// <param name="managerRepo">The repository for the CRUD operations of the managers.</param>
        /// <param name="teamRepo">The repository for the CRUD operations of the teams.</param>
        public ReadLogic(IManagerRepository managerRepo, ITeamRepository teamRepo)
        {
            this.managerRepo = managerRepo;
            this.teamRepo = teamRepo;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReadLogic"/> class.
        /// </summary>
        /// <param name="managerRepo">The repository for the CRUD operations of the managers.</param>
        public ReadLogic(IManagerRepository managerRepo)
        {
            this.managerRepo = managerRepo;
        }
        public Team GetTeamByName(string name)
        {
            return this.teamRepo.GetAll().First(x => x.Name == name);
        }

        /// <inheritdoc/>
        public IList<Manager> GetAllManagers()
        {
            return this.managerRepo.GetAll().ToList();
        }

        /// <inheritdoc/>
        public Manager GetManagerByID(int id)
        {
            return this.managerRepo.GetOne(id);
        }

        /// <inheritdoc/>
        public IList<Player> GetAllPlayers()
        {
            return this.playerRepo.GetAll().ToList();
        }

        /// <inheritdoc/>
        public Player GetPlayerByID(int id)
        {
            return this.playerRepo.GetOne(id);
        }

        /// <inheritdoc/>
        public IList<Team> GetAllTeams()
        {
            return this.teamRepo.GetAll().ToList();
        }

        /// <inheritdoc/>
        public Team GetTeamByID(int id)
        {
            return this.teamRepo.GetOne(id);
        }

        /// <summary>
        /// Gets the youngest player in every team.
        /// </summary>
        /// <returns>The list of every teams youngest player.</returns>
        public IList<Player> GetYoungestPlayers()
        {
            IList<Player> youngPlayers = new List<Player>();
            this.teamRepo.GetAll().ToList().ForEach(x => youngPlayers.Add(x.Players.OrderByDescending(p => p.Birthday).FirstOrDefault()));
            return youngPlayers;
        }

        /// <summary>
        /// Gets the sum of the value of the teams' players.
        /// </summary>
        /// <returns>A Dictionary of team names and values.</returns>
        public IDictionary<string, int> GetTeamValue()
        {
            IDictionary<string, int> dict = new Dictionary<string, int>();
            this.teamRepo.GetAll().ToList().ForEach(x => dict.Add(x.Name, x.Players.Sum(p => p.Value)));
            return dict;
        }

        /// <summary>
        /// Gets all the english playes.
        /// </summary>
        /// <returns>A list of all english players.</returns>
        public IList<Player> GetEnglishPlayers()
        {
            IList<Player> english = new List<Player>();
            this.teamRepo.GetAll().ToList().ForEach(x => x.Players.Where(p => p.Nationality.Equals("English", System.StringComparison.Ordinal)).ToList().ForEach(p => english.Add(p)));
            return english;
        }

        /// <summary>
        /// Asynchronously gets the youngest player in every team.
        /// </summary>
        /// <returns>A task that has the list of every teams youngest player.</returns>
        public Task<IList<Player>> GetYoungestPlayersAsync()
        {
            return Task.Run(() => this.GetYoungestPlayers());
        }

        /// <summary>
        /// Asynchronously gets the sum of the value of the teams' players.
        /// </summary>
        /// <returns>A task that has a Dictionary of team names and values.</returns>
        public Task<IDictionary<string, int>> GetTeamValueAsync()
        {
            return Task.Run(() => this.GetTeamValue());
        }

        /// <summary>
        /// Asynchronously gets all the english playes.
        /// </summary>
        /// <returns>A task that has a list of all english players.</returns>
        public Task<IList<Player>> GetEnglishPlayersAsync()
        {
            return Task.Run(() => this.GetEnglishPlayers());
        }
    }
}
