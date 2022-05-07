// <copyright file="MyIoc.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PremierLeague.WpfApp
{
    using CommonServiceLocator;
    using GalaSoft.MvvmLight.Ioc;

    /// <summary>
    /// An implementation of the SimpleIoc.
    /// </summary>
    internal class MyIoc : SimpleIoc, IServiceLocator
    {
        /// <summary>
        /// Gets an instance of the MyIoc.
        /// </summary>
        public static MyIoc Instance { get; private set; } = new MyIoc();
    }
}
