// <copyright file="PlayerListViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PremierLeague.Web.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// A viewmodel of the list of players.
    /// </summary>
    public class PlayerListViewModel
    {
        /// <summary>
        /// Gets or sets a list of the players.
        /// </summary>
        public List<Player> Players { get; set; }

        /// <summary>
        /// Gets or sets the edited player.
        /// </summary>
        public Player EditedPlayer { get; set; }
    }
}
