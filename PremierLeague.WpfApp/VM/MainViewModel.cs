// <copyright file="MainViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PremierLeague.WpfApp.VM
{
    using System;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using CommonServiceLocator;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using PremierLeague.WpfApp.BL;
    using PremierLeague.WpfApp.Data;

    /// <summary>
    /// The viewmodel of the main window.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private IPlayerLogic logic;

        /// <summary>
        /// The selected player.
        /// </summary>
        private Player playerSelected;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        /// <param name="logic">An instance of the playerlogic.</param>
        public MainViewModel(IPlayerLogic logic)
        {
            this.logic = logic;

            this.Players = new ObservableCollection<Player>();

            if (this.IsInDesignMode)
            {
                Player player1 = new Player() { Name = "Firstname Lastname", Nationality = "Sugondese", Birthday = DateTime.Today, Position = Position.Forward, Value = "1000000000" };
                this.Players.Add(player1);
            }

            foreach (Player player in logic?.GetAllPlayers())
            {
                this.Players.Add(player);
            }

            this.AddCmd = new RelayCommand(() => this.logic.AddPlayer(this.Players));
            this.ModCmd = new RelayCommand(() => this.logic.ModPlayer(this.PlayerSelected));
            this.DelCmd = new RelayCommand(() => this.logic.DelPlayer(this.Players, this.PlayerSelected));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        public MainViewModel()
            : this(IsInDesignModeStatic ? null : ServiceLocator.Current.GetInstance<IPlayerLogic>())
        {
        }

        /// <summary>
        /// Gets or sets the selected player.
        /// </summary>
        public Player PlayerSelected
        {
            get { return this.playerSelected; }
            set { this.Set(ref this.playerSelected, value); }
        }

        /// <summary>
        /// Gets a collection of the players.
        /// </summary>
        public ObservableCollection<Player> Players { get; private set; }

        /// <summary>
        /// Gets the add command.
        /// </summary>
        public ICommand AddCmd { get; private set; }

        /// <summary>
        /// Gets the modify command.
        /// </summary>
        public ICommand ModCmd { get; private set; }

        /// <summary>
        /// Gets the delete command.
        /// </summary>
        public ICommand DelCmd { get; private set; }
    }
}
