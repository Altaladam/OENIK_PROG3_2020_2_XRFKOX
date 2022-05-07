// <copyright file="Team.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PremierLeague.Data
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Contains the teams.
    /// </summary>
    [Table("Team")]
    public class Team
    {
        /// <summary>
        /// Gets or sets the ID of the team.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ToString]
        public int TeamID { get; set; }

        /// <summary>
        /// Gets or sets the name of the team.
        /// </summary>
        [ToString]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the city of the team.
        /// </summary>
        [ToString]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the year the team was founded.
        /// </summary>
        [ToString]
        public int FoundationYear { get; set; }

        /// <summary>
        /// Gets or sets the total value of the teams whole squad.
        /// </summary>
        [ToString]
        public int TotalValue { get; set; }

        /// <summary>
        /// Gets or sets the name of the teams stadium.
        /// </summary>
        [ToString]
        public string Stadium { get; set; }

        /// <summary>
        /// Gets or sets the teams players.
        /// </summary>
        [NotMapped]
        public virtual ICollection<Player> Players { get; set; }

        /// <summary>
        /// Gets or sets the teams manager.
        /// </summary>
        [NotMapped]
        public virtual ICollection<Manager> Manager { get; set;  }

        /// <summary>
        /// Converts the value of the teams properties into a single string.
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
