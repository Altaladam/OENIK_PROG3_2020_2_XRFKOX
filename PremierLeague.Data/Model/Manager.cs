// <copyright file="Manager.cs" company="PlaceholderCompany">
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
    /// Contains the managers.
    /// </summary>
    [Table("Manager")]
    public class Manager
    {
        /// <summary>
        /// Gets or sets the ID of the manager.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ToString]
        public int ManagerID { get; set; }

        /// <summary>
        /// Gets or sets the name of the manager.
        /// </summary>
        [ToString]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the birthday of the manager.
        /// </summary>
        [ToString]
        public DateTime Birthday { get; set; }

        /// <summary>
        /// Gets or sets the nationality of the manager.
        /// </summary>
        [ToString]
        public string Nationality { get; set; }

        /// <summary>
        /// Gets or sets the start of the managers contract.
        /// </summary>
        [ToString]
        public DateTime ContractStart { get; set; }

        /// <summary>
        /// Gets or sets the preferred formation of the manager.
        /// </summary>
        [ToString]
        public string PreferredFormation { get; set; }

        /// <summary>
        /// Gets or Sets the team of the manager.
        /// </summary>
        [NotMapped]
        public virtual Team Team { get; set; }

        /// <summary>
        /// Gets or sets the ID of the team of the manager.
        /// </summary>
        [ForeignKey(nameof(Team))]
        public virtual int? TeamID { get; set; }

        /// <summary>
        /// Converts the value of the managers proprerties into a single string.
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
