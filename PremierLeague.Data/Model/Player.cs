// <copyright file="Player.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PremierLeague.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Contains the players.
    /// </summary>
    [Table("Player")]
    public class Player
    {
        /// <summary>
        /// Gets or sets the ID of the player.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ToString]
        public int PlayerID { get; set; }

        /// <summary>
        /// Gets or sets the name of the player.
        /// </summary>
        [ToString]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the birthday of the player.
        /// </summary>
        [ToString]
        public DateTime Birthday { get; set; }

        /// <summary>
        /// Gets or sets the nationality of the player.
        /// </summary>
        [ToString]
        public string Nationality { get; set; }

        /// <summary>
        /// Gets or sets the position of the player.
        /// </summary>
        [ToString]
        public string Position { get; set; }

        /// <summary>
        /// Gets or sets the value of the player.
        /// </summary>
        [ToString]
        public int Value { get; set; }

        /// <summary>
        /// Gets or sets the team of the player.
        /// </summary>
        [NotMapped]
        public virtual Team Team { get; set; }

        /// <summary>
        /// Gets or sets the ID of the team of the player.
        /// </summary>
        [ForeignKey(nameof(Team))]
        public virtual int? TeamID { get; set; }

        /// <summary>
        /// Converts the value of the players properties into a single string.
        /// </summary>
        /// <returns>string.</returns>
        public override string ToString()
        {
            string x = string.Empty;

            foreach (var item in this.GetType().GetProperties().Where(x => x.GetCustomAttribute<ToStringAttribute>() != null))
            {
                x += "  ";
                x += item.Name + "\t=>";
                x += item.GetValue(this);
                x += "\n";
            }

            return x;
        }
    }
}
