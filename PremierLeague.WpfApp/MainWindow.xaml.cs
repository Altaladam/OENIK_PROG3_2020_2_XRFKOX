// <copyright file="MainWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PremierLeague.WpfApp
{
    using System.Windows;
    using GalaSoft.MvvmLight.Messaging;
    using PremierLeague.WpfApp.VM;

    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// An instance of the MainViewModel.
        /// </summary>
        public MainViewModel VM;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.VM = this.FindResource("VM") as MainViewModel;
            Messenger.Default.Register<string>(this, "LogicResult", msg =>
            {
                MessageBox.Show(msg);
            });
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Messenger.Default.Unregister(this);
        }
    }
}
