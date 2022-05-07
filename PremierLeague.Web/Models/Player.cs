// <copyright file="Player.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PremierLeague.Web.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// An element of the Player table.
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Gets or sets the name of the player.
        /// </summary>
        [Display(Name = "Játékos neve")]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the birthday of the player.
        /// </summary>
        [Display(Name = "Játékos születési dátuma")]
        [Required]
        public DateTime Birthday { get; set; }

        /// <summary>
        /// Gets or sets the nationality of the player.
        /// </summary>
        [Display(Name = "Játékos nemzetisége")]
        [Required]
        public string Nationality { get; set; }

        /// <summary>
        /// Gets or sets the position of the player.
        /// </summary>
        [Display(Name = "Játékos pozíciója")]
        [Required]
        public string Position { get; set; }

        /// <summary>
        /// Gets or sets the value of the player.
        /// </summary>
        [Display(Name = "Játékos értéke")]
        [Required]
        public int Value { get; set; }

        /// <summary>
        /// Gets or sets the id of the player.
        /// </summary>
        [Display(Name = "Játékos azonosítója")]
        [Required]
        public int Id { get; set; }
    }
}
