// <copyright file="Player.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PremierLeague.WpfApp.Data
{
    using System;
    using System.Linq;
    using GalaSoft.MvvmLight;

    /// <summary>
    /// An enum of the possible positions.
    /// </summary>
    public enum Position
    {
        /// <summary>
        /// The position of Goalkeeper.
        /// </summary>
        Goalkeeper,

        /// <summary>
        /// The position of Defender.
        /// </summary>
        Defender,

        /// <summary>
        /// The position of Midfielder.
        /// </summary>
        Midfielder,

        /// <summary>
        /// The position of Forward.
        /// </summary>
        Forward,
    }

    /// <summary>
    /// An element of the Player table.
    /// </summary>
    public class Player : ObservableObject
    {
        private int id;
        private string name;
        private DateTime birthday;
        private string nationality;
        private Position position;
        private string value;

        /// <summary>
        /// Gets or sets the name of the player.
        /// </summary>
        public string Name
        {
            get { return this.name; }
            set { this.Set(ref this.name, value); }
        }

        /// <summary>
        /// Gets or sets the birthday of the player.
        /// </summary>
        public DateTime Birthday
        {
            get { return this.birthday; }
            set { this.Set(ref this.birthday, value); }
        }

        /// <summary>
        /// Gets or sets the nationality of the player.
        /// </summary>
        public string Nationality
        {
            get { return this.nationality; }
            set { this.Set(ref this.nationality, value); }
        }

        /// <summary>
        /// Gets or sets the position of the player.
        /// </summary>
        public Position Position
        {
            get { return this.position; }
            set { this.Set(ref this.position, value); }
        }

        /// <summary>
        /// Gets or sets the value of the player.
        /// </summary>
        public string Value
        {
            get { return this.value; }
            set { this.Set(ref this.value, value); }
        }

        /// <summary>
        /// Gets or sets the id of the player.
        /// </summary>
        public int Id
        {
            get { return this.id; }
            set { this.Set(ref this.id, value); }
        }

        /// <summary>
        /// Copies the other player into this player.
        /// </summary>
        /// <param name="other">The player thats properties are going to be copied.</param>
        public void CopyFrom(Player other)
        {
            this.GetType().GetProperties().ToList().ForEach(
                property => property.SetValue(this, property.GetValue(other)));
        }
    }
}
