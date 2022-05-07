// <copyright file="Factory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PremierLeague.WpfApp
{
    using PremierLeague.Data;
    using PremierLeague.Logic;
    using PremierLeague.Repository;

    /// <summary>
    /// Instantiates everything.
    /// </summary>
    public static class Factory
    {
        /// <summary>
        /// Gets an instance of the context.
        /// </summary>
        /// <returns>An instance of the context.</returns>
        public static PLContext Context => new PLContext();

        /// <summary>
        /// Gets an instance of the TeamRepository.
        /// </summary>
        /// <returns>An instance of the TeamRepository.</returns>
        public static TeamRepository TeamRepository => new TeamRepository(Context);

        /// <summary>
        /// Gets an instance of the PlayerRepository.
        /// </summary>
        /// <returns>An instance of the PlayerRepository.</returns>
        public static PlayerRepository PlayerRepository => new PlayerRepository(Context);

        /// <summary>
        /// Gets an instance of the ManagerRepository.
        /// </summary>
        /// <returns>An instance of the ManagerRepository.</returns>
        public static ManagerRepository ManagerRepository => new ManagerRepository(Context);

        /// <summary>
        /// Gets an instance of the ReadLogic.
        /// </summary>
        /// <returns>An instance of the ReadLogic.</returns>
        public static ReadLogic ReadLogic => new ReadLogic(ManagerRepository, PlayerRepository, TeamRepository);

        /// <summary>
        /// Gets an instance of the ModifyLogic.
        /// </summary>
        /// <returns>An instance of the ModifyLogic.</returns>
        public static ModifyLogic ModifyLogic => new ModifyLogic(ManagerRepository, PlayerRepository, TeamRepository);
    }
}
