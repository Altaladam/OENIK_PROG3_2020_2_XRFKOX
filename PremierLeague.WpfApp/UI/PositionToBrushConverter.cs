// <copyright file="PositionToBrushConverter.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PremierLeague.WpfApp.UI
{
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows.Media;
    using PremierLeague.WpfApp.Data;

    /// <summary>
    /// Converts the positions into brush colors.
    /// </summary>
    public class PositionToBrushConverter : IValueConverter
    {
        /// <summary>
        /// Converts a position into a brush color.
        /// </summary>
        /// <param name="value">The position.</param>
        /// <param name="targetType">The type of the target.</param>
        /// <param name="parameter">Parameter.</param>
        /// <param name="culture">The culture of the UI.</param>
        /// <returns>Returns an object.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Position position = (Position)value;
            switch (position)
            {
                default:
                case Position.Goalkeeper: return Brushes.Orange;
                case Position.Defender: return Brushes.Gold;
                case Position.Midfielder: return Brushes.LimeGreen;
                case Position.Forward: return Brushes.DodgerBlue;
            }
        }

        /// <summary>
        /// Does nothing.
        /// </summary>
        /// <param name="value">The position.</param>
        /// <param name="targetType">The type of the target.</param>
        /// <param name="parameter">Parameter.</param>
        /// <param name="culture">The culture of the UI.</param>
        /// <returns>Returns an object.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
