// <copyright file="EditorWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PremierLeague.WpfApp.UI
{
    using System.Windows;
    using System.Windows.Input;
    using PremierLeague.WpfApp.Data;
    using PremierLeague.WpfApp.VM;

    /// <summary>
    /// Interaction logic for EditorWindow.xaml.
    /// </summary>
    public partial class EditorWindow : Window
    {
        /// <summary>
        /// An instance of the viewmodel.
        /// </summary>
        public EditorViewModel VM;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditorWindow"/> class.
        /// </summary>
        public EditorWindow()
        {
            this.InitializeComponent();

            this.VM = this.FindResource("VM") as EditorViewModel;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EditorWindow"/> class.
        /// </summary>
        /// <param name="oldPlayer">The old player.</param>
        public EditorWindow(Player oldPlayer)
            : this()
        {
            this.VM.Player = oldPlayer;
        }

        /// <summary>
        /// Gets an instance of the player.
        /// </summary>
        public Player Player { get => this.VM.Player; }

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = !(e.Key == Key.Back || e.Key == Key.Delete || e.Key == Key.Subtract || e.Key == Key.OemMinus || (e.Key >= Key.D0 && e.Key <= Key.D9) || (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9));
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
