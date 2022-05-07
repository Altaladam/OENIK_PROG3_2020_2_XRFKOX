// <copyright file="EditorViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PremierLeague.WpfApp.VM
{
    using System;
    using GalaSoft.MvvmLight;
    using PremierLeague.WpfApp.Data;

    /// <summary>
    /// The viewmodel of the editor window.
    /// </summary>
    public class EditorViewModel : ViewModelBase
    {
        /// <summary>
        /// An instance of the player.
        /// </summary>
        private Player player;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditorViewModel"/> class.
        /// </summary>
        public EditorViewModel()
        {
            this.player = new Player();
            if (this.IsInDesignMode)
            {
                this.player.Name = "Firstname Lastname";
                this.player.Nationality = "Sugondese";
                this.player.Position = Position.Forward;
                this.player.Birthday = DateTime.Today;
                this.player.Value = "100000000";
            }
        }

        /// <summary>
        /// Gets an array of all positions.
        /// </summary>
        public static Array Positions
        {
            get { return Enum.GetValues(typeof(Position)); }
        }

        /// <summary>
        /// Gets or sets an instance of the player.
        /// </summary>
        public Player Player
        {
            get { return this.player; }
            set { this.Set(ref this.player, value); }
        }
    }
}
